using Baumax.Domain;
using System.Collections;
using System.Collections.Generic;
using Baumax.Contract.QueryResult;

namespace Baumax.Contract.Interfaces
{
    public interface IEmployeeHolidaysInfoService : IBaseService<EmployeeHolidaysInfo>
    {
        //List<EmployeeHolidaysInfo> GetByEmployeeID(long employeeID);
        //List<EmployeeHolidaysInfo> GetByStoreYear(long storeID, int currentYear);
        //List<EmployeeHolidaysInfo> GetByEmployeesYear(List<long> ids, int year);

        //List<EmployeeDayTimeResult> GetEmployeeCoefficints(long storeid, int year);

        EmployeeHolidaysInfo GetEntity(long emplid, int year);
        List<EmployeeHolidaysInfo> GetEntities(long emplid);
        List<EmployeeHolidaysInfo> GetEntities(long[] emplids, int year);
        List<EmployeeHolidaysInfo> GetEntitiesByStore(long storeid, int year);
        List<EmployeeHolidaysInfo> GetEntitiesByCountry(long countryid, int year);
        List<EmployeeHolidaysInfo> MoveSpareHolidaysToYear(long storeid, int year);
    }
}