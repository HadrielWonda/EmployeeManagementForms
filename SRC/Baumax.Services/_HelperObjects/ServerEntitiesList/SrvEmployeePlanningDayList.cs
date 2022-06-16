using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using System.Diagnostics;
using Baumax.Contract;
using Baumax.AppServer.Environment;
using Baumax.Contract.TimePlanning;

namespace Baumax.Services._HelperObjects.ServerEntitiesList
{

    public class EmployeePlanningDayList
    {
        List<EmployeeDayStatePlanning> _list = new List<EmployeeDayStatePlanning>();
        Dictionary<DateTime, EmployeeDayStatePlanning> _index = new Dictionary<DateTime, EmployeeDayStatePlanning>();
        private long _EmployeeId;

        public long EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }

        public EmployeePlanningDayList(long emplid)
        {
            EmployeeId = emplid;
        }

        public void AddEntity(EmployeeDayStatePlanning entity)
        {
            if (entity != null && entity.EmployeeID == EmployeeId)
            {
                if (!_index.ContainsKey(entity.Date))
                {
                    _index[entity.Date] = entity;
                    _list.Add(entity);
                }
            }
        }
        public void RemoveEntity(EmployeeDayStatePlanning entity)
        {
            if (entity != null && entity.EmployeeID == EmployeeId)
            {
                if (_index.ContainsKey(entity.Date))
                {
                    _index.Remove(entity.Date);
                    _list.Remove(entity);
                }
            }
        }
        public int GetAdditionalChargesForWeekRange(DateTime monday, DateTime sunday)
        {
            int sumOfAdditionalCharges = 0;
            if (_index.Count > 0)
            {
                foreach (EmployeeDayStatePlanning entity in _index.Values)
                {
                    if (DateTimeHelper.Between(entity.Date, monday, sunday))
                    {
                        sumOfAdditionalCharges += entity.SumOfAddHours;
                    }
                }
            }
            return sumOfAdditionalCharges;
        }
        
        public EmployeeDayStatePlanning this[DateTime date]
        {
            get
            {
                EmployeeDayStatePlanning entity;
                _index.TryGetValue(date, out entity);
                return entity;
            }
        }
        public List<EmployeeDayStatePlanning> List
        {
            get { return _list; }
        }
        
    }

    public class EmployeePlanningDayListEx : List<EmployeeDayStatePlanning>
    {
        private long _employeeid;
	    public long EmployeeId
	    {
	        get { return _employeeid;}
	    }

        public EmployeePlanningDayListEx(long emplid)
            : base(100)
        {
            _employeeid = emplid;
        }
        public EmployeePlanningDayListEx(long emplid, DateTime fromDate)
            : base(100)
        {
            _employeeid = emplid;
            Load(fromDate, DateTimeSql.SmallDatetimeMax);
        }
        public EmployeePlanningDayListEx(long emplid, DateTime fromDate, DateTime toDate)
            :base(100)
        {
            _employeeid = emplid;
            Load(fromDate, toDate);
        }

        private void Load(DateTime fromDate, DateTime toDate)
        {
            EmployeeDayStatePlanningService service = ServerEnvironment.EmployeeDayStatePlanningService as EmployeeDayStatePlanningService;

            List<EmployeeDayStatePlanning> list = service.GetEmployeeStates(EmployeeId, fromDate, toDate);

            if (list != null)
                AddRange(list);
        }

        public void RemoveFromDatabase(DateTime fromDate, DateTime toDate)
        {
            List<EmployeeDayStatePlanning> entities = new List<EmployeeDayStatePlanning>();
            List<EmployeeDayStatePlanning> temp = new List<EmployeeDayStatePlanning>();
            foreach (EmployeeDayStatePlanning entity in this)
            {
                if (DateTimeHelper.Between(entity.Date, fromDate, toDate))
                    entities.Add(entity);
                else
                    temp.Add(entity);
            }

            EmployeeDayStatePlanningService service = ServerEnvironment.EmployeeDayStatePlanningService as EmployeeDayStatePlanningService;

            service.DeleteList(entities);

            Clear();
            AddRange(temp);
        }

    }

    public class SrvEmployeesPlanningDayList
    {
        Dictionary<long, EmployeePlanningDayList> _EmployeeToDayState = new Dictionary<long, EmployeePlanningDayList>();

        private DateTime _FromDate;
        private DateTime _ToDate = DateTimeSql.SmallDatetimeMax;

        public DateTime FromDate
        {
            get { return _FromDate; }
            protected set { _FromDate = value; }
        }
        public DateTime ToDate
        {
            get { return _ToDate; }
            protected set { _ToDate = value; }
        }
        protected EmployeeDayStatePlanningService Service
        {
            get { return ServerEnvironment.EmployeeDayStatePlanningService as EmployeeDayStatePlanningService; }
        }

        public SrvEmployeesPlanningDayList(long[] ids, DateTime fromdate, DateTime todate)
        {
            FromDate = fromdate;
            _ToDate = todate;

            InitCache(ids);
        }
        public SrvEmployeesPlanningDayList(long[] ids, DateTime fromdate)
        {
            FromDate = fromdate;

            InitCache(ids);
        }
        public SrvEmployeesPlanningDayList(long id, DateTime fromdate)
        {
            FromDate = fromdate;
            InitCache(new long[] { id });
        }
        private void InitCache(long[] ids)
        {
            List<EmployeeDayStatePlanning> list = Service.GetEmployeesState(ids, FromDate, ToDate);

            BuildDiction(list);
        }
        private void BuildDiction(List<EmployeeDayStatePlanning> list)
        {
            _EmployeeToDayState.Clear();
            if (list == null || list.Count == 0) return;
            EmployeePlanningDayList dictionItem = null;
            foreach (EmployeeDayStatePlanning entity in list)
            {
                if (!_EmployeeToDayState.TryGetValue(entity.EmployeeID, out dictionItem))
                {
                    dictionItem = CreateDictionItem(entity.EmployeeID);
                }
                dictionItem.AddEntity(entity);
            }
        }
        private EmployeePlanningDayList CreateDictionItem(long emplid)
        {
            EmployeePlanningDayList list = new EmployeePlanningDayList(emplid);
            _EmployeeToDayState[emplid] = list;
            return list;
        }

        private void _DoUpdate(EmployeeDayStatePlanning entity)
        {
            if (entity.IsNew)
                Service.Save(entity);
            else
                Service.Update(entity);

            //ServerEnvironment.EmployeeDayStatePlanningService.SaveOrUpdate(entity);
        }

        protected virtual void _DoDelete(EmployeeDayStatePlanning entity)
        {
            Service.Delete(entity);
        }

        public void LoadList(long id, DateTime fromdate)
        {
            LoadList (new long[] {id}, fromdate);
        }
        public void LoadList(long[] ids, DateTime fromdate)
        {
            FromDate = fromdate;
            InitCache(ids);
        }

        public EmployeePlanningDayList GetList(long emplid)
        {
            EmployeePlanningDayList list = null;
            _EmployeeToDayState.TryGetValue (emplid, out list);

            return list;
        }
        public int GetAdditionalChargesForWeekRange(long emplid, DateTime monday, DateTime sunday)
        {
            EmployeePlanningDayList list = GetList(emplid);

            int result = 0;

            if (list != null)
            {
                result = list.GetAdditionalChargesForWeekRange(monday, sunday);
            }

            return result;
        }
        private void DeleteEntity(EmployeeDayStatePlanning entity)
        {
            _DoDelete(entity);
        }
        public void CompareAndSave(EmployeeDay day)
        {
            if (day == null)
                throw new ArgumentNullException();

            EmployeePlanningDayList list = GetList(day.EmployeeId);
            if (list == null)
            {
                list = CreateDictionItem(day.EmployeeId);
            }

            EmployeeDayStatePlanning entity = list[day.Date];

            if (entity == null)
            {
                if (day.IsValidDay)
                {
                    entity = EmployeeDayProcessor.CreatePlanningEntity(day);
                    UpdateEntity(entity);
                    list.AddEntity(entity);
                }
            }
            else
            {
                if (day.IsValidDay )
                {
                    if (!EmployeeDayProcessor.IsEqual(entity, day))
                    {
                        EmployeeDayProcessor.AssignToPlanning(entity, day);
                        UpdateEntity(entity);
                    }
                }
                else
                {
                    if (entity != null)
                    {
                        DeleteEntity(entity);
                    }
                }
            }
        }

        public void UpdateEntity(EmployeeDayStatePlanning entity)
        {
            _DoUpdate(entity);
        }

        
    }
}
