using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using NHibernate;
using NHibernate.Expression;
using System;

namespace Baumax.Dao.NHibernate
{
    public class HibernateBenchmarkDao : HibernateDao<Benchmark>, IBenchmarkDao
    {
        #region IBenchmarkDao Members

        public IList GetBenchmarkFiltered(long storeID, short? yearFrom, short? yearTo)
        {
            StringBuilder sb =
                new StringBuilder(" entity.StoreWorldID = sw.ID AND sw.StoreID = :store_id ");
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();
            pNames.Add("store_id");
            pValues.Add(storeID);
            if (yearFrom.HasValue)
            {
                sb.Append(" AND entity.Year >= :year_from ");
                pNames.Add("year_from");
                pValues.Add(yearFrom.Value);
            }
            if (yearTo.HasValue)
            {
                sb.Append(" AND entity.Year <= :year_to ");
                pNames.Add("year_to");
                pValues.Add(yearTo.Value);
            }

            IList list = FindByNamedParam("StoreToWorld sw", sb.ToString(), pNames.ToArray(), pValues.ToArray());
            if ((list != null) && (list.Count == 0))
            {
                return null;
            }
            return list;
        }

        public Benchmark GetBenchmark(long storeworldID, short year)
        {
            IList result = (IList) HibernateTemplate.Execute(delegate(ISession session)
                                                                 {
                                                                     return session.CreateCriteria(typeof (Benchmark))
                                                                         .Add(Expression.Eq("StoreWorldID", storeworldID))
                                                                         .Add(Expression.Eq("Year", year))
                                                                         .List();
                                                                 }
                                       );

            if (result == null || result.Count == 0) 
                return null;

            return (Benchmark)result[0];
        }
        public List<Benchmark> GetBenchmarkByStoreWorld(long storeworldID)
        {
            //string query = String.Format("select pmm.* from Benchmark pmm where pmm.Store_WorldID={0} ORDER BY Year", storeworldID);

            return (List<Benchmark>)HibernateTemplate.Execute(delegate(ISession session)
                {
                    return GetTypedListFromIList(session.CreateCriteria(typeof(Benchmark))
                                                                         .Add(Expression.Eq("StoreWorldID", storeworldID))
                                                                         .AddOrder(Order.Asc("Year"))
                                                                         .List());
                }
            );
        }
        #endregion
    }
}