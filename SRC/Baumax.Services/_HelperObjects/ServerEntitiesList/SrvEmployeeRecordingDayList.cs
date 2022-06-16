using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.AppServer.Environment;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;

namespace Baumax.Services._HelperObjects.ServerEntitiesList
{
    public class SrvEmployeeRecordingDayList
    {
        List<EmployeeDayStateRecording> _list = new List<EmployeeDayStateRecording>();
        Dictionary<DateTime, EmployeeDayStateRecording> _index = new Dictionary<DateTime, EmployeeDayStateRecording>();
        private long _EmployeeId;

        public long EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }

        public SrvEmployeeRecordingDayList(long emplid)
        {
            EmployeeId = emplid;
        }
        public void Clear()
        {
            _list.Clear();
            _index.Clear();
        }
        public void AddEntities(List<EmployeeDayStateRecording> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (EmployeeDayStateRecording entity in entities)
                    AddEntity(entity); 
            }
        }
        public void AddEntity(EmployeeDayStateRecording entity)
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

        public int GetAdditionalChargesForWeekRange(DateTime monday, DateTime sunday)
        {
            int sumOfAdditionalCharges = 0;
            if (_index.Count > 0)
            {
                foreach (EmployeeDayStateRecording entity in _index.Values)
                {
                    if (DateTimeHelper.Between(entity.Date, monday, sunday))
                    {
                        sumOfAdditionalCharges += entity.SumOfAddHours;
                    }
                }
            }
            return sumOfAdditionalCharges;
        }
        public void CalculateWorkingSundayAndSaturday(DateTime fromdate, DateTime toDate,
            out int countSunday, out int countSaturday)
        {
            countSunday = 0;
            countSaturday = 0;
            if (_index.Count > 0)
            {
                foreach (EmployeeDayStateRecording entity in _index.Values)
                {
                    if (entity.Date.DayOfWeek == DayOfWeek.Sunday ||
                            entity.Date.DayOfWeek == DayOfWeek.Saturday)
                    {
                        if (DateTimeHelper.Between(entity.Date, fromdate, toDate))
                        {
                            if (entity.Date.DayOfWeek == DayOfWeek.Sunday)
                                countSunday++;
                            else
                                countSaturday++;
                        }
                    }
                }
            }
        }

        public int GetCountWorkingDayBefore(DateTime beforeDate)
        {

            DateTime date;
            EmployeeDayStateRecording entity = null;
            int i = 1;
            int count = 0;
            while (i < 7)
            {
                date = beforeDate.AddDays(-i);
                entity = this[date];

                if (entity != null && entity.WorkingHours > 0)
                {
                    count++;
                }
                else break;
                i++;
            }

            return count;

        }
        public List<EmployeeDayStateRecording> List
        {
            get { return _list; }
        }
        public EmployeeDayStateRecording this[DateTime date]
        {
            get
            {
                EmployeeDayStateRecording entity;
                _index.TryGetValue(date, out entity);
                return entity;
            }
        }
        
    }

    public class SrvEmployeeRecordingDayListLoader : SrvEmployeeRecordingDayList
    {

        protected EmployeeDayStateRecordingService Service
        {
            get { return ServerEnvironment.EmployeeDayStateRecordingService as EmployeeDayStateRecordingService; }
        }
        protected virtual void OnLoad(DateTime from, DateTime to)
        {
            List<EmployeeDayStateRecording> listEntities = 
                Service.GetEmployeeStates(EmployeeId, from, to);

            if (listEntities != null)
                AddEntities(listEntities);
        }
        private void _DoUpdate(EmployeeDayStateRecording entity)
        {
            Service.SaveOrUpdate(entity);
        }

        public SrvEmployeeRecordingDayListLoader(long emplid, DateTime from, DateTime to):base(emplid)
        {
            OnLoad(from, to);
        }
        public void Update(EmployeeDayStateRecording entity)
        {
            _DoUpdate(entity);
        }
    }

    public class SrvEmployeesRecordingDayList
    {
        Dictionary<long, SrvEmployeeRecordingDayList> _EmployeeToDayState = new Dictionary<long, SrvEmployeeRecordingDayList>();
        protected EmployeeDayStateRecordingService Service
        {
            get { return ServerEnvironment.EmployeeDayStateRecordingService as EmployeeDayStateRecordingService; }
        }
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
        public SrvEmployeesRecordingDayList(long[] ids, DateTime fromdate, DateTime todate)
        {
            FromDate = fromdate;
            ToDate = todate;
            InitCache(ids);
        }

        public SrvEmployeesRecordingDayList(long[] ids, DateTime fromdate)
        {
            FromDate = fromdate;
            InitCache(ids);
        }
        public SrvEmployeesRecordingDayList(long id, DateTime fromdate)
        {
            FromDate = fromdate;
            InitCache(new long[] { id });
        }
        private void InitCache(long[] ids)
        {
            List<EmployeeDayStateRecording> list = Service.GetEmployeesStateEntityByIds(ids, FromDate, ToDate);

            BuildDiction(list);
        }
        private void BuildDiction(List<EmployeeDayStateRecording> list)
        {
            _EmployeeToDayState.Clear();
            if (list == null || list.Count == 0) return;
            SrvEmployeeRecordingDayList dictionItem = null;
            foreach (EmployeeDayStateRecording entity in list)
            {
                if (!_EmployeeToDayState.TryGetValue(entity.EmployeeID, out dictionItem))
                {
                    dictionItem = CreateDictionItem(entity.EmployeeID);
                }
                dictionItem.AddEntity(entity);
            }
        }
        protected virtual SrvEmployeeRecordingDayList CreateDictionItem(long emplid)
        {
            SrvEmployeeRecordingDayList list = new SrvEmployeeRecordingDayList(emplid);
            _EmployeeToDayState[emplid] = list;
            return list;
        }

        protected virtual void _DoUpdate(EmployeeDayStateRecording entity)
        {
            if (entity.IsNew)
                Service.Save(entity);
            else
                Service.Update(entity);
        }
        protected virtual void _DoDelete(EmployeeDayStateRecording entity)
        {
            Service.Delete(entity);
        }

        public void LoadList(long id, DateTime fromdate)
        {
            LoadList(new long[] { id }, fromdate);
        }
        public void LoadList(long[] ids, DateTime fromdate)
        {
            FromDate = fromdate;
            InitCache(ids);
        }

        public SrvEmployeeRecordingDayList GetList(long emplid)
        {
            SrvEmployeeRecordingDayList list = null;
            _EmployeeToDayState.TryGetValue(emplid, out list);

            return list;
        }
        public int GetAdditionalChargesForWeekRange(long emplid, DateTime monday, DateTime sunday)
        {
            SrvEmployeeRecordingDayList list = GetList(emplid);

            int result = 0;

            if (list != null)
            {
                result = list.GetAdditionalChargesForWeekRange(monday, sunday);
            }

            return result;
        }

        private void DeleteEntity(EmployeeDayStateRecording entity)
        {
            _DoDelete(entity);
        }

        public void CompareAndSave(EmployeeDay day)
        {

            if (day == null)
                throw new ArgumentNullException();

            
            SrvEmployeeRecordingDayList list = GetList(day.EmployeeId);
            if (list == null)
            {
                list = CreateDictionItem(day.EmployeeId);
            }

            EmployeeDayStateRecording entity = list[day.Date];

            if (entity == null)
            {
                if (day.IsValidDay)
                {
                    entity = EmployeeDayProcessor.CreateRecordingEntity(day);
                    UpdateEntity(entity);
                    list.AddEntity(entity);
                }
            }
            else
            {
                if (day.IsValidDay)
                {
                    if (!EmployeeDayProcessor.IsEqual(entity, day))
                    {
                        EmployeeDayProcessor.AssignToRecording(entity, day);
                        UpdateEntity(entity);
                    }
                }
                else
                {
                    DeleteEntity(entity);
                }
            }
        }

        public void UpdateEntity(EmployeeDayStateRecording entity)
        {
            _DoUpdate(entity);
        }

        public void CalculateWorkingSundayAndSaturday(long emplid, DateTime fromdate, DateTime toDate,
            out int countSunday, out int countSaturday)
        {
            SrvEmployeeRecordingDayList list = GetList(emplid);
            countSunday = 0;
            countSaturday = 0;
            if (list != null)
            {
                list.CalculateWorkingSundayAndSaturday(fromdate, toDate, out countSunday, out countSaturday);
            }
        }

        public int GetCountWorkingDayBefore(long emplid, DateTime beforeDate)
        {
            SrvEmployeeRecordingDayList list = GetList(emplid);

            int result = 0;

            if (list != null)
            {
                result = list.GetCountWorkingDayBefore(beforeDate);
            }

            return result;
        }
    }

    public class EmployeeRecordingDayListEx : List<EmployeeDayStateRecording>
    {
        private long _employeeid;
        public long EmployeeId
        {
            get { return _employeeid; }
        }

        public EmployeeRecordingDayListEx(long emplid)
        {
            _employeeid = emplid;
        }
        public EmployeeRecordingDayListEx(long emplid, DateTime fromDate)
        {
            _employeeid = emplid;
            Load(fromDate, DateTimeSql.SmallDatetimeMax);
        }
        public EmployeeRecordingDayListEx(long emplid, DateTime fromDate, DateTime toDate)
        {
            _employeeid = emplid;
            Load(fromDate, toDate);
        }

        private void Load(DateTime fromDate, DateTime toDate)
        {
            EmployeeDayStateRecordingService service = ServerEnvironment.EmployeeDayStateRecordingService as EmployeeDayStateRecordingService;

            List<EmployeeDayStateRecording> list = service.GetEmployeeStates(EmployeeId, fromDate, toDate);

            if (list != null)
                AddRange(list);
        }


        public void RemoveFromDatabase(DateTime fromDate, DateTime toDate)
        {
            List<EmployeeDayStateRecording> entities = new List<EmployeeDayStateRecording>();
            List<EmployeeDayStateRecording> temp = new List<EmployeeDayStateRecording>();
            foreach (EmployeeDayStateRecording entity in this)
            {
                if (DateTimeHelper.Between(entity.Date, fromDate, toDate))
                    entities.Add(entity);
                else
                    temp.Add(entity);
            }

            EmployeeDayStateRecordingService service = ServerEnvironment.EmployeeDayStateRecordingService as EmployeeDayStateRecordingService;

            service.DeleteList(entities);

            Clear();
            AddRange(temp);
        }
    }
}
