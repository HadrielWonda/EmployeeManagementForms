using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;
using Baumax.Contract.Exceptions;

namespace Baumax.Services
{
    [ServiceID("86DE68FA-6EC6-4b6f-8285-55A96C7886C3")]
    public class FeastService : BaseService<Feast>, IFeastService
    {
        private static bool _IsRunningFeastImport = false;
        private static Object _SyncIsRunningFeastImport = new Object();

        private static bool IsRunningFeastImport
        {
            get { return _IsRunningFeastImport; }
            set
            {
                lock (_SyncIsRunningFeastImport)
                {
                    if (_IsRunningFeastImport != value)
                        _IsRunningFeastImport = value;
                }
            }
        }

        #region IFeastService Members

        [AccessType(AccessType.Read)]
        public List<Feast> GetFeastsFiltered(long countryID, DateTime? from, DateTime? to)
        {
            try
            {
                return GetTypedListFromIList(((IFeastDao) Dao).GetFeastsFiltered(countryID, from, to));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Import)]
        public SaveDataResult ImportFeasts(List<ImportDaysData> list)
        {
            if (IsRunningFeastImport)
                throw new AnotherImportRunning();
            IsRunningFeastImport = true;
            try
            {
                return ((IFeastDao)Dao).ImportFeasts(list);
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
            finally
            {
                IsRunningFeastImport = false;
            }
        }

        #endregion
    }
}