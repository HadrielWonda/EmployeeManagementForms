using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System.IO;
using System.Collections;

using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;
using Baumax.Contract;
using LumenWorks.Framework.IO.Csv;

namespace Baumax.Import
{
	class ImportFeasts: ImportBase
	{
		IFeastService _FeastService;

		const int _VLIDIndex = 0;
		const int _FeastDateIndex = 1;

		internal ImportFeasts(string fileName, ICountryService countryService)
			:base(fileName,countryService)
		{
			_FeastService = _IContryServise.FeastService;
		}

		protected override string ImportName
		{
			get
			{
				return GetLocalized("inFeasts");
			}
		}

		protected override void readCSVFile(CachedCsvReader csv)
		{
#if(UseHeaders)
			int countryIDIndex = csv.GetFieldIndex(_VLID);
			int feastDateIndex = csv.GetFieldIndex(_FeastDate);
#else
			int countryIDIndex = _VLIDIndex;
			int feastDateIndex = _FeastDateIndex;
#endif

			Dictionary<string, ImportFeastsData> data = new Dictionary<string, ImportFeastsData>();
			int i = 1;
			while (csv.ReadNextRecord())
			{
				csvDataNextRow();
				int countryID = int.Parse(csv[countryIDIndex]);
				DateTime feastDate = DateTime.ParseExact(csv[feastDateIndex], "yyyyMMdd", null);
				string key = countryID.ToString() + feastDate.ToString();
				if (!data.ContainsKey(key))
					data.Add(key, new ImportFeastsData(i, new  ImportDaysData(countryID, feastDate)));
				else
					message(string.Format(GetLocalized("FeastExists"), i, _CountryID, countryID, _FeastDate, feastDate));
				i++;
			}
			csvDataEndRead();

			List<ImportDaysData> list = new List<ImportDaysData>(data.Count);
			foreach (ImportFeastsData value in data.Values)
				list.Add(value.Data);
			SaveDataResult saveDataResult = _FeastService.ImportFeasts(list);
			list = (List<ImportDaysData>)saveDataResult.Data;
			foreach (ImportDaysData value in list)
			{
				string key = value.CountryID.ToString() + value.Date.ToString();
				message(string.Format(GetLocalized("CountryNotExistsDB"), data[key].RecordNumber, _VLID, value.CountryID));
			}
		}

		internal class ImportFeastsData
		{
			internal int RecordNumber;
			internal ImportDaysData Data;
			
			internal ImportFeastsData()
			{ }

			internal ImportFeastsData(int recordNumber, ImportDaysData data)
			{
				RecordNumber = recordNumber;
				Data = data;
			}

			
		}

	}
}
