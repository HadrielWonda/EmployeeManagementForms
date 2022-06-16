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
	internal class ImportWorld_HwgrToWgr: ImportBase
	{
		IStoreService _IStoreService;

		internal ImportWorld_HwgrToWgr(string fileName, IStoreService iStoreService)
			:base(fileName)
		{
			_IStoreService = iStoreService;
		}

		protected Dictionary<int, World> getDBWorldList()
		{
			Dictionary<int, World> dbWorldHash;
			List<World> dbWorldList = _IStoreService.WorldService.FindAll();
			if (dbWorldList != null)
			{
				dbWorldHash = new Dictionary<int, World>(dbWorldList.Count);
				for (int i = 0; i < dbWorldList.Count; i++)
					dbWorldHash.Add(dbWorldList[i].ExSystemID, dbWorldList[i]);
			}
			else
				dbWorldHash = new Dictionary<int, World>();
			return dbWorldHash;
		}


		protected override void readCSVFile(CachedCsvReader csv)
		{

		}

	}
	*/
}

