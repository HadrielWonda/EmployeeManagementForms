using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System;
using System.Collections.Generic;
using Baumax.Dao;
using Baumax.Contract;
using System.Diagnostics;

namespace Baumax.Services
{
    [ServiceID("898FDFC8-86A8-464b-8E2C-1D12A463AFC2")]
    public class EmployeeContractService : BaseService<EmployeeContract>, IEmployeeContractService
    {
        public IEmployeeContractDao ContractDao
        {
            get { return (IEmployeeContractDao)_dao; }
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeContract> GetEmployeeContracts(long[] ids, DateTime dateBegin, DateTime dateEnd)
        {
            if (ids == null || (dateBegin > dateEnd)) return null;
            if (ids.Length == 1)
                return ContractDao.GetEmployeeContracts(ids[0], dateBegin, dateEnd);
            else 
                return ContractDao.GetEmployeeContracts(ids, dateBegin, dateEnd);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeContract> GetEmployeeContracts(long emplid, DateTime dateBegin, DateTime dateEnd)
        {
            return ContractDao.GetEmployeeContracts(emplid, dateBegin, dateEnd);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeContract> GetEmployeeContracts(long emplid)
        {
            return ContractDao.GetEmployeeContracts(emplid);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeContract> LoadAllSorted()
        {
            return ContractDao.LoadAllSorted();
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeContract> GetEmployeeContractsByStore(long storeid)
        {
            return ContractDao.GetEmployeeContractsByStore(storeid);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeContract> GetEmployeeContractsByStore(long storeid, DateTime begin, DateTime end)
        {
            return ContractDao.GetEmployeeContractsByStore(storeid, begin, end);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeContract> GetEmployeeContractsByRelationStore(long storeid, DateTime begin, DateTime end)
        {
            return ContractDao.GetEmployeeContractsByRelationStore(storeid, begin, end);
        }
        [AccessType(AccessType.Read)]
        public List<EmployeeContract> GetEmployeeContractsByCountry(long countryid)
        {
            return ContractDao.GetEmployeeContractsByCountry(countryid);
        }

        [Conditional("DEBUG")]
        public void TesterMethods()
        {
            DateTime date1 = new DateTime (2007,12,31);
            DateTime date2 = new DateTime (2008,12,31);

            ContractDao.GetEmployeeContracts(new long[] { 76491, 76733 }, date1, date2);
            ContractDao.GetEmployeeContracts(76491, date1, date2);
            ContractDao.GetEmployeeContracts(76491);
            ContractDao.GetEmployeeContracts(new long[] { 76491, 76733 });
            ContractDao.LoadAllSorted();
            ContractDao.GetEmployeeContractsByStore(1234);
            ContractDao.GetEmployeeContractsByStore(1234, date1, date2);
            ContractDao.GetEmployeeContractsByCountry(1003);
            ContractDao.GetEmployeeContractsByRelationStore(1234, date1, date2);
        }

    }
}
