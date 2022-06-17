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
    public class HibernateAbsenceTimeRecordingDao : HibernateDao<AbsenceTimeRecording>, IAbsenceTimeRecordingDao
    {
        #region IAbsenceTimeRecordingDao Members
        public List<AbsenceTimeRecording> GetCountryHolidayTimeRecordingsBetweenDate(long countryid, DateTime beginDate, DateTime endDate)
        {
            Debug.Assert(beginDate <= endDate);
            
            string squery = @"select _absences from AbsenceTimeRecording _absences, Store st, Employee empl, Absence absn
                            WHERE  _absences.Date BETWEEN '{1}' AND '{2}' AND _absences.EmployeeID=empl.id AND 
                            _absences.AbsenceID=absn.id AND absn.AbsenceTypeID=2 AND 
                            empl.MainStoreID=st.id AND st.CountryID={0} ORDER BY _absences.EmployeeID, _absences.Date";// + countyid);

            string sql = String.Format(squery, countryid, DateTimeSql.DateToSqlString(beginDate), DateTimeSql.DateToSqlString(endDate));

            List<AbsenceTimeRecording> result = (List<AbsenceTimeRecording>)HibernateTemplate.Execute(
                                       delegate(ISession session)
                                       {
                                            IQuery query = Session.CreateQuery (sql);

                                            IList lst = query.List();


                                            return GetTypedListFromIList (lst);
                                       }
                                    );
            return result;
        }


        public List<AbsenceTimeRecording> GetAbsenceTimeRecordingsByEmployeeIds(long[] employeeIDs, DateTime beginDate, DateTime endDate)
        {
            Debug.Assert(beginDate <= endDate);

            if (employeeIDs == null || employeeIDs.Length == 0)
                return null;

            IList result = (IList)HibernateTemplate.Execute(delegate(ISession session)
                 {

                     ICriteria criteria = session.CreateCriteria(typeof(AbsenceTimeRecording));

                     if (employeeIDs.Length == 1)
                     {
                         criteria.Add(Expression.Eq("EmployeeID", employeeIDs[0]));
                     }
                     else
                     {
                         criteria.Add(Expression.In("EmployeeID", employeeIDs));
                     }

                     criteria.Add(Expression.Between("Date", beginDate, endDate));

                     return criteria.List();
                 }
                                       );

            if ((result == null) || (result.Count == 0))
            {
                return null;
            }

            return GetTypedListFromIList(result);
            //if ((employeeIDs == null) || (employeeIDs.Length == 0))
            //{
            //    return null;
            //}

            //List<string> pNames = new List<string>();
            //List<object> pValues = new List<object>();

            //StringBuilder hql = new StringBuilder(" entity.Date >= :begin_date AND entity.Date <= :end_date ");
            //pNames.Add("begin_date");
            //pValues.Add(beginDate);

            //pNames.Add("end_date");
            //pValues.Add(endDate);

            //string ids = QueryUtils.GenIDList(employeeIDs, pNames, pValues);
            //if ((ids != null) && (ids.Length > 0))
            //{
            //    hql.AppendFormat(" AND entity.EmployeeID IN ({0}) ", ids);
            //}

            //IList result = FindByNamedParam(hql.ToString(), pNames.ToArray(), pValues.ToArray());

            //if ((result == null) || (result.Count == 0))
            //{
            //    return null;
            //}
            
            //return GetTypedListFromIList (result);
        }

        //public IList SetAbsenceTimeRecordings(long[] employeeIDs, List<AbsenceTimeRecording> absenceTimeRecordings,
        //                                      DateTime beginDate, DateTime endDate)
        //{
        //    if ((employeeIDs == null) || (employeeIDs.Length == 0))
        //    {
        //        return null;
        //    }

        //    IList itemsToDelete = GetAbsenceTimeRecordingsByEmployeeIds(employeeIDs, beginDate, endDate);
        //    if (itemsToDelete != null)
        //    {
        //        DeleteList(itemsToDelete);
        //    }

        //    if (absenceTimeRecordings == null)
        //    {
        //        return null;
        //    }

        //    for (int i = 0; i < absenceTimeRecordings.Count; i++)
        //    {
        //        if(absenceTimeRecordings[i].ID < 0)
        //        {
        //            absenceTimeRecordings[i].ID = 0;
        //        }
        //        absenceTimeRecordings[i] = SaveOrUpdate(absenceTimeRecordings[i]);
        //    }

        //    return absenceTimeRecordings;
        //}

        public List<AbsenceTimeRecording> SetAbsenceTimeRecordings(long[] employeeIDs, List<AbsenceTimeRecording> absenceTimeRecordings,
                                              DateTime beginDate, DateTime endDate)
        {
            if ((employeeIDs == null) || (employeeIDs.Length == 0))
            {
                return null;
            }

            IList itemsToDelete = GetAbsenceTimeRecordingsByEmployeeIds(employeeIDs, beginDate, endDate);

            List<AbsenceTimeRecording> originalList = GetTypedListFromIList(itemsToDelete);
            List<AbsenceTimeRecording> newList = null;
            if (originalList == null)
                originalList = new List<AbsenceTimeRecording>();

            newList = absenceTimeRecordings;
            if (newList == null)
                newList = new List<AbsenceTimeRecording>();

            Dictionary<long, AbsenceTimeRecording> dict = new Dictionary<long, AbsenceTimeRecording>();

            foreach (AbsenceTimeRecording entity in originalList)
                dict[entity.ID] = entity;

            bool bExistEntity = false;
            foreach (AbsenceTimeRecording newentity in newList)
            {
                bExistEntity = false;
                // search exists entity 
                foreach (AbsenceTimeRecording entity in originalList)
                {
                    if (entity.EmployeeID == newentity.EmployeeID &&
                        entity.Date == newentity.Date &&
                        entity.Begin == newentity.Begin &&
                        entity.End == newentity.End &&
                        entity.AbsenceID == newentity.AbsenceID &&
                        entity.Time == newentity.Time)
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
            foreach (AbsenceTimeRecording entity in newList)
            {
                if (entity.ID <= 0)
                    throw new ArgumentException();
            }
#endif

            if (dict.Count > 0)
            {
                foreach (AbsenceTimeRecording entity in dict.Values)
                {
                    DeleteByID(entity.ID);
                }
            }



            return absenceTimeRecordings;
        }

        public List<AbsenceTimeRecording> GetAbsenceTimeByEmployeeId(long employeeId, DateTime beginDate, DateTime endDate)
        {
            Debug.Assert(beginDate <= endDate);

            IList result = (IList) HibernateTemplate.Execute(
                                       delegate(ISession session)
                                           {
                                               return
                                                   session.CreateCriteria(typeof (AbsenceTimeRecording))
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

        private void DeleteAbsenceTimeRange(long emplid, DateTime beginDate, DateTime endDate)
        {
            IList result = GetAbsenceTimeByEmployeeId(emplid, beginDate, endDate);
            if (result != null)
            {
                DeleteList(result);
            }
        }

        public void SaveEmployeeWeek(EmployeeWeek week)
        {
            if (week != null)
            {
                DeleteAbsenceTimeRange(week.EmployeeId, week.BeginDate, week.EndDate);
                List<AbsenceTimeRecording> lst = new List<AbsenceTimeRecording>();
                AbsenceTimeRecording entity = null;
                foreach (EmployeeDay ed in week.DaysList)
                {
                    if (ed.TimeList != null)
                    {
                        foreach (EmployeeTimeRange range in ed.TimeList)
                        {
                            if (range.AbsenceID > 0)
                            {
                                entity = new AbsenceTimeRecording();
                                range.AssignTo(entity);
                                lst.Add(entity);
                            }
                        }
                    }
                }

                if (lst.Count > 0)
                {
                    foreach (AbsenceTimeRecording entity1 in lst)
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