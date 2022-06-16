using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Baumax.Printouts.AbsebcePlanning;
using System.Drawing.Printing;

namespace Baumax.Printouts
{
    public partial class AbsenceQuartlyA4 : AbsenceQartly
    {
        protected Font m_SmallerFont = new Font("Arial", 5f, FontStyle.Regular);

        public AbsenceQuartlyA4()
        {
            InitializeComponent();
        }

        private void holidayBeforePrint(object sender, PrintEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell.Text.Length > 4)
            {
                if (cell.Text.Length > 5)
                    cell.Font = m_SmallerFont;
                cell.Text = cell.Text.Replace(",", "\n,").Replace(".","\n.");
            }
        }

        private void gc_Employee_BeforePrint(object sender, PrintEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell.Text.Length > 15)
                cell.Text = cell.Text.Replace(' ', '\n');
        }
    }
}

