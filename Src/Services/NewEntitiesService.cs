using System.Collections.Generic;
using System.Linq;
using WindEveMagnat.Domain.Wind.Eve;
using WindEveMagnat.Domain.Wind;
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
		public IDictionary<int, InvGroup> GetAllInvGroups()
		{
			return _newEntitiesDao.GetAllInvGroups().ToDictionary(x=>x.Id, x=>x);
		}

		public Blueprint GetBlueprint(int invTypeId)
		{
			var invBlueprintType = Cached.InvBlueprintTypes.Item.First(x => x.Value.ProductTypeId == invTypeId).Value; // Inv Blueprint
			var blueprint = new Blueprint(invBlueprintType); // Blueprint

			blueprint.Materials = new List<BlueprintMaterial>();

			// Main
			var invMaterials = Cached.InvTypeMaterials.Item.Where(x => x.TypeId == invTypeId); // Inv Materials
			foreach (var invTypeMaterial in invMaterials)
			{
				var materialTypeId = Cached.InvTypes.Item.First(x => x.Value.Id == invTypeMaterial.MaterialTypeId).Value;
				var blueprintMaterial = new BlueprintMaterial(materialTypeId);
				blueprintMaterial.Quantity = invTypeMaterial.Quantity;
				blueprintMaterial.Damage = 1; // full destroy
				blueprint.Materials.Add(new BlueprintMaterial(blueprintMaterial));
			}

			// Additional
			var invRamReqs = Cached.RamTypeRequirements.Item.Where(x => x.TypeId == blueprint.Id && x.ActivityId == 1);
			var skillGroups = Cached.InvGroups.Item.Where(x => x.Value.CategoryId == 16).Select(t=>t.Key).ToList();
			foreach (var invRamReq in invRamReqs)
			{
				var materialTypeId = Cached.InvTypes.Item.First(x => x.Value.Id == invRamReq.RequiredTypeId).Value;

				// Skip skills
				if (materialTypeId.GroupId.HasValue && skillGroups.Contains(materialTypeId.GroupId.Value))
					continue;

				var blueprintMaterial = new BlueprintMaterial(materialTypeId);
				blueprintMaterial.Quantity = invRamReq.Quantity.HasValue ? invRamReq.Quantity.Value : 0;
				blueprintMaterial.Damage = invRamReq.DamagePerJob.HasValue ? invRamReq.DamagePerJob.Value : 0;
				blueprint.Materials.Add(new BlueprintMaterial(blueprintMaterial));
			}

			return blueprint;
		}
	}
}
