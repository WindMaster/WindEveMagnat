using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindEveMagnat.Common.Cache
{
	interface ICacheDataProvider<T>
	{
		T GetEntity(int id);
		IList<T> GetAllEntities();
	}
}
