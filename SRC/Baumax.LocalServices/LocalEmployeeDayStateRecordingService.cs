using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalEmployeeDayStateRecordingService : LocalBaseCachingService<EmployeeDayStateRecording>, IEmployeeDayStateRecordingService
    {
        private IEmployeeDayStateRecordingService RemoteService
        {
            get { return (IEmployeeDayStateRecordingService)_remoteService; }
        }
    }
}