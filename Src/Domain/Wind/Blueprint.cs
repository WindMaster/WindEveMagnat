using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindEveMagnat.Domain.Wind.Eve;

namespace WindEveMagnat.Domain.Wind
{
	public class Blueprint : InvBlueprintType
	{
		public List<BlueprintMaterial> Materials { get; set; }

		public Blueprint()
		{
		}

		public Blueprint(InvBlueprintType blueprintType) : base(blueprintType)
		{
			
		}
	}
}
