using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.PlanningAndRecording.EntitiesList;
using Baumax.AppServer.Environment;
using Baumax.Domain;
using Baumax.Contract;
using System.Diagnostics;
using Baumax.Contract.TimePlanning;

namespace Baumax.Services._HelperObjects.ServerEntitiesList
{
    public class SrvEmployeeWeekRecordingList : EmployeeWeekTimeRecordingList
    {
        private EmployeeBusinessObject _employee = null;
        private CacheEmployeesAllIn _AllInManager = null;
        private SrvEmployeeWeekRecordingList _PlanningWeeks = null;

        public EmployeeBusinessObject Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }


        

        public CacheEmployeesAllIn CacheAllIn
        {
            get { return _AllInManager; }

            set
            {
                _AllInManager = value;
            }
        }

        

        public SrvEmployeeWeekRecordingList PlanningWeeks
        {
            get { return _PlanningWeeks; }
            set { _PlanningWeeks = value; }
        }


        #region load and save entity functions

        protected EmployeeWeekTimeRecordingService Service
        {
            get
            {
                return ServerEnvironment.EmployeeWeekTimeRecordingService as EmployeeWeekTimeRecordingService;
            }
        }

        protected virtual void UpdateEntity(EmployeeWeekTimeRecording entity)
        {
            if (entity.IsNew)
                Service.Save(entity);
            else
                Service.Update(entity);

            //Service.SaveOrUpdate(entity);
        }
        protected virtual void DeleteEntity(EmployeeWeekTimeRecording entity)
        {
            if (entity.IsNew) return;
            Service.Delete(entity);
        }
        protected virtual List<EmployeeWeekTimeRecording> LoadEntities(long id, DateTime date)
        {
            return LoadEntities(new long[] { id }, date);
        }
        protected virtual List<EmployeeWeekTimeRecording> LoadEntities(long[] ids, DateTime date)
        {
            //EmployeeWeekTimeRecordingService service = ServerEnvironment.EmployeeWeekTimeRecordingService as EmployeeWeekTimeRecordingService;

            if (ids == null)
                return Service.ServiceDao.LoadAllFromDateSorted(date);
            else
                return Service.GetEmployeesWeekStateByDateRange(ids, date, DateTimeSql.LastMaxSunday);
        }
        public void InitList(long emplid, DateTime fromDate)
        {
            Debug.Assert(fromDate.DayOfWeek == DayOfWeek.Monday);

            InitList(new long[] { emplid }, fromDate);
        }

        public void InitList(long[] emplids, DateTime fromDate)
        {
            Debug.Assert(fromDate.DayOfWeek == DayOfWeek.Monday);

            ClearList();

            List<EmployeeWeekTimeRecording> lst = LoadEntities(emplids, fromDate);

            if (lst != null)
            {
                _entities = lst;
                BuildIndex();
            }
            
            // if employee had long time absence need load last recording week
            if (emplids != null)
            {
                for (int i = 0; i < emplids.Length; i++)
                {
                    if (!_index.ContainsKey(emplids[i]))
                    {
                        EmployeeWeekTimeRecording entity = LoadLastEntity(emplids[i], fromDate);

                        if (entity != null)
                        {
                            lst = new List<EmployeeWeekTimeRecording>();
                            lst.Add(entity);
                            _index[emplids[i]] = lst;
                            _entities.Add(entity);
                        }
                    }
                }
            }
        }
        public void ClearList()
        {
            _entities.Clear();
            _index.Clear();
        }
        #endregion

        protected override void _UpdateSaldo(EmployeeWeekTimeRecording entity, int lastSaldo, bool allin)
        {
            Debug.Assert(entity != null);
            if (entity != null)
            {
                int oldSaldo = entity.Saldo;
                base._UpdateSaldo(entity, lastSaldo, allin);

                if (oldSaldo != entity.Saldo)
                {
                    UpdateEntity(entity);
                }
            }
        }

        private bool GetAllInState(long emplid, DateTime date)
        {
            if (CacheAllIn == null)
            {
                CacheAllIn = (new CacheEmployeesAllIn()).LoadByEmployee(emplid);
            }
            return CacheAllIn.GetAllIn(emplid, date, DateTimeHelper.GetSunday(date));
        }


        public virtual void UpdateSaldo(long emplid, DateTime date, int lastSaldo)
        {
            UpdateSaldo(emplid, date, lastSaldo, GetAllInState(emplid, date));
        }


        public virtual void UpdateSaldoAfterRecording(long emplid, DateTime date, int lastSaldo)
        {

            List<EmployeeWeekTimeRecording> list = GetEntitiesByEmployeeId(emplid);
            if (list == null) return;
            int previous_saldo = lastSaldo;
            foreach (EmployeeWeekTimeRecording entity in list)
            {
                if (entity.WeekBegin <= date) continue;

                if (entity.CalculateSaldo(previous_saldo))
                {
                    UpdateEntity(entity);
                    previous_saldo = entity.Saldo;
                }
                else break;

            }
        }
        public virtual void UpdateEntityAfterRecording(EmployeeWeek week)
        {

            EmployeeWeekTimeRecording entity = GetByDate(week.EmployeeId, week.BeginDate);
            List<EmployeeWeekTimeRecording> list = GetEntitiesByEmployeeId(week.EmployeeId);

            if (entity == null)
            {
                entity = new EmployeeWeekTimeRecording();
                EmployeeWeekProcessor.AssignTo(entity, week);
                UpdateEntity(entity);

                if (list == null)
                {
                    list = new List<EmployeeWeekTimeRecording>();
                    
                    _index[week.EmployeeId] = list;
                }

                _entities.Add(entity);
                list.Add(entity);

                list.Sort();


            }
            else
            {
                if (EmployeeWeekProcessor.IsModified(entity, week))
                {
                    EmployeeWeekProcessor.AssignTo(entity, week);
                    UpdateEntity(entity);
                }
            }



            
            if (list != null)
            {
                int previous_saldo = entity.Saldo; 
                foreach (EmployeeWeekTimeRecording next_entity in list)
                {
                    if (next_entity.WeekBegin <= week.BeginDate) continue;

                    if (next_entity.CalculateSaldo(previous_saldo))
                    {
                        UpdateEntity(next_entity);
                        previous_saldo = next_entity.Saldo;
                    }
                    else break;
                }
            }

            SrvEmployeeWeekPlanningList planList = new SrvEmployeeWeekPlanningList(week.EmployeeId, week.EndDate.AddDays(1));
            //planList.UpdateSaldoFrom2(week.EmployeeId, week.EndDate.AddDays(1), week.Saldo);
            planList.UpdateSaldoAfterRecording(week.EmployeeId, list, week.EndDate.AddDays(1));
        }

        public int GetSaldoBefore(long emplid, DateTime beforeDate)
        {
            List<EmployeeWeekTimeRecording> list = GetEntitiesByEmployeeId(emplid);

            if (list != null)
            {
                for (int i = list.Count-1; i >=0 ; i--)
                {
                    if (list[i].WeekBegin < beforeDate)
                        return list[i].Saldo;
                }
            }
            EmployeeWeekTimeRecording entity = LoadLastEntity(emplid, beforeDate);

            if (entity != null)
            {
                
                if (list != null)
                {
                    list.Insert(0, entity);
                }
                else
                {
                    list = new List<EmployeeWeekTimeRecording>();
                    list.Add(entity);
                    _index.Add(emplid, list);
                }

                return entity.Saldo;
            }
            return 0;
        }

        public EmployeeWeekTimeRecording UpdateLastSaldoAsCustom(long emplid, int saldo)
        {
            List<EmployeeWeekTimeRecording> list = GetEntitiesByEmployeeId(emplid);

            EmployeeWeekTimeRecording entity = GetLastEntity(emplid);

            if (entity != null)
            {
                entity.Saldo = saldo;
                entity.CustomEdit = true;

                UpdateEntity(entity);
            }

            return entity;

        }

        public EmployeeWeekTimeRecording GetLastEntity(long emplid)
        {
            List<EmployeeWeekTimeRecording> list = GetEntitiesByEmployeeId(emplid);
            EmployeeWeekTimeRecording entity = null;

            if (list != null && list.Count > 0)
            {
                entity = list[list.Count - 1];
            }

            return entity;
        }
        public void UpdateSaldoFrom(long emplid, DateTime date, int lastSaldo)
        {
            int saldo = lastSaldo;
            List<EmployeeWeekTimeRecording> list = _entities;
            if (_index.TryGetValue(emplid, out list))
            {
                if (list != null)
                {
                    foreach (EmployeeWeekTimeRecording entity in list)
                    {
                        if (entity.EmployeeID == emplid && entity.WeekBegin >= date)
                        {
                            _UpdateSaldo(entity, saldo, GetAllInState(emplid, entity.WeekBegin));

                            saldo = entity.Saldo;
                        }
                    }
                }
            }
        }

        public EmployeeWeekTimeRecording LoadLastEntity(long emplid, DateTime beforeDate)
        {
            return Service.GetLastWeek(emplid, beforeDate);
        }


        public void ValidateWeekWithContractEnd(long emplid, DateTime date)
        {
            List<EmployeeWeekTimeRecording> list = null;
            _index.TryGetValue(emplid, out list);

            if (list == null) return;

            for (int i = list.Count - 1; i >= 0; i--)
            {
                EmployeeWeekTimeRecording entity = list[i];
                if (date <= entity.WeekBegin)
                {
                    DeleteEntity(entity);
                    list.RemoveAt(i);
                }
            }
        }
    }
}
