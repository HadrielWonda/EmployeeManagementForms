using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;

namespace Baumax.Contract.WorkingModelConditions
{
    public class ConditionBase
    {
        private ConditionTypes _conditionType = ConditionTypes.Empty;
        private WorkingModelWrapper _owner = null;
        private WorkingModelWrapperNew _ownerNew = null;

        public ConditionBase(ConditionTypes type)
        {
            _conditionType = type;
        }

        public WorkingModelWrapper Wrapper
        {
            get { return _owner; }
            set { _owner = value; }
        }
        public WorkingModelWrapperNew Owner
        {
            get { return _ownerNew; }
            set { _ownerNew = value; }
        }

        public ConditionTypes ConditionType
        {
            get { return _conditionType; }
        }
        public virtual void ParseValue(string value)
        {
        }
        public virtual bool Validate()
        {
            return false;
        }

        public virtual bool ValidateWeek(EmployeePlanningWeek planningWeek, DateTime date)
        {
            return false;
        }

        public virtual bool ValidateNew()
        {
            return false;
        }

        public virtual bool ValidateWeekNew(IBaumaxEmployeeWeek planningWeek, DateTime date)
        {
            return false;
        }
    }

    [Flags]
    public enum EveryItemEnum
    {
        Empty = 0,
        EveryWeek = 1,
        EveryMonth = 2,
        EveryYear = 4
    }
}
