namespace WindEveMagnat.Domain.Wind.Eve
{
	public class InvType : InvObject
	{
		public int? MetaGroupId { get; set; }
		public double? Mass { get; set; }
		public double Volume { get; set; }
		public double? Capacity { get; set; }
		public int? PortionSize { get; set; }
		public int? RaceId { get; set; }
		public decimal? BasePrice { get; set; }
		public int? MarketGroupId { get; set; }
	}
}
