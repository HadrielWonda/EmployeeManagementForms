using System;
using System.Collections.Generic;
using System.Collections;
using Baumax.Domain;
using System.ComponentModel;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;
using Baumax.Contract.HolydayClasses;
using Baumax.Contract.QueryResult;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace Baumax.Contract.Absences
{
    //public class EmployeeManager
    //{
    //    private Dictionary<long, EmployeeSource> m_EmplDict = new Dictionary<long, EmployeeSource>();
    //    private long m_StoreWorldID = 0;
    //    private Dictionary<long, List<EmployeeHolidaysInfo>> m_HolidaysInfo =null;
    //    private EmployeeSource m_SelectedEmployee;
    //    private BindingList<EmployeeSource> m_Bindings;
    //    private List<EmployeeRelation> m_EmployeesInAnorher = new List<EmployeeRelation>();
    //    private DictionListEmployeesContract contractIndexer;
    //    private YearAppearance m_Props;
    //    protected AbsencePlanningServices m_Services;
    //    protected AbsencePlanningQuery m_Query;

    //    public EmployeeManager(YearAppearance properties, AbsencePlanningServices services, AbsencePlanningQuery query)
    //    {
    //        m_Props = properties;
    //        m_Services = services;
    //        m_Query = query;
    //        Load();
    //        ModifyPrimaryParametres();
    //    }

    //    public YearAppearance Props
    //    {
    //        get { return m_Props; }
    //        set { m_Props = value; }
    //    }

    //    private void ModifyPrimaryParametres()
    //    {
    //        m_Bindings = new BindingList<EmployeeSource>();
    //        m_EmployeesInAnorher.Clear();

    //        List<long> employeeIDs = new List<long>();

    //        if (m_StoreWorldID != 0)
    //        {
    //            World world = m_Services.World.GetByStoreToWorldID(m_StoreWorldID);
    //            long world_id = world != null ? world.ID : 0;

    //            if (m_Query.Relations != null)
    //                foreach (EmployeeRelation relation in m_Query.Relations)
    //                    if (m_EmplDict.ContainsKey(relation.EmployeeID))
    //                        if (relation.WorldID == world_id && !employeeIDs.Contains(relation.EmployeeID))
    //                        {
    //                            m_Bindings.Add(m_EmplDict[relation.EmployeeID]);
    //                            employeeIDs.Add(relation.EmployeeID);
    //                        }
    //                        else
    //                            if (relation.WorldID.HasValue && relation.BeginTime >= m_Props.Begin && relation.EndTime <= m_Props.End)
    //                                m_EmployeesInAnorher.Add(relation);
    //        }
    //        else
    //            foreach (EmployeeSource employee in m_EmplDict.Values)
    //                if (!employeeIDs.Contains(employee.ID))
    //                {
    //                    m_Bindings.Add(employee);
    //                    employeeIDs.Add(employee.ID);
    //                }

    //        foreach (long id in employeeIDs)
    //        { 
    //            List<EmployeeContract> contracts = contractIndexer[id];
    //            if (contracts != null)
    //                foreach (EmployeeContract contract in contracts)
    //                {
    //                    if (contract.ContractBegin > m_Props.Begin)
    //                        m_EmployeesInAnorher.Add(new EmployeeRelation(m_Props.Begin, contract.ContractBegin.AddDays(-1),0, m_Props.StoreID , id, -100));
                        
    //                    if (contract.ContractEnd < m_Props.End)
    //                        m_EmployeesInAnorher.Add(new EmployeeRelation(contract.ContractEnd.AddDays(1), m_Props.End, 0, m_Props.StoreID, id, -100));
    //                }
    //        }
    //    }

    //    public EmployeeSource Employee
    //    {
    //        get { return m_SelectedEmployee; }
    //        set 
    //        {
    //            if (value != null)
    //                m_SelectedEmployee = value; 
    //        }
    //    }
    //    public long StoreWorldID
    //    {
    //        get { return m_StoreWorldID; }
    //        set 
    //        {
    //            if (m_StoreWorldID != value)
    //            {
    //                m_StoreWorldID = value;
    //                ModifyPrimaryParametres();
    //            }
    //        }
    //    }
	
    //    public long[] IdArray 
    //    {
    //        get 
    //        {
    //            long[] ids = new long[m_EmplDict.Keys.Count];
    //            m_EmplDict.Keys.CopyTo(ids, 0);
    //            return ids;
    //        }
    //    }
    //    public long EmployeeID
    //    {
    //        get { return m_SelectedEmployee.ID; }
    //        set 
    //        {
    //            if (m_EmplDict.ContainsKey(value))
    //                m_SelectedEmployee = m_EmplDict[value];
    //        }
    //    }
    //    public List<EmployeeHolidaysInfo> HolidaysInfo
    //    {
    //        get
    //        {
    //            if (m_SelectedEmployee != null)
    //                if (m_HolidaysInfo!=null && m_HolidaysInfo.ContainsKey(m_SelectedEmployee.ID))
    //                    return m_HolidaysInfo[m_SelectedEmployee.ID];
    //                else
    //                    return new List<EmployeeHolidaysInfo>(new EmployeeHolidaysInfo[] { m_SelectedEmployee.Entity});
    //            else
    //                return null;
    //        }
    //    }

    //    public List<EmployeeRelation> EmployeesInAnorherWorlds
    //    {
    //        get { return m_EmployeesInAnorher; }
    //    }

    //    public BindingList<EmployeeSource> Employees
    //    {
    //        get {  return m_Bindings; }
    //    }

    //    public void Load()
    //    {
    //        m_EmplDict.Clear();
            
    //        if (m_Query.Employees != null)
    //            foreach (EmployeeSource employee in m_Query.Employees)
    //                m_EmplDict.Add(employee.ID, employee);
            
    //        if (m_Query.Contracts != null)
    //            contractIndexer = new DictionListEmployeesContract(m_Query.Contracts);
    //    }

    //    public void ChangeEmployee(EmployeeSource employee, decimal value, bool isOldHolidays)
    //    {
    //        if (isOldHolidays)
    //            employee.OldHolidays = value;
    //        else
    //            employee.NewHolidays = value;

    //        m_Bindings.ResetItem(m_Bindings.IndexOf(employee));
    //    }

    //    public void SetHolidaysToDisplayedEmployees(decimal value, long employeeID, bool isDelete)
    //    {
    //        foreach(EmployeeSource employee in m_Bindings)
    //            if (employee.ID == employeeID)
    //            {
    //                employee.PlusPlanningDays(isDelete ? -value : value);
    //                m_Bindings.ResetItem (m_Bindings.IndexOf (employee));
    //                break;
    //            }
    //    }

    //    public void LoadHolidaysHistory()
    //    {
    //        List<EmployeeHolidaysInfo> holydays = m_Services.HolidaysInfo.GetByEmployeeID(m_SelectedEmployee.ID);
            
    //        if (holydays != null)
    //            m_HolidaysInfo[m_SelectedEmployee.ID] = holydays;
    //    }

    //    public void SaveChanges()
    //    {
    //        List<EmployeeHolidaysInfo> toSave = new List<EmployeeHolidaysInfo>();
    //        foreach (EmployeeSource employee in m_EmplDict.Values)
    //            if (employee.Action != Action.None)
    //                toSave.Add(employee.Entity);

    //        if (toSave.Count != 0)
    //            m_Services.HolidaysInfo.SaveOrUpdateList(toSave);
    //    }
    //}

    [Serializable ]
    public sealed class AbsenceTimeRange : IComparable<AbsenceTimeRange>, IEmployeeTimeRange
    {
        private long _ID = 0;
        private long _EmployeeID = 0;
        private short _Begin;
        private short _End;
        private long _AbsenceID = 0;
        [NonSerialized]
        private Absence _Absence;
        private DateTime _Date;
        private short _Time;
        
        private bool _planned = false;
        [NonSerialized]
        public bool Removed = false;

        public bool Planned
        {
            get { return _planned; }
            set { _planned = value; }
        }

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public decimal Days
        {
            get { return _Time / Utills.DayMinutes; }
        }
        public short Time
        {
            get { return _Time; }
            set { _Time = value; }
        }
        public short Begin
        {
            get { return _Begin; }
            set { _Begin = value; }
        }

        public short End
        {
            get { return _End; }
            set { _End = value; }
        }

        public long EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        public long AbsenceID
        {
            get { return _AbsenceID; }
            set { _AbsenceID = value; }
        }

        public Absence Absence
        {
            get { return _Absence; }
            set { _Absence = value; }
        }
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public int CompareTo(AbsenceTimeRange entity)
        {

            int i = EmployeeID.CompareTo(entity.EmployeeID);
            if (i == 0)
            {
                if ((i = Date.CompareTo(entity.Date)) == 0)
                    return Begin - entity.Begin;
                else return i;
            }
            else
                return i;
        }

        public void Assign(IEmployeeTimeRange entity)
        {
            EmployeeID = entity.EmployeeID;
            Begin= entity.Begin;
            End = entity.End;
            AbsenceID = entity.AbsenceID ;
            Absence = entity.Absence ;
            Date = entity.Date;
            Time = entity.Time;
        }

        public void AssignTo(IEmployeeTimeRange entity)
        {
            entity.EmployeeID = EmployeeID;
            entity.Begin = Begin;
            entity.End = End;
            entity.AbsenceID = AbsenceID;
            entity.Absence = Absence;
            entity.Date = Date;
            entity.Time = Time;
        }

        public AbsenceTimeRange()
        {
            Planned = true;
        }
        public AbsenceTimeRange(AbsenceTimePlanning entity)
        {
            Assign(entity);
            ID = entity.ID;
            Planned = true;

        }
        public AbsenceTimeRange(AbsenceTimeRecording entity)
        {
            Assign(entity);
            ID = entity.ID;
            Planned = false;
        }
    }


    #region AbsenceTimeRangeList
    [Serializable]
    public sealed class AbsenceTimeRangeList : List<AbsenceTimeRange>
    {
        public AbsenceTimeRangeList(int count):base(count)
        {

        }
        public AbsenceTimeRangeList()
        {

        }

        public bool DeleteByDate(DateTime date)
        {
            return DeleteByDateRange(date, date);
        }

        public List<AbsenceTimeRange> this[DateTime date]
        {
            get
            {
                return FindAll(delegate(AbsenceTimeRange atr) 
                {
                    return atr.Date == date;
                });
            }
        }

        public bool DeleteByDateRange(DateTime from_date, DateTime to_date)
        {
            bool bRemoved = false;
            if (Count > 0)
            {
                AbsenceTimeRange range;
                for (int i = Count-1; i >= 0; i--)
                {
                    range = this[i];
                    if (range.Planned && (from_date <= range.Date) && (range.Date <= to_date))
                    {
                        range.Removed = true;
                        RemoveAt(i);
                        bRemoved = true;
                    }
                }
               
            }
            return bRemoved;
        }

        public bool DeleteById(long id)
        {

            AbsenceTimeRange range;
            for (int i = Count - 1; i >= 0; i--)
            {
                range = this[i];
                if (range.Planned && range.ID == id)
                {
                    range.Removed = true;
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteAll()
        {
            AbsenceTimeRange range;
            bool b = false;
            for (int i = Count - 1; i >= 0; i--)
            {
                range = this[i];
                if (range.Planned)
                {
                    range.Removed = true;
                    RemoveAt(i);
                    b = true;
                }
            }

            return b;
        }

        public List<AbsenceTimeRange> GetNewEntities()
        {
            List<AbsenceTimeRange>  lst = null;


            foreach (AbsenceTimeRange range in this)
            {
                if (!range.Removed && range.ID <= 0)
                {
                    if (lst == null)
                        lst = new List<AbsenceTimeRange>();

                    lst.Add(range);
                }
            }
            return lst;
        }

        public int GetHolidaysSum()
        {
            int sum = 0;
            bool bExistsRemoved = false;
            foreach (AbsenceTimeRange range in this)
            {
                bExistsRemoved |= range.Removed;

                if (!range.Removed && range.Absence.AbsenceTypeID == AbsenceType.Holiday )
                {
                    sum += range.Time;
                }
            }

            if (bExistsRemoved)
                RemoveMarked();
            return sum;
        }

        public int GetPlannedHolidaysSum()
        {
            int sum = 0;
            bool bExistsRemoved = false;
            foreach (AbsenceTimeRange range in this)
            {
                bExistsRemoved |= range.Removed;
                if (!range.Removed && range.Planned && range.Absence.AbsenceTypeID == AbsenceType.Holiday)
                {
                    sum += range.Time;
                }
            }
            if (bExistsRemoved)
                RemoveMarked();
            return sum;
        }
        public int GetRecordedHolidaysSum()
        {
            int sum = 0;
            foreach (AbsenceTimeRange range in this)
            {
                if (!range.Removed && !range.Planned && range.Absence.AbsenceTypeID == AbsenceType.Holiday)
                {
                    sum += range.Time;
                }
            }
            return sum;
        }

        public List<AbsenceTimeRange> GetAbsencesByDates(List<DateTime> dates)
        {
            List<AbsenceTimeRange> result = new List<AbsenceTimeRange>();
            foreach (AbsenceTimeRange range in this)
            {
                if (dates.Contains(range.Date))
                {
                    result.Add(range);
                }
            }
            return result;
        }

        public List<AbsenceTimeRange> GetAbsencesByDateRange(DateTime from, DateTime to)
        {
            if (from > to) return null;

            List<AbsenceTimeRange> resultList = null;

            foreach (AbsenceTimeRange a in this)
            {
                if (from <= a.Date && a.Date <= to)
                {
                    if (resultList == null)
                        resultList = new List<AbsenceTimeRange>();

                    resultList.Add(a);
                }
            }

            return resultList;
        }

        public List<AbsenceTimeRange> DeleteAbsencesByDates(List<DateTime> dates)
        {

            List<AbsenceTimeRange> result = GetAbsencesByDates(dates);
            foreach (AbsenceTimeRange range in result)
            {
                range.Removed = true;
                Remove(range);
            }
            return result;
        }

        public List<long> GetIds()
        {
            List<long> ids = new List<long>();
            if (Count == 0) return ids;

            foreach (AbsenceTimeRange range in this)
            {
                if (!range.Removed && range.ID > 0)
                    ids.Add(range.ID);
            }

            return ids;
        }

        public bool RemoveMarked()
        {
            int iCount = Count;
            AbsenceTimeRange range;
            for (int i = Count - 1; i >= 0; i--)
            {
                range = this[i];
                if (range.Removed && range.Planned)
                {
                    RemoveAt(i);
                }
            }

            return iCount != Count;
        }
    }

    #endregion

    [Serializable ]
    public sealed class BzEmployeeHoliday
    {
        #region fields

        private EmployeeHolidaysInfo _entity = null;
        private string _employeefullname;
        [NonSerialized]
        private double _oldholidays = 0;
        [NonSerialized]
        private double _newholidays = 0;
        private double _takenholidays = 0;
        private double _plannedholidays = 0;
        private double _availableholidays = 0;
        [NonSerialized]
        private bool _isAustria = false;

        private long _homestoreid;
        [NonSerialized]
        private double _avgdayinweek = 0;
        private string m_WorldName = string.Empty;

        
	
        
        [NonSerialized]
        ListEmployeeContracts _contracts = null;

        [NonSerialized]
        AbsenceTimeRangeList _absences = null;
        [NonSerialized]
        ListEmployeeRelations _relations = null;
        [NonSerialized]
        List<EmployeeLongTimeAbsence> _longabsences = null;

        [NonSerialized]
        HolidayWeekInfo[] _weeks = null;

        [NonSerialized]
        HolidayMonthInfo[] _months = null;

        private long _HwgrId = 0;
        [NonSerialized]
        private string _HwgrName = String.Empty;

        #endregion

        public BzEmployeeHoliday(EmployeeHolidaysInfo entity, string employeename, long homestoreid, long? hwgrid)
        {
            _entity = entity;
            _employeefullname = employeename;
            _homestoreid = homestoreid;

            _HwgrId =  (hwgrid.HasValue)?hwgrid.Value : 0;
        }

        #region properties
        public string WorldName
        {
            get { return m_WorldName; }
            set { m_WorldName = value; }
        }
        public bool IsAustria
        {
            get { return _isAustria; }
            set { _isAustria = value; }
        }
        public EmployeeHolidaysInfo Entity
        {
            get { return _entity; }
        }


        public long EmployeeId
        {
            get { return Entity.EmployeeID; }
        }

        

        public string EmployeeName
        {
            get { return _employeefullname; }
            set { _employeefullname = value; }
        }
        public long HomeStoreId
        {
            get { return _homestoreid; }
            set { _homestoreid = value; }
        }
        public double AvgDayInWeek
        {
            get { return _avgdayinweek; }
            set { _avgdayinweek = value; }
        }
        public double OldHolidays
        {
            get
            {
                return _oldholidays;
            }
            set
            {
                if (!_isAustria )
                    _oldholidays = value;
            }
        }
        public double NewHolidays
        {
            get
            {
                return _newholidays;
            }
            set
            {
                if (!_isAustria)
                    _newholidays = value;
            }
        }
        // from time-recording table < Today date
        public double TakenHolidays
        {
            get
            {
                return _takenholidays;
            }
            set
            {
                _takenholidays = value;
            }
        }
        // from time-planning table >= Today date
        public double PlannedHolidays
        {
            get
            {
                return _plannedholidays;
            }
            set
            {
                _plannedholidays = value;
            }
        }


        public double UsedHolidays
        {
            get { return TakenHolidays + PlannedHolidays; }
        }

        public double SpareHolidaysExc
        {
            get 
            {
                if (IsAustria)
                    return AvailableHolidays;
                else
                    return AvailableHolidays - TakenHolidays; 
            }
        }
        public double SpareHolidaysInc
        {
            get 
            {
                if (IsAustria)
                    return AvailableHolidays - PlannedHolidays;
                else 
                    return AvailableHolidays - UsedHolidays; 
            }
        }
        public double AvailableHolidays
        {
            get
            {
                if (_isAustria)
                    return _availableholidays;
                else
                    return NewHolidays + OldHolidays;
            }
            set
            {
                if (_isAustria )
                    _availableholidays = value;
            }
        }

        public int Year
        {
            get { return Entity.Year; }
        }

        public HolidayWeekInfo[] Weeks
        {
            get { return _weeks; }
        }

        public long HwgrId
        {
            get { return _HwgrId; }
        }
        public string HwgrName
        {
            get { return _HwgrName; }
            set { _HwgrName = value; }
        }
        #endregion


        public HolidayWeekInfo GetWeek(int weeknumber)
        {
            if (weeknumber < 1 || weeknumber > _weeks.Length)
                throw new Exception("weeknumber= " + weeknumber);

            return _weeks[weeknumber - 1];
        }
        public HolidayMonthInfo GetMonth(int month)
        {
            if (month < 1 || month > 12)
                throw new Exception("month= " + month);

            return _months[month - 1];
        }
        public AbsenceTimeRangeList Absences
        {
            get { return _absences; }
        }
        public ListEmployeeContracts Contracts
        {
            get { return _contracts; }
        }
        public ListEmployeeRelations Relations
        {
            get { return _relations; }
        }
        public List<EmployeeLongTimeAbsence> LongAbsences
        {
            get { return _longabsences; }
        }

        private bool IsContainLongAbsence(DateTime date)
        {
            if (LongAbsences == null || LongAbsences.Count == 0) return false;

            foreach (EmployeeLongTimeAbsence a in LongAbsences)
                if (a.IsContainDate(date)) return true;
            return false;
        }
        public void BuildWeeks()
        {
            CopyPropertiesFromEntity();

            int countweek = DateTimeHelper.GetCountWeekInYear(Year);

            _weeks = new HolidayWeekInfo[countweek];

            for (int i = 0; i < countweek; i++)
            {
                _weeks[i] = new HolidayWeekInfo(this, i + 1, AvgDayInWeek);
            }
            _months = new HolidayMonthInfo[12];
            for (int i = 0; i < 12; i++)
            {
                _months[i] = new HolidayMonthInfo(this, i + 1);
            }

            if (_absences != null)
            {
                int weeknumber = 1;
                int takenHolidays = 0;
                int usedHolidays = 0;
                foreach (AbsenceTimeRange range in _absences)
                {
                    weeknumber = DateTimeHelper.GetWeekNumber(range.Date);
                    
                    Debug.Assert(weeknumber > 0 && weeknumber <= countweek);

                    
                    _weeks[weeknumber - 1].Add(range);

                    if (range.Absence.AbsenceTypeID == AbsenceType.Holiday)
                    {
                        if (!range.Planned)
                            takenHolidays += range.Time;
                        usedHolidays += range.Time;
                    }
                }

                this.PlannedHolidays = GetDays(usedHolidays - takenHolidays);
                this.TakenHolidays = GetDays(takenHolidays);

                Calculate();
            }

        }

        private int _freeze_calculation = 0;
        public void Calculate()
        {
            if (_freeze_calculation>0) return;


            foreach (HolidayMonthInfo minfo in _months)
            {
                minfo.NeedRecalculation = true;
                minfo.BuildValueAndColor();
            }

            if (Absences != null) Absences.RemoveMarked();
            int sum = 0;
            foreach (HolidayWeekInfo weekinfo in Weeks)
            {
                sum += weekinfo.CalculateHolidays();
            }
            PlannedHolidays = GetDays(sum)-TakenHolidays;
        }
        private double GetDays(int minutes)
        {
            double day = 1440;
            return Math.Round ((minutes / day), 1);
        }
        private void CopyPropertiesFromEntity()
        {
            if (Entity != null)
            {
                OldHolidays = Convert.ToDouble(Entity.OldHolidays);
                NewHolidays = Convert.ToDouble(Entity.NewHolidays);
            }
        }

        public bool IsModified()
        {
            return (_entity.IsNew) || (OldHolidays != Convert.ToDouble(Entity.OldHolidays)) ||
                (NewHolidays != Convert.ToDouble(Entity.NewHolidays));
        }

        public EmployeeHolidaysInfo UpdateEntity()
        {
            Entity.NewHolidays = Convert.ToDecimal (NewHolidays);
            Entity.OldHolidays = Convert.ToDecimal(OldHolidays);
            Entity.UsedHolidays = Convert.ToDecimal(AvailableHolidays);
            return Entity;
        }

        public void AddAbsences(AbsenceTimePlanning entity)
        {
            if (_absences == null)
                _absences = new AbsenceTimeRangeList();


            int hours = Contracts.GetContractHours(entity.Date);

            int time = (int)(((entity.End - entity.Begin) / (hours / AvgDayInWeek))*1440);

            entity.Time = (short)time;

            _absences.Add(new AbsenceTimeRange(entity));
        }
        public void AddAbsences(AbsenceTimeRecording entity)
        {
            if (_absences == null)
                _absences = new AbsenceTimeRangeList();
            int hours = Contracts.GetContractHours(entity.Date);

            int time = (int)(((entity.End - entity.Begin) / (hours / AvgDayInWeek)) * 1440);

            entity.Time = (short)time;

            _absences.Add(new AbsenceTimeRange(entity));
        }

        public EmployeeRelation GetRelationByDate(DateTime date)
        {
            return _relations.GetRelation(date);
        }
        public void AddRelation(EmployeeRelation entity)
        {
            if (_relations == null)
                _relations = new ListEmployeeRelations();
            _relations.Add(entity);
        }
        public void AddRelation(List<EmployeeRelation> entities)
        {
            if (entities != null)
            {
                if (_relations == null)
                    _relations = new ListEmployeeRelations();
                _relations.AddRange(entities);
            }
        }
        public EmployeeContract GetContractByDate(DateTime date)
        {
            return _contracts.GetContract (date);
        }
        public void AddContract(EmployeeContract entity)
        {
            if (_contracts == null)
                _contracts = new ListEmployeeContracts(EmployeeId);
            _contracts.Add(entity);
        }
        public void AddContract(List<EmployeeContract> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                if (_contracts == null)
                    _contracts = new ListEmployeeContracts(EmployeeId);
                _contracts.AddRange(entities);
            }
        }
        public EmployeeLongTimeAbsence GetLongTimeAbsence(DateTime date)
        {
            EmployeeLongTimeAbsence result = null;
            if (_longabsences != null && _longabsences.Count > 0)
            {
                for (int i = 0; i < _longabsences.Count; i++)
                {
                    if (_longabsences[i].IsContainDate(date))
                    {
                        result = _longabsences[i];
                        break;
                    }
                }
            }
            return result;
        }

        public void AddLongAbsence(EmployeeLongTimeAbsence entity)
        {
            if (_longabsences == null)
                _longabsences = new List<EmployeeLongTimeAbsence> ();
            _longabsences.Add(entity);
        }

        private void __SetAbsence(AbsenceTimeRange absence)
        {
            if (absence == null) return;

            if (Absences == null)
            {
                _absences = new AbsenceTimeRangeList();
            }
            __DeleteAbsenceByDate(absence.Date);
            Absences.Add(absence);

            Weeks[DateTimeHelper.GetWeekNumber(absence.Date) - 1].Add(absence);
            _months[DateTimeHelper.GetMonthNumberByDate(absence.Date) - 1].NeedRecalculation = true;
        }
        public void SetAbsence(List<AbsenceTimeRange> absences)
        {
            if (absences == null || absences.Count == 0) return;

            absences.Sort();


            foreach (AbsenceTimeRange a in absences)
            {
                __SetAbsence(a);
            }

            
            Calculate();

        }
        public void SetAbsence(AbsenceTimeRange absence)
        {
            __SetAbsence(absence);
            Calculate();

        }


        private bool __DeleteAbsenceByDate(DateTime date)
        {
            Weeks[DateTimeHelper.GetWeekNumber(date) - 1].DeleteAbsence(date);
            bool wasDeleted = false;
            if (Absences != null)
                wasDeleted = Absences.DeleteByDate(date);
            if (wasDeleted )
                _months[DateTimeHelper.GetMonthNumberByDate(date) - 1].NeedRecalculation = true;
            return wasDeleted ;
        }
        public bool DeleteAbsences(List<DateTime> dates)
        {
            bool wasDeleted = false;
            if (Absences != null && dates != null)
            {
                _freeze_calculation++;
                foreach (DateTime date in dates)
                    wasDeleted |= __DeleteAbsenceByDate(date);
                _freeze_calculation--;
                if (wasDeleted )
                    Calculate();
            }
            return wasDeleted;
        }
        public bool DeleteAbsences(DateTime date)
        {
            _freeze_calculation++;
            bool wasDeleted = __DeleteAbsenceByDate(date);
            _freeze_calculation--;
            if (wasDeleted)
                Calculate();
            return wasDeleted;
        }
        public bool DeleteAbsences(DateTime from_date, DateTime to_date)
        {
            bool wasDeleted = false;
            _freeze_calculation++;
            DateTime date = from_date;
            while (date <= to_date)
            {
                wasDeleted |= __DeleteAbsenceByDate(date);
                date = date.AddDays(1);
            }
            _freeze_calculation--;
            if (wasDeleted)
                Calculate();

            return wasDeleted;

        }
        //public void ResetMonthsState()
        //{
        //    foreach (HolidayMonthInfo m in _months)
        //        m.NeedRecalculation = true;
        //}
        public bool DeleteMonthAbsences(int monthnumber)
        {
            _freeze_calculation++;


            DateTime from = new DateTime (Year , monthnumber, 1);
            DateTime to = new DateTime(Year, monthnumber, DateTime.DaysInMonth(Year, monthnumber));

            bool wasDeleted = DeleteAbsences(from, to);
            _freeze_calculation--;
            if (wasDeleted)
            {

                Calculate();
            }

            return wasDeleted;
        }
        public bool DeleteMonthAbsences(int[] monthnumbers)
        {
            bool wasDeleted = false;
            if (monthnumbers != null && monthnumbers.Length > 0)
            {
                _freeze_calculation++;

                foreach (int i in monthnumbers)
                    wasDeleted |= DeleteMonthAbsences(i);

                _freeze_calculation--;
                if (wasDeleted)
                    Calculate();
            }
            return wasDeleted;
        }
        public bool DeleteWeekAbsences(int weeknumber)
        {
            _freeze_calculation++;
            DateTime from = Weeks[weeknumber - 1].MondayDate;
            DateTime to = Weeks[weeknumber - 1].SundayDate;

            bool wasDeleted = DeleteAbsences(from, to);
            _freeze_calculation--;
            if (wasDeleted )
                Calculate();
            
            return wasDeleted;
        }
        public bool DeleteWeekAbsences(int[] weeknumbers)
        {
            _freeze_calculation++;
            bool wasDeleted = false;
            if (weeknumbers != null && weeknumbers.Length > 0)
            {
                foreach (int i in weeknumbers)
                    wasDeleted |= DeleteWeekAbsences(i);
            }
            _freeze_calculation--;
            if (wasDeleted )
                Calculate();
            return wasDeleted;
        }

        public int GetAvgWorkingHourADay(DateTime date)
        {
            return Utills.AvgWorkingHoursPerDay(Contracts.GetContractHours(date), AvgDayInWeek);
            //int contract = Contracts.GetContractHours(date);

            //return (int)(contract / AvgDayInWeek);
        }

        public short GetAbsenceTimeAsDay(Absence absence, DateTime date, int time)
        {
            return Utills.GetEntityTime(absence, time, Contracts.GetContractHours(date), AvgDayInWeek);

            //double avg_hours_per_day = GetAvgWorkingHourADay(date);
            
            //if (avg_hours_per_day == 0)
            //    return (short)0;
            //else 
            //    return Convert.ToInt16((time / avg_hours_per_day * 1440));
        }


        public void CheckDates(List<DateTime> dates)
        {
            DateTime date;
            for (int i = dates.Count-1; i >=0; i--)
            {
                date = dates[i];
                if (Contracts != null && Contracts.IsExistsContract(date))
                {
                    if (Relations != null && Relations.IsWorkInHomeStore(date, HomeStoreId))
                    {
                        if (LongAbsences == null || !IsContainLongAbsence(date))
                        continue;
                    }
                }

                dates.RemoveAt(i);
            }
        }


        public void FillTotalSums(double[] array_weeks, double[] array_months)
        {
            foreach (HolidayWeekInfo w in _weeks)
                array_weeks[w.WeekNumber - 1] += w.CountHolidayMinutes;
            foreach (HolidayMonthInfo m in _months)
                array_months[m.MonthNumber - 1] += m.CountHolidayMinutes;
        }
    }


    public interface IHolidayInfo 
    {
        int GetColor();
        string Value { get; }
        bool IsHoliday();
    }


    public sealed class HolidayWeekInfo : IHolidayInfo
    {
        #region fields

        private BzEmployeeHoliday _owner = null;
        private int _weeknumber = 1;
        private int _monthNumber = 1;
        private DateTime _mondayDate;
        private DateTime _sundayDate;
        private int _countholidayminutes = 0;
        AbsenceTimeRangeList _absences = null;
        private int _contracthoursperweek = 0;
        private List<EmployeeRelation> _relations = null;
        private List<EmployeeLongTimeAbsence> _longabsences = null;
        private double _avgdaysperweek = 0;
        private bool _isHolidays = false;

        #endregion

        private bool _lock_calculation = false;

        public HolidayWeekInfo(BzEmployeeHoliday owner, int weeknumber, double avgdaysperweek)
        {
            Owner = owner;
            WeekNumber = weeknumber;
            _avgdaysperweek = avgdaysperweek;
            DateTimeHelper.GetDateRangeByWeekNumber(WeekNumber, Owner.Year, out _mondayDate, out _sundayDate);

            _monthNumber = DateTimeHelper.GetMonthNumberByWeekDateRange(MondayDate, SundayDate);

            ContractHoursPerWeek = Owner.Contracts.GetContractHoursByWeekRange(MondayDate, SundayDate);

            _relations = new List<EmployeeRelation>(1);

            DateTime date = MondayDate;
            EmployeeRelation relation = null;
            while( date <= SundayDate)
            {
                relation = null;
                if (Owner.Relations != null)
                    relation = Owner.Relations.GetRelation(date);

                if (relation != null)
                {
                    _relations.Add(relation);
                    if (relation.IsContainDate(SundayDate)) break;
                    date = relation.EndTime.AddDays(1);
                }
                else 
                    date = date.AddDays(1);
            }

            ReCheckLongAbsence();
        }

        #region properties


        public bool IsExistsAbsences
        {
            get { return (_absences != null) && (_absences.Count > 0); }
        }
        public bool IsExistsRelation
        {
            get { return _relations.Count > 0; }
        }
        public bool IsExistsLongAbsence
        {
            get { return (_longabsences != null) && (_longabsences.Count > 0); }
        }

        public int ContractHoursPerWeek
        {
            get { return _contracthoursperweek; }
            set { _contracthoursperweek = value; }
        }
        public double AvgDayPerWeek
        {
            get { return _avgdaysperweek; }
        }
        public DateTime MondayDate
        {
            get { return _mondayDate; }
        }
        public DateTime SundayDate
        {
            get { return _sundayDate; }
        }
        public int WeekNumber
        {
            get { return _weeknumber; }
            private set { _weeknumber = value; }
        }
        public int MonthNumber
        {
            get { return _weeknumber; }
            private set { _weeknumber = value; }
        }
        public BzEmployeeHoliday Owner
        {
            get { return _owner; }
            private set { _owner = value; }
        }
        public AbsenceTimeRangeList Absences
        {
            get { return _absences; }
        }

        public int CountHolidayMinutes
        {
            get { return _countholidayminutes; }
            set { _countholidayminutes = value; }
        }

        #endregion

        public bool IsDisableWeek()
        {
            return ContractHoursPerWeek <= 0 || !IsExistsRelation;
        }

        public bool IsDisableDay(DateTime date)
        {
            if (_relations == null || _relations.Count == 0) return true;

            return !Owner.Relations.IsExistsRelation(date);
        }
        public void Add(AbsenceTimeRange absence)
        {
            if (_absences == null)
                _absences = new AbsenceTimeRangeList();
            _absences.Add(absence);
            _valueexists = false;
        }

        public void ReCheckLongAbsence()
        {
            if (_longabsences != null) _longabsences.Clear();
            if (Owner.LongAbsences != null && Owner.LongAbsences.Count > 0)
            {
                foreach (EmployeeLongTimeAbsence labsence in Owner.LongAbsences)
                {
                    if (DateTimeHelper.IsIntersectExc(MondayDate, SundayDate, labsence.BeginTime, labsence.EndTime))
                    {
                        if (_longabsences == null) _longabsences = new List<EmployeeLongTimeAbsence>(1);

                        _longabsences.Add(labsence);
                    }
                }
            }
        }

        public bool IsIntersectWithLongAbsence(DateTime date)
        {
            if (_longabsences == null || _longabsences.Count == 0) return false;

            foreach (EmployeeLongTimeAbsence absence in _longabsences)
            {
                if (absence.IsContainDate(date)) return true;
            }

            return false;
        }

        public EmployeeLongTimeAbsence GetEmployeeLongTimeAbsence(DateTime date)
        {
            EmployeeLongTimeAbsence resultAbsence = null;
            if (_longabsences != null && _longabsences.Count > 0)
            {
                foreach (EmployeeLongTimeAbsence absence in _longabsences)
                {
                    if (absence.IsContainDate(date))
                    {
                        resultAbsence = absence;
                        break;
                    }
                }
            }
            return resultAbsence;

        }

        public List<AbsenceTimeRange> GetAbsencesByDate(DateTime date)
        {
            List<AbsenceTimeRange> resultList = null;

            if (Absences != null && Absences.Count > 0)
            {
                foreach (AbsenceTimeRange a in Absences)
                    if (a.Date == date)
                    {
                        if (resultList == null) resultList = new List<AbsenceTimeRange>();
                        resultList.Add(a);
                    }
            }
            return resultList;
        }
        public bool IsContainDate(DateTime date)
        {
            return (MondayDate <= date) && (date <= SundayDate);
        }

        public int CalculateHolidays()
        {
            if (_lock_calculation) return 0;

            CountHolidayMinutes = 0;

            if (Absences != null && Absences.Count > 0)
            {
                CountHolidayMinutes = Absences.GetHolidaysSum();
            }
            return CountHolidayMinutes;
        }

        

        public void DeleteAbsence(DateTime date)
        {
            if (IsContainDate(date))
            {
                if (Absences != null)
                {
                    Absences.DeleteByDate(date);
                }
                _valueexists = false;
            }
        }

        public bool DeleteAll()
        {
            bool bExists = false;
            if (Absences != null && Absences.Count> 0)
            {
                int iCount = Absences.Count;
                Absences.DeleteAll();
                _valueexists = false;
                bExists = iCount != Absences.Count;
            }
            CalculateHolidays();
            return bExists;
        }

        public bool IsHoliday()
        {
            return _isHolidays;
        }

        public void BuildColorAndValue()
        {
            _valueexists = true;
            _value = String.Empty;
            if (!IsExistsAbsences && !IsExistsLongAbsence)
            {
                _WeekColor = Color.White;
               
                return;
            }

            Dictionary<long, __AbsenceSum> _absenceSums = new Dictionary<long, __AbsenceSum>();


            if (_absences != null)
            {
                __AbsenceSum sum = null;
                foreach (AbsenceTimeRange a in _absences)
                {
                    if (!a.Removed)
                    {
                        if (!_absenceSums.TryGetValue(a.AbsenceID, out sum))
                        {
                            sum = new __AbsenceSum();
                            sum.Absence = a.Absence;
                            _absenceSums[sum.ID] = sum;
                        }
                        sum.AddAbsence(a);
                        //sum.Sum += a.Time;
                    }
                }
                List<__AbsenceSum> lst = new List<__AbsenceSum>(_absenceSums.Values);
                lst.Sort();

                _WeekColor = Color.FromArgb(lst[0].Color);
                StringBuilder sb = new StringBuilder(10);
                foreach (__AbsenceSum var in lst)
                {
                    // _isHolidays = _isHolidays || var.Absence.AbsenceTypeID == AbsenceType.Holiday;
                    if (sb.Length > 0) sb.Append(" / ");
                    sb.Append(var.AsString());//(int)(ContractHoursPerWeek / AvgDayPerWeek)));
                }
                _value = sb.ToString();
            }
            else
            {
                if (_longabsences != null)
                {
                    StringBuilder sb = new StringBuilder(10);
                    foreach (EmployeeLongTimeAbsence a in _longabsences)
                    {
                        _WeekColor = Color.FromArgb (a.Absence.Color);
                        if (sb.Length > 0) sb.Append(" / ");
                        //sb.Append('(').Append (a.Absence.CharID).Append (')');
                        sb.Append(a.Absence.CharID);
                    }
                    _value = sb.ToString();
                }
            }

        }

        private Color _WeekColor = Color.White;
        private string _value = String.Empty;
        public bool _valueexists = false;
        public Color WeekColor
        {
            get
            {
                if (!_valueexists) BuildColorAndValue();
                return _WeekColor;
            }
        }

        public string Value
        {
            get 
            {
                if (!_valueexists) BuildColorAndValue();
                return _value; 
            }
        }
        public void FillDaysSum(double[] sums_array)
        {
            if (CountHolidayMinutes > 0 && Absences != null && Absences.Count > 0 )
            {
                foreach (AbsenceTimeRange a in Absences)
                    if (a.Absence.AbsenceTypeID == AbsenceType.Holiday)
                        sums_array[(int)a.Date.DayOfWeek] += a.Time; 
            }
        }

        public int GetColor()
        {
            return IsDisableWeek() ? 0 : WeekColor.ToArgb();   
        }
    }

    internal  class __AbsenceSum : IComparer<__AbsenceSum>, IComparable<__AbsenceSum>
    {
        public Absence Absence;
        public LongTimeAbsence LongAbsence;
        public long ID
        {
            get 
            {
                if (Absence != null)
                    return Absence.ID;
                else
                    return -LongAbsence.ID;
            }
        }
        public double Sum;
        public string AsString()
        {
            double d = Math.Round(Sum / 1440, 1);

            if (Absence != null)
                return String.Format("{0} {1}", d, Absence.CharID);
            else
                return String.Format("{0} {1}", d, LongAbsence.CharID);
        }
        public int Color
        {
            get
            {
                return (Absence != null)?Absence.Color:LongAbsence.Color;
            }
        }
        public int Compare(__AbsenceSum a, __AbsenceSum b)
        {
            return a.Sum.CompareTo(b.Sum);
        }
        public int CompareTo(__AbsenceSum a)
        {
            return Compare(this, a);
        }

        public void AddAbsence(AbsenceTimeRange range)
        {
            if (ID == range.AbsenceID)
            {
                if (range.Absence != null)
                {
                    if (range.Absence.CountAsOneDay)
                        Sum += 1440;
                    else
                        Sum += range.Time;
                }
            }
        }
    }

    public sealed class HolidayMonthInfo : IHolidayInfo
    {
        private BzEmployeeHoliday _entity = null;
        private int _month = 1;
        private bool _isHoliday = false;
        
        private DateTime _beginMonthDate;
        private DateTime _endMonthDate;

        private Color _color;
        private string _value;
        private bool _disableMonth = false;
        private int _countholidayminutes;

        private bool _NeedRecalculation = false;

        public int MonthNumber
        {
            get { return _month; }
            set { _month = value; }
        }
        public bool NeedRecalculation
        {
            get { return _NeedRecalculation; }
            set { _NeedRecalculation = value; }
        }

        public int CountHolidayMinutes
        {
            get 
            {
                if (NeedRecalculation)
                    BuildValueAndColor();
                return _countholidayminutes; 
            }
            set { _countholidayminutes = value; }
        }

        public HolidayMonthInfo(BzEmployeeHoliday entity, int month)
        {
            _month = month;
            _entity = entity;

            DateTimeHelper.GetDateRangeByMonthNumber(_entity.Year, _month, out _beginMonthDate, out _endMonthDate);

            if (_entity.Relations == null || _entity.Relations.Count == 0) _disableMonth = true;
            else
            {

                _disableMonth = !(_entity.Relations.IsExistsRelation(_beginMonthDate) ||
                    _entity.Relations.IsExistsRelation(_endMonthDate));
            }
            NeedRecalculation = true;
            BuildValueAndColor();

        }


        public Color MonthColor
        {
            get 
            {
                if (NeedRecalculation)
                    BuildValueAndColor();
                return _color; 
            }
        }
        public string Value
        {
            get
            {
                if (NeedRecalculation)
                    BuildValueAndColor();
                return _value;
            }
        }
        public bool DisableMonth
        {
            get { return _disableMonth; }
        }

        public bool IsHoliday()
        {
            return _isHoliday;
        }

        public void BuildValueAndColor()
        {
            if (NeedRecalculation)
            {
                _countholidayminutes = 0;
                _value = String.Empty;
                if (DisableMonth) return;


                List<AbsenceTimeRange> absences = (_entity.Absences != null) ? _entity.Absences.GetAbsencesByDateRange(_beginMonthDate, _endMonthDate) : null;
                if (absences == null || absences.Count == 0)
                {
                    _color = Color.White;
                }

                if (absences != null || _entity.LongAbsences != null)
                {

                    Dictionary<long, __AbsenceSum> _absenceSums = new Dictionary<long, __AbsenceSum>();

                    __AbsenceSum sum = null;
                    if (absences != null)
                    {

                        foreach (AbsenceTimeRange a in absences)
                        {
                            if (!a.Removed)
                            {
                                if (a.Absence.AbsenceTypeID == AbsenceType.Holiday)
                                    _countholidayminutes += a.Time;

                                if (!_absenceSums.TryGetValue(a.AbsenceID, out sum))
                                {
                                    sum = new __AbsenceSum();
                                    sum.Absence = a.Absence;
                                    _absenceSums[sum.ID] = sum;
                                }
                                sum.AddAbsence(a);
                                //sum.Sum += a.Time;
                            }
                        }
                    }
                    if (_entity.LongAbsences != null)
                    {
                        foreach (EmployeeLongTimeAbsence a in _entity.LongAbsences)
                        {
                            if (DateTimeHelper.IsIntersectExc(_beginMonthDate, _endMonthDate, a.BeginTime, a.EndTime))
                            {
                                int days = DateTimeHelper.SubstractDateRange(_beginMonthDate, _endMonthDate, a.BeginTime, a.EndTime);
                                if (!_absenceSums.TryGetValue(-a.Absence.ID, out sum))
                                {
                                    sum = new __AbsenceSum();
                                    sum.LongAbsence = a.Absence;
                                    _absenceSums[-sum.ID] = sum;
                                }
                                sum.Sum += days * 1440;
                            }
                        }
                    }
                    
                    List<__AbsenceSum> lst = new List<__AbsenceSum>(_absenceSums.Values);
                    lst.Sort();

                    if (lst.Count > 0)
                    {
                        _color = Color.FromArgb(lst[0].Color);


                        StringBuilder sb = new StringBuilder(10);
                        foreach (__AbsenceSum var in lst)
                        {
                           // _isHoliday = _isHoliday || var.Absence.AbsenceTypeID == AbsenceType.Holiday;
                            if (sb.Length > 0) sb.Append(",");
                            sb.Append(var.AsString());
                        }
                        _value = sb.ToString();
                    }
                }
            }
            NeedRecalculation = false;
        }

        public int GetColor()
        {
            return MonthColor.ToArgb();
        }
    }

}
