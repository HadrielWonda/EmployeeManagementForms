using System;
using System.Collections.Generic;
using System.Text;

using Baumax.Domain;
using System.Collections;
using NHibernate;
using NHibernate.Expression;
using Baumax.Contract;

namespace Baumax.Dao.NHibernate
{
    public class HibernateEmployeeAllInDao : HibernateDao<EmployeeAllIn>, IEmployeeAllInDao
    {

        public List<EmployeeAllIn> GetEntitiesByEmployee(long emplid, DateTime? aBegin, DateTime? aEnd)
        {

            List<EmployeeAllIn> resultList = (List<EmployeeAllIn>)HibernateTemplate.Execute(delegate(ISession session)
                {
                    ICriteria criteria = session.CreateCriteria(typeof(EmployeeAllIn));
                    criteria.Add(Expression.Eq("EmployeeID", emplid));

                    if (aBegin.HasValue && aEnd.HasValue)
                    {
                        criteria.Add(Expression.Not(
                                         Expression.Or(
                                                       Expression.Gt("BeginTime", aEnd.Value ),
                                                       Expression.Lt("EndTime", aBegin.Value))));

                    }
                    else
                        if (aBegin.HasValue)
                        {
                            criteria.Add(Expression.Le("BeginTime", aBegin.Value));
                            criteria.Add(Expression.Ge("EndTime", aBegin.Value));
                        }


                    criteria.AddOrder(Order.Asc("BeginTime"));

                    return criteria.List < EmployeeAllIn>();
                }
            );

            return resultList;
        }
        public List<EmployeeAllIn> GetEntitiesByEmployees(long[] emplids, DateTime? aBegin, DateTime? aEnd)
        {

            if (emplids == null || emplids.Length == 0) return null;

            IList resultList = (IList)HibernateTemplate.Execute(delegate(ISession session)
                {
                    ICriteria criteria = session.CreateCriteria(typeof(EmployeeAllIn));
                    criteria.Add(Expression.In("EmployeeID", emplids));

                    if (aBegin.HasValue && aEnd.HasValue)
                    {
                        criteria.Add(Expression.Not(
                                         Expression.Or(
                                                       Expression.Gt("BeginTime", aEnd.Value),
                                                       Expression.Lt("EndTime", aBegin.Value))));

                    }
                    else
                        if (aBegin.HasValue)
                        {
                            criteria.Add(Expression.Le("BeginTime", aBegin.Value));
                            criteria.Add(Expression.Ge("EndTime", aBegin.Value));
                        }


                    criteria.AddOrder(Order.Asc("BeginTime"));

                    return criteria.List();
                }
            );

            return GetTypedListFromIList(resultList);
        }

        public List<EmployeeAllIn> GetEntitiesByStoreAndRelation(long storeid, DateTime? aBegin, DateTime? aEnd)
        {

            IList resultList = (IList)HibernateTemplate.Execute(delegate(ISession session)
                {
                    

                    string hql = string.Empty;
                    if (aBegin.HasValue && aEnd.HasValue)
                    {
                        string sQuery = @"SELECT _allin from EmployeeAllIn _allin, EmployeeRelation rel where
                                rel.StoreID={0} AND NOT(rel.BeginTime>'{2}' OR rel.EndTime<'{1}') AND _allin.EmployeeID=rel.EmployeeID 
                                AND NOT(_allin.BeginTime>'{2}' OR _allin.EndTime<'{1}') ORDER BY _allin.EmployeeID, _allin.BeginTime 
                                ";
                        hql = string.Format(sQuery, storeid, DateTimeSql.DateToSqlString(aBegin.Value), DateTimeSql.DateToSqlString(aEnd.Value));

                        
                        
                    }
                    else if (aBegin.HasValue)
                    {
                        string sQuery = @"SELECT _allin from EmployeeAllIn _allin, EmployeeRelation rel where
                                rel.StoreID={0} AND rel.BeginTime<='{1}' AND '{1}' <= rel.EndTime  AND _allin.EmployeeID=rel.EmployeeID 
                                AND _allin.BeginTime<='{1}' AND '{1}' <= _allin.EndTime ORDER BY _allin.EmployeeID, _allin.BeginTime 
                                ";

                        hql = string.Format(sQuery, storeid, DateTimeSql.DateToSqlString(aBegin.Value));
                        
                    }
                    else
                    {

                        string sQuery = @"SELECT _allin from EmployeeAllIn _allin, Employee empl where
                                empl.MainStoreID={0} AND empl.id = _allin.EmployeeID ORDER BY _allin.EmployeeID, _allin.BeginTime 
                                ";
                        hql = string.Format(sQuery, storeid);
                    }
                    return session.CreateQuery(hql).List();

                    

                }
            );

            return GetTypedListFromIList(resultList);
        }
        public List<EmployeeAllIn> GetEntitiesByStore(long storeid, DateTime? aBegin, DateTime? aEnd)
        {

            IList resultList = (IList)HibernateTemplate.Execute(delegate(ISession session)
                {
                    string sQuery = @"SELECT _allin from EmployeeAllIn _allin,Employee empl where
                                empl.MainStoreID=:storeid  AND empl.id=_allin.EmployeeID AND NOT(_allin.BeginTime>:etime1 OR _allin.EndTime<:stime1) ORDER BY _allin.EmployeeID, _allin.BeginTime 
                                ";
                    if (aBegin.HasValue && aEnd.HasValue)
                    {
                        return session.CreateQuery(sQuery)
                                      //.AddEntity("_allin", typeof(EmployeeAllIn))
                                      .SetInt64("storeid", storeid)
                                      .SetDateTime("etime1", aEnd.Value)
                                      .SetDateTime("stime1", aBegin.Value)
                                      .List();
                    }
                    else if (aBegin.HasValue)
                    {
                        sQuery = @"SELECT _allin from EmployeeAllIn _allin, Employee empl where
                                empl.MainStoreID=:storeid AND _allin.EmployeeID=empl.id 
                                AND _allin.EndTime >=:stime ORDER BY _allin.EmployeeID, _allin.BeginTime 
                                ";
                        return session.CreateQuery(sQuery)
                                      //.AddEntity("_allin", typeof(EmployeeAllIn))
                                      .SetInt64("storeid", storeid)
                                      .SetDateTime("stime", aBegin.Value)
                                      .List();
                    }

                    sQuery = @"SELECT _allin from EmployeeAllIn _allin, Employee empl where
                                empl.MainStoreID=:storeid AND empl.id = _allin.EmployeeID ORDER BY _allin.EmployeeID, _allin.BeginTime 
                                ";
                    return session.CreateQuery(sQuery)
                                  //.AddEntity("_allin", typeof(EmployeeAllIn))
                                  .SetInt64("storeid", storeid)
                                  .List();


                }
            );

            return GetTypedListFromIList(resultList);
        }
        public List<EmployeeAllIn> GetEntitiesByCountry(long countryid, DateTime? aBegin, DateTime? aEnd)
        {

            IList resultList = (IList)HibernateTemplate.Execute(delegate(ISession session)
                {
                    string sQuery = @"SELECT _allin from EmployeeAllIn _allin, Employee empl, Store st where
                                st.CountryID=:cid AND
                                empl.MainStoreID=st.id AND _allin.EmployeeID=empl.id 
                                AND NOT(_allin.BeginTime>:etime OR _allin.EndTime<:stime) ORDER BY _allin.EmployeeID, _allin.BeginTime 
                                ";
                    if (aBegin.HasValue && aEnd.HasValue)
                    {
                        return session.CreateQuery(sQuery)
                                      //.AddEntity("_allin", typeof(EmployeeAllIn))
                                      .SetInt64("cid", countryid)
                                      .SetDateTime("etime", aEnd.Value)
                                      .SetDateTime("stime", aBegin.Value)
                                      .List();
                    }
                    else if (aBegin.HasValue)
                    {
                        sQuery = @"SELECT _allin from EmployeeAllIn _allin, Employee empl, Store st where
                                st.CountryID=:cid AND
                                empl.MainStoreID=st.id AND _allin.EmployeeID=empl.id 
                                AND _allin.BeginTime <= :stime AND _allin.EndTime>=:stime1 ORDER BY _allin.EmployeeID, _allin.BeginTime 
                                ";
                        return session.CreateQuery(sQuery)
                                      //.AddEntity("_allin", typeof(EmployeeAllIn))
                                      .SetInt64("cid", countryid)
                                      .SetDateTime("stime", aBegin.Value)
                                      .SetDateTime("stime1", aBegin.Value)
                                      .List();
                    }

                    sQuery = @"SELECT _allin from EmployeeAllIn _allin, Employee empl, Store st where
                                st.CountryID=:cid AND 
                                empl.MainStoreID=st.id AND _allin.EmployeeID=empl.id ORDER BY _allin.EmployeeID, _allin.BeginTime 
                                ";
                    return session.CreateQuery(sQuery)
                                  //.AddEntity("_allin", typeof(EmployeeAllIn))
                                  .SetInt64("cid", countryid)
                                  .List();


                }
            );

            return GetTypedListFromIList(resultList);
        }

        public List<EmployeeAllIn> GetAllEntitiesSorted()
        {

            List<EmployeeAllIn> lst = new List<EmployeeAllIn>(10000);

            
            HibernateTemplate.Execute(delegate(ISession session)
                {
                    string sQuery = @"SELECT allin from EmployeeAllIn allin ORDER BY allin.EmployeeID, allin.BeginTime";

                    session.CreateQuery(sQuery).List (lst);
                    return null;
                }
            );
            
            return lst;
        }


    }
}
