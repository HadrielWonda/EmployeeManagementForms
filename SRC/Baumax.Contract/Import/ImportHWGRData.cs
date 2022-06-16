using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.Import
{
	[Serializable]
	public class ImportHWGRData
	{
		public int HWGR_SystemID;
		public int World_SystemID;
		public string Name;

		public ImportHWGRData(int hwgr_SystemID, int world_SystemID, string name)
		{
			HWGR_SystemID = hwgr_SystemID;
			World_SystemID = world_SystemID;
			Name = name;
		}

		public ImportHWGRData()
		{ }
	}
}
