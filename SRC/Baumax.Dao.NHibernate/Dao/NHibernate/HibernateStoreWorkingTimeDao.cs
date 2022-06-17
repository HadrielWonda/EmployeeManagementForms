using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Baumax.Contract;
using Baumax.Domain;
using NHibernate;
using NHibernate.Expression;

namespace Baumax.Dao.NHibernate
{
    public class HibernateStoreWorkingTimeDao : HibernateDao<StoreWorkingTime>, IStoreWorkingTimeDao
    {
        protected override PermittedIDsResult CreatePermittedIDFilter(List<string> pNames, List<object> pValues,
                                                                      bool bForReading, out string filterHQL, User user)
        {
            Debug.Assert((pNames != null) && (pValues != null),
                         "CreatePermittedIDFilter: impossible to store parameters");

            User u = user;
            Debug.Assert(u != null, "CreatePermittedIDFilter: user is null");
            if (!u.UserRoleID.HasValue)
            {
                filterHQL = null;
                return PermittedIDsResult.None;
            }

            StringBuilder sFrom = new StringBuilder();
            StringBuilder sWhere = new StringBuilder();
            sFrom.AppendFormat("SELECT filtered.ID FROM {0} filtered", typeof (StoreWorkingTime).Name);

            PermittedIDsResult result;
            UserRoleId role = (UserRoleId) (u.UserRoleID.Value);
            switch (role)
            {
                case UserRoleId.GlobalAdmin:
                    result = PermittedIDsResult.All;
                    break;
                case UserRoleId.Controlling:
                    if (bForReading)
                    {
                        goto case UserRoleId.CountryAdmin;
                    }
                    else
                    {
                        result = PermittedIDsResult.None;
                    }
                    break;
                case UserRoleId.CountryAdmin:
                    sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                    sFrom.AppendFormat(
                        ", {0} internal_dao_uc, {1} internal_dao_c, {2} internal_dao_r, {3} internal_dao_s",
                        typeof (UserCountry).Name, typeof (Country).Name, typeof (Region).Name, typeof (Store).Name);
                    sWhere.Append(
                        @"internal_dao_uc.User.ID = :internal_dao_userID
                      AND internal_dao_uc.CountryID = internal_dao_c.ID
                      AND internal_dao_c.ID = internal_dao_r.CountryID
                      AND internal_dao_r.ID = internal_dao_s.RegionID
                      AND internal_dao_s.ID = filtered.StoreID");
                    pNames.Add("internal_dao_userID");
                    pValues.Add(u.ID);
                    result = PermittedIDsResult.Restricted;
                    break;
                case UserRoleId.RegionAdmin:
                    sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                    sFrom.AppendFormat(", {0} internal_dao_ur, {1} internal_dao_r, {2} internal_dao_s",
                                       typeof (UserRegion).Name, typeof (Region).Name, typeof (Store).Name);
                    sWhere.Append(
                        @"internal_dao_ur.User.ID = :internal_dao_userID
                      AND internal_dao_ur.RegionID = internal_dao_r.ID
                      AND internal_dao_r.ID = internal_dao_s.RegionID
                      AND internal_dao_s.ID = filtered.StoreID");
                    pNames.Add("internal_dao_userID");
                    pValues.Add(u.ID);
                    result = PermittedIDsResult.Restricted;
                    break;
                case UserRoleId.StoreAdmin:
                    sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                    sFrom.AppendFormat(", {0} internal_dao_us", typeof (UserStore).Name);
                    sWhere.Append(
                        @"internal_dao_us.User.ID = :internal_dao_userID
                      AND internal_dao_us.StoreID = filtered.StoreID");
                    pNames.Add("internal_dao_userID");
                    pValues.Add(u.ID);
                    result = PermittedIDsResult.Restricted;
                    break;
                default:
                    throw new Exception(string.Format("unknown user role : {0}", role.ToString()));
            }

            if (sWhere.Length == 0)
            {
                filterHQL = null;
            }
            else
            {
                filterHQL = sFrom.Append(sWhere).ToString();
            }
            return result;
            // suppose, we should never call base
            //return base.CreatePermittedIDFilter();
        }

        #region IStoreWorkingTimeDao Members

        public IList GetWorkingTimeFiltered(long storeID, DateTime? dateOn)
        {
            /*
            ICriteria criteria = Session.CreateCriteria(typeof(StoreWorkingTime));
            criteria.Add(Expression.Eq("StoreID", storeID));

            if (dateOn.HasValue )
            {
                // BeginTime <= dateOn and dateOn <=EndTime
                criteria.Add(Expression.Le("BeginTime", dateOn));
                criteria.Add(Expression.Ge("EndTime", dateOn));
            }
            criteria.AddOrder(Order.Desc("BeginTime"));
            
            return criteria.//List();*/

            StringBuilder sb = new StringBuilder("entity.StoreID = :storeid ");
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();
            pNames.Add("storeid");
            pValues.Add(storeID);
            if (dateOn.HasValue)
            {
                sb.Append(" AND (:dateon BETWEEN entity.BeginTime AND entity.EndTime) ");
                pNames.Add("dateon");
                pValues.Add(dateOn.Value);
            }
            IList list =
                FindByNamedParam(null, sb.ToString(), "ORDER BY entity.BeginTime DESC", pNames.ToArray(),
                                 pValues.ToArray());
            if ((list != null) && (list.Count == 0))
            {
                return null;
            }
            return list;
        }


        public IList GetWorkingTimeFiltered(long storeID, DateTime aBegin, DateTime aEnd)
        {
            /*
            ICriteria criteria = Session.CreateCriteria(typeof(StoreWorkingTime));
            criteria.Add(Expression.Eq("StoreID", storeID))
                .Add(Expression.Not(Expression.Or(Expression.Gt("BeginTime", aEnd),
                                                  Expression.Lt("EndTime", aBegin))));


            return criteria.//List();*/

            return FindByNamedParam(
                @" entity.StoreID = :store_id AND NOT ( (entity.BeginTime > :a_end) OR (entity.EndTime < :a_begin) ) ",
                new string[] {"store_id", "a_end", "a_begin"},
                new object[] {storeID, aEnd, aBegin});
        }

        public List<StoreWorkingTime> GetWorkingTimeFiltered_Srv(long storeID, DateTime aBegin, DateTime aEnd)
        {

            List<StoreWorkingTime> lstResult = new List<StoreWorkingTime>();

            ICriteria criteria = Session.CreateCriteria(typeof(StoreWorkingTime));
            criteria.Add(Expression.Eq("StoreID", storeID))
                .Add(Expression.Not(Expression.Or(Expression.Gt("BeginTime", aEnd),
                                                  Expression.Lt("EndTime", aBegin))));


            criteria.List(lstResult );

            return lstResult;

            //return FindByNamedParam(
            //    @" entity.StoreID = :store_id AND NOT ( (entity.BeginTime > :a_end) OR (entity.EndTime < :a_begin) ) ",
            //    new string[] { "store_id", "a_end", "a_begin" },
            //    new object[] { storeID, aEnd, aBegin });
        }
        #endregion
    }
}