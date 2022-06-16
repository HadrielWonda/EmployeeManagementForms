using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Rsdn.Framework.Data.Mapping;
using Baumax.Contract.Interfaces;
using System.Threading;

namespace Baumax.Cache
{
    public class QueryCache<TKey, TValue>
        where TValue : IKey<TKey>
    {
        
        string _Query;
        IQueryCacheDao _QueryCacheDao;
        Dictionary<TKey, TValue> _DataCache;

        ReaderWriterLock _SyncDataCache = new ReaderWriterLock();

        #region InvalidCache property

        object _SyncInvalidCache = new Object();
        bool _InvalidCache;
        bool InvalidCache
        {
            get { return _InvalidCache; }
            set 
            {
                lock (_SyncInvalidCache)
                {
                    if (_InvalidCache != value)
                    {
                        _InvalidCache = value;
                    }
                }
            }
        }
        #endregion

        #region Construntors

        public QueryCache(string query, IQueryCacheDao queryCacheDao)
        {
            _Query = query;
            _QueryCacheDao = queryCacheDao;
            _DataCache = new Dictionary<TKey, TValue>();
            InvalidCache = true;
        }
        #endregion

        #region Private functions

        private void InsertDataInCache ()
        {
            if (InvalidCache)
            {
                List<TValue> result = new List<TValue>();
                using (IDataReader reader = _QueryCacheDao.GetDataReader(_Query))
                {
                    result = Map.ToList<TValue>(reader);
                }
                InvalidCache = false;
                
                _SyncDataCache.AcquireWriterLock(Timeout.Infinite);
                try
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        _DataCache.Add(result[i].GetKey(), result[i]);
                    }
                }
                finally
                {
                    _SyncDataCache.ReleaseWriterLock();
                }
            }
        }

        private TValue this[TKey key]
        {
            get
            {
                TValue res;
                if (_DataCache.TryGetValue(key, out res))
                {
                    return res;
                }
                else
                {
                    return default(TValue);
                }
            }
            set
            {
                _DataCache[key] = value;
            }
        }

        private void ResetCache()
        {
            _SyncDataCache.AcquireWriterLock(Timeout.Infinite);
            try
            {
                _DataCache.Clear();
            }
            finally
            {
                _SyncDataCache.ReleaseWriterLock();
            }
            InvalidCache = true;
        }

        #endregion

        #region Public functions

        public void Add(TValue value)
        {
            TKey key = value.GetKey();
            _SyncDataCache.AcquireWriterLock(Timeout.Infinite);
            try
            {
                if (_DataCache.ContainsKey(key))
                {
                    this[key] = value;
                }
                else
                {
                    _DataCache.Add(key, value);
                }
            }
            finally
            {
                _SyncDataCache.ReleaseWriterLock();
            }
        }

        public void Add(IEnumerable<TValue> value)
        {
            if (value != null)
            {
                foreach (TValue t in value)
                {
                    Add(t);
                }
            }
        }

        public List<TValue> FindAll(string query)
        {
            _SyncDataCache.AcquireReaderLock(Timeout.Infinite);
            try
            {
                return new List<TValue>(_DataCache.Values);
            }
            finally
            {
                _SyncDataCache.ReleaseReaderLock();
            }
        }

        public List<TValue> FindByFilter(FilterDelegate<TValue> fd)
        {
            return FindByFilter(fd, null);
        }

        public List<TValue> FindByFilter(FilterDelegate<TValue> fd, Comparison<TValue> comparer)
        {
            if (fd == null)
            {
                return null;
            }
            List<TValue> result = new List<TValue>();
            _SyncDataCache.AcquireReaderLock(Timeout.Infinite);
            try
            {
                foreach (KeyValuePair<TKey, TValue> pair in _DataCache)
                {
                    if (fd(pair.Value))
                    {
                        result.Add(pair.Value);
                    }
                }
            }
            finally
            {
                _SyncDataCache.ReleaseReaderLock();
            }
            if ((result.Count > 0) && (comparer != null))
            {
                result.Sort(comparer);
            }
            if (result.Count == 0)
            {
                return null;
            }
            return result;
        }

        public void LoadCache()
        {
            InsertDataInCache();
        }

        public void ReloadCache()
        {
            ResetCache();
            InsertDataInCache();
        }

        #endregion
    }
}
