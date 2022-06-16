using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IEmployeeAllInService: IBaseService<EmployeeAllIn>
    {
        List<EmployeeAllIn> GetEntitiesByEmployee(long emplid, DateTime? aBegin, DateTime? aEnd);
        List<EmployeeAllIn> GetEntitiesByStore(long storeid, DateTime? aBegin, DateTime? aEnd);
        List<EmployeeAllIn> GetEntitiesByStoreAndRelation(long storeid, DateTime? aBegin, DateTime? aEnd);
        List<EmployeeAllIn> GetEntitiesByCountry(long countryid, DateTime? aBegin, DateTime? aEnd);

        void InsertAllIn(long emplid, DateTime date, bool bAllIn);
    }
}
