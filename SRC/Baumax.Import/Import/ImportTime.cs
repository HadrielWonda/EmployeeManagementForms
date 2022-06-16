using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System.IO;
using System.Collections;
using System.Threading;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;
using Baumax.Contract;
using LumenWorks.Framework.IO.Csv;

namespace Baumax.Import
{
    internal class ImportTime : ImportBase
    {
        private const int _PersIDIndex = 0;
        private const int _DateIndex = 1;
        private const int _AbsenceCharIDIndex = 2;
        private const int _BeginIndex = 3;
        private const int _EndIndex = 4;

        private IEmployeeTimeService _EmployeeTimeService;
        private bool _ImportRunning;
        private SaveDataResult _SaveDataResult;
        private Dictionary<string, ImportFileTimeData> _Data;
        private ImportTimeType _ImportTimeType;

        internal ImportTime(string fileName, IEmployeeTimeService employeeTimeService, ImportTimeType importTimeType)
            : base(fileName, null)
        {
            _ImportTimeType = importTimeType;
            _EmployeeTimeService = employeeTimeService;
            _ImportRunning = true;
            _SaveDataResult = new SaveDataResult();
        }

        protected override string ImportName
        {
            get
            {
                string importName;
                switch (_ImportTimeType)
                {
                    case ImportTimeType.Planning:
                        importName = GetLocalized("inTimePlanning");
                        break;
                    case ImportTimeType.Recording:
                        importName = GetLocalized("inTimeRecording");
                        break;
                    default:
                        goto case ImportTimeType.Planning;
                }
                return importName;
            }
        }

        private short getTimeInMinutes(string time)
        {
            short result = (short) (short.Parse(time.Substring(0, 2))*60);
            result += short.Parse(time.Substring(2, 2));
            return result;
        }

        protected override void readCSVFile(CachedCsvReader csv)
        {
            _Data = new Dictionary<string, ImportFileTimeData>();
            while (csv.ReadNextRecord())
            {
                csvDataNextRow();
                string persID = csv[_PersIDIndex];
                string charID = csv[_AbsenceCharIDIndex];
                DateTime date = DateTime.ParseExact(csv[_DateIndex], "yyyyMMdd", null);
                short begin = getTimeInMinutes(csv[_BeginIndex]);
                short end = getTimeInMinutes(csv[_EndIndex]);
                string key = persID.ToString() + charID + csv[_DateIndex] + begin.ToString() + end.ToString();
                if (!_Data.ContainsKey(key))
                {
                    ImportTimeData awp = new ImportTimeData();
                    awp.PersID = persID;
                    awp.CharID = charID;
                    awp.Date = date;
                    awp.Begin = begin;
                    awp.End = end;
                    _Data.Add(key, new ImportFileTimeData(_CurrentRow, awp));
                }
                else
                {
                    message(
                        string.Format(GetLocalized("TimePlanningExists"), _CurrentRow, persID, date, charID, begin, end));
                }
            }
            csvDataEndRead();

            List<ImportTimeData> list = new List<ImportTimeData>(_Data.Count);
            foreach (ImportFileTimeData value in _Data.Values)
            {
                list.Add(value.Data);
            }
            _EmployeeTimeService.OperationComplete += new OperationCompleteDelegate(employeeTimeService_OnOperationComplete);
            try
            {
                _EmployeeTimeService.ImportTime(list, _ImportTimeType);
                while (_ImportRunning)
                {
                    Thread.Sleep(1000);
                }
            }
            finally
            {
                _EmployeeTimeService.OperationComplete -= new OperationCompleteDelegate(employeeTimeService_OnOperationComplete);
            }
        }

        private void employeeTimeService_OnOperationComplete(object sender, OperationCompleteEventArgs e)
        {
            if (e.Success)
            {
                //List<ImportTimeData> list = (List<ImportTimeData>) e.Param;
                //foreach (ImportTimeData value in list)
                //{
                //    string key = value.PersID + value.CharID + value.Date.ToString("yyyyMMdd") + value.Begin.ToString() +
                //                 value.End.ToString();
                //    message(
                //        string.Format(GetLocalized("TimePlanningNotAssignToEmployee"), _Data[key].RecordNumber,
                //                      value.PersID));
                //}
            }
            _ImportRunning = false;
        }

        internal class ImportFileTimeData
        {
            internal int RecordNumber;
            internal ImportTimeData Data;

            internal ImportFileTimeData()
            {
            }

            internal ImportFileTimeData(int recordNumber, ImportTimeData data)
            {
                RecordNumber = recordNumber;
                Data = data;
            }
        }
    }
}