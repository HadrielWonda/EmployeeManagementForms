using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using System.Diagnostics;

namespace Baumax.Contract.PlanningAndRecording.EntitiesList
{
    public class EmployeeWeekTimePlanningList
    {
        protected List<EmployeeWeekTimePlanning> _entities = new List<EmployeeWeekTimePlanning>(100);
        protected Dictionary<long, List<EmployeeWeekTimePlanning>> _index = new Dictionary<long, List<EmployeeWeekTimePlanning>>(10);

        public void BuildIndex()
        {
            _index.Clear ();
            // = new Dictionary<long, List<EmployeeWeekTimePlanning>>();
            List<EmployeeWeekTimePlanning> list = null;
            foreach (EmployeeWeekTimePlanning entity in _entities)
            {
                if (!_index.TryGetValue (entity.EmployeeID, out list))
                {
                    list = new List<EmployeeWeekTimePlanning>(10);
                    _index[entity.EmployeeID] = list;
                }

                list.Add(entity);
            }
        }

        public void AddEntity(EmployeeWeekTimePlanning entity)
        {
            _entities.Add(entity);
            List<EmployeeWeekTimePlanning> lst = GetEntitiesByEmployeeId(entity.EmployeeID);

            if (lst == null)
            {
                lst = new List<EmployeeWeekTimePlanning>();
                _index[entity.EmployeeID] = lst;
            }
            lst.Add(entity);
            
            lst.Sort(new PlanningWeekComparer ());
        }
        public void Clear()
        {
            if (_entities != null)
                _entities.Clear();
            if (_index != null)
                _index.Clear();

            if (_entities == null)
                throw new ArgumentNullException();
            if (_index == null)
                throw new ArgumentNullException();

        }

        public void AddEntities(List<EmployeeWeekTimePlanning> entities)
        {
            if (entities != null)
            {
                _entities.AddRange(entities);
                BuildIndex();
            }
        }

        public virtual EmployeeWeekTimePlanning GetByDate(long emplid, DateTime date)
        {
            Debug.Assert(date.DayOfWeek == DayOfWeek.Monday);
            EmployeeWeekTimePlanning returnEntity = null;
            List<EmployeeWeekTimePlanning> list = null;

            _index.TryGetValue(emplid, out list);

            if (list != null)
            {
                foreach (EmployeeWeekTimePlanning entity in list)
                {
                    if (entity.EmployeeID == emplid && entity.WeekBegin == date)
                    {
                        returnEntity = entity;
                    }
                }
            }
            return returnEntity;
        }

        public virtual bool IsExistEntity(long emplid, DateTime date)
        {
            return GetByDate(emplid, date) != null;
        }

        public virtual void UpdateSaldo(long emplid, DateTime date, int lastSaldo, bool allin)
        {

            EmployeeWeekTimePlanning entity = GetByDate(emplid, date);
            
            if (entity != null)
            {
                _UpdateSaldo(entity, lastSaldo, allin);
            }
        }

        protected virtual void _UpdateSaldo(EmployeeWeekTimePlanning entity, int lastSaldo, bool allin)
        {
            Debug.Assert(entity != null);
            if (entity != null)
            {
                entity.AllIn = allin;
                entity.CalculateSaldo(lastSaldo);
            }
        }

        public List<EmployeeWeekTimePlanning> GetEntitiesByEmployeeId(long emplid)
        {
            List<EmployeeWeekTimePlanning> list = null;

            _index.TryGetValue(emplid, out list);

            return list;
        }

        public bool IsExistsPlanning(long emplid)
        {
            List<EmployeeWeekTimePlanning> list = GetEntitiesByEmployeeId(emplid);
            bool exists = (list != null) && (list.Count > 0);

            return exists;
        }

        #region Service function
        
        public void SortEntities()
        {
            _entities.Sort(new PlanningWeekComparer());
        }

        #endregion
    }

    public class PlanningWeekComparer : IComparer<EmployeeWeekTimePlanning>
    {
        public int Compare(EmployeeWeekTimePlanning a, EmployeeWeekTimePlanning b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException();

            int i = a.EmployeeID.CompareTo(b.EmployeeID);

            if (i == 0)
            {
                i = a.WeekBegin.CompareTo(b.WeekBegin);
            }

            return i;
        }
    }
}
