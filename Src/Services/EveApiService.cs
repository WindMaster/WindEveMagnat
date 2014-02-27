using System;
using System.Collections.Generic;
using System.Linq;
using EveAI.Live;
using WindEveMagnat.Domain;

namespace WindEveMagnat.Services
{
	public class EveApiService
	{
		private static readonly Dictionary<long, EveApi> ApiDic = new Dictionary<long, EveApi>(); 
		private static EveApiService _instance;

		public static EveApiService Instance
		{
			get { return _instance ?? (_instance = new EveApiService()); }
		}

		public void InitAccounts(List<EveApiKey> accountsList)
		{
			if(accountsList == null)
				return;

			foreach (var eveApiKey in accountsList)
			{
				var api = new EveApi(eveApiKey.KeyId, eveApiKey.VCode, eveApiKey.CharacterId);
				ApiDic.Add(eveApiKey.CharacterId, api);
			}
		}

		public EveApi Api(long characterId)
		{
			if(characterId == -1)
				throw new Exception("Character is unknown");

			return ApiDic.ContainsKey(characterId) ? ApiDic[characterId] : null;
		}

		public List<EveAI.Live.Account.APIKeyInfo> GetAllCharacters()
		{
			return ApiDic.Select(eveApi => eveApi.Value.getApiKeyInfo()).ToList();
		}

		public List<TransactionEntry> GetAllCharacterTransactions(long characterId)
		{
			return Api(characterId).GetCharacterWalletTransactions();
		}

		private void AddContentsToList_R(ref IList<Asset> mainList, IList<Asset> internalList )
		{
			if(mainList == null || internalList == null)
				return;

			for (var i = 0; i < internalList.Count; i++)
			{
				var asset = internalList[i];
				if(asset.Contents != null && asset.Contents.Count > 0)
				{
					AddContentsToList_R(ref mainList, asset.Contents);
				}
				else
				{
					mainList.Add(asset);
				}
			}
		}

		public IList<Asset> GetAllCharacterAssets(long characterId)
		{
			IList<Asset> result = new List<Asset>();
			var assets = Api(characterId).GetCharacterAssets();

			AddContentsToList_R(ref result, assets);

			return result;
		}

		public IList<Asset> GetAllCorpAssets(long characterId)
		{
			return Api(characterId).GetCorporationAssets();
		}

		public List<Asset> GetAllBlueprints(long characterId)
		{
			var assets = Instance.GetAllCharacterAssets(characterId);
			return assets.Where(asset => asset.Type.Blueprint != null).ToList();
		}

		public bool CheckApiKey(EveApiKey apiKey)
		{
			var anonApi = new EveApi(apiKey.KeyId, apiKey.VCode);
			return anonApi.GetAccountEntries().Count > 0;
		}
	}
}
