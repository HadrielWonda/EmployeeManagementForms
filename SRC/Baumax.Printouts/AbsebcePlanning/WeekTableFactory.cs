using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Absences;
using System.Data;
using PC = Baumax.Printouts.PrintoutConst;

namespace Baumax.Printouts.AbsebcePlanning
{
    public class WeekTableFactory : DataTableFactory
    {
        int m_Week;

        protected override void BuildDynamicColumns()
        {
            for (int i = 1; i <= 7; i++)
                m_Table.Columns.Add(PC.DynName(i), typeof(string));
        }

        protected override void ApplyDynamicValues(BzEmployeeHoliday entity, DataRow spanRow)
        {
            DateTime start, end;
            Wrapper.GetWeekDateRange(m_Week, out start, out end);

            for (int i = 1; i <= 7; i++, start = start.AddDays(1d))
            {
                DataRow row = m_Table.NewRow();
                List<AbsenceTimeRange> absences = entity.Absences != null 
                                                ? entity.Absences[start] : null;
                if (absences != null && absences.Count > 0)
                    row[PC.DynName(i)] = absences[0].Days;
                m_Table.Rows.Add(row);
            }
        }

        public WeekTableFactory(IList<BzEmployeeHoliday> content, int year, int week) : base(false,false)
        {
            m_Week = week;
            Init(content, year);
        }
    }
}
