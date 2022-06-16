using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.Interfaces;

namespace Baumax.Contract.TimePlanning
{
    public class EmployeeLongTimeAbsenceIndexer
    {
        Dictionary<long, List<EmployeeLongTimeAbsence>> _diction = new Dictionary<long, List<EmployeeLongTimeAbsence>>();
        List<EmployeeLongTimeAbsence> _lstUsing = null;
        long _lastId = 0;

        public EmployeeLongTimeAbsenceIndexer(List<EmployeeLongTimeAbsence> lst)
        {
            BuildDiction(lst);
        }
        public EmployeeLongTimeAbsenceIndexer(IEmployeeLongTimeAbsenceService service, long emplid)
        {

            LoadByEmployee(service, emplid);
        }

        public void BuildDiction(List<EmployeeLongTimeAbsence> lst)
        {
            _diction.Clear();
            _lastId = 0;
            _lstUsing = null;
            if (lst == null) return;

            
            foreach (EmployeeLongTimeAbsence rel in lst)
            {
                GetById(rel.EmployeeID,true).Add(rel);
            }
        }

        private List<EmployeeLongTimeAbsence> GetById(long emplid, bool bCreate)
        {
            if (_lstUsing != null && _lastId == emplid) return _lstUsing; 

            List<EmployeeLongTimeAbsence> list = null;

            if (_diction.TryGetValue(emplid, out list))
            {
                _lstUsing = list;
                _lastId = emplid;
                return list;
            }

            if (bCreate)
            {
                list = new List<EmployeeLongTimeAbsence>();
                _lstUsing = list;
                _lastId = emplid;
                _diction[emplid] = list;
            }

            return list;
        }

        public int Count
        {
            get { return _diction.Count; }
        }
        public List<EmployeeLongTimeAbsence> this[long emplid]
        {
            get { return GetById(emplid, false); }
        }

        public EmployeeLongTimeAbsence IsContain(long emplid, DateTime date)
        {
            List<EmployeeLongTimeAbsence> lst = this[emplid];

            if (lst == null) return null;

            foreach (EmployeeLongTimeAbsence entity in lst)
            {
                //if (DateTimeHelper.IsHitInInterval(date, entity.BeginTime, entity.EndTime)) return entity;
                if (entity.IsContainDate(date)) return entity;
            }
            return null;
        }

        public bool FillEmployeeWeek(EmployeeWeek week)
        {
            if (week == null) return false;
            bool bExists = false;
            List<EmployeeLongTimeAbsence> lst = this[week.EmployeeId];

            if (lst != null && lst.Count > 0)
            {
                
                foreach (EmployeeLongTimeAbsence entity in lst)
                {
                    foreach (EmployeeDay d in week.DaysList)
                    {
                        if (entity.IsContainDate(d.Date))
                        {
                            d.LongAbsenceId = entity.LongTimeAbsenceID;
                        }
                    }
                }
                bExists = true;
                foreach (EmployeeDay d in week.DaysList)
                {
                    
                    bExists &= d.HasLongAbsence;
                }

            }
            return !bExists;
        }
        public void FillEmployeeWeeks(List<EmployeeWeek> weeks)
        {
            if (weeks == null || weeks.Count == 0) return;

            foreach (EmployeeWeek w in weeks)
                FillEmployeeWeek(w);
        }

        public void LoadByEmployee(IEmployeeLongTimeAbsenceService service, long emplid)
        {
            if (service == null) return;

            List<EmployeeLongTimeAbsence> list = service.GetEmployeesHasLongTimeAbsence(new long[] { emplid }, DateTimeSql.SmallDatetimeMin,
                DateTimeSql.SmallDatetimeMax);

            BuildDiction(list);
        }
        public void LoadByCountry(IEmployeeLongTimeAbsenceService service, long countryid, DateTime fromDate)
        {
            if (service == null) return;

            List<EmployeeLongTimeAbsence> list = null;

            BuildDiction(list);
        }

        public void LoadAll(IEmployeeLongTimeAbsenceService service, DateTime fromDate)
        {
            if (service == null) return;

            List<EmployeeLongTimeAbsence> list = null;

            BuildDiction(list);
        }

    }
}
