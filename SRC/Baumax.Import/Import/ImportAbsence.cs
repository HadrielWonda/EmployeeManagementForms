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
    internal class ImportAbsence: ImportBase
    {
        const int _AbsenceTypeIDIndex = 0;
        const int _AbsenceCharIDIndex = 1;
        const int _AbsenceDescriptionIndex = 2;

        IAbsenceService _AbsenceService;

        internal ImportAbsence(string fileName, IAbsenceService absenceService)
			: base(fileName, null)
		{
            _AbsenceService = absenceService;
		}

		protected override string ImportName
		{
			get
			{
                return GetLocalized("inAbsence");
			}
		}

        protected override void readCSVFile(CachedCsvReader csv)
        {
#if(UseHeaders)
#else
            int absenceTypeIDIndex = _AbsenceTypeIDIndex;
            int absenceDescriptionIndex = _AbsenceDescriptionIndex;
#endif


            Dictionary<int, ImportFileAbsenceData> data = new Dictionary<int, ImportFileAbsenceData>();

            //Add Absence
            while (csv.ReadNextRecord())
            {
                csvDataNextRow();
                int systemID = int.Parse(csv[absenceTypeIDIndex]);
                string absenceName = csv[absenceDescriptionIndex];
                if (!data.ContainsKey(systemID))
                    data.Add(systemID, new ImportFileAbsenceData(_CurrentRow, new ImportAbsenceData(systemID, absenceName, csv[_AbsenceCharIDIndex])));
                else
                    message(string.Format(GetLocalized("AbsenceExists"), _CurrentRow, systemID));
            }
            csvDataEndRead();

            List<ImportAbsenceData> list = new List<ImportAbsenceData>(data.Count);
            foreach (ImportFileAbsenceData value in data.Values)
                list.Add(value.Data);
            SaveDataResult saveDataResult =  _AbsenceService.ImportAbsence(list);
            list = (List<ImportAbsenceData>)saveDataResult.Data;
            foreach (ImportAbsenceData value in list)
            {
                message(string.Format(GetLocalized("AbsenceNotImportedInDB"), data[value.SystemID].RecordNumber, value.SystemID));
            }
        }

        struct ImportFileAbsenceData
        {
            internal int RecordNumber;
            internal ImportAbsenceData Data;
            internal ImportFileAbsenceData(int recordNumber, ImportAbsenceData data)
            {
                RecordNumber = recordNumber;
                Data = data;
            }
        }
    }
}
