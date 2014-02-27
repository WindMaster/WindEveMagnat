using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindEveMagnat.Common
{
	public class Config
	{
		public static string ConnectionString
		{
			get { return "Data Source=(local);Initial Catalog=EveOnline2;Integrated Security=True"; }
		}
	}
}
