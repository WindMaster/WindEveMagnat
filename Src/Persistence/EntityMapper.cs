using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using WindEveMagnat.Common;

namespace WindEveMagnat.Persistence
{
	public static class EntityMapperFactory
	{
		public static ISqlMapper EntityMapper
		{
			get
			{
				try
				{
					ISqlMapper mapper = Mapper.Instance();
					mapper.DataSource.ConnectionString = Config.ConnectionString;
					return mapper;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
	}
}
