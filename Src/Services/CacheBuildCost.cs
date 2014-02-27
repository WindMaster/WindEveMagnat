using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindEveMagnat.Common;

namespace WindEveMagnat.Services
{
	public class CacheBuildCost
	{
		private static CacheBuildCost _instance;
		private readonly Dictionary<int, double> _buildCache = new Dictionary<int, double>(); 
		private readonly object _lockObject = new object();

		public static CacheBuildCost Instance
		{
			get
			{
				if(_instance != null)
					return _instance;
				_instance = new CacheBuildCost();
				return _instance;
			}
		}

		public double GetBuildCostByJitaPrices(int typeId)
		{
			lock(_lockObject)
			{
				double returnValue;
				if (_buildCache.TryGetValue(typeId, out returnValue))
					return returnValue;

				var materialRows = EveDbService.Instance.GetIdealMaterialRowsForItem(typeId);
				var buildPrice = EveMathService.GetBuildPriceForItem(materialRows);
				_buildCache.Add(typeId, buildPrice);

				return buildPrice;
			}
		}
	}
}
