using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;

namespace Baumax.Dao.NHibernate
{
    public class HibernateFeastDao : HibernateDao<Feast>, IFeastDao
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
            sFrom.AppendFormat("SELECT filtered.ID FROM {0} filtered", typeof (Feast).Name);

            PermittedIDsResult result;
            UserRoleId role = (UserRoleId) (u.UserRoleID.Value);
            switch (role)
            {
                case UserRoleId.GlobalAdmin:
                    filterHQL = null;
                    return PermittedIDsResult.All;
                case UserRoleId.Controlling:
                    filterHQL = null;
                    if (bForReading)
                    {
                        goto case UserRoleId.CountryAdmin;
                    }
                    else
                    {
                        return PermittedIDsResult.None;
                    }
                case UserRoleId.CountryAdmin:
                    sWhere.Append(sWhere.Length > 0 ? " AND " : " WHERE ");
                    sFrom.AppendFormat(", {0} internal_dao_uc",
                                       typeof (UserCountry).Name);
                    sWhere.Append(
                        @" internal_dao_uc.User.ID = :internal_dao_userID
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
                        sWhere.Append(
                            @" internal_dao_ur.User.ID = :internal_dao_userID
                           AND internal_dao_ur.RegionID = internal_dao_r.ID
                           AND internal_dao_r.CountryID = filtered.CountryID ");
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
                        sWhere.Append(
                            @" internal_dao_us.User.ID = :internal_dao_userID
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

        #region IFeastDao Members

        public IList GetFeastsFiltered(long countryID, DateTime? from, DateTime? to)
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
                sb.Append(" and FeastDate >= :datefrom ");
                pNames.Add("datefrom");
                pValues.Add(from.Value);
            }
            if (to.HasValue)
            {
                sb.Append(" and FeastDate <= :dateto ");
                pNames.Add("dateto");
                pValues.Add(to.Value);
            }
            IList list = FindByNamedParam(sb.ToString(), pNames.ToArray(), pValues.ToArray());
            if ((list != null) && (list.Count == 0))
            {
                return null;
            }
            return list;
        }

        /*
        public IList GetFeastsFiltered(long countryID, DateTime? from, DateTime? to)
        {
            ICriteria criteria = Session.CreateCriteria(typeof (Feast));
            criteria.Add(Expression.Eq("CountryID", countryID));
            if (from.HasValue)
            {
                criteria.Add(Expression.Ge("FeastDate", from.Value));
                if (to.HasValue)
                {
                    criteria.Add(Expression.Le("FeastDate", to.Value));
                }
            }
            return ResolveCriteria(criteria);
        }*/

        public SaveDataResult ImportFeasts(List<ImportDaysData> list)
        {
            SaveDataResult result = new SaveDataResult();
            result.Success = true;
            if (list.Count > 0)
            {
                string query =
                    @" create table #feast4insert
(
	CountryID bigint,
	[Date] smalldatetime
)
";
                using (IDbCommand command = CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandTimeout = 60*3;
                    command.ExecuteNonQuery();
                    foreach (ImportDaysData value in list)
                    {
                        query = "insert into #feast4insert (CountryID,[Date]) values({0},'{1}')";
                        command.CommandText = string.Format(query, value.CountryID, value.Date.ToString("yyyyMMdd"));
                        command.ExecuteNonQuery();
                    }
                    command.CommandText = "spFeasts_ImportData";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter importResult = new SqlParameter("@result", SqlDbType.Int, 4);
                    importResult.Direction = ParameterDirection.Output;
                    command.Parameters.Add(importResult);
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        list.Clear();
                        while (reader.Read())
                        {
                            ImportDaysData value = new ImportDaysData();
                            value.CountryID = reader.GetInt64(0);
                            value.Date = reader.GetDateTime(1);
                            list.Add(value);
                        }
                        reader.NextResult();
                        result.Success = ((int) importResult.Value > 0);
                    }
                    result.Data = list;
                }
            }
            OnDaoInvalidateWholeCache();
            return result;
        }

        #endregion
    }
}