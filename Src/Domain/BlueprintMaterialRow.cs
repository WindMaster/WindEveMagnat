using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindEveMagnat.Domain
{
	public class BlueprintMaterialRow
	{
		public int typeid { get; set; }
		public string name { get; set; }
		public int quantity { get; set; }
		public int dmg { get; set; }
		public bool isadditional { get; set; }

		public BlueprintMaterialRow()
		{
		}

		public BlueprintMaterialRow(BlueprintMaterialRow baseItem)
		{
			typeid = baseItem.typeid;
			name = baseItem.name;
			quantity = baseItem.quantity;
			dmg = baseItem.quantity;
			isadditional = baseItem.isadditional;
		}
	}
}
