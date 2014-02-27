using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindEveMagnat.Domain
{
	public class EveApiKey : ICloneable
	{
		public long KeyId { get; set; }
		public string VCode { get; set; }
		public long CharacterId { get; set; }
		public int AccessType { get; set; }
		public bool AccountStatus { get; set; }
		public string Name { get; set; }
		public bool IsCorp { get; set; }

		public object Clone()
		{
			var clone = new EveApiKey();
			DeepCopyTo(clone);
			return clone;
		}

		public void DeepCopyTo(EveApiKey key)
		{
			key.KeyId = this.KeyId;
			key.VCode = this.VCode;
			key.CharacterId = this.CharacterId;
			key.AccessType = this.AccessType;
			key.AccountStatus = this.AccountStatus;
			key.Name = this.Name;
			key.IsCorp = this.IsCorp;
		}
	}
}
