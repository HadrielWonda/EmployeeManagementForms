using System;
using System.Collections.Generic;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Contract.TimePlanning;

namespace Baumax.Services
{
    [ServiceID("8732D076-D742-4fe1-B63D-14E2EFE60DA2")]
    public class AbsenceTimeRecordingService : BaseService<AbsenceTimeRecording>, IAbsenceTimeRecordingService,
        IServerEmployeeTimeRangeService
    {
        private IEmployeeService _employeeService;

        public IEmployeeService EmployeeService
        {
            get { return _employeeService; }
        }

        public  IAbsenceTimeRecordingDao absenceTimeRecordingDao
        {
            get { return (IAbsenceTimeRecordingDao) _dao; }
        }

        #region IAbsenceTimeRecordingService Members

        [AccessType(AccessType.Read)]
        public List<AbsenceTimeRecording> GetAbsenceTimeRecordingsByEmployeeIds(long[] employeeIDs, DateTime beginDate,
                                                                                DateTime endDate)
        {
            return absenceTimeRecordingDao.GetAbsenceTimeRecordingsByEmployeeIds(employeeIDs, beginDate, endDate);
        }
        public List<AbsenceTimeRecording> GetAbsenceTimeRecordingsByEmployeeId(long employeeID, DateTime beginDate,
                                                                                DateTime endDate)
        {
            return absenceTimeRecordingDao.GetAbsenceTimeByEmployeeId(employeeID, beginDate, endDate);
        }
        [AccessType(AccessType.Write)]
        public List<AbsenceTimeRecording> SetAbsenceTimeRecordings(long[] employeeIDs,
                                                                   List<AbsenceTimeRecording> absenceTimeRecordings,
                                                                   DateTime beginDate, DateTime endDate)
        {
            return  absenceTimeRecordingDao.SetAbsenceTimeRecordings(employeeIDs, absenceTimeRecordings, beginDate, endDate);
        }
        [AccessType(AccessType.Write)]
        public void SaveEmployeesWeek(List<EmployeeWeek> lstWeeks)
        {
            absenceTimeRecordingDao.SaveEmployeesWeek(lstWeeks);
        }

        [AccessType(AccessType.Write)]
        public void SaveEmployeeWeek(EmployeeWeek week)
        {
            absenceTimeRecordingDao.SaveEmployeeWeek(week);
        }



        [AccessType(AccessType.Write)]
        public void SaveEmployeeTimeRanges(long[] emplids, List<EmployeeTimeRange> ranges, DateTime aBegin, DateTime aEnd)
        {
            List<EmployeeTimeRange> lstWorkingRanges = new List<EmployeeTimeRange>();
            List<AbsenceTimeRecording> lstTimes = new List<AbsenceTimeRecording>();
            if (ranges != null)
            {
                AbsenceTimeRecording entity = null;
                foreach (EmployeeTimeRange range in ranges)
                {
                    if (range.AbsenceID > 0)
                    {
                        entity = new AbsenceTimeRecording();
                        range.AssignTo(entity);
                        entity.ID = 0;
                        lstTimes.Add(entity);
                    }
                }
            }

            absenceTimeRecordingDao.SetAbsenceTimeRecordings(emplids, lstTimes, aBegin, aEnd);
        }
        #endregion


        public void ClearEmployeeByDateRange(long id, DateTime aBegin, DateTime aEnd)
        {
            List<AbsenceTimeRecording> lst = GetAbsenceTimeRecordingsByEmployeeId(id, aBegin, aEnd);
            if (lst != null && lst.Count > 0)
            {
                DeleteList(lst);
            }
        }
    }
}