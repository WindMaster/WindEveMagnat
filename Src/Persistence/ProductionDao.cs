using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindEveMagnat.Domain;

namespace WindEveMagnat.Persistence
{
	public class ProductionDao
	{
		public IList<BlueprintMaterialRow> GetIdealMaterialParameters(int typeid)
		{
			var result = new List<BlueprintMaterialRow>();
			var result1 = EntityMapperFactory.EntityMapper.QueryForList<BlueprintMaterialRow>("GetIdealMaterialParametersMain", typeid);
			if(result1 != null && result1.Count > 0)
				result.AddRange(result1);

			var result2 = EntityMapperFactory.EntityMapper.QueryForList<BlueprintMaterialRow>("GetIdealMaterialParametersAdditional", typeid);
			if(result2 != null && result2.Count > 0)
				result.AddRange(result2);

			return result;
		} 
	}
}
