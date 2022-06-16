using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.Import
{
	[Serializable]
	public class ImportEmployeeData
	{
		public int HWGR_SystemID;
		public int World_SystemID;
		public int Store_SystemID;
        public int PersNumber;
		public string FirstName;
		public string LastName;
		public string PersID;
		public DateTime ContractBegin;
		public DateTime ContractEnd;
        public decimal ContractWorkingHours;
        public decimal AvailableHolidays;
        public decimal BalanceHours;
        public string Department;
        public EmployeeImportError ImportError;
        public byte AllIn;
	}
}
