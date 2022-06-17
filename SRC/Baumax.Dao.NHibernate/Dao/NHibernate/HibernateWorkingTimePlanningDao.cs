using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Baumax.Dao;
using Baumax.Domain;
using Baumax.Contract;
using NHibernate;
using Spring.Transaction.Interceptor;
using NHibernate.Expression;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;


namespace Baumax.Dao.NHibernate
{
    public class HibernateWorkingTimePlanningDao: HibernateDao<WorkingTimePlanning>, IWorkingTimePlanningDao
    {
        #region IWorkingTimePlanningDao Members

        public IList GetWorkingTimePlanningsByEmployeeIds(long[] employeeIDs, DateTime beginDate, DateTime endDate)
        {
            if ((employeeIDs == null) || (employeeIDs.Length == 0))
            {
                return null;
            }

            /*
            IList result = Session.CreateCriteria(typeof(WorkingTimePlanning))
                .Add(Expression.Ge("Date", beginDate))
                .Add(Expression.Le("Date", endDate))
                .Add(Expression.In("EmployeeID", employeeIDs))
                .//List();*/

            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();
            StringBuilder hql = new StringBuilder(" entity.Date >= :begin_date AND entity.Date <= :end_date ");
            pNames.Add("begin_date");
            pValues.Add(beginDate);
            pNames.Add("end_date");
            pValues.Add(endDate);
            string ids = QueryUtils.GenIDList(employeeIDs, pNames, pValues);
            if ((ids != null) && (ids.Length > 0))
            {
                hql.AppendFormat(" AND entity.EmployeeID IN ({0}) ", ids);
            }
            IList result = FindByNamedParam(hql.ToString(), pNames.ToArray(), pValues.ToArray());

            if ((result == null) || (result.Count == 0))
            {
                return null;
            }
            return result;
        }

        public IList SetWorkingTimePlannings(long[] employeeIDs, List<WorkingTimePlanning> workingTimePlannings,
                                              DateTime beginDate, DateTime endDate)
        {
            if ((employeeIDs == null) || (employeeIDs.Length == 0))
            {
                return null;
            }

            IList itemsToDelete = GetWorkingTimePlanningsByEmployeeIds(employeeIDs, beginDate, endDate);
            if (itemsToDelete != null)
            {
                DeleteList(itemsToDelete);
            }

            if (workingTimePlannings == null)
            {
                return null;
            }

            for (int i = 0; i < workingTimePlannings.Count; i++)
            {
                if (workingTimePlannings[i].ID < 0)
                {
                    workingTimePlannings[i].ID = 0;
                }
                workingTimePlannings[i] = SaveOrUpdate(workingTimePlannings[i]);
            }

            return workingTimePlannings;
        }

        #endregion


        public List<WorkingTimePlanning> GetWorkingTimeByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate)
        {
            Debug.Assert(beginDate <= endDate);

            IList result = (IList) HibernateTemplate.Execute(
                                       delegate(ISession session)
                                           {
                                               return session.CreateCriteria(typeof (WorkingTimePlanning))
                                                   .Add(Expression.Eq("EmployeeID", employeeId))
                                                   .Add(Expression.Ge("Date", beginDate))
                                                   .Add(Expression.Le("Date", endDate))
                                                   .List();
                                           }
                                       );


            return GetTypedListFromIList(result); ;
        }

        public IList SetWorkingTimeByEmployeeId(long employeeID, List<WorkingTimePlanning> workingTimePlannings,
                                              DateTime beginDate, DateTime endDate)
        {
            if (employeeID <=0 )
            {
                return null;
            }

            DeleteWorkingTimeRange(employeeID, beginDate, endDate);

            if (workingTimePlannings != null)
            {
                for (int i = 0; i < workingTimePlannings.Count; i++)
                {
                    workingTimePlannings[i].ID = 0;
                    workingTimePlannings[i] = SaveOrUpdate(workingTimePlannings[i]);
                }
            }

            return workingTimePlannings;
        }

        /*private void DeleteWorkingTime(long emplid, DateTime date)
        {
            IList result = Session.CreateCriteria(typeof(WorkingTimePlanning))
            .Add(Expression.Eq("EmployeeID", emplid))
            .Add(Expression.Eq ("Date", date))
            .List();
            if (result != null)
            {
                DeleteList(result);
            }
        }*/

        private void DeleteWorkingTimeRange(long emplid, DateTime beginDate, DateTime endDate)
        {
            IList result = GetWorkingTimeByEmployeeId(emplid, beginDate, endDate);
            if (result != null)
            {
                DeleteList(result);
            }
        }

        public void SetWeekWorkingTimePlanning(List<EmployeePlanningWeek> planningweeks)
        {
            if (planningweeks == null || planningweeks.Count == 0) return;

            foreach (EmployeePlanningWeek epw in planningweeks)
            {
                foreach (EmployeePlanningDay epd in epw.Days.Values)
                {
                    SetWorkingTimeByEmployeeId(epd.EmployeeId, epd.WorkingTimeList, epd.Date, epd.Date);
                }
            }
        }

        public void SaveEmployeeWeek(EmployeeWeek week)
        {
            if (week != null)
            {
                DeleteWorkingTimeRange(week.EmployeeId, week.BeginDate, week.EndDate);
                List<WorkingTimePlanning> lst = new List<WorkingTimePlanning>();
                WorkingTimePlanning entity = null;
                foreach (EmployeeDay ed in week.DaysList)
                {
                    if (ed.TimeList != null)
                    {
                        foreach (EmployeeTimeRange range in ed.TimeList)
                        {
                            if (range.AbsenceID <= 0)
                            {
                                entity = new WorkingTimePlanning();
                                range.AssignTo (entity);
                                entity.ID = 0;
                                lst.Add(entity);
                            }
                        }
                    }
                }

                if (lst.Count > 0)
                {
                    foreach (WorkingTimePlanning entity1 in lst)
                    {
                        SaveOrUpdate(entity1);
                    }
                }
            }
        }

        public void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks)
        {
            if (lstWeeks != null && lstWeeks.Count > 0)
            {
                foreach (EmployeeWeek week in lstWeeks)
                    SaveEmployeeWeek(week);
            }
        }

        public List<WorkingTimePlanning> GetEntitiesByStoreRelation(long storeid, DateTime begin, DateTime end)
        {
            //(((employeere1_.BeginTime<='20080210' ))and(('20080204'<=employeere1_.EndTime )))
            string query = @"select entity from WorkingTimePlanning entity, EmployeeRelation relations
                                where entity.Date between '{1}' and '{2}' and
                            entity.EmployeeID=relations.EmployeeID and 
                            relations.StoreID={0} and 
                            NOT((relations.BeginTime>'{2}') OR (relations.EndTime<'{1}'))";

            string hql = string.Format(query, storeid, DateTimeSql.DateToSqlString(begin), DateTimeSql.DateToSqlString(end));

            return GetTypedListFromIList(HibernateTemplate.FindByNamedParam(hql, new string[] { }, new object[] { }));
        }
    }

    
}
