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
	internal class ImportCountry : ImportBase
	{
		const int _VLIDIndex = 0;
		const int _CountryIDIndex = 1;
		const int _CountryNameIndex = 4;

		internal ImportCountry(string fileName, ICountryService iservise)
			: base(fileName)
		{
			_IContryServise = iservise;
		}

		protected override string ImportName
		{
			get
			{
				return GetLocalized("inCountries");
			}
		}

		protected override void readCSVFile(CachedCsvReader csv)
		{
#if(UseHeaders)	
			int systemID1Index = csv.GetFieldIndex(_VLID);
			int systemID2Index = csv.GetFieldIndex(_CountryID);
			int countryNameIndex = csv.GetFieldIndex(_CountryName);
#else
			int systemID1Index = _VLIDIndex;
			int systemID2Index = _CountryIDIndex;
			int countryNameIndex = _CountryNameIndex;
#endif
			Dictionary<string, Country> dbCountryHash = getDBCountryListSysKey();
			List<Country> importCountryList = new List<Country>();

			Country country;
			while (csv.ReadNextRecord())
			{
				csvDataNextRow();
				string key = csv[systemID1Index];
				if (dbCountryHash.ContainsKey(key))
				{
					country = dbCountryHash[key];
				}
				else
				{
					country = new Country();
					country.SystemID2 = csv[systemID2Index];
				}
				country.Name = csv[countryNameIndex];
				country.Import = true;
				country.CountryLanguage = SharedConsts.NeutralLangId;
				country.LanguageID = SharedConsts.NeutralLangId;
				country.SystemID1 = byte.Parse(csv[systemID1Index]);
				if (country.IsNew && !dbCountryHash.ContainsKey(key))
					dbCountryHash.Add(key, country);
				if (!importCountryList.Contains(country))
					importCountryList.Add(country);
				else
					message(string.Format(GetLocalized("CountryExists"), _CurrentRow, _VLID, key));
			}
			csvDataEndRead();

			SaveOrUpdateList<Country>(_IContryServise, importCountryList);
		}


	}
}
