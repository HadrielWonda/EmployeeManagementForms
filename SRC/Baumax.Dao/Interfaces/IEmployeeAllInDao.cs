using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Dao
{
    public interface IEmployeeAllInDao : IDao<EmployeeAllIn>
    {
        List<EmployeeAllIn> GetEntitiesByEmployee(long emplid, DateTime? aBegin, DateTime? aEnd);
        List<EmployeeAllIn> GetEntitiesByEmployees(long[] emplids, DateTime? aBegin, DateTime? aEnd);
        List<EmployeeAllIn> GetEntitiesByStoreAndRelation(long storeid, DateTime? aBegin, DateTime? aEnd);
        List<EmployeeAllIn> GetEntitiesByCountry(long countryid, DateTime? aBegin, DateTime? aEnd);
        List<EmployeeAllIn> GetEntitiesByStore(long storeid, DateTime? aBegin, DateTime? aEnd);
        List<EmployeeAllIn> GetAllEntitiesSorted();
    }
}
