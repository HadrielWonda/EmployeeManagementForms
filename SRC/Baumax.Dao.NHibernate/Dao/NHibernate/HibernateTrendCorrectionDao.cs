using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Dao.NHibernate
{
    public class HibernateTrendCorrectionDao : HibernateDao<TrendCorrection>, ITrendCorrectionDao
    {
        #region ITrendCorrectionDao Members

        public IList GetTrendCorrectionFiltered(long storeID, System.DateTime? dateFrom, System.DateTime? dateTo)
        {
            StringBuilder sb =
                new StringBuilder("entity.StoreWorldID = sw.ID AND sw.StoreID = :store_id ");
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();
            pNames.Add("store_id");
            pValues.Add(storeID);
            if (dateFrom.HasValue)
            {
                sb.Append(" AND entity.EndTime >= :from_date ");
                pNames.Add("from_date");
                pValues.Add(dateFrom.Value);
            }
            if (dateTo.HasValue)
            {
                sb.Append(" AND entity.BeginTime <= :to_date ");
                pNames.Add("to_date");
                pValues.Add(dateTo.Value);
            }

            IList list = FindByNamedParam("StoreToWorld sw", sb.ToString(), pNames.ToArray(), pValues.ToArray());
            if ((list != null) && (list.Count == 0))
            {
                return null;
            }
            return list;
        }

        #endregion
    }
}