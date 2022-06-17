using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Expression;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;
using Baumax.Domain;

namespace Baumax.Dao.NHibernate
{
    public class HibernateEmployeeDayStatePlanningDao : HibernateDao<EmployeeDayStatePlanning>, IEmployeeDayStatePlanningDao
    {
        
        public void SaveEmployeePlanningDay(EmployeePlanningDay planningday)
        {
            EmployeeDayStatePlanning state = GetEmployeesState(planningday.EmployeeId, planningday.Date);

            if (!planningday.IsBlockedDay)
            {
                if (state == null)
                {
                    state = new EmployeeDayStatePlanning();
                    state.EmployeeID = planningday.EmployeeId;
                    state.Date = planningday.Date;
                }
                state.WorkingHours = planningday.CountDailyWorkingHours;
                state.AllreadyPlannedHours = planningday.CountDailyPlannedWorkingHours;
                state.EmplBalanceHours = 0;
                state.PlusMinusHours = 0;
                state.SumOfAddHours = planningday.CountDailyAdditionalCharges;
                state.StoreWorldId = planningday.WorldId;

                SaveOrUpdate(state);

            }
            else
            {
                if (state != null) DeleteByID(state.ID);
            }
        }

        public void SaveEmployeePlanningWeeks(List<EmployeePlanningWeek> planningweeks)
        {
            foreach (EmployeePlanningWeek epw in planningweeks)
            {
                foreach (EmployeePlanningDay epd in epw.Days.Values)
                {
                    SaveEmployeePlanningDay(epd);
                }
            }
        }

        public EmployeeDayStatePlanning GetEmployeesState(long emplid, DateTime date)
        {
            EmployeeDayStatePlanning result =
                (EmployeeDayStatePlanning) HibernateTemplate.
                                               Execute(delegate(ISession session)
                                                           {
                                                               return
                                                                   session.
                                                                       CreateCriteria(
                                                                       typeof (EmployeeDayStatePlanning))
                                                                       .Add(Expression.Eq("EmployeeID", emplid))
                                                                       .Add(Expression.Eq("Date", date))
                                                                       .UniqueResult<EmployeeDayStatePlanning>();
                                                           }
                                               );
            return result;
        }

        public List<EmployeeDayStatePlanning> GetEmployeesStates(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeDayStatePlanning> states = new List<EmployeeDayStatePlanning>();
            
            if (emplids != null && emplids.Length > 0)
            {
                HibernateTemplate.Execute(delegate(ISession session)
                                              {
                                                  session.CreateCriteria(typeof (EmployeeDayStatePlanning))
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
        public List<EmployeeDayStatePlanning> GetEmployeeStates(long emplid, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeDayStatePlanning> states = new List<EmployeeDayStatePlanning>();

                HibernateTemplate.Execute(delegate(ISession session)
                                              {
                                                  session.CreateCriteria(typeof(EmployeeDayStatePlanning))
                                                      .Add(Expression.Eq("EmployeeID", emplid))
                                                      .Add(Expression.Between("Date", beginDate, endDate))
                                                      .AddOrder(Order.Asc("Date"))
                                                      .List(states);
                                                  return null;
                                              }
                    );

            return states;

        }

        public List<EmployeeDay> GetEmployeeDayStates(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeDayStatePlanning> states = GetEmployeesStates(emplids, beginDate, endDate);

            return EmployeeDayProcessor.ConvertFrom(states);
        }

        public int GetWorkingHoursByMonth(long employeeid, DateTime date)
        {
            DateTime beginMonth = new DateTime(date.Year, date.Month ,1);
            DateTime endMonth = date.AddMonths(1).AddDays(-1);

            List<EmployeeDayStatePlanning> states = new List<EmployeeDayStatePlanning>();

            HibernateTemplate.Execute(delegate(ISession session)
                                          {
                                              session.CreateCriteria(typeof (EmployeeDayStatePlanning))
                                                  .Add(Expression.Eq("EmployeeID", employeeid))
                                                  .Add(Expression.Between("Date", beginMonth, endMonth))
                                                  .List(states);
                                              return null;
                                          }
                );

            int result = 0;
            foreach (EmployeeDayStatePlanning edsp in states)
            {
                result += edsp.AllreadyPlannedHours;
            }
            return result;
        }

        public void SaveEmployeeDay(EmployeeDay planningday)
        {
            if (planningday == null)
                throw new ArgumentNullException();

            EmployeeDayStatePlanning entity = GetEmployeesState(planningday.EmployeeId, planningday.Date);

            bool bNeedSave = EmployeeDayProcessor.IsNeedSave(planningday);

            if (bNeedSave)
            {
                bool bModified = false;

                if (entity == null)
                {
                    entity = EmployeeDayProcessor.CreatePlanningEntity(planningday);
                }
                else
                {
                    if (!EmployeeDayProcessor.IsEqual(entity, planningday))
                    {

                        EmployeeDayProcessor.AssignToPlanning(entity, planningday);
                        bModified = true;
                    }
                }
                if (entity.IsNew || bModified )
                    SaveOrUpdate(entity);

                //planningday.ID = entity.ID;
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

        private bool IsNeedSave(EmployeePlanningDay employeeday)
        {
            if (employeeday == null)
                throw new ArgumentNullException();

            bool bNeedSave = false;

            bNeedSave = employeeday.HasContract & !employeeday.HasLongAbsence & employeeday.HasRelation;

            return bNeedSave;
        }
        
    }
}