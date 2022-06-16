using System;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Absences
{
    //public static class AbsenceProcessor
    //{
    //    /// <summary>
    //    /// Correct delete process
    //    /// </summary>
    //    /// <param name="deleted">Some absencess need delete after processing</param>
    //    /// <param name="inserted">Some absencess need insert after processing(!!! ID = 0)</param>
    //    /// <param name="updated">Some absencess need update after processing</param>
    //    public static void DeleteLongTimeAbsences(List<EmployeeLongTimeAbsence> absences, DateTime beginDate, DateTime endDate, 
    //        List<EmployeeLongTimeAbsence> deleted, 
    //        List<EmployeeLongTimeAbsence> inserted,
    //        List<EmployeeLongTimeAbsence> updated)
    //    {
    //        foreach (EmployeeLongTimeAbsence absence in absences)
    //            if (absence.BeginTime >= beginDate && absence.EndTime <= absence.EndTime)
    //                deleted.Add(absence);
    //            else
    //                if (absence.BeginTime < beginDate && absence.EndTime > endDate)
    //                {
    //                    inserted.Add(new EmployeeLongTimeAbsence(endDate.AddDays(1), absence.EndTime, absence.EmployeeID, absence.LongTimeAbsenceID));
    //                    absence.EndTime = beginDate.AddDays(-1);
    //                    updated.Add(absence);
    //                }
    //                else
    //                    if (absence.EndTime > beginDate && absence.EndTime < endDate)
    //                    {
    //                        absence.EndTime = absence.BeginTime.AddDays(-1);
    //                        updated.Add(absence);
    //                    }
    //                    else
    //                        if (absence.BeginTime > beginDate && absence.BeginTime < absence.EndTime)
    //                        {
    //                            absence.BeginTime = absence.EndTime.AddDays(1);
    //                            updated.Add(absence);
    //                        }

    //    }
    //}
}
