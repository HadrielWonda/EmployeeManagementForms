using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Dao;
using Baumax.Domain;
using NHibernate.Expression;
using Spring.Transaction.Interceptor;
using Baumax.Contract;
using Baumax.Contract.TimePlanning;
using System.Diagnostics;
using NHibernate;

namespace Baumax.Dao.NHibernate
{
    public class HibernateWorkingTimeRecordingDao : HibernateDao<WorkingTimeRecording>, IWorkingTimeRecordingDao
    {
        #region IWorkingTimeRecordingDao Members

        public List<WorkingTimeRecording> GetWorkingTimeByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate)
        {
            Debug.Assert(beginDate <= endDate);

            IList result = (IList)HibernateTemplate.Execute(
                                       delegate(ISession session)
                                       {
                                           return session.CreateCriteria(typeof(WorkingTimeRecording))
                                               .Add(Expression.Eq("EmployeeID", employeeId))
                                               .Add(Expression.Ge("Date", beginDate))
                                               .Add(Expression.Le("Date", endDate))
                                               .AddOrder (Order.Asc ("Date"))
                                               .List();
                                       }
                                       );


            return GetTypedListFromIList(result); ;
        }

        public IList GetWorkingTimeRecordingsByEmployeeIds(long[] employeeIDs, DateTime beginDate, DateTime endDate)
        {
            if ((employeeIDs == null) || (employeeIDs.Length == 0))
            {
                return null;
            }

            /*IList result = Session.CreateCriteria(typeof(WorkingTimeRecording))
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

        public IList SetWorkingTimeRecordings(long[] employeeIDs, List<WorkingTimeRecording> workingTimeRecordings,
                                              DateTime beginDate, DateTime endDate)
        {
            if ((employeeIDs == null) || (employeeIDs.Length == 0))
            {
                return null;
            }

            IList itemsToDelete = GetWorkingTimeRecordingsByEmployeeIds(employeeIDs, beginDate, endDate);
            if (itemsToDelete != null)
            {
                DeleteList(itemsToDelete);
            }

            if (workingTimeRecordings == null)
            {
                return null;
            }

            for (int i = 0; i < workingTimeRecordings.Count; i++)
            {
                if (workingTimeRecordings[i].ID < 0)
                {
                    workingTimeRecordings[i].ID = 0;
                }
                workingTimeRecordings[i] = SaveOrUpdate(workingTimeRecordings[i]);
            }

            return workingTimeRecordings;
        }

        private void DeleteWorkingTimeRange(long emplid, DateTime beginDate, DateTime endDate)
        {
            IList result = GetWorkingTimeRecordingsByEmployeeIds(new long[] { emplid }, beginDate, endDate);
            if (result != null)
            {
                DeleteList(result);
            }
        }

        public void SaveEmployeeWeek(EmployeeWeek week)
        {
            if (week != null)
            {
                DeleteWorkingTimeRange(week.EmployeeId, week.BeginDate, week.EndDate);
                List<WorkingTimeRecording> lst = new List<WorkingTimeRecording>();
                WorkingTimeRecording entity = null;
                foreach (EmployeeDay ed in week.DaysList)
                {
                    if (ed.TimeList != null)
                    {
                        foreach (EmployeeTimeRange range in ed.TimeList)
                        {
                            if (range.AbsenceID <= 0)
                            {
                                entity = new WorkingTimeRecording();
                                range.AssignTo(entity);
                                lst.Add(entity);
                            }
                        }
                    }
                }

                if (lst.Count > 0)
                {
                    foreach (WorkingTimeRecording entity1 in lst)
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
        #endregion
    }
}
