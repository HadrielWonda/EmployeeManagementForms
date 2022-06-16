using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.PlanningAndRecording.EntitiesList;
using Baumax.Domain;
using System.Diagnostics;
using Baumax.AppServer.Environment;
using Baumax.Contract;
using Baumax.Contract.TimePlanning;

namespace Baumax.Services._HelperObjects.ServerEntitiesList
{
    /*
     
     1. User can change  AllIn flag -> all planning week after next monday (from Today) must update saldo and change allin flag
     2. After save planning week - need update follow planning week saldo
     3. after save actual week - need update follow planning week saldo
     
     */
    public class SrvEmployeeWeekPlanningList : EmployeeWeekTimePlanningList
    {

        private EmployeeBusinessObject _employee = null;
        private CacheEmployeesAllIn _AllInManager = null;
        private SrvEmployeeWeekRecordingList _recordingWeeks = null;
        private DictionListEmployeesContract _contracts = null;

        public EmployeeBusinessObject BzEmployee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        public CacheEmployeesAllIn AllInManager
        {
            get { return _AllInManager; }

            set
            {
                _AllInManager = value;
            }
        }

        private bool GetAllInState(long emplid, DateTime date)
        {
            if (AllInManager == null)
            {
                AllInManager = new CacheEmployeesAllIn();
                AllInManager.LoadByEmployee(emplid);
            }
            return AllInManager.GetAllIn(emplid, date, DateTimeHelper.GetSunday(date));
        }

        public SrvEmployeeWeekRecordingList RecordingWeeks
        {
            get { return _recordingWeeks; }
            set { _recordingWeeks = value; }
        }

        public DictionListEmployeesContract Contracts
        {
            get { return _contracts; }
            set { _contracts = value; }
        }

        public SrvEmployeeWeekPlanningList()
        {

        }
        public SrvEmployeeWeekPlanningList(long emplid, DateTime date)
        {
            InitList(emplid, date);
        }
        public SrvEmployeeWeekPlanningList(long[] emplids, DateTime date)
        {
            InitList(emplids, date);
        }

        #region load and save entity functions
        
        protected virtual void DoUpdateEntity(EmployeeWeekTimePlanning entity)
        {
            if (entity.IsNew)
                ServerEnvironment.EmployeeWeekTimePlanningService.Save(entity);
            else 
                ServerEnvironment.EmployeeWeekTimePlanningService.Update(entity);
            //ServerEnvironment.EmployeeWeekTimePlanningService.SaveOrUpdate(entity);
        }
        protected virtual void DoDeleteEntity(EmployeeWeekTimePlanning entity)
        {
            if (entity.IsNew) return;

            ServerEnvironment.EmployeeWeekTimePlanningService.Delete(entity);
        }
        protected virtual List<EmployeeWeekTimePlanning> LoadEntities(long id, DateTime date)
        {
            return LoadEntities(new long[] { id }, date);
        }
        protected virtual List<EmployeeWeekTimePlanning> LoadEntities(long[] ids, DateTime date)
        {
            EmployeeWeekTimePlanningService service = ServerEnvironment.EmployeeWeekTimePlanningService as EmployeeWeekTimePlanningService;

            if (ids == null)
                return service.ServiceDao.LoadAllFromDateSorted(date);
            else
                return service.GetEmployeesWeekStateByDateRange (ids, date, DateTimeSql.LastMaxSunday);
        }



        #endregion

        protected override void _UpdateSaldo(EmployeeWeekTimePlanning entity, int lastSaldo, bool allin)
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


        public void UpdateEntity(EmployeeWeekTimePlanning entity)
        {
            DoUpdateEntity(entity); 
        }
        public void InitList(long emplid, DateTime fromDate)
        {
            Debug.Assert(fromDate.DayOfWeek == DayOfWeek.Monday);

            InitList(new long[] { emplid }, fromDate);
        }

        public void InitList(long[] emplids, DateTime fromDate)
        {
            Debug.Assert(fromDate.DayOfWeek == DayOfWeek.Monday);

            Clear();

            List<EmployeeWeekTimePlanning> lst = LoadEntities(emplids, fromDate);


            AddEntities(lst);

        }

        public virtual void UpdateSaldo(long emplid, DateTime date, int lastSaldo)
        {
            UpdateSaldo(emplid, date, lastSaldo, GetAllInState(emplid, date));
        }

        public void UpdateSaldoFrom(long emplid, DateTime date, int lastSaldo)
        {
            UpdateSaldoFrom(emplid, date, lastSaldo, false);
        }
        public void UpdateSaldoFrom(long emplid, DateTime date, int lastSaldo, bool loadAllIn)
        {
            int saldo = lastSaldo;
            List<EmployeeWeekTimePlanning> list = _entities;
            _index.TryGetValue(emplid, out list);

            if (list != null && list.Count > 0)
            {
                foreach (EmployeeWeekTimePlanning entity in list)
                {
                    if (entity.EmployeeID == emplid && entity.WeekBegin >= date)
                    {
                        _UpdateSaldo(entity, saldo, ((loadAllIn)?GetAllInState(emplid, entity.WeekBegin): entity.AllIn));

                        saldo = entity.Saldo;
                    }
                }
            }
        }

        public void UpdateSaldoAfterPlanning(EmployeeWeek week)
        {
            EmployeeWeekTimePlanning entity = GetByDate(week.EmployeeId, week.BeginDate);

            if (entity == null)
            {
                entity = new EmployeeWeekTimePlanning();
                EmployeeWeekProcessor.AssignTo(entity, week);
                UpdateEntity(entity);
            }
            else
            {
                if (EmployeeWeekProcessor.IsModified(entity, week))
                {
                    EmployeeWeekProcessor.AssignTo(entity, week);
                    UpdateEntity(entity);
                }
            }
            
            UpdateSaldoFrom(week.EmployeeId, DateTimeHelper.GetNextMonday(week.BeginDate), week.Saldo);
        }
        
        public void SetCustomEditFlag(long emplid, DateTime date, int saldo)
        {
            List<EmployeeWeekTimePlanning> list = _entities;
            _index.TryGetValue(emplid, out list);
            if (list != null && list.Count > 0)
            {
                foreach (EmployeeWeekTimePlanning entity in list)
                {
                    if (entity.EmployeeID == emplid && entity.WeekBegin == date)
                    {
                        if (entity.CustomEdit != true)
                        {
                            entity.CustomEdit = true;
                            entity.Saldo = saldo;
                            UpdateEntity(entity);
                        }
                    }
                }
            }
        }
        // if not exists planning week in future => don't need recalculation
        private bool IsNeedRecalculationAfterImport(long id, DateTime monday)
        {
            List<EmployeeWeekTimePlanning> list = GetEntitiesByEmployeeId(id);

            if (list != null && list.Count > 0)
            {
                foreach (EmployeeWeekTimePlanning w in list)
                    if (w.WeekBegin >= monday) return true;
            }
            return false;
        }
        public void RecalculateAfterImport(DateTime monday)
        {
            
            long id = BzEmployee.Employee.ID;
            if (!IsNeedRecalculationAfterImport(id, monday)) return;

            int lastSaldo = 0;
            if (BzEmployee.AustriaEmployee)
                lastSaldo = Convert.ToInt32(BzEmployee.Employee.BalanceHours);
            else
            {
                DateTime prevMonday = monday.AddDays(-7);

                IEmployeeWeek week = RecordingWeeks.GetByDate(id, prevMonday);
                if (week == null)
                {
                    week = GetByDate(id, prevMonday);

                    if (week == null)
                    {
                        lastSaldo = BzEmployee.GetLastSaldoForPlanning(monday);
                    }
                    else
                        lastSaldo = week.Saldo;
                }
                else
                    lastSaldo = week.Saldo;

                
            }

            List<EmployeeWeekTimePlanning> list = GetEntitiesByEmployeeId(id);
            
            if (list != null && list.Count > 0)
            {
                int contract = 0;
                bool allin = false;
                bool customedit = false;
                bool bModified = false;
                foreach (EmployeeWeekTimePlanning entity in list)
                {
                     contract = 0;
                     allin = false;
                     customedit = false;
                     bModified = false;
                    if (entity.EmployeeID == id && entity.WeekBegin >= monday)
                    {

                        allin = AllInManager.GetAllIn(id, entity.WeekBegin, entity.WeekEnd);

                        if (RecordingWeeks != null)
                        {
                            EmployeeWeekTimeRecording rec = RecordingWeeks.GetByDate(id, entity.WeekBegin);
                            if (rec != null)
                                customedit = rec.CustomEdit;
                        }

                        contract = Contracts.GetContractHours(entity.EmployeeID,entity.WeekBegin, entity.WeekEnd);


                        bModified = (entity.CustomEdit != customedit) |
                            (entity.AllIn != allin) |
                            (entity.ContractHours != contract);
                        if (bModified)
                        {
                            entity.CustomEdit = customedit;
                            entity.AllIn = allin;
                            entity.ContractHours = contract;
                        }
                        if (entity.CalculateSaldo(lastSaldo) | bModified)
                            UpdateEntity(entity);

                        lastSaldo = entity.Saldo;
                    }
                }
            }
        }

        

        public void UpdateSaldoAfterRecording(long emplid, List<EmployeeWeekTimeRecording> list_recording, DateTime fromDate)
        {

            List<WeekPair> sortedList = WeekPair.BuildListOfWeekPairs(list_recording, GetEntitiesByEmployeeId(emplid));

            if (sortedList != null && sortedList.Count > 0)
            {
                WeekPair pair_week = null;
                for (int i = 0; i < sortedList.Count; i++)
                {
                    pair_week = sortedList[i];
                    if (pair_week.Date >= fromDate && pair_week.PlanningWeek != null)
                    {
                        if (i - 1 >= 0)
                        {
                            
                            int prevSaldo = sortedList[i - 1].Saldo;
                            if (pair_week.PlanningWeek.CalculateSaldo(prevSaldo))
                            {
                                UpdateEntity(pair_week.PlanningWeek);

                            }
                        }
                        else
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            

        }

        public void ValidateWeekWithContractEnd(long emplid, DateTime date)
        {
            List<EmployeeWeekTimePlanning> list = null;
            _index.TryGetValue(emplid, out list);

            if (list == null) return;

            for (int i = list.Count - 1; i >= 0; i--)
            {
                EmployeeWeekTimePlanning entity = list[i];
                if (date <= entity.WeekBegin)
                {
                    DoDeleteEntity(entity);
                    list.RemoveAt(i);
                }
            }
        }
    }
}
