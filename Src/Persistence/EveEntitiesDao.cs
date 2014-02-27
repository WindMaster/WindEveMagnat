using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.Eve;

namespace WindEveMagnat.Persistence
{
	public class EveEntitiesDao
	{
		public EveType GetEveItemById(int typeid)
		{
			return EntityMapperFactory.EntityMapper.QueryForObject<EveType>("GetEveItemById", typeid);
		}

		public IList<MarketGroup> GetAllMarketGroups()
		{
			return EntityMapperFactory.EntityMapper.QueryForList<MarketGroup>("GetEveAllMarketGroups", null);
		}

		public IList<MarketGroup> GetRootMarketGroups()
		{
			return EntityMapperFactory.EntityMapper.QueryForList<MarketGroup>("GetEveRootMarketGroups", null);
		}

		public IList<EveType> GetMarketItemsForGroup( int group )
		{
			var searchParams = new Hashtable()
			{
				{ "group", group },
			};
			return EntityMapperFactory.EntityMapper.QueryForList<EveType>("GetMarketItemsForGroup", searchParams);
		}

		public IList<EveType> GetEveItemsByText( string text )
		{
			text = string.Format("%{0}%", text);
			return EntityMapperFactory.EntityMapper.QueryForList<EveType>("GetEveItemsByText", text);
		}
	}
}
