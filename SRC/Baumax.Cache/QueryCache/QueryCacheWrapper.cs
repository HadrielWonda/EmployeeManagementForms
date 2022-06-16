using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Baumax.Contract.Interfaces;

namespace Baumax.Cache
{
    public class QueryCacheWrapper<TKey, TValue>
        where TValue : IKey<TKey>
    {
        protected QueryCache<TKey, TValue> _Cache;
        public QueryCacheWrapper(string query, IQueryCacheDao queryCacheDao)
        {
            _Cache = new QueryCache<TKey, TValue>(query, queryCacheDao);
            _Cache.LoadCache();
        }

        public void Add(TValue value)
        {
            _Cache.Add(value);
        }

        public void Add(IEnumerable<TValue> value)
        {
            _Cache.Add(value);
        }

        public void ReloadCache()
        {
            _Cache.ReloadCache();
        }
    }
}
