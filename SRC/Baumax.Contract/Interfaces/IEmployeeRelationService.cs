using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
	public interface IEmployeeRelationService : IBaseService<EmployeeRelation>
	{
        List<EmployeeRelation> GetEmployeeRelations(long emplid);

        List<EmployeeRelation> InsertRelation(EmployeeRelation entity);

        List<EmployeeRelation> InsertDeligationToStore(EmployeeRelation entity);

		List<EmployeeRelation> GetEmployeeRelationsByStore(long storeid, DateTime? aBegin, DateTime? aEnd);
        List<EmployeeRelation> GetEmployeeRelationsByStoreAndWorld(long storeid, long worldid, DateTime? aBegin, DateTime? aEnd);
        List<EmployeeRelation> GetEmployeeRelations(long emplid, DateTime aBegin, DateTime aEnd);
        List<EmployeeRelation> LoadAllSorted();
        //List<EmployeeRelation> GetEmployeeRelationsByEmployeeIds(long[] emplIds, DateTime aBegin, DateTime aEnd);
	}
}