using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Dao
{
    public delegate void DaoEntitiesChangedDelegate(IEnumerable<long> ids);

    public delegate void DaoInvalidateWholeCacheDelegate();

    public interface IDao<T>
    {
        event DaoEntitiesChangedDelegate DaoEntitiesChanged;
        void OnDaoEntitiesChanged(IEnumerable<long> ids);
        void OnDaoEntitiesChanged(long id);
        event DaoInvalidateWholeCacheDelegate DaoInvalidateWholeCache;
        void OnDaoInvalidateWholeCache();

        T FindById(long id);
        IList FindByIDList(IEnumerable<long> ids);
        IList GetIDList(); // items in result are long (NOT <T>!)
        IList FindAll();
        IList FindByNamedParam(string condition, string[] paramNames, object[] paramValues);
        IList FindByNamedParam(string fromAddition, string condition, string[] paramNames, object[] paramValues);

        IList FindByNamedParam(string fromAddition, string condition, string afterJoinClauses, string[] paramNames,
                               object[] paramValues);
        IList FindByNamedParam(string fromAddition, string condition, string afterJoinClauses, string paramName,
                               object paramValue);
        IList FindByNamedParam(string[] fields, string fromAddition, string condition, string afterJoinClauses,
                                      string[] paramNames, object[] paramValues, bool bCheckForReading);
        IList FindByNamedParam(string[] fields, string fromAddition, string condition, string afterJoinClauses,
                                      string[] paramNames, object[] paramValues, bool bCheckForReading, User user);

        T Save(T daoObj);
        void SaveList(IList list);
        T SaveOrUpdate(T daoObj);
        void SaveOrUpdateList(IList list);
        T Update(T daoObj);
        void UpdateList(IList list);
        void Delete(T daoObj);
        void DeleteByID(long id);
        void DeleteList(IList list);
        void DeleteListByID(IEnumerable<long> idlist);

        bool IsPermittedAll(User user, bool forReading);
    }
}