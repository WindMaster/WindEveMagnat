using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.Eve;
using WindEveMagnat.Persistence;

namespace WindEveMagnat.Services
{
	public class EveDbService
	{
		private static EveDbService _eveDbService;
		private static ProductionDao _productionDao;
		private static EveEntitiesDao _eveEntitiesDao;

		public static EveDbService Instance
		{
			get
			{
				if (_eveDbService != null)
					return _eveDbService;

				_eveDbService = new EveDbService();
				return _eveDbService;
			}
		}

		public EveDbService()
		{
			_productionDao = new ProductionDao();
			_eveEntitiesDao = new EveEntitiesDao();
		}

		public IList<BlueprintMaterialRow> GetIdealMaterialRowsForItem(int typeid)
		{
			return _productionDao.GetIdealMaterialParameters(typeid);
		}

		public EveType GetItemTypeById(int i)
		{
			return _eveEntitiesDao.GetEveItemById(i);
		}

		public IList<MarketGroup> GetRootMarketGroups()
		{
			return _eveEntitiesDao.GetRootMarketGroups();
		}

		public IList<MarketGroup> GetAllMarketGroups()
		{
			return _eveEntitiesDao.GetAllMarketGroups();
		}

		public IList<EveType> GetMarketItemsForGroup( int group )
		{
			return _eveEntitiesDao.GetMarketItemsForGroup(group);
		}

		public IList<EveType> FindEveItemsByName( string text )
		{
			return _eveEntitiesDao.GetEveItemsByText(text);
		}
	}
}