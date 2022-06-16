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
	internal class ImportHWGRdb: ImportBase
	{
		const int _WorldIDIndex = 0;
		const int _HWGR_IDIndex = 1;
		const int _HWGR_NameIndex = 3;

		IStoreService _StoreService;

		internal ImportHWGRdb(string fileName, IStoreService storeService)
			: base(fileName, null)
		{
			_StoreService = storeService;
		}

		protected override string ImportName
		{
			get
			{
				return GetLocalized("inHWGRs");
			}
		}

		protected override void readCSVFile(CachedCsvReader csv)
		{
#if(UseHeaders)
			int worldIDIndex = csv.GetFieldIndex(_WorldID);
			int hwgr_IDIndex = csv.GetFieldIndex(_HWGR_ID);
			int hwgr_NameIndex = csv.GetFieldIndex(_HWGR_Name);
#else
			int worldIDIndex = _WorldIDIndex;
			int hwgr_IDIndex = _HWGR_IDIndex;
			int hwgr_NameIndex = _HWGR_NameIndex;
#endif


			Dictionary<string, ImportFileHWGRData> data = new Dictionary<string, ImportFileHWGRData>();

			//Add HWGR
			while (csv.ReadNextRecord())
			{
				csvDataNextRow();
				int worldID = int.Parse(csv[worldIDIndex]);
				int hwgrID = int.Parse(csv[hwgr_IDIndex]);
				string hwgrName = csv[hwgr_NameIndex];
				string key = worldID.ToString() + hwgrID.ToString();
				if (!data.ContainsKey(key))
					data.Add(key, new ImportFileHWGRData(_CurrentRow ,new ImportHWGRData(hwgrID, worldID, hwgrName)));
				else
					message(string.Format(GetLocalized("HWGRExists"), _CurrentRow, _WorldID, worldID, _HWGR_ID, hwgrID));
			}
			csvDataEndRead();

			List<ImportHWGRData> list = new List<ImportHWGRData>(data.Count);
			foreach (ImportFileHWGRData value in data.Values)
				list.Add(value.Data);
			SaveDataResult saveDataResult = _StoreService.HWGRService.ImportHWGR(list);
			list = (List<ImportHWGRData>)saveDataResult.Data;
			foreach (ImportHWGRData value in list)
			{
				string key = value.World_SystemID.ToString() + value.HWGR_SystemID.ToString();
				message(string.Format(GetLocalized("WorldNotExistsDB"), data[key].RecordNumber, _WorldID, value.World_SystemID));
			}
		}

		class ImportFileHWGRData
		{
			internal int RecordNumber;
			internal ImportHWGRData Data;

			internal ImportFileHWGRData(int recordNumber, ImportHWGRData data)
			{
				RecordNumber = recordNumber;
				Data = data;
			}

		}

	}
}
