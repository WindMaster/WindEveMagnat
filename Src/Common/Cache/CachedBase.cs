using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindEveMagnat.Common.Cache
{
	public class CachedBase
	{
		protected static readonly Dictionary<string, MemoryCacheBase> CachedItems = new Dictionary<string, MemoryCacheBase>();

		public static void SaveAllDictionaries()
		{
			foreach (var memoryCacheBase in CachedItems)
				memoryCacheBase.Value.SaveToFile();
		}

		public static void PreloadAllCachesFromDb()
		{
			foreach (var memoryCacheBase in CachedItems)
				memoryCacheBase.Value.InvalidateCache();
		}

		public static void PreloadAllCachesFromFiles()
		{
			foreach (var memoryCacheBase in CachedItems)
				memoryCacheBase.Value.LoadFromFile();
		}
	}
}
