using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Interfaces;

namespace Baumax.Contract.PlanningAndRecording
{
    [Serializable]
    public class AbsencePlanningQuery
    {
        public long StoreID = 0;
        public int Year = DateTime.Today.Year;
        public double AvgDaysPerWeek = 0;

        public List<Employee> Employees;
        public List<EmployeeHolidaysInfo> HolidaysInfos;
        public List<EmployeeRelation> Relations;
        public List<EmployeeContract> Contracts;
        public List<EmployeeLongTimeAbsence> Longabsences;

        public List<AbsenceTimePlanning> Plannings;
        public List<AbsenceTimeRecording> Recordings;
        public DateTime[] Feasts;
        public DateTime[] Closeddays;
        public List<StoreWorkingTime> Storetimes;
    }
}
