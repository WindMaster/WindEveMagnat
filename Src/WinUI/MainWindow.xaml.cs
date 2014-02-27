﻿using System;
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
using WindEveMagnat.Services;
using WindEveMagnat.UI.Controls;
using WindEveMagnat.UI.Forms;
using WindEveMagnat.UI.DataAccess;
using WindEveMagnat.UI.DataObjects;

namespace WindEveMagnat.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			appTabControl.SelectionChanged += AppTabControlSelectionChanged;
		}

		void AppTabControlSelectionChanged( object sender, SelectionChangedEventArgs e )
		{
			if(!(sender is TabControl))
				return;

			if(tabMarketBrowser.IsSelected)
			{
				marketBrowserControl.OnLoad();
			}
		}

		private void MenuExitClick( object sender, RoutedEventArgs e )
		{
			Close();
		}

		private void MenuItemBuyStaffClick(object sender, RoutedEventArgs e)
		{
			using (var buyStuffForm = new BuySomeStaffForm())
			{
				buyStuffForm.ShowDialog();
			}
		}

		private void AccountManagerClick(object sender, RoutedEventArgs e)
		{
			var frmAddEditAccount = new Accounts();
			var result = frmAddEditAccount.ShowDialog();
			if (result == null || result.Value == false)
				return;
		}
	}
}
