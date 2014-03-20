using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.Wind.Eve;

namespace WindEveMagnat.Services
{
	public static class EveMathService
	{
		public static double GetBuildPriceForItemNew(IList<BlueprintMaterialRow> rows)
		{
			double finalPrice = 0;
			foreach (var blueprintMaterialRow in rows)
			{
				var price = CachedPrices.GetSellPrice(blueprintMaterialRow.typeid, MapRegion.TheForge.Id);
				if(price <= 0)
					continue;
				finalPrice += blueprintMaterialRow.quantity*price;
			}
			return finalPrice;
		}

		public static double GetBuildCostWithWaste(double buildCost)
		{
			return buildCost*1.2; // -1
		}

		public static double GetBuildCostByJitaPrices(int typeId)
		{
			var materialRows = EveDbService.Instance.GetIdealMaterialRowsForItem(typeId);
			var buildPrice = GetBuildPriceForItemNew(materialRows);
			return buildPrice;
		}
	}
}
