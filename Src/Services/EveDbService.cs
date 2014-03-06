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
		}

		public IList<BlueprintMaterialRow> GetIdealMaterialRowsForItem(int typeid)
		{
			return _productionDao.GetIdealMaterialParameters(typeid);
		}
	}
}