using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EveAI.Live;
using EveAI.Map;
using NUnit.Framework;
using WindEveMagnat.Domain.Wind.Eve;
using WindEveMagnat.Services;

namespace UnitTests.Services
{
	public class CacheTests
	{
		[Test]
		public void LoadCacheAndCheckTest()
		{
			var cacheItems = Cached.InvMarketGroups.Item.Where(x => x.Value.Name.Length > 0);
			Assert.NotNull(cacheItems);
			Assert.Greater(cacheItems.Count(), 0);
		}

		[Test]
		[Ignore]
		public void LoadFromDbAndSaveToFile()
		{
			Cached.PreloadAllCachesFromDb();
			LoadCacheAndCheckTest();
			Cached.SaveAllDictionaries();
		}

		[Test]
		[Ignore]
		public void LoadFromFileAndSaveToFile()
		{
			Cached.PreloadAllCachesFromFiles();
			LoadCacheAndCheckTest();
		}

		[Test]
		[Ignore]
		public void TestCachedPricesCommon()
		{
			CachedPrices.PreloadAllCachesFromDb();
			CachedPrices.SaveAllDictionaries();
		}

		[Test]
		public void TestPrices()
		{
			var dominix = Cached.InvTypes.Item.FirstOrDefault(x => x.Value.Name == "Dominix").Value;
			var price = CachedPrices.GetSellPrice(dominix.Id, MapRegion.TheForge.Id);
			Assert.Greater(price, 0);
		}

		[Test]
		public void TestPricesPreloadAllCaches()
		{
			var dominix = Cached.InvTypes.Item.FirstOrDefault(x => x.Value.Name == "Dominix").Value;
			CachedPrices.GetPrice(dominix.Id, true, MapRegion.TheForge.Id);
			CachedPrices.GetPrice(dominix.Id, false, MapRegion.TheForge.Id);
			CachedPrices.GetPrice(dominix.Id, true, MapRegion.Deklein.Id);
			CachedPrices.GetPrice(dominix.Id, false, MapRegion.Deklein.Id);
		}
	}
}
