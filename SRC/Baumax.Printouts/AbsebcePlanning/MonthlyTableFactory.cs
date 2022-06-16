using System;
using System.Collections.Generic;
using System.Data;
using Baumax.Contract.Absences;
using PC = Baumax.Printouts.PrintoutConst;
using DevExpress.XtraReports.UI;

namespace Baumax.Printouts.AbsebcePlanning
{
    public class MonthTableFactory : DataTableFactory
    {
        int m_Month;

        protected override void BuildDynamicColumns()
        {
            foreach (string month in PC.Months)
                m_Table.Columns.Add(month, typeof(string));
        }

        public override void BindDynamicCell(XRTableCell cell, int factor)
        {
            cell.DataBindings.Add(new XRBinding(PC.Tag, m_Table, PC.Months[factor]));
        }

        protected override void ApplyDynamicValues(BzEmployeeHoliday entity, DataRow row)
        {
            int i = 1;
            foreach (string month in PC.Months)
                row[month] = InfoToString(entity.GetMonth(i++));
        }

        public MonthTableFactory(IList<BzEmployeeHoliday> content, int year, int month, bool holidaysOnly, bool calcSumm)
            : base(holidaysOnly, calcSumm)
        {
            m_Month = month;
            Init(content, year);
        }
    }
}
