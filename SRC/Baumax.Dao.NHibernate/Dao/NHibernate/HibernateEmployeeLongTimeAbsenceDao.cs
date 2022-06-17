using Baumax.Domain;
using System.Collections;
using System;
using NHibernate;
using System.Collections.Generic;
using NHibernate.Expression;
using Baumax.Contract;

namespace Baumax.Dao.NHibernate
{
    public class HibernateEmployeeLongTimeAbsenceDao : HibernateDao<EmployeeLongTimeAbsence>,
                                                       IEmployeeLongTimeAbsenceDao
    {
        public List<EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsence(long storeid, DateTime aBegin, DateTime aEnd)
        {
            string s =
                @"select distinct absen.* from Employee_LongTimeAbsence absen, Employee_Relations rel WHERE 
                        rel.StoreID=:sid AND NOT(rel.BeginTime>:etime OR rel.EndTime<:stime) AND
                        rel.EmployeeID = absen.EmployeeID AND
                        NOT(absen.BeginTime>:etime2 OR absen.EndTime<:stime2)
                        ORDER BY EmployeeID ASC ,BeginTime ASC
                        ";

            List<EmployeeLongTimeAbsence> res = new List<EmployeeLongTimeAbsence>();

            HibernateTemplate.Execute(delegate(ISession session)
                                          {
                                              session.CreateSQLQuery(s)
                                                  .AddEntity("absen", typeof (EmployeeLongTimeAbsence))
                                                  .SetDateTime("stime", aBegin)
                                                  .SetDateTime("stime2", aBegin)
                                                  .SetDateTime("etime", aEnd)
                                                  .SetDateTime("etime2", aEnd)
                                                  .SetInt64("sid", storeid)
                                                  .List(res);
                                              return null;
                                          }
                );

            return res;
        }

        public List<EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsence2(long storeid, DateTime aBegin,
                                                                             DateTime aEnd)
        {
            // return all intersect for all store(but need apply storeid)
            /*
            ICriteria criteria = Session.CreateCriteria(typeof(EmployeeLongTimeAbsence));
            criteria.Add(Expression.Not(Expression.Or(Expression.Gt("BeginTime", aEnd),
                                                  Expression.Lt("EndTime", aBegin))));

            criteria.AddOrder(Order.Asc("EmployeeID")).AddOrder(Order.Asc("BeginTime"));
            IList lst = criteria.//List();
            return EmployeeLongTimeAbsenceProcessor.ToTypedList(lst);*/
            return GetTypedListFromIList(
                FindByNamedParam(null,
                                 " NOT ( (entity.BeginTime > :a_end) OR (entity.EndTime < :a_begin) ) ",
                                 " ORDER BY EmployeeID, BeginTime ",
                                 new string[] {"a_end", "a_begin"},
                                 new object[] {aEnd, aBegin}));
        }


        public Dictionary<long, EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsenceAsDiction(long storeid,
                                                                                                 DateTime aBegin,
                                                                                                 DateTime aEnd)
        {
            List<EmployeeLongTimeAbsence> lst = GetEmployeesHasLongTimeAbsence(storeid, aBegin, aEnd);
            //IList lst = GetEmployeesHasLongTimeAbsence2(storeid, aBegin, aEnd);

            int iCount = (lst != null) ? lst.Count : 0;

            Dictionary<long, EmployeeLongTimeAbsence> result = new Dictionary<long, EmployeeLongTimeAbsence>(iCount);

            EmployeeLongTimeAbsence entity = null;
            for (int i = 0; i < iCount; i++)
            {
                entity = lst[i];
                result[entity.ID] = entity;
            }
            return result;
        }


        public List<EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsence(long[] emplids, DateTime aBegin, DateTime aEnd)
        {
            if (emplids == null || emplids.Length == 0) 
                return null;

            List<EmployeeLongTimeAbsence> res = new List<EmployeeLongTimeAbsence>();

            HibernateTemplate.Execute(delegate(ISession session)
                                          {
                                              session.CreateCriteria(typeof (EmployeeLongTimeAbsence))
                                                  .Add(Expression.In("EmployeeID", emplids))
                                                  .Add(Expression.Not(
                                                           Expression.Or(
                                                               Expression.Gt("BeginTime", aEnd),
                                                               Expression.Lt("EndTime", aBegin)
                                                               )
                                                           )
                                                  )
                                                  .List(res);
                                              return null;
                                          }
                );

            return res;
        }
    }
}