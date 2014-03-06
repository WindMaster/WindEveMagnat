using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EveAI.Live;
using EveAI.Map;
using NUnit.Framework;
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
			Cached.PreloadAllCaches();
			Cached.SaveAllDictionaries();
		}
	}
}
