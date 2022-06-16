using System;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.EntityListManager
{
    public delegate bool FilterDelegate<T>(T item);
    
    public delegate bool EntityAddedDelegate(object sender, BaseEntity entity);
    public delegate bool EntityDeletedDelegate(object sender, BaseEntity entity);
    public delegate bool EntityUpdatedDelegate(object sender, BaseEntity entity);

    public interface IFilterEntity<T>
    {
        bool IsOK(T entity);// :-) good method
    }



    public interface IEntityCache<T>
    {
        event EntityAddedDelegate EntityAdded;
        event EntityDeletedDelegate EntityDeleted;
        event EntityUpdatedDelegate EntityUpdated;
        
        void Add(T entity);
        void Add(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Delete(long id);
        void Delete(IEnumerable<long> idList);
        void Delete(IEnumerable<T> entities);
        List<long> GetIDList();
        List<T> GetAll();
        List<T> GetFiltered(FilterDelegate<T> fd);
        List<T> GetFiltered(FilterDelegate<T> fd, Comparison<T> comparer);
        T Find(FilterDelegate<T> fd);
        void Clear();
        bool Contains(T entity);
        bool Contains(long id);
        T this[long id] { get; set;}
        int Count { get; }
    }
}