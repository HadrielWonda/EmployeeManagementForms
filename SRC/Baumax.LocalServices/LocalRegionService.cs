using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.LocalServices
{
    public sealed class LocalRegionService : LocalBaseCachingService<Region>, IRegionService
    {
        #region IRegionService Members

        public IList<Region> GetUserRegions(long userId)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();

                User usr = ClientEnvironment.UserService.FindById(userId);
                IList<Region> res = _cache.GetFiltered(delegate(Region item)
                                                       {
                                                           foreach (UserRegion ur in usr.UserRegionList)
                                                           {
                                                               if (ur.RegionID == item.ID)
                                                                   return true;
                                                           }
                                                           return false;
                                                       }
                    );

                return res;
            }
            return RemoteService.GetUserRegions(userId);
        }

        #endregion

        private IRegionService RemoteService
        {
            get { return (IRegionService)_remoteService; }
        }
    }
}
