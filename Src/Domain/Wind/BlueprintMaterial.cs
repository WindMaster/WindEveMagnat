using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindEveMagnat.Domain.Wind.Eve;

namespace WindEveMagnat.Domain.Wind.Eve
{
	public class BlueprintMaterial : InvType
	{
		public int Quantity { get; set; }
		public double Damage { get; set; }
		public bool IsAdditional { get; set; }

		public BlueprintMaterial()
		{}

		public BlueprintMaterial(InvType baseType) : base(baseType)
		{}
		
		public BlueprintMaterial( BlueprintMaterial baseMaterial ) : base(baseMaterial)
		{
			Quantity = baseMaterial.Quantity;
			Damage = baseMaterial.Damage;
			IsAdditional = baseMaterial.IsAdditional;
		}
	}
}
