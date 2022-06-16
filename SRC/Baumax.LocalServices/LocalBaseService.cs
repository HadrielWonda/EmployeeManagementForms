using System;
using System.Collections.Generic;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalBaseService<T> : LocalService, IBaseService<T>
        where T : BaseEntity, new()
    {
        #region Fields

        protected static long _nextID = -1;

        #endregion

        private IBaseService<T> RemoteService
        {
            get { return (IBaseService<T>) base._remoteService; }
        }

        #region IBaseService<T> Members

        // not really used locally.
        public event EntitiesChangedDelegate EntitiesChanged;
        public event InvalidateWholeCacheDelegate InvalidateWholeCache;

        public virtual T AfterEntityLoaded(T entity)
        {
            return entity;
        }

        protected List<T> AfterEntitiesLoaded(List<T> entities)
        {
            if ((entities != null) && (entities.Count > 0))
            {
                foreach (T entity in entities)
                {
                    AfterEntityLoaded(entity);
                }
            }
            return entities;
        }

        public virtual List<long> GetIDList()
        {
            return RemoteService.GetIDList();
        }

        public virtual T FindById(long id)
        {
            return AfterEntityLoaded(RemoteService.FindById(id));
        }

        public virtual List<T> FindByIDList(List<long> ids)
        {
            return AfterEntitiesLoaded(RemoteService.FindByIDList(ids));
        }

        public virtual List<T> FindAll()
        {
            return AfterEntitiesLoaded(RemoteService.FindAll());
        }

        public virtual List<T> FindByNamedParam(string condition, string[] paramNames, object[] paramValues)
        {
            return AfterEntitiesLoaded(RemoteService.FindByNamedParam(condition, paramNames, paramValues));
        }

        public List<T> FindByNamedParam(string fromAddition, string condition, string[] paramNames, object[] paramValues)
        {
            return AfterEntitiesLoaded(RemoteService.FindByNamedParam(fromAddition, condition, paramNames, paramValues));
        }

        public List<T> FindByNamedParam(string fromAddition, string condition, string afterJoinClauses, string[] paramNames, object[] paramValues)
        {
            return AfterEntitiesLoaded(RemoteService.FindByNamedParam(fromAddition, condition, afterJoinClauses, paramNames, paramValues));
        }

        public List<T> FindByNamedParam(string fromAddition, string condition, string afterJoinClauses, string paramName, object paramValue)
        {
            return AfterEntitiesLoaded(RemoteService.FindByNamedParam(fromAddition, condition, afterJoinClauses, paramName, paramValue));
        }

        public virtual T SaveOrUpdate(T entity)
        {
            return RemoteService.SaveOrUpdate(entity);
        }

        public virtual void SaveOrUpdateList(List<T> entities)
        {
            RemoteService.SaveOrUpdateList(entities);
        }

        public virtual T Save(T entity)
        {
            return RemoteService.Save(entity);
        }

        public virtual void SaveList(List<T> entities)
        {
            RemoteService.SaveList(entities);
        }

        public T Update(T entity)
        {
            return RemoteService.Update(entity);
        }

        public void UpdateList(List<T> entities)
        {
            RemoteService.UpdateList(entities);
        }

        public virtual void Delete(T entity)
        {
            RemoteService.Delete(entity);
        }

        public virtual void DeleteList(List<T> entities)
        {
            RemoteService.DeleteList(entities);
        }

        public virtual void DeleteByID(long id)
        {
            RemoteService.DeleteByID(id);
        }

        public virtual void DeleteListByID(List<long> ids)
        {
            RemoteService.DeleteListByID(ids);
        }

        public virtual T CreateEntity()
        {
            T entity = new T();
            entity.ID = _nextID--;
            return entity;
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void SubscribeEntitiesChanged(IChangeReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void SubscribeInvalidateWholeCache(IInvalidateWholeCacheReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void UnsubscribeEntitiesChanged(IChangeReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }

        /// <summary>
        /// Use events for local needs instead of this
        /// </summary>
        public void UnsubscribeInvalidateWholeCache(IInvalidateWholeCacheReceiver receiver)
        {
            throw new ApplicationException("Remote using only method");
        }
        
        #endregion

        protected virtual void OnEntitiesChanged(IEnumerable<long> ids)
        {
            if (EntitiesChanged != null)
            {
                EntitiesChanged(ids);
            }
        }

        protected virtual void OnInvalidateWholeCache()
        {
            if (InvalidateWholeCache != null)
            {
                InvalidateWholeCache();
            }
        }
    }
}