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
using WindEveMagnat.Domain.Eve;
using WindEveMagnat.Domain.Wind.Eve;
using WindEveMagnat.Services;
using WindEveMagnat.UI.DataObjects;

namespace WindEveMagnat.UI.Controls
{
	public delegate void OnEveItemDoubleClicked(int typeId);
	/// <summary>
	/// Interaction logic for EveItemsFinderControl.xaml
	/// </summary>
	public partial class EveItemsFinderControl : UserControl
	{
		public OnEveItemDoubleClicked OnItemDoubleClicked	 { get; set; }

		public EveItemsFinderControl()
		{
			InitializeComponent();
		}

		private void BtnSearchClick( object sender, RoutedEventArgs e )
		{
			// Search
			if(string.IsNullOrEmpty(txtFinderText.Text))
			{
				MessageBox.Show("Nothing to find");
				return;
			}

			var text = txtFinderText.Text.ToLower();
			var resultList = Cached.InvTypes.Item.Where(x=>x.Value.Name.ToLower().Contains(text)).Select(y=>y.Value);
			listViewItems.DataContext = resultList;
		}

		private void TxtFinderTextKeyDown( object sender, KeyEventArgs e )
		{
			if(e.Key == Key.Enter)
			{
				BtnSearchClick(sender, e);
				e.Handled = true;
			}
		}

		private void ListViewItemsMouseDoubleClick( object sender, MouseButtonEventArgs e )
		{
			if(OnItemDoubleClicked == null)
				return;
			
			var itemObject = (InvType)listViewItems.SelectedValue;
			OnItemDoubleClicked(itemObject.Id);
		}

		private void listViewItems_SelectionChanged( object sender, SelectionChangedEventArgs e )
		{
			e.Handled = true;
		}
	}
}
