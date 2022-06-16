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
	internal class ImportHWGR : ImportWorld
	{

		const int _WorldIDIndex = 0;
		const int _HWGR_IDIndex = 1;
		const int _HWGR_NameIndex = 2;

		internal ImportHWGR(string fileName, IStoreService storeService)
			: base(fileName, storeService)
		{ }

		protected override string ImportName
		{
			get
			{
				return GetLocalized("inHWGRs");
			}
		}
/*
		private Dictionary<long, HWGR> getDBhwgrHash()
		{
			Dictionary<long, HWGR> dbhwgrHash;
			List<HWGR> dbhwgrList = _IStoreService.HWGRService.FindAll();
			if (dbhwgrList != null)
			{
				dbhwgrHash = new Dictionary<long, HWGR>(dbhwgrList.Count);
				for (int i = 0; i < dbhwgrList.Count; i++)
					dbhwgrHash.Add(dbhwgrList[i].SystemID, dbhwgrList[i]);
			}
			else
				dbhwgrHash = new Dictionary<long, HWGR>();
			return dbhwgrHash;
		}

		private Dictionary<int, Store_WorldData> getdbWorldID__Store_WorldIDHash()
		{
			Dictionary<long, int> worldID_ExSystemID= getWorldID_ExSystemID();
			Dictionary<int, Store_WorldData> dbWorldID__Store_WorldIDHash = new Dictionary<int, Store_WorldData>();
			List<StoreToWorld> dbStore_WorldList = _IStoreService.StoreToWorldService.FindAll();
			if (dbStore_WorldList != null)
			{
				foreach(StoreToWorld store_world in dbStore_WorldList)
				{
					Store_WorldData store_WorldData;
					List<long> store_WorldIDList;
					if (dbWorldID__Store_WorldIDHash.TryGetValue(worldID_ExSystemID[store_world.WorldID], out store_WorldData))
					{
						store_WorldData.Store_WorldIDList.Add(store_world.ID);
					}
					else
					{
						store_WorldData = new Store_WorldData();
						store_WorldIDList = new List<long>();
						store_WorldIDList.Add(store_world.ID);
						store_WorldData.Store_WorldIDList = store_WorldIDList;
						store_WorldData.Store_WorldID = store_world.ID;
						dbWorldID__Store_WorldIDHash.Add(worldID_ExSystemID[store_world.WorldID], store_WorldData);
					}
				}
			}
			return dbWorldID__Store_WorldIDHash;
		}

		private Dictionary<long, int> getWorldID_ExSystemID()
		{
			Dictionary<long, int> result= new Dictionary<long,int>();
			List<World> dbWorldList = _IStoreService.WorldService.FindAll();
			if (dbWorldList != null)
				for (int i = 0; i < dbWorldList.Count; i++)
					result.Add(dbWorldList[i].ID, dbWorldList[i].ExSystemID);
			return result;
		}

		private Dictionary<string, WorldToHwgr> getWorld_HWGRHash()
		{
			Dictionary<string, WorldToHwgr> dbworld_hwgrHash;
			List<WorldToHwgr> dbhwgrList = _IStoreService.WorldToHWGRService.FindAll();
			if (dbhwgrList != null)
			{
				dbworld_hwgrHash = new Dictionary<string, WorldToHwgr>(dbhwgrList.Count);
				for (int i = 0; i < dbhwgrList.Count; i++)
					dbworld_hwgrHash.Add(dbhwgrList[i].StoreWorld_ID.ToString() + dbhwgrList[i].HWGR_ID.ToString(), dbhwgrList[i]);
			}
			else
				dbworld_hwgrHash = new Dictionary<string, WorldToHwgr>();
			return dbworld_hwgrHash;
		}

		//private Dictionary<string, WorldToHwgr_SysValues> getHWGR_WGR_SysValuesHash()
		//{
		//    Dictionary<string, WorldToHwgr_SysValues> dbWorld_HWGR_SysValuesHash;
		//    List<WorldToHwgr_SysValues> dbWorld_HWGR_SysValuesList = _IStoreService.WorldToHWGRService.Get_WorldToHwgr_SysValues();
		//    if (dbWorld_HWGR_SysValuesList != null)
		//    {
		//        dbWorld_HWGR_SysValuesHash = new Dictionary<string, WorldToHwgr_SysValues>(dbWorld_HWGR_SysValuesList.Count);
		//        foreach (WorldToHwgr_SysValues value in dbWorld_HWGR_SysValuesList)
		//            dbWorld_HWGR_SysValuesHash.Add(, value);
		//    }
		//    else
		//        dbWorld_HWGR_SysValuesHash = new Dictionary<string, WorldToHwgr_SysValues>();
		//    return dbWorld_HWGR_SysValuesHash;
		//}


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

			Dictionary<int, Store_WorldData> dbWorldID__Store_WorldIDHash = getdbWorldID__Store_WorldIDHash();
			Dictionary<long, HWGR> dbhwgrHash = getDBhwgrHash();
			List<HWGR> hwgrSaveList = new List<HWGR>();
			List<WorldToHwgr> world_hwgrSaveList = new List<WorldToHwgr>();

			Dictionary<string, ImportDataHWGR> data = new Dictionary<string, ImportDataHWGR>();
			Dictionary<string, WorldToHwgr> dbworld_hwgrHash = getWorld_HWGRHash();
			
			//Add HWGR

			int i = 1;
			while (csv.ReadNextRecord())
			{
				csvDataNextRow();
				int worldID = int.Parse(csv[worldIDIndex]);
				int hwgrID = int.Parse(csv[hwgr_IDIndex]);
				string hwgrName = csv[hwgr_NameIndex];
				string key = worldID.ToString() + hwgrID.ToString();
				if (!data.ContainsKey(key))
				{
					data.Add(key, new ImportDataHWGR(i ,hwgrID, worldID, hwgrName));
					if (!dbhwgrHash.ContainsKey(hwgrID))
					{
						HWGR hwgr = new HWGR(hwgrID, SharedConsts.NeutralLangId, hwgrName);
						hwgr.Import = true;
						hwgrSaveList.Add(hwgr);
						dbhwgrHash.Add(hwgrID, hwgr);
					}
				}
				else
				{
					message(string.Format(GetLocalized("HWGRExists"), i, _WorldID, worldID, _HWGR_ID, hwgrID));
				}
				i++;
			}
			csvDataEndRead();
			if (hwgrSaveList.Count > 0)
			{
				SaveOrUpdateList<HWGR>(_IStoreService.HWGRService, hwgrSaveList);
				dbhwgrHash = getDBhwgrHash();
			}

			//Add WorldToHwgr
			i = 1;
			foreach (ImportDataHWGR importData in data.Values)
			{
				Store_WorldData store_WorldData;
				if (dbWorldID__Store_WorldIDHash.TryGetValue(importData.WorldID, out store_WorldData))
				{
					HWGR hwgr = dbhwgrHash[importData.HWGR_ID];
					foreach (long store_worldID in store_WorldData.Store_WorldIDList)
					{
						if (!dbworld_hwgrHash.ContainsKey(store_worldID.ToString() + hwgr.ID.ToString()))
						{
							WorldToHwgr wh = new WorldToHwgr();
							wh.StoreWorld_ID = store_worldID;
							wh.HWGR_ID = hwgr.ID;
							wh.BeginTime = DateTimeSql.SmallDatetimeMin;
							wh.EndTime = DateTimeSql.SmallDatetimeMax;
							world_hwgrSaveList.Add(wh);
						}
					}
				}
				else
				{
					message(string.Format(GetLocalized("WorldNotExistsDB"), importData.RecordNumber, _WorldID, importData.WorldID));
				}
			}
			SaveOrUpdateList<WorldToHwgr>(_IStoreService.WorldToHWGRService, world_hwgrSaveList);
		}

		struct Store_WorldData
		{
			internal long Store_WorldID;
			internal List<long> Store_WorldIDList;
			internal Store_WorldData(long worldID, List<long> store_WorldIDList)
			{
				Store_WorldID = worldID;
				Store_WorldIDList = store_WorldIDList;
			}
		}
*/
		protected class ImportDataHWGR
		{
			internal int HWGR_ID;
			internal int WorldID;
			internal string Name;
			internal int RecordNumber;

			internal ImportDataHWGR(int recordNumber, int hwgr_ID, int worldID, string name)
			{
				HWGR_ID = hwgr_ID;
				WorldID = worldID;
				Name = name;
				RecordNumber = recordNumber;
			}

		}

	}
}
