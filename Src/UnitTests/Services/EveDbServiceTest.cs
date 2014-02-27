using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WindEveMagnat.Domain;
using WindEveMagnat.Services;

namespace UnitTests.Services
{
	public class EveDbServiceTest
	{
		[Test]
		public void GetIdealMaterialRowsForItemTest()
		{
			const int testItemId = 645; // Dominix
			var materials = EveDbService.Instance.GetIdealMaterialRowsForItem(testItemId);
			Assert.AreEqual(1407, materials.First(x => x.typeid == (int)EveMineralsEnum.Megacyte && x.isadditional == false).quantity);
			Assert.AreEqual(1993, materials.First(x => x.typeid == (int)EveMineralsEnum.Megacyte && x.isadditional).quantity);
			Assert.AreEqual(true, materials.First(x => x.typeid == (int)EveMineralsEnum.Megacyte && x.isadditional).isadditional);
		}

		[Test]
		[TestCase(645, "Dominix")]
		public void GetItemByIdTest(int itemId, string itemName)
		{
			var item = EveDbService.Instance.GetItemTypeById(itemId);
			Assert.AreEqual(itemName, item.TypeName);
			Assert.AreEqual(MetaGroup.Tech.MetaGroupId, item.MetaGroupId);
		}

		[Test]
		public void GetRootMarketGroupsTest()
		{
			var items = EveDbService.Instance.GetRootMarketGroups();
			Assert.AreEqual(15, items.Count);
		}

		[Test]
		public void GetAllMarketGroupsTest()
		{
			var items = EveDbService.Instance.GetAllMarketGroups();
			Assert.AreEqual(1611, items.Count);
		}

		[Test]
		public void GetMarketItemsForGroupTest()
		{
			var items = EveDbService.Instance.GetMarketItemsForGroup(840);
			Assert.AreEqual(4, items.Count);
			
		}
	}
}
