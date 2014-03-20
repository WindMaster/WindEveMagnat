using System;
using System.Collections.Generic;
using System.IO;

namespace WindEveMagnat.Common.Cache
{
	public class MemoryCache<T> : MemoryCacheBase where T: class
	{
 		private string CacheFileName
 		{
 			get { return string.Format(@"cache\cache_{0}.json", _cacheKey); }
 		}

		public MemoryCache(string cacheKey, IDictionary<string, MemoryCacheBase> localCache, CacheItemDataProvider callBack, bool isExpired = false)
			: base(cacheKey, typeof(T),localCache, callBack, isExpired)
		{
		}

		public static implicit operator T( MemoryCache<T> obj )
		{
			return obj.Item;
		}

		public T Item
		{
			get
			{
				var item = GetItem();
				if(item == null) return default(T);
				if( !(item is T) )
				{
					return (T)GetItem();
				}
				return (T)item;
			}
		}

		public override void LoadFromFile()
		{
			InitCacheDirectory();

 			var cacheFileName = CacheFileName;
			if (!File.Exists(cacheFileName))
				return;

 			var jsonFile = new JsonFile<T> {FileName = cacheFileName};
			if (!jsonFile.OpenAndRead()) 
				return;

			var items = jsonFile.GetObject();
			if(items != null)
				SetObject(items);
		}

 		public override void SaveToFile(object items = null)
 		{
 			InitCacheDirectory();

 			var cacheFileName = CacheFileName;
 			var jsonFile = new JsonFile<T> {FileName = cacheFileName};
 			if (items == null)
 				items = Item;

			jsonFile.SetObject((T)items);
 			jsonFile.OpenAndWrite();
 		}

		private void InitCacheDirectory()
		{
			if (Directory.Exists("cache"))
				return;

			Directory.CreateDirectory("cache");
		}
	}
}
