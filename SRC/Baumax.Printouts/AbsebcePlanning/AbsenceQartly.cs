using System;
using DevExpress.XtraReports.UI;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;

namespace Baumax.Printouts.AbsebcePlanning
{
    public partial class AbsenceQartly : ReportBase
    {
        protected MonthTableFactory m_Data = null;
        protected Font m_SmallFont = new Font("Arial", 6f, FontStyle.Regular);

        public AbsenceQartly()
        {
            InitializeComponent();
        }
        public AbsenceQartly Bind(MonthTableFactory converter)
        {
            m_Data = converter;
            m_Data.BindStaticCells(gc_Employee, gc_OldHolidays, gc_NewHolidays,
                                   gc_SpareHolidaysExc, gc_SpareHolidaysInc,
                                   gc_AvailableHolidays, gc_UsedHolidays);

            foreach (XRTableCell cell in xrDetailRow.Cells)
            {
                string factor = cell.Name.Replace("gc_", "");
                if (PrintoutConst.Months.Contains(factor))
                {
                    m_Data.BindDynamicCell(cell, PrintoutConst.Months.IndexOf(factor));
                    cell.BeforePrint += new PrintEventHandler(cellBeforePrint);
                }
            }
            DataSource = m_Data.Table;
            return this;
        }

        protected void cellBeforePrint(object sender, PrintEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (!(cell.Tag == null || cell.Tag.Equals(string.Empty)))
            {
                string text; Color color;
                m_Data.ParseTag(cell.Tag, out text, out color);
                cell.Text = text;
                if (text.Length > 12)
                    cell.Font = m_SmallFont;
                cell.BackColor = color;
            }
        }

        protected override void OnBeforePrint(PrintEventArgs e)
        {
            base.OnBeforePrint(e);
            ReportLocalizer.Localize(this);
            ApplyRowStyle(xrRow1);
            ApplyRowStyle(xrDetailRow);
        }

        protected void ApplyRowStyle(XRTableRow row)
        {
            foreach (XRTableCell cell in row.Cells)
                cell.WordWrap = false;
        }

        private void summaryBeforePrint(object sender, PrintEventArgs e)
        {
            
        }

        public void ReaddRange()
        {
            xrDetailRow.Cells.Clear();
            xrRow1.Cells.Clear();

            xrDetailRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            gc_Employee,
            gc_january,
            gc_february,
            gc_march,
            gc_april,
            gc_may,
            gc_june,
            gc_july,
            gc_august,
            gc_september,
            gc_october,
            gc_november,
            gc_december,
            gc_SpareHolidaysExc,
            gc_UsedHolidays,
            gc_SpareHolidaysInc});

            this.xrRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xr_Employee,
            this.xr_january,
            this.xr_february,
            this.xr_march,
            this.xr_april,
            this.xr_may,
            this.xr_june,
            this.xr_july,
            this.xr_august,
            this.xr_september,
            this.xr_october,
            this.xr_november,
            this.xr_december,
            this.xr_Excl,
            this.xr_Used,
            this.xr_Incl});


        }

        protected void RecalculateBlock(XRTableRow row, int[] sizes)
        {
            for (int i = 0; i < sizes.Length; i++)
                row.Cells[i].Size = new Size(sizes[i], 29);
        }

    }
}
