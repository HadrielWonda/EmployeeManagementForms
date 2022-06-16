using System;
using System.Collections;
using Baumax.Domain;


namespace Baumax.Dao
{
    public interface IWorkingModelDao : IDao<WorkingModel>
    {
        IList GetCountryWorkingModel(long countryID);
        IList GetCountryWorkingModel(long countryID, DateTime aBegin, DateTime aEnd);
        IList GetCountryLunchModel(long countryID);
        IList GetCountryLunchModel(long countryID, DateTime aBegin, DateTime aEnd);

    }
}