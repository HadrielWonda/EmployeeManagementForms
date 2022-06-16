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
	internal class ImportWorld : ImportStore
	{
		const int _WorldIDIndex= 0;
		const int _WorldNameIndex= 1;

		internal ImportWorld(string fileName, IStoreService storeService)
			: base(fileName, null, null, storeService)
		{	}

		protected override string ImportName
		{
			get
			{
				return GetLocalized("inWorlds");
			}
		}
		private Dictionary<string, World> getDBWorldHash()
		{
			Dictionary<string, World> dbWorldHash;
			List<World> dbWorldList = _IStoreService.WorldService.FindAll();
			if (dbWorldList != null)
			{
				dbWorldHash = new Dictionary<string, World>(dbWorldList.Count);
                for (int i = 0; i < dbWorldList.Count; i++)
                {
                    if (dbWorldList[i].Import)
                        dbWorldHash.Add(dbWorldList[i].ExSystemID.ToString(), dbWorldList[i]);
                }
			}
			else
				dbWorldHash = new Dictionary<string, World>();
			return dbWorldHash;
		}

		protected Dictionary<string, StoreToWorld> getStore_WorldHash()
		{
			Dictionary<string, StoreToWorld> dbStore_WorldHash;
			List<StoreToWorld> dbStore_WorldList = _IStoreService.StoreToWorldService.FindAll();
			if (dbStore_WorldList != null)
			{
				dbStore_WorldHash = new Dictionary<string, StoreToWorld>(dbStore_WorldList.Count);
				for (int i = 0; i < dbStore_WorldList.Count; i++)
					dbStore_WorldHash.Add(dbStore_WorldList[i].StoreID.ToString() + dbStore_WorldList[i].WorldID.ToString(), dbStore_WorldList[i]);
			}
			else
				dbStore_WorldHash = new Dictionary<string, StoreToWorld>();
			return dbStore_WorldHash;
		}

		protected override void readCSVFile(CachedCsvReader csv)
		{
#if(UseHeaders)
			int worldIDIndex = csv.GetFieldIndex(_WorldID);
			int worldNameIndex = csv.GetFieldIndex(_WorldName);
#else
			int worldIDIndex = _WorldIDIndex;
			int worldNameIndex = _WorldNameIndex;
#endif
			Dictionary<string, World> dbWorldHash = getDBWorldHash();
			Dictionary<long, Store> dbStoreHash = getDBStoreList();
			Dictionary<string, StoreToWorld> dbStore_WorldHash = getStore_WorldHash();

			List<World> worldSaveList = new List<World>();
			List<StoreToWorld> store_WorldSaveList = new List<StoreToWorld>();

			bool isNew= false;
			while (csv.ReadNextRecord())
			{
				csvDataNextRow();
				string worldID = csv[worldIDIndex];
				string worldName = csv[worldNameIndex];
				string key = worldID;
				World world;
				if (dbWorldHash.ContainsKey(key))
				{
					world = dbWorldHash[key];
				}
				else
				{
					world = new World();
				}
				world.ExSystemID = int.Parse(worldID);
				world.LanguageID = SharedConsts.NeutralLangId;
				world.Name = worldName;
				world.WorldTypeID = WorldType.World;
				world.Import = true;
				if (!worldSaveList.Contains(world))
					worldSaveList.Add(world);
				else
					message(string.Format(GetLocalized("WorldExists"), _CurrentRow, _WorldID, worldID));

				if (world.IsNew && !dbWorldHash.ContainsKey(key))
				{
					dbWorldHash.Add(key, world);
					isNew= true;
				}
			}
			csvDataEndRead();
			SaveOrUpdateList<World>(_IStoreService.WorldService,worldSaveList);

			if (isNew)
				dbWorldHash = getDBWorldHash();
			foreach (Store store in dbStoreHash.Values)
			{
				foreach (World world in dbWorldHash.Values)
				{ 
					string key= store.ID.ToString () + world.ID.ToString ();
					if (!dbStore_WorldHash.ContainsKey(key))
					{
						StoreToWorld store_world = new StoreToWorld(world.ID, store.ID);
						store_WorldSaveList.Add(store_world);
						dbStore_WorldHash.Add(key, store_world);
					}
				}
			}
			if (dbStoreHash.Count == 0)
				message(GetLocalized("StoresNotExistsDB"));
			SaveList<StoreToWorld>(_IStoreService.StoreToWorldService, store_WorldSaveList);
		}
	}
}
