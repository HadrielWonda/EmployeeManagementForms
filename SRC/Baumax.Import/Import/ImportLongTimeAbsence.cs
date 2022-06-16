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
namespace Baumax.Import
{
    internal class ImportLongTimeAbsence: ImportBase
    {
        IEmployeeService _EmployeeService;

        const int _PersIDIndex = 0;
        const int _CodeIndex = 1;
        const int _CodeNameIndex = 2;
        const int _BeginTimeIndex = 3;
        const int _EndTimeIndex = 4;

        internal ImportLongTimeAbsence(string fileName, IEmployeeService employeeService)
			:base(fileName,null)
		{
            _EmployeeService = employeeService;
		}

		protected override string ImportName
		{
			get
			{
                return GetLocalized("inLongTimeAbsence");
			}
		}

		protected override void readCSVFile(CachedCsvReader csv)
		{
#if(UseHeaders)
#else
            int persIDIndex = _PersIDIndex;
            int codeIndex = _CodeIndex;
            int codeNameIndex = _CodeNameIndex;
            int beginTimeIndex = _BeginTimeIndex;
            int endTimeIndex = _EndTimeIndex;
#endif

			Dictionary<string, ImportFileLongTimeAbsenceData> data = new Dictionary<string, ImportFileLongTimeAbsenceData>();
			while (csv.ReadNextRecord())
			{
				csvDataNextRow();
                short code = short.Parse(csv[codeIndex]);
                string persID = csv[persIDIndex];
                DateTime beginTime = DateTime.ParseExact(csv[beginTimeIndex], "yyyyMMdd", null);
                string endTimeStr = csv[endTimeIndex];
                if (string.IsNullOrEmpty(endTimeStr)) endTimeStr = DateTimeSql.SmallDatetimeMaxStr;
                DateTime endTime = DateTime.ParseExact(endTimeStr, "yyyyMMdd", null);
                string key = persID + code.ToString() + beginTime.ToString() + endTime.ToString();
                if (!data.ContainsKey(key))
                {
                    ImportLongTimeAbsenceData lta= new ImportLongTimeAbsenceData();
                    lta.PersID = persID;
                    lta.BeginTime = beginTime;
                    lta.EndTime = endTime;
                    lta.Code = code;
                    lta.CodeName = csv[codeNameIndex];
                    data.Add(key, new ImportFileLongTimeAbsenceData(_CurrentRow, lta));
                }
                else
                    message(string.Format(GetLocalized("LongTimeAbsenceExists"), _CurrentRow, persID, code, beginTime, endTime));
            }
			csvDataEndRead();

            List<ImportLongTimeAbsenceData> list = new List<ImportLongTimeAbsenceData>(data.Count);
			foreach (ImportFileLongTimeAbsenceData value in data.Values)
				list.Add(value.Data);
            SaveDataResult saveDataResult = _EmployeeService.LongTimeAbsenceService.ImportLongTimeAbsence(list);
            list = (List<ImportLongTimeAbsenceData>)saveDataResult.Data;
            foreach (ImportLongTimeAbsenceData value in list)
			{
                string key = value.PersID.ToString() + value.Code.ToString () + value.BeginTime.ToString() + value.EndTime.ToString();
                message(string.Format(GetLocalized("LongTimeAbsenceNotAssignToEmployee"), data[key].RecordNumber, value.PersID));
			}
		}

		internal class ImportFileLongTimeAbsenceData
		{
			internal int RecordNumber;
            internal ImportLongTimeAbsenceData Data;
			
			internal ImportFileLongTimeAbsenceData()
			{ }

            internal ImportFileLongTimeAbsenceData(int recordNumber, ImportLongTimeAbsenceData data)
			{
				RecordNumber = recordNumber;
				Data = data;
			}

			
		}

	}
}
