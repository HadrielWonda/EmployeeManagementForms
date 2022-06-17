using System.Text;
using Baumax.Contract;
using Baumax.Domain;
using System.Collections.Generic;
using System;
using NHibernate;
using NHibernate.Expression;
using System.Collections;

namespace Baumax.Dao.NHibernate
{
    public class HibernateEmployeeContractDao : HibernateDao<EmployeeContract>, IEmployeeContractDao
    {
        public List<EmployeeContract> LoadAllSorted()
        {
            return GetTypedListFromIList((IList)HibernateTemplate.Execute(delegate(ISession session)
                                                                 {
                                                                     return
                                                                         session.CreateCriteria(typeof(EmployeeContract))
                                                                             .AddOrder(Order.Asc("EmployeeID"))
                                                                             .AddOrder(Order.Asc("ContractBegin"))
                                                                             .List();
                                                                 }
                                       ));
        }

        public List<EmployeeContract> GetEmployeeContracts(long[] emplids)
        {
            
            List<EmployeeContract> lst = new List<EmployeeContract>();
            if (emplids != null && emplids.Length > 0)
            {
                HibernateTemplate.Execute(delegate(ISession session)
                                                                 {
                                                                     ICriteria criteria = session.CreateCriteria(typeof(EmployeeContract));

                                                                     if (emplids.Length == 1)
                                                                         criteria.Add(Expression.Eq("EmployeeID", emplids[0]));
                                                                     else
                                                                         criteria.Add(Expression.In("EmployeeID", emplids));

                                                                     criteria.AddOrder(Order.Asc("EmployeeID"));
                                                                     criteria.AddOrder(Order.Asc("ContractBegin"));
                                                                     criteria.List(lst);
                                                                     return null;
                                                                 }
                                       );
            }
            return lst;
        }
        public List<EmployeeContract> GetEmployeeContracts(long emplid)
        {
            return GetTypedListFromIList((IList)HibernateTemplate.Execute(delegate(ISession session)
                                                                 {
                                                                     return
                                                                         session.CreateCriteria(typeof(EmployeeContract))
                                                                             .Add(Expression.Eq("EmployeeID", emplid))
                                                                             .AddOrder(Order.Asc("ContractBegin"))
                                                                             .List();
                                                                 }
                                       ));


        }

        public List<EmployeeContract> GetEmployeeContracts(long[] ids, DateTime dateBegin, DateTime dateEnd)
        {
            return GetTypedListFromIList( (IList)HibernateTemplate.Execute(delegate(ISession session)
                                                                 {
                                                                     return
                                                                         session.CreateCriteria(typeof (EmployeeContract))
                                                                             .Add(Expression.In("EmployeeID", ids))
                                                                             .Add(Expression.Not(
                                                                                      Expression.Or(
                                                                                          Expression.Gt("ContractBegin", dateEnd),
                                                                                          Expression.Lt("ContractEnd", dateBegin))))
                                                                             .AddOrder(Order.Asc("EmployeeID"))
                                                                             .AddOrder(Order.Asc("ContractBegin"))
                                                                             .List();
                                                                 }
                                       ));
            
        }
        public List<EmployeeContract> GetEmployeeContracts(long emplid, DateTime dateBegin, DateTime dateEnd)
        {
            return GetTypedListFromIList((IList)HibernateTemplate.Execute(delegate(ISession session)
                                                                 {
                                                                     return
                                                                         session.CreateCriteria(typeof(EmployeeContract))
                                                                             .Add(Expression.Eq("EmployeeID", emplid))
                                                                             .Add(Expression.Not(
                                                                                      Expression.Or(
                                                                                          Expression.Gt("ContractBegin", dateEnd),
                                                                                          Expression.Lt("ContractEnd", dateBegin))))
                                                                             .AddOrder(Order.Asc("ContractBegin"))
                                                                             .List();
                                                                 }
                                       ));

            
        }

        public List<EmployeeContract> GetEmployeeContractsByStore(long storeid)
        {
            List<EmployeeContract> lst = new List<EmployeeContract>();

            HibernateTemplate.Execute(delegate(ISession session)
                {
                    string sQuery = @"select contracts from EmployeeContract contracts, Employee empl 
                                            where 
                                      contracts.EmployeeID=empl.id AND 
                                      empl.MainStoreID = :storeid 
                                            order by 
                                      contracts.EmployeeID asc, contracts.ContractBegin asc";

                    IList<EmployeeContract> list = session.CreateQuery(sQuery)
                                  .SetInt64("storeid", storeid)
                                  .List<EmployeeContract>();

                    if (list != null)
                    {
                        lst.AddRange(list);
                    }
                    return null;
                }
            );

            return lst;

        }

        public List<EmployeeContract> GetEmployeeContractsByStore(long storeid, DateTime begin, DateTime end)
        {
            List<EmployeeContract> lst = null;

            HibernateTemplate.Execute(delegate(ISession session)
                {
                    string sQuery = @"select contracts 
                                        from 
                                     EmployeeContract contracts, 
                                     Employee empl 
                                        where 
                                      contracts.EmployeeID=empl.id AND 
                                      empl.MainStoreID = {0} AND
                                      NOT(contracts.ContractBegin > '{2}' OR contracts.ContractEnd < '{1}') 
                                    order by contracts.EmployeeID asc, contracts.ContractBegin asc";
                    
                    string hql = string.Format(sQuery, storeid, DateTimeSql.DateToSqlString(begin), DateTimeSql.DateToSqlString(end));

                    IList list = session.CreateQuery(hql).List();

                    lst = GetTypedListFromIList(list);

                    return null;
                }
            );

            return lst;

        }

        public List<EmployeeContract> GetEmployeeContractsByCountry(long countryid)
        {
            List<EmployeeContract> lst = new List<EmployeeContract>();

            HibernateTemplate.Execute(delegate(ISession session)
                {
                    string sQuery = @"select contracts from EmployeeContract contracts, Employee empl, Store st 
                                        where 
                                      contracts.EmployeeID=empl.id AND 
                                      empl.MainStoreID = st.id AND 
                                      st.CountryID=:countryid
                                        order by 
                                      contracts.EmployeeID asc, contracts.ContractBegin asc";

                    IList<EmployeeContract> list = session.CreateQuery(sQuery)
                                  .SetInt64("countryid", countryid)
                                  .List<EmployeeContract>();

                    if (list != null)
                    {
                        lst.AddRange(list);
                    }
                    return null;
                }
            );

            return lst;
        }

        public List<EmployeeContract> GetEmployeeContractsByCountry(long countryid, DateTime begin, DateTime end)
        {
            List<EmployeeContract> lst = new List<EmployeeContract>(1000);

            HibernateTemplate.Execute(delegate(ISession session)
                {
                    string sQuery = @"select contracts from EmployeeContract contracts, Employee empl, Store st 
                                        where 
                                      contracts.EmployeeID=empl.id AND 
                                      empl.MainStoreID = st.id AND 
                                      st.CountryID={0} AND
                                      NOT(contracts.ContractBegin>'{2}' OR contracts.ContractEnd<'{1}')
                                        order by 
                                      contracts.EmployeeID asc, contracts.ContractBegin asc";

                    string hql = string.Format (sQuery, countryid, DateTimeSql.DateToSqlString (begin),DateTimeSql.DateToSqlString (end));

                    session.CreateQuery(sQuery).List(lst);


                    //IList<EmployeeContract> list = session.CreateQuery(sQuery)
                    //              .SetInt64("countryid", countryid)
                    //              .List<EmployeeContract>();

                    //if (list != null)
                    //{
                    //    lst.AddRange(list);
                    //}
                    return null;
                }
            );

            return lst;
        }

        public List<EmployeeContract> GetEmployeeContractsByRelationStore(long storeid, DateTime begin, DateTime end)
        {
            string hql_template = @"select contracts from EmployeeContract contracts, EmployeeRelation relations where
                           contracts.EmployeeID=relations.EmployeeID and relations.StoreID={0} and
                           NOT(contracts.ContractBegin > '{2}' OR contracts.ContractEnd < '{1}') and
                           NOT((relations.BeginTime > '{2}') OR (relations.EndTime < '{1}')) 
                           order by contracts.EmployeeID asc, contracts.ContractBegin asc";

            string hql = string.Format(hql_template, storeid, DateTimeSql.DateToSqlString(begin), DateTimeSql.DateToSqlString(end));

            IList list = HibernateTemplate.FindByNamedParam(hql, new string[] { }, new object[] { });

            return GetTypedListFromIList(list);
        }

    }
}