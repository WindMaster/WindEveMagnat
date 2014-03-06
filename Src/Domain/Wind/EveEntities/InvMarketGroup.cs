using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindEveMagnat.Domain.Wind.Eve
{
	public class InvMarketGroup : InvObjectWithIcon
	{
		public int? ParentId { get; set; }
		public bool HasTypes { get; set; }
	}
}
