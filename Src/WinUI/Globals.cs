using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EveAI.Live.Account;
using WindEveMagnat.Common;
using WindEveMagnat.Domain;
using WindEveMagnat.Services;

namespace WindEveMagnat.UI
{
	public static class Globals
	{
		private static List<EveApiKey> _apiKeys; 
		public static List<EveApiKey> Accounts
		{
			get
			{
				if(_apiKeys == null)
					InitApiKeys();

				return _apiKeys;
			}
		}

		private static void InitApiKeys()
		{
			// Check Accounts.json
			var isExists = File.Exists(Consts.FileNameAccounts);
			if( !isExists )
			{
				_apiKeys = new List<EveApiKey>();
				// Add test key
				var apiKey = new EveApiKey {KeyId = 12312, VCode ="xxxx", Name = "Test Account"};
				_apiKeys.Add(apiKey);

				return;
			}

			// If exists - load data
			var fl = new JsonFile<List<EveApiKey>> {FileName = Consts.FileNameAccounts};
			fl.OpenAndRead();
			_apiKeys = fl.GetObject();
		}

		public static void ReloadApiKeys()
		{
			InitApiKeys();
			EveApiService.Instance.InitAccounts(Accounts);
		}
	}
}
