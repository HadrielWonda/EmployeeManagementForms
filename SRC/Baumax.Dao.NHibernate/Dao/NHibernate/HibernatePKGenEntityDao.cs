using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Baumax.Domain;
using Baumax.Dao;
using NHibernate;
using Spring.Data.NHibernate;
using Spring.Data.NHibernate.Support;

namespace Baumax.Dao.NHibernate
{
    public class HibernatePKGenEntityDao : HibernateDaoSupport, IHibernatePKGenEntityDao
    {
        private const long startingIdValue = 1000;

        #region IHibernatePKGenEntityDao Members

        public long GetNextPK(string _domainName)
        {
            lock (this)
            {
                PKGenEntity entity;
                try
                {
                    entity = HibernateTemplate.Get(typeof(PKGenEntity), _domainName) as PKGenEntity;
                    if (entity == null)
                        return CreateDomain(_domainName);
                }
                catch(HibernateObjectRetrievalFailureException)
                {
                    return CreateDomain(_domainName);
                }
                entity.Value += 1;
                HibernateTemplate.Update(entity);
                return entity.Value;

                /*try
                {
                    IDbCommand command = this.CreateCommand();
                    command.CommandText = "getNewID";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter newIdParam = new SqlParameter("@NewID", SqlDbType.BigInt, 8);
                    newIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(newIdParam);
                    command.ExecuteScalar();
                    return (long)newIdParam.Value;
                }
                catch(Exception ex)
                {
                    throw new Exception("Cannot get next primary key value", ex);
                }*/
            }
        }
        #endregion
        
        private long CreateDomain(string domainName)
        {
            // if domain doesn't exist try to create a new one
            PKGenEntity entity = new PKGenEntity();
            entity.DomainName = domainName;
            entity.Value = startingIdValue;
            HibernateTemplate.Save(entity);
            return entity.Value;
        }
    }
}