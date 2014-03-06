using System.Collections.Generic;
using WindEveMagnat.Domain.Wind.Eve;

namespace WindEveMagnat.Persistence
{
	public class NewEntitiesDao
	{
		public IList<InvTypeMaterial> GetAllInvTypeMaterials()
		{
			return EntityMapperFactory.EntityMapper.QueryForList<InvTypeMaterial>("GetAllInvTypeMaterials", null);
		}

		public IList<InvType> GetAllInvTypes()
		{
			return EntityMapperFactory.EntityMapper.QueryForList<InvType>("GetAllInvTypes", null);
		}

		public IList<InvBlueprintType> GetAllInvBlueprintTypes()
		{
			return EntityMapperFactory.EntityMapper.QueryForList<InvBlueprintType>("GetAllInvBlueprintTypes", null);
		}

		public IList<InvMetaGroup> GetAllInvMetaGroups()
		{
			return EntityMapperFactory.EntityMapper.QueryForList<InvMetaGroup>("GetAllInvMetaGroups", null);
		}

		public IList<InvMarketGroup> GetAllInvMarketGroups()
		{
			return EntityMapperFactory.EntityMapper.QueryForList<InvMarketGroup>("GetAllInvMarketGroups", null);
		}

		public IList<RamActivity> GetAllRamActivities()
		{
			return EntityMapperFactory.EntityMapper.QueryForList<RamActivity>("GetAllRamActivities", null);
		}

		public IList<RamTypeRequirement> GetAllRamTypeRequirements()
		{
			return EntityMapperFactory.EntityMapper.QueryForList<RamTypeRequirement>("GetAllRamTypeRequirements", null);
		}

		public IList<MapRegion> GetAllMapRegions()
		{
			return EntityMapperFactory.EntityMapper.QueryForList<MapRegion>("GetAllMapRegions", null);
		}
	}
}
