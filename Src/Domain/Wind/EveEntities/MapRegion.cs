using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindEveMagnat.Domain.Wind.Eve
{
	public class MapRegion : InvObject
	{
		public static MapRegion TheForge = new MapRegion { Id = 10000002, Name = "The Forge"};
		public static MapRegion Deklein = new MapRegion { Id = 10000035, Name = "Deklein"};
		public static MapRegion Aridia = new MapRegion { Id = 10000054, Name = "Aridia"};
		public static MapRegion BlackRise = new MapRegion { Id = 10000069, Name = "Black Rise"};
		public static MapRegion Branch = new MapRegion { Id = 10000055, Name = "Branch"};
		public static MapRegion Cache = new MapRegion { Id = 10000007, Name = "Cache"};
		public static MapRegion Catch = new MapRegion { Id = 10000014, Name = "Catch"};
		public static MapRegion CloudRing = new MapRegion { Id = 10000051, Name = "Cloud Ring"};
		public static MapRegion CobaltEdge = new MapRegion { Id = 10000053, Name = "Cobalt Edge"};
		public static MapRegion Curse = new MapRegion { Id = 10000012, Name = "Curse"};
		public static MapRegion Delve = new MapRegion { Id = 10000060, Name = "Delve"};
		public static MapRegion Derelik = new MapRegion { Id = 10000001, Name = "Derelik"};
		public static MapRegion Detorid = new MapRegion { Id = 10000005, Name = "Detorid"};
		public static MapRegion Devoid = new MapRegion { Id = 10000036, Name = "Devoid"};
		public static MapRegion Domain = new MapRegion { Id = 10000043, Name = "Domain"};
		public static MapRegion Esoteria = new MapRegion { Id = 10000039, Name = "Esoteria"};
		public static MapRegion Essence = new MapRegion { Id = 10000064, Name = "Essence"};
		public static MapRegion EtheriumReach = new MapRegion { Id = 10000027, Name = "Etherium Reach"};
		public static MapRegion Everyshore = new MapRegion { Id = 10000037, Name = "Everyshore"};
		public static MapRegion Fade = new MapRegion { Id = 10000046, Name = "Fade"};
		public static MapRegion Feythabolis = new MapRegion { Id = 10000056, Name = "Feythabolis"};
		public static MapRegion Fountain = new MapRegion { Id = 10000058, Name = "Fountain"};
		public static MapRegion Geminate = new MapRegion { Id = 10000029, Name = "Geminate"};
		public static MapRegion Genesis = new MapRegion { Id = 10000067, Name = "Genesis"};
		public static MapRegion GreatWildlands = new MapRegion { Id = 10000011, Name = "Great Wildlands"};
		public static MapRegion Heimatar = new MapRegion { Id = 10000030, Name = "Heimatar"};
		public static MapRegion Immensea = new MapRegion { Id = 10000025, Name = "Immensea"};
		public static MapRegion Impass = new MapRegion { Id = 10000031, Name = "Impass"};
		public static MapRegion Insmother = new MapRegion { Id = 10000009, Name = "Insmother"};
		public static MapRegion Kador = new MapRegion { Id = 10000052, Name = "Kador"};
		public static MapRegion Khanid = new MapRegion { Id = 10000049, Name = "Khanid"};
		public static MapRegion KorAzor = new MapRegion { Id = 10000065, Name = "Kor-Azor"};
		public static MapRegion Lonetrek = new MapRegion { Id = 10000016, Name = "Lonetrek"};
		public static MapRegion Malpais = new MapRegion { Id = 10000013, Name = "Malpais"};
		public static MapRegion Metropolis = new MapRegion { Id = 10000042, Name = "Metropolis"};
		public static MapRegion MoldenHeath = new MapRegion { Id = 10000028, Name = "Molden Heath"};
		public static MapRegion Oasa = new MapRegion { Id = 10000040, Name = "Oasa"};
		public static MapRegion Omist = new MapRegion { Id = 10000062, Name = "Omist"};
		public static MapRegion OuterPassage = new MapRegion { Id = 10000021, Name = "Outer Passage"};
		public static MapRegion OuterRing = new MapRegion { Id = 10000057, Name = "Outer Ring"};
		public static MapRegion ParagonSoul = new MapRegion { Id = 10000059, Name = "Paragon Soul"};
		public static MapRegion PeriodBasis = new MapRegion { Id = 10000063, Name = "Period Basis"};
		public static MapRegion PerrigenFalls = new MapRegion { Id = 10000066, Name = "Perrigen Falls"};
		public static MapRegion Placid = new MapRegion { Id = 10000048, Name = "Placid"};
		public static MapRegion Providence = new MapRegion { Id = 10000047, Name = "Providence"};
		public static MapRegion PureBlind = new MapRegion { Id = 10000023, Name = "Pure Blind"};
		public static MapRegion Querious = new MapRegion { Id = 10000050, Name = "Querious"};
		public static MapRegion ScaldingPass = new MapRegion { Id = 10000008, Name = "Scalding Pass"};
		public static MapRegion SinqLaison = new MapRegion { Id = 10000032, Name = "Sinq Laison"};
		public static MapRegion Solitude = new MapRegion { Id = 10000044, Name = "Solitude"};
		public static MapRegion Stain = new MapRegion { Id = 10000022, Name = "Stain"};
		public static MapRegion Syndicate = new MapRegion { Id = 10000041, Name = "Syndicate"};
		public static MapRegion TashMurkon = new MapRegion { Id = 10000020, Name = "Tash-Murkon"};
		public static MapRegion Tenal = new MapRegion { Id = 10000045, Name = "Tenal"};
		public static MapRegion Tenerifis = new MapRegion { Id = 10000061, Name = "Tenerifis"};
		public static MapRegion TheBleakLands = new MapRegion { Id = 10000038, Name = "The Bleak Lands"};
		public static MapRegion TheCitadel = new MapRegion { Id = 10000033, Name = "The Citadel"};
		public static MapRegion TheKalevalaExpanse = new MapRegion { Id = 10000034, Name = "The Kalevala Expanse"};
		public static MapRegion TheSpire = new MapRegion { Id = 10000018, Name = "The Spire"};
		public static MapRegion Tribute = new MapRegion { Id = 10000010, Name = "Tribute"};
		public static MapRegion ValeoftheSilent = new MapRegion { Id = 10000003, Name = "Vale of the Silent"};
		public static MapRegion Venal = new MapRegion { Id = 10000015, Name = "Venal"};
		public static MapRegion VergeVendor = new MapRegion { Id = 10000068, Name = "Verge Vendor"};
		public static MapRegion WickedCreek = new MapRegion { Id = 10000006, Name = "Wicked Creek"};

		public static int GetDefault()
		{
			return TheForge.Id;
		}
	}
}
