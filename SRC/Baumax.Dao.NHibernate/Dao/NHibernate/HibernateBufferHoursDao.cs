using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using NHibernate;
using NHibernate.Expression;
using System;

namespace Baumax.Dao.NHibernate
{
    public class HibernateBufferHoursDao : HibernateDao<BufferHours>, IBufferHoursDao
    {
        #region IBufferHoursDao Members

        public IList GetBufferHoursFiltered(long storeID, short? yearFrom, short? yearTo)
        {
            StringBuilder sb =
                new StringBuilder("entity.StoreWorldID = sw.ID AND sw.StoreID = :store_id ");
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
        public BufferHours GetBufferHours(long storeworldID, short year)
        {
            IList result = (IList) HibernateTemplate.Execute(delegate(ISession session)
                                                                 {
                                                                     return session.CreateCriteria(typeof (BufferHours))
                                                                         .Add(Expression.Eq("StoreWorldID", storeworldID))
                                                                         .Add(Expression.Eq("Year", year))
                                                                         .List();
                                                                 }
                                       );

            if (result == null || result.Count == 0) return null;

            return (BufferHours)result[0];
        }


        public List<BufferHours> GetBufferHours(long storeworldID)
        {
            //string query = "SELECT {_buffer.*} FROM BufferHours {_buffer} where _buffer.Store_WorldID=:sw_id ORDER BY _buffer.Year";

            //return (List<BufferHours>)HibernateTemplate.Execute(delegate(ISession session)
            //    {
            //        return GetTypedListFromIList(session.CreateSQLQuery(query).AddEntity("_buffer", typeof(BufferHours)).SetInt64("sw_id", storeworldID).List());
            //    }
            //);
            return (List<BufferHours>)HibernateTemplate.Execute(delegate(ISession session)
                {
                    return GetTypedListFromIList(session.CreateCriteria(typeof(BufferHours))
                                                                             .Add(Expression.Eq("StoreWorldID", storeworldID))
                                                                             .AddOrder(Order.Asc("Year"))
                                                                             .List());
                }
            );
        }
        #endregion
    }
}