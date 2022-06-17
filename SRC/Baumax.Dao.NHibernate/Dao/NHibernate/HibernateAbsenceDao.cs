using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;
using System.Data.SqlClient;
using Baumax.Contract;

namespace Baumax.Dao.NHibernate
{
    public class HibernateAbsenceDao : HibernateDao<Absence>, IAbsenceDao
    {
        #region IAbsenceDao Members

        public IList GetCountryAbsences(long countryID)
        {
            return FindByNamedParam(null, "entity.CountryID = :countryid", null, "countryid", countryID);
        }

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
            sFrom.AppendFormat("SELECT filtered.ID FROM {0} filtered", typeof (Absence).Name);
            long? languageID = getCurrentLanguageID();
            if (languageID.HasValue)
            {
                sWhere.Append(" WHERE filtered.LanguageID = :internal_dao_languageid ");
                pNames.Add("internal_dao_languageid");
                pValues.Add(languageID.Value);
            }

            PermittedIDsResult result;
            UserRoleId role = (UserRoleId) (u.UserRoleID.Value);
            switch (role)
            {
                case UserRoleId.GlobalAdmin:
                    result = PermittedIDsResult.Restricted;
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

        public SaveDataResult ImportAbsence(List<ImportAbsenceData> list)
        {
            SaveDataResult result = new SaveDataResult();
            result.Success = true;
            if (list.Count > 0)
            {
                string query =
                    @" create table #abs4insert
(
	SystemID int,
    CharID nvarchar (10),
	[Name] nvarchar (50)
)
";
                using (IDbCommand command = CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandTimeout = 60*3;
                    command.ExecuteNonQuery();
                    foreach (ImportAbsenceData value in list)
                    {
                        query = @"insert into #abs4insert (SystemID, CharID, [Name]) 
									values({0},'{1}',N'{2}')";
                        command.CommandText = string.Format(query,
                                                            value.SystemID,
                                                            value.CharID,
                                                            value.Name);
                        command.ExecuteNonQuery();
                    }
                    command.CommandText = "spAbsence_ImportData";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter importResult = new SqlParameter("@result", SqlDbType.Int, 4);
                    importResult.Direction = ParameterDirection.Output;
                    command.Parameters.Add(importResult);
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        list.Clear();
                        while (reader.Read())
                        {
                            ImportAbsenceData value = new ImportAbsenceData();
                            value.SystemID = reader.GetInt32(0);
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