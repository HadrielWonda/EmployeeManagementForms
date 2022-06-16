using System.Collections.Generic;
using System.Reflection;
using System;

namespace Baumax.Contract.Absences
{
    public class EmployeeComparer : IComparer<BzEmployeeHoliday>
    {
        protected Dictionary<PropertyInfo, bool> _Info;
        readonly object[] obj = new object[0];

        public EmployeeComparer(Dictionary<PropertyInfo, bool> info)
        {
            _Info = info;
        }

        public int Compare(BzEmployeeHoliday left, BzEmployeeHoliday right)
        {
            foreach (KeyValuePair<PropertyInfo, bool> field in _Info)
            {
                int result = (field.Key.GetValue(left, obj) as IComparable).CompareTo
                             (field.Key.GetValue(right, obj));
                if (result != 0)
                    return result * (field.Value ? 1 : -1);
            }
            return 0;
        }
    }
}
