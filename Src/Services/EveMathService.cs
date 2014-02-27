using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindEveMagnat.Domain;

namespace WindEveMagnat.Services
{
	public static class EveMathService
	{
		public static double GetBuildPriceForItem(IList<BlueprintMaterialRow> itemBuildParams)
		{
			double finalPrice = 0;
			foreach (var blueprintMaterialRow in itemBuildParams)
			{
				var price = CachePrices.Instance.GetCurrentPrice(blueprintMaterialRow.typeid);
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
	}
}
