using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindEveMagnat.UI.CommonControls
{
	public static class EveMathInColor
	{
		public static string GetProfitColorByPrice(double price)
		{
			if(price <= 0)
				return KnownColor.Red.ToString();

			if(price > 0 && price < 1000000)
				return KnownColor.Yellow.ToString();

			return KnownColor.LightGreen.ToString();
		}

		public static string GetProfitRateColorByRate(double rate)
		{
			if(rate <= 0)
				return KnownColor.Red.ToString();

			if(rate > 0 && rate < 10)
				return KnownColor.Yellow.ToString();

			if(rate >= 10 && rate < 20)
				return KnownColor.GreenYellow.ToString();

			return KnownColor.LightGreen.ToString();
		}
	}
}
