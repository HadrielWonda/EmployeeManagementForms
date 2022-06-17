using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Baumax.Contract;
using Baumax.Domain;

namespace Baumax.Dao.NHibernate
{
    public class HibernateStoreAdditionalHourDao : HibernateDao<StoreAdditionalHour>, IStoreAdditionalHourDao
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
            sFrom.AppendFormat("SELECT filtered.ID FROM {0} filtered", typeof (StoreAdditionalHour).Name);

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

        #region IStoreAdditionalHourDao Members

        public List<StoreAdditionalHour> GetStoreAdditionalHourFiltered(long storeID, DateTime Begin, DateTime End)
        {
            return
                GetTypedListFromIList(
                    FindByNamedParam(
                        " entity.StoreID = :storeid AND entity.BeginDate = :datebegin AND entity.EndDate = :dateend ",
                        new string[] {"storeid", "datebegin", "dateend"},
                        new object[] {storeID, Begin, End}));
        }

        public List<StoreAdditionalHour> GetStoreAdditionalHourFiltered(long storeID, int beginYear, byte dayOfWeek)
        {
            return
                GetTypedListFromIList(
                    FindByNamedParam(
                        " entity.StoreID = :storeid AND (entity.BeginDate BETWEEN :datebegin AND :dateend) AND entity.WeekDay = :weekday",
                        new string[] { "storeid", "datebegin", "dateend", "weekday" },
                        new object[] { storeID, new DateTime(beginYear, 1, 1), new DateTime(beginYear, 12, 31), dayOfWeek }));
        }

        #endregion
    }
}