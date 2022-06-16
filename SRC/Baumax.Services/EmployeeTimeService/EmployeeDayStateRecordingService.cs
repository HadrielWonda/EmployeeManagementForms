using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Dao;
using Baumax.Contract.TimePlanning;
using System.Collections.Generic;
using System;

namespace Baumax.Services
{
    [ServiceID("0EDD7D68-A2E3-4f41-8DED-FFFA3D4422D7")]
    public class EmployeeDayStateRecordingService : BaseService<EmployeeDayStateRecording>, 
        IEmployeeDayStateRecordingService,
        IServerEmployeeDayService
    {
        private IEmployeeService _employeeService;
    
        public IEmployeeService EmployeeService
        {
            get { return _employeeService; }
        }
        private IEmployeeDayStateRecordingDao servicedao
        {
            get { return (IEmployeeDayStateRecordingDao)Dao; }
        }

        public int GetWorkingHoursByMonth(long employeeid, DateTime date)
        {
            return servicedao.GetWorkingHoursByMonth(employeeid, date);
        }

        #region IInternalEmployeeDayState

        public void SaveEmployeeDay(EmployeeDay plday)
        {
            servicedao.SaveEmployeeDay(plday);

        }

        public void SaveEmployeeWeeks(List<EmployeeWeek> planningweeks)
        {
            servicedao.SaveEmployeeWeeks(planningweeks);
        }

        public List<EmployeeDay> GetEmployeesStateByIds(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeDayStateRecording> states = servicedao.GetEmployeesStates(emplids, beginDate, endDate);
            if (states != null)
            {
                return EmployeeDayProcessor.ConvertFrom(states);
            }
            return null;
        }
        public List<EmployeeDayStateRecording> GetEmployeesStateEntityByIds(long[] emplids, DateTime beginDate, DateTime endDate)
        {
            return  servicedao.GetEmployeesStates(emplids, beginDate, endDate);
        }

        public List<EmployeeDayStateRecording> GetEmployeeStates(long emplid, DateTime beginDate, DateTime endDate)
        {
            List<EmployeeDayStateRecording> states = servicedao.GetEmployeeStates(emplid, beginDate, endDate);
            
            return states;
        }
        public void FillEmployeeWeeks(List<EmployeeWeek> weeks, DateTime beginDate, DateTime endDate)
        {
            if (weeks != null && weeks.Count > 0)
            {
                Dictionary<long, EmployeeWeek> _diction = EmployeeWeekProcessor.GetDictionary(weeks); 
                long[] ids = EmployeeWeekProcessor.GetEmployeeIds(weeks);

                List<EmployeeDayStateRecording> daystates = servicedao.GetEmployeesStates(ids, beginDate, endDate);

                if (daystates != null)
                {
                    EmployeeWeek lastWeek = null;
                    EmployeeDay day = null;
                    foreach (EmployeeDayStateRecording edsp in daystates)
                    {
                        if ((lastWeek == null) || (edsp.EmployeeID != lastWeek.EmployeeId))
                        {
                            lastWeek = null;
                            _diction.TryGetValue(edsp.EmployeeID, out lastWeek);
                        }

                        if (lastWeek != null)
                        {
                            day = lastWeek.GetDay(edsp.Date);
                            if (day != null)
                            {
                                EmployeeDayProcessor.AssignDay(edsp, day);
                            }

                        }
                    }
                }

            }
        }


        #endregion 
    }
}