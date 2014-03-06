using System;
using System.Collections.Generic;
using System.Linq;

namespace WindEveMagnat.Common
{
	public static class CommonUtils
	{
		public static List<int> GetListFromArray(Enum en)
		{
			return en == null ? null : Enum.GetValues(en.GetType()).Cast<int>().ToList();
		}

		public static double FormatDouble(double xx)
		{
			return Math.Truncate(xx*100)/100;
		}

		public static string ToPercentFormat(double xx)
		{
			return string.Format("{0}%", Math.Truncate(xx));
		}

		public static string ToMoneyFormat(double xx)
		{
			if(Equals(xx, 0d))
				return string.Empty;

			var xxx = Math.Abs(xx);
			if(xxx >= 1000000)
			{
				xx /= 1000000;
				xx = FormatDouble(xx);
				return string.Format("{0} mil", xx);
			}

			if(xxx >= 1000)
			{
				xx /= 1000;
				xx = FormatDouble(xx);
				return string.Format("{0} k", xx);
			}

			xx = FormatDouble(xx);
			return string.Format("{0} isk", xx);
		}

		public static long GetLongFromString(string trim)
		{
			long id;
			var result = long.TryParse(trim, out id);
			if (!result)
				return -1;
			return id;
		}
	}
}
