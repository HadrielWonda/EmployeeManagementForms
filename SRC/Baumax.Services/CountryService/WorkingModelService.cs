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
    [ServiceID("{55E4F21C-6283-4913-82D6-81FB0391979C}")]
    public class WorkingModelService : BaseService<WorkingModel>, IWorkingModelService
    {
        #region IWorkingModelService Members

        [AccessType(AccessType.Read)]
        public List<WorkingModel> GetCountryWorkingModel(long countryID, DateTime? aBeginTime, DateTime? aEndTime)
        {
            try
            {
                if (aBeginTime.HasValue && aEndTime.HasValue)
                    return GetTypedListFromIList(((IWorkingModelDao)Dao).GetCountryWorkingModel(countryID, aBeginTime.Value,aEndTime.Value));
                else 
                    return GetTypedListFromIList(((IWorkingModelDao) Dao).GetCountryWorkingModel(countryID));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        [AccessType(AccessType.Read)]
        public List<WorkingModel> GetCountryLunchModel(long countryID, DateTime? aBeginTime, DateTime? aEndTime)
        {
            try
            {
                if (aBeginTime.HasValue && aEndTime.HasValue)
                    return null;//GetTypedListFromIList(((IWorkingModelDao)Dao).GetCountryLunchModel(countryID, aBeginTime.Value, aEndTime.Value));
                else
                    return GetTypedListFromIList(((IWorkingModelDao)Dao).GetCountryLunchModel(countryID));
            }
            catch (Exception ex)
            {
                throw new LoadException(ex);
            }
        }

        #endregion
    }
}