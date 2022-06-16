using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using Baumax.Contract.HolydayClasses;

namespace Baumax.Contract.Absences
{
     [Serializable]
     public class AbsencePlanningQuery
     {
        public long StoreID = 0;
        public int Year = DateTime.Today.Year;
        public double AvgDaysPerWeek = 0;

        //public List<EmployeeSource> Employees;
        public List<BzEmployeeHoliday> _holidays;
        public List<EmployeeRelation> Relations;
        public List<EmployeeContract> Contracts;

        public List<LongTimeAbsence> LongabsencesEntities;
        public List<EmployeeLongTimeAbsence> Longabsences;
        public List<AbsenceTimePlanning> Plannings;
        public List<AbsenceTimeRecording> Recordings;
        
        public StoreDaysList StoreDays;
        public List<Absence> Absences;
    }
    [Serializable]
    public class AbsencePlanningResponse
    {
        public int Year;
        public long StoreID;
        public EmployeeHolidaysInfo[] ModifiedEntity = null;
        public long[] DeletedIds = null;
        public AbsenceTimeRange[] NewAbsences = null;

    }

}
