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
	internal class ImportRegion : ImportBase
	{
		const int _VLIDIndex = 0;
		const int _RegionNameIndex = 1;
		
		protected IRegionService _RegionService;

		internal ImportRegion(string fileName, ICountryService countryService, IRegionService regionService)
			: base(fileName, countryService)
		{
			_RegionService = regionService;
		}

		protected override string ImportName
		{
			get
			{
				return GetLocalized("inRegions");
			}
		}

		protected Dictionary<string, Region> getDBRegionList()
		{
			Dictionary<string, Region> dbRegionHash;
			List<Region> dbRegionList = _RegionService.FindAll();
			if (dbRegionList != null)
			{
				Dictionary<long, Country> dbCountryHash = getDBCountryListIDKey();

				dbRegionHash = new Dictionary<string, Region>(dbRegionList.Count);
				for (int i = 0; i < dbRegionList.Count; i++)
				{
					long key = dbRegionList[i].CountryID;
					if (dbCountryHash.ContainsKey(key))
					{
						dbRegionHash.Add(dbCountryHash[key].SystemID1.ToString() + dbRegionList[i].RegionSysID, dbRegionList[i]);
					}
				}
			}
			else
				dbRegionHash = new Dictionary<string, Region>();
			return dbRegionHash;
		}


		protected override void readCSVFile(CachedCsvReader csv)
		{
#if(UseHeaders)
			int systemID1Index = csv.GetFieldIndex(_VLID);
			int regionNameIndex = csv.GetFieldIndex(_RegionName);
#else
			int systemID1Index = _VLIDIndex;
			int regionNameIndex = _RegionNameIndex;
#endif
			Dictionary<string, Region> dbRegionHash = getDBRegionList();
			Dictionary<string, long> countrySysKeyIDKey = getDBCountryListSysKeyIDKey();
			List<Region> importRegionList = new List<Region>();
			
			int i = 1;
			while (csv.ReadNextRecord())
			{
				csvDataNextRow();
				string regionName = csv[regionNameIndex];
				string keyCountry = csv[systemID1Index];
				string keyRegion = keyCountry + regionName;

				if (!dbRegionHash.ContainsKey(keyRegion))
				{
					if (countrySysKeyIDKey.ContainsKey(keyCountry))
					{
						Region region = new Region();
						region.CountryID = countrySysKeyIDKey[keyCountry];
						region.LanguageID = SharedConsts.NeutralLangId;
						region.Name = regionName;
						region.Import = true;
						region.RegionSysID = regionName;
						importRegionList.Add(region);
						dbRegionHash.Add(keyRegion, region);
					}
					else 
					{
						message(string.Format(GetLocalized("CountryNotExistsDB"), _CurrentRow, _VLID, keyCountry));
					}
				}
				else
				{
					message(string.Format(GetLocalized("RegiontExistsDB"), i, keyRegion));
				}
				i++;
			}
			csvDataEndRead();

			SaveOrUpdateList<Region>(_RegionService, importRegionList);
		}

	}
}
