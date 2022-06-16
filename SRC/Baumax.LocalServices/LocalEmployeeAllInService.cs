using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.LocalServices
{
    public class LocalEmployeeAllInService: LocalBaseCachingService<EmployeeAllIn>, IEmployeeAllInService
    {
        
        public List<EmployeeAllIn> GetEntitiesByEmployee(long emplid, DateTime? aBegin, DateTime? aEnd)
        {
            return (_remoteService as IEmployeeAllInService).GetEntitiesByEmployee(emplid, aBegin, aEnd);
        }
        public List<EmployeeAllIn> GetEntitiesByStore(long storeid, DateTime? aBegin, DateTime? aEnd)
        {
            throw new NotSupportedException();
        }
        public List<EmployeeAllIn> GetEntitiesByStoreAndRelation(long storeid, DateTime? aBegin, DateTime? aEnd)
        {
            throw new NotSupportedException();
        }
        
        public List<EmployeeAllIn> GetEntitiesByCountry(long countryid, DateTime? aBegin, DateTime? aEnd)
        {
            throw new NotSupportedException();
        }

        public void InsertAllIn(long emplid, DateTime date, bool bAllIn)
        {
            (_remoteService as IEmployeeAllInService).InsertAllIn(emplid,date, bAllIn);
        }
    }
}
