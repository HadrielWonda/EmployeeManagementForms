using System.Collections;
using Baumax.Domain;
using NHibernate;
using NHibernate.Expression;
using System.Collections.Generic;
using System;

namespace Baumax.Dao.NHibernate
{
    public class HibernatePersonMinMaxDao : HibernateDao<PersonMinMax>, IPersonMinMaxDao
    {
        public IList GetPersonMinMaxFiltered(long storeID)
        {
            return
                FindByNamedParam("StoreToWorld sw", "entity.Store_WorldID = sw.ID AND sw.StoreID = :store_id", null,
                                 "store_id", storeID);
        }

        public IList GetPersonMinMaxFiltered(long storeid, int year)
        {
            return FindByNamedParam("StoreToWorld sw", "entity.Store_WorldID = sw.ID AND sw.StoreID = :store_id AND entity.Year=:year", null,
                                             new string[] { "store_id", "year" }, new object[] { storeid, year });
        }

        public PersonMinMax GetPersonMinMaxByStoreWorld(long storeworldID, int year)
        {
            PersonMinMax res = (PersonMinMax)HibernateTemplate.Execute(
                delegate(ISession session)
                    {
                        return session.CreateCriteria(typeof (PersonMinMax))
                            .Add(Expression.Eq("Store_WorldID", storeworldID))
                            .Add(Expression.Eq("Year", (short) year))
                            .UniqueResult<PersonMinMax>();
                    }
                );
            return res;
        }


        public List<PersonMinMax> GetPersonMinMaxByStoreWorld(long storeworldID)
        {
            //string query = String.Format("select pmm.* from PersonMinMax pmm where pmm.Store_WorldID={0} ORDER BY Year", storeworldID);

            return (List<PersonMinMax>)HibernateTemplate.Execute(delegate(ISession session)
                {
                    return GetTypedListFromIList(session.CreateCriteria(typeof (PersonMinMax))
                                                    .Add(Expression.Eq("Store_WorldID", storeworldID))
                                                    .AddOrder (Order .Asc ("Year"))
                                                    .List ()
                                                );
                }
            );
        }
    }
}