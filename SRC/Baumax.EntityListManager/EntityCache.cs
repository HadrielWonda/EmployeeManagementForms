using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.EntityListManager
{
    [Serializable]
    public class EntityCache<T> : IEntityCache<T>
        where T : BaseEntity
    {
        protected Dictionary<long, T> _index = new Dictionary<long, T>();

        public event EntityAddedDelegate EntityAdded;
        public event EntityDeletedDelegate EntityDeleted;
        public event EntityUpdatedDelegate EntityUpdated;

        public virtual void Add(T entity)
        {
            if (_index.ContainsKey(entity.ID))
            {
                this[entity.ID] = entity;
                OnUpdated(entity);
            }
            else
            {
                _index.Add(entity.ID, entity);
                OnAdded(entity);
            }
        }

        public virtual void Add(IEnumerable<T> entities)
        {
            if (entities != null)
            {
                foreach (T t in entities)
                {
                    Add(t);
                }
            }
        }

        public virtual void Update(T entity)
        {
            if (_index.ContainsKey(entity.ID))
            {
                if (_index[entity.ID] != entity)
                {
                    _index[entity.ID] = entity;
                    OnUpdated(entity);
                }
            }
        }

        public virtual void Delete(T entity)
        {
            if (_index.ContainsKey(entity.ID))
            {
                _index.Remove(entity.ID);
                OnDeleted(entity);
            }
        }

        public virtual void Delete(long id)
        {
            if (_index.ContainsKey(id))
            {
                T entity = _index[id];
                _index.Remove(id);
                OnDeleted(entity);
            }
        }

        public void Delete(IEnumerable<long> idList)
        {
            foreach(long id in idList)
            {
                Delete(id);
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                Delete(entity.ID);
            }
        }
        
        public virtual List<long> GetIDList()
        {
            return new List<long>(_index.Keys);
        }

        public virtual List<T> GetAll()
        {
            //List<T> res = new List<T>(_index.Values.Count);
            //res.AddRange(_index.Values);
            //return res;
            return new List<T>(_index.Values);
        }

        public virtual List<T> GetFiltered(FilterDelegate<T> fd)
        {
            return GetFiltered(fd, null);
        }

        public List<T> GetFiltered(FilterDelegate<T> fd, Comparison<T> comparer)
        {
            if (fd == null)
            {
                return null;
            }
            List<T> result = new List<T>();
            foreach (KeyValuePair<long, T> pair in _index)
            {
                if (fd(pair.Value))
                {
                    result.Add(pair.Value);
                }
            }

            if ((result.Count > 0) && (comparer != null))
            {
                result.Sort(comparer);
            }
            if(result.Count == 0)
            {
                return null;
            }
            return result;
        }

        public virtual IList<T> GetFiltered(IFilterEntity<T> fd)
        {
            List<T> res = new List<T>();
            foreach (KeyValuePair<long, T> pair in _index)
            {
                if (fd.IsOK(pair.Value))
                {
                    res.Add(pair.Value);
                }
            }
            if (res.Count == 0)
            {
                return null;
            }
            return res;
        }

        public virtual T Find(FilterDelegate<T> fd)
        {
            foreach (KeyValuePair<long, T> pair in _index)
            {
                if (fd(pair.Value))
                {
                    return pair.Value;
                }
            }

            return null;
        }

        public virtual bool Contains(T entity)
        {
            return _index.ContainsKey(entity.ID);
        }

        public virtual bool Contains(long id)
        {
            return _index.ContainsKey(id);
        }

        public virtual void Clear()
        {
            _index.Clear();
        }

        public virtual T this[long id]
        {
            get
            {
                T res;
                if (_index.TryGetValue(id, out res))
                {
                    return res;
                }
                else
                {
                    return default(T);
                }
            }

            set
            {
                // do we need to fire onAdded/Updated event here?
                _index[id] = value;
            }
        }

        public int Count
        {
            get { return _index.Count; }
        }

        protected virtual void OnAdded(T entity)
        {
            if (EntityAdded != null)
            {
                EntityAdded(this, entity);
            }
        }

        protected virtual void OnDeleted(T entity)
        {
            if (EntityDeleted != null)
            {
                EntityDeleted(this, entity);
            }
        }

        protected virtual void OnUpdated(T entity)
        {
            if (EntityUpdated != null)
            {
                EntityUpdated(this, entity);
            }
        }
    }
}