using System;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IService
    {
        Guid ServiceId { get; }

        // unfortunately, all services require to call "Init" method AFTER login.
        // otherwise it is impossible to subscribe server-services' events because of
        // security violation. so please call manually "Init" method for EVERY service 
        // (including nested ones) after successful login.
        void Init();
    }

    public interface IBaseService<T> : IService
        where T : BaseEntity
    {
        // supposed for local access (client and server)
        event EntitiesChangedDelegate EntitiesChanged;
        event InvalidateWholeCacheDelegate InvalidateWholeCache;
        // supposed for remote subscribing
        void SubscribeEntitiesChanged(IChangeReceiver receiver);
        void UnsubscribeEntitiesChanged(IChangeReceiver receiver);
        void SubscribeInvalidateWholeCache(IInvalidateWholeCacheReceiver receiver);
        void UnsubscribeInvalidateWholeCache(IInvalidateWholeCacheReceiver receiver);

        List<long> GetIDList();
        T FindById(long id);
        List<T> FindByIDList(List<long> ids);
        List<T> FindAll();
        List<T> FindByNamedParam(string condition, string[] paramNames, object[] paramValues);
        List<T> FindByNamedParam(string fromAddition, string condition, string[] paramNames, object[] paramValues);

        List<T> FindByNamedParam(string fromAddition, string condition, string afterJoinClauses, string[] paramNames,
                                 object[] paramValues);

        List<T> FindByNamedParam(string fromAddition, string condition, string afterJoinClauses, string paramName,
                                 object paramValue);

        T SaveOrUpdate(T entity);
        void SaveOrUpdateList(List<T> entities);
        T Save(T entity);
        void SaveList(List<T> entities);
        T Update(T entity);
        void UpdateList(List<T> entities);
        void Delete(T entity);
        void DeleteList(List<T> entities);
        void DeleteByID(long id);
        void DeleteListByID(List<long> ids);

        T CreateEntity();
    }
}