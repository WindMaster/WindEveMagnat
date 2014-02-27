using System;
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
using WindEveMagnat.Services;
using WindEveMagnat.UI.DataAccess;
using WindEveMagnat.UI.DataObjects;

namespace WindEveMagnat.UI.Controls
{
	/// <summary>
	/// Interaction logic for MarketBrowserControl.xaml
	/// </summary>
	public partial class MarketBrowserControl : UserControl
	{
		public MarketBrowserControl()
		{
			InitializeComponent();
		}

		private bool _isLoaded;
		public void OnLoad()
		{
			if(_isLoaded)
				return;

			eveItemsTree.OnLoad();
			eveItemsTree.OnMarketGroupSelected += OnGroupSelected;
			eveItemsTree.OnMarketGroupsSelected += OnGroupsSelected;
			eveItemsFinder.OnItemDoubleClicked += OnItemSelected;
			transactionsGrid.SetModeInvestigationView();
			transactionsGrid.SetModeWithoutFilter();
			_isLoaded = true;
		}

		private void OnGroupsSelected(List<int> groups)
		{
			var resultList = new List<TransactionRow>();
			foreach (var group in groups)
			{
				var items = MarketItemsHelper.GetMarketItemsRowsForGroup(group);
				resultList.AddRange(items);
			}
			transactionsGrid.dataGridTransactions.DataContext = resultList;
		}

		public void OnGroupSelected(int group)
		{
			var items = MarketItemsHelper.GetMarketItemsRowsForGroup(group);
			transactionsGrid.dataGridTransactions.DataContext = items;
		}

		public void OnItemSelected(int typeId)
		{
			var item = MarketItemsHelper.GetMarketItemRowForItem(typeId);
			if(item == null)
				return;

			transactionsGrid.dataGridTransactions.DataContext = item;
		}

		private void TransactionsGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
		}
	}
}
