using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Contract.QueryResult;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalHWGRService : LocalBaseCachingService<HWGR>, IHWGRService
    {
        private IHWGRService RemoteService
        {
            get { return (IHWGRService)_remoteService; }
        }
        
        #region IHWGRService Members

        public List<HWGR> GetHwgrFiltered(long worldID, DateTime? from, DateTime? to)
        {
            return RemoteService.GetHwgrFiltered(worldID, from, to);
        }

        public SaveDataResult ImportHWGR(List<Baumax.Contract.Import.ImportHWGRData> list)
        {
            return RemoteService.ImportHWGR(list);
        }

        #endregion
    }
}
