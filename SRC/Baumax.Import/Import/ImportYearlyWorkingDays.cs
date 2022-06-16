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
	internal class ImportYearlyWorkingDays: ImportBase
	{
		IYearlyWorkingDayService _WorkingDayService;

		const int _VLIDIndex= 0;
		const int _WorkingDayIndex= 1;

		internal ImportYearlyWorkingDays(string fileName, ICountryService countryService)
			:base(fileName,countryService)
		{
			_WorkingDayService = _IContryServise.YearlyWorkingDayService;
		}

		protected override string ImportName
		{
			get
			{
				return GetLocalized("inWorkingDays");
			}
		}

		protected Dictionary<string, YearlyWorkingDay> getDBWorkingDayList()
		{
			Dictionary<string, YearlyWorkingDay> dbWorkingDayHash;
			List<YearlyWorkingDay> dbWorkingDayList = _WorkingDayService.FindAll();
			if (dbWorkingDayList != null)
			{
				Dictionary<long, Country> dbCountryHash = getDBCountryListIDKey();

				dbWorkingDayHash = new Dictionary<string, YearlyWorkingDay>(dbWorkingDayList.Count);
				for (int i = 0; i < dbWorkingDayList.Count; i++)
				{
					long key = dbWorkingDayList[i].CountryID.Value;
					if (dbCountryHash.ContainsKey(key))
					{
						dbWorkingDayHash.Add(dbCountryHash[key].SystemID1.ToString() + dbWorkingDayList[i].WorkingDay.ToString("yyyyMMdd"), dbWorkingDayList[i]);
					}
				}
			}
			else
				dbWorkingDayHash = new Dictionary<string, YearlyWorkingDay>();
			return dbWorkingDayHash;
		}


		protected override void readCSVFile(CachedCsvReader csv)
		{
#if(UseHeaders)
			int systemID1Index = csv.GetFieldIndex(_VLID);
			int workingDayIndex = csv.GetFieldIndex(_WorkingDay);
#else
			int systemID1Index = _VLIDIndex;
			int workingDayIndex = _WorkingDayIndex;
#endif
			Dictionary<string, YearlyWorkingDay> dbWorkingDayHash = getDBWorkingDayList();
			Dictionary<string, long> countrySysKeyIDKey = getDBCountryListSysKeyIDKey();
			List<YearlyWorkingDay> importWDayList = new List<YearlyWorkingDay>();

			
			while (csv.ReadNextRecord())
			{
				csvDataNextRow();
				string workingDay = csv[workingDayIndex];
				string keyCountry = csv[systemID1Index];
				string keyWorkingDay = keyCountry + workingDay;

				if (!dbWorkingDayHash.ContainsKey(keyWorkingDay))
				{
					if (countrySysKeyIDKey.ContainsKey(keyCountry))
					{
						YearlyWorkingDay yearlyWorkingDay = new YearlyWorkingDay();
						yearlyWorkingDay.CountryID = countrySysKeyIDKey[keyCountry];
						yearlyWorkingDay.WorkingDay = DateTime.ParseExact(workingDay, "yyyyMMdd", null);
						importWDayList.Add(yearlyWorkingDay);
						dbWorkingDayHash.Add(keyWorkingDay, yearlyWorkingDay);
					}
					else
					{
						message(string.Format(GetLocalized("CountryNotExistsDB"), _CurrentRow, _VLID, keyCountry));
					}
				}
				else
				{
					message(string.Format(GetLocalized("WorkingDayExistsDB"), _CurrentRow));
				}
			}
			csvDataEndRead();

			SaveList<YearlyWorkingDay>(_IContryServise.YearlyWorkingDayService, importWDayList);
		}

	}
}
