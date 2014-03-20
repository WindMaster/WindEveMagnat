using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using Newtonsoft.Json;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.Wind.Eve;

namespace WindEveMagnat.Services
{
	public class MarketDataService
	{
		private static MarketDataService _instance = null;

		private const string RequestUrlFormat =
			"http://api.eve-marketdata.com/api/{0}?char_name={1}&type_ids={2}&region_ids={3}&buysell={4}";

		private const string MyCharacterNameForContract = "Miner_WindMaster";
		private const string CurrentPriceAddress = "item_prices2.json";
		private const string OrdersAddress = "item_orders2.json";
		private const string HistoryAddress = "item_history2.json";

		public static MarketDataService Instance
		{
			get { return _instance ?? (_instance = new MarketDataService()); }
		}

		private static string GetCurrentPriceRequestUrl(string charName, string typeIds, string regionIds, string buySell)
		{
			return string.Format(RequestUrlFormat, CurrentPriceAddress, charName, typeIds, regionIds, buySell);
		}

		private static string GetOrdersAddressRequestUrl(string charName, string typeIds, string regionIds, string buySell)
		{
			return string.Format(RequestUrlFormat, OrdersAddress, charName, typeIds, regionIds, buySell);
		}

		private static string GetHistoryAddressRequestUrl(string charName, string typeIds, string regionIds, string buySell)
		{
			return string.Format(RequestUrlFormat, HistoryAddress, charName, typeIds, regionIds, buySell);
		}

		private static string ProcessRequestFromUrl(string requestUrl)
		{
			string responseString = null;
			try
			{
				var request = WebRequest.Create(requestUrl) as HttpWebRequest;
				if (request == null)
					return null;

				using (var response = request.GetResponse() as HttpWebResponse)
				{
					if (response == null)
						return null;

					if (response.StatusCode != HttpStatusCode.OK)
						throw new Exception(String.Format(
							"Server error (HTTP {0}: {1}).",
							response.StatusCode,
							response.StatusDescription));

					using (var stream = response.GetResponseStream())
					{
						if (stream == null)
							return null;

						var reader = new StreamReader(stream);
						responseString = reader.ReadToEnd();
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
			return responseString;
		}

		public Domain.EveMarketData.CurrentPrice.RootObject GetTestRequest()
		{
			var requestUrl = GetCurrentPriceRequestUrl(MyCharacterNameForContract, "34,12068", "10000002", "s");
			var json = ProcessRequestFromUrl(requestUrl);
			return JsonConvert.DeserializeObject<Domain.EveMarketData.CurrentPrice.RootObject>(json);
		}

		/// <summary>
		/// just the current price, for multiple items
		/// </summary>
		/// <param name="itemIds"></param>
		/// <param name="regionIds"></param>
		/// <param name="buySell"></param>
		/// <returns></returns>
		public Domain.EveMarketData.CurrentPrice.RootObject GetItemInfoCurrent(IList<int> itemIds, IList<int> regionIds,
			string buySell = "s")
		{
			var items = string.Join(",", itemIds);
			var regions = string.Join(",", regionIds);

			var requestUrl = GetCurrentPriceRequestUrl(MyCharacterNameForContract, items, regions, buySell);
			var json = ProcessRequestFromUrl(requestUrl);
			Domain.EveMarketData.CurrentPrice.RootObject result = null;
			try
			{
				result = JsonConvert.DeserializeObject<Domain.EveMarketData.CurrentPrice.RootObject>(json);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return result;
		}

		public Domain.EveMarketData.CurrentPrice.RootObject GetItemInfoCurrent(int itemId, int regionId, string buySell = "s")
		{
			return GetItemInfoCurrent(new List<int> {itemId}, new List<int> {regionId}, buySell);
		}

		public Domain.EveMarketData.CurrentPrice.RootObject GetItemInfoCurrent(List<int> itemIds, int regionId, bool isBuy)
		{
			var buySell = isBuy ? "b" : "s";
			return GetItemInfoCurrent(itemIds, new List<int> {regionId}, buySell);
		}

		public double GetItemCurrentPrice(int itemId, int regionId, string buySell = "s")
		{
			var rootObject = GetItemInfoCurrent(itemId, regionId, buySell);
			return rootObject == null ? 0 : rootObject.emd.result[0].row.price;
		}

		/// <summary>
		/// all market orders
		/// </summary>
		/// <param name="itemIds"></param>
		/// <param name="regionIds"></param>
		/// <param name="buySell"></param>
		/// <returns></returns>
		public Domain.EveMarketData.OrdersInfo.RootObject GetOrdersInfo(IList<int> itemIds, IList<int> regionIds,
			string buySell = "s")
		{
			var items = string.Join(",", itemIds);
			var regions = string.Join(",", regionIds);

			var requestUrl = GetOrdersAddressRequestUrl(MyCharacterNameForContract, items, regions, buySell);
			var json = ProcessRequestFromUrl(requestUrl);
			return JsonConvert.DeserializeObject<Domain.EveMarketData.OrdersInfo.RootObject>(json);
		}

		/// <summary>
		/// daily sales history - same as in-game market:history tab
		/// </summary>
		/// <param name="itemIds"></param>
		/// <param name="regionIds"></param>
		/// <param name="buySell"></param>
		/// <returns></returns>
		public Domain.EveMarketData.OrdersHistory.RootObject GetHistoryInfo(IList<int> itemIds, IList<int> regionIds,
			string buySell = "s")
		{
			var items = string.Join(",", itemIds);
			var regions = string.Join(",", regionIds);

			var requestUrl = GetHistoryAddressRequestUrl(MyCharacterNameForContract, items, regions, buySell);
			var json = ProcessRequestFromUrl(requestUrl);
			if (json == null)
				return null;

			try
			{
				return JsonConvert.DeserializeObject<Domain.EveMarketData.OrdersHistory.RootObject>( json );
			}
			catch( Exception ex )
			{
				Console.WriteLine(ex.Message);
			}
			return null;
		}

		public Dictionary<int, int> GetMarketVolumeForItems(IList<int> itemsIds, IList<int> regionIds = null,
			string buySell = "s")
		{
			var resultDic = new Dictionary<int, int>();
			if (regionIds == null || regionIds.Count == 0)
				regionIds = new List<int> {MapRegion.GetDefault()};

			var rootItem = GetHistoryInfo(itemsIds, regionIds, buySell);
			if (rootItem == null)
				return null;

			foreach (var result in rootItem.emd.result)
			{
				int typeid;
				int volume;
				if (!int.TryParse(result.row.typeID, out typeid) || !int.TryParse(result.row.volume, out volume))
					continue;

				if (!resultDic.ContainsKey(typeid))
					resultDic.Add(typeid, volume);
				else
					resultDic[typeid] += volume;
			}

			return resultDic;
		}

		public Dictionary<int, double> GetCurrentMineralPrices()
		{
			var prices = new Dictionary<int, double>();
			var mineralIds = GetMineralsIds();
			var rootItem = Instance.GetItemInfoCurrent(mineralIds, new List<int> {MapRegion.GetDefault()});
			if (rootItem == null)
				return null;

			foreach (var result in rootItem.emd.result)
			{
				int typeid;
				if (int.TryParse(result.row.typeID, out typeid))
					prices.Add(typeid, result.row.price);
			}
			return prices;
		}

		public Dictionary<int, double> GetCurrentSalvageWithMineralPrices()
		{
			var prices = new Dictionary<int, double>();
			var mineralIds = GetSalvageWithMineralsIds();
			var rootItem = Instance.GetItemInfoCurrent(mineralIds, new List<int> {MapRegion.GetDefault()});
			foreach (var result in rootItem.emd.result)
			{
				int typeid;
				if (int.TryParse(result.row.typeID, out typeid))
					prices.Add(typeid, result.row.price);
			}
			return prices;
		}

		public Dictionary<int, double> GetAllMaterials()
		{
			var prices = new Dictionary<int, double>();
			var mineralIds = GetAllMaterialsIds();
			var rootItem = Instance.GetItemInfoCurrent(mineralIds, new List<int> {MapRegion.GetDefault()});

			try
			{
				foreach (var result in rootItem.emd.result)
				{
					int typeid;
					if (int.TryParse(result.row.typeID, out typeid))
						prices.Add(typeid, result.row.price);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			return prices;
		}

		public Dictionary<int, double> GetCurrentAllMaterialsAndCcPrices()
		{
			var prices = new Dictionary<int, double>();
			var materialsIds = GetConstructionComponentsIds();
			materialsIds.AddRange(GetSalvageWithMineralsIds());
			var rootItem = Instance.GetItemInfoCurrent(materialsIds, new List<int> {MapRegion.GetDefault()});
			foreach (var result in rootItem.emd.result)
			{
				int typeid;
				if (int.TryParse(result.row.typeID, out typeid))
					prices.Add(typeid, result.row.price);
			}
			return prices;
		}

		public static List<int> GetMineralsIds()
		{
			return Common.CommonUtils.GetListFromArray(EveMineralsEnum.Isogen);
		}

		public static List<int> GetSalvageT1Ids()
		{
			return Common.CommonUtils.GetListFromArray(EveSalvageT1Enum.AlloyedTritaniumBar);
		}

		public static List<int> GetSalvageT2Ids()
		{
			return Common.CommonUtils.GetListFromArray(EveSalvageT2Enum.CapacitorConsole);
		}

		public static List<int> GetMaterialsT2Ids()
		{
			return Common.CommonUtils.GetListFromArray(EveSalvageT2Enum.CapacitorConsole);
		}

		public static List<int> GetConstructionComponentsIds()
		{
			var result = new List<int>();
			result.AddRange(Common.CommonUtils.GetListFromArray(EveMaterialsT2AmarrEnum.AntimatterReactorUnit));
			result.AddRange(Common.CommonUtils.GetListFromArray(EveMaterialsT2CaldariEnum.GravimetricSensorCluster));
			result.AddRange(Common.CommonUtils.GetListFromArray(EveMaterialsT2MinmatarEnum.DeflectionShieldEmitter));
			result.AddRange(Common.CommonUtils.GetListFromArray(EveMaterialsT2GallenteEnum.CrystallineCarbonideArmorPlate));
			return result;
		}

		public static List<int> GetSalvageAllIds()
		{
			var salvage = GetSalvageT1Ids();
			salvage.AddRange(GetSalvageT2Ids());
			return salvage;
		}

		public static List<int> GetAllMaterialsIds()
		{
			var minerals = GetMineralsIds();
			var salvage = GetSalvageAllIds();
			var common = GetCommonIds();
			var cc = GetConstructionComponentsIds();
			minerals.AddRange(salvage);
			minerals.AddRange(common);
			minerals.AddRange(cc);
			return minerals;
		}

		private static IEnumerable<int> GetCommonIds()
		{
			return Common.CommonUtils.GetListFromArray(EveItemCommonOther.ConstructionBlocks);
		}

		public static List<int> GetSalvageWithMineralsIds()
		{
			var salvage = GetSalvageAllIds();
			salvage.AddRange(GetMineralsIds());
			return salvage;
		}

		public Dictionary<int, double> GetAllPricesForRegion(int regionId, bool isBuy)
		{
			var result = new Dictionary<int, double>();

			var minItemId = 0;
			var maxItemId = 33407;
			var step = 1000;

			try
			{
				for (int i = minItemId; i < maxItemId/step + 1; i++)
				{
					var fromValue = i*step;
					var items = Enumerable.Range(fromValue, step-1).Select(x => x).ToList();
					var rootItem = GetItemInfoCurrent(items, regionId, isBuy);
					if(rootItem == null)
						break;

					foreach (var resultPrices in rootItem.emd.result)
					{
						int typeid;
						if (int.TryParse(resultPrices.row.typeID, out typeid))
							result.Add(typeid, resultPrices.row.price);
					}
				}
			}
			catch(Exception exception)
			{
				Console.WriteLine(exception.Message);
			}

			if (result.Count == 0)
				return null;

			return result;
		}
	}
}
