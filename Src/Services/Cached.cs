using System.Collections.Generic;
using WindEveMagnat.Common.Cache;
using WindEveMagnat.Domain.Wind.Eve;

namespace WindEveMagnat.Services
{
	public class Cached : CachedBase
	{
		public static MemoryCache<Dictionary<int, InvMarketGroup>> InvMarketGroups = new MemoryCache
			<Dictionary<int, InvMarketGroup>>(
			ServiceConst.CachedItemKeys.InvMarketGroups, CachedItems,
			() => NewEntitiesService.Instance.GetAllInvMarketGroups());

		public static MemoryCache<Dictionary<int, InvMetaGroup>> InvMetaGroups = new MemoryCache
			<Dictionary<int, InvMetaGroup>>(
			ServiceConst.CachedItemKeys.InvMetaGroups, CachedItems,
			() => NewEntitiesService.Instance.GetAllInvMetaGroups());

		public static MemoryCache<List<InvTypeMaterial>> InvTypeMaterials = new MemoryCache<List<InvTypeMaterial>>(
			ServiceConst.CachedItemKeys.InvTypeMaterials, CachedItems,
			() => NewEntitiesService.Instance.GetAllInvTypeMaterials());

		public static MemoryCache<Dictionary<int, InvBlueprintType>> InvBlueprintTypes = new MemoryCache
			<Dictionary<int, InvBlueprintType>>(
			ServiceConst.CachedItemKeys.InvBlueprintTypes, CachedItems,
			() => NewEntitiesService.Instance.GetAllInvBlueprintTypes());

		public static MemoryCache<Dictionary<int, InvType>> InvTypes = new MemoryCache<Dictionary<int, InvType>>(
			ServiceConst.CachedItemKeys.InvTypes, CachedItems,
			() => NewEntitiesService.Instance.GetAllInvTypes());

		public static MemoryCache<Dictionary<int, MapRegion>> MapRegions = new MemoryCache<Dictionary<int, MapRegion>>(
			ServiceConst.CachedItemKeys.MapRegions, CachedItems,
			() => NewEntitiesService.Instance.GetAllMapRegions());

		public static MemoryCache<List<RamTypeRequirement>> RamTypeRequirements = new MemoryCache<List<RamTypeRequirement>>(
			ServiceConst.CachedItemKeys.RamTypeRequirements, CachedItems,
			() => NewEntitiesService.Instance.GetAllRamTypeRequirements());

		public static MemoryCache<Dictionary<int, InvGroup>> InvGroups = new MemoryCache<Dictionary<int, InvGroup>>(
			ServiceConst.CachedItemKeys.InvGroups, CachedItems,
			() => NewEntitiesService.Instance.GetAllInvGroups());
	}
}
