using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindEveMagnat.Domain.Eve
{
	public class EveGroup
	{
		public int GroupId { get; set; }
		public int CategoryId { get; set; }
		public string GroupName { get; set; }
		public string Description { get; set; }
		public int IconId { get; set; }

		public static EveGroup Industrial = new EveGroup{GroupId = 28, CategoryId = 6, GroupName = "Industrial"};
		public static EveGroup Minerals = new EveGroup{GroupId = 18, CategoryId = 6, GroupName = "Minerals"};
		public static EveGroup SalvageT1 = new EveGroup{GroupId = 754, CategoryId = 6, GroupName = "SalvageT1"};
		public static EveGroup SalvageT2 = new EveGroup{GroupId = 754, CategoryId = 6, GroupName = "SalvageT2"};
	}
}
