using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindEveMagnat.Domain.Wind.Eve
{
	class InvBlueprintType : InvObject
	{
		public int ParentId { get; set; }
		public int ProductTypeId { get; set; }
		public int ProductionTime { get; set; }
		public int TechLevel { get; set; }
		public int ResearchProductivityTime { get; set; }
		public int ResearchMaterialTime { get; set; }
		public int ResearchCopyTime { get; set; }
		public int ResearchTechTime { get; set; }
		public int ProductivityModifier { get; set; }
		public int MaterialModifier { get; set; }
		public int WasteFactor { get; set; }
		public int MaxProductionLimit { get; set; }
	}
}
