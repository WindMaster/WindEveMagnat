using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WindEveMagnat.Common;
using WindEveMagnat.Domain;
using WindEveMagnat.Services;

namespace WindEveMagnat.UI.DataObjects
{
	public class EveItemDetailsMaterialRow : BlueprintMaterialRow, INotifyPropertyChanged
	{
		public string GroupName { get; set; }

		public EveItemDetailsMaterialRow(BlueprintMaterialRow baseItem) : base(baseItem) { }

		protected EveItemDetailsMaterialRow()
		{
		}

		public static IList<EveItemDetailsMaterialRow> CopyFrom(IList<BlueprintMaterialRow> lst)
		{
			return lst.Select(blueprintMaterialRow => new EveItemDetailsMaterialRow(blueprintMaterialRow)).ToList();
		}

		public event PropertyChangedEventHandler PropertyChanged;
	    private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

		private double _cost;
		public double Cost
		{
			get { return _cost; }
			set
			{
				if (_cost == value) 
					return;

				_cost = value;
				NotifyPropertyChanged("Cost");
			}
		}

		public string CostFormatted
		{
			get
			{
				Cost = Price*quantity;
				return CommonUtils.ToMoneyFormat(Cost);
			}
		}

		public int Quantity
		{
			get { return quantity; }
			set
			{
				if(quantity == value)
					return;

				quantity = value;
				NotifyPropertyChanged("Quantity");
				NotifyPropertyChanged("CostFormatted");
			}
		}

		private double _price;

		public double Price
		{
			get { return _price; }
			set
			{
				if(value == _price)
					return;

				_price = value;
				NotifyPropertyChanged("Price");
			}
		}

		public string PriceFormatted
		{
			get
			{
				Price = CachedPrices.GetPrice(typeid, false);
				return CommonUtils.ToMoneyFormat(Price);
			}
		}

		public string SortingColumn
		{
			get { return string.Format("{0}-{1}", GroupName, name); }
		}

		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				NotifyPropertyChanged("Name");
				NotifyPropertyChanged("SortingColumn");
			}
		}
	}
}
