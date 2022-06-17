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

namespace Baumax.Dao.NHibernate
{
    public class HibernateHWGRDao : HibernateDao<HWGR>, IHWGRDao
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
            sFrom.AppendFormat("SELECT filtered.ID FROM {0} filtered", typeof (HWGR).Name);
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

        #region IHWGRDao Members

        public IList GetHwgrFiltered(long worldID, DateTime? from, DateTime? to)
        {
            if ((from.HasValue) && (to.HasValue) && (from.Value > to.Value))
            {
                return null;
            }

            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();

            StringBuilder sb = new StringBuilder(50);
            sb.Append(
                @"entity.ID=WoHw.HwgrID 
                AND WoHw.StoreWorld_ID=StWo.ID 
                AND StWo.WorldID = :worldID ");
            pNames.Add("worldID");
            pValues.Add(worldID);

            if (from.HasValue)
            {
                sb.Append(" AND ( (WoHw.EndTime is null) OR (WoHw.EndTime >= :from_date) ) ");
                pNames.Add("from_date");
                pValues.Add(from.Value);
            }
            if (to.HasValue)
            {
                sb.Append(" AND ( (WoHw.BeginTime is null) OR (WoHw.BeginTime <= :to_date) ) ");
                pNames.Add("to_date");
                pValues.Add(to.Value);
            }

            IList list =
                FindByNamedParam("WorldToHwgr WoHw, StoreToWorld StWo", sb.ToString(), pNames.ToArray(),
                                 pValues.ToArray());
            if ((list != null) && (list.Count == 0))
            {
                return null;
            }
            return list;
        }

        public SaveDataResult ImportHWGR(List<ImportHWGRData> list)
        {
            SaveDataResult result = new SaveDataResult();
            result.Success = true;
            if (list.Count > 0)
            {
                string query =
                    @" create table #hwgr4insert
(
	HWGR_SystemID int,
	World_SystemID int,
	ImportName nvarchar (50)
)
";
                using (IDbCommand command = CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandTimeout = 60*3;
                    command.ExecuteNonQuery();
                    foreach (ImportHWGRData value in list)
                    {
                        query =
                            "insert into #hwgr4insert (HWGR_SystemID,World_SystemID, ImportName) values({0},{1},N'{2}')";
                        command.CommandText =
                            string.Format(query, value.HWGR_SystemID, value.World_SystemID, value.Name);
                        command.ExecuteNonQuery();
                    }
                    command.CommandText = "spHWGR_ImportData";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter importResult = new SqlParameter("@result", SqlDbType.Int, 4);
                    importResult.Direction = ParameterDirection.Output;
                    command.Parameters.Add(importResult);
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        list.Clear();
                        while (reader.Read())
                        {
                            ImportHWGRData value = new ImportHWGRData();
                            value.HWGR_SystemID = reader.GetInt32(0);
                            value.World_SystemID = reader.GetInt32(1);
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