using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using Baumax.Contract;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Baumax.Contract.Absences;
using System.ComponentModel;
using Baumax.Domain;
using System.Drawing;

namespace Baumax.Printouts.AbsebcePlanning
{
	public partial class AbsenceYearly : ReportBase
	{
        protected YearTableFactory m_Data = null;
        protected Font m_DataFont = new Font("Arial", 7f);
        protected Font m_HeadFont = new Font("Arial", 8f, FontStyle.Bold);
        protected Font m_DataSmall = new Font("Arial", 7f);

        public AbsenceYearly()
		{
			InitializeComponent();
		}

        public AbsenceYearly Bind(YearTableFactory converter)
        {
            m_Data = converter;
            m_Data.BindStaticCells(fieldCellEmployee, fieldCellOldHolidays, fieldCellNewHolidays,
                                   fieldCellAliquotSpareNoPlanned, fieldCellAliquotSpareWithPlanned, fieldCellAvailable, fieldUsed);

            DataSource = m_Data.Table;
            return this;
        }



        protected override void OnBeforePrint(PrintEventArgs e)
        {
            base.OnBeforePrint(e);
            ReportLocalizer.Localize(this);
            tblCaptionMonths.Height = 25;
            int month = 0;
            XRTableCell monthCell = null;
            XRTableCell weekCaptionCell = null;
            XRTableCell weekDataCell = null;

            int weekWidth = CalcWeekWidth();
        
            CalculateWidth(weekWidth);   

			int monthWeeksCount = 1;

            for (int monthNumer = 1; monthNumer < 13 ; monthNumer++ )
                foreach (int weekNumber in m_Data.Wrapper.GetWeekNumbersByMonths(monthNumer))
                {
                    if (month != monthNumer)
                    {
                        if (monthCell == null)
                        {
                            monthCell = lbCell_January;
                        }
                        else
                        {
                            tblCaptionMonths.InsertColumnToRight(monthCell);
                            monthCell.Width = weekWidth * monthWeeksCount;
                            monthCell = monthCell.NextCell;
                            monthCell.Font = m_HeadFont;
                            monthCell.Text = ReportLocalizer.GetMonthName(monthNumer);
                        }

                        monthCell.TextAlignment = TextAlignment.MiddleCenter;
                        month = monthNumer;
                        monthWeeksCount = 1;
                    }
                    else
                    {
                        monthWeeksCount++;
                    }

                    if (weekCaptionCell == null)
                    {
                        weekCaptionCell = lbCell_Week01;
                    }
                    else
                    {
                        tblCaptionWeeks.InsertColumnToRight(weekCaptionCell);
                        weekCaptionCell.Width = weekWidth;
                        weekCaptionCell = weekCaptionCell.NextCell;
                    }
                    weekCaptionCell.TextAlignment = TextAlignment.MiddleCenter;
                    weekCaptionCell.Text = weekNumber.ToString();
                    weekCaptionCell.Font = m_HeadFont;

                    if (weekDataCell == null)
                    {
                        weekDataCell = fieldCellWeek01;
                        weekDataCell.Font = m_DataFont;
                    }
                    else
                    {
                        tblData.InsertColumnToRight(weekDataCell);
                        weekDataCell.Width = weekWidth;
                        weekDataCell.Font = m_DataFont;
                        weekDataCell = weekDataCell.NextCell;
                    }
                    m_Data.BindDynamicCell(weekDataCell, weekNumber);

                    weekDataCell.Name = PrintoutConst.DynName(weekNumber);

                    weekDataCell.BeforePrint += new PrintEventHandler(weekDataCell_BeforePrint);
                }

		}

        protected virtual int CalcWeekWidth()
        {
            return lbCell_Week01.Width / m_Data.Wrapper.CountOfWeek;
        }

        protected virtual void CalculateWidth(int weekWidth)
        {
            lbCell_Employee.Width = lbCellEmployee1.Width = fieldCellEmployee.Width = tblCaptionMonths.Width - 20 * 6 - weekWidth * m_Data.Wrapper.CountOfWeek;
            lbCell_Old.Width = lbCell_OldHolidays1.Width = fieldCellOldHolidays.Width = 20;
            lbCell_New2.Width = lbCell_NewHolidays1.Width = fieldCellNewHolidays.Width = 20;
            lbCell_Avail.Width = lbCellAvail1.Width = fieldCellAvailable.Width = 20;

            lbCell_Week01.Width = fieldCellWeek01.Width = lbCell_January.Width = weekWidth * m_Data.Wrapper.CountOfWeek;

            lbCell_Used.Width = lbCellUsed1.Width = fieldUsed.Width = 20;
            lbCell_Excl.Width = lbCell_AliquotSpareWithPlanned1.Width = fieldCellAliquotSpareNoPlanned.Width = 20;
            lbCell_Incl.Width = lbCell_AliquotSpareWithPlanned1.Width = fieldCellAliquotSpareWithPlanned.Width = 20;
        }

        private void weekDataCell_BeforePrint(object sender, PrintEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (!(cell.Tag == null || cell.Tag.Equals(string.Empty)))
            {
                string text; Color color;
                m_Data.ParseTag(cell.Tag,out text,out color);
                cell.Text = text;//.Replace(',', '/');
                cell.BackColor = color;
            }
        }
	}
}