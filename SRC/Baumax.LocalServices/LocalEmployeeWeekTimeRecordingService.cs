using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalEmployeeWeekTimeRecordingService : LocalBaseCachingService<EmployeeWeekTimeRecording>, IEmployeeWeekTimeRecordingService
    {
        private IEmployeeWeekTimeRecordingService RemoteService
        {
            get { return (IEmployeeWeekTimeRecordingService)_remoteService; }
        }
    }
}