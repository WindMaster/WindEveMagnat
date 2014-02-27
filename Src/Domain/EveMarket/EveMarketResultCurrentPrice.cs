using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindEveMagnat.Domain.EveMarketData.CurrentPrice
{
	public class Row
	{
		public string buysell { get; set; }
		public string regionID { get; set; }
		public string typeID { get; set; }
		public double price { get; set; }
		public string updated { get; set; }
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
