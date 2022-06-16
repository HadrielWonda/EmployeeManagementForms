using Baumax.Domain;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Baumax.Dao
{
    public interface IEmployeeContractDao : IDao<EmployeeContract>
    {
        List<EmployeeContract> GetEmployeeContracts(long[] ids, DateTime dateBegin, DateTime dateEnd);
        List<EmployeeContract> GetEmployeeContracts(long emplid, DateTime dateBegin, DateTime dateEnd);
        // get all contracts of employee - sorted asc
        List<EmployeeContract> GetEmployeeContracts(long emplid);
        // get all contracts of employees[] - sorted asc
        List<EmployeeContract> GetEmployeeContracts(long[] emplids);
        List<EmployeeContract> LoadAllSorted();
        // get all contracts employees where MainStoreID=storeid
        // note that load contracts which expire (ContractEnd  < Today)
        List<EmployeeContract> GetEmployeeContractsByStore(long storeid);
        // get all contracts employees where MainStoreID=storeid
        // note that load only valid contracts depend on negin-end date
        List<EmployeeContract> GetEmployeeContractsByStore(long storeid, DateTime begin, DateTime end);
        // load all contracts employees for country
        List<EmployeeContract> GetEmployeeContractsByCountry(long countryid);
        // load all contracts of employee for country which intersect (begin, end)
        List<EmployeeContract> GetEmployeeContractsByCountry(long countryid, DateTime begin, DateTime end);
        // load all contracts employees which have relation to store in date-range
        List<EmployeeContract> GetEmployeeContractsByRelationStore(long storeid, DateTime begin, DateTime end);
    }
}