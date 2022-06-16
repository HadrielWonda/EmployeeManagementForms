using Baumax.Domain;
using System.Collections.Generic;
using Baumax.Contract.QueryResult;

namespace Baumax.Dao
{
    public interface IEmployeeHolidaysInfoDao : IDao<EmployeeHolidaysInfo>
    {
        void DeleteAllForEmployee(long employeeID);
        EmployeeHolidaysInfo SaveOrUpdateForEmployee(Employee employee, int currentYear);
        List<EmployeeDayTimeResult> GetEmployeeCoefficints(long storeid, int year);
        List<EmployeeHolidaysInfo> RecalculateWithLastYear(int year);
        EmployeeHolidaysInfo GetEntity(long emplid, int Year);
        List<EmployeeHolidaysInfo> GetEntities(long emplid);
        List<EmployeeHolidaysInfo> GetEntities(long[] emplids, int year);
        List<EmployeeHolidaysInfo> GetEntitiesByStore(long storeid, int year);
        List<EmployeeHolidaysInfo> GetEntitiesByCountry(long countryid, int year);

    }
}