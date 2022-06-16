using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalWorkingModelService : LocalBaseCachingService<WorkingModel>, IWorkingModelService
    {
        #region IWorkingModelService Members

        public List<WorkingModel> GetCountryWorkingModel(long countryID, DateTime? aBeginTime, DateTime? aEndTime)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
                return _cache.GetFiltered(delegate(WorkingModel entity)
                                          {
                                              if (entity.CountryID != countryID || entity.WorkingModelType != WorkingModelType.WorkingModel)
                                              {
                                                  return false;
                                              }
                                              // shorj: i don't know why this implemended such way in remote service
                                              // but for common approach i implement here the same logic
                                              if ((aBeginTime.HasValue) && (aEndTime.HasValue))
                                              {
                                                  return
                                                      (!
                                                       ((aBeginTime.Value > entity.EndTime) ||
                                                        (aEndTime.Value < entity.BeginTime)));
                                              }
                                              return true;
                                          }
                    );
            }
            else
            {
                return ((IWorkingModelService) _remoteService).GetCountryWorkingModel(countryID, aBeginTime, aEndTime);
            }
        }

        public List<WorkingModel> GetCountryLunchModel(long countryID, DateTime? aBeginTime, DateTime? aEndTime)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
                return _cache.GetFiltered(delegate(WorkingModel entity)
                                          {
                                              if (entity.CountryID != countryID || entity.WorkingModelType != WorkingModelType.LunchModel)
                                              {
                                                  return false;
                                              }
                                              if ((aBeginTime.HasValue) && (aEndTime.HasValue))
                                              {
                                                  return
                                                      (!
                                                       ((aBeginTime.Value > entity.EndTime) ||
                                                        (aEndTime.Value < entity.BeginTime)));
                                              }
                                              return true;
                                          }
                    );
            }
            else
            {
                return ((IWorkingModelService)_remoteService).GetCountryLunchModel(countryID, aBeginTime, aEndTime);
            }
        }

        #endregion
    }
}