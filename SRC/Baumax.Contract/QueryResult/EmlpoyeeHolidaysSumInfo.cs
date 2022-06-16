using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Contract.QueryResult
{
    [Serializable]
    public class EmlpoyeeHolidaysSumInfo
    {
        public long EmployeeID;
        public int TimeRecording;
        public int TimePlanning;
    }

    [Serializable]
    public class EmlpoyeeHolidaysSumDays
    {
        public long EmployeeID;
        public decimal TimeRecording;
        public decimal TimePlanning;

        public EmlpoyeeHolidaysSumDays()   { }

        public EmlpoyeeHolidaysSumDays (EmlpoyeeHolidaysSumInfo info)
        {
            EmployeeID = info.EmployeeID;
            TimePlanning = Utills.ToDays(info.TimePlanning);
            TimeRecording = Utills.ToDays(info.TimeRecording);
        }

        public static Dictionary<long, EmlpoyeeHolidaysSumDays> BuildDiction(List<EmlpoyeeHolidaysSumDays> list)
        {
            Dictionary<long, EmlpoyeeHolidaysSumDays> diction = new Dictionary<long, EmlpoyeeHolidaysSumDays>();

            if (list != null)
            {
                foreach (EmlpoyeeHolidaysSumDays item in list)
                    diction[item.EmployeeID] = item;
            }
            return diction;
        }
    }
}
