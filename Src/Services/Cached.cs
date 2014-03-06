using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using WindEveMagnat.Common;
using WindEveMagnat.Common.Cache;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.Wind.Eve;

namespace WindEveMagnat.Services
{
	public static class Cached
	{
		private static readonly Dictionary<string, MemoryCacheBase> _cachedItems = new Dictionary<string, MemoryCacheBase>();

		public static MemoryCache<Dictionary<int, InvMarketGroup>> InvMarketGroups = new MemoryCache
			<Dictionary<int, InvMarketGroup>>(
			ServiceConst.CachedItemKeys.InvMarketGroups, _cachedItems,
			() => NewEntitiesService.Instance.GetAllInvMarketGroups());

		public static MemoryCache<Dictionary<int, InvMetaGroup>> InvMetaGroups = new MemoryCache
			<Dictionary<int, InvMetaGroup>>(
			ServiceConst.CachedItemKeys.InvMetaGroups, _cachedItems,
			() => NewEntitiesService.Instance.GetAllInvMetaGroups());

		public static MemoryCache<List<InvTypeMaterial>> InvTypeMaterials = new MemoryCache<List<InvTypeMaterial>>(
			ServiceConst.CachedItemKeys.InvTypeMaterials, _cachedItems,
			() => NewEntitiesService.Instance.GetAllInvTypeMaterials());

		public static MemoryCache<Dictionary<int, InvBlueprintType>> InvBlueprintTypes = new MemoryCache
			<Dictionary<int, InvBlueprintType>>(
			ServiceConst.CachedItemKeys.InvBlueprintTypes, _cachedItems,
			() => NewEntitiesService.Instance.GetAllInvBlueprintTypes());

		public static MemoryCache<Dictionary<int, InvType>> InvTypes = new MemoryCache<Dictionary<int, InvType>>(
			ServiceConst.CachedItemKeys.InvTypes, _cachedItems,
			() => NewEntitiesService.Instance.GetAllInvTypes());

		public static MemoryCache<Dictionary<int, MapRegion>> MapRegions = new MemoryCache<Dictionary<int, MapRegion>>(
			ServiceConst.CachedItemKeys.MapRegions, _cachedItems,
			() => NewEntitiesService.Instance.GetAllMapRegions());


		public static void SaveAllDictionaries()
		{
			foreach (var memoryCacheBase in _cachedItems)
				memoryCacheBase.Value.SaveToFile();
		}

		public static void PreloadAllCaches()
		{
			foreach (var memoryCacheBase in _cachedItems)
				memoryCacheBase.Value.InvalidateCache();
		}
	}
}
