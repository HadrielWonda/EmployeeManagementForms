using System.Collections.Generic;
using Baumax.Contract.QueryResult;
using Baumax.Domain;
using Baumax.Contract.Import;

namespace Baumax.Dao
{
    public interface ILongTimeAbsenceDao : IDao<LongTimeAbsence>
    {
        SaveDataResult ImportLongTimeAbsence(List<ImportLongTimeAbsenceData> list);
        List<LongTimeAbsence> FindAllByCountry(long countryid);
    }
}