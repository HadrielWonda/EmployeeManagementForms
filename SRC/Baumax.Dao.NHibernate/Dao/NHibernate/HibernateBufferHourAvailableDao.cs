using Baumax.Domain;
using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Expression;
using System.Collections;
using System.Text;

namespace Baumax.Dao.NHibernate
{
    public class HibernateBufferHourAvailableDao : HibernateDao<BufferHourAvailable>, IBufferHourAvailableDao
    {
        #region IBufferHourAvailableDao Members
        public List<BufferHourAvailable> GetAvailableBufferHoursForYear(long storeworldid, int year)
        {
            string query = "entity.StoreWorldID={0} AND entity.Year={1}";

            query = String.Format(query, storeworldid, year);

            return GetTypedListFromIList(FindByNamedParam(query, new string[] { }, new object[] { }));
        }

        public List<BufferHourAvailable> GetAvailableBufferHours(long storeworldid, DateTime aBegin, DateTime aEnd)
        {
            return GetTypedListFromIList((IList)HibernateTemplate.Execute(delegate(ISession session)
                    {
                        ICriteria criteria = session.CreateCriteria(typeof(BufferHourAvailable));
                        criteria.Add(Expression.Eq("StoreWorldID", storeworldid));
                        criteria.Add(Expression.Between("WeekBegin", aBegin, aEnd));
                        criteria.AddOrder(Order.Asc("WeekBegin"));

                        return criteria.List();
                    }
                ));
        }
        
        public List<BufferHourAvailable> GetAvailableBufferHoursForStore(long storeid, DateTime aBegin, DateTime aEnd)
        {
            StringBuilder sb =
                 new StringBuilder("entity.StoreWorldID = sw.ID AND sw.StoreID = :store_id AND entity.WeekBegin <= :from_date  AND entity.WeekEnd <= :to_date");

            string[] pNames = new string[] { "store_id", "from_date", "to_date" };
            object[] pValues = new object[] { storeid, aBegin, aEnd };

            return GetTypedListFromIList(FindByNamedParam("StoreToWorld sw", sb.ToString(), pNames, pValues));

        }
        public List<BufferHourAvailable> GetAvailableBufferHoursForStore(long storeid, int year)
        {
            StringBuilder sb =  new StringBuilder();
            sb.AppendFormat ("entity.StoreWorldID = sw.ID AND sw.StoreID = {0} AND entity.Year = {1}", storeid, year);

            return GetTypedListFromIList(FindByNamedParam("StoreToWorld sw", sb.ToString(), null, null));

        }
        public BufferHourAvailable GetBufferHoursAvailable(long storeworldid, DateTime date)
        {
            StringBuilder sb =
                 new StringBuilder("entity.StoreWorldID = :storeworld_id AND entity.WeekBegin = :week_date");

            string[] pNames = new string[] { "storeworld_id", "week_date"};
            object[] pValues = new object[] { storeworldid, date };

            IList lst = FindByNamedParam(sb.ToString(), pNames, pValues);

            return (lst != null && lst.Count > 0) ? (BufferHourAvailable)lst[0] : null;

        }
        // from date to ,,,,
        public List<BufferHourAvailable> GetBufferHoursAvailableFrom(long storeworldid, DateTime date)
        {
            StringBuilder sb =
                 new StringBuilder("entity.StoreWorldID = :storeworld_id AND entity.WeekBegin >= :week_date");

            string[] pNames = new string[] { "storeworld_id", "week_date" };
            object[] pValues = new object[] { storeworldid, date };

            return GetTypedListFromIList(FindByNamedParam(sb.ToString(), pNames, pValues));
        }

        public void SaveOrUpdate2(BufferHourAvailable entity)
        {
            HibernateTemplate.SaveOrUpdate(entity);
        }
        #endregion
    }
}