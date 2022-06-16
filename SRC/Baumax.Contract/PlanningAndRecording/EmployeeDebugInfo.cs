using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;

namespace Baumax.Contract.PlanningAndRecording
{
    [Serializable]
    public class EmployeeDebugInfo
    {
        public Employee employee = null;
        public List<EmployeeRelation> _relations = null;
        public List<EmployeeContract> _contracts = null;

        public List<EmployeeAllIn> _allins = null;
        public List<EmployeeLongTimeAbsence> _absences = null;

        public List<EmployeeWeekTimePlanning> _planningweeks = null;
        public List<EmployeeWeekTimeRecording> _recordingweeks = null;
    }
}
