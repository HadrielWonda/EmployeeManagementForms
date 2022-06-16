using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System.IO;
using System.Collections;

using Baumax.Contract;
using LumenWorks.Framework.IO.Csv;

namespace Baumax.Import
{
	internal class ImportStore : ImportRegion
	{
		const int _VLIDIndex = 0;
		const int _RegionNameIndex = 1;
		const int _StoreIDIndexIndex = 2;
		const int _StoreNameIndex = 4;
		const int _CityIndex = 6;
		const int _AdressIndex = 7;
		const int _AreaIndex = 8;
		const int _PostCodeIndex = 5;

		protected IStoreService _IStoreService;

		internal ImportStore(string fileName, ICountryService countryService, IRegionService regionService, IStoreService storeService)
			: base(fileName, countryService, regionService)
		{
			_IStoreService = storeService;
		}

		protected override string ImportName
		{
			get
			{
				return  GetLocalized("inStories");
			}
		}

		protected Dictionary<long, Store> getDBStoreList()
		{
			Dictionary<long, Store> dbStoreHash;
			List<Store> dbStoreList = _IStoreService.FindAll();
			if (dbStoreList != null)
			{
				dbStoreHash = new Dictionary<long, Store>(dbStoreList.Count);
				for (int i = 0; i < dbStoreList.Count; i++)
					dbStoreHash.Add(dbStoreList[i].SystemID, dbStoreList[i]);
			}
			else
				dbStoreHash = new Dictionary<long, Store>();
			return dbStoreHash;
		}


		protected override void readCSVFile(CachedCsvReader csv)
		{
#if(UseHeaders)
			int systemID1Index = csv.GetFieldIndex(_VLID);
			int regionNameIndex = csv.GetFieldIndex(_RegionName);
			int storeIDIndex = csv.GetFieldIndex(_StoreIDIndex);
			int cityIndex = csv.GetFieldIndex(_City);
			int areaIndex = csv.GetFieldIndex(_Area);
			int adressIndex = csv.GetFieldIndex(_Adress);
			int storeNameIndex = csv.GetFieldIndex(_StoreName);
			int postCodeIndex= csv.GetFieldIndex(_PostCode);
#else
			int systemID1Index = _VLIDIndex;
			int regionNameIndex = _RegionNameIndex;
			int storeIDIndex = _StoreIDIndexIndex;
			int cityIndex = _CityIndex;
			int areaIndex = _AreaIndex;
			int adressIndex = _AdressIndex;
			int storeNameIndex = _StoreNameIndex;
			int postCodeIndex = _PostCodeIndex;
#endif
			Dictionary<long, Store> dbStoreHash = getDBStoreList();
			Dictionary<string, Region> dbRegionHash = getDBRegionList();
			List<Store> storeSaveList = new List<Store>();
			int i = 1;
			Store store;
			while (csv.ReadNextRecord())
			{
				csvDataNextRow();
				string regionName = csv[regionNameIndex];
				string keyCountry = csv[systemID1Index];
				string keyRegion = keyCountry + regionName;

				int storeID = int.Parse(csv[storeIDIndex]);
				string city = csv[cityIndex];
				int area = int.Parse(csv[areaIndex]);
				string postCode = csv[postCodeIndex].ToUpper().Replace(_null,"");
				string address = csv[adressIndex];
				string storeName = csv[storeNameIndex];

				if (dbRegionHash.ContainsKey(keyRegion))
				{
					if (dbStoreHash.ContainsKey(storeID))
					{
						if (dbStoreHash[storeID].ID == 0)
						{
							message(string.Format(GetLocalized("StoreExists"), _StoreIDIndex, storeID));
							continue;
						}
						store = dbStoreHash[storeID];
					}
					else
					{
						store = new Store();
					}
					store.RegionID = dbRegionHash[keyRegion].ID;
					store.LanguageID = SharedConsts.NeutralLangId;
					store.SystemID = storeID;
					store.Name = storeName;
					store.Address = address;
					store.Number = postCode;
					store.Area = area;
					store.City = city;
					store.Import = true;
					storeSaveList.Add(store);
					if (store.ID == 0)
					{
						dbStoreHash.Add(storeID, store);
					}
				}
				else
					message(string.Format(GetLocalized("RegionNotExistsDB"), i, _VLID, keyCountry, _RegionName, regionName));

				i++;
			}
			csvDataEndRead();

			SaveOrUpdateList<Store>(_IStoreService, storeSaveList);
            _IStoreService.CopyStructureForEmptyStores();
		}

	}
}

