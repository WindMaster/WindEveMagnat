using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindEveMagnat.Domain.Eve
{
	public class EveCategory
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public int Icon { get; set; }

		public static EveCategory Material = new EveCategory{ CategoryId = 4, CategoryName = "Material", Icon = 22};
		public static EveCategory Accessories = new EveCategory{ CategoryId = 5, CategoryName = "Accessories", Icon = 33};
		public static EveCategory Ship = new EveCategory{ CategoryId = 6, CategoryName = "Ship"};
		public static EveCategory Module = new EveCategory{ CategoryId = 7, CategoryName = "Module", Icon = 67};
		public static EveCategory Blueprint = new EveCategory{ CategoryId = 9, CategoryName = "Blueprint", Icon = 21};
	}
}
