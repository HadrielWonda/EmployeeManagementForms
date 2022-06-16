using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.PlanningAndRecording
{
    [Serializable]
    public class StoreTimeEnvironment
    {
        public byte WarningDays = 0;
        public byte CriticalDays = 0;
        public DateTime? LastRecordingDate;
        public DateTime? LastPlanningDate;
    }
}
