using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace WindEveMagnat.Common
{
	public class CacheItemBase<T> : CacheItem
	{
		public CacheItemBase(string key, T value) : base(key, value)
		{
		}

		public T GetObject
		{
			get
			{
				if (!(Value is T))
					return default(T);

				return (T)Value;
			}
		}
	}
}
