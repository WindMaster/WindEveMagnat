namespace WindEveMagnat.Domain.Wind.Eve
{
	public class InvType : InvObject
	{
		public int GroupId { get; set; }
		public float Mass { get; set; }
		public float Volume { get; set; }
		public float Capacity { get; set; }
		public int PortionSize { get; set; }
		public int RaceId { get; set; }
		public int BasePrice { get; set; }
		public int MarketGroupId { get; set; }
	}
}
