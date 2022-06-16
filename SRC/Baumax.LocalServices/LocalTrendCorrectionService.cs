using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalTrendCorrectionService : LocalBaseCachingService<TrendCorrection>, ITrendCorrectionService
    {
        #region ITrendCorrectionService Members

        public List<TrendCorrection> GetTrendCorrectionFiltered(long storeID, DateTime? dateFrom, DateTime? dateTo)
        {
            return RemoteService.GetTrendCorrectionFiltered(storeID, dateFrom, dateTo);
        }

        #endregion

        private ITrendCorrectionService RemoteService
        {
            get { return (ITrendCorrectionService)_remoteService; }
        }
    }
}
