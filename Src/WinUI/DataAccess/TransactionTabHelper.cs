using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using EveAI.Live;
using WindEveMagnat.Common;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.Wind.Eve;
using WindEveMagnat.Services;
using WindEveMagnat.UI.DataObjects;

namespace WindEveMagnat.UI.DataAccess
{
	public static class TransactionTabHelper
	{
		public static ObservableCollection<TransactionRow> LoadUserTransactions(int? limit, long characterId)
		{
			var rows = new ObservableCollection<TransactionRow>();
			var indexTransaction = 0;

			var transactions = new List<TransactionEntry>();
			if(characterId == -1)
			{
				var chars = EveApiService.Instance.GetAllCharacters();
				foreach (var apiKeyInfo in chars)
				{
					var trans = EveApiService.Instance.GetAllCharacterTransactions(apiKeyInfo.Characters[0].CharacterID);
					if(trans == null || trans.Count == 0)
						continue;

					transactions.AddRange(trans);
				}
			}
			else
			{
				transactions = EveApiService.Instance.GetAllCharacterTransactions(characterId);
			}
			foreach (var transactionEntry in transactions)
			{
				if(transactionEntry.TransactionType == TransactionType.Buy)
					continue;

				var dateTime = transactionEntry.DateLocalTime;
				var itemName = transactionEntry.TypeName;
				var quantity = transactionEntry.Quantity;
				var unitPrice = transactionEntry.Price;
				var totalPrice = transactionEntry.PriceTotal;
				var itemObject = Cached.InvTypes.Item[transactionEntry.TypeID];
				
				// 30% waste for t2
				var buildCost = CacheBuildCost.Instance.GetBuildCostByJitaPrices(transactionEntry.TypeID);
				if(InvMetaGroup.IsT2(itemObject.MetaGroupId))
					buildCost = EveMathService.GetBuildCostWithWaste(buildCost);
				
				if(buildCost == 0)
					continue;

				var jitaPrice = CachePrices.Instance.GetCurrentPrice(transactionEntry.TypeID);
				var vfkPrice = MarketDataService.Instance.GetItemCurrentPrice(transactionEntry.TypeID, MapRegion.Deklein.Id);
				var metaGroupName = itemObject.MetaGroupId.HasValue ? Cached.InvMetaGroups.Item[itemObject.MetaGroupId.Value].Name : "<none>";

				rows.Add(new TransactionRow
				         	{
				         		When = dateTime,
				         		BuildCost = buildCost,
				         		DekleinPrice = vfkPrice,
				         		JitaPrice = jitaPrice,
				         		Price = unitPrice,
								Volume = itemObject.Volume,
				         		Quantity = quantity,
				         		Station = transactionEntry.StationName,
				         		Total = totalPrice,
				         		TypeName = itemName,
				         		TypeId = transactionEntry.TypeID,
								GroupName = metaGroupName
				         	});
				indexTransaction++;

				if(limit < indexTransaction)
					break;
			}
			return rows;
		}
	}
}
