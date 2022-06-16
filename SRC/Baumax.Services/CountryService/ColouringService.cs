using System;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;

namespace Baumax.Services
{
    [ServiceID("71913269-F37B-49ac-AD2B-C80FB1773815")]
    public class ColouringService : BaseService<Colouring>, IColouringService
    {
        #region IColouringService Members

        [AccessType(AccessType.Read)]
        public List<Colouring> GetCountryColouring(long countryID)
        {
            try
            {
                return GetTypedListFromIList(((IColouringDao) Dao).GetCountryColouring(countryID));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        #endregion
    }
}