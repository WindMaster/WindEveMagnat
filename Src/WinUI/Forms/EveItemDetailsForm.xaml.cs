using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WindEveMagnat.UI.Controls;

namespace WindEveMagnat.UI.Forms
{
	/// <summary>
	/// Interaction logic for EveItemDetailsForm.xaml
	/// </summary>
	public partial class EveItemDetailsForm : Window
	{
		public EveItemDetailsForm()
		{
			InitializeComponent();
		}

		public void Init(int typeId)
		{
			EveItemDetailsControl.LoadItemInfo(typeId);
		}
	}
}
