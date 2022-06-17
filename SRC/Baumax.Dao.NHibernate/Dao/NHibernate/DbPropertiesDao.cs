using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Baumax.Dao.Interfaces;
using Spring.Data.NHibernate.Support;

namespace Baumax.Dao.NHibernate
{
    public class DbPropertiesDao : HibernateDaoSupport, IDbPropertiesDao
    {

        public string GetDbVersion()
        {
            using (IDbCommand cmd = Session.Connection.CreateCommand())
            {
                Session.Transaction.Enlist(cmd);
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spDBVersionGet";

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader[0].ToString();
                    }
                }
            }
            return "";
        }
    }
}
