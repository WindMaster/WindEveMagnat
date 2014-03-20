using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace WindEveMagnat.Common.Cache
{
	public delegate object CacheItemDataProvider();

 	public class MemoryCacheBase
 	{
 		private readonly CacheItemDataProvider _callBack;
		private readonly object _padLock = new object();
		private object DataObject { get; set; }
		protected Type _dataType;
 		protected string _cacheKey;
 		protected int ExpirationInterval = 60; // minutes
 		protected DateTime? ExpirationTime;

 		public bool IsExpired
 		{
 			get { return ExpirationTime == DateTime.MaxValue; }
 			set { ExpirationTime = value ? DateTime.Now : DateTime.MaxValue; }
 		}

 		public MemoryCacheBase(string cacheKey, Type dataType, IDictionary<string, MemoryCacheBase> localCache, CacheItemDataProvider callBack, bool isExpired)
		{
			_callBack = callBack;
			_dataType = dataType;
			_cacheKey = cacheKey;
			IsExpired = isExpired;
			localCache.Add(cacheKey, this);
		}

 		public object GetItem()
 		{
 			if (ExpirationTime != null && ExpirationTime <= DateTime.Now)
 				InvalidateCache();

 			if (DataObject == null)
 				LoadFromFile();

 			if (DataObject == null)
 				InvalidateCache();

			if(IsExpired)
 				ExpirationTime = DateTime.Now.AddMinutes(ExpirationInterval);
			else if(ExpirationTime != DateTime.MaxValue)
				ExpirationTime = DateTime.MaxValue;

 			return DataObject;
 		}

 		protected void SetObject(object items)
 		{
 			lock (_padLock)
 			{
 				DataObject = items;
 			}
 		}

 		public void InvalidateCache()
 		{
 			lock (_padLock)
 			{
 				try
 				{
 					DataObject = _callBack();
					if(DataObject != null)
						SaveToFile(DataObject);
 				}
 				catch(Exception ex)
 				{
 					Console.WriteLine(ex);
 				}
 			}
 		}

		public virtual void LoadFromFile() {}

 		public virtual void SaveToFile(object items = null) {}
 	}
}
