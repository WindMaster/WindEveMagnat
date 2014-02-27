using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindEveMagnat.Domain;

namespace WindEveMagnat.Persistence
{
	public class TestTableDao
	{
		public void AddTestTableRecord(TestTable row)
		{
			EntityMapperFactory.EntityMapper.Insert("InsertTestTableRecord", row);
		}

		public void UpdateTestTableRecord(TestTable row)
		{
			EntityMapperFactory.EntityMapper.Update("UpdateTestTableRecord", row);
		}

		public void DeleteTestTableRecord(int id)
		{
			EntityMapperFactory.EntityMapper.Delete("DeleteTestTableRecord", id);
		}

		public IList<TestTable> GetAllTestTableRecords()
		{
			return EntityMapperFactory.EntityMapper.QueryForList<TestTable>("GetTestTableRecord", null);
		}
	}
}
