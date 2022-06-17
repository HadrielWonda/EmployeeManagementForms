using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract;
using Baumax.Dao;
using Baumax.Domain;
using Spring.Transaction.Interceptor;
using Baumax.Contract.QueryResult;
using NHibernate.Expression;
using System.Diagnostics;
using Baumax.Contract.TimePlanning;
using NHibernate;

namespace Baumax.Dao.NHibernate
{/*
  * don't need check access to this entity
  * 
  */
    public class HibernateAbsenceTimePlanningDao : HibernateDao<AbsenceTimePlanning>, IAbsenceTimePlanningDao
    {
        #region IAbsenceTimePlanningDao Members
        
        public List<AbsenceTimePlanning> GetAbsenceTimePlanningsByEmployeeIds(long[] employeeIDs, DateTime beginDate, DateTime endDate)
        {

            Debug.Assert(beginDate <= endDate);

            if (employeeIDs == null || employeeIDs.Length == 0)
                return null;

            IList result = (IList)HibernateTemplate.Execute(delegate(ISession session)
                 {

                     ICriteria criteria = session.CreateCriteria(typeof(AbsenceTimePlanning));

                     if (employeeIDs.Length == 1)
                     {
                         criteria.Add(Expression.Eq("EmployeeID", employeeIDs[0])); 
                     }
                     else
                     {
                         criteria.Add(Expression.In("EmployeeID", employeeIDs));
                     }

                     criteria.Add (Expression.Between ("Date", beginDate, endDate ));

                     return criteria.List ();
                 }
                                       );

            if ((result == null) || (result.Count == 0))
            {
                return null;
            }

            return GetTypedListFromIList(result);
            
        }

        public List<AbsenceTimePlanning> GetAbsenceTimeByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate)
        {
            Debug.Assert(beginDate <= endDate);
            IList result = (IList) HibernateTemplate.Execute(delegate(ISession session)
                                                                 {
                                                                     return
                                                                         session.CreateCriteria(
                                                                             typeof (AbsenceTimePlanning))
                                                                             .Add(Expression.Eq("EmployeeID", employeeId))
                                                                             .Add(Expression.Ge("Date", beginDate))
                                                                             .Add(Expression.Le("Date", endDate))
                                                                             .List();
                                                                 }
                                       );

            if ((result == null) || (result.Count == 0))
            {
                return null;
            }
            return GetTypedListFromIList(result);
        }

        public List<AbsenceTimePlanning> SetAbsenceTimePlannings(long[] employeeIDs, List<AbsenceTimePlanning> absenceTimePlannings,
                                             DateTime beginDate, DateTime endDate)
        {

            if ((employeeIDs == null) || (employeeIDs.Length == 0))
            {
                return null;
            }

            IList itemsToDelete = GetAbsenceTimePlanningsByEmployeeIds(employeeIDs, beginDate, endDate);

            List<AbsenceTimePlanning> originalList = GetTypedListFromIList(itemsToDelete);
            List<AbsenceTimePlanning> newList = null;
            if (originalList == null)
                originalList = new List<AbsenceTimePlanning>();

            newList = absenceTimePlannings;
            if (newList == null)
                newList = new List<AbsenceTimePlanning>();

            Dictionary<long, AbsenceTimePlanning> dict = new Dictionary<long, AbsenceTimePlanning>();

            foreach (AbsenceTimePlanning entity in originalList)
                dict[entity.ID] = entity;

            bool bExistEntity = false;
            foreach (AbsenceTimePlanning newentity in newList)
            {
                bExistEntity = false;
                // search exists entity 
                foreach (AbsenceTimePlanning entity in originalList)
                {
                    if (entity.EmployeeID == newentity.EmployeeID &&
                        entity.Date == newentity.Date &&
                        entity.Begin == newentity.Begin &&
                        entity.End == newentity.End &&
                        entity.AbsenceID == newentity.AbsenceID)
                    {
                        //entity.AbsenceID = newentity.AbsenceID;
                        //entity.Begin = newentity.Begin;
                        //entity.End = newentity.End;
                        //entity.Time = newentity.Time;

                        //entity = SaveOrUpdate(entity);

                        newentity.ID = entity.ID;
                        bExistEntity = true;
                        dict.Remove(entity.ID);
                        break;
                    }
                }
                // if its new entity - create new entity
                if (!bExistEntity)
                {
                    newentity.ID = 0;
                    SaveOrUpdate(newentity);
                }

            }
#if DEBUG
            // checking
            foreach (AbsenceTimePlanning entity in newList)
            {
                if (entity.ID <= 0)
                    throw new ArgumentException();
            }
#endif

            if (dict.Count > 0)
            {
                foreach (AbsenceTimePlanning entity in dict.Values)
                {
                    DeleteByID(entity.ID);
                }
            }



            return absenceTimePlannings;
            //if ((employeeIDs == null) || (employeeIDs.Length == 0))
            //{
            //    return null;
            //}

            //IList itemsToDelete = GetAbsenceTimePlanningsByEmployeeIds(employeeIDs, beginDate, endDate);
            //if (itemsToDelete != null)
            //{
            //    DeleteList(itemsToDelete);
            //}

            //if (absenceTimePlannings == null)
            //{
            //    return null;
            //}

            //for (int i = 0; i < absenceTimePlannings.Count; i++)
            //{
            //    if (absenceTimePlannings[i].ID < 0)
            //    {
            //        absenceTimePlannings[i].ID = 0;
            //    }
            //    absenceTimePlannings[i] = SaveOrUpdate(absenceTimePlannings[i]);
            //}

            //return absenceTimePlannings;
        }

        public List<AbsenceTimePlanning> SetAbsenceTimeByEmployeeId(long employeeID, List<AbsenceTimePlanning> absenceTimePlannings,
                                              DateTime beginDate, DateTime endDate)
        {
            if (employeeID <= 0)
            {
                return null;
            }

            DeleteAbsenceTimeRange(employeeID, beginDate, endDate);

            if (absenceTimePlannings != null)
            {
                for (int i = 0; i < absenceTimePlannings.Count; i++)
                {
                    absenceTimePlannings[i].ID = 0;
                    absenceTimePlannings[i] = SaveOrUpdate(absenceTimePlannings[i]);
                }
            }

            return absenceTimePlannings;
        }

        public void DeleteAbsenceTimeRange(long emplid, DateTime beginDate, DateTime endDate)
        {
            IList result = GetAbsenceTimeByEmployeeId(emplid, beginDate, endDate);
            if (result != null)
            {
                DeleteList(result);
            }

        }

        public void SetWeekAbsenceTimePlanning(List<EmployeePlanningWeek> planningweeks)
        {
            if (planningweeks == null || planningweeks.Count == 0) return;
            List<AbsenceTimePlanning> list = new List<AbsenceTimePlanning>();
            foreach (EmployeePlanningWeek epw in planningweeks)
            {
                foreach (EmployeePlanningDay epd in epw.Days.Values)
                {
                    if (epd.AbsenceTimeList != null && epd.AbsenceTimeList.Count > 0)
                    {
                        list.AddRange(epd.AbsenceTimeList);
                        
                    }
                }
                SetAbsenceTimeByEmployeeId(epw.EmployeeId , list, epw.BeginDate , epw.EndDate);
                list.Clear();
            }
        }

        public void SaveEmployeeWeek(EmployeeWeek week)
        {
            if (week != null)
            {
                DeleteAbsenceTimeRange(week.EmployeeId, week.BeginDate, week.EndDate);
                List<AbsenceTimePlanning> lst = new List<AbsenceTimePlanning>();
                AbsenceTimePlanning entity = null;
                foreach (EmployeeDay ed in week.DaysList)
                {
                    if (ed.TimeList != null)
                    {
                        foreach (EmployeeTimeRange range in ed.TimeList)
                        {
                            if (range.AbsenceID > 0)
                            {
                                entity = new AbsenceTimePlanning();
                                range.AssignTo(entity);
                                lst.Add(entity);
                            }
                        }
                    }
                }

                if (lst.Count > 0)
                {
                    foreach (AbsenceTimePlanning entity1 in lst)
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


        public List<AbsenceTimePlanning> GetEntitiesByStoreRelation(long storeid, DateTime begin, DateTime end)
        {
            string query = @"select entity from AbsenceTimePlanning entity, EmployeeRelation relations
                                where entity.Date between '{1}' and '{2}' and
                            entity.EmployeeID=relations.EmployeeID and 
                            relations.StoreID={0} and 
                            NOT((relations.BeginTime>'{2}') OR (relations.EndTime<'{1}'))";

            string hql = string.Format(query, storeid, DateTimeSql.DateToSqlString(begin), DateTimeSql.DateToSqlString(end));

            return GetTypedListFromIList(HibernateTemplate.FindByNamedParam(hql, new string[] { }, new object[] { }));
        }
        #endregion
    }
}