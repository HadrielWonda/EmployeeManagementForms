using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.Import;

namespace Baumax.Dao
{
    public interface IFeastDao : IDao<Feast>
    {
        IList GetFeastsFiltered(long countryID, DateTime? from, DateTime? to);
		SaveDataResult ImportFeasts(List<ImportDaysData> list);
    }
}