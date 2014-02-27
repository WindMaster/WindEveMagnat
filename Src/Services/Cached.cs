using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using WindEveMagnat.Common;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.Wind.Eve;

namespace WindEveMagnat.Services
{
	public static class Cached
	{
		static readonly Dictionary<string, MemoryCache> _cachedItems = new Dictionary<string, MemoryCache>();

		/*  
			Old Data Entities
		 */

		public static MemoryCacheBase<MarketGroup> InvGroups = new MemoryCacheBase<MarketGroup>(
		ServiceConst.CachedItemKeys.InvGroups, _cachedItems, 
		() => EveDbService.Instance.GetAllMarketGroups()
		);


	}
}
