using Baumax.Domain;
using Baumax.Contract.TimePlanning;
using Baumax.Contract;
using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Expression;
using System.Collections;
using System.Diagnostics;

namespace Baumax.Dao.NHibernate
{
    public class HibernateEmployeeWeekTimeRecordingDao : HibernateDao<EmployeeWeekTimeRecording>, IEmployeeWeekTimeRecordingDao
    {
        public List<EmployeeWeekTimeRecording> GetEmployeeWeekStatesFrom(long emplid, DateTime beginDate)
        {
            IList lst =
                (IList)HibernateTemplate.Execute(
                                                delegate(ISession session)
                                                {
                                                    return session.CreateCriteria(typeof(EmployeeWeekTimeRecording))
                                                        .Add(Expression.Eq("EmployeeID", emplid))
                                                        .Add(Expression.Ge("WeekBegin", beginDate))
                                                        .AddOrder(Order.Asc ("WeekBegin"))
                                                        .List();
                                                }
                                                );

            return GetTypedListFromIList(lst);
        }

        public EmployeeWeekTimeRecording GetEmployeeWeekState(long emplid, DateTime beginDate, DateTime endDate)
        {
            EmployeeWeekTimeRecording entity =
                (EmployeeWeekTimeRecording) HibernateTemplate.Execute(
                                                delegate(ISession session)
                                                    {
                                                        return session.CreateCriteria(typeof (EmployeeWeekTimeRecording))
                                                            .Add(Expression.Eq("EmployeeID", emplid))
                                                            .Add(Expression.Eq("WeekBegin", beginDate))
                                                            .Add(Expression.Eq("WeekEnd", endDate))
                                                            .UniqueResult<EmployeeWeekTimeRecording>();
                                                    }
                                                );

            return entity;
        }

        public List<EmployeeWeekTimeRecording> GetEmployeesWeekState(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeWeekTimeRecording> res = new List<EmployeeWeekTimeRecording>();
            HibernateTemplate.Execute(
                delegate(ISession session)
                    {
                        session.CreateCriteria(typeof (EmployeeWeekTimeRecording))
                            .Add(Expression.In("EmployeeID", emplids))
                            .Add(Expression.Eq("WeekBegin", beginDate))
                            .Add(Expression.Eq("WeekEnd", endDate))
                            .List(res);
                        return null;
                    }
                );

            return res;
        }
        public List<EmployeeWeekTimeRecording> GetEmployeesWeekStateByDateRange(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeWeekTimeRecording> res = new List<EmployeeWeekTimeRecording>();
            if (emplids != null && emplids.Length > 0)
            {
                HibernateTemplate.Execute(
                    delegate(ISession session)
                    {
                        ICriteria criteria = session.CreateCriteria(typeof(EmployeeWeekTimeRecording));
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
        public List<EmployeeWeekTimeRecording> GetEmployeeWeekStateByDateRange(long emplid, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeWeekTimeRecording> res = new List<EmployeeWeekTimeRecording>();
            HibernateTemplate.Execute(
                delegate(ISession session)
                {
                    session.CreateCriteria(typeof(EmployeeWeekTimeRecording))
                        .Add(Expression.Eq("EmployeeID", emplid))
                        .Add(Expression.Ge("WeekBegin", beginDate))
                        .Add(Expression.Lt("WeekBegin", endDate))
                        .AddOrder (Order.Asc ("WeekBegin"))
                        .List(res);
                    return null;
                }
                );

            return res;
        }
        public void SaveEmployeeWeek(EmployeeWeek planningweek)
        {
            if (planningweek == null)
                throw new ArgumentNullException();

            EmployeeWeekTimeRecording entity = GetEmployeeWeekState(planningweek.EmployeeId, planningweek.BeginDate,planningweek.EndDate );

            if (entity == null)
                entity = new EmployeeWeekTimeRecording();

            EmployeeWeekProcessor.AssignTo(entity, planningweek);

            SaveOrUpdate(entity);

            //planningweek.ID = entity.ID;
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
            EmployeeWeekTimeRecording entity = GetEmployeeWeekState(emplid, beginDate, endDate);
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

            List<EmployeeWeekTimeRecording> entities = GetEmployeesWeekState(emplids, beginDate, endDate);
            if (entities != null)
            {
                weeks = new List<EmployeeWeek>();
                foreach (EmployeeWeekTimeRecording entity in entities)
                {
                    week = new EmployeeWeek(entity);
                    weeks.Add(week);//EmployeeWeekProcessor.Assign(entity, week));
                }
            }

            return weeks;
        }

        public EmployeeWeekTimeRecording GetLastWeek(long emplid)
        {
            EmployeeWeekTimeRecording res = null;
            HibernateTemplate.Execute(
                delegate(ISession session)
                {
                    res = session.CreateCriteria(typeof(EmployeeWeekTimeRecording))
                        .Add(Expression.Eq("EmployeeID", emplid))
                        .AddOrder (Order.Desc ("WeekBegin"))
                        //.SetProjection (Projections.Max ("WeekBegin"))
                        .SetMaxResults (1)
                        .UniqueResult<EmployeeWeekTimeRecording>();
                    return res;
                }
                );

            return res;
        }

        public EmployeeWeekTimeRecording GetLastWeek(long emplid, DateTime date)
        {
            EmployeeWeekTimeRecording res = null;
            HibernateTemplate.Execute(
                delegate(ISession session)
                {
                    res = session.CreateCriteria(typeof(EmployeeWeekTimeRecording))
                        .Add(Expression.Eq("EmployeeID", emplid))
                        .Add (Expression.Lt("WeekBegin", date))
                        .AddOrder(Order.Desc("WeekBegin"))
                        .SetMaxResults(1)
                        .UniqueResult<EmployeeWeekTimeRecording>();
                    return res;
                }
                );

            return res;
        }


        public List<EmployeeWeekTimeRecording> LoadAllFromDateSorted(DateTime monday)
        {
            Debug.Assert(monday.DayOfWeek == DayOfWeek.Monday);

            List<EmployeeWeekTimeRecording> entities = new List<EmployeeWeekTimeRecording>();

            HibernateTemplate.Execute(
                    delegate(ISession session)
                    {
                        session.CreateCriteria(typeof(EmployeeWeekTimeRecording))
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