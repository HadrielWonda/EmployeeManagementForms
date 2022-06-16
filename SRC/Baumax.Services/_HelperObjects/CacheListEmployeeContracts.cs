using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;
using Baumax.AppServer.Environment;
using Baumax.Contract;

namespace Baumax.Services._HelperObjects
{
    public class CacheListEmployeeContracts : DictionListEmployeesContract
    {
        public EmployeeContractService Service
        {
            get { return ServerEnvironment.EmployeeContractService as EmployeeContractService; }
        }
        public CacheListEmployeeContracts():base()
        {

        }

        public CacheListEmployeeContracts LoadByStore(long storeid)
        {
            BuildDiction(Service.ContractDao.GetEmployeeContractsByStore(storeid));
            return this;
        }
        public CacheListEmployeeContracts LoadByStore(long storeid, DateTime begin, DateTime end)
        {
            BuildDiction(Service.ContractDao.GetEmployeeContractsByRelationStore (storeid, begin,end));
            return this;
        }
        public CacheListEmployeeContracts LoadByCountry(long countryid)
        {
            BuildDiction(Service.ContractDao.GetEmployeeContractsByCountry(countryid));
            return this;
        }
        public CacheListEmployeeContracts LoadByCountry(long countryid, DateTime begin, DateTime end)
        {
            BuildDiction(Service.ContractDao.GetEmployeeContractsByCountry(countryid, begin, end));
            return this;
        }
        public CacheListEmployeeContracts LoadByEmployees(long[] emplids)
        {
            BuildDiction(Service.ContractDao.GetEmployeeContracts(emplids));
            return this;
        }

        public CacheListEmployeeContracts LoadAll()
        {
            BuildDiction (Service.LoadAllSorted());

            return this;
        }

    }
}
