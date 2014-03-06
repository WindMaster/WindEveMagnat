using System.Collections.Generic;
using System.Linq;
using WindEveMagnat.Domain.Wind.Eve;
using WindEveMagnat.Persistence;

namespace WindEveMagnat.Services
{
	public class NewEntitiesService
	{
		private static NewEntitiesService _newEntitiesService;
		private static readonly NewEntitiesDao _newEntitiesDao = new NewEntitiesDao();

		public static NewEntitiesService Instance
		{
			get
			{
				if (_newEntitiesService != null)
					return _newEntitiesService;

				_newEntitiesService = new NewEntitiesService();
				return _newEntitiesService;
			}
		}

		public Dictionary<int, InvType> GetAllInvTypes()
		{
			return _newEntitiesDao.GetAllInvTypes().ToDictionary(x=>x.Id, x=>x);
		}

		public IList<InvTypeMaterial> GetAllInvTypeMaterials()
		{
			return _newEntitiesDao.GetAllInvTypeMaterials();
		}

		public IDictionary<int, InvBlueprintType> GetAllInvBlueprintTypes()
		{
			return _newEntitiesDao.GetAllInvBlueprintTypes().ToDictionary(x=>x.Id, x=>x);
		}

		public IDictionary<int, InvMetaGroup> GetAllInvMetaGroups()
		{
			return _newEntitiesDao.GetAllInvMetaGroups().ToDictionary(x=>x.Id, x=>x);
		}

		public IDictionary<int, InvMarketGroup> GetAllInvMarketGroups()
		{
			return _newEntitiesDao.GetAllInvMarketGroups().ToDictionary(x=>x.Id, x=>x);
		}

		public IDictionary<int, RamActivity> GetAllRamActivities()
		{
			return _newEntitiesDao.GetAllRamActivities().ToDictionary(x=>x.Id, x=>x);
		}

		public IList<RamTypeRequirement> GetAllRamTypeRequirements()
		{
			return _newEntitiesDao.GetAllRamTypeRequirements();
		}

		public IDictionary<int, MapRegion> GetAllMapRegions()
		{
			return _newEntitiesDao.GetAllMapRegions().ToDictionary(x=>x.Id, x=>x);
		}
	}
}
