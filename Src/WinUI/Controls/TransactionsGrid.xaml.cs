using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using EveAI.Live.Account;
using WindEveMagnat.Services;
using WindEveMagnat.UI.DataAccess;
using WindEveMagnat.UI.DataObjects;
using WindEveMagnat.UI.Forms;
using WindEveMagnat.UI.CommonControls;

namespace WindEveMagnat.UI.Controls
{
	/// <summary>
	/// Interaction logic for TransactionsGrid.xaml
	/// </summary>
	public partial class TransactionsGrid : UserControl
	{
		public TransactionsGrid()
		{
			InitializeComponent();
		}

		private void btnLoadTransactions_Click( object sender, RoutedEventArgs e )
		{
			var limit = 50;
			if(chkNoLimit.IsChecked == true)
				limit = int.MaxValue;

			dataGridTransactions.DataContext = TransactionTabHelper.LoadUserTransactions(limit, (long)cbCharacters.SelectedValue);
		}

		private void cbCharacters_Loaded( object sender, RoutedEventArgs e )
		{
			var chars = EveApiService.Instance.GetAllCharacters();
			chars.Add(new APIKeyInfo{Characters = new List<AccountEntry>{new AccountEntry{CharacterID = (long)-1, Name = "All"}}});
			var itemsSource = (from x in chars select new {x.Characters[0].Name, x.Characters[0].CharacterID});
			cbCharacters.ItemsSource = itemsSource;
			cbCharacters.DisplayMemberPath = "Name";
			cbCharacters.SelectedValuePath = "CharacterID";
			cbCharacters.SelectedValue = (long)-1;
		}

		private void DetailsLinkClick(object sender, RoutedEventArgs e)
		{
			e.Handled = true;
			var obj = ((FrameworkElement)sender).DataContext as TransactionRow;
			int typeid = obj.TypeId;
			var detailsForm = new EveItemDetailsForm();
			detailsForm.Init(typeid);
			detailsForm.ShowDialog();
		}

		private void button1_Click( object sender, RoutedEventArgs e )
		{
			 var trans = new ObservableCollection<TransactionRow>();
			 trans.Add(new TransactionRow
			           	{
			           		BuildCost = 10000000,
							DekleinPrice = 15000000,
							JitaPrice = 11000000,
							Price = 15500000,
							GroupName = "Test Group",
							When = DateTime.Now,
							TypeName = "TestDate",
							Quantity = 1,
							Station = "Test Station",
							TypeId = 1,
			           	});
			 trans.Add(new TransactionRow
			           	{
			           		BuildCost = 20000,
							DekleinPrice = 19000,
							JitaPrice = 19000,
							Price = 26500,
							GroupName = "Test Group",
							When = DateTime.UtcNow,
							TypeName = "TestDate",
							Quantity = 12,
							Station = "Test Station",
							TypeId = 2
			           	});
			 trans.Add(new TransactionRow
			           	{
			           		BuildCost = 20000,
							DekleinPrice = 19000,
							JitaPrice = 19000,
							Price = 26500,
							GroupName = "Test Group",
							When = DateTime.UtcNow,
							TypeName = "TestDate",
							Quantity = 12,
							Station = "Test Station",
							TypeId = 2
			           	});
			 trans.Add(new TransactionRow
			           	{
			           		BuildCost = 20000,
							DekleinPrice = 19000,
							JitaPrice = 19000,
							Price = 26500,
							GroupName = "Test Group",
							When = DateTime.UtcNow,
							TypeName = "TestDate",
							Quantity = 12,
							Station = "Test Station",
							TypeId = 2
			           	});
			dataGridTransactions.DataContext = trans;
		}

		internal void SetModeInvestigationView()
		{
			var hiddenColumns = new List<string> {"When", "Total Credit", "My Profit", "My Profit %", "Sell Price", "Station"};
			foreach (var dataGridColumn in dataGridTransactions.Columns)
			{
				if(hiddenColumns.Contains((string)dataGridColumn.Header)) 
					dataGridColumn.Visibility = Visibility.Hidden;
			}
		}

		public void SetModeWithoutFilter()
		{
			gridFilter.Visibility = Visibility.Hidden;
			dataGridTransactions.Margin = new Thickness(dataGridTransactions.Margin.Left, 0, dataGridTransactions.Margin.Right, dataGridTransactions.Margin.Bottom);
		}

		private void dataGridTransactions_MouseDoubleClick( object sender, MouseButtonEventArgs e )
		{
			e.Handled = true;
			var obj = ((FrameworkElement)sender).DataContext as TransactionRow;
			if(obj == null)
				return;

			int typeid = obj.TypeId;
			var detailsForm = new EveItemDetailsForm();
			detailsForm.Init(typeid);
			detailsForm.ShowDialog();
		}

		private void ClearAllMenuItem_OnClick(object sender, RoutedEventArgs e)
		{
			dataGridTransactions.DataContext = null;
		}
	}
}
