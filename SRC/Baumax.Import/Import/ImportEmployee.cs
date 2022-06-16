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
using System.Globalization;

namespace Baumax.Import
{
	internal class ImportEmployee: ImportBase
	{

        const int _PersNumberIndex = 3;
        const int _ContractBeginIndex = 6;
        const int _ContractEndIndex = 7;
		const int _PersIDIndex= 1;
		const int _LastNameIndex= 4;
		const int _FirstNameIndex = 5;
		const int _WorldIDIndex = 9;
		const int _HWGR_IDIndex = 10;
		new const int _StoreIDIndex = 0;
        const int _ContractWorkingHoursIndex = 8;
        const int _AvailableHolidaysIndex = 12;
        const int _BalanceHoursIndex= 11;
        const int _DepartmentIndex = 13;
        const int _AllInIndex = 14;

        IEmployeeService _EmployeeService;

		internal ImportEmployee(string fileName, IEmployeeService employeeService)
			:base(fileName,null)
		{
			_EmployeeService = employeeService;
		}

		protected override string ImportName
		{
			get
			{
				return GetLocalized("inEmployee");
			}
		}

		protected override void readCSVFile(CachedCsvReader csv)
		{
#if(UseHeaders)
#else
            int persNumberIndex = _PersNumberIndex;
            int contractBeginIndex= _ContractBeginIndex;
			int contractEndIndex= _ContractEndIndex;
			int persIDIndex= _PersIDIndex;
			int lastNameIndex= _LastNameIndex;
			int firstNameIndex= _FirstNameIndex;
			int worldIDIndex= _WorldIDIndex;
			int hwgr_IDIndex = _HWGR_IDIndex;
			int storeIDIndex = _StoreIDIndex;
            int departmentIndex = _DepartmentIndex;
            int allInIndex = _AllInIndex;	

#endif
            if (csv.FieldCount < (allInIndex + 1))
            {
                throw new Exception(GetLocalized("EmployeeImportFileOldVersion"));
            }
            //CultureInfo.GetCultureInfo("en-US").NumberFormat
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.CurrencyDecimalSeparator = ".";
            numberFormatInfo.CurrencyGroupSeparator = " ";
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = " ";

            //numberFormatInfo.PositiveInfinitySymbol = "+";
            //numberFormatInfo.NegativeInfinitySymbol = "-";
            Dictionary<string, ImportFileEmployeeData> data = new Dictionary<string, ImportFileEmployeeData>();
			while (csv.ReadNextRecord())
			{
				csvDataNextRow();
                string department = csv[departmentIndex];
				string worldID = csv[worldIDIndex];
				if (string.IsNullOrEmpty(worldID)) worldID = "-1";
				string hwgr_ID = csv[hwgr_IDIndex];
				if (string.IsNullOrEmpty(hwgr_ID)) hwgr_ID = "-1";
				string storeID = csv[storeIDIndex];
				string key = csv[persIDIndex];//storeID.ToString() + worldID.ToString() + hwgr_ID.ToString();
				if (string.IsNullOrEmpty(storeID)) storeID = "-1";
                string contractWorkingHours = csv[_ContractWorkingHoursIndex];
                if (string.IsNullOrEmpty(contractWorkingHours)) contractWorkingHours = "0";
                //else if (contractWorkingHours[0] == ',') contractWorkingHours = "0" + contractWorkingHours;
                string availableHolidays= csv[_AvailableHolidaysIndex];
                if (string.IsNullOrEmpty(availableHolidays)) availableHolidays = "0";
                //else if (availableHolidays[0] == ',') availableHolidays = "0" + availableHolidays;
                string balanceHours = csv[_BalanceHoursIndex];
                if (string.IsNullOrEmpty(balanceHours)) balanceHours = "0";
                //else if (balanceHours[0] == ',') balanceHours = "0" + balanceHours;
                string persNumber = csv[persNumberIndex];
                if (string.IsNullOrEmpty(persNumber)) persNumber = "0";
                if (!data.ContainsKey(key))
				{
					ImportEmployeeData eData = new ImportEmployeeData();
					eData.World_SystemID = int.Parse(worldID);
					eData.HWGR_SystemID = int.Parse(hwgr_ID);
					eData.Store_SystemID = int.Parse(storeID);
					eData.PersID = key;
					eData.FirstName = csv[firstNameIndex];
					eData.LastName = csv[lastNameIndex];
                    eData.Department = department;
					string contractBegin = csv[contractBeginIndex];
					if (string.IsNullOrEmpty(contractBegin)) contractBegin = DateTimeSql.SmallDatetimeMinStr;
					eData.ContractBegin = DateTime.ParseExact(contractBegin, "yyyyMMdd", null);
					string contractEnd = csv[contractEndIndex];
					if (string.IsNullOrEmpty(contractEnd)) contractEnd = DateTimeSql.SmallDatetimeMaxStr;
					eData.ContractEnd = DateTime.ParseExact(contractEnd, "yyyyMMdd", null);
                    try
                    {
                        eData.ContractWorkingHours = decimal.Parse(contractWorkingHours, numberFormatInfo);
                        eData.AvailableHolidays = decimal.Parse(availableHolidays, numberFormatInfo);
                        eData.BalanceHours = decimal.Parse(balanceHours, numberFormatInfo);
                        eData.BalanceHours = eData.BalanceHours * 60;//minutes
                        eData.PersNumber = int.Parse(persNumber);
                        eData.AllIn = byte.Parse(csv[allInIndex]);
                    }
                    catch (FormatException ex)
                    { 
                        message(string.Format(GetLocalized("NumberFormatError"),_CurrentRow,ex.Message));
                        continue;
                    }
                    
                    if (eData.AllIn != 0) 
                        eData.AllIn = 1;
                    if (eData.ContractEnd < eData.ContractBegin)
                    {
                        message(string.Format(GetLocalized("EmployeeContractDateError"), _CurrentRow, key, eData.ContractBegin, eData.ContractEnd));
                        continue;
                    }
                    else if (eData.ContractWorkingHours <= 0)
                    {
                        message(string.Format(GetLocalized("EmployeeContractTimeError"), _CurrentRow, key, eData.ContractWorkingHours));
                        continue;
                    }
					data.Add(key, new ImportFileEmployeeData(_CurrentRow, eData));
				}
				else
					message(string.Format(GetLocalized("EmployeeExists"), _CurrentRow, key));
			}
			csvDataEndRead();

			List<ImportEmployeeData> list = new List<ImportEmployeeData>(data.Count);
			foreach (ImportFileEmployeeData value in data.Values)
				list.Add(value.Data);
            ImportEmployeeResult importEmployeeResult = _EmployeeService.ImportEmployee(list);
			list = (List<ImportEmployeeData>)importEmployeeResult.DataError;
            if (list != null)
            {
                foreach (ImportEmployeeData value in list)
                {
                    string key = value.PersID;
                    switch (value.ImportError)
                    {
                        case EmployeeImportError.NotAssignToStore:
                            message(string.Format(GetLocalized("EmployeeNotAssignToStore"), data[key].RecordNumber, key));
                            break;
                        case EmployeeImportError.ContractBeginChange:
                            message(string.Format(GetLocalized("EmployeeIEContractBeginChange"), data[key].RecordNumber, key, data[key].Data.ContractBegin));
                            break;
                        case EmployeeImportError.ContractEndChangeAndLessImportDate:
                            message(string.Format(GetLocalized("EmployeeIEContractEndChangeAndLessImportDate"), data[key].RecordNumber, key, data[key].Data.ContractEnd));
                            break;
                        default:
                            goto case EmployeeImportError.NotAssignToStore;
                    }
                }
            }
            if (importEmployeeResult.DataChanged != null)
                _Result = importEmployeeResult.DataChanged;
            if (!importEmployeeResult.Success)
                throw new Exception("");
		}

		internal class ImportFileEmployeeData
		{
			internal int RecordNumber;
			internal ImportEmployeeData Data;
			
			internal ImportFileEmployeeData()
			{ }

			internal ImportFileEmployeeData(int recordNumber, ImportEmployeeData data)
			{
				RecordNumber = recordNumber;
				Data = data;
			}

			
		}

	}
}
