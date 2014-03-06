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
using WindEveMagnat.UI.DataAccess;

namespace WindEveMagnat.UI.Controls
{
	public delegate void OnMarketGroupSelected(int marketGroupId);
	public delegate void OnMarketGroupsSelected(List<int> groups);
	/// <summary>
	/// Interaction logic for EveItemsTree.xaml
	/// </summary>
	public partial class EveItemsTree : UserControl
	{
		public OnMarketGroupSelected OnMarketGroupSelected;
		public OnMarketGroupsSelected OnMarketGroupsSelected;

		public EveItemsTree()
		{
			InitializeComponent();
		}

		public void Init(TreeViewItem rootItem)
		{
			treeViewItems.Items.Add(rootItem);
		}

		public int SelectedId
		{
			get
			{
				if(treeViewItems.SelectedValue == null)
					return -1;

				return (int)((TreeViewItem) treeViewItems.SelectedValue).Tag;
			}
		}

		public void OnLoad()
		{
			treeViewItems.Items.Clear();
			treeViewItems.Items.Add(MarketGroupsHelper.GetMarketGroupsTree());	
		}

		private void treeViewItems_MouseDoubleClick( object sender, MouseButtonEventArgs e )
		{
			if (OnMarketGroupSelected == null) 
				return;
			
			OnMarketGroupSelected(SelectedId);
			e.Handled = true;
		}

		private void GetIdsFromTree(TreeViewItem item, ref List<int> result)
		{
			if(item == null)
				return;

			result.Add((int)item.Tag);

			if(item.Items == null || item.Items.Count == 0)
				return;

			foreach (TreeViewItem subItem in item.Items)
				GetIdsFromTree(subItem, ref result);
		}

		private void MenuItemClick( object sender, RoutedEventArgs e )
		{
			var currentGroup = (TreeViewItem)treeViewItems.SelectedValue;
			var resultGroupList = new List<int>();
			GetIdsFromTree(currentGroup, ref resultGroupList);

			if(OnMarketGroupsSelected != null)
				OnMarketGroupsSelected(resultGroupList);

			e.Handled = true;
		}
	}
}
