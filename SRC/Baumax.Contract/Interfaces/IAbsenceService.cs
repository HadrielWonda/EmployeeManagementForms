using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.Import;
using Baumax.Contract.QueryResult;

namespace Baumax.Contract.Interfaces
{
    public interface IAbsenceService : IBaseService<Absence>
    {
        List<Absence> GetCountryAbsences(long countryID);
        SaveDataResult ImportAbsence(List<ImportAbsenceData> list);
        bool IsExistAbsenceNameOrAbbreviation(long? countryID, string name, string charID, long id);
    }
}