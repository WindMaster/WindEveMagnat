using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.Wind.Eve;
using WindEveMagnat.Services;

namespace UnitTests.Services
{
	public class MarketDataServiceTest
	{
		[Test]
		public void GetCurrentMineralPricesTest()
		{
			var mineralPrices = MarketDataService.Instance.GetCurrentMineralPrices();
			Assert.IsNotNull(mineralPrices);
			Assert.Greater(mineralPrices.First().Value, 0);
		}

		[Test]
		public void GetItemCurrentPriceTest()
		{
			var dominixPrice = MarketDataService.Instance.GetItemCurrentPrice(645, MapRegion.GetDefault());
			Assert.Greater(dominixPrice, 0);
		}

		[Test]
		public void GetItemMarketVoulmeTest()
		{
			var items = MarketDataService.Instance.GetMarketVolumeForItems(new List<int>{645}, null);
			int volume;
			items.TryGetValue(645, out volume);
			Assert.Greater(volume, 0);
		}
	}
}
