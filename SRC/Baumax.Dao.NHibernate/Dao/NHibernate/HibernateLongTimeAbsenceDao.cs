using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;

namespace Baumax.Dao.NHibernate
{
    public class HibernateLongTimeAbsenceDao : HibernateDao<LongTimeAbsence>, ILongTimeAbsenceDao
    {
        public SaveDataResult ImportLongTimeAbsence(List<ImportLongTimeAbsenceData> list)
        {
            SaveDataResult result = new SaveDataResult();
            result.Success = true;
            if (list.Count > 0)
            {
                string query =
                    @" create table #lta4insert
(
	    PersID nvarchar (25),
        Code smallint,
        CodeName nvarchar (30),
        BeginTime smalldatetime,
        EndTime smalldatetime
)
";
                using (IDbCommand command = CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandTimeout = 60*3;
                    command.ExecuteNonQuery();
                    foreach (ImportLongTimeAbsenceData value in list)
                    {
                        query =
                            "insert into #lta4insert (PersID, Code, CodeName, BeginTime, EndTime) values(N'{0}',{1},N'{2}','{3}','{4}')";
                        command.CommandText =
                            string.Format(query, value.PersID, value.Code, value.CodeName,
                                          value.BeginTime.ToString("yyyyMMdd"), value.EndTime.ToString("yyyyMMdd"));
                        command.ExecuteNonQuery();
                    }
                    command.CommandText = "spLongTimeAbsence_ImportData";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter importResult = new SqlParameter("@result", SqlDbType.Int, 4);
                    importResult.Direction = ParameterDirection.Output;
                    command.Parameters.Add(importResult);
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        list.Clear();
                        while (reader.Read())
                        {
                            ImportLongTimeAbsenceData value = new ImportLongTimeAbsenceData();
                            value.PersID = reader.GetString(0);
                            value.Code = reader.GetInt16(1);
                            value.BeginTime = reader.GetDateTime(2);
                            value.EndTime = reader.GetDateTime(3);
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


        public List<LongTimeAbsence> FindAllByCountry(long countryid)
        {
            return
                GetTypedListFromIList(
                    FindByNamedParam(null, "entity.CountryID=:countryid", null, "countryid", countryid));
        }
    }
}