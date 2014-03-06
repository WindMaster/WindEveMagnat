using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.Wind.Eve;

namespace WindEveMagnat.Services
{
	public class CachePrices
	{
		private static CachePrices _instance;

		private readonly Dictionary<int, Dictionary<int, double>> _allRegionPrices = new Dictionary<int, Dictionary<int, double>>(); 
		private bool _isWarm;
		private readonly object _lockObject = new object();

		public static CachePrices Instance
		{
			get
			{
				if(_instance != null)
					return _instance;
				_instance = new CachePrices();
				return _instance;
			}
		}

		private Dictionary<int, double> GetOrCreateRegionDictionary(int regionId, Dictionary<int, double> initValues = null)
		{
			Dictionary<int, double> regionPrices;
			if (!_allRegionPrices.TryGetValue(regionId, out regionPrices))
			{
				if (initValues == null)
					initValues = new Dictionary<int, double>();

				regionPrices = new Dictionary<int, double>(initValues);
				_allRegionPrices.Add(regionId, regionPrices);
			}

			return regionPrices;
		}

		public double GetCurrentPrice(int typeId, int regionId = -1)
		{
			if (regionId == -1)
				regionId = MapRegion.GetDefault();

			lock (_lockObject)
			{
				Warm();

				double returnValue;
				var jitaPrices = GetOrCreateRegionDictionary(regionId);
				if (jitaPrices.TryGetValue(typeId, out returnValue))
					return returnValue;

				var price = MarketDataService.Instance.GetItemCurrentPrice(typeId, regionId);
				jitaPrices.Add(typeId, price);
				return price;
			}
		}

		private void Warm()
		{
			if(_isWarm)
				return;
			
				var prices = MarketDataService.Instance.GetAllMaterials();
				GetOrCreateRegionDictionary(MapRegion.GetDefault(), prices);
				_isWarm = true;
		}
	}
}
