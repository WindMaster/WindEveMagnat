using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindEveMagnat.Services;

namespace WindEveMagnat.TestConsole
{
	class Program
	{
		static void Main( string[] args )
		{
			var currentPriceRoot = MarketDataService.Instance.GetTestRequest();
			var orderInfoRoot = MarketDataService.Instance.GetOrdersInfo(new List<int>{34,12068}, new List<int>{10000002});
			var transactions = EveApiService.Instance.GetAllCharacterTransactions();

			var assets = EveApiService.Instance.GetAllCharacterAssets();
			var corpAssets = EveApiService.Instance.GetAllCorpAssets();

			//// test DB connection
			//var idealMaterialForDominix = Services.EveDbService.Instance.GetIdealMaterialRowsForItem(645);
			var reportResult = Reports.GetTransactionsReportConsole();
			foreach (var str in reportResult)
			{
				Console.WriteLine(str);
			}
			
			Console.ReadLine();
		}
	}
}
