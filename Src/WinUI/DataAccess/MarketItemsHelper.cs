using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.Eve;
using WindEveMagnat.Services;
using WindEveMagnat.UI.DataObjects;

namespace WindEveMagnat.UI.DataAccess
{
	public static class MarketItemsHelper
	{
		public static List<TransactionRow> GetMarketItemsRowsForGroup(int groupId)
		{
			var result = new List<TransactionRow>();
			var items = EveDbService.Instance.GetMarketItemsForGroup(groupId);
			
			ProcessItemsToTransactionList(result, items);

			return result;
		}

		private static void ProcessItemsToTransactionList(List<TransactionRow> result, IList<EveType> items)
		{
			foreach (var item in items)
			{
				if(item == null)
					continue;
				// 30% waste for t2
				var buildCost = CacheBuildCost.Instance.GetBuildCostByJitaPrices(item.TypeId);
				if (MetaGroup.IsT2(item.MetaGroupId))
					buildCost = EveMathService.GetBuildCostWithWaste(buildCost);

				var itemObject = EveDbService.Instance.GetItemTypeById(item.TypeId);
				var jitaPrice = CachePrices.Instance.GetCurrentPrice(item.TypeId);
				var vfkPrice = MarketDataService.Instance.GetItemCurrentPrice(item.TypeId, (int) EveRegionEnum.Deklein);
				var volumeDic = MarketDataService.Instance.GetMarketVolumeForItems(new List<int>{item.TypeId});

				var volume = 0;
				if (volumeDic != null && volumeDic.Count != 0)
					volumeDic.TryGetValue(item.TypeId, out volume);

				var trRow = new TransactionRow
				            	{
				            		TypeName = item.TypeName,
				            		BuildCost = buildCost,
				            		DekleinPrice = vfkPrice,
				            		JitaPrice = jitaPrice,
				            		GroupName = itemObject.GroupName,
				            		TypeId = itemObject.TypeId,
									Quantity = volume
				            	};
				result.Add(trRow);
			}
		}

		public static List<TransactionRow> GetMarketItemRowForItem(int typeId)
		{
			var result = new List<TransactionRow>();
			var item = EveDbService.Instance.GetItemTypeById(typeId);
			var itemList = new List<EveType> {item};

			ProcessItemsToTransactionList(result, itemList);

			return result;
		} 
	}
}
