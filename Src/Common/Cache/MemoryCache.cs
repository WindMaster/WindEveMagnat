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

		public MemoryCache(string cacheKey, IDictionary<string, MemoryCacheBase> localCache, CacheItemDataProvider callBack)
			: base(cacheKey, typeof(T),localCache, callBack)
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

 		public override void SaveToFile()
 		{
 			InitCacheDirectory();

 			var cacheFileName = CacheFileName;
 			var jsonFile = new JsonFile<T> {FileName = cacheFileName};
			jsonFile.SetObject(Item);
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
