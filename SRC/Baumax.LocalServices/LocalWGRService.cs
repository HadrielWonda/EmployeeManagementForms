using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalWGRService : LocalBaseCachingService<WGR>, IWGRService
    {
        private IWGRService RemoteService
        {
            get { return (IWGRService)_remoteService; }
        }

        #region IWGRService Members

        public List<WGR> GetWgrFiltered(long HWGR_ID, DateTime? from, DateTime? to)
        {
            return RemoteService.GetWgrFiltered(HWGR_ID, from, to);
        }

        #endregion
    }
}
