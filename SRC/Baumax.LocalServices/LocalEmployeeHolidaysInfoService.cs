using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract.QueryResult;

namespace Baumax.LocalServices
{
    public class LocalEmployeeHolidaysInfoService : LocalBaseCachingService<EmployeeHolidaysInfo>,
                                                    IEmployeeHolidaysInfoService
    {
        private IEmployeeHolidaysInfoService RemoteService
        {
            get { return (IEmployeeHolidaysInfoService) _remoteService; }
        }

        #region IEmployeeHolidaysInfoService Members

        public EmployeeHolidaysInfo GetEntity(long emplid, int year)
        {
            return RemoteService.GetEntity(emplid, year); 
        }
        public List<EmployeeHolidaysInfo> GetEntities(long emplid)
        {
            return RemoteService.GetEntities(emplid);
        }
        public List<EmployeeHolidaysInfo> GetEntities(long[] emplids, int year)
        {
            return RemoteService.GetEntities(emplids, year);
        }
        public List<EmployeeHolidaysInfo> GetEntitiesByStore(long storeid, int year)
        {
            return RemoteService.GetEntitiesByStore (storeid, year);
        }
        public List<EmployeeHolidaysInfo> GetEntitiesByCountry(long countryid, int year)
        {
            return RemoteService.GetEntitiesByCountry(countryid, year);
        }
        public List<EmployeeHolidaysInfo> MoveSpareHolidaysToYear(long storeid, int year)
        {
            return RemoteService.MoveSpareHolidaysToYear(storeid, year);
        }

        //public List<EmployeeHolidaysInfo> GetByEmployeeID(long employeeID)
        //{
        //    return RemoteService.GetByEmployeeID(employeeID);
        //}

        //public List<EmployeeHolidaysInfo> GetByStoreYear(long storeID, int currentYear)
        //{
        //    return RemoteService.GetByStoreYear(storeID, currentYear);
        //}

        //public List<EmployeeHolidaysInfo> GetByEmployeesYear(List<long> ids, int year)
        //{
        //    return RemoteService.GetByEmployeesYear(ids, year);
        //}


        //public List<EmployeeDayTimeResult> GetEmployeeCoefficints(long storeid, int year)
        //{
        //    return RemoteService.GetEmployeeCoefficints(storeid, year);
        //}
        #endregion
    }
}