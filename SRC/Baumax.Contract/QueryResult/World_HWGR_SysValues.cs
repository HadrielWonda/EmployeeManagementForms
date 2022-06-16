using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.QueryResult
{
	[Serializable]
	public class World_HWGR_SysValues
	{
		public long World_HWGR_ID;
		public long Store_WorldID;
		public long HWGR_ID;
		public long HWGR_SystemID;
		public int World_SystemID;
		
		public World_HWGR_SysValues()
		{ 
		
		}

		public World_HWGR_SysValues(long world_HWGR_ID, long store_WorldID, long hwgr_ID, long hwgr_SystemID, int exSystemID)
		{ 
			World_HWGR_ID= world_HWGR_ID;
			Store_WorldID= store_WorldID;
			HWGR_ID= hwgr_ID;
			HWGR_SystemID = hwgr_SystemID;
			World_SystemID = exSystemID;
		}

	}
}
