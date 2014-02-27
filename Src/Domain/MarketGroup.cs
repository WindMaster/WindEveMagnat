using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindEveMagnat.Domain
{
	public class MarketGroup
	{
		public string GroupName { get; set; }
		public string Description { get; set; }
		public int GroupId { get; set; }
		public int ParentGroupId { get; set; }
		public int Level { get; set; }
	}
}
