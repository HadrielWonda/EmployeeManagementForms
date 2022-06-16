using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System.IO;
using System.Collections;
using Baumax.Contract.QueryResult;

using Baumax.Contract;
using LumenWorks.Framework.IO.Csv;

namespace Baumax.Import
{
/*
	internal class ImportWGR : ImportHWGR
	{
		internal ImportWGR(string fileName, IStoreService storeService)
			: base(fileName, storeService)
		{ }

		protected override string ImportName
		{
			get
			{
				return GetLocalized("inWGRs");
			}
		}

		private Dictionary<long, WGR> getDBwgrHash()
		{
			Dictionary<long, WGR> dbwgrHash;
			List<WGR> dbwgrList = _IStoreService.WGRService.FindAll();
			if (dbwgrList != null)
			{
				dbwgrHash = new Dictionary<long, WGR>(dbwgrList.Count);
				for (int i = 0; i < dbwgrList.Count; i++)
					dbwgrHash.Add(dbwgrList[i].SystemID, dbwgrList[i]);
			}
			else
				dbwgrHash = new Dictionary<long, WGR>();
			return dbwgrHash;
		}

		private Dictionary<string, HwgrToWgr_SysValues> getHWGR_WGR_SysValuesHash()
		{
			Dictionary<string, HwgrToWgr_SysValues> dbHWGR_WGR_SysValuesHash;
			List<HwgrToWgr_SysValues> dbHWGR_WGR_SysValuesList = _IStoreService.HwgrToWgrService.Get_HwgrToWgr_SysValues();
			if (dbHWGR_WGR_SysValuesList != null)
			{
				dbHWGR_WGR_SysValuesHash = new Dictionary<string, HwgrToWgr_SysValues>(dbHWGR_WGR_SysValuesList.Count);
				foreach (HwgrToWgr_SysValues value in dbHWGR_WGR_SysValuesList)
					dbHWGR_WGR_SysValuesHash.Add(value.World_HwgrID.ToString() + value.WGR_SystemID.ToString(), value);
			}
			else
				dbHWGR_WGR_SysValuesHash = new Dictionary<string, HwgrToWgr_SysValues>();
			return dbHWGR_WGR_SysValuesHash;
		}

		private Dictionary<string, List<WorldToHwgr_SysValues>> getWorld_HWGR_Lists()
		{
			Dictionary<string, List<WorldToHwgr_SysValues>> result = new Dictionary<string, List<WorldToHwgr_SysValues>>();
			List<WorldToHwgr_SysValues> dbWorld_HWGR_SysValuesList = _IStoreService.WorldToHWGRService.Get_WorldToHwgr_SysValues();
			foreach (WorldToHwgr_SysValues world_hwgr in dbWorld_HWGR_SysValuesList)
			{
				string key = world_hwgr.World_SystemID.ToString() + world_hwgr.HWGR_SystemID;
				List<WorldToHwgr_SysValues> currList;
				if (!result.TryGetValue(key, out currList))
				{
					currList = new List<WorldToHwgr_SysValues>();
					result.Add(key, currList);
				}
				currList.Add(world_hwgr);
			}
			return result;
		}

		protected override void readCSVFile(CachedCsvReader csv)
		{

			Dictionary<string, ImportDataWGR> data = new Dictionary<string, ImportDataWGR>();
			Dictionary<long, WGR> dbwgrHash = getDBwgrHash();
			List<WGR> wgrSaveList = new List<WGR>();
			Dictionary<string, HwgrToWgr_SysValues> dbHWGR_WGR_SysValuesHash = getHWGR_WGR_SysValuesHash();
			List<HwgrToWgr> hwgr_wgrSaveList = new List<HwgrToWgr>();

			int worldIDIndex = csv.GetFieldIndex(_WorldID);
			int _HWGR_IDIndex = csv.GetFieldIndex(_HwgrID);
			int _WGR_IDIndex = csv.GetFieldIndex(_WgrId);
			int _WGR_NameIndex = csv.GetFieldIndex(_WGR_Name);

			//Add WGR
			int i = 1;
			while (csv.ReadNextRecord())
			{
				csvDataNextRow();
				int worldID = int.Parse(csv[worldIDIndex]);
				int hwgrID = int.Parse(csv[_HWGR_IDIndex]);
				int wgrID = int.Parse(csv[_WGR_IDIndex]);
				string wgrName = csv[_WGR_NameIndex];
				string key = worldID.ToString() + hwgrID.ToString() + wgrID.ToString();
				if (!data.ContainsKey(key))
				{
					data.Add(key, new ImportDataWGR(i, hwgrID, worldID, wgrID, wgrName, key));
					if (!dbwgrHash.ContainsKey(wgrID))
					{
						WGR wgr = new WGR(wgrID, SharedConsts.NeutralLangId, wgrName);
						wgr.Import = true;
						wgrSaveList.Add(wgr);
						dbwgrHash.Add(wgrID, wgr);
					}
				}
				else
				{
					message(string.Format(GetLocalized("WGRExists"), i, _WorldID, worldID, _HwgrID, hwgrID, _WgrId, wgrID));
				}
				i++;
			}
			csvDataEndRead();
			if (wgrSaveList.Count > 0)
			{
				SaveOrUpdateList<WGR>(_IStoreService.WGRService, wgrSaveList);
			}

			//Add HwgrToWgr
			Dictionary<string, List<WorldToHwgr_SysValues>> world_hwgr_Lists = getWorld_HWGR_Lists();
			i = 1;
			foreach (ImportDataWGR importData in data.Values)
			{
				string key = importData.WorldID.ToString() + importData.HwgrID.ToString();
				List<WorldToHwgr_SysValues> curr_world_hwgrList;
				if (world_hwgr_Lists.TryGetValue(key, out curr_world_hwgrList))
				{
					foreach (WorldToHwgr_SysValues world_hwgr_SysValues in curr_world_hwgrList)
					{
						if (!dbHWGR_WGR_SysValuesHash.ContainsKey(world_hwgr_SysValues.World_HwgrID.ToString() + importData.WgrId.ToString()))
						{
							HwgrToWgr hwgr_wgr = new HwgrToWgr();
							hwgr_wgr.WorldHWGR_ID = world_hwgr_SysValues.World_HwgrID;
							hwgr_wgr.WgrId = dbwgrHash[importData.WgrId].ID;
							hwgr_wgr.BeginTime = null;
							hwgr_wgr.EndTime = null;
							hwgr_wgrSaveList.Add(hwgr_wgr);
						}
					}
				}
				else
				{
					message(string.Format(GetLocalized("HWGRNotExistsDB"), importData.RecordNumber, _WorldID, importData.WorldID, _HwgrID, importData.HwgrID));
				}
			}
			SaveList<HwgrToWgr>(_IStoreService.HwgrToWgrService, hwgr_wgrSaveList);
		}

		protected class ImportDataWGR : ImportDataHWGR
		{
			internal string Key;
			internal int WgrId;
			internal ImportDataWGR(int recordNumber, int hwg_rID, int worldID, int wgr_ID, string name, string key)
				: base(recordNumber, hwg_rID, worldID, name)
			{
				Key = key;
				WgrId = wgr_ID;
			}
		}

	}
*/
}
