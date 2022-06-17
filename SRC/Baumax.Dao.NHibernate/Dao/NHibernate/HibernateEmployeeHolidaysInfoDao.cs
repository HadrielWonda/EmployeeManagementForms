using System.Collections;
using Baumax.Domain;
using NHibernate;
using Baumax.Contract.QueryResult;
using System.Collections.Generic;
using Baumax.Contract;
using System;
using NHibernate.Expression;

namespace Baumax.Dao.NHibernate
{
    public class HibernateEmployeeHolidaysInfoDao : HibernateDao<EmployeeHolidaysInfo>, IEmployeeHolidaysInfoDao
    {
        #region IEmployeeHolidaysInfoDao Members

        #region need rewrite and remove

        public void DeleteAllForEmployee(long employeeID)
        {
            HibernateTemplate.Delete("FROM EmployeeHolidaysInfo entity WHERE entity.EmployeeID = ?", employeeID,
                                     NHibernateUtil.Int64);
        }

        public EmployeeHolidaysInfo SaveOrUpdateForEmployee(Employee employee, int currentYear)
        {
            //IList currentHolidays = FindByNamedParam(" EmployeeID=:empID AND Year=:year ",
            //                                         new string[] {"empID", "year"},
            //                                         new object[] {employee.ID, currentYear});
            EmployeeHolidaysInfo entity = GetEntity(employee.ID, currentYear);
            if (entity == null)
            {
              entity = new EmployeeHolidaysInfo();
              entity.EmployeeID = employee.ID;
              entity.Year = (short)currentYear;
            }
            //EmployeeHolidaysInfo entity = (currentHolidays == null || currentHolidays.Count == 0)
            //                                  ? new EmployeeHolidaysInfo()
            //                                  : (EmployeeHolidaysInfo) currentHolidays[0];
            
            entity.NewHolidays = employee.NewHolidays;
            entity.OldHolidays = employee.OldHolidays;
            entity.UsedHolidays = employee.UsedHolidays;
            entity.CalculateSpareHolidays();

            return SaveOrUpdate(entity);
        }


        public List<EmployeeDayTimeResult> GetEmployeeCoefficints(long storeid, int year)
        {
            List<WeekSource> weeks = WeekManager.GetYearMap(year);
            DateTime begin = weeks[0].Monday,
                     end = weeks[weeks.Count - 1].Sunday;

            List<EmployeeDayTimeResult> emplCoefficents = new List<EmployeeDayTimeResult>();

            string query = "exec sp_EmployeeHoursDayGet :year, :storeID, :begin, :end";

            HibernateTemplate.Execute(
                delegate(ISession session)
                {
                    session.CreateSQLQuery(query)
                        .AddEntity(typeof(EmployeeDayTimeResult))
                        .SetParameter("year", year)
                        .SetParameter("storeID", storeid)
                        .SetParameter("begin", begin.ToString("yyyMMdd"))
                        .SetParameter("end", end.ToString("yyyMMdd"))
                        .List(emplCoefficents);
                    return null;
                });
            
            return emplCoefficents;
        }


        public List<EmployeeHolidaysInfo> RecalculateWithLastYear(int year)
        {
            List<WeekSource> weeks = WeekManager.GetYearMap(year);
            DateTime begin = weeks[0].Monday,  end = weeks[weeks.Count - 1].Sunday;

            return new List<EmployeeHolidaysInfo>();
        }

        #endregion

        public EmployeeHolidaysInfo GetEntity(long emplid, int Year)
        {
            EmployeeHolidaysInfo entity = (EmployeeHolidaysInfo)HibernateTemplate.Execute(
                delegate(ISession session)
                {
                    return session.CreateQuery("select info from EmployeeHolidaysInfo info where info.EmployeeID=:emplid and info.Year=:year")
                                .SetInt64("emplid", emplid)
                                .SetInt16 ("year", (short)Year)
                                .UniqueResult <EmployeeHolidaysInfo>();

                });

            return entity;
        }

        public List<EmployeeHolidaysInfo> GetEntities(long emplid)
        {

            List<EmployeeHolidaysInfo> entities = 
                GetTypedListFromIList(
                    (IList)HibernateTemplate.Execute(
                        delegate(ISession session)
                        {
                            return session.CreateQuery("select info from EmployeeHolidaysInfo info where info.EmployeeID=:emplid order by info.Year")
                                .SetInt64("emplid", emplid)
                                .List ();

                        }
                        )
                        );

            return entities;
        }

        public List<EmployeeHolidaysInfo> GetEntities(long[] emplids, int year)
        {

            if (emplids == null || emplids.Length == 0) return null;

            List<EmployeeHolidaysInfo> entities =
                GetTypedListFromIList(
                    (IList)HibernateTemplate.Execute(
                        delegate(ISession session)
                        {
                            //ICriteria criteria = session.CreateCriteria(typeof(EmployeeHolidaysInfo));

                            //return criteria.Add(Expression.Eq("Year", (short)year))
                            //.Add(Expression.In("EmployeeID", emplids))
                            //.List();

                            string hql = String.Format("select info from EmployeeHolidaysInfo info where info.EmployeeID IN {0} AND info.Year=(1)", QueryUtils.GetINString (emplids), year);
                            return session.CreateQuery(hql)
                                .List();
                        }
                        )
                        );

            return entities;
        }

        public List<EmployeeHolidaysInfo> GetEntitiesByStore(long storeid, int year)
        {

            if (storeid < 0) return null;

            string hql = @"select info from EmployeeHolidaysInfo info, Employee empl where info.Year=:year and info.EmployeeID=empl.id and empl.MainStoreID=:stid";

            List<EmployeeHolidaysInfo> entities =
                GetTypedListFromIList(
                    (IList)HibernateTemplate.Execute(
                        delegate(ISession session)
                        {

                            return session.CreateQuery(hql)
                                .SetInt64("stid", storeid)
                                .SetInt16("year", (short)year)
                                .List();
                        }
                        )
                        );

            return entities;
        }
        public List<EmployeeHolidaysInfo> GetEntitiesByCountry(long countryid, int year)
        {
            if (countryid < 0) return null;

            string hql = @"select info from EmployeeHolidaysInfo info, Employee empl, Store store where info.Year=:year and info.EmployeeID=empl.id and empl.MainStoreID=store.id and store.CountryID=:ctid";

            List<EmployeeHolidaysInfo> entities =
                GetTypedListFromIList(
                    (IList)HibernateTemplate.Execute(
                        delegate(ISession session)
                        {

                            return session.CreateQuery(hql)
                                .SetInt64("ctid", countryid)
                                .SetInt16("year", (short)year)
                                .List();
                        }
                        )
                        );

            return entities;
        }
        #endregion

    }
}
