using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EveAI.Live;
using NUnit.Framework;
using WindEveMagnat.Services;

namespace UnitTests.Services
{
	public class CacheTests
	{
		[Test]
		public void LoadCacheAndCheckTest()
		{
			var item = Cached.InvGroups.Get("Spaceship Command");
			Assert.NotNull(item);
		}
	}
}
