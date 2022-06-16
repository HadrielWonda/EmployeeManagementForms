using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.QueryResult
{
	[Serializable]
	public class HWGR_WGR_SysValuesShort
	{
		public int HWGR_SystemID;
		public int World_SystemID;
		public int WGR_SystemID;

		public HWGR_WGR_SysValuesShort(int hwgr_SystemID, int wgr_SystemID)
			:this(hwgr_SystemID,0,wgr_SystemID)
		{
		}

		public HWGR_WGR_SysValuesShort(int hwgr_SystemID, int world_SystemID, int wgr_SystemID)
		{
			HWGR_SystemID= hwgr_SystemID;
			World_SystemID = world_SystemID;
			WGR_SystemID = wgr_SystemID;
		}
		public HWGR_WGR_SysValuesShort()
		{ 
		
		}

	}
}
