using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Contract.ZLib;
using Baumax.Dao;
using Baumax.Domain;
using System.Runtime.InteropServices;

namespace Baumax.Services
{
    [ServiceID("ACCE3AFC-9A36-4c11-A447-6FA7E9A3DF69")]
    public class RegionService : BaseService<Region>, IRegionService
    {
        private IRegionDao RegionDao
        {
            get { return (IRegionDao) Dao; }
        }

        #region IRegionService Members

        [AccessType(AccessType.Read)]
        public IList<Region> GetUserRegions(long userId)
        {
            try
            {
                return GetTypedListFromIList(RegionDao.GetUserRegions(userId));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        #endregion
    }
}