using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindEveMagnat.Domain.Wind.Eve;

namespace WindEveMagnat.Domain.Wind
{
	class Blueprint : InvBlueprintType
	{
		public List<InvType> Materials { get; set; }

	}
}
