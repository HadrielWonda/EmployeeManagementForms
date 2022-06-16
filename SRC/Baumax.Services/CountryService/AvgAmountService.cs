using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;

namespace Baumax.Services
{
    [ServiceID("E40B63B9-6584-45a2-88C0-0B651B502003")]
    public class AvgAmountService : BaseService<AvgAmount>, IAvgAmountService
    {
        #region IAvgAmountService Members

        [AccessType(AccessType.Read)]
        public List<AvgAmount> GetCountryAvgAmounts(long countryID)
        {
            try
            {
                return GetTypedListFromIList(((IAvgAmountDao) Dao).GetCountryAvgAmounts(countryID));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        //2think: whether it should be implemented in C#? this is DB-constraints level logic.
        //!index is already present in DB ([UniqueRec]).
        //TODO: Give more informative name to method
        [AccessType(AccessType.Read)]
        public bool CheckYear(short year, long entityid, long countryid)
        {
            try
            {
                List<string> pNames = new List<string>();
                List<object> pValues = new List<object>();
                StringBuilder sb = new StringBuilder("entity.Year = :year AND entity.CountryID = :countryid");
                pNames.Add("year");
                pValues.Add(year);
                pNames.Add("countryid");
                pValues.Add(countryid);
                if (entityid > 0)
                {
                    sb.Append(" AND entity.ID <> :id");
                    pNames.Add("id");
                    pValues.Add(entityid);
                }
                IList list = FindByNamedParam(sb.ToString(), pNames.ToArray(), pValues.ToArray());
                if ((list != null) && (list.Count > 0))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ValidationException(ex);
            }
        }


        [AccessType(AccessType.Read)]
        public AvgAmount GetAvgAmountByYear(long countryid, int year)
        {
            List<string> pNames = new List<string>();
            List<object> pValues = new List<object>();
            StringBuilder sb = new StringBuilder("entity.Year = :year AND entity.CountryID = :countryid");
            pNames.Add("year");
            pValues.Add(year);
            pNames.Add("countryid");
            pValues.Add(countryid);
            IList list = FindByNamedParam(sb.ToString(), pNames.ToArray(), pValues.ToArray());

            if (list != null && list.Count == 1) return (AvgAmount)list[0];

            return null;
        }

        #endregion
    }
}