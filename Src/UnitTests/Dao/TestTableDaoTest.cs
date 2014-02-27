using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EveAI.Live;
using NUnit.Framework;
using WindEveMagnat.Domain;
using WindEveMagnat.Persistence;

namespace UnitTests.Dao
{
	public class TestTableDaoTest
	{
		[Test]
		public void TestTableDaoAddRecord()
		{
			var row = new TestTable();
			row.id = 2;
			row.name = "Name 2";
			var dao = new TestTableDao();
			dao.AddTestTableRecord(row);
			
			var lst = dao.GetAllTestTableRecords();
			Assert.NotNull(lst);
			Assert.AreEqual(lst.Count, 1);

			var lst2 = dao.GetAllTestTableRecords();
			Assert.NotNull(lst2);
			Assert.AreEqual(lst2.Count, 1);

			dao.DeleteTestTableRecord(row.id);
			var lst3 = dao.GetAllTestTableRecords();
			Assert.IsNotNull(lst3);
			Assert.AreEqual(lst3.Count, 0);
		}
	}
}
