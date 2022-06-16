using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using PC = Baumax.Printouts.PrintoutConst;

using Baumax.Contract;
using Baumax.Contract.Absences;

namespace Baumax.Printouts.AbsebcePlanning
{
    public class YearTableFactory : DataTableFactory
    {
        protected override void BuildDynamicColumns()
        {
            for (int i = 1; i <= Wrapper.CountOfWeek; i++)
                m_Table.Columns.Add(PC.DynName(i), typeof(string));
        }

        protected override void ApplyDynamicValues(BzEmployeeHoliday entity, DataRow row)
        {
            for (int i = 1; i <= Wrapper.CountOfWeek; i++)
                row[PC.DynName(i)] = InfoToString(entity.GetWeek(i));
        }

        public YearTableFactory(IList<BzEmployeeHoliday> content, int year, bool holidaysOnly, bool calcSumm)
            :base(holidaysOnly, calcSumm)
        {
            Init(content, year);
        }
    }
}
