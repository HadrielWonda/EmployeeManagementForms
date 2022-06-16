using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Util;
using Belikov.GenuineChannels;
using Belikov.GenuineChannels.BroadcastEngine;
using Spring.Transaction.Interceptor;
using Baumax.Localization;

namespace Baumax.Services
{
    public class BaseService<T> : RemoteService, IBaseService<T>
        where T : BaseEntity, new()
    {
        #region Private fields

        protected IDao<T> _dao;

#if DEBUG
        // the same bibb as for local services
        private bool _inited;
#endif

        #endregion

        #region Protected fields

        // for CreateEntity-like functions. 
        // suppose, it's not a good enough way for server, but client implementation requires...
        protected static long _nextID = -1;

        #endregion

        #region Properties

        public virtual IDao<T> Dao
        {
            get
            {
#if DEBUG
                if (!_inited)
                {
                    throw new ApplicationException("Service " + this.GetType().FullName + " is NOT initialized");
                }
#endif
                return _dao;
            }
            set { _dao = value; }
        }

        #endregion

        #region Private Methods

        private void _dao_DaoEntitiesChanged(IEnumerable<long> ids)
        {
            OnEntitiesChanged(ids);
        }

        private void _dao_DaoInvalidateWholeCache()
        {
            OnInvalidateWholeCache();
        }

        private void CorrectID(T entity)
        {
            if (entity.ID < 0)
            {
                entity.ID = 0;
            }
        }

        #endregion

        #region Constructors

        static BaseService()
        {
            DefaultDiction.BuildDefaultResource();
        }

        public BaseService()
        {
            _entitiesChangedDispatcher.BroadcastCallFinishedHandler +=
                new BroadcastCallFinishedHandler(EntitiesChangedBroadcastCallFinishedHandler);
            _entitiesChangedDispatcher.CallIsAsync = true;
            _entitiesChangedCaller = (IChangeReceiver) _entitiesChangedDispatcher.TransparentProxy;

            _invalidateWholeCacheDispatcher.BroadcastCallFinishedHandler +=
                new BroadcastCallFinishedHandler(InvalidateWholeCacheBroadcastCallFinishedHandler);
            _invalidateWholeCacheDispatcher.CallIsAsync = true;
            _invalidateWholeCacheCaller =
                (IInvalidateWholeCacheReceiver) _invalidateWholeCacheDispatcher.TransparentProxy;
        }

        #endregion

        #region Protected Methods

        protected List<long> GetIDsFromEntityList(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                return null;
            }
            List<long> result = new List<long>();
            foreach (T entity in entities)
            {
                result.Add(entity.ID);
            }
            return result;
        }

        protected List<long> GetIDsFromEntityList(IEnumerable entities)
        {
            if (entities == null)
            {
                return null;
            }
            List<long> result = new List<long>();
            foreach (T entity in entities)
            {
                result.Add(entity.ID);
            }
            return result;
        }

        protected List<T> GetTypedListFromIList(IList list)
        {
            return TypedListConverter<T>.ToTypedList(list);
        }

        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>True if entity is valid</returns>
        protected virtual bool Validate(T entity)
        {
            return true;
        }

        protected void DoValidateAndThrowIfNeed(T entity)
        {
            bool result;
            try
            {
                result = Validate(entity);
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ValidationException(new long[] {entity.ID}, ex);
            }
            if (!result)
            {
                throw new ValidationException(new long[] {entity.ID}, null);
            }
        }

        #endregion

        #region Public Methods

        public virtual void OnEntitiesChanged(IEnumerable<long> ids)
        {
            // local call
            if (_entitiesChanged != null)
            {
                _entitiesChanged(ids);
            }
            // remote call
            EntityChangeFilter<T> filter = new EntityChangeFilter<T>(this);
            using (new DispatcherFilterKeeper(filter))
            {
                _entitiesChangedCaller.ReceiveEntitiesChanged(ids);
            }
            if (Log.IsDebugEnabled)
            {
                StringBuilder sb = new StringBuilder("OnEntitiesChanged:");
                foreach (long value in ids)
                {
                    sb.AppendFormat(" {0}", value);
                }
                Log.Debug(sb.ToString());
            }
        }

        public virtual void OnEntitiesChanged(long id)
        {
            OnEntitiesChanged(new long[] {id});
        }

        public virtual void OnInvalidateWholeCache()
        {
            // local call
            if (_invalidateWholeCache != null)
            {
                _invalidateWholeCache();
            }
            // remote call
            _invalidateWholeCacheCaller.ReceiveInvalidateWholeCache();
            if (Log.IsDebugEnabled)
            {
                Log.Debug("OnInvalidateWholeCache");
            }
        }

        #endregion

        #region IBaseService<T> Members

        private Dispatcher _entitiesChangedDispatcher = new Dispatcher(typeof (IChangeReceiver));
        private IChangeReceiver _entitiesChangedCaller;

        private Dispatcher _invalidateWholeCacheDispatcher = new Dispatcher(typeof (IInvalidateWholeCacheReceiver));
        private IInvalidateWholeCacheReceiver _invalidateWholeCacheCaller;

        private event EntitiesChangedDelegate _entitiesChanged;

        public event EntitiesChangedDelegate EntitiesChanged
        {
            //use SubscribeEntitiesChanged for remote access
            //[AccessType(AccessType.FreeAccess)]
            add { _entitiesChanged += value; }
            //[AccessType(AccessType.FreeAccess)]
            remove { _entitiesChanged -= value; }
        }

        private event InvalidateWholeCacheDelegate _invalidateWholeCache;

        public event InvalidateWholeCacheDelegate InvalidateWholeCache
        {
            //use SubscribeInvalidateWholeCache for remote access
            //[AccessType(AccessType.FreeAccess)]
            add { _invalidateWholeCache += value; }
            //[AccessType(AccessType.FreeAccess)]
            remove { _invalidateWholeCache -= value; }
        }

        [AccessType(AccessType.FreeAccess)]
        public override void Init()
        {
#if DEBUG
            _inited = true;
#endif
            base.Init();
        }

        [AccessType(AccessType.Read)]
        public virtual List<long> GetIDList()
        {
            try
            {
                //2think: it should be enough here to select only id's from table
                IList list = _dao.GetIDList();
                if ((list == null) || (list.Count == 0))
                {
                    return null;
                }
                return TypedListConverter<long>.ToTypedList(list);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public virtual T FindById(long id)
        {
            try
            {
                return _dao.FindById(id);
            }
            catch (Exception ex)
            {
                throw new LoadException(new long[] {id}, ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<T> FindByIDList(List<long> ids)
        {
            try
            {
                return GetTypedListFromIList(_dao.FindByIDList(ids));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public virtual List<T> FindAll()
        {
            try
            {
                return GetTypedListFromIList(_dao.FindAll());
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public virtual List<T> FindByNamedParam(string condition, string[] paramNames, object[] paramValues)
        {
            try
            {
                return GetTypedListFromIList(_dao.FindByNamedParam(condition, paramNames, paramValues));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<T> FindByNamedParam(string fromAddition, string condition, string[] paramNames, object[] paramValues)
        {
            try
            {
                return GetTypedListFromIList(_dao.FindByNamedParam(fromAddition, condition, paramNames, paramValues));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<T> FindByNamedParam(string fromAddition, string condition, string afterJoinClauses,
                                        string[] paramNames,
                                        object[] paramValues)
        {
            try
            {
                return
                    GetTypedListFromIList(
                        _dao.FindByNamedParam(fromAddition, condition, afterJoinClauses, paramNames, paramValues));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<T> FindByNamedParam(string fromAddition, string condition, string afterJoinClauses, string paramName,
                                        object paramValue)
        {
            try
            {
                return
                    GetTypedListFromIList(
                        _dao.FindByNamedParam(fromAddition, condition, afterJoinClauses, paramName, paramValue));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public virtual T SaveOrUpdate(T entity)
        {
            long oldID = entity.ID;
            DoValidateAndThrowIfNeed(entity);
            CorrectID(entity);
            try
            {
                return _dao.SaveOrUpdate(entity);
            }
            catch (Exception ex)
            {
                long[] failedIDs = new long[] {oldID};
                CheckForDBValidationException(failedIDs, ex);
                throw new SaveOrUpdateException(failedIDs, ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public virtual void SaveOrUpdateList(List<T> entities)
        {
            foreach (T entity in entities)
            {
                DoValidateAndThrowIfNeed(entity);
                CorrectID(entity);
            }
            try
            {
                _dao.SaveOrUpdateList(entities);
            }
            catch (Exception ex)
            {
                // 2think: implement DaoException class?
                throw new SaveOrUpdateException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public virtual T Save(T entity)
        {
            long oldID = entity.ID;
            DoValidateAndThrowIfNeed(entity);
            CorrectID(entity);
            try
            {
                return _dao.Save(entity);
            }
            catch (Exception ex)
            {
                long[] failedIDs = new long[] {oldID};
                CheckForDBValidationException(failedIDs, ex);
                throw new SaveException(failedIDs, ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public virtual void SaveList(List<T> entities)
        {
            foreach (T entity in entities)
            {
                DoValidateAndThrowIfNeed(entity);
                CorrectID(entity);
            }
            try
            {
                _dao.SaveList(entities);
            }
            catch (Exception ex)
            {
                // 2think: implement DaoException class?
                throw new SaveException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public virtual T Update(T entity)
        {
            DoValidateAndThrowIfNeed(entity);
            try
            {
                return _dao.Update(entity);
            }
            catch (Exception ex)
            {
                // assume id is not changed during update
                long[] failedIDs = new long[] {entity.ID};
                CheckForDBValidationException(failedIDs, ex);
                throw new UpdateException(failedIDs, ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public virtual void UpdateList(List<T> entities)
        {
            foreach (T entity in entities)
            {
                DoValidateAndThrowIfNeed(entity);
            }
            try
            {
                _dao.UpdateList(entities);
            }
            catch (Exception ex)
            {
                // 2think: implement DaoException class?
                throw new UpdateException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public virtual void Delete(T entity)
        {
            long oldID = entity.ID;
            try
            {
                _dao.Delete(entity);
            }
            catch (Exception ex)
            {
                long[] failedIDs = new long[] {oldID};
                CheckForDBValidationException(failedIDs, ex);
                throw new DeleteException(failedIDs, ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public virtual void DeleteList(List<T> entities)
        {
            try
            {
                _dao.DeleteList(entities);
            }
            catch (Exception ex)
            {
                // 2think: implement DaoException class?
                throw new DeleteException(ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public virtual void DeleteByID(long id)
        {
            try
            {
                _dao.DeleteByID(id);
            }
            catch (Exception ex)
            {
                long[] failedIDs = new long[] {id};
                CheckForDBValidationException(failedIDs, ex);
                throw new DeleteException(failedIDs, ex);
            }
        }

        [AccessType(AccessType.Write)]
        [Transaction]
        public virtual void DeleteListByID(List<long> ids)
        {
            try
            {
                _dao.DeleteListByID(ids);
            }
            catch (Exception ex)
            {
                // 2think: implement DaoException class?
                throw new DeleteException(ex);
            }
        }

        // i insist on using client implementation of this function in future
        [AccessType(AccessType.Read)]
        public virtual T CreateEntity()
        {
            T entity = new T();
            entity.ID = Interlocked.Decrement(ref _nextID);
            return entity;
        }

        [AccessType(AccessType.FreeAccess)]
        public void SubscribeEntitiesChanged(IChangeReceiver receiver)
        {
            // save symbol to client's session
            //GenuineUtility.CurrentSession["symbol"] = symbol;
            // and subscribe the receiver
            _entitiesChangedDispatcher.Add((MarshalByRefObject) receiver, GenuineUtility.CurrentSession);

            if (Log.IsDebugEnabled)
            {
                Log.Debug(
                    string.Format("SubscribeEntitiesChanged: Client with {0} session id has been registered.",
                                  (GenuineUtility.CurrentSession["id"] as SessionId).Id));
            }
        }

        [AccessType(AccessType.FreeAccess)]
        public void UnsubscribeEntitiesChanged(IChangeReceiver receiver)
        {
            _entitiesChangedDispatcher.Remove((MarshalByRefObject) receiver);

            if (Log.IsDebugEnabled)
            {
                Log.Debug(
                    string.Format("UnsubscribeEntitiesChanged: Client with {0} session id has been UNregistered.",
                                  (GenuineUtility.CurrentSession["id"] as SessionId).Id));
            }
        }

        [AccessType(AccessType.FreeAccess)]
        public void SubscribeInvalidateWholeCache(IInvalidateWholeCacheReceiver receiver)
        {
            _invalidateWholeCacheDispatcher.Add((MarshalByRefObject) receiver, GenuineUtility.CurrentSession);

            if (Log.IsDebugEnabled)
            {
                Log.Debug(
                    string.Format("SubscribeInvalidateWholeCache: Client with {0} session id has been registered.",
                                  (GenuineUtility.CurrentSession["id"] as SessionId).Id));
            }
        }

        [AccessType(AccessType.FreeAccess)]
        public void UnsubscribeInvalidateWholeCache(IInvalidateWholeCacheReceiver receiver)
        {
            _invalidateWholeCacheDispatcher.Remove((MarshalByRefObject) receiver);

            if (Log.IsDebugEnabled)
            {
                Log.Debug(
                    string.Format("UnsubscribeInvalidateWholeCache: Client with {0} session id has been UNregistered.",
                                  (GenuineUtility.CurrentSession["id"] as SessionId).Id));
            }
        }

        #endregion

        #region IInitializingObject Members

        public override void AfterPropertiesSet()
        {
            _dao.DaoEntitiesChanged += new DaoEntitiesChangedDelegate(_dao_DaoEntitiesChanged);
            _dao.DaoInvalidateWholeCache += new DaoInvalidateWholeCacheDelegate(_dao_DaoInvalidateWholeCache);
            base.AfterPropertiesSet();
        }

        #endregion

        private void EntitiesChangedBroadcastCallFinishedHandler(Dispatcher dispatcher, IMessage message,
                                                                 ResultCollector resultCollector)
        {
            lock (resultCollector)
            {
                /*
                foreach (DictionaryEntry entry in resultCollector.Successful)
                {
                    IMethodReturnMessage iMethodReturnMessage =
                       (IMethodReturnMessage)entry.Value;

                    // here you get client responses
                    // including out and ref parameters
                    Console.WriteLine("EntitiesChangedBroadcastCallFinishedHandler: Returned object = {0}",
                                 iMethodReturnMessage.ReturnValue.ToString());
                }*/

                foreach (DictionaryEntry entry in resultCollector.Failed)
                {
                    string mbrUri = (string) entry.Key;
                    Exception ex = null;
                    if (entry.Value is Exception)
                    {
                        ex = (Exception) entry.Value;
                    }
                    else
                    {
                        ex = ((IMethodReturnMessage) entry.Value).Exception;
                    }
                    MarshalByRefObject failedObject =
                        dispatcher.FindObjectByUri(mbrUri);

                    Console.WriteLine(
                        "EntitiesChangedBroadcastCallFinishedHandler: Receiver {0} has failed. Error: {1}",
                        mbrUri, ex.Message);
                    // here you have failed MBR object (failedObject)
                    // and Exception (ex)
                }
            }
        }

        private void InvalidateWholeCacheBroadcastCallFinishedHandler(Dispatcher dispatcher, IMessage message,
                                                                      ResultCollector resultCollector)
        {
            lock (resultCollector)
            {
                /*
                foreach (DictionaryEntry entry in resultCollector.Successful)
                {
                    IMethodReturnMessage iMethodReturnMessage =
                       (IMethodReturnMessage)entry.Value;

                    // here you get client responses
                    // including out and ref parameters
                    if (Log.IsDebugEnabled)
                    {
                        Log.Debug(string.Format("InvalidateWholeCacheBroadcastCallFinishedHandler: Returned object = {0}",
                                          iMethodReturnMessage.ReturnValue.ToString()));
                    }
                }*/

                foreach (DictionaryEntry entry in resultCollector.Failed)
                {
                    string mbrUri = (string) entry.Key;
                    Exception ex = null;
                    if (entry.Value is Exception)
                    {
                        ex = (Exception) entry.Value;
                    }
                    else
                    {
                        ex = ((IMethodReturnMessage) entry.Value).Exception;
                    }
                    MarshalByRefObject failedObject =
                        dispatcher.FindObjectByUri(mbrUri);

                    if (Log.IsDebugEnabled)
                    {
                        Log.Debug(
                            string.Format(
                                "InvalidateWholeCacheBroadcastCallFinishedHandler: Receiver {0} has failed. Error: {1}",
                                mbrUri, ex.Message));
                    }
                    // here you have failed MBR object (failedObject)
                    // and Exception (ex)
                }
            }
        }

        protected string GetLocalized(string key)
        {
            return Baumax.Localization.Localizer.GetLocalized(key);
        }

    }
}