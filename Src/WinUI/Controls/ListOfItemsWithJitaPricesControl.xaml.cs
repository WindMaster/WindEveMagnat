using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindEveMagnat.UI.DataObjects;
using UserControl = System.Windows.Controls.UserControl;

namespace WindEveMagnat.UI.Controls
{
	/// <summary>
	/// Interaction logic for ListOfItemsWithJitaPrices.xaml
	/// </summary>
	public partial class ListOfItemsWithJitaPrices : UserControl
	{
		private BindingSource itemsBindingSource = new BindingSource();

		public ListOfItemsWithJitaPrices()
		{
			InitializeComponent();
		}

		public void Init(List<EveItemDetailsMaterialRow> items)
		{
			dataGridItems.ItemsSource = new ObservableCollection<EveItemDetailsMaterialRow>(items);
		}

		public void NotifyCollectionChanged()
		{
			itemsBindingSource.ResetBindings(false);
		}
	}
}
