using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.QueryResult
{
	[Serializable]
	public class HWGR_WGR_SysValues
	{
		public long World_HWGR_ID;
		public long WGR_ID;        
		public int HWGR_SystemID;
		public int World_SystemID;
		public int WGR_SystemID;

		public HWGR_WGR_SysValues(long world_HWGR_ID, long wgr_ID, int hwgr_SystemID, int world_SystemID, int wgr_SystemID)
		{
			World_HWGR_ID = world_HWGR_ID; ;
			WGR_ID= wgr_ID;        
			HWGR_SystemID= hwgr_SystemID;
			World_SystemID = world_SystemID;
			WGR_SystemID = wgr_SystemID;
		}
		public HWGR_WGR_SysValues()
		{ 
		
		}
	}
}
