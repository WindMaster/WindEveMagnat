using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WindEveMagnat.Domain;
using WindEveMagnat.Services;

namespace WindEveMagnat.UI.DataAccess
{
	public static class MarketGroupsHelper
	{
		public static TreeViewItem GetMarketGroupsTree()
		{
			var rootItem = new TreeViewItem {Header = "All"};

			var items = EveDbService.Instance.GetAllMarketGroups();

			var curLevel = -1;
			while(true)
			{
				curLevel++;
				var levelItems = items.Where(x => x.Level == curLevel).ToList();
				if(levelItems.Count == 0)
					break;

				foreach (var marketGroup in levelItems)
					AddMarketGroupToTree(rootItem, marketGroup);
			}

			return rootItem;
		}

		private static bool AddMarketGroupToTree( TreeViewItem rootItem, MarketGroup marketGroup )
		{
			if(rootItem.Tag == null || !(rootItem.Tag is int))
				rootItem.Tag = 0;

			var itemId = (Int32)rootItem.Tag;
			if(itemId == marketGroup.ParentGroupId)
			{
				var newItem = new TreeViewItem {Header = marketGroup.GroupName, Tag = marketGroup.GroupId};
				rootItem.Items.Add(newItem);
				return true;
			}
			return rootItem.Items.Cast<TreeViewItem>().Any(item => AddMarketGroupToTree(item, marketGroup));
		}
	}
}
