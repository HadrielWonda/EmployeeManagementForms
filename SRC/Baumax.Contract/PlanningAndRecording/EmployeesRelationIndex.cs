using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.Interfaces;
using System.Collections;

namespace Baumax.Contract.TimePlanning
{
    public class DictionListEmployeeRelations
    {
        protected Dictionary<long, ListEmployeeRelations> _diction = new Dictionary<long, ListEmployeeRelations>();
        protected ListEmployeeRelations _lstUsing = null;
        protected long _lastId = 0;

        public DictionListEmployeeRelations(List<EmployeeRelation> lst)
        {
            BuildDiction(lst);
        }


        public void BuildDiction(List<EmployeeRelation> lst)
        {
            _diction.Clear();
            _lastId = 0;
            _lstUsing = null;
            if (lst == null) return;

            
            foreach (EmployeeRelation rel in lst)
            {
                GetById(rel.EmployeeID,true).Add(rel);
            }
        }

        protected virtual ListEmployeeRelations GetById(long emplid, bool bCreate)
        {
            if (_lstUsing != null && _lastId == emplid) return _lstUsing;

            ListEmployeeRelations list = null;

            if (_diction.TryGetValue(emplid, out list))
            {
                _lstUsing = list;
                _lastId = emplid;
                return list;
            }

            if (bCreate)
            {
                list = new ListEmployeeRelations();
                _lstUsing = list;
                _lastId = emplid;
                _diction[emplid] = list;
            }

            return list;
        }


        public ListEmployeeRelations this[long emplid]
        {
            get { return GetById(emplid, false); }
        }

        public virtual bool IsContain(long emplid, DateTime date)
        {
            ListEmployeeRelations lst = GetById(emplid, false);

            if (lst == null) return false;


            return lst.GetRelation(date) != null;
        }

        public virtual long GetRelationWorld(long emplid, DateTime date)
        {
            EmployeeRelation relation = GetRelationEntity(emplid, date);

            return (relation != null)? relation.WorldID.Value : 0L;
        }
        public virtual EmployeeRelation GetRelationEntity(long emplid, DateTime date)
        {
            ListEmployeeRelations lst = GetById(emplid, false);

            if (lst == null) return null;


            return lst.GetRelation(date);
        }

        public void LoadRelations(IEmployeeRelationService service)
        {
            BuildDiction(service.LoadAllSorted());
        }
    }


    public class ListEmployeeRelations : List<EmployeeRelation>
    {
        private IEmployeeRelationService _relationservice = null;
        private long _employeeid = 0;

        public long Employeeid
        {
            get { return _employeeid; }
        }
        public ListEmployeeRelations()
            : base()
        {

        }
        public ListEmployeeRelations(IEmployeeRelationService relationservice)
        {
            _relationservice = relationservice;
        }
        public ListEmployeeRelations(IEmployeeRelationService relationservice, long emplid)
        {
            _relationservice = relationservice;
            LoadRelations(emplid);
        }


        public EmployeeRelation GetRelation(DateTime date)
        {

            int iCount = this.Count;
            if (iCount > 0)
            {
                EmployeeRelation relation = this[0];

                if (iCount == 1 && relation.IsContainDate(date))
                    return relation;

                for (int i = 0; i < iCount; i++)
                {
                    relation = this[i];
                    if (relation.IsContainDate(date))
                        return relation;
                }
            }
            return null;
        }

        public bool IsExistsRelation(DateTime date)
        {
            return GetRelation (date) != null;
        }

        public bool IsWorkInHomeStore(DateTime date, long storeid)
        {
            EmployeeRelation relation = GetRelation(date);

            return relation != null && relation.StoreID == storeid;
        }
        public void LoadRelations(long emplid, DateTime beginDate, DateTime endDate)
        {
            if (_relationservice == null)
                throw new ArgumentNullException();

            _employeeid = emplid;

            this.Clear();

            List<EmployeeRelation> lst = _relationservice.GetEmployeeRelations(emplid, beginDate, endDate);

            if (lst != null)
                AddRange(lst);

#if DEBUG
            Check();
#endif
        }

        public void LoadRelations(long emplid)
        {
            if (_relationservice == null)
                throw new ArgumentNullException();

            _employeeid = emplid;

            this.Clear();

            List<EmployeeRelation> lst = _relationservice.GetEmployeeRelations (emplid);

            if (lst != null)
                AddRange(lst);

#if DEBUG
            Check();
#endif
        }

        private void Check()
        {
            if (Count <= 1) return;

            DateTime date = this[0].BeginTime.Date;

            for (int i = 1; i < Count - 1; i++)
            {
                if (date.AddDays(1) != this[i].BeginTime.Date)
                    throw new ArgumentException();

                date = this[i].EndTime.Date;
            }
        }

        public DateTime GetFirstRelationDate()
        {
            if (Count > 0)
                return this[0].BeginTime;
            else
                return DateTimeSql.SmallDatetimeMin;
        }

        public DateTime GetLastRelationDate()
        {
            if (Count > 0)
                return this[Count - 1].EndTime;
            else
                return DateTimeSql.SmallDatetimeMin;
        }

        public bool IsExistsWorldAssignment(StoreToWorld sw)
        {
            return IsExistsWorldAssignment(sw.StoreID, sw.WorldID);
        }
        public bool IsExistsWorldAssignment(long storeid, long worldid)
        {
            foreach (EmployeeRelation rel in this)
            {
                if (rel.WorldID.HasValue && rel.StoreID == storeid && rel.WorldID == worldid) return true;
            }
            return false;
        }

        public bool IsExistsWorldAssignment(StoreToWorld sw, DateTime begin, DateTime end)
        {
            bool b = false;
            foreach (EmployeeRelation rel in this)
            {
                b = DateTimeHelper.IsIntersectExc(begin, end, rel.BeginTime, rel.EndTime);
                if (rel.WorldID.HasValue && rel.StoreID == sw.StoreID && rel.WorldID == sw.WorldID && b) return true;
            }
            return false;
        }

        public void SyncWithContract(ListEmployeeContracts contracts)
        {

        }
    }
    
}
