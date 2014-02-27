using System.Windows;
using WindEveMagnat.Common;
using WindEveMagnat.Domain;
using WindEveMagnat.Services;
using MessageBox = System.Windows.MessageBox;

namespace WindEveMagnat.UI.Forms
{
	/// <summary>
	/// Interaction logic for AddEditAccount.xaml
	/// </summary>
	public partial class AddEditAccount : Window
	{
		public AddEditAccount()
		{
			InitializeComponent();
		}

		public EveApiKey GetApiKeyFromUI()
		{
			var newApiKey = new EveApiKey();

			newApiKey.KeyId = CommonUtils.GetLongFromString(txtKeyId.Text.Trim());
			newApiKey.VCode = txtVcode.Text.Trim();
			newApiKey.Name = txtAccountName.Text.Trim();
			newApiKey.CharacterId = CommonUtils.GetLongFromString(txtCharacterId.Text.Trim());

			return newApiKey;
		}

		public void SetApiKeyToUI(EveApiKey activeKey)
		{
			txtAccountName.Text = activeKey.Name;
			txtKeyId.Text = activeKey.KeyId.ToString();
			txtVcode.Text = activeKey.VCode;
			txtCharacterId.Text = activeKey.CharacterId.ToString();
		}

		private void btnCheckApi_Click( object sender, RoutedEventArgs e )
		{
			var apiKey = GetApiKeyFromUI();
			var result = EveApiService.Instance.CheckApiKey(apiKey);
			if( result )
				MessageBox.Show("Key is ok!");
			else
				MessageBox.Show("Wrong Api key");
		}

		private void btnOk_Click( object sender, RoutedEventArgs e )
		{
			DialogResult = true;
			Close();
		}

		private void btnCancel_Click( object sender, RoutedEventArgs e )
		{
			DialogResult = false;
			Close();
		}
	}
}
