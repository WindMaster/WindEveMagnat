using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.Eve;
using WindEveMagnat.Domain.Wind.Eve;
using WindEveMagnat.Services;
using WindEveMagnat.UI.DataObjects;

namespace WindEveMagnat.UI.DataAccess
{
	public static class MarketItemsHelper
	{
		public static List<TransactionRow> GetMarketItemsRowsForGroup(int groupId)
		{
			var result = new List<TransactionRow>();
			var items = Cached.InvTypes.Item.Where(x=> x.Value.MetaGroupId == groupId).Select(y=>y.Value);
			
			ProcessItemsToTransactionList(result, items);

			return result;
		}

		private static void ProcessItemsToTransactionList(List<TransactionRow> result, IEnumerable<InvType> items)
		{
			foreach (var item in items)
			{
				if(item == null)
					continue;
				// 30% waste for t2
				var buildCost = CacheBuildCost.Instance.GetBuildCostByJitaPrices(item.Id);
				if (InvMetaGroup.IsT2(item.MarketGroupId))
					buildCost = EveMathService.GetBuildCostWithWaste(buildCost);

				var itemObject = Cached.InvTypes.Item[item.Id];
				var groupName = itemObject.MetaGroupId.HasValue ? Cached.InvMetaGroups.Item[itemObject.MetaGroupId.Value].Name : "<none>";
				var jitaPrice = CachePrices.Instance.GetCurrentPrice(item.Id);
				var vfkPrice = MarketDataService.Instance.GetItemCurrentPrice(item.Id, MapRegion.Deklein.Id);
				var volumeDic = MarketDataService.Instance.GetMarketVolumeForItems(new List<int>{item.Id});

				var volume = 0;
				if (volumeDic != null && volumeDic.Count != 0)
					volumeDic.TryGetValue(item.Id, out volume);

				var trRow = new TransactionRow
				            	{
				            		TypeName = item.Name,
				            		BuildCost = buildCost,
				            		DekleinPrice = vfkPrice,
				            		JitaPrice = jitaPrice,
				            		GroupName = groupName,
				            		TypeId = itemObject.Id,
									Quantity = volume
				            	};
				result.Add(trRow);
			}
		}

		public static List<TransactionRow> GetMarketItemRowForItem(int typeId)
		{
			var result = new List<TransactionRow>();
			var item = Cached.InvTypes.Item[typeId];
			var itemList = new List<InvType> {item};

			ProcessItemsToTransactionList(result, itemList);

			return result;
		} 
	}
}
