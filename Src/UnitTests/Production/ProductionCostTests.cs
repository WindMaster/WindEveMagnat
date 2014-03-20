using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WindEveMagnat.Services;

namespace UnitTests.Production
{
	public class ProductionCostTests
	{
		[Test]
		public void ProductionT2Cost_Manticore()
		{
			// Manticore
			const int manticoreTypeId = 12032; 
			var materialRows = EveDbService.Instance.GetIdealMaterialRowsForItem(manticoreTypeId);
			var buildPrice = EveMathService.GetBuildPriceForItemNew(materialRows);
			Assert.Greater(buildPrice, 12000000);
		}

		[Test]
		public void ProductionT2Cost_Sabre()
		{
			// Sabre
			const int sabreTypeId = 22456; 
			var materialRows = EveDbService.Instance.GetIdealMaterialRowsForItem(sabreTypeId);
			var buildPrice = EveMathService.GetBuildPriceForItemNew(materialRows);
			Assert.Greater(buildPrice, 12000000);
		}

		[Test]
		public void ProductionMaterialsSabre()
		{
			// Sabre
			const int sabreTypeId = 22456; 
			var materialRows = EveDbService.Instance.GetIdealMaterialRowsForItem(sabreTypeId);
			var blueprint = NewEntitiesService.Instance.GetBlueprint(sabreTypeId);
			Assert.AreEqual(materialRows.Count, blueprint.Materials.Count);
		}
	}
}
