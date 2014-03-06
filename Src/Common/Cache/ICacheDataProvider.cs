using System.Collections.Generic;

namespace WindEveMagnat.Common.Cache
{
	interface ICacheDataProvider<T>
	{
		T GetEntity(int id);
		IList<T> GetAllEntities();
	}
}
