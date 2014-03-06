using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.Xml;

namespace WindEveMagnat.Common
{
	public delegate object CacheItemDataProvider();

 	public class MemoryCacheBase
 	{
 		private readonly CacheItemDataProvider _callBack;
		private readonly object _padLock = new object();
		private object DataObject { get; set; }
		protected Type _dataType;
 		protected string _cacheKey;

		public MemoryCacheBase(string cacheKey, Type dataType, IDictionary<string, MemoryCacheBase> localCache, CacheItemDataProvider callBack)
		{
			_callBack = callBack;
			_dataType = dataType;
			_cacheKey = cacheKey;
			localCache.Add(cacheKey, this);
		}

 		public object GetItem()
 		{
 			if (DataObject == null)
 				InvalidateCache();

 			return DataObject;
 		}

 		public void InvalidateCache()
 		{
 			lock (_padLock)
 			{
 				DataObject = _callBack();
 			}
 		}

 		public virtual void SaveToFile()
 		{
 		}
 	}
}
