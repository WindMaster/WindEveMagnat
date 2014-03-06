using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WindEveMagnat.Persistence;

namespace UnitTests.Dao
{
	public class NewEntitiesDaoTest
	{
		readonly NewEntitiesDao _dao = new NewEntitiesDao();

		[Test]
		public void GetAllInvTypeMaterialsTest()
		{
			var result = _dao.GetAllInvTypeMaterials();
			Assert.NotNull(result);
			Assert.Greater(result.Count, 0);
		}

		[Test]
		public void GetAllInvTypesTest()
		{
			var result = _dao.GetAllInvTypes();
			Assert.NotNull(result);
			Assert.Greater(result.Count, 0);
		}

		[Test]
		public void GetAllInvBlueprintTypesTest()
		{
			var result = _dao.GetAllInvBlueprintTypes();
			Assert.NotNull(result);
			Assert.Greater(result.Count, 0);
		}

		[Test]
		public void GetAllInvMetaGroupsTest()
		{
			var result = _dao.GetAllInvMetaGroups();
			Assert.NotNull(result);
			Assert.Greater(result.Count, 0);
		}

		[Test]
		public void GetAllInvMarketGroupsTest()
		{
			var result = _dao.GetAllInvMarketGroups();
			Assert.NotNull(result);
			Assert.Greater(result.Count, 0);
		}

		[Test]
		public void GetAllRamActivitiesTest()
		{
			var result = _dao.GetAllRamActivities();
			Assert.NotNull(result);
			Assert.Greater(result.Count, 0);
		}

		[Test]
		public void GetAllRamTypeRequirementsTest()
		{
			var result = _dao.GetAllRamTypeRequirements();
			Assert.NotNull(result);
			Assert.Greater(result.Count, 0);
		}

		[Test]
		public void GetAllMapRegionsTest()
		{
			var result = _dao.GetAllMapRegions();
			Assert.NotNull(result);
			Assert.Greater(result.Count, 0);
		}
	}
}
