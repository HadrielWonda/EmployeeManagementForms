using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalEmployeeDayStatePlanningService : LocalBaseCachingService<EmployeeDayStatePlanning>, IEmployeeDayStatePlanningService
    {
        private IEmployeeDayStatePlanningService RemoteService
        {
            get { return (IEmployeeDayStatePlanningService)_remoteService; }
        }
    }
}