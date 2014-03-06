using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.VisualStyles;
using WindEveMagnat.Domain.Wind.Eve;
using WindEveMagnat.Services;

namespace WindEveMagnat.UI.DataAccess
{
	public static class MarketGroupsHelper
	{
		public static TreeViewItem GetMarketGroupsTree()
		{
			var rootItem = new TreeViewItem {Header = "All"};

			var items = Cached.InvMarketGroups.Item;
			PopulateTreeItemsToNode(rootItem, null, items);

			return rootItem;
		}

		private static void PopulateTreeItemsToNode(TreeViewItem parentNode, int? currentNodeId, Dictionary<int, InvMarketGroup> items)
		{
			var filteredItems = items.Where(x => x.Value.ParentId == currentNodeId);
			foreach (var filteredItem in filteredItems.OrderBy(x => x.Value.Name))
			{
				var id = filteredItem.Key;
				var childNode = new TreeViewItem {Tag = id, Header = filteredItem.Value.Name};

				PopulateTreeItemsToNode(childNode, id, items);
				parentNode.Items.Add(childNode);
			}
		}
	}
}
