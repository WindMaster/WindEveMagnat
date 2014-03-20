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
		public int? GroupId { get; set; }

		public InvType()
		{
			
		}

		public InvType(InvType baseType) : base(baseType)
		{
			MetaGroupId = baseType.MetaGroupId;
			Mass = baseType.Mass;
			Volume = baseType.Volume;
			Capacity = baseType.Capacity;
			PortionSize = baseType.PortionSize;
			RaceId = baseType.RaceId;
			BasePrice = baseType.BasePrice;
			MarketGroupId = baseType.MarketGroupId;
			GroupId = baseType.GroupId;
		}
	}
}
