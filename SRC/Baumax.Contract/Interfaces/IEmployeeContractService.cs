using Baumax.Domain;
using System;
using System.Collections.Generic;

namespace Baumax.Contract.Interfaces
{
    public interface IEmployeeContractService : IBaseService<EmployeeContract>
    {
        List<EmployeeContract> GetEmployeeContracts(long[] ids,   DateTime dateBegin, DateTime dateEnd);
        List<EmployeeContract> GetEmployeeContracts(long emplid, DateTime dateBegin, DateTime dateEnd);
        List<EmployeeContract> GetEmployeeContracts(long emplid);

        List<EmployeeContract> LoadAllSorted();
    }
}