using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Exceptions;

namespace Baumax.Services
{
    [ServiceID("39001C13-55A7-44b9-B03B-788E697713CC")]
    public class HWGRService : BaseService<HWGR>, IHWGRService
    {
        private static bool _IsRunningHwgrImport = false;
        private static Object _SyncIsRunningHwgrImport = new Object();

        private static bool IsRunningHwgrImport
        {
            get { return _IsRunningHwgrImport; }
            set 
            { 
                lock (_SyncIsRunningHwgrImport)
                {
                    if (_IsRunningHwgrImport != value)
                        _IsRunningHwgrImport = value;
                }
            }
        }

        #region IHWGRService Members

        [AccessType(AccessType.Read)]
        public List<HWGR> GetHwgrFiltered(long worldID, DateTime? from, DateTime? to)
        {
            try
            {
                return
                    GetTypedListFromIList(((IHWGRDao) Dao).GetHwgrFiltered(worldID, from, to));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Import)]
        public SaveDataResult ImportHWGR(List<ImportHWGRData> list)
        {
            if (IsRunningHwgrImport)
                throw new AnotherImportRunning();
            IsRunningHwgrImport = true;
            try
            {
                return ((IHWGRDao)Dao).ImportHWGR(list);
            }
            catch (Exception ex)
            {
                throw new SaveException(ex);
            }
            finally
            {
                IsRunningHwgrImport = false;
            }
        }
        #endregion
    }
}