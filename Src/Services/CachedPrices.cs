using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WindEveMagnat.Common.Cache;
using WindEveMagnat.Domain.Wind.Eve;

namespace WindEveMagnat.Services
{
	public class CachedPrices : CachedBase
	{
		protected static string GetDictionaryName(int? regionId, bool isBuy)
		{
			var buySell = isBuy ? "buy" : "sell";
			return string.Format("Prices-{0}-{1}", regionId, buySell);
		}

		public static double GetBuyPrice(int typeId, int? regionId = null)
		{
			return GetPrice(typeId, true, regionId);
		}

		public static double GetSellPrice(int typeId, int? regionId = null)
		{
			return GetPrice(typeId, false, regionId);
		}

		public static double GetPrice(int typeId, bool isBuy, int? regionId = null)
		{
			if (regionId == null)
				regionId = MapRegion.TheForge.Id; // Jita

			// Prices in region
			var cacheKey = GetDictionaryName(regionId, isBuy);
			MemoryCacheBase cache;
			if (!CachedItems.ContainsKey(cacheKey))
			{
				AddPriceBook(regionId.Value, isBuy);
				cache = CachedItems[cacheKey];
				if (cache == null)
					return -1;
			}
			cache = CachedItems[cacheKey];
			if (cache == null)
				return -1;

			var cachedPrices = (Dictionary<int, double>) cache.GetItem();
			if (cachedPrices == null)
				return -1;

			double price;
			if (cachedPrices.TryGetValue(typeId, out price))
				return price;

			return -1;
		}

		protected static void AddPriceBook(int regionId, bool isBuy)
		{
			var key = GetDictionaryName(regionId, isBuy);
			if (CachedItems.ContainsKey(key))
				return;

			new MemoryCache<Dictionary<int, double>>(key, CachedItems, () => MarketDataService.Instance.GetAllPricesForRegion(regionId, isBuy), true);
		}

		public static void InitCache()
		{
			AddPriceBook(MapRegion.TheForge.Id, true);
			AddPriceBook(MapRegion.TheForge.Id, false);

			AddPriceBook(MapRegion.Deklein.Id, true);
			AddPriceBook(MapRegion.Deklein.Id, false);
		}
	}
}
