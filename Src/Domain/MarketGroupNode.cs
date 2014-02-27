using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindEveMagnat.Domain
{
	public class MarketGroupNode : MarketGroup
	{
		public bool IsRoot { get; set; }
		public List<MarketGroupNode> SubItems { get; set; }
		
		public void AddSubItem(MarketGroupNode item)
		{
			if(SubItems == null)
				SubItems = new List<MarketGroupNode>();
			SubItems.Add(item);
		} 
	}
}
