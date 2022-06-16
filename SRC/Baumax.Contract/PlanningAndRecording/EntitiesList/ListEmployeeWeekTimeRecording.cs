using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using System.Diagnostics;

namespace Baumax.Contract.PlanningAndRecording.EntitiesList
{
    public class EmployeeWeekTimeRecordingList
    {
        protected List<EmployeeWeekTimeRecording> _entities = new List<EmployeeWeekTimeRecording>(100);
        protected Dictionary<long, List<EmployeeWeekTimeRecording>> _index = new Dictionary<long,List<EmployeeWeekTimeRecording>> (50);

        public void BuildIndex()
        {
            _index.Clear ();
            List<EmployeeWeekTimeRecording> list = null;
            foreach (EmployeeWeekTimeRecording entity in _entities)
            {
                if (!_index.TryGetValue(entity.EmployeeID, out list))
                {
                    list = new List<EmployeeWeekTimeRecording>(10);
                    _index[entity.EmployeeID] = list;
                }

                list.Add(entity);
            }
        }

        public virtual EmployeeWeekTimeRecording GetByDate(long emplid, DateTime date)
        {
            Debug.Assert(date.DayOfWeek == DayOfWeek.Monday);
            EmployeeWeekTimeRecording returnEntity = null;
            List<EmployeeWeekTimeRecording> list = GetEntitiesByEmployeeId(emplid);

            if (list != null)
            {
                foreach (EmployeeWeekTimeRecording entity in list)
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

            EmployeeWeekTimeRecording entity = GetByDate(emplid, date);

            if (entity != null)
            {
                _UpdateSaldo(entity, lastSaldo, allin);
            }

            
        }

        protected virtual void _UpdateSaldo(EmployeeWeekTimeRecording entity, int lastSaldo, bool allin)
        {
            Debug.Assert(entity != null);
            if (entity != null)
            {
                entity.AllIn = allin;

                entity.CalculateSaldo(lastSaldo);
                //if (!entity.CustomEdit)
                //{
                //    entity.Saldo = lastSaldo - entity.ContractHours;

                //    if (!allin)
                //    {
                //        entity.Saldo += entity.AdditionalCharge;
                //    }

                //    entity.Saldo += entity.PlannedHours;
                //}
            }
        }
        public List<EmployeeWeekTimeRecording> GetEntitiesByEmployeeId(long emplid)
        {
            List<EmployeeWeekTimeRecording> list = null;

            _index.TryGetValue(emplid, out list);

            return list;
        }
        #region Service function

        public void SortEntities()
        {
            _entities.Sort(CompareEntities);
        }

        public static int CompareEntities(EmployeeWeekTimeRecording x, EmployeeWeekTimeRecording y)
        {
            Debug.Assert(x != null && y != null);

            int i = x.EmployeeID.CompareTo(y.EmployeeID);

            if (i == 0)
            {
                i = x.WeekBegin.CompareTo(y.WeekBegin);
            }

            return i;
        }

        #endregion
    }
}
