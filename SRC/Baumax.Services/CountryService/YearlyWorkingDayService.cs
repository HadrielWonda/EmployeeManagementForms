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
    [ServiceID("1D8E192F-67F6-4390-A05D-4FAE7BFAFDC5")]
    public class YearlyWorkingDayService : BaseService<YearlyWorkingDay>, IYearlyWorkingDayService
    {
        #region IYearlyWorkingDayService Members

        [AccessType(AccessType.Read)]
        public List<YearlyWorkingDay> GetYearlyWorkingDaysFiltered(long countryID, DateTime? from, DateTime? to)
        {
            try
            {
                return GetTypedListFromIList(((IYearlyWorkingDayDao)Dao).GetYearlyWorkingDaysFiltered(countryID, from, to));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        #endregion
    }
}