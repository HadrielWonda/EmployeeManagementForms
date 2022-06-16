using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;

namespace Baumax.Dao
{
    public interface IAbsenceDao : IDao<Absence>
    {
        IList GetCountryAbsences(long countryID);
        SaveDataResult ImportAbsence(List<ImportAbsenceData> list);
    }
}