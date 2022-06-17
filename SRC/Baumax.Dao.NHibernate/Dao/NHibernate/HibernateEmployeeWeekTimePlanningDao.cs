
using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using System.Collections;
using NHibernate;
using NHibernate.Expression;
using Baumax.Contract;
using Spring.Transaction.Interceptor;
using System.Diagnostics;

namespace Baumax.Dao.NHibernate
{
    public class HibernateEmployeeWeekTimePlanningDao : HibernateDao<EmployeeWeekTimePlanning>, IEmployeeWeekTimePlanningDao
    {
        public void SaveEmployeePlanningWeek(EmployeePlanningWeek planningweek)
        {
            
            if (planningweek == null)
            {
                throw new ArgumentNullException();
            }

            EmployeeWeekTimePlanning entity = null;

            entity = GetEmployeeWeekState(planningweek.EmployeeId, planningweek.BeginDate, planningweek.EndDate);

            if (entity == null)
            {
                entity = planningweek.CreateEntity();
                entity.ID = 0;
            }
            else
            {
                planningweek.AssignTo(entity);
            }

            entity.WeekNumber = DateTimeHelper.GetWeekNumber(planningweek.BeginDate, planningweek.EndDate);

            SaveOrUpdate(entity);

            if (DateTimeHelper.Between(DateTime.Today, planningweek.BeginDate, planningweek.EndDate))
            {
                UpdatePlanningSaldo(entity);
            }

        }

        public void SaveEmployeePlanningWeeks(List<EmployeePlanningWeek> planningweeks)
        {
            if (planningweeks != null)
            {
                foreach (EmployeePlanningWeek epw in planningweeks)
                {
                    SaveEmployeePlanningWeek(epw);
                }
            }
        }

        public EmployeeWeekTimePlanning GetEmployeeWeekState(long emplid, DateTime beginDate, DateTime endDate)
        {
            EmployeeWeekTimePlanning entity =
                (EmployeeWeekTimePlanning) HibernateTemplate.Execute(
                                               delegate(ISession session)
                                                   {
                                                       return session.CreateCriteria(typeof (EmployeeWeekTimePlanning))
                                                           .Add(Expression.Eq("EmployeeID", emplid))
                                                           .Add(Expression.Eq("WeekBegin", beginDate))
                                                           .Add(Expression.Eq("WeekEnd", endDate))
                                                           .UniqueResult<EmployeeWeekTimePlanning>();
                                                   }
                                               );

            return entity;
        }

        public List<EmployeeWeekTimePlanning> GetEmployeeWeekStatesInFuture(long emplid, DateTime fromDate)
        {
            List<EmployeeWeekTimePlanning> entities = new List<EmployeeWeekTimePlanning>();

            HibernateTemplate.Execute(
                    delegate(ISession session)
                        {
                            session.CreateCriteria(typeof (EmployeeWeekTimePlanning))
                                .Add(Expression.Eq("EmployeeID", emplid))
                                .Add(Expression.Ge("WeekBegin", fromDate))
                                .AddOrder(Order.Asc("WeekBegin"))
                                .List(entities);
                            return null;
                        }
                    );

            return entities;
        }

        public void UpdateSaldo(EmployeeWeekTimePlanning prevEntity)
        {
            List<EmployeeWeekTimePlanning> entities = GetEmployeeWeekStatesInFuture(prevEntity.EmployeeID , prevEntity.WeekEnd );
            int nextSaldo = prevEntity.Saldo;
            if (entities != null)
            {
                foreach (EmployeeWeekTimePlanning entity in entities)
                {
                    entity.Saldo = nextSaldo + entity.PlusMinusHours;
                    nextSaldo = entity.Saldo;
                    SaveOrUpdate(entity);
                }
            }
        }

        public List<EmployeeWeekTimePlanning> GetEmployeesWeekState(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeWeekTimePlanning> res = new List<EmployeeWeekTimePlanning>();
            HibernateTemplate.Execute(
                delegate(ISession session)
                    {
                        session.CreateCriteria(typeof (EmployeeWeekTimePlanning))
                            .Add(Expression.In("EmployeeID", emplids))
                            .Add(Expression.Eq("WeekBegin", beginDate))
                            .Add(Expression.Eq("WeekEnd", endDate))
                            .List(res);
                        return null;
                    }
                );

            return res;
        }

        public List<EmployeeWeekTimePlanning> GetEmployeesWeekStateByDateRange(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeWeekTimePlanning> res = new List<EmployeeWeekTimePlanning>();

            if (emplids != null && emplids.Length > 0)
            {
                HibernateTemplate.Execute(
                    delegate(ISession session)
                    {
                        ICriteria criteria = session.CreateCriteria(typeof(EmployeeWeekTimePlanning));
                        if (emplids.Length == 1)
                            criteria.Add(Expression.Eq("EmployeeID", emplids[0]));
                        else
                            criteria.Add(Expression.In("EmployeeID", emplids));

                        criteria.Add(Expression.Ge("WeekBegin", beginDate))
                        .Add(Expression.Lt("WeekBegin", endDate))
                        .AddOrder(Order.Asc("EmployeeID"))
                        .AddOrder(Order.Asc("WeekBegin"))
                        .List(res);
                        return null;
                    }
                    );
            }
            return res;
        }

        public void SaveEmployeeWeek(EmployeeWeek planningweek)
        {
            if (planningweek == null)
                throw new ArgumentNullException();

            EmployeeWeekTimePlanning entity = GetEmployeeWeekState(planningweek.EmployeeId,planningweek.BeginDate ,planningweek.EndDate);
            if (entity == null)
                entity = new EmployeeWeekTimePlanning();

            EmployeeWeekProcessor.AssignTo(entity, planningweek);

            SaveOrUpdate(entity);

            //planningweek.ID = entity.ID;
            if (DateTimeHelper.Between(DateTime.Today, planningweek.BeginDate, planningweek.EndDate))
            {
                UpdatePlanningSaldo(entity);
            }
        }

        public void SaveEmployeeWeeks(List<EmployeeWeek> planningweeks)
        {
            if (planningweeks != null)
            {
                foreach (EmployeeWeek ew in planningweeks)
                    SaveEmployeeWeek(ew);
            }
        }

        public EmployeeWeek GetEmployeeWeek(long emplid, DateTime beginDate, DateTime endDate)
        {
            EmployeeWeek week = null;
            EmployeeWeekTimePlanning entity = GetEmployeeWeekState(emplid, beginDate, endDate);
            if (entity != null)
            {
                week = new EmployeeWeek(entity);
            }
            return week;

        }

        public List<EmployeeWeek> GetEmployeesWeekStates(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeWeek> weeks = null;
            EmployeeWeek week = null;

            List<EmployeeWeekTimePlanning> entities = GetEmployeesWeekState(emplids, beginDate, endDate);
            if (entities != null)
            {
                weeks = new List<EmployeeWeek>();
                foreach (EmployeeWeekTimePlanning entity in entities)
                {
                    week = new EmployeeWeek(entity);
                    weeks.Add (EmployeeWeekProcessor.Assign(entity, week));
                }
            }

            return weeks;
        }


        public EmployeeWeekTimeRecording GetRecordingWeek(long employeeid, DateTime weekDate)
        {
             return (EmployeeWeekTimeRecording)HibernateTemplate.Execute(
                        delegate(ISession session)
                            {
                                return session.CreateCriteria(typeof(EmployeeWeekTimeRecording))
                                    .Add(Expression.Eq("EmployeeID", employeeid))
                                    .Add(Expression.Eq("WeekBegin", weekDate))
                                    .UniqueResult<EmployeeWeekTimeRecording>();
                            }
                        );

            //return res;


            //return Session.CreateCriteria(typeof(EmployeeWeekTimeRecording))
            //.Add(Expression.Eq("EmployeeID", employeeid))
            //.Add(Expression.Eq("WeekBegin", weekDate))
            //.UniqueResult<EmployeeWeekTimeRecording>();
        }
        // warning!!!!  recursive function 
        public void UpdatePlanningSaldo(EmployeeWeekTimePlanning prevEntity)
        {
            if (prevEntity == null)
                throw new ArgumentNullException();

            EmployeeWeekTimeRecording entity = GetRecordingWeek(prevEntity.EmployeeID, prevEntity.WeekBegin);

            DateTime mondayDate = DateTimeHelper.GetNextMonday(prevEntity.WeekBegin);
            DateTime sundayDate = DateTimeHelper.GetNextSunday(prevEntity.WeekBegin);

            if (entity != null)
            {
                EmployeeWeekTimePlanning nextEntity = GetEmployeeWeekState(prevEntity.EmployeeID, mondayDate, sundayDate);

                if (nextEntity != null)
                {
                    nextEntity.Saldo = entity.Saldo + nextEntity.PlusMinusHours;
                    SaveOrUpdate(nextEntity);

                    UpdatePlanningSaldo(nextEntity);
                }
            }
            else
            {
                UpdateSaldo(prevEntity);
            }
        }

        public List<EmployeeWeekTimePlanning> LoadAllFromDateSorted(DateTime monday)
        {
            Debug.Assert(monday.DayOfWeek == DayOfWeek.Monday);
            List<EmployeeWeekTimePlanning> entities = new List<EmployeeWeekTimePlanning>();

            HibernateTemplate.Execute(
                    delegate(ISession session)
                    {
                        session.CreateCriteria(typeof(EmployeeWeekTimePlanning))
                            .Add(Expression.Ge("WeekBegin", monday))
                            .AddOrder(Order.Asc("EmployeeID"))
                            .AddOrder(Order.Asc("WeekBegin"))
                            .List(entities);
                        return null;
                    }
                    );

            return entities;
        }

    }
}