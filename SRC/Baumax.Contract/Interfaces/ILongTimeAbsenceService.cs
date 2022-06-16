using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;
namespace Baumax.Contract.Interfaces
{
    public interface ILongTimeAbsenceService : IBaseService<LongTimeAbsence>
    {
        SaveDataResult ImportLongTimeAbsence(List<ImportLongTimeAbsenceData> list);
        List<LongTimeAbsence> FindAllByCountry(long countryid);
        bool IsExistCodeNameOrAbbreviation(long? countryID, string codeName, string charID, long id);
    }
}