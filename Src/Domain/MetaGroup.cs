using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindEveMagnat.Domain
{
	public class MetaGroup
	{
		public int MetaGroupId { get; set; }
		public string MetaGroupName { get; set; }

		public static MetaGroup Tech = new MetaGroup {MetaGroupId = 0, MetaGroupName = "Tech I"};
		public static MetaGroup Tech1 = new MetaGroup {MetaGroupId = 1, MetaGroupName = "Tech I"};
		public static MetaGroup Tech2 = new MetaGroup {MetaGroupId = 2, MetaGroupName = "Tech II"};
		public static MetaGroup Storyline = new MetaGroup {MetaGroupId = 3, MetaGroupName = "Storyline"};
		public static MetaGroup Faction = new MetaGroup {MetaGroupId = 4, MetaGroupName = "Faction"};
		public static MetaGroup Officer = new MetaGroup {MetaGroupId = 5, MetaGroupName = "Officer"};
		public static MetaGroup Deadspace = new MetaGroup {MetaGroupId = 6, MetaGroupName = "Deadspace"};
		public static MetaGroup Frigates = new MetaGroup {MetaGroupId = 7, MetaGroupName = "Frigates"};
		public static MetaGroup EliteFrigates = new MetaGroup {MetaGroupId = 8, MetaGroupName = "Elite Frigates"};
		public static MetaGroup CommanderFrigates = new MetaGroup {MetaGroupId = 9, MetaGroupName = "Commander Frigates"};
		public static MetaGroup Destroyer = new MetaGroup {MetaGroupId = 10, MetaGroupName = "Destroyer"};
		public static MetaGroup Cruiser = new MetaGroup {MetaGroupId = 11, MetaGroupName = "Cruiser"};
		public static MetaGroup EliteCruiser = new MetaGroup {MetaGroupId = 12, MetaGroupName = "Elite Cruiser"};
		public static MetaGroup CommanderCruiser = new MetaGroup {MetaGroupId = 13, MetaGroupName = "Commander Cruiser"};
		public static MetaGroup Tech3 = new MetaGroup {MetaGroupId = 11, MetaGroupName = "Tech III"};

		public static bool IsT2(int i)
		{
			return i == Tech2.MetaGroupId || i == EliteFrigates.MetaGroupId || i == EliteCruiser.MetaGroupId;
		}
	}
}
