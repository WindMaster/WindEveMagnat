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

namespace WindEveMagnat.UI.Controls
{
	/// <summary>
	/// Interaction logic for MarketFilterPanelControl.xaml
	/// </summary>
	public partial class MarketFilterPanelControl : UserControl
	{
		public MarketFilterPanelControl()
		{
			InitializeComponent();
		}

		public bool IsAllChecked { get { return ChkAllBox.IsChecked ?? false; } }
		public bool IsTech1Checked { get { return ChkTech1Box.IsChecked ?? false; } }
		public bool IsTech2Checked { get { return ChkTech2Box.IsChecked ?? false; } }
		public bool IsCapitalRigsChecked { get { return ChkCapitalRigs.IsChecked ?? false; } }
		public bool IsLargeRigsChecked { get { return ChkLargeRigs.IsChecked ?? false; } }
		public bool IsMediumRigsChecked { get { return ChkMediumRigs.IsChecked ?? false; } }
		public bool IsFractionChecked { get { return ChkFractionBox.IsChecked ?? false; } }

		public List<int> GetActiveMarketGroups()
		{
			if (IsAllChecked)
				return null;

			if (IsTech2Checked)
				return new List<int> {1, 2};

			return new List<int>();
		}

		private void ChkFilterChecked(object sender, RoutedEventArgs e)
		{
			e.Handled = true;
			var allCheckBoxes = new List<CheckBox>
			{
				ChkCapitalRigs,
				ChkFractionBox,
				ChkLargeRigs,
				ChkMediumRigs,
				ChkTech1Box,
				ChkTech2Box
			};
	
			var chkControl = e.OriginalSource as CheckBox;
			if (chkControl == null)
				return;

			// Check all box - uncheck all other boxes
			var isCurrentControlChecked = chkControl.IsChecked ?? false;
			if (chkControl == ChkAllBox && isCurrentControlChecked)
			{
				foreach (var allCheckBox in allCheckBoxes)
				{
					allCheckBox.IsChecked = false;
				}
				return;
			}

			// unchecked all - check all
			var isChecked = false;
			foreach (var allCheckBox in allCheckBoxes)
			{
				if (allCheckBox.IsChecked ?? false)
					isChecked = true;
			}
			if (isChecked)
			{
				ChkAllBox.IsChecked = true;
				return;
			}
		}

		private void Filter_OnClick(object sender, RoutedEventArgs e)
		{
		}
	}
}
