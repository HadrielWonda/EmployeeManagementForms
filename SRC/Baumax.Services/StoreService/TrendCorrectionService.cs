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
    [ServiceID("0C5825D0-073B-45f2-BC81-D11EC8119409")]
    public class TrendCorrectionService : BaseService<TrendCorrection>, ITrendCorrectionService
    {
        private ITrendCorrectionDao tcDao
        {
            get { return (ITrendCorrectionDao) Dao; }
        }

        #region ITrendCorrectionService Members

        [AccessType(AccessType.Read)]
        public List<TrendCorrection> GetTrendCorrectionFiltered(long storeID, DateTime? dateFrom,
                                                              DateTime? dateTo)
        {
            try
            {
                return GetTypedListFromIList(tcDao.GetTrendCorrectionFiltered(storeID, dateFrom, dateTo));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        #endregion

        protected override bool Validate(TrendCorrection entity)
        {
			// ACPRO 119207
			// Trendcorrections shall NOT accept negativ values. the range should go between +10 and 0
			if (entity.Value <0 || entity.Value > 10)
			{
				return false;
			}
			//
            string s = @" entity.StoreWorldID = :StoreWorldID AND 
                        ( (:from_date BETWEEN entity.BeginTime AND entity.EndTime) OR
                        (:to_date BETWEEN entity.BeginTime AND entity.EndTime) OR 
                        (entity.BeginTime BETWEEN :from_date AND :to_date) OR
                        (entity.EndTime BETWEEN :from_date AND :to_date))";
            IList list =
                tcDao.FindByNamedParam(s,
                    new string[] {"StoreWorldID", "from_date", "to_date"},
                    new object[] {entity.StoreWorldID, entity.BeginTime, entity.EndTime});
            if ((list != null) && (list.Count > 0))
            {
                if(entity.IsNew)
                {
                    return false;
                }
                else
                {
                    foreach(TrendCorrection e in list)
                    {
                        if (e.ID != entity.ID)
                        {
                            return false;
                        }
                    }
                }
            }
            return base.Validate(entity);
        }
    }
}