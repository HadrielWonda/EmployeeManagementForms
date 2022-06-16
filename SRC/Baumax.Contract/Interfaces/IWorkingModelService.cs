using System.Collections.Generic;
using Baumax.Domain;
using System;

namespace Baumax.Contract.Interfaces
{
    public interface IWorkingModelService : IBaseService<WorkingModel>
    {
        List<WorkingModel> GetCountryWorkingModel(long countryID, DateTime? aBeginTime, DateTime? aEndTime);
        List<WorkingModel> GetCountryLunchModel(long countryID, DateTime? aBeginTime, DateTime? aEndTime);
    }
}