using System;
using System.Drawing;
using System.Drawing.Printing;
using Baumax.Contract.TimePlanning;
using Baumax.Environment;
using DevExpress.XtraReports.UI;
using Baumax.Contract;
using TimeCellInfo=Baumax.Printouts.TimeCellInfo;

namespace Baumax.Printouts.ManpowerTimePlanning
{
	public partial class TimePlanningDaily : ReportBase
	{
		private DateTime _viewDate;
		private IPlanningContext _planningContext;
		private EmployeeDayViewList _dayViewList;
		private bool _hideSums;
		private bool _manualFill;
		private bool _manualFillOnly;

		public TimePlanningDaily()
		{
			InitializeComponent();

			if (ClientEnvironment.IsRuntimeMode)
			{
				fieldCell_EmployeeName.DataBindings.Add("Text", DataSource, "FullName");

				ReportLocalizer.Localize(this);
			}
		}

		public DateTime ViewDate
		{
			get { return _viewDate; }
			set { _viewDate = value; }
		}

		public bool HideSums
		{
			get { return _hideSums; }
			set { _hideSums = value; }
		}

		public bool ManualFill
		{
			get { return _manualFill; }
			set { _manualFill = value; }
		}

		public bool ManualFillOnly
		{
			get { return _manualFillOnly; }
			set { _manualFillOnly = value; }
		}

		public IPlanningContext PlanningContext
		{
			get { return _planningContext; }
			set { _planningContext = value; }
		}

		public EmployeeDayViewList DayViewList
		{
			get { return _dayViewList; }
			set { _dayViewList = value; }
		}

		protected override void OnBeforePrint(PrintEventArgs e)
		{
			base.OnBeforePrint(e);
			
			// Hide SUM colums if needed
			if (_hideSums)
			{
				//tbl_DailyCaption.DeleteColumn(lbCell_ContractWorkingHours);
				tbl_DailyCaption.DeleteColumn(lbCell_AllreadyPlannedWorkingHours);
				//tbl_DailyCaption.DeleteColumn(lbCell_SummOfAdditionalCharges);
				//tbl_DailyCaption.DeleteColumn(lbCell_PlusMinusHours);
				//tbl_DailyCaption.DeleteColumn(lbCell_EmployeeBalanceHours);

				//tbl_DailyData.DeleteColumn(fieldCell_ContractWorkingHours);
				tbl_DailyData.DeleteColumn(fieldCell_PlannedWorkingHours);
				//tbl_DailyData.DeleteColumn(fieldCell_SumAdditionalHours);
				//tbl_DailyData.DeleteColumn(fieldCell_PlusMinusHours);
				//tbl_DailyData.DeleteColumn(fieldCell_BalanceHours);
			}
			//
			// Generate columnss
			//
			int segmentWidth = Convert.ToInt32(lbCell_0000.Width / 24);
			lbCell_Employee.Width = fieldCell_EmployeeName.Width = lbCell_0000.Right - (segmentWidth * 24);
			TimeSpan dayTime = TimeSpan.Zero;
			TimeSpan timeStep = TimeSpan.FromMinutes(60);

			XRTableCell baseLabelCell = lbCell_0000;
			XRTableCell baseDataCell = fieldCell_0000;

			while (dayTime.TotalHours < 23)
			{
				DateTime columnTime = _viewDate.Add(dayTime);

				// Caption
				ReportPainter.ApplyCaptionCellFormat(baseLabelCell, columnTime);
				tbl_DailyCaption.InsertColumnToRight(baseLabelCell);
				baseLabelCell.Width = segmentWidth;

				baseLabelCell = baseLabelCell.NextCell;

				// Data
				baseDataCell.Tag = columnTime;
				tbl_DailyData.InsertColumnToRight(baseDataCell);
				baseDataCell.BeforePrint += PrintTimeCell;
				baseDataCell.Width = segmentWidth;
				ReportPainter.Insert15MinuteShapes(baseDataCell, columnTime, ManualFillOnly);

				baseDataCell = baseDataCell.NextCell;

				dayTime = dayTime.Add(timeStep);
			}

			DateTime lastColumnTime = _viewDate.Add(dayTime);
			ReportPainter.ApplyCaptionCellFormat(baseLabelCell, lastColumnTime);
			baseDataCell.Tag = lastColumnTime;
			baseDataCell.BeforePrint += PrintTimeCell;
			ReportPainter.Insert15MinuteShapes(baseDataCell, lastColumnTime, ManualFillOnly);
			//
			// If manuall fill, add new row
			if (ManualFill && !ManualFillOnly)
			{
				XRTableRow dataRow = tbl_DailyData.Rows.FirstRow;
				tbl_DailyData.InsertRowBelow(dataRow);
				XRTableRow manualFillRow = tbl_DailyData.Rows[1];
				for (int idx = 1; idx < dataRow.Cells.Count; idx++)
				{
					if (dataRow.Cells[idx].Tag.GetType() == typeof(DateTime))
					{
						DateTime columnTime = (DateTime)dataRow.Cells[idx].Tag;
						manualFillRow.Cells[idx].Tag = columnTime;
						ReportPainter.Insert15MinuteShapes(manualFillRow.Cells[idx], columnTime, true);
						manualFillRow.Cells[idx].BeforePrint += PrintTimeCell;
					}
				}
			}
		}

		private void PrintTimeCell(object sender, PrintEventArgs e)
		{
			XRTableCell cell = (XRTableCell)sender;
			EmployeePlanningWeek employeePlanningWeek = GetCurrentEmployeeWeek();
			EmployeeDayView dayView = DayViewList.GetByEmployeeId(employeePlanningWeek.EmployeeId);

			if(dayView == null)
			{
				return;
			}
			StoreDay storeDay = _planningContext.StoreDays[dayView.ViewDate];

			if (storeDay == null)
			{
				return;
			}
			
			foreach (XRControl child in cell.Controls)
			{
				XRLabel shape = child as XRLabel;
				TimeCellInfo cellInfo = child.Tag as TimeCellInfo;
				if (shape == null || cellInfo == null)
				{
					continue;
				}
				
				short currentTime = Convert.ToInt16(cellInfo.DayTime.TotalMinutes);

				Color color = storeDay.IsOpeningTime(currentTime) ? Color.White : Color.LightGray;
				if (!cellInfo.ManualFill)
				{
					Color workingTimeColor = dayView.GetColor(currentTime / 15);
					if (workingTimeColor != Color.White)
						color = workingTimeColor;
					
				}
                ReportPainter.AcceptShape(shape, cell, color);
			}
		}

		private EmployeePlanningWeek GetCurrentEmployeeWeek() {
			return (EmployeePlanningWeek)GetCurrentRow();
		}

		private void PrintSummaryColumn(object sender, PrintEventArgs e)
		{
			XRTableCell cell = (XRTableCell)sender;
			EmployeePlanningWeek employeePlanningWeek = GetCurrentEmployeeWeek();
			if (employeePlanningWeek == null)
			{
				return;
			}
			EmployeeDayView dayView = DayViewList.GetByEmployeeId(GetCurrentEmployeeWeek().EmployeeId);

			string cellText = String.Empty;

			if(dayView != null)
			{
                //if(cell == fieldCell_ContractWorkingHours)
                //{
                //    cellText = DateTimeHelper.IntTimeToStr(dayView.ContractHoursPerWeek);
                //} else if(cell == fieldCell_PlannedWorkingHours)
                //{
                //    cellText = DateTimeHelper.IntTimeToStr(dayView.TotalWorkingTime);
                //} else if(cell == fieldCell_SumAdditionalHours)
                //{
                //    cellText = DateTimeHelper.IntTimeToStr(dayView.PlanningDay.CountDailyAdditionalCharges);
                //} else if(cell == fieldCell_PlusMinusHours)
                //{
                //    cellText = DateTimeHelper.IntTimeToStr(dayView.PlanningDay.PlanningWeek.CountWeeklyPlusMinusHours);
                //} else if(cell == fieldCell_BalanceHours)
                //{
                //    cellText = DateTimeHelper.IntTimeToStr(dayView.PlanningDay.PlanningWeek.Saldo);
                //}

                if (cell == fieldCell_PlannedWorkingHours)
                {
                    cellText = DateTimeHelper.IntTimeToStr(dayView.PlanningDay.CountDailyPlannedWorkingHours/* TotalWorkingTime*/);
                }
			}

			cell.Text = cellText;
		}
	}
}