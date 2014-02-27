using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindEveMagnat.Domain.Eve
{
	public class EveType
	{
		public int TypeId { get; set; }
		public int GroupId { get; set; }
		public string GroupName { get; set; }
		public string TypeName { get; set; }
		public string Description { get; set; }
		public double Volume { get; set; }
		public int MarketGroup { get; set; }
		public int MetaGroupId { get; set; }
		public string MetaGroupName { get; set; }
	}
}
