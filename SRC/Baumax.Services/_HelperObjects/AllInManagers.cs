using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract;
using System.Diagnostics;
using System.Collections;
using Baumax.AppServer.Environment;

namespace Baumax.Services._HelperObjects
{
    public class ListEmployeeAllIn : IList<EmployeeAllIn>
    {
        private List<EmployeeAllIn> _list = new List<EmployeeAllIn>();
        private EmployeeAllInService _service = null;
        private long _employeeId = 0;

        #region interface 
        
        public EmployeeAllIn this[int index] 
        { 
            get{ return _list[index]; }
            set { _list[index] = value;} 
        }

        public int IndexOf(EmployeeAllIn item)
        {
            return _list.IndexOf(item);
        }


        public void Insert(int index, EmployeeAllIn item)
        {
            _list.Insert(index, item);
        }


        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }


        public int Count { get { return _list.Count; } }

        public bool IsReadOnly { get { return false; } }


        public void Add(EmployeeAllIn item)
        {
            _list.Add(item);
        }

        public void Clear() { _list.Clear(); }

        public bool Contains(EmployeeAllIn item) { return _list.Contains(item); }

        public void CopyTo(EmployeeAllIn[] array, int arrayIndex) { _list.CopyTo(array, arrayIndex); }
        public bool Remove(EmployeeAllIn item) { return _list.Remove(item); }

         
        public IEnumerator<EmployeeAllIn> GetEnumerator() { return (IEnumerator<EmployeeAllIn>)_list.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return (IEnumerator)_list.GetEnumerator(); }

        #endregion


        public long EmployeeId
        {
            get { return _employeeId; }
            set 
            {
                if (_employeeId != value)
                {
                    Clear();
                    _employeeId = value;
                }
            }
        }

        #region  Load

        public ListEmployeeAllIn()
        {
            _service = ServerEnvironment.EmployeeService.EmployeeAllInService as EmployeeAllInService; ;
        }

        public ListEmployeeAllIn(long emplid):this()
        {
            EmployeeId = emplid;
            Load();
        }

        public void Load()
        {
            LoadEntities();
        }

        private void LoadEntities()
        {
            Clear();

            if (_service == null)
                throw new ArgumentNullException ();
            if (_employeeId <= 0)
                throw new ArgumentException ("AllInManager employeeid <= 0");
            

            List<EmployeeAllIn> lst = _service.GetEntitiesByEmployee(EmployeeId, DateTimeSql.SmallDatetimeMin , DateTimeSql.SmallDatetimeMax);

            if (lst != null && lst.Count > 0)
            {
                _list = lst;
                Sort();
            }
        }

        #endregion

        public void SetEmployee(long emplid)
        {
            EmployeeId = emplid;
            Load();
        }

        #region Modified entity

        public void Sort()
        {
            //_list.Sort(new ComparerAllIn());
            _list.Sort();
            DebugCheck();
        }

        [Conditional("DEBUG")]
        public void DebugCheck()
        {
#if DEBUG
            if (Count > 0)
            {
                DateTime date = this[0].EndTime.AddDays (1);

                for (int i = 1; i < _list.Count; i++)
                {
                    if (this[i].BeginTime != date)
                        throw new Exception();

                    date = this[i].EndTime.AddDays(1);
                }
            }
#endif 
            
        }

        public bool Insert(DateTime date, bool AllIn)
        {
            EmployeeAllIn item = null;

            for (int i = 0; i < Count; i++)
            {
                item = this[i];
                if (item.IsContainDate(date))
                {
                    if (item.AllIn == AllIn)
                    {
                        if (item.EndTime != DateTimeSql.SmallDatetimeMax)
                        {
                            item.EndTime = DateTimeSql.SmallDatetimeMax;
                            item.EntityState = 1;
                        }
                        for (int j = i + 1; j < Count; j++)
                        {
                            this[j].EntityState = 2;//deleted
                        }
                        break;
                    }

                    item.EndTime = date.AddDays(-1);
                    item.EntityState = 1;//modified
                    if (!item.IsValid())
                        item.EntityState = 2;
                    for (int j = i + 1; j < Count; j++)
                    {
                        this[j].EntityState = 2;//deleted
                    }

                    this.Add(new EmployeeAllIn(EmployeeId, date, DateTimeSql.SmallDatetimeMax, AllIn));

                    break;
                }
            }
            bool bModified = false;
            for (int i = Count - 1; i >= 0; i--)
            {
                if (this[i].EntityState == 2)
                {
                    bModified = true;
                    RemoveEntity(this[i]);
                    this.RemoveAt(i);
                }
                else
                {
                    if (this[i].EntityState == 1 || this[i].IsNew)
                    {
                        UpdateEntity(this[i]);
                        this[i].EntityState = 0;
                        bModified = true;
                    }
                }
            }
            return bModified;
        }

        private void UpdateEntity(EmployeeAllIn employeeAllIn)
        {
            if (_service != null)
                _service.SaveOrUpdate(employeeAllIn);
        }

        private void RemoveEntity(EmployeeAllIn employeeAllIn)
        {
            if (_service != null && employeeAllIn != null && !employeeAllIn.IsNew )
                _service.DeleteByID(employeeAllIn.ID);

        }

        #endregion


        public bool GetAllIn(DateTime date)
        {
            foreach (EmployeeAllIn entity in _list)
            {
                if (entity.IsContainDate(date))
                    return entity.AllIn;
            }

            return false;
        }
        public bool GetAllIn(DateTime beginDate, DateTime endDate)
        {
            foreach (EmployeeAllIn entity in _list)
            {
                if (DateTimeHelper.IsIntersectExc (beginDate, endDate, entity.BeginTime, entity.EndTime ))
                    return entity.AllIn;
            }

            return false;
        }
    }

    public class CacheEmployeesAllIn
    {
        private Dictionary<long, ListEmployeeAllIn> _diction = new Dictionary<long, ListEmployeeAllIn>();

        private EmployeeAllInService _service = null;
        private ListEmployeeAllIn _lastUsed = null;

        public CacheEmployeesAllIn()
        {
            _service = ServerEnvironment.EmployeeService.EmployeeAllInService as EmployeeAllInService;
        }

        public CacheEmployeesAllIn(long emplid):this()
        {
            LoadByEmployee(emplid);
        }

        private void FillDiction(List<EmployeeAllIn> lst)
        {
            if (lst != null && lst.Count > 0)
            {
                ListEmployeeAllIn lastUsed = null;
                foreach (EmployeeAllIn entity in lst)
                {
                    ListEmployeeAllIn manager = null;

                    if (lastUsed != null && lastUsed.EmployeeId == entity.EmployeeID)
                    {
                        manager = lastUsed;
                    }
                    else
                    {
                        lastUsed = null;
                        if (!_diction.TryGetValue(entity.EmployeeID, out manager))
                        {
                            manager = new ListEmployeeAllIn();
                            manager.EmployeeId = entity.EmployeeID;
                            _diction[manager.EmployeeId] = manager;
                        }
                    }
                    manager.Add(entity);
                    lastUsed = manager;
                }
            }
        }

        #region Load entities

        public CacheEmployeesAllIn LoadAll()
        {
            if (_service != null)
            {
                List<EmployeeAllIn> lst = _service.AllInDao.GetAllEntitiesSorted();
                FillDiction(lst);
            }
            return this;
        }

        public CacheEmployeesAllIn LoadByStore(long storeid)
        {
            if (_service != null)
            {
                List<EmployeeAllIn> lst = _service.GetEntitiesByStore(storeid, DateTimeSql.SmallDatetimeMin, DateTimeSql.SmallDatetimeMax);
                FillDiction(lst);
            }
            return this;
        }

        public CacheEmployeesAllIn LoadByEmployee(long emplid)
        {
            if (_service != null)
            {
                ListEmployeeAllIn manager = null;
                if (!_diction.TryGetValue(emplid, out manager))
                {
                    manager = new ListEmployeeAllIn();

                    manager.SetEmployee(emplid);
                    _diction[emplid] = manager;
                }
            }
            return this;
        }



        public CacheEmployeesAllIn LoadByStoreRelation(long storeid)
        {
            if (_service != null)
            {
                List<EmployeeAllIn> lst = _service.GetEntitiesByStoreAndRelation(storeid, DateTimeSql.SmallDatetimeMin, DateTimeSql.SmallDatetimeMax);
                FillDiction(lst);
            }
            return this;
        }

        public CacheEmployeesAllIn LoadByCountryRelation(long countryid)
        {
            if (_service != null)
            {
                List<EmployeeAllIn> lst = _service.GetEntitiesByCountry(countryid, DateTimeSql.SmallDatetimeMin, DateTimeSql.SmallDatetimeMax);
                FillDiction(lst);
            }
            return this;
        }


        #endregion

        public bool GetAllIn(long emplid, DateTime date)
        {
            ListEmployeeAllIn manager = GetManager(emplid); ;

            bool bAllIn = false;
            if (manager != null)
            {
                bAllIn = manager.GetAllIn(date);
            }
            return bAllIn;
        }
        public bool GetAllIn(long emplid, DateTime monday, DateTime sunday)
        {
            Debug.Assert((monday.DayOfWeek == DayOfWeek.Monday) && 
                (sunday.DayOfWeek == DayOfWeek.Sunday));


            ListEmployeeAllIn manager = GetManager(emplid );

            bool bAllIn = false;
            if (manager != null)
            {
                bAllIn = manager.GetAllIn(monday, sunday);
            }
            return bAllIn;
        }

        public ListEmployeeAllIn GetManager(long emplid)
        {
            ListEmployeeAllIn manager = null;
            if (_lastUsed != null && _lastUsed.EmployeeId == emplid)
            {
                manager = _lastUsed;
            }
            else 
                _diction.TryGetValue(emplid, out manager);
            if (manager != null)
                _lastUsed = manager;

            return manager;
        }
    }
}
