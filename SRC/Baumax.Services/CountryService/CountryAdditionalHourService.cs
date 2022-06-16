using System;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;

namespace Baumax.Services
{
    [ServiceID("644B1872-49EC-48f6-8A39-D2F85E62CEF2")]
    public class CountryAdditionalHourService : BaseService<CountryAdditionalHour>, ICountryAdditionalHourService
    {
        
        #region ICountryAdditionalHourService Members

        [AccessType(AccessType.Read)]
        public List<CountryAdditionalHour> GetCountryAdditionalHourFiltered(long CountryID, short? Year)
        {
            try
            {
                return ((ICountryAdditionalHourDao) Dao).GetCountryAdditionalHourFiltered(CountryID, Year);
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }
        
        #endregion
    }
}