using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WindEveMagnat.Common;
using WindEveMagnat.Domain;
using WindEveMagnat.Services;
using WindEveMagnat.UI.DataObjects;

namespace WindEveMagnat.UI.Forms
{
	/// <summary>
	/// Interaction logic for Accounts.xaml
	/// </summary>
	public partial class Accounts : Window
	{
		private ApiKeyRowCollection apiKeysCollection;

		public Accounts()
		{
			InitializeComponent();

			LoadApiKeys();
		}

		private void LoadApiKeys()
		{
			apiKeysCollection = new ApiKeyRowCollection();
			apiKeysCollection.AddRange(Globals.Accounts);
			gridAccounts.DataContext = apiKeysCollection.Rows;
		}

		private void btnAddAccount_Click( object sender, RoutedEventArgs e )
		{
			var frmAddAccount = new AddEditAccount();
			var result = frmAddAccount.ShowDialog();
			if (!result.HasValue || !result.Value)
				return;

			var newApiKey = frmAddAccount.GetApiKeyFromUI();

			// Add api key to list
			AddApiKeyToList(newApiKey);
		}

		private void SaveApiKeysToFile()
		{
			JsonFile<List<EveApiKey>> fl = new JsonFile<List<EveApiKey>>();
			fl.FileName = Consts.FileNameAccounts;
			fl.SetObject(apiKeysCollection.Rows.ToList());
			fl.OpenAndWrite();
		}

		private void AddApiKeyToList(EveApiKey newApiKey)
		{
			apiKeysCollection.Add(newApiKey);
		}

		private void btnEditAccount_Click( object sender, RoutedEventArgs e )
		{
			var currentApiKey = GetSelectedApiKey(); 
			if(currentApiKey == null)
				return;

			var frmEditAccount = new AddEditAccount();
			frmEditAccount.SetApiKeyToUI((EveApiKey)currentApiKey);
			var result = frmEditAccount.ShowDialog();
			if (!result.HasValue || !result.Value)
				return;

			var newApiKey = frmEditAccount.GetApiKeyFromUI();

			// Add api key to list
			UpdateApiKeyInList(newApiKey);
		}

		private EveApiKey GetSelectedApiKey()
		{
			if (!(gridAccounts.SelectedValue is EveApiKey))
				return null;

			return (EveApiKey)gridAccounts.SelectedValue;
		}

		private void UpdateApiKeyInList(EveApiKey account)
		{
			apiKeysCollection.Update(account);
		}

		private void btnDeleteAccount_Click( object sender, RoutedEventArgs e )
		{
			var currentApiKey = GetSelectedApiKey(); 
			if(currentApiKey == null)
				return;

			var result = MessageBox.Show("Do you really want to delete this key?", "Warning", MessageBoxButton.YesNo);

			if (result != MessageBoxResult.Yes)
				return;

			apiKeysCollection.Remove(currentApiKey);
		}

		private void btnCheckAccounts_Click( object sender, RoutedEventArgs e )
		{
			var accounts = apiKeysCollection.Rows.ToList();
			foreach (var account in accounts)
			{
				if (!EveApiService.Instance.CheckApiKey(account))
				{
					UpdateApiKeyStatusInGrid(account, -1);
				}
			}
		}

		private void UpdateApiKeyStatusInGrid(EveApiKey account, int i)
		{
		}

		private void btnSaveAccounts_Click( object sender, RoutedEventArgs e )
		{
			// Save
			SaveApiKeysToFile();
			Globals.ReloadApiKeys();
			MessageBox.Show("Api keys were saved successfully.", "Api keys were updated", MessageBoxButton.OK);
			Close();
		}
	}
}
