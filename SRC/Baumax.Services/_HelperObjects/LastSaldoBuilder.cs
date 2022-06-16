using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;
using Baumax.AppServer.Environment;
using Baumax.Services._HelperObjects.ServerEntitiesList;
using Baumax.Domain;
using System.Diagnostics;

namespace Baumax.Services._HelperObjects
{
    public class LastSaldoBuilder
    {
        private EmployeeTimeService Service
        {
            get { return ServerEnvironment.EmployeeTimeService as EmployeeTimeService; }
        }

        public virtual void FillPlanningLastSaldo(Dictionary<long, EmployeePlanningWeek> dict, long[] ids, DateTime aBeginWeek)
        {

            if (ids == null || ids.Length == 0) return;
            long[][] result = Service.EmployeeTimeSaldoGet(ids, EmployeeTimeSaldoType.Planning, aBeginWeek);

            long id = 0;
            long value = 0;
            EmployeePlanningWeek entity = null;
            foreach (long[] data in result)
            {
                id = (long)data[0];
                value = (long)data[1];
                if (dict.TryGetValue(id, out entity))
                {
                    entity.LastSaldo = (int)value;
                }
            }
        }

        public virtual void FillLastSaldo(Dictionary<long, EmployeeWeek> dict, long[] ids, DateTime aBeginWeek, bool bPlanning)
        {
            if (ids == null || ids.Length == 0) return;

            long[][] result = Service.EmployeeTimeSaldoGet(ids, (bPlanning) ? EmployeeTimeSaldoType.Planning : EmployeeTimeSaldoType.Recording, aBeginWeek);

            long id = 0;
            long value = 0;
            EmployeeWeek entity = null;
            foreach (long[] data in result)
            {
                id = (long)data[0];
                value = (long)data[1];
                if (dict.TryGetValue(id, out entity))
                {
                    entity.LastSaldo = (int)value;
                }
            }
        }

        //public void FillLastSaldoAustria(Dictionary<long, EmployeeWeek> dict, long[] ids, DateTime aBeginWeek)
        //{
        //    DateTime todayMonday = DateTimeHelper.GetMonday(DateTime.Today);
        //    bool isFutureWeek  = todayMonday < aBeginWeek;
        //    bool isCurrentWeek = todayMonday == aBeginWeek;
        //    bool isPastWeek = todayMonday > aBeginWeek;

        //    //if 

        //}
    }

    public class LastSaldoBuilderAustria : LastSaldoBuilder
    {
        public override void FillPlanningLastSaldo(Dictionary<long, EmployeePlanningWeek> dict, long[] ids, DateTime aBeginWeek)
        {
            DateTime todayMonday = DateTimeHelper.GetMonday(DateTime.Today);

            Debug.Assert(aBeginWeek.DayOfWeek == DayOfWeek.Monday);

            DateTime currentMonday = aBeginWeek;

            bool bPastWeek = todayMonday > currentMonday;
            bool bFutureWeek = todayMonday < currentMonday;
            bool bCurrentWeek = todayMonday == currentMonday;

            if (bCurrentWeek)
            {
                return;
            }
            if (bFutureWeek)
            {
                SrvEmployeeWeekPlanningList cache_weeks = new SrvEmployeeWeekPlanningList(ids, todayMonday);

                foreach (EmployeePlanningWeek week in dict.Values)
                {
                    List<EmployeeWeekTimePlanning> list_weeks =
                        cache_weeks.GetEntitiesByEmployeeId(week.EmployeeId);
                    DateTime minDate = todayMonday;
                    EmployeeWeekTimePlanning prevWeekEntity = null;
                    if (list_weeks != null && list_weeks.Count > 0)
                    {
                        foreach (EmployeeWeekTimePlanning entity in list_weeks)
                        {
                            if (entity.WeekBegin < currentMonday && minDate <= entity.WeekBegin)
                            {
                                prevWeekEntity = entity;
                                minDate = prevWeekEntity.WeekBegin;
                            }
                        }
                    }
                    if (prevWeekEntity != null)
                    {
                        Debug.Assert(prevWeekEntity.WeekBegin < currentMonday);
                        week.LastSaldo = prevWeekEntity.Saldo;

                    }


                }

                return;
            }

            if (bPastWeek)
            {
                foreach (EmployeePlanningWeek week in dict.Values)
                {
                    if (week.IsNew)
                        week.LastSaldo = 0;
                    else
                    {
                        week.LastSaldo = PlanningWeekProcessor.GetLastSaldoFromSaldo(week);
                    }
                }
            }

        }


        public override void FillLastSaldo(Dictionary<long, EmployeeWeek> dict, long[] ids, DateTime aBeginWeek, bool bPlanning)
        {
            if (!bPlanning)
                throw new ArgumentException("Austria don't support time recording");


            DateTime todayMonday = DateTimeHelper.GetMonday(DateTime.Today);

            Debug.Assert(aBeginWeek.DayOfWeek == DayOfWeek.Monday);

            DateTime currentMonday = aBeginWeek;

            bool bPastWeek = todayMonday > currentMonday;
            bool bFutureWeek = todayMonday < currentMonday;
            bool bCurrentWeek = todayMonday == currentMonday;

            if (bCurrentWeek)
            {
                return;
            }
            if (bFutureWeek)
            {
                SrvEmployeeWeekPlanningList cache_weeks = new SrvEmployeeWeekPlanningList(ids, todayMonday);

                foreach (EmployeeWeek week in dict.Values)
                {
                    List<EmployeeWeekTimePlanning> list_weeks =
                        cache_weeks.GetEntitiesByEmployeeId(week.EmployeeId);
                    DateTime minDate = todayMonday;
                    EmployeeWeekTimePlanning prevWeekEntity = null;
                    if (list_weeks != null && list_weeks.Count > 0)
                    {
                        foreach (EmployeeWeekTimePlanning entity in list_weeks)
                        {
                            if (entity.WeekBegin < currentMonday && minDate <= entity.WeekBegin)
                            {
                                prevWeekEntity = entity;
                                minDate = prevWeekEntity.WeekBegin;
                            }
                        }
                    }
                    if (prevWeekEntity != null)
                    {
                        Debug.Assert(prevWeekEntity.WeekBegin < currentMonday);
                        Debug.Assert(prevWeekEntity.WeekBegin > todayMonday);
                        week.LastSaldo = prevWeekEntity.Saldo;

                    }


                }

                return;
            }

            if (bPastWeek)
            {
                foreach (EmployeeWeek week in dict.Values)
                {
                    if (week.NewWeek)
                        week.LastSaldo = 0;
                    else
                    {
                        week.LastSaldo = EmployeeWeekProcessor.GetLastSaldoFromSaldo(week);
                    }
                }
            }
        }
    }
}
