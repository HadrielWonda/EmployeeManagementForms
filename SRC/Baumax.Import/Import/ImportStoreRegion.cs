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
/*
	internal class ImportStoreRegion : ImportBase
	{
		
		IRegionService _IRegionService;
		IStoreService _IStoreService;
		internal ImportStoreRegion(string fileName, ICountryService iCountryService, IRegionService iRegionService, IStoreService iStoreService)
			: base(fileName)
		{
			_IContryServise = iCountryService;
			_IRegionService = iRegionService;
			_IStoreService = iStoreService;
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
			Dictionary<string, Country> dbCountryHash = getDBCountryListSysKey();
			Dictionary<long, Store> dbStoreHash = getDBStoreList();

			Dictionary<string, Region> dbRegionHash = new Dictionary<string, Region>();
			List<Region> regionList = _IRegionService.FindAll();
			if (regionList != null)
				for (int i = 0; i < regionList.Count; i++)
					dbRegionHash.Add(regionList[i].Name, regionList[i]);
			Dictionary<string, Region> importRegionHash = new Dictionary<string, Region>();
			Dictionary<long, Store> importStoreHash = new Dictionary<long, Store>();

			int countryIDIndex = csv.GetFieldIndex(_CountryID);
			int countryDescriptionIndex = csv.GetFieldIndex(_VLID);
			int regionNameIndex = csv.GetFieldIndex(_RegionName);
			int storeIDIndex = csv.GetFieldIndex(_StoreIDIndex);
			int cityIndex = csv.GetFieldIndex(_City);
			int areaIndex = csv.GetFieldIndex(_Area);
			int adressIndex = csv.GetFieldIndex(_Adress);
			int storeNameIndex = csv.GetFieldIndex(_StoreName);
			while (csv.ReadNextRecord())
			{
				Region region;
				Store store;
				string regionName = csv[regionNameIndex];
				string countryID = csv[countryIDIndex];
				int storeID = int.Parse(csv[storeIDIndex]);
				string city = csv[cityIndex];
				int area = int.Parse(csv[areaIndex]);
				string address = csv[adressIndex];
				string storeName = csv[storeNameIndex];
				if (!importStoreHash.ContainsKey(storeID))
				{
					if (!importRegionHash.ContainsKey(regionName))
					{
						if (dbRegionHash.ContainsKey(regionName))
						{
							region = dbRegionHash[regionName];
						}
						else
						{
							region = new Region();
						}
						if (dbCountryHash.ContainsKey(countryID))
							region.CountryID = dbCountryHash[countryID].ID;
						region.Name = regionName;
						region.LanguageID = SharedConsts.NeutralLangId;
						importRegionHash.Add(regionName, region);
					}
					else
					{
						region = importRegionHash[regionName];
					}
					if (dbStoreHash.ContainsKey(storeID))
						store = dbStoreHash[storeID];
					else
						store = new Store();
					store.RegionID = region.ID;
					store.LanguageID = SharedConsts.NeutralLangId;
					store.SystemID = storeID;
					store.Name = storeName;
					store.Address = address;
					store.Area = area;
					store.City = city;
					importStoreHash.Add(storeID, store);
				}

			}
			if (regionList != null)
				regionList.Clear();
			else
				regionList = new List<Region>(importRegionHash.Count);
			foreach (Region region in importRegionHash.Values)
				regionList.Add(region);
			_IRegionService.SaveOrUpdateList(regionList);

			List<Store> storeSaveList = new List<Store>(importStoreHash.Count);
			foreach (Store store in importStoreHash.Values)
				storeSaveList.Add(store);
			_IStoreService.SaveOrUpdateList(storeSaveList);


		}
	}
*/
}

