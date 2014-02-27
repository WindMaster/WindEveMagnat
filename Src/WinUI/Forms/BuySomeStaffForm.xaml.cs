using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WindEveMagnat.Common;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.Eve;
using WindEveMagnat.UI.DataObjects;

namespace WindEveMagnat.UI.Forms
{
	/// <summary>
	/// Interaction logic for BuySomeStaffForm.xaml
	/// </summary>
	public partial class BuySomeStaffForm : Window, IDisposable
	{
		private List<EveItemDetailsMaterialRow> _materialRows = new List<EveItemDetailsMaterialRow>();

		public BuySomeStaffForm()
		{
			InitializeComponent();

			ListOfGroups.GroupChanged += OnGroupChanged;
			ListOfItems.Init(_materialRows);

			ListOfGroups.SetGroupChecked();
		}

		public void OnGroupChanged(EveGroup group, bool isChecked)
		{
			if(isChecked)
				AddGroupToList(group);
			else
				RemoveGroupFromList(group);

			ApplySorting();
		}

		private void ApplySorting()
		{
			// It doesn't work at all
			var sortingColumn = ListOfItems.dataGridItems.Columns.First(x => x.SortMemberPath == "SortingColumn");
			if(sortingColumn != null)
			{
				sortingColumn.SortDirection = ListSortDirection.Descending;
				sortingColumn.SortDirection = ListSortDirection.Ascending;
			}
		}

		private void RemoveGroupFromList(EveGroup group)
		{
			if(_materialRows.Count == 0)
				return;

			var materialsToRemove = new List<int>();
			switch (@group.GroupName)
			{
				case "Minerals":
					materialsToRemove.AddRange(Services.MarketDataService.GetMineralsIds());
					break;
				case "SalvageT1":
					materialsToRemove.AddRange(Services.MarketDataService.GetSalvageT1Ids());
					break;
				case "SalvageT2":
					materialsToRemove.AddRange(Services.MarketDataService.GetSalvageT2Ids());
					break;
			}
			foreach (var i in materialsToRemove)
			{
				var index = _materialRows.FindIndex(x => x.typeid == i);
				if(index >= 0)
					_materialRows.RemoveAt(index);
			}
			ListOfItems.Init(_materialRows);
		}

		private void AddGroupToList(EveGroup group)
		{
			var materialsToAdd = new List<int>();
			switch (@group.GroupName)
			{
				case "Minerals":
					materialsToAdd.AddRange(Services.MarketDataService.GetMineralsIds());
					break;
				case "SalvageT1":
					materialsToAdd.AddRange(Services.MarketDataService.GetSalvageT1Ids());
					break;
				case "SalvageT2":
					materialsToAdd.AddRange(Services.MarketDataService.GetSalvageT2Ids());
					break;
			}
			foreach (var i in materialsToAdd)
			{
				var itemObject = Services.EveDbService.Instance.GetItemTypeById(i);
				var item = new EveItemDetailsMaterialRow(
					new BlueprintMaterialRow
						{
							typeid = i,
							dmg = 1,
							isadditional = false,
							name = itemObject.TypeName,
							quantity = 0,
						});
				item.GroupName = itemObject.GroupName;
				_materialRows.Add(item);
			}
			ListOfItems.Init(_materialRows);
//			ListOfItems.NotifyCollectionChanged();
		}

		private void BtnCalcClick( object sender, RoutedEventArgs e )
		{
			double result = 0;
			foreach (var eveItemDetailsMaterialRow in _materialRows)
			{
				result += eveItemDetailsMaterialRow.Cost;
			}

			txtFullCost.Text = CommonUtils.FormatDouble(result).ToString();
			txtFullCostInMil.Text = CommonUtils.ToMoneyFormat(result);
		}

		public void Dispose()
		{
			_materialRows.Clear();
		}
	}
}