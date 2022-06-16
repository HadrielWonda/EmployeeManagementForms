using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Contract.QueryResult;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.LocalServices
{
    public class LocalHwgrToWgrService : LocalBaseCachingService<HwgrToWgr>, IHwgrToWgrService
    {
        public override HwgrToWgr AfterEntityLoaded(HwgrToWgr entity)
        {
            return base.AfterEntityLoaded(FillWgrName(entity));
        }

        private HwgrToWgr FillWgrName(HwgrToWgr entity)
        {
            if (entity != null)
            {
                WGR related = ClientEnvironment.WGRService.FindById(entity.WGR_ID);
                if (related != null)
                {
                    entity.WgrName = related.Name;
                }
            }
            return entity;
        }

        private List<HwgrToWgr> FillWgrName(List<HwgrToWgr> entities)
        {
            if ((entities != null) && (entities.Count > 0))
            {
                foreach (HwgrToWgr entity in entities)
                {
                    FillWgrName(entity);
                }
            }
            return entities;
        }

        #region IHwgrToWgrService Members

        public List<HwgrToWgr> InsertRelation(HwgrToWgr entity)
        {
            return FillWgrName(RemoteService.InsertRelation(entity));
        }

        public List<HwgrToWgr> GetHwgrToWgrFiltered(DateTime dateon)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();

                return FillWgrName(_cache.GetFiltered(delegate(HwgrToWgr entity)
                                          {
                                              return
                                                  ((entity.BeginTime <= dateon) &&
                                                   (entity.EndTime >= dateon));
                                          }
                    ));
            }
            return FillWgrName(RemoteService.GetHwgrToWgrFiltered(dateon));
        }


        public List<HwgrToWgr> GetHwgrToWgrFiltered(long storeID)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();

                return FillWgrName(_cache.GetFiltered(delegate(HwgrToWgr entity)
                                          {
                                              return (entity.StoreID == storeID);
                                          },
                                          delegate(HwgrToWgr x, HwgrToWgr y)
                                          {
                                              // inverse logic
                                              return -DateTime.Compare(x.BeginTime, y.BeginTime);
                                          }
                    ));
            }
            return FillWgrName(RemoteService.GetHwgrToWgrFiltered(storeID));
        }

        public List<HWGR_WGR_SysValues> Get_HWGR_WGR_SysValues()
        {
            return RemoteService.Get_HWGR_WGR_SysValues();
        }

        public SaveDataResult Save_HWGR_WGR_Values(List<HWGR_WGR_SysValuesShort> list)
        {
            return RemoteService.Save_HWGR_WGR_Values(list);
        }

        #endregion

        private IHwgrToWgrService RemoteService
        {
            get { return (IHwgrToWgrService) _remoteService; }
        }
    }
}