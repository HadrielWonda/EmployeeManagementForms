using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NHibernate;
using NHibernate.Type;
using Spring.Data.NHibernate;
using Spring.Data.NHibernate.Support;
using Baumax.Contract.Interfaces;
using Baumax.Contract;
using Spring.Objects.Factory;
using System.Data;
using Spring.Transaction.Interceptor;
using IInterceptor = NHibernate.IInterceptor;
using Baumax.Contract.Exceptions;
using Baumax.Domain;
using Baumax.Util;
using Baumax.Dao;
using Baumax.Cache;

namespace Baumax.Dao.NHibernate
{
    public enum PermittedIDsResult
    {
        None,
        All,
        Restricted
    }

    public class HibernateDao<T> : HibernateDaoSupport, IDao<T>, IQueryCacheDao, IInitializingObject /*, IInterceptor, IInitializingObject*/
        where T : class
    {
        private event DaoEntitiesChangedDelegate _daoEntitiesChanged;
        private event DaoInvalidateWholeCacheDelegate _daoInvalidateWholeCache;

        #region Protected fields

        protected IAuthorizationService _AuthorizationService;

        #endregion

        #region Constuctors

        public HibernateDao()
        {
        }

        #endregion

        #region Protected properties

        protected IAuthorizationService AuthorizationService
        {
            get { return _AuthorizationService; }
            set { _AuthorizationService = value; }
        }

        #endregion

        #region Protected methods

        protected long? getCurrentLanguageID()
        {
            //long? languageID = null;
            //if (_AuthorizationService != null)
            //{
            //    languageID = _AuthorizationService.GetCurrentUser().LanguageID;
            //}
            //return languageID;
            return SharedConsts.NeutralLangId;
        }

        public IDataReader GetDataReader(string query)
        {
            return getDataReader(query);
        }

        protected IDataReader getDataReader(string query)
        {
            using (IDbCommand command = CreateCommand())
            {
                command.CommandText = query;
                command.CommandTimeout = 180;
                return command.ExecuteReader(CommandBehavior.SequentialAccess);
            }
        }

        protected object getDataScalar(string query)
        {
            using (IDbCommand command = CreateCommand())
            {
                command.CommandText = query;
                return command.ExecuteScalar();
            }
        }

        protected IDbCommand CreateCommand()
        {
            IDbCommand cmd = Session.Connection.CreateCommand();
            Session.Transaction.Enlist(cmd);
            return cmd;
        }

        #endregion

        #region IDao<T> Members

        public event DaoEntitiesChangedDelegate DaoEntitiesChanged
        {
            add { _daoEntitiesChanged += value; }
            remove { _daoEntitiesChanged -= value; }
        }

        public virtual void OnDaoEntitiesChanged(IEnumerable<long> ids)
        {
            if ((_daoEntitiesChanged != null) && (ids != null))
            {
                _daoEntitiesChanged(ids);
            }
        }

        public virtual void OnDaoEntitiesChanged(long id)
        {
            OnDaoEntitiesChanged(new long[] {id});
        }

        public event DaoInvalidateWholeCacheDelegate DaoInvalidateWholeCache
        {
            add { _daoInvalidateWholeCache += value; }
            remove { _daoInvalidateWholeCache -= value; }
        }

        public void OnDaoInvalidateWholeCache()
        {
            if (_daoInvalidateWholeCache != null)
            {
                _daoInvalidateWholeCache();
            }
        }

        protected List<T> GetTypedListFromIList(IList list)
        {
            return TypedListConverter<T>.ToTypedList(list);
        }

        /// <summary>
        /// Creates sql query for getting the permitted for reading ID list for current user/role.
        /// For example: "SELECT filtered.ID FROM Country filtered, UserCountry uc WHERE filtered.ID = uc.Country.ID AND uc.UserID = :cur_user_id"
        /// Please use "filtered" alias for current entity's table if it is possible. It is required only for common uniformity for now.
        /// </summary>
        /// <param name="pNames">The parameter names.</param>
        /// <param name="pValues">The parameter values.</param>
        /// <param name="bForReading">if set to <c>true</c> for reading.</param>
        /// <param name="filterHQL">string with HQL query that resolves to permitted ID list.</param>
        /// <param name="user">User to create filter for.</param>
        /// <returns>
        /// Permission result (None, All, Restricted by <paramref name="filterHQL"/>).
        /// </returns>
        protected virtual PermittedIDsResult CreatePermittedIDFilter(List<string> pNames, List<object> pValues,
                                                                     bool bForReading, out string filterHQL, User user)
        {
            filterHQL = null;
            // by default have access to all entities of type
            return PermittedIDsResult.All;
        }

        public T FindById(long id)
        {
            // TODO: rewrite using permitted ID list
            return HibernateTemplate.Get(typeof (T), id) as T;
        }

        public virtual IList GetIDList()
        {
            return FindByNamedParam(new string[] {"entity.ID"}, null, null, null, null, null, true);
        }
        
        public IList FindAll()
        {
            return FindByNamedParam(null, null, null);
        }

        /// <summary>
        /// Finds the entities by named parameter list.
        /// </summary>
        /// <param name="condition">The condition (is added after default WHERE-conditions using AND operation).</param>
        /// <param name="paramNames">The parameter names.</param>
        /// <param name="paramValues">The parameter values.</param>
        /// <returns>Entity list</returns>
        public IList FindByNamedParam(string condition, string[] paramNames, object[] paramValues)
        {
            return FindByNamedParam(null, condition, paramNames, paramValues);
        }

        /// <summary>
        /// Finds the entities by named parameter list.
        /// </summary>
        /// <param name="fromAddition">From clause addition (i.e. is added after "SELECT entity FROM [TypeName] entity, ").</param>
        /// <param name="condition">The condition (is added after default WHERE-conditions using AND operation).</param>
        /// <param name="paramNames">The parameter names.</param>
        /// <param name="paramValues">The parameter values.</param>
        /// <returns>Entity list</returns>
        public IList FindByNamedParam(string fromAddition, string condition, string[] paramNames, object[] paramValues)
        {
            return FindByNamedParam(fromAddition, condition, null, paramNames, paramValues);
        }

        /// <summary>
        /// Finds the entities by named parameter list.
        /// </summary>
        /// <param name="fromAddition">From clause addition (i.e. is added after "SELECT entity FROM [TypeName] entity, ").</param>
        /// <param name="condition">The condition (is added after default WHERE-conditions using AND operation).</param>
        /// <param name="afterJoinClauses">The after join clauses (ORDER BY, for example).</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <returns>Entity list</returns>
        public IList FindByNamedParam(string fromAddition, string condition, string afterJoinClauses, string paramName,
                                      object paramValue)
        {
            return
                FindByNamedParam(fromAddition, condition, afterJoinClauses, new string[] {paramName},
                                 new object[] {paramValue});
        }

        /// <summary>
        /// Finds the entities by named parameter list.
        /// </summary>
        /// <param name="fromAddition">From clause addition (i.e. is added after "SELECT entity FROM [TypeName] entity, ").</param>
        /// <param name="condition">The condition (is added after default WHERE-conditions using AND operation).</param>
        /// <param name="afterJoinClauses">The after join clauses (ORDER BY, for example).</param>
        /// <param name="paramNames">The parameter names.</param>
        /// <param name="paramValues">The parameter values.</param>
        /// <returns>Entity list</returns>
        public IList FindByNamedParam(string fromAddition, string condition, string afterJoinClauses,
                                      string[] paramNames, object[] paramValues)
        {
            return FindByNamedParam(fromAddition, condition, afterJoinClauses, paramNames, paramValues, true);
        }

        /// <summary>
        /// Finds the entities by named parameter list.
        /// </summary>
        /// <param name="fromAddition">From clause addition (i.e. is added after "SELECT entity FROM [TypeName] entity, ").</param>
        /// <param name="condition">The condition (is added after default WHERE-conditions using AND operation).</param>
        /// <param name="afterJoinClauses">The after join clauses (ORDER BY, for example).</param>
        /// <param name="paramNames">The parameter names.</param>
        /// <param name="paramValues">The parameter values.</param>
        /// <param name="bCheckForReading">Check user rights for reading or for writing entity.</param>
        /// <returns>Entity list</returns>
        public IList FindByNamedParam(string fromAddition, string condition, string afterJoinClauses,
                                      string[] paramNames, object[] paramValues, bool bCheckForReading)
        {
            return
                FindByNamedParam(null, fromAddition, condition, afterJoinClauses, paramNames, paramValues,
                                 bCheckForReading);
        }

        /// <summary>
        /// Finds the entities by named parameter list.
        /// </summary>
        /// <param name="fields">Fields to select from entity (by default whole entity is selected).</param>
        /// <param name="fromAddition">From clause addition (i.e. is added after "SELECT entity FROM [TypeName] entity, ").</param>
        /// <param name="condition">The condition (is added after default WHERE-conditions using AND operation).</param>
        /// <param name="afterJoinClauses">The after join clauses (ORDER BY, for example).</param>
        /// <param name="paramNames">The parameter names.</param>
        /// <param name="paramValues">The parameter values.</param>
        /// <param name="bCheckForReading">Check user rights for reading or for writing entity.</param>
        /// <returns>Entity list</returns>
        public IList FindByNamedParam(string[] fields, string fromAddition, string condition, string afterJoinClauses,
                                      string[] paramNames, object[] paramValues, bool bCheckForReading)
        {
            return FindByNamedParam(fields, fromAddition, condition, afterJoinClauses, paramNames, paramValues,
                                    bCheckForReading, _AuthorizationService.GetCurrentUser());
        }

        /// <summary>
        /// Finds the entities by named parameter list.
        /// </summary>
        /// <param name="fields">Fields to select from entity (by default whole entity is selected).</param>
        /// <param name="fromAddition">From clause addition (i.e. is added after "SELECT entity FROM [TypeName] entity, ").</param>
        /// <param name="condition">The condition (is added after default WHERE-conditions using AND operation).</param>
        /// <param name="afterJoinClauses">The after join clauses (ORDER BY, for example).</param>
        /// <param name="paramNames">The parameter names.</param>
        /// <param name="paramValues">The parameter values.</param>
        /// <param name="bCheckForReading">Check user rights for reading or for writing entity.</param>
        /// <param name="user">User to find for.</param>
        /// <returns>Entity list</returns>
        public IList FindByNamedParam(string[] fields, string fromAddition, string condition, string afterJoinClauses,
                                      string[] paramNames, object[] paramValues, bool bCheckForReading, User user)
        {
            StringBuilder sb = new StringBuilder(50);
            sb.AppendFormat("SELECT ");
            if ((fields == null) || (fields.Length == 0))
            {
                sb.AppendFormat(" entity ");
            }
            else
            {
                int i = 0;
                // at least one item is present
                sb.AppendFormat(" {0}", fields[i++]);
                for (; i < fields.Length; i++)
                {
                    sb.AppendFormat(",{0}", fields[i]);
                }
            }
            sb.AppendFormat(" FROM {0} entity ", typeof (T).Name);
            if ((fromAddition != null) && (fromAddition.Length > 0))
            {
                sb.AppendFormat(",{0} ", fromAddition);
            }
            bool isWhereClauseAdded = false;
            if ((condition != null) && (condition.Length > 0))
            {
                sb.AppendFormat(" WHERE ({0}) ", condition);
                isWhereClauseAdded = true;
            }
            // HibernateTemplate doesn't accept nulls instead of empty arrays
            List<string> pNames = new List<string>();
            if (paramNames != null)
            {
                pNames.AddRange(paramNames);
            }
            List<object> pValues = new List<object>();
            if (paramValues != null)
            {
                pValues.AddRange(paramValues);
            }
            string permittedIDFilter;
            switch (CreatePermittedIDFilter(pNames, pValues, bCheckForReading, out permittedIDFilter, user))
            {
                case PermittedIDsResult.None:
                    return null;
                case PermittedIDsResult.All:
                    break;
                case PermittedIDsResult.Restricted:
                    if ((permittedIDFilter != null) && (permittedIDFilter.Length > 0))
                    {
                        if (!isWhereClauseAdded)
                        {
                            sb.Append(" WHERE ");
                            isWhereClauseAdded = true;
                        }
                        else
                        {
                            sb.Append(" AND ");
                        }
                        sb.AppendFormat("(entity.ID IN ({0})) ", permittedIDFilter);
                    }
                    break;
                default:
                    Debug.Assert(false, "Unknown PermittedIDsResult");
                    break;
            }
            if ((afterJoinClauses != null) && (afterJoinClauses.Length > 0))
            {
                sb.AppendFormat(" {0} ", afterJoinClauses);
            }
            Debug.Assert(pNames.Count == pValues.Count);
            IList result = HibernateTemplate.FindByNamedParam(sb.ToString(), pNames.ToArray(), pValues.ToArray());
            if ((result == null) || (result.Count == 0))
            {
                return null;
            }
            return result;
        }

        public IList FindByIDList(IEnumerable<long> ids)
        {
            const long maxParamCount = 100;
            const string beginStr = "entity.ID IN (";
            const string endStr = ")";

            if (ids == null)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder(beginStr);
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();
            long pIndex = 0;
            ArrayList result = new ArrayList();
            IEnumerator<long> ie = ids.GetEnumerator();
            ie.Reset();
            if (ie.MoveNext())
            {
                sb.AppendFormat(":p{0}", pIndex);
                pNames.Add(string.Format("p{0}", pIndex++));
                pValues.Add(ie.Current);
                while (ie.MoveNext())
                {
                    sb.AppendFormat(",:p{0}", pIndex);
                    pNames.Add(string.Format("p{0}", pIndex++));
                    pValues.Add(ie.Current);
                    if (pIndex >= maxParamCount)
                    {
                        sb.Append(endStr);
                        IList list = FindByNamedParam(sb.ToString(), pNames.ToArray(), pValues.ToArray());
                        if ((list != null) && (list.Count > 0))
                        {
                            result.AddRange(list);
                        }
                        sb.Length = 0;
                        sb.Append(beginStr);
                        pNames.Clear();
                        pValues.Clear();
                        pIndex = 0;
                        if (ie.MoveNext())
                        {
                            sb.AppendFormat(":p{0}", pIndex);
                            pNames.Add(string.Format("p{0}", pIndex++));
                            pValues.Add(ie.Current);
                        }
                    }
                }
            }
            if (pNames.Count > 0)
            {
                sb.Append(endStr);
                IList list = FindByNamedParam(sb.ToString(), pNames.ToArray(), pValues.ToArray());
                if ((list != null) && (list.Count > 0))
                {
                    result.AddRange(list);
                }
            }
            if (result.Count == 0)
            {
                return null;
            }
            return result;
        }

        protected virtual T DoSaveEntity(T daoObj)
        {
            User u = AuthorizationService.GetCurrentUser();
            if (!u.UserRoleID.HasValue)
            {
                throw new AccessDeniedException("User have no rights to save entity");
            }
            UserRoleId role = (UserRoleId) (u.UserRoleID.Value);

            return (T)HibernateTemplate.SaveOrUpdateCopy(daoObj);
            /*
            if (!(daoObj is BaseEntity))
            {
                return (T) HibernateTemplate.SaveOrUpdateCopy(daoObj);
            }

            // now daoObj IS BaseEntity
            BaseEntity entity = daoObj as BaseEntity;
            if (entity.IsNew)
            {
                // shorj: pretty ugly right check but i can't contrive better implementation now 
                // without large amount of coding
                entity = (BaseEntity) HibernateTemplate.SaveOrUpdateCopy(daoObj);
                if (role != UserRoleId.GlobalAdmin)
                {
                    IList list =
                        FindByNamedParam(new string[] {"entity.ID"}, null, "entity.ID = :id", null, new string[] {"id"},
                                         new object[] {entity.ID}, false);
                    if ((list == null) || (list.Count == 0))
                    {
                        HibernateTemplate.Delete(string.Format("from {0} entity where entity.ID = ?", typeof (T).Name),
                                                 entity.ID, NHibernateUtil.Int64);
                        throw new AccessDeniedException("User have no rights to save entity");
                    }
                }
            }
            else
            {
                if (role != UserRoleId.GlobalAdmin)
                {
                    IList list =
                        FindByNamedParam(new string[] {"entity.ID"}, null, "entity.ID = :id", null, new string[] {"id"},
                                         new object[] {entity.ID}, false);
                    if ((list == null) || (list.Count == 0))
                    {
                        throw new AccessDeniedException("User have no rights to save entity");
                    }
                }
                entity = (BaseEntity) HibernateTemplate.SaveOrUpdateCopy(daoObj);
            }

            return (entity as T);*/
        }

        public virtual T Save(T daoObj)
        {
            daoObj = DoSaveEntity(daoObj);
            if (daoObj is BaseEntity)
            {
                OnDaoEntitiesChanged((daoObj as BaseEntity).ID);
            }
            return daoObj;
        }

        public virtual void SaveList(IList list)
        {
            if ((list != null) && (list.Count > 0))
            {
                List<long> ids = new List<long>();
                foreach (T obj in list)
                {
                    T newObj = DoSaveEntity(obj);
                    if (newObj is BaseEntity)
                    {
                        ids.Add((newObj as BaseEntity).ID);
                    }
                }
                if (ids.Count > 0)
                {
                    OnDaoEntitiesChanged(ids);
                }
            }
        }

        public virtual T SaveOrUpdate(T daoObj)
        {
            T result = DoSaveEntity(daoObj);
            if (result is BaseEntity)
            {
                OnDaoEntitiesChanged((result as BaseEntity).ID);
            }
            return result;
        }

        public virtual void SaveOrUpdateList(IList list)
        {
            if ((list != null) && (list.Count > 0))
            {
                List<long> ids = new List<long>();
                foreach (T obj in list)
                {
                    T newObj = DoSaveEntity(obj);
                    if (newObj is BaseEntity)
                    {
                        ids.Add((newObj as BaseEntity).ID);
                    }
                }
                if (ids.Count > 0)
                {
                    OnDaoEntitiesChanged(ids);
                }
            }
        }


        public virtual T Update(T daoObj)
        {
            daoObj = DoSaveEntity(daoObj);
            if (daoObj is BaseEntity)
            {
                OnDaoEntitiesChanged((daoObj as BaseEntity).ID);
            }
            return daoObj;
        }

        public virtual void UpdateList(IList list)
        {
            if ((list != null) && (list.Count > 0))
            {
                List<long> ids = new List<long>();
                foreach (T obj in list)
                {
                    T newObj = DoSaveEntity(obj);
                    if (newObj is BaseEntity)
                    {
                        ids.Add((newObj as BaseEntity).ID);
                    }
                }
                if (ids.Count > 0)
                {
                    OnDaoEntitiesChanged(ids);
                }
            }
        }

        protected virtual void DoDeleteEntities(IEnumerable<long> idlist)
        {
            if (idlist != null)
            {
                User u = AuthorizationService.GetCurrentUser();
                if (!u.UserRoleID.HasValue)
                {
                    throw new AccessDeniedException("User have no rights to delete entity");
                }
                UserRoleId role = (UserRoleId) (u.UserRoleID.Value);
                if (role == UserRoleId.Controlling)
                {
                    throw new AccessDeniedException("User have no rights to delete entity");
                }
                /*
                if (role != UserRoleId.GlobalAdmin)
                {
                    List<string> pNames = new List<string>();
                    List<object> pValues = new List<object>();
                    string idListStr = QueryUtils.GenIDList(idlist, pNames, pValues);
                    // nothing to delete?
                    if ((idListStr == null) || (idListStr.Length == 0))
                    {
                        return;
                    }
                    IList list =
                        FindByNamedParam(new string[] {"entity.ID"}, null,
                                         string.Format("entity.ID IN ({0})", idListStr), null,
                                         pNames.ToArray(), pValues.ToArray(), false);
                    if ((list == null) || (list.Count != pNames.Count))
                    {
                        throw new AccessDeniedException("User have no rights to delete entity");
                    }
                }
                 * */
                
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("FROM {0} entity WHERE entity.ID IN (", typeof (T).Name);
                List<object> values = new List<object>();
                List<IType> types = new List<IType>();
                IEnumerator<long> ie = idlist.GetEnumerator();
                ie.Reset();
                if (ie.MoveNext())
                {
                    long current = (ie.Current);
                    sb.Append("?");
                    values.Add(current);
                    types.Add(NHibernateUtil.Int64);
                    while (ie.MoveNext())
                    {
                        current = (ie.Current);
                        sb.Append(",?");
                        values.Add(current);
                        types.Add(NHibernateUtil.Int64);
                    }
                }
                if (values.Count > 0)
                {
                    sb.Append(")");
                    HibernateTemplate.Delete(sb.ToString(), values.ToArray(), types.ToArray());
                }
            }
        }

        public virtual void Delete(T daoObj)
        {
            if (daoObj is BaseEntity)
            {
                long id = (daoObj as BaseEntity).ID;
                DoDeleteEntities(new long[] {id});
                OnDaoEntitiesChanged(id);
            }
            else
            {
                HibernateTemplate.Delete(daoObj);
            }
        }

        public virtual void DeleteList(IList list)
        {
            if ((list != null) && (list.Count > 0))
            {
                List<long> ids = new List<long>();
                foreach (T obj in list)
                {
                    if (obj is BaseEntity)
                    {
                        ids.Add((obj as BaseEntity).ID);
                    }
                    else
                    {
                        HibernateTemplate.Delete(obj);
                    }
                }
                if (ids.Count > 0)
                {
                    DoDeleteEntities(ids);
                    OnDaoEntitiesChanged(ids);
                }
            }
        }

        public virtual void DeleteByID(long id)
        {
            DoDeleteEntities(new long[] {id});
            OnDaoEntitiesChanged(id);
        }

        public virtual void DeleteListByID(IEnumerable<long> idlist)
        {
            if (idlist != null)
            {
                DoDeleteEntities(idlist);
                OnDaoEntitiesChanged(idlist);
            }
        }

        public bool IsPermittedAll(User user, bool forReading)
        {
            string outStr;
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();
            // it should be faster than "select"-ing from DB anyway
            return (CreatePermittedIDFilter(pNames, pValues, forReading, out outStr, user) == PermittedIDsResult.All);
        }

        public virtual new void AfterPropertiesSet()
        {
            base.AfterPropertiesSet();
        }

        #endregion

        #region IInterceptor Members

        /*
        public virtual int[] FindDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, global::NHibernate.Type.IType[] types)
        {
            return null;
        }

        public virtual object Instantiate(Type type, object id)
        {
            return null;
        }

        public virtual object IsUnsaved(object entity)
        {
            return null;
        }

        public virtual void OnDelete(object entity, object id, object[] state, string[] propertyNames, global::NHibernate.Type.IType[] types)
        {
        }

        public virtual bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, global::NHibernate.Type.IType[] types)
        {
            return false;
        }

        public virtual bool OnLoad(object entity, object id, object[] state, string[] propertyNames, global::NHibernate.Type.IType[] types)
        {
            return false;
        }

        public virtual bool OnSave(object entity, object id, object[] state, string[] propertyNames, global::NHibernate.Type.IType[] types)
        {
            return false;
        }

        public virtual void PostFlush(ICollection entities)
        {
        }

        public virtual void PreFlush(ICollection entities)
        {
        }
        #endregion
        
        public new void AfterPropertiesSet()
        {
            base.AfterPropertiesSet();

            HibernateTemplate.EntityInterceptor = this;
        }

        #region IInitializingObject Members

        void IInitializingObject.AfterPropertiesSet()
        {
            HibernateTemplate.EntityInterceptor = this;
        }
        */

        #endregion
    }
}