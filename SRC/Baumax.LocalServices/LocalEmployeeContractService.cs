using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System.Collections.Generic;
using System;
using System.Collections;

namespace Baumax.LocalServices
{
    public class LocalEmployeeContractService : LocalBaseCachingService<EmployeeContract>, IEmployeeContractService
    {
        public List<EmployeeContract> GetEmployeeContracts(long[] ids, DateTime dateBegin, DateTime dateEnd)
        {

            return ((IEmployeeContractService)_remoteService).GetEmployeeContracts(ids, dateBegin, dateEnd);
        }
        public List<EmployeeContract> GetEmployeeContracts(long emplid, DateTime dateBegin, DateTime dateEnd)
        {
            return ((IEmployeeContractService)_remoteService).GetEmployeeContracts(emplid, dateBegin, dateEnd);
        }
        public List<EmployeeContract> GetEmployeeContracts(long emplid)
        {
            return ((IEmployeeContractService)_remoteService).GetEmployeeContracts(emplid);
        }

        public List<EmployeeContract> LoadAllSorted()
        {
            return ((IEmployeeContractService)_remoteService).LoadAllSorted();
        }
    }
}