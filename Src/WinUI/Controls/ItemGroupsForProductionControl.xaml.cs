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

namespace WindEveMagnat.UI.Controls
{
	public delegate void OnGroupChanged(EveGroup group, bool isChecked);
	/// <summary>
	/// Interaction logic for ItemGroupsForProductionControl.xaml
	/// </summary>
	public partial class ItemGroupsForProductionControl : UserControl
	{
		public OnGroupChanged GroupChanged;

		public ItemGroupsForProductionControl()
		{
			InitializeComponent();
		}

		private void chkMinerals_Click( object sender, RoutedEventArgs e )
		{
			if(GroupChanged != null)
				GroupChanged(EveGroup.Minerals, chkMinerals.IsChecked ?? false);
		}

		private void chkSalvageT1_Click( object sender, RoutedEventArgs e )
		{
			if(GroupChanged != null)
				GroupChanged(EveGroup.SalvageT1, chkSalvageT1.IsChecked ?? false);
		}

		private void chkSalvageT2_Click( object sender, RoutedEventArgs e )
		{
			if(GroupChanged != null)
				GroupChanged(EveGroup.SalvageT2, chkSalvageT2.IsChecked ?? false);
		}

		internal void SetGroupChecked( int p = 0)
		{
			// Default
			if(p == 0)
				chkMinerals.IsChecked = true;

			if(p == 1)
				chkSalvageT1.IsChecked = true;

			if(p == 2)
				chkSalvageT2.IsChecked = true;
		}
	}
}
