using System;
using System.Drawing.Printing;
using Baumax.Contract.TimePlanning;
using Baumax.Environment;
using DevExpress.XtraReports.UI;

namespace Baumax.Printouts.TimeRecording
{
	public partial class WorldsTimeRecordingWeekly : ReportBase
	{
		private IRecordingContext _recordingContext;
		private long _storeToWorldID;
		private bool _hideSums;
		private bool _printPlannedValues;

		public WorldsTimeRecordingWeekly()
		{
			InitializeComponent();
			// 
			if (ClientEnvironment.IsRuntimeMode)
			{
				ReportLocalizer.Localize(this);
			}
		}

		public long StoreToWorldID
		{
			get { return _storeToWorldID; }
			set { _storeToWorldID = value; }
		}

		protected override void OnBeforePrint(PrintEventArgs e)
		{
			base.OnBeforePrint(e);
			// Bind
			if(_printPlannedValues)
			{
				fieldCell_FullName.DataBindings.Add("Text", DataSource, "FullName");
			} else
			{
				fieldCell_FullName1.DataBindings.Add("Text", DataSource, "FullName");
			}
			// Bind summaries
			fieldCell_ActualWorkingHours.DataBindings.Add("Text", DataSource, "ContractHoursPerWeek");
			//fieldCell_PlannedWorking.DataBindings.Add("Text", DataSource, "PlannedWorkingHours");
			//fieldCell_ActualPlannedWorking.DataBindings.Add("Text", DataSource, "ActualPlannedWorkingHours");
			fieldCell_SumAdditional.DataBindings.Add("Text", DataSource, "AdditionalHours");
			fieldCell_ActualSumAdditional.DataBindings.Add("Text", DataSource, "ActualAdditionalHours");
			fieldCell_PlusMinusHours.DataBindings.Add("Text", DataSource, "PlusMinusHours");
			fieldCell_ActualPlusMinusHours.DataBindings.Add("Text", DataSource, "ActualPlusMinusHours");
			fieldCell_BalanceHours.DataBindings.Add("Text", DataSource, "Saldo");
			fieldCell_ActualBalanceHours.DataBindings.Add("Text", DataSource, "ActualSaldo");
		}

		public void Init(IRecordingContext recordingContext, DateTime startDate, bool printPlannedValues, bool hideSums)
		{
			_recordingContext = recordingContext;
			_printPlannedValues = printPlannedValues;
			_hideSums = hideSums;

			XRTableRow captionRow = tbl_DetailsCaption.Rows[0];
			XRTableRow firstDataRow = tbl_WeekPlanningData.Rows[0];
			XRTableRow secondDataRow = tbl_WeekPlanningData.Rows[1];

			if (_hideSums)
			{
				while (captionRow.Cells.Count > 8)
				{
					captionRow.Cells.RemoveAt(8);
					firstDataRow.Cells.RemoveAt(8);
					secondDataRow.Cells.RemoveAt(8);
				}

				int tblWidth = tbl_DetailsCaption.Width;
				int cellWidth = Convert.ToInt32(tblWidth / 8.5);

				lbCell_Sunday.Width = fieldCell_Sunday.Width = fieldCell_SundayPlanned.Width = cellWidth;
				lbCell_Friday.Width = fieldCell_Friday.Width = fieldCell_FridayPlanned.Width = lbCell_Saturday.Right - lbCell_Friday.Left - cellWidth;
				lbCell_Thursday.Width = fieldCell_Thursday.Width = fieldCell_ThursdayPlanned.Width = lbCell_Friday.Right - lbCell_Thursday.Left - cellWidth;
				lbCell_Wednesday.Width = fieldCell_Wednesday.Width = fieldCell_WednesdayPlanned.Width = lbCell_Thursday.Right - lbCell_Wednesday.Left - cellWidth;
				lbCell_Tuesday.Width = fieldCell_Tuesday.Width = fieldCell_TuesdayPlanned.Width = lbCell_Wednesday.Right - lbCell_Tuesday.Left - cellWidth;
				lbCell_Monday.Width = fieldCell_Monday.Width = fieldCell_MondayPlanned.Width = lbCell_Tuesday.Right - lbCell_Monday.Left - cellWidth;

				lbCell_Employee.Width = tblWidth - cellWidth * 7;
				fieldCell_FullName.Width = fieldCell_FullName1.Width = lbCell_Employee.Width;
			}

			if (!_printPlannedValues)
			{
				tbl_WeekPlanningData.Rows.RemoveAt(0);
				Detail.Height = tbl_WeekPlanningData.Height;
			}

			lbCell_Monday.Tag = fieldCell_Monday.Tag = fieldCell_MondayPlanned.Tag = startDate;
			lbCell_Tuesday.Tag = fieldCell_Tuesday.Tag = fieldCell_TuesdayPlanned.Tag = startDate.AddDays(1);
			lbCell_Wednesday.Tag = fieldCell_Wednesday.Tag = fieldCell_WednesdayPlanned.Tag = startDate.AddDays(2);
			lbCell_Thursday.Tag = fieldCell_Thursday.Tag = fieldCell_ThursdayPlanned.Tag = startDate.AddDays(3);
			lbCell_Friday.Tag = fieldCell_Friday.Tag = fieldCell_FridayPlanned.Tag = startDate.AddDays(4);
			lbCell_Saturday.Tag = fieldCell_Saturday.Tag = fieldCell_SaturdayPlanned.Tag = startDate.AddDays(5);
			lbCell_Sunday.Tag = fieldCell_Sunday.Tag = fieldCell_SundayPlanned.Tag = startDate.AddDays(6);

            foreach (XRTableCell cell in new XRTableCell[] { lbCell_Monday, lbCell_Tuesday, 
                                                             lbCell_Wednesday, lbCell_Thursday, 
                                                             lbCell_Friday, lbCell_Saturday, lbCell_Sunday })
                cell.Text = string.Format("{0}\n{1}", cell.Text, ((DateTime)cell.Tag).ToShortDateString());
		}

		private EmployeeWeekView GetCurrentWeekView()
		{
			return (EmployeeWeekView)GetCurrentRow();
		}

		private void PrintPlannedDayCell(XRTableCell cell)
		{
			XRPanel panel = ReportPainter.GetPanelControl(cell);
			panel.Width = cell.Width;
			panel.Dock = XRDockStyle.Fill;
			panel.Controls.Clear();

			EmployeeDay employeeDay = null;
			EmployeeWeekView employeeWeek = GetCurrentWeekView();
			StoreDay storeDay = _recordingContext.StoreDays[(DateTime)cell.Tag];

			if (employeeWeek != null && storeDay != null && employeeWeek.PlanningWeek != null)
			{
				employeeDay = employeeWeek.PlanningWeek.GetDay(storeDay.Date);				
			}

            ReportPainter.ApplyEmployeeDayStyle(cell, storeDay, employeeDay, StoreToWorldID, _recordingContext);

			ReportPainter.PrintDayCellValues(panel, employeeDay, _recordingContext);
		}

		private void PrintActualDayCell(XRTableCell cell)
		{
			XRPanel panel = ReportPainter.GetPanelControl(cell);
			panel.Font = cell.Font;
			panel.Width = cell.Width;
			panel.Dock = XRDockStyle.Fill;
			panel.Controls.Clear();

			EmployeeDay employeeDay = null;
			EmployeeWeekView employeeWeek = GetCurrentWeekView();
			StoreDay storeDay = _recordingContext.StoreDays[(DateTime)cell.Tag];

			if (employeeWeek != null && storeDay != null && employeeWeek.ActualWeek != null)
			{
				employeeDay = employeeWeek.ActualWeek.GetDay(storeDay.Date);
			}

            ReportPainter.ApplyEmployeeDayStyle(cell, storeDay, employeeDay, StoreToWorldID, _recordingContext);

			ReportPainter.PrintDayCellValues(panel, employeeDay, _recordingContext);
		}

		private void PrintPlannedRow(object sender, PrintEventArgs e)
		{
			XRTableRow row = (XRTableRow)sender;
			for (int idx=1;idx<8; idx++)
			{
				PrintPlannedDayCell(row.Cells[idx]);
			}
		}

		private void PrintActualRow(object sender, PrintEventArgs e)
		{
			XRTableRow row = (XRTableRow)sender;
			for (int idx=1;idx<8;idx++)
			{
				PrintActualDayCell(row.Cells[idx]);
			}
		}
	}
}