using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zlib;
using WindEveMagnat.Domain;
using WindEveMagnat.Domain.EveMarketData.CurrentPrice;

namespace WindEveMagnat.UI.DataObjects
{
	public class ApiKeyRowCollection : INotifyCollectionChanged
	{
		ObservableCollection<EveApiKey> rows = new ObservableCollection<EveApiKey>(); 

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public void Add(EveApiKey row)
		{
			rows.Add(row);
			RaiseCollectionChanged(NotifyCollectionChangedAction.Add);
		}

		public void AddRange(List<EveApiKey> coll)
		{
			if(coll == null)
				return;
			
			foreach (var eveApiKey in coll)
			{
				rows.Add(eveApiKey);
			}
			RaiseCollectionChanged(NotifyCollectionChangedAction.Add);
		}

		public void Remove(EveApiKey row)
		{
			var itemInList = rows.FirstOrDefault(x => x.KeyId == row.KeyId);
			if (itemInList == null)
				return;

			rows.Remove(itemInList);
			RaiseCollectionChanged(NotifyCollectionChangedAction.Remove);
		}

		public void Update(EveApiKey row)
		{
			var itemInList = rows.FirstOrDefault(x => x.KeyId == row.KeyId);
			if (itemInList == null)
				return;

			row.DeepCopyTo(itemInList);
			RaiseCollectionChanged(NotifyCollectionChangedAction.Replace);
		}

		public void RaiseCollectionChanged(NotifyCollectionChangedAction action)
		{
			if (CollectionChanged != null)
				CollectionChanged(this, new NotifyCollectionChangedEventArgs(action));
		}

		public ObservableCollection<EveApiKey> Rows
		{
			get { return rows; }
		}
	}
}
