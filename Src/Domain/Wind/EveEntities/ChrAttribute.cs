using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindEveMagnat.Domain.Wind.Eve
{
	public class ChrAttribute : InvObjectWithIcon
	{
		public string ShortDescription { get; set; }
		public string Notes { get; set; }
	}
}
