using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using System.Collections;

namespace Baumax.Contract
{
    public class EmployeeLongTimeAbsenceProcessor
    {
        /* return employee id 
         * which have full long-time absence at it time-range
         */

        public static Dictionary<long, EmployeeLongTimeAbsence> GetEmployeeHasAbsences(
            List<EmployeeLongTimeAbsence> list,
            DateTime aBegin,
            DateTime aEnd)
        {
            Dictionary<long, EmployeeLongTimeAbsence> diction = new Dictionary<long, EmployeeLongTimeAbsence>();

            if (list != null)
            {
                foreach (EmployeeLongTimeAbsence absence in list)
                {
                    if (absence.BeginTime <= aBegin && aEnd <= absence.EndTime)
                    {
                        diction[absence.EmployeeID] = absence;
                    }
                }
            }

            return diction;
        }


        public static Dictionary<long, EmployeeLongTimeAbsence> ToDictionary(List<EmployeeLongTimeAbsence> list)
        {
            Dictionary<long, EmployeeLongTimeAbsence> diction = new Dictionary<long, EmployeeLongTimeAbsence>();
            if (list != null)
            {
                foreach (EmployeeLongTimeAbsence absence in list)
                {
                    diction[absence.ID] = absence;
                }
            }

            return diction;
        }

        public static List<EmployeeLongTimeAbsence> GetEmployeesIntersectTimeRange(
            List<EmployeeLongTimeAbsence> list,
            DateTime aBegin,
            DateTime aEnd)
        {
            List<EmployeeLongTimeAbsence> resultList = new List<EmployeeLongTimeAbsence>();

            if (list != null)
            {
                foreach (EmployeeLongTimeAbsence absence in list)
                {
                    if (!(absence.BeginTime <= aBegin && aEnd <= absence.EndTime))
                    {
                        resultList.Add(absence);
                    }
                }
            }

            return resultList;
        }
    }
}