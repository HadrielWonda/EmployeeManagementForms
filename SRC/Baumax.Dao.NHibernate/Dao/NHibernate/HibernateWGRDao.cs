using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Baumax.Domain;

namespace Baumax.Dao.NHibernate
{
    public class HibernateWGRDao : HibernateDao<WGR>, IWGRDao
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
            sFrom.AppendFormat("SELECT filtered.ID FROM {0} filtered", typeof (WGR).Name);
            long? languageID = getCurrentLanguageID();
            if (languageID.HasValue)
            {
                sWhere.Append(" WHERE filtered.LanguageID = :internal_dao_languageid ");
                pNames.Add("internal_dao_languageid");
                pValues.Add(languageID.Value);
            }

            // TODO: add filtering by user/role
            if (sWhere.Length == 0)
            {
                filterHQL = null;
            }
            else
            {
                filterHQL = sFrom.Append(sWhere).ToString();
            }
            return PermittedIDsResult.Restricted;
            // suppose, we should never call base
            //return base.CreatePermittedIDFilter();
        }

        #region IWGRDao Members

        public IList GetWgrFiltered(long HWGR_ID, DateTime? from, DateTime? to)
        {
            if ((from.HasValue) && (to.HasValue) && (from.Value > to.Value))
            {
                return null;
            }

            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();

            StringBuilder sb = new StringBuilder(50);
            sb.Append(
                @"entity.ID=HW.WgrId 
                AND WoHw.ID=HW.WorldHWGR_ID 
                AND WoHw.HwgrID = :HwgrID ");
            pNames.Add("HwgrID");
            pValues.Add(HWGR_ID);

            if (from.HasValue)
            {
                sb.Append(" AND ( (HW.EndTime is null) OR (HW.EndTime >= :from_date) ) ");
                pNames.Add("from_date");
                pValues.Add(from.Value);
            }
            if (to.HasValue)
            {
                sb.Append(" AND ( (HW.BeginTime is null) OR (HW.BeginTime <= :to_date) ) ");
                pNames.Add("to_date");
                pValues.Add(to.Value);
            }

            IList list =
                FindByNamedParam("WorldToHwgr WoHw, HwgrToWgr HW", sb.ToString(), pNames.ToArray(), pValues.ToArray());
            if ((list != null) && (list.Count == 0))
            {
                return null;
            }
            return list;
        }

        #endregion
    }
}