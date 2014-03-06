using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindEveMagnat.Domain.Wind.Eve
{
	public class InvMetaGroup : InvObjectWithIcon
	{
		public static InvMetaGroup Tech = new InvMetaGroup{Id = 0, Name = "Tech I"};
		public static InvMetaGroup Tech1 = new InvMetaGroup{Id = 1, Name = "Tech I"};
		public static InvMetaGroup Tech2 = new InvMetaGroup{Id = 2, Name = "Tech II"};
		public static InvMetaGroup Storyline = new InvMetaGroup{Id = 3, Name = "Storyline"};
		public static InvMetaGroup Faction = new InvMetaGroup{Id = 4, Name = "Faction"};
		public static InvMetaGroup Officer = new InvMetaGroup{Id = 5, Name = "Officer"};
		public static InvMetaGroup Deadspace = new InvMetaGroup{Id = 6, Name = "Deadspace"};
		public static InvMetaGroup Frigates = new InvMetaGroup{Id = 7, Name = "Frigates"};
		public static InvMetaGroup EliteFrigates = new InvMetaGroup{Id = 8, Name = "Elite Frigates"};
		public static InvMetaGroup CommanderFrigates = new InvMetaGroup{Id = 9, Name = "Commander Frigates"};
		public static InvMetaGroup Destroyer = new InvMetaGroup{Id = 10, Name = "Destroyer"};
		public static InvMetaGroup Cruiser = new InvMetaGroup{Id = 11, Name = "Cruiser"};
		public static InvMetaGroup EliteCruiser = new InvMetaGroup{Id = 12, Name = "Elite Cruiser"};
		public static InvMetaGroup CommanderCruiser = new InvMetaGroup{Id = 13, Name = "Commander Cruiser"};
		public static InvMetaGroup Tech3 = new InvMetaGroup{Id = 11, Name = "Tech III"};

		public static bool IsT2(int? i)
		{
			if (i == null)
				return false;

			return i == Tech2.Id || i == EliteFrigates.Id || i == EliteCruiser.Id;
		}
	}
}
