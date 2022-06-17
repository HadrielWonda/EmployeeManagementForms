using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Expression;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;
using NHibernate;

namespace Baumax.Dao.NHibernate
{
    public class HibernateEmployeeDayStateRecordingDao : HibernateDao<EmployeeDayStateRecording>, IEmployeeDayStateRecordingDao
    {
        public List<EmployeeDayStateRecording> GetEmployeesStates(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeDayStateRecording> states = new List<EmployeeDayStateRecording>();

            if (emplids != null && emplids.Length > 0)
            {
                HibernateTemplate.Execute(delegate(ISession session)
                                              {
                                                  session.CreateCriteria(typeof (EmployeeDayStateRecording))
                                                      .Add(Expression.In("EmployeeID", emplids))
                                                      .Add(Expression.Between("Date", beginDate, endDate))
                                                      .AddOrder(Order.Asc("EmployeeID"))
                                                      .List(states);
                                                  return null;
                                              }
                    );
            }

            return states;

        }
        public List<EmployeeDayStateRecording> GetEmployeeStates(long emplid, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeDayStateRecording> states = new List<EmployeeDayStateRecording>();

            HibernateTemplate.Execute(delegate(ISession session)
                                          {
                                              session.CreateCriteria(typeof(EmployeeDayStateRecording))
                                                  .Add(Expression.Eq("EmployeeID", emplid))
                                                  .Add(Expression.Between("Date", beginDate, endDate))
                                                  .AddOrder(Order.Asc("Date"))
                                                  .List(states);
                                              return null;
                                          }
                );
            return states;
        }


        public EmployeeDayStateRecording GetEmployeesState(long emplid, DateTime date)
        {
            EmployeeDayStateRecording res = (EmployeeDayStateRecording)HibernateTemplate.Execute(
                delegate(ISession session)
                    {
                        return session.CreateCriteria(typeof (EmployeeDayStateRecording))
                            .Add(Expression.Eq("EmployeeID", emplid))
                            .Add(Expression.Eq("Date", date))
                            .UniqueResult<EmployeeDayStateRecording>();
                    }
                );

            return res;
        }

        public List<EmployeeDay> GetEmployeeDayStates(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeDayStateRecording> states = GetEmployeesStates(emplids, beginDate, endDate);

            return EmployeeDayProcessor.ConvertFrom(states);
        }

        public int GetWorkingHoursByMonth(long employeeid, DateTime date)
        {
            DateTime beginMonth = new DateTime(date.Year, date.Month, 1);
            DateTime endMonth = date.AddMonths(1).AddDays(-1);

            List<EmployeeDayStateRecording> states = new List<EmployeeDayStateRecording>();

            HibernateTemplate.Execute(delegate(ISession session)
                                          {
                                              session.CreateCriteria(typeof (EmployeeDayStateRecording))
                                                  .Add(Expression.Eq("EmployeeID", employeeid))
                                                  .Add(Expression.Between("Date", beginMonth, endMonth))
                                                  .List(states);
                                              return null;
                                          }
                );

            int result = 0;
            foreach (EmployeeDayStateRecording edsp in states)
            {
                result += edsp.AllreadyPlannedHours;
            }
            return result;
        }

        public void SaveEmployeeDay(EmployeeDay employeeday)
        {
            if (employeeday == null)
                throw new ArgumentNullException();

            EmployeeDayStateRecording entity = GetEmployeesState(employeeday.EmployeeId, employeeday.Date);

            bool bNeedSave = EmployeeDayProcessor.IsNeedSave(employeeday);
            if (bNeedSave )
            {
                if (entity == null)
                {
                    entity = EmployeeDayProcessor.CreateRecordingEntity(employeeday);
                }
                else
                    EmployeeDayProcessor.AssignToRecording(entity, employeeday);

                SaveOrUpdate(entity);
                //employeeday.ID = entity.ID;
            }
            else
            {
                if (entity != null)
                    DeleteByID(entity.ID);
            }
        }

        public void SaveEmployeeWeeks(List<EmployeeWeek> planningweeks)
        {
            foreach (EmployeeWeek epw in planningweeks)
            {
                foreach (EmployeeDay epd in epw.DaysList)
                {
                    SaveEmployeeDay(epd);
                }
            }
        }
    }
}