using Baumax.Domain;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Baumax.Dao
{
    public interface IEmployeeRelationDao : IDao<EmployeeRelation>
    {
        List<EmployeeRelation> GetEmployeeRelations(long emplid);
        List<EmployeeRelation> GetEmployeeRelations(long storeid, DateTime aBegin, DateTime aEnd);
        List<EmployeeRelation> GetEmployeeRelationsByStore(long storeid, DateTime? aBegin, DateTime? aEnd);
        List<EmployeeRelation> GetEmployeeRelationsByStoreAndWorld(long storeid, long worldid, DateTime? aBegin, DateTime? aEnd);
        List<EmployeeRelation> GetEmployeeRelationByMainStore(long storeid, DateTime begin, DateTime end);
        List<EmployeeRelation> GetEmployeeRelationsByEmployeeIds(long[] emplIds, DateTime aBegin, DateTime aEnd);
        List<EmployeeRelation> GetEmployeeRelationsByEmployeeIds(long[] emplIds);
        List<EmployeeRelation> GetEmployeeRelationsByEmployeeId(long emplId, DateTime aBegin, DateTime aEnd);
        List<EmployeeRelation> GetEmployeeRelationByCountryId(long countryid);
        
        List<EmployeeRelation> LoadAllSorted();
    }
}