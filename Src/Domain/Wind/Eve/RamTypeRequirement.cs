using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindEveMagnat.Domain.Wind.Eve
{
	public class RamTypeRequirement
	{
		public int TypeId { get; set; }
		public int ActivityId { get; set; }
		public int RequiredTypeId { get; set; }
		public int Quantity { get; set; }
		public float DamagePerJob { get; set; }
		public int Recycle { get; set; }
	}
}
