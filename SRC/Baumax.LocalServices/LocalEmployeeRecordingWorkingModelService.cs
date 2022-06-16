using Baumax.Contract.Interfaces;
using Baumax.Domain;

namespace Baumax.LocalServices
{
    public class LocalEmployeeRecordingWorkingModelService : LocalBaseCachingService<EmployeeRecordingWorkingModel>, IEmployeeRecordingWorkingModelService
    {
        private IEmployeeRecordingWorkingModelService RemoteService
        {
            get { return (IEmployeeRecordingWorkingModelService)_remoteService; }
        }

        #region IEmployeeRecordingWorkingModelService Members
        #endregion
    }
}