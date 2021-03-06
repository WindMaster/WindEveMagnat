﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.Wind.Eve;
using WindEveMagnat.Services;
using WindEveMagnat.UI.DataObjects;
using WindEveMagnat.Common;

namespace WindEveMagnat.UI.Controls
{
	/// <summary>
	/// Interaction logic for EveItemDetails.xaml
	/// </summary>
	public partial class EveItemDetails : UserControl
	{
		public EveItemDetails()
		{
			InitializeComponent();
		}

		public void LoadItemInfo(int typeid)
		{
			// title 
			var itemFromDb = Cached.InvTypes.Item[typeid];
			if(itemFromDb == null)
			{
				MessageBox.Show("No item in Db for id: " + typeid, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			txtTitle.Text = itemFromDb.Name;

			// jita price 
			var jitaPrice = CachedPrices.GetSellPrice(typeid);
			txtJitaPrice.Text = CommonUtils.ToMoneyFormat(jitaPrice);

			// build cost
			var buildCost = EveMathService.GetBuildCostByJitaPrices(typeid);
			txtBuildCost.Text = CommonUtils.ToMoneyFormat(buildCost);

			// deklein price
			var dekleinPrice = CachedPrices.GetSellPrice(typeid, MapRegion.Deklein.Id);
			txtDekleinPrice.Text = CommonUtils.ToMoneyFormat(dekleinPrice);

			// profit in Deklein
			var deliveryCost = itemFromDb.Volume*0;
			var profit = dekleinPrice - buildCost - deliveryCost;
			txtProfit.Text = CommonUtils.ToMoneyFormat(profit);

			// materials and cost list
			var materials = EveDbService.Instance.GetIdealMaterialRowsForItem(typeid);
			var extendedMaterials = EveItemDetailsMaterialRow.CopyFrom(materials);
			dataGridProductionCost.DataContext = extendedMaterials;
		}
	}
}
