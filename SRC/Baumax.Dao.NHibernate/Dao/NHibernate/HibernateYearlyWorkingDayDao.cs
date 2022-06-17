using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Baumax.Contract;
using Baumax.Domain;

namespace Baumax.Dao.NHibernate
{
    public class HibernateYearlyWorkingDayDao : HibernateDao<YearlyWorkingDay>, IYearlyWorkingDayDao
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
            sFrom.AppendFormat("SELECT filtered.ID FROM {0} filtered", typeof (YearlyWorkingDay).Name);

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
                    sFrom.AppendFormat(", {0} internal_dao_uc",
                                       typeof (UserCountry).Name);
                    sWhere.Append(
                        @"internal_dao_uc.User.ID = :internal_dao_userID
                      AND internal_dao_uc.CountryID = filtered.CountryID");
                    pNames.Add("internal_dao_userID");
                    pValues.Add(u.ID);
                    result = PermittedIDsResult.Restricted;
                    break;
                case UserRoleId.RegionAdmin:
                    if (bForReading)
                    {
                        sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                        sFrom.AppendFormat(", {0} internal_dao_r, {1} internal_dao_ur",
                                           typeof (Region).Name, typeof (UserRegion).Name);
                        sWhere.AppendFormat(
                            @"internal_dao_ur.User.ID = :internal_dao_userID
                      AND internal_dao_ur.RegionID = internal_dao_r.ID
                      AND internal_dao_r.CountryID = filtered.CountryID");
                        pNames.Add("internal_dao_userID");
                        pValues.Add(u.ID);
                        result = PermittedIDsResult.Restricted;
                    }
                    else
                    {
                        result = PermittedIDsResult.None;
                    }
                    break;
                case UserRoleId.StoreAdmin:
                    if (bForReading)
                    {
                        sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                        sFrom.AppendFormat(", {0} internal_dao_s, {1} internal_dao_r, {2} internal_dao_us",
                                           typeof (Store).Name, typeof (Region).Name, typeof (UserStore).Name);
                        sWhere.AppendFormat(
                            @"internal_dao_us.User.ID = :internal_dao_userID
                      AND internal_dao_us.StoreID = internal_dao_s.ID
                      AND internal_dao_s.RegionID = internal_dao_r.ID
                      AND internal_dao_r.CountryID = filtered.CountryID");
                        pNames.Add("internal_dao_userID");
                        pValues.Add(u.ID);
                        result = PermittedIDsResult.Restricted;
                    }
                    else
                    {
                        result = PermittedIDsResult.None;
                    }
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

        #region IYearlyWorkingDayDao Members

        public IList GetYearlyWorkingDaysFiltered(long countryID, DateTime? from, DateTime? to)
        {
            StringBuilder sb = new StringBuilder("entity.CountryID = :countryid ");
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();
            pNames.Add("countryid");
            pValues.Add(countryID);
            // i don't use "between" clause here. in case if only one of "from"/"to" values specified.
            // may be useful for reporting in future, imho
            if (from.HasValue)
            {
                sb.Append(" and WorkingDay >= :workingdayfrom ");
                pNames.Add("workingdayfrom");
                pValues.Add(from.Value);
            }
            if (to.HasValue)
            {
                sb.Append(" and WorkingDay <= :workingdayto ");
                pNames.Add("workingdayto");
                pValues.Add(to.Value);
            }
            IList list = FindByNamedParam(sb.ToString(), pNames.ToArray(), pValues.ToArray());
            if ((list != null) && (list.Count == 0))
            {
                return null;
            }
            return list;
        }

        #endregion
    }
}