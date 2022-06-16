using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;

namespace Baumax.Services
{
    [ServiceID("CD575B72-D3A4-4931-824B-A9E5B5618259")]
    public class WGRService : BaseService<WGR>, IWGRService
    {
        #region IWGRService Members

        [AccessType(AccessType.Read)]
        public List<WGR> GetWgrFiltered(long HWGR_ID, DateTime? from, DateTime? to)
        {
            try
            {
                return GetTypedListFromIList(((IWGRDao) Dao).GetWgrFiltered(HWGR_ID, from, to));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        #endregion
    }
}