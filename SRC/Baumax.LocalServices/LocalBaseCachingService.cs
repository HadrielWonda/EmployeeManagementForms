using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.EntityListManager;
using Baumax.Environment.Interfaces;
using Common.Logging;

namespace Baumax.LocalServices
{
    public enum CachingPolicy : int
    {
        // setting values manually to ensure validity while injecting properties
        None = 0, // no caching at all
        Demanded = 1, // cache entities that are requested by id, not any more
        Dictionary = 2 // cache all
    }

    public class LocalBaseCachingService<T> : LocalBaseService<T>, IBaseService<T>, IStreamingService
        where T : BaseEntity, new()
    {
        #region Fields

        static ILog log = LogManager.GetLogger(typeof (LocalBaseCachingService<T>));

        protected int _cachingPolicy;
        protected IEntityCache<T> _cache = new EntityCache<T>();
        private bool _isCacheValid = false;
        private bool _subscribed = false;
        protected ChangeReceiver<T> _changeReceiver;
        protected InvalidateWholeCacheReceiver<T> _invalidateWholeCacheReceiver;

        #endregion

        #region Properties

        public bool IsWholeCacheValid
        {
            get { return _isCacheValid && !_changeReceiver.HasChanges && !_invalidateWholeCacheReceiver.IsInvalid; }
        }

        protected CachingPolicy CachingPolicy
        {
            get { return (CachingPolicy) _cachingPolicy; }
            set
            {
                if (value != (CachingPolicy) _cachingPolicy)
                {
                    DoSetCachingPolicy(value);
                }
            }
        }

        #endregion

        #region Event handlers

        public void _remoteService_EntitiesChanged(IEnumerable<long> ids)
        {
            OnEntitiesChanged(ids);
        }

        public void _remoteService_InvalidateWholeCache()
        {
            OnInvalidateWholeCache();
        }

        #endregion

        #region Private methods

        private void DoSetCachingPolicy(CachingPolicy value)
        {
            switch (value)
            {
                case CachingPolicy.None:
                    if (_subscribed)
                    {
                        RemoteUnsubscribe();
                    }
                    ClearCache();
                    break;
                case CachingPolicy.Demanded:
                    // cached elements and validity remains
                    if (!_subscribed)
                    {
                        RemoteSubscribe();
                    }
                    break;
                case CachingPolicy.Dictionary:
                    if (!_subscribed)
                    {
                        RemoteSubscribe();
                    }
                    RefreshCacheIfNeed();
                    break;
                default:
                    throw new Exception(
                        string.Format("LocalBaseCachingService: Unknown value of type {0}",
                                      typeof (CachingPolicy).FullName));
            }
            _cachingPolicy = (int) value;
        }

        private List<T> ReNewCacheFromBase()
        {
            ClearCache();
            List<T> result = base.FindAll();
            if (result != null)
            {
                _cache.Add(result);
            }
            _isCacheValid = true;
            return result;
        }

        private void ClearCache()
        {
            _cache.Clear();
            _isCacheValid = false;
        }

        #endregion

        #region IBaseService<T> Members

        public override void Init()
        {
            base.Init();

            // if connection was broken we can't count on old data in cache any more
            ClearCache();
            // enforce resubscribe
            _subscribed = false;
            DoSetCachingPolicy((CachingPolicy) _cachingPolicy);
        }

        protected virtual void RemoteSubscribe()
        {
            _changeReceiver = new ChangeReceiver<T>((IBaseService<T>) _remoteService);
            _changeReceiver.EntitiesChanged += new EntitiesChangedDelegate(_remoteService_EntitiesChanged);
            _invalidateWholeCacheReceiver = new InvalidateWholeCacheReceiver<T>((IBaseService<T>) _remoteService);
            _invalidateWholeCacheReceiver.InvalidateWholeCache +=
                new InvalidateWholeCacheDelegate(_remoteService_InvalidateWholeCache);
        }

        protected virtual void RemoteUnsubscribe()
        {
            // clear id list
            _changeReceiver.GetIds();
            _changeReceiver.EntitiesChanged -= _remoteService_EntitiesChanged;
            _invalidateWholeCacheReceiver.InvalidateWholeCache -= _remoteService_InvalidateWholeCache;
        }

        public override List<long> GetIDList()
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
            }
            if ((CachingPolicy != CachingPolicy.None) && (IsWholeCacheValid))
            {
                return _cache.GetIDList();
            }
            return base.GetIDList();
        }

        public override T FindById(long id)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
            }
            if ((CachingPolicy != CachingPolicy.None) && (IsWholeCacheValid))
            {
                return _cache[id];
            }
            if ((CachingPolicy == CachingPolicy.Demanded) && (_cache[id] != null) && (!_changeReceiver.IsInList(id)))
            {
                return _cache[id];
            }
            T result = base.FindById(id);
            if (result != default(T))
            {
                _cache[id] = result;
            }
            else
            {
                _cache.Delete(id);
            }
            if (CachingPolicy != CachingPolicy.None)
            {
                _changeReceiver.RemoveFromList(id);
            }
            return result;
        }

        public override List<T> FindByIDList(List<long> ids)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
            }
            List<T> result = new List<T>();
            if ((CachingPolicy != CachingPolicy.None) && (IsWholeCacheValid))
            {
                foreach (long id in ids)
                {
                    T item = _cache[id];
                    if (item != null)
                    {
                        result.Add(item);
                    }
                }
                if (result.Count == 0)
                {
                    return null;
                }
                return result;
            }
            List<long> filteredIDs = new List<long>(ids);
            if (CachingPolicy == CachingPolicy.Demanded)
            {
                foreach (long id in ids)
                {
                    if ((_cache[id] != null) && (!_changeReceiver.IsInList(id)))
                    {
                        result.Add(_cache[id]);
                        int index = filteredIDs.IndexOf(id);
                        while (index != -1)
                        {
                            filteredIDs.RemoveAt(index);
                            index = filteredIDs.IndexOf(id);
                        }
                    }
                }
            }
            if (filteredIDs.Count > 0)
            {
                List<T> remoteList = base.FindByIDList(filteredIDs);
                if ((remoteList != null) && (remoteList.Count > 0))
                {
                    result.AddRange(remoteList);
                    _changeReceiver.RemoveFromList(filteredIDs);
                    _cache.Delete(filteredIDs);
                    _cache.Add(remoteList);
                }
            }

            if (result.Count == 0)
            {
                return null;
            }
            return result;
        }

        public override List<T> FindAll()
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
            }
            if ((CachingPolicy != CachingPolicy.None) && (IsWholeCacheValid))
            {
                return _cache.GetAll();
            }
            return ReNewCacheFromBase();
        }

        public override T SaveOrUpdate(T entity)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
            }
            T result = base.SaveOrUpdate(entity);
            _cache[result.ID] = result;
            return result;
        }

        public override void SaveOrUpdateList(List<T> entities)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
            }
            base.SaveOrUpdateList(entities);
            // id's of entities may change from unset (0) to real ones. 
            // but here we don't know anything about...
            // server's notification to clients should resolve this problem
            // just set cache to invalid state for now
            _isCacheValid = false;
        }

        public override T Save(T entity)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
            }
            T result = base.Save(entity);
            _cache[result.ID] = result;
            return result;
        }

        public override void SaveList(List<T> entities)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
            }
            base.SaveList(entities);
            // id's of entities may change from unset (0) to real ones. 
            // but here we don't know anything about...
            // server's notification to clients should resolve this problem
            // just set cache to invalid state for now
            _isCacheValid = false;
        }

        public override void Delete(T entity)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
            }
            if (!entity.IsNew)
            {
                base.Delete(entity);
            }
            _cache.Delete(entity.ID);
        }

        public override void DeleteList(List<T> entities)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
            }
            if (entities != null)
            {
                List<T> tmp = new List<T>(entities.Count);
                foreach (T t in entities)
                {
                    if (!t.IsNew)
                    {
                        tmp.Add(t);
                    }
                }

                base.DeleteList(tmp);

                _cache.Delete(tmp);
            }
        }

        public override void DeleteByID(long id)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
            }
            base.DeleteByID(id);
            _cache.Delete(id);
        }

        public override void DeleteListByID(List<long> ids)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
            }
            base.DeleteListByID(ids);
            if (ids != null)
            {
                _cache.Delete(ids);
            }
        }

        #endregion

        /// <summary>
        /// Refreshes the cache if need to.
        /// </summary>
        public void RefreshCacheIfNeed()
        {
            if (IsWholeCacheValid)
            {
                return;
            }
            if (_invalidateWholeCacheReceiver.IsInvalid)
            {
                _invalidateWholeCacheReceiver.Reset();
                ReNewCacheFromBase();
                OnInvalidateWholeCache();
                // ? should we?
                //OnEntitiesChanged(_cache.GetIDList());
            }
            else
            {
                List<long> res = _changeReceiver.GetIds();
                if (res == null || res.Count == 0)
                {
                    ReNewCacheFromBase();
                }
                else
                {
                    // delete before asking for changed 
                    // or else we should later manually skip deleted entities
                    foreach (long id in res)
                    {
                        _cache.Delete(id);
                    }
                    _cache.Add(base.FindByIDList(res));
                }
                _isCacheValid = true;
                OnEntitiesChanged(res);
            }
        }

        #region IStreamingService Members

        public virtual void SaveToStream(Stream stream)
        {
            // 2think: refreshing can consume big amount of time.
            RefreshCacheIfNeed();
            Debug.Assert(stream.CanWrite,
                         string.Format("stream \"{0}\" doesn't support Write operation", stream.GetType().FullName));

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, _cache);
        }

        public virtual void RestoreFromStream(Stream stream)
        {
            Debug.Assert(stream.CanRead,
                         string.Format("stream \"{0}\" doesn't support Read operation", stream.GetType().FullName));

            BinaryFormatter bf = new BinaryFormatter();
            _cache = (EntityCache<T>) (bf.Deserialize(stream));

            // suppose we should call AfterEntitiesLoaded() or overload Save/RestoreFromStream() 
            // for specific local services to implement custom client serialization 
            // of fields that was marked as non-serialized for better remoting performance
            AfterEntitiesLoaded(_cache.GetAll());
        }

        #endregion
    }
}