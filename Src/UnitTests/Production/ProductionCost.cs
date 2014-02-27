using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WindEveMagnat.Services;

namespace UnitTests.Production
{
	public class ProductionCost
	{
		[Test]
		public void ProductionT2Cost_Manticore()
		{
			// Manticore
			const int manticoreTypeId = 12032; 
			var materialRows = EveDbService.Instance.GetIdealMaterialRowsForItem(manticoreTypeId);
			var buildPrice = EveMathService.GetBuildPriceForItem(materialRows);
			Assert.Greater(buildPrice, 12000000);
		}

		[Test]
		public void ProductionT2Cost_Sabre()
		{
			// Sabre
			const int sabreTypeId = 22457; 
			var materialRows = EveDbService.Instance.GetIdealMaterialRowsForItem(sabreTypeId);
			var buildPrice = EveMathService.GetBuildPriceForItem(materialRows);
			Assert.Greater(buildPrice, 12000000);
		}
	}
}
