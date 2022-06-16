using System;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.Services
{
    [ServiceID("05C6E37B-F1FB-46b0-93C7-7252143B89BB")]
    public class WorkingTimeRecordingService : BaseService<WorkingTimeRecording>, IWorkingTimeRecordingService,
        IServerEmployeeTimeRangeService
    {
        private IEmployeeService _employeeService;

        public IEmployeeService EmployeeService
        {
            get { return _employeeService; }
        }

        private IWorkingTimeRecordingDao workingTimeRecordingDao
        {
            get { return (IWorkingTimeRecordingDao)_dao; }
        }

        #region IWorkingTimeRecordingService Members
        public List<WorkingTimeRecording> GetWorkingTimeByEmployeeId(long employeeID, DateTime beginDate,
                                                                                DateTime endDate)
        {
            return workingTimeRecordingDao.GetWorkingTimeByEmployeeId(employeeID, beginDate, endDate);
        }
        [AccessType(AccessType.Read)]
        public List<WorkingTimeRecording> GetWorkingTimeRecordingsByEmployeeIds(long[] employeeIDs, DateTime beginDate,
                                                                                DateTime endDate)
        {
            return
                GetTypedListFromIList(
                    workingTimeRecordingDao.GetWorkingTimeRecordingsByEmployeeIds(employeeIDs, beginDate, endDate));
        }

        [AccessType(AccessType.Write)]
        public List<WorkingTimeRecording> SetWorkingTimeRecordings(long[] employeeIDs,
                                                                   List<WorkingTimeRecording> workingTimeRecordings,
                                                                   DateTime beginDate, DateTime endDate)
        {
            return
                GetTypedListFromIList(
                    workingTimeRecordingDao.SetWorkingTimeRecordings(employeeIDs, workingTimeRecordings, beginDate,
                                                                     endDate));
        }


        [AccessType(AccessType.Write)]
        public void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks)
        {
            workingTimeRecordingDao.SaveEmployeesWeek(lstWeeks);
        }

        [AccessType(AccessType.Write)]
        public void SaveEmployeeWeek(EmployeeWeek week)
        {
            workingTimeRecordingDao.SaveEmployeeWeek(week);
        }


        [AccessType(AccessType.Write)]
        public void SaveEmployeeTimeRanges(long[] emplids, List<EmployeeTimeRange> ranges,DateTime aBegin,DateTime aEnd)
        {
            List<EmployeeTimeRange> lstWorkingRanges = new List<EmployeeTimeRange>();
            List<WorkingTimeRecording> lstTimes = new List<WorkingTimeRecording>();
            if (ranges != null)
            {
                WorkingTimeRecording entity = null;
                foreach (EmployeeTimeRange range in ranges)
                {
                    if (range.AbsenceID <= 0)
                    {
                        entity = new WorkingTimeRecording();
                        range.AssignTo(entity);
                        entity.ID = 0;
                        lstTimes.Add(entity);
                    }
                }
            }

            workingTimeRecordingDao.SetWorkingTimeRecordings(emplids, lstTimes, aBegin, aEnd);
        }
        [AccessType(AccessType.Write)]
        void RemoveDay(long employeeid, DateTime date)
        {

        }

        #endregion


        public void ClearEmployeeByDateRange(long id, DateTime begin, DateTime end)
        {
            List<WorkingTimeRecording> lst = this.GetWorkingTimeByEmployeeId(id, begin, end);
            if (lst != null && lst.Count > 0)
            {
                DeleteList(lst);
            }

        }
    }
}
