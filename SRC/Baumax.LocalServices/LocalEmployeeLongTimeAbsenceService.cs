using Baumax.Contract.Interfaces;
using Baumax.Domain;
using System.Collections.Generic;
using System;

namespace Baumax.LocalServices
{
    public class LocalEmployeeLongTimeAbsenceService : LocalBaseCachingService<EmployeeLongTimeAbsence>, IEmployeeLongTimeAbsenceService
    {
        public List<EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsence(long storeid, DateTime aBegin, DateTime aEnd)
        {
            return ((IEmployeeLongTimeAbsenceService)_remoteService).GetEmployeesHasLongTimeAbsence(storeid, aBegin, aEnd);
        }
        public Dictionary<long, EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsenceAsDiction(long storeid, DateTime aBegin, DateTime aEnd)
        {
            return ((IEmployeeLongTimeAbsenceService)_remoteService).GetEmployeesHasLongTimeAbsenceAsDiction(storeid, aBegin, aEnd);
        }
        public List<EmployeeLongTimeAbsence> GetEmployeesHasLongTimeAbsence(long[] emplids, DateTime aBegin, DateTime aEnd)
        {
            return ((IEmployeeLongTimeAbsenceService)_remoteService).GetEmployeesHasLongTimeAbsence(emplids, aBegin, aEnd);
        }
    }
}