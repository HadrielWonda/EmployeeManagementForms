using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;

namespace Baumax.Contract.Interfaces
{
    public interface IFeastService : IBaseService<Feast>
    {
        List<Feast> GetFeastsFiltered(long countryID, DateTime? from, DateTime? to);
		SaveDataResult ImportFeasts(List<ImportDaysData> list);
    }
}