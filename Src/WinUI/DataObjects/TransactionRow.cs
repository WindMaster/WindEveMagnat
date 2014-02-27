using System;
using WindEveMagnat.Common;
using WindEveMagnat.UI.CommonControls;

namespace WindEveMagnat.UI.DataObjects
{
	public class TransactionRow
	{
		public DateTime When { get; set; }
		public int TypeId { get; set; }
		public string TypeName { get; set; }
		public string GroupName { get; set; }
		public double Volume { get; set; }
		public double Total { get; set; }
		public long Quantity { get; set; }
		public string Station { get; set; }
		public string SolarSysten { get; set; }
		public string Region { get; set; }

		// prices
		public double Price { get; set; }
		public double BuildCost { get; set; }
		public double JitaPrice { get; set; }
		public double DekleinPrice { get; set; }

		public double DeliveryToFromJitaCost
		{
			get { return Volume*0; }
		}

		public double DeliveryInDeklein
		{
			get { return Volume*0; }
		}

		// profit calculations
		public double ProfitOfMySelling
		{
			get { return Price - BuildCost - DeliveryInDeklein; }
		}

		public double ProfitOfMySellingRate
		{
			get
			{
				return (1-(BuildCost + DeliveryInDeklein)/(Price))*100;
			}
		}

		public double ProfitBuildForJita
		{
			get { return JitaPrice - BuildCost - DeliveryToFromJitaCost - DeliveryInDeklein; }
		}

		public double ProfitBuildForJitaRate
		{
			get
			{
				return (1-(BuildCost + DeliveryToFromJitaCost + DeliveryInDeklein)/JitaPrice)*100;
			}
		}
		public double ProfitBuildForDeklein
		{
			get
			{
				if(Math.Abs(DekleinPrice - 0) < double.Epsilon)
					DekleinPrice = Price;

				return DekleinPrice - BuildCost - DeliveryInDeklein;
			}
		}
		public double ProfitBuildForDekleinRate
		{
			get
			{
				if(Math.Abs(DekleinPrice - 0) < double.Epsilon)
					DekleinPrice = Price;

				return (1-(BuildCost + DeliveryInDeklein)/DekleinPrice)*100;
			}
		}
		public double ProfitImportToDeklein
		{
			get
			{
				if(Math.Abs(DekleinPrice - 0) < double.Epsilon)
					DekleinPrice = Price;

				return DekleinPrice - JitaPrice - DeliveryToFromJitaCost;
			}
		}
		public double ProfitImportToDekleinRate
		{
			get
			{
				if(Math.Abs(DekleinPrice - 0) < double.Epsilon)
					DekleinPrice = Price;

				return (1-(JitaPrice + DeliveryToFromJitaCost)/DekleinPrice)*100;
			}
		}
		
		// Formatted values
		public string TotalFormatted
		{
			get { return CommonUtils.ToMoneyFormat(Total); }
		}

		public string QuantityFormatted
		{
			get { return Quantity.ToString(); }
		}

		public string PriceFormatted { get { return CommonUtils.ToMoneyFormat(Price); } }
		public string BuildCostFormatted { get { return CommonUtils.ToMoneyFormat(BuildCost); } }
		public string JitaPriceFormatted { get { return CommonUtils.ToMoneyFormat(JitaPrice); } }
		public string DekleinPriceFormatted { get { return CommonUtils.ToMoneyFormat(DekleinPrice); } }
		
		public string ProfitOfMySellingFormatted { get { return CommonUtils.ToMoneyFormat(ProfitOfMySelling); } }
		public string ProfitOfMySellingRateFormatted { get { return CommonUtils.ToPercentFormat(ProfitOfMySellingRate); } }
		public string ProfitBuildForJitaFormatted { get { return CommonUtils.ToMoneyFormat(ProfitBuildForJita); } }
		public string ProfitBuildForJitaRateFormatted { get { return CommonUtils.ToPercentFormat(ProfitBuildForJitaRate); } }
		public string ProfitBuildForDekleinFormatted { get { return CommonUtils.ToMoneyFormat(ProfitBuildForDeklein); } }
		public string ProfitBuildForDekleinRateFormatted { get { return CommonUtils.ToPercentFormat(ProfitBuildForDekleinRate); } }
		public string ProfitImportToDekleinFormatted { get { return CommonUtils.ToMoneyFormat(ProfitImportToDeklein); } }
		public string ProfitImportToDekleinRateFormatted { get { return CommonUtils.ToPercentFormat(ProfitImportToDekleinRate); } }

		// Color
		public string ProfitOfMySellingColor
		{
			get { return EveMathInColor.GetProfitColorByPrice(ProfitOfMySelling); }
		}
		public string ProfitOfMySellingRateColor
		{
			get { return EveMathInColor.GetProfitRateColorByRate(ProfitOfMySellingRate); }
		}
		public string ProfitBuildForJitaColor
		{
			get { return EveMathInColor.GetProfitColorByPrice(ProfitBuildForJita); }
		}
		public string ProfitBuildForJitaRateColor
		{
			get { return EveMathInColor.GetProfitRateColorByRate(ProfitBuildForJitaRate); }
		}
		public string ProfitBuildForDekleinColor
		{
			get { return EveMathInColor.GetProfitColorByPrice(ProfitBuildForDeklein); }
		}
		public string ProfitBuildForDekleinRateColor
		{
			get { return EveMathInColor.GetProfitRateColorByRate(ProfitBuildForDekleinRate); }
		}
		public string ProfitImportToDekleinColor
		{
			get { return EveMathInColor.GetProfitColorByPrice(ProfitImportToDeklein); }
		}
		public string ProfitImportToDekleinRateColor
		{
			get { return EveMathInColor.GetProfitRateColorByRate(ProfitImportToDekleinRate); }
		}
	}
}
