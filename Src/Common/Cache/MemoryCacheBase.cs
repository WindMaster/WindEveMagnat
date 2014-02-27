using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace WindEveMagnat.Common
{
	public delegate object CacheItemDataProvider();

 	public class MemoryCacheBase<T> : MemoryCache
 	{
 		private CacheItemDataProvider _callBack;

		public MemoryCacheBase(string name, IDictionary<string, MemoryCache> localCache, CacheItemDataProvider callBack) : base(name)
		{
			_callBack = callBack;
			localCache.Add(name, this);
		} 

		public void Add(string name, T item)
		{
			Add(name, item, new CacheItemPolicy());
		}

		public T Get(string key)
		{
			if( !Contains( key ) )
			{
				InvalidateCache();
				return default(T);
			}

			var result = GetCacheItem(key);
			if (!(result is T))
				return default(T);

			return (T)result.Value;
		}

 		private void InvalidateCache()
 		{
 			if (_callBack == null)
 				return;

 			var items = (IList<T>)_callBack();
 			foreach (T item in items)
 			{

 				//Add(item.)
				
 			}
 		}

 		public Dictionary<string, T> GetAll()
		{
			throw new Exception("It is not implemented yet");
		}
	}
}
