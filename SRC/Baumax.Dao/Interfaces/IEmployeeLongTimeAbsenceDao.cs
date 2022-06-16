using Baumax.Domain;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Baumax.Dao
{
    public interface IEmployeeLongTimeAbsenceDao : IDao<EmployeeLongTimeAbsence>
    {
        List<EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsence(long storeid, DateTime aBegin, DateTime aEnd);
        Dictionary<long,EmployeeLongTimeAbsence>  GetEmployeesHasLongTimeAbsenceAsDiction(long storeid, DateTime aBegin, DateTime aEnd);
        List<EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsence(long[] emplids, DateTime aBegin, DateTime aEnd);
    }
}