using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Baumax.LocalServices
{
    public class LocalEmployeeRelationService : LocalBaseCachingService<EmployeeRelation>, IEmployeeRelationService
    {

        public List<EmployeeRelation> LoadAllSorted()
        {
            return ((IEmployeeRelationService)_remoteService).LoadAllSorted();
        }
        public List<EmployeeRelation> GetEmployeeRelations(long emplid)
        {
            return ((IEmployeeRelationService)_remoteService).GetEmployeeRelations(emplid);
        }
        public List<EmployeeRelation> GetEmployeeRelations(long emplid, DateTime aBegin, DateTime aEnd)
        {
            return ((IEmployeeRelationService)_remoteService).GetEmployeeRelations(emplid, aBegin, aEnd);
        }
        public List<EmployeeRelation> InsertDeligationToStore(EmployeeRelation entity)
    	{
    		return ((IEmployeeRelationService)_remoteService).InsertDeligationToStore(entity);
    	}

        public List<EmployeeRelation> InsertRelation(EmployeeRelation entity)
        {
            return ((IEmployeeRelationService)_remoteService).InsertRelation(entity);
        }

        public List<EmployeeRelation> GetEmployeeRelationsByStore(long storeid, DateTime? aBegin, DateTime? aEnd)
        {
            return ((IEmployeeRelationService)_remoteService).GetEmployeeRelationsByStore(storeid, aBegin, aEnd);
        }
        public List<EmployeeRelation> GetEmployeeRelationsByStoreAndWorld(long storeid, long worldid, DateTime? aBegin, DateTime? aEnd)
        {
            return ((IEmployeeRelationService)_remoteService).GetEmployeeRelationsByStoreAndWorld(storeid, worldid, aBegin, aEnd);
        }

    }
}
