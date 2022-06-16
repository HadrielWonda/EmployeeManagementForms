using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Baumax.Printouts
{
    public partial class AbsenceYearlyAustria : Baumax.Printouts.AbsebcePlanning.AbsenceYearly
    {
        public AbsenceYearlyAustria()
        {
            InitializeComponent();
            ReaddRange();
        }

        private void ReaddRange()
        {
            rowData.Cells.Clear();
            rowCaptionWeeks.Cells.Clear();
            rowCaptionMonths.Cells.Clear();

            rowData.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            fieldCellEmployee,
            fieldCellWeek01,
            fieldCellAliquotSpareNoPlanned,
            fieldUsed,
            fieldCellAliquotSpareWithPlanned});


                        rowCaptionWeeks.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            lbCellEmployee1,
            lbCell_Week01,
            lbCell_AliquotSpareNoPlanned1,
                            lbCellUsed1,
            
            lbCell_AliquotSpareWithPlanned1});

                        rowCaptionMonths.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            lbCell_Employee,
            lbCell_January,
            lbCell_Excl,
                            lbCell_Used,
            lbCell_Incl});
        }

        protected override void CalculateWidth(int weekWidth)
        {
            lbCell_Employee.Width = lbCellEmployee1.Width = fieldCellEmployee.Width = tblCaptionMonths.Width - 35 * 3 - weekWidth * m_Data.Wrapper.CountOfWeek;

            lbCell_Week01.Width = fieldCellWeek01.Width = lbCell_January.Width = weekWidth * m_Data.Wrapper.CountOfWeek;

            lbCell_Excl.Width = lbCell_AliquotSpareNoPlanned1.Width = fieldCellAliquotSpareNoPlanned.Width = 35;
            lbCell_Used.Width = lbCellUsed1.Width = fieldUsed.Width = 35;
            //lbCell_Incl.Width = lbCell_AliquotSpareWithPlanned1.Width = fieldCellAliquotSpareWithPlanned.Width = 35;
        }
    }
}

