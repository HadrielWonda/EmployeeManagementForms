using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using System.Collections;
using System;
using NHibernate;
using NHibernate.Expression;
using Baumax.Contract;
using System.Diagnostics;

namespace Baumax.Dao.NHibernate
{
    public class HibernateEmployeeRelationDao : HibernateDao<EmployeeRelation>, IEmployeeRelationDao
    {

        public List<EmployeeRelation> LoadAllSorted()
        {
            IList result = (IList)HibernateTemplate.Execute(delegate(ISession session)
                                         {
                                             ICriteria criteria = session.CreateCriteria(typeof(EmployeeRelation));
                                             criteria.AddOrder(Order.Asc("EmployeeID"));
                                             criteria.AddOrder(Order.Asc("BeginTime"));
                                             return criteria.List();
                                         }

                                         );
            return GetTypedListFromIList(result);
        }

        public List<EmployeeRelation> GetEmployeeRelations(long emplid)
        {
            IList result = (IList)HibernateTemplate.Execute(delegate(ISession session)
                                         {
                                             ICriteria criteria = session.CreateCriteria(typeof(EmployeeRelation));
                                             criteria.Add(Expression.Eq("EmployeeID", emplid));
                                             criteria.AddOrder(Order.Asc("BeginTime"));
                                             return criteria.List();
                                         }
                   
                                         );
            return GetTypedListFromIList(result);
        }

        public List<EmployeeRelation> GetEmployeeRelations(long storeid, DateTime aBegin, DateTime aEnd)
        {

            IList result =
                (IList)HibernateTemplate
                            .Execute(delegate(ISession session)
                                         {
                                             ICriteria criteria =
                                                 session.CreateCriteria(typeof(EmployeeRelation));

                                             criteria.Add(Expression.Eq("StoreID", storeid));

                                             criteria.Add(Expression.Not(
                                                              Expression.Or(
                                                                  Expression.Gt("BeginTime", aEnd),
                                                                  Expression.Lt("EndTime", aBegin))));
                                             criteria.AddOrder(Order.Asc("EmployeeID")).AddOrder(Order.Asc("BeginTime"));
                                             return criteria.List();
                                         }
                            );
            return GetTypedListFromIList(result);
        }

        public List<EmployeeRelation> GetEmployeeRelationsByStore(long storeid, DateTime? aBegin, DateTime? aEnd)
        {
            IList result =
                (IList)HibernateTemplate
                            .Execute(delegate(ISession session)
                                         {
                                             ICriteria criteria =
                                                 session.CreateCriteria(typeof(EmployeeRelation));

                                             criteria.Add(Expression.Eq("StoreID", storeid));

                                             if (aEnd.HasValue && aBegin.HasValue)
                                             {
                                                 criteria.Add(Expression.Not(
                                                                  Expression.Or(
                                                                      Expression.Gt("BeginTime", aEnd),
                                                                      Expression.Lt("EndTime", aBegin))));
                                             }
                                             else
                                             {
                                                 if (aBegin.HasValue)
                                                 {
                                                     criteria
                                                         .Add(Expression.Le("BeginTime", aBegin))
                                                         .Add(Expression.Ge("EndTime", aBegin));
                                                 }
                                             }
                                             criteria.AddOrder(Order.Asc("EmployeeID")).AddOrder(Order.Asc("BeginTime"));
                                             return criteria.List();
                                         }
                            );
            return GetTypedListFromIList(result);
            
        }

        public List<EmployeeRelation> GetEmployeeRelationsByStoreAndWorld(long storeid, long worldid, DateTime? aBegin, DateTime? aEnd)
        {
            IList result =
                (IList) HibernateTemplate
                            .Execute(delegate(ISession session)
                                         {
                                             ICriteria criteria =
                                                 session.CreateCriteria(typeof (EmployeeRelation));

                                             criteria.Add(Expression.Eq("StoreID", storeid));

                                             if (worldid > 0)
                                                 criteria.Add(Expression.Eq("WorldID", worldid));

                                             if (aEnd.HasValue && aBegin.HasValue)
                                             {
                                                 criteria.Add(Expression.Not(
                                                                  Expression.Or(
                                                                      Expression.Gt("BeginTime", aEnd),
                                                                      Expression.Lt("EndTime", aBegin))));
                                             }
                                             else
                                             {
                                                 if (aBegin.HasValue)
                                                 {
                                                     criteria
                                                         .Add(Expression.Le("BeginTime", aBegin))
                                                         .Add(Expression.Ge("EndTime", aBegin));
                                                 }
                                             }
                                             criteria.AddOrder(Order.Asc("EmployeeID")).AddOrder(Order.Asc("BeginTime"));
                                             return criteria.List();
                                         }
                            );
            return GetTypedListFromIList(result);
        }

        public List<EmployeeRelation> GetEmployeeRelationsByEmployeeIds(long[] emplIds, DateTime aBegin, DateTime aEnd)
        {

            if (emplIds == null || emplIds.Length == 0) 
                return null;

            List<EmployeeRelation> lst = new List<EmployeeRelation>();

            HibernateTemplate.Execute(delegate(ISession session)
                                         {
                                             ICriteria criteria =
                                                 session.CreateCriteria(typeof(EmployeeRelation));


                                             criteria.Add(Expression.In("EmployeeID", emplIds));
                                             criteria.Add(Expression.Not(
                                                                        Expression.Or(
                                                                                    Expression.Gt("BeginTime", aEnd),
                                                                                    Expression.Lt("EndTime", aBegin))));
                                             criteria.AddOrder (Order.Asc ("EmployeeID")).AddOrder (Order.Asc ("BeginTime"));
                                             criteria.List(lst);
                                             return null;
                                         }
                            );
            if (lst.Count == 0) 
                lst = null;

            return lst; 
        }

        public List<EmployeeRelation> GetEmployeeRelationsByEmployeeIds(long[] emplIds)
        {
            if (emplIds == null || emplIds.Length == 0)
                return null;

            List<EmployeeRelation> lst = new List<EmployeeRelation>();

            HibernateTemplate.Execute(delegate(ISession session)
                                         {
                                             ICriteria criteria =
                                                 session.CreateCriteria(typeof(EmployeeRelation));

                                             if (emplIds.Length == 1)
                                                 criteria.Add(Expression.Eq("EmployeeID", emplIds[0]));
                                             else
                                                criteria.Add(Expression.In("EmployeeID", emplIds));

                                             criteria.AddOrder(Order.Asc("EmployeeID")).AddOrder(Order.Asc("BeginTime"));

                                             criteria.List(lst);
                                             return null;
                                         }
                            );

            if (lst.Count == 0)
                lst = null;

            return lst;
        }
        public List<EmployeeRelation> GetEmployeeRelationsByEmployeeId(long emplId, DateTime aBegin, DateTime aEnd)
        {

            IList result = (IList)HibernateTemplate.Execute(delegate(ISession session)
                                         {
                                             ICriteria criteria = session.CreateCriteria(typeof(EmployeeRelation));


                                             criteria.Add(Expression.Eq("EmployeeID", emplId));
                                             criteria.Add(Expression.Not(
                                                                        Expression.Or(
                                                                                    Expression.Gt("BeginTime", aEnd),
                                                                                    Expression.Lt("EndTime", aBegin)
                                                                                    )
                                                                         )
                                                          );
                                             criteria.AddOrder(Order.Asc("EmployeeID")).AddOrder(Order.Asc("BeginTime"));
                                             return criteria.List();
                                         }
                            );
            return GetTypedListFromIList(result);
        }

        public List<EmployeeRelation>  GetEmployeeRelationByCountryId(long countryid)
        {

            string hql = @"SELECt entity FROM EmployeeRelation entity, Employee empl, Store stores 
                            WHERE empl.id=entity.EmployeeID AND empl.MainStoreID=stores.id AND
                             stores.CountryID={0} order by entity.EmployeeID asc, entity.BeginTime asc";


            hql = String.Format(hql, countryid);

            return GetTypedListFromIList(HibernateTemplate.FindByNamedParam(hql, new string[] { }, new object[] { }));

        }

        // return all relation of employees where Employee.MainStoreID=storeid and found into begin and end date-range
        // need for absence planning
        public List<EmployeeRelation> GetEmployeeRelationByMainStore(long storeid, DateTime begin, DateTime end)
        {

            Debug.Assert(storeid > 0);
            Debug.Assert(DateTimeHelper.Between(begin, DateTimeSql.SmallDatetimeMin, DateTimeSql.SmallDatetimeMax));
            Debug.Assert(DateTimeHelper.Between(end, DateTimeSql.SmallDatetimeMin, DateTimeSql.SmallDatetimeMax));

            begin = DateTimeSql.CheckSmallMinMax(begin);
            end = DateTimeSql.CheckSmallMinMax(end);


            string template_hql = @"select relation from EmployeeRelation relation, Employee empl where
                            empl.MainStoreID={0} and empl.id=relation.EmployeeID
                            and NOT((relation.BeginTime>'{2}') OR (relation.EndTime<'{1}')) 
                             order by relation.EmployeeID asc, relation.BeginTime asc";

            string hql = string.Format(template_hql, storeid, DateTimeSql.DateToSqlString(begin), DateTimeSql.DateToSqlString(end));

            IList list = HibernateTemplate.FindByNamedParam(hql, new string[] { }, new object[] { });

            if (list == null || list.Count == 0) return null;

            return GetTypedListFromIList(list);
        }
    }
}