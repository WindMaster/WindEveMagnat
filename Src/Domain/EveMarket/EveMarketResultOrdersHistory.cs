using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindEveMagnat.Domain.EveMarketData.OrdersHistory
{
	public class Row
	{
		public string typeID { get; set; }
		public string regionID { get; set; }
		public string date { get; set; }
		public string lowPrice { get; set; }
		public string highPrice { get; set; }
		public string avgPrice { get; set; }
		public string volume { get; set; }
		public string orders { get; set; }
	}

	public class Result
	{
		public Row row { get; set; }
	}

	public class Emd
	{
		public int version { get; set; }
		public string currentTime { get; set; }
		public string name { get; set; }
		public string key { get; set; }
		public string columns { get; set; }
		public List<Result> result { get; set; }
	}

	public class RootObject
	{
		public Emd emd { get; set; }
	}
}
