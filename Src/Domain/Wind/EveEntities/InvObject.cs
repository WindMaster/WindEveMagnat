namespace WindEveMagnat.Domain.Wind.Eve
{
	public class InvObject
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public InvObject()
		{
			
		}

		public InvObject(InvObject baseInvObject)
		{
			Id = baseInvObject.Id;
			Name = baseInvObject.Name;
			Description = baseInvObject.Description;
		}
	}
}