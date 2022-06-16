using Baumax.Domain;
using System.Collections.Generic;
using System;

namespace Baumax.Contract.Interfaces
{
    public interface IEmployeeLongTimeAbsenceService : IBaseService<EmployeeLongTimeAbsence>
    {
        List<EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsence(long storeid, DateTime aBegin, DateTime aEnd);
        Dictionary<long, EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsenceAsDiction(long storeid, DateTime aBegin, DateTime aEnd);
        List<EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsence(long[] emplids, DateTime aBegin, DateTime aEnd);
    }
}