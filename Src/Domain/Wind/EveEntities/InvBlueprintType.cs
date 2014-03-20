using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindEveMagnat.Domain.Wind.Eve
{
	public class InvBlueprintType : InvObject
	{
		public int? ParentBlueprintTypeId { get; set; }
		public int? ProductTypeId { get; set; }
		public int? ProductionTime { get; set; }
		public int? TechLevel { get; set; }
		public int? ResearchProductivityTime { get; set; }
		public int? ResearchMaterialTime { get; set; }
		public int? ResearchCopyTime { get; set; }
		public int? ResearchTechTime { get; set; }
		public int? ProductivityModifier { get; set; }
		public int? MaterialModifier { get; set; }
		public int? WasteFactor { get; set; }
		public int? MaxProductionLimit { get; set; }

		public InvBlueprintType()
		{
			
		}

		public InvBlueprintType(InvBlueprintType baseType) : base(baseType)
		{
			ParentBlueprintTypeId = baseType.ParentBlueprintTypeId;
			ProductTypeId = baseType.ProductTypeId;
			ProductionTime = baseType.ProductionTime;
			TechLevel = baseType.TechLevel;
			ResearchProductivityTime = baseType.ResearchProductivityTime;
			ResearchMaterialTime = baseType.ResearchMaterialTime;
			ResearchCopyTime = baseType.ResearchCopyTime;
			ResearchTechTime = baseType.ResearchTechTime;
			ProductivityModifier = baseType.ProductivityModifier;
			MaterialModifier = baseType.MaterialModifier;
			WasteFactor = baseType.WasteFactor;
			MaxProductionLimit = baseType.MaxProductionLimit;
		}
	}
}
