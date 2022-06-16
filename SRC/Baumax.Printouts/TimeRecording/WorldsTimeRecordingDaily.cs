using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using Baumax.Contract.TimePlanning;
using Baumax.Environment;
using DevExpress.XtraReports.UI;
using TimeCellInfo=Baumax.Printouts.TimeCellInfo;

namespace Baumax.Printouts.TimeRecording
{
	public partial class WorldsTimeRecordingDaily : ReportBase
	{
		private WorldsTimeRecordingPrintoutContext _recordingContext;
		private bool _printPlannedValues;
		private bool _hideSums;
		private RecordingDayView _plannedDayView;
		private RecordingDayView _actualDayView;

		public WorldsTimeRecordingDaily()
		{
			InitializeComponent();
			// 
			if (ClientEnvironment.IsRuntimeMode)
			{
				ReportLocalizer.Localize(this);
			}
		}

		public void Init(WorldsTimeRecordingPrintoutContext recordingContext, DateTime viewDate, bool printPlannedValues, bool hideSums)
		{
			_recordingContext = recordingContext;
			_printPlannedValues = printPlannedValues;
			_hideSums = hideSums;

			// Hide SUM colums if needed
			if(_hideSums)
			{
				//tbl_DailyCaption.DeleteColumn(lbCell_ContractWorkingHours);
				tbl_DailyCaption.DeleteColumn(lbCell_AllreadyPlannedWorkingHours);
				//tbl_DailyCaption.DeleteColumn(lbCell_SummOfAdditionalCharges);
				//tbl_DailyCaption.DeleteColumn(lbCell_PlusMinusHours);
				//tbl_DailyCaption.DeleteColumn(lbCell_EmployeeBalanceHours);

				//tbl_DailyData.DeleteColumn(fieldCell_ContractWorkingHoursPlanned);
				tbl_DailyData.DeleteColumn(fieldCell_PlannedWorkingHoursPlanned);
				//tbl_DailyData.DeleteColumn(fieldCell_SumAdditionalHoursPlanned);
				//tbl_DailyData.DeleteColumn(fieldCell_PlusMinusHoursPlanned);
				//tbl_DailyData.DeleteColumn(fieldCell_BalanceHoursPlanned);

				//tbl_DailyData.DeleteColumn(fieldCell_ContractWorkingHours);
				tbl_DailyData.DeleteColumn(fieldCell_PlannedHours);
				//tbl_DailyData.DeleteColumn(fieldCell_PlusMinusHours);
				//tbl_DailyData.DeleteColumn(fieldCell_PlusMinusHours);
				//tbl_DailyData.DeleteColumn(fieldCell_BalanceHours);
			}

			//
			// Generate columnss
			//
			int segmentWidth = Convert.ToInt32(lbCell_0000.Width / 24);
			lbCell_Employee.Width = fieldCell_EmployeeName.Width = fieldCell_Employee1.Width = lbCell_0000.Right - (segmentWidth * 24);
			TimeSpan dayTime = TimeSpan.Zero;
			TimeSpan timeStep = TimeSpan.FromMinutes(60);

			XRTableCell baseLabelCell = lbCell_0000;
			XRTableCell basePlannedCell = fieldCell_0000Planned;
			XRTableCell baseDataCell = fieldCell_0000;

			while(dayTime.TotalHours < 23)
			{
				DateTime columnTime = viewDate.Add(dayTime);

				// Caption
				ReportPainter.ApplyCaptionCellFormat(baseLabelCell, columnTime);
				tbl_DailyCaption.InsertColumnToRight(baseLabelCell);
				baseLabelCell.Width = segmentWidth;

				baseLabelCell = baseLabelCell.NextCell;

				// Planned values
				tbl_DailyData.InsertColumnToRight(basePlannedCell);

				basePlannedCell.Tag = columnTime;
				basePlannedCell.BeforePrint += PrintPlannedCell;
                //basePlannedCell.SizeChanged += CellSizeChanged;
				basePlannedCell.Width = segmentWidth;
				ReportPainter.Insert15MinuteShapes(basePlannedCell, columnTime, false);

				basePlannedCell = basePlannedCell.NextCell;

				// Data
				baseDataCell.Tag = columnTime;
				baseDataCell.BeforePrint += PrintTimeCell;
				baseDataCell.Width = segmentWidth;
                //baseDataCell.SizeChanged += CellSizeChanged;
				ReportPainter.Insert15MinuteShapes(baseDataCell, columnTime, false);

				baseDataCell = baseDataCell.NextCell;

				dayTime = dayTime.Add(timeStep);
			}

			DateTime lastColumnTime = viewDate.Add(dayTime);
			ReportPainter.ApplyCaptionCellFormat(baseLabelCell, lastColumnTime);

			basePlannedCell.Tag = baseDataCell.Tag = lastColumnTime;
			basePlannedCell.BeforePrint += PrintPlannedCell;
			baseDataCell.BeforePrint += PrintTimeCell;
			ReportPainter.Insert15MinuteShapes(basePlannedCell, lastColumnTime, false);
			ReportPainter.Insert15MinuteShapes(baseDataCell, lastColumnTime, false);

			if(!_printPlannedValues)
			{
				tbl_DailyData.Rows.RemoveAt(0);
				Detail.Height = tbl_DailyData.Height;
			}
		}

		protected override void OnBeforePrint(PrintEventArgs e)
		{
			base.OnBeforePrint(e);
			//
			if (!_printPlannedValues)
			{
				fieldCell_Employee1.DataBindings.Add("Text", DataSource, "FullName");
			}
			else
			{
				fieldCell_EmployeeName.DataBindings.Add("Text", DataSource, "FullName");
			}

			//fieldCell_ContractWorkingHours.DataBindings.Add("Text", DataSource, "ContractHoursPerWeek");
		}

		private void PrintPlannedCell(object sender, PrintEventArgs e)
		{
			XRTableCell cell = (XRTableCell)sender;

			if (_plannedDayView == null)
			{
				return;
			}
			StoreDay storeDay = _recordingContext.StoreDays[_recordingContext.ViewDate];

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
					Color workingTimeColor = _plannedDayView.GetColorByTime(currentTime);
					if (workingTimeColor != Color.White)
					{
						color = workingTimeColor;
					}
				}

                ReportPainter.AcceptShape(shape, cell, color);
			}
		}

		private void PrintTimeCell(object sender, PrintEventArgs e)
		{
			XRTableCell cell = (XRTableCell)sender;
			
			if(_actualDayView == null)
			{
				return;
			}
			StoreDay storeDay = _recordingContext.StoreDays[_recordingContext.ViewDate];

			if(storeDay == null)
			{
				return;
			}

			foreach(XRControl child in cell.Controls)
			{
				XRLabel shape = child as XRLabel;
				TimeCellInfo cellInfo = child.Tag as TimeCellInfo;
				if(shape == null || cellInfo == null)
				{
					continue;
				}

				short currentTime = Convert.ToInt16(cellInfo.DayTime.TotalMinutes);

				Color color = storeDay.IsOpeningTime(currentTime) ? Color.White : Color.LightGray;
				if(!cellInfo.ManualFill)
				{
					Color workingTimeColor = _actualDayView.GetColorByTime(currentTime);
					if(workingTimeColor != Color.White)
					    color = workingTimeColor;
				}
                ReportPainter.AcceptShape(shape,cell, color);
			}
		}

		private EmployeeWeek GetCurrentEmployee() {
			return (EmployeeWeek)GetCurrentRow();
		}

		private void BeforePrintRecordingTable(object sender, PrintEventArgs e)
		{
			_plannedDayView = _actualDayView = null;

			if (DataSource != null && ((IList)DataSource).Count > 0)
			{
				EmployeeWeek ew = GetCurrentEmployee();

				_plannedDayView = new RecordingDayView();
				_plannedDayView.RecordingDay = ew.GetDay(_recordingContext.ViewDate);

				_actualDayView = new RecordingDayView();
                EmployeeWeek emplWeek = _recordingContext.WorldActualState[ew.EmployeeId];
                if (emplWeek != null)
				    _actualDayView.RecordingDay = emplWeek.GetDay(_recordingContext.ViewDate);
			}
		}

		private void PrintContractWorkingHours(object sender, PrintEventArgs e)
		{
            //if (_plannedDayView != null)
            //{
            //    EmployeeWeek employeeWeek = _recordingContext.WorldPlanningState[GetCurrentEmployee().EmployeeId];
            //    if(employeeWeek != null)
            //    {
            //        fieldCell_ContractWorkingHours.Text = TextParser.TimeToString(employeeWeek.ContractHoursPerWeek);
            //        return;
            //    }
            //} 
            //fieldCell_ContractWorkingHours.Text = "00:00";
		}

		private void PrintPlannedHours(object sender, PrintEventArgs e)
		{
			if (_plannedDayView != null)
			{
				fieldCell_PlannedWorkingHoursPlanned.Text = TextParser.TimeToString(_plannedDayView.RecordingDay.CountDailyPlannedWorkingHours);
			} else
			{
				fieldCell_PlannedWorkingHoursPlanned.Text = "00:00";
			}
		}

		private void PrintActualHours(object sender, PrintEventArgs e)
		{
			if (_actualDayView != null)
			{
				fieldCell_PlannedHours.Text = TextParser.TimeToString(_actualDayView.RecordingDay.CountDailyPlannedWorkingHours);
			} else
			{
				fieldCell_PlannedHours.Text = "00:00";
			}
		}

		private void PrintPlannedAdditionalHours(object sender, PrintEventArgs e)
		{
            //if (_plannedDayView != null)
            //{
            //    fieldCell_SumAdditionalHoursPlanned.Text = TextParser.TimeToString(_plannedDayView.RecordingDay.CountDailyAdditionalCharges);
            //} else
            //{
            //    fieldCell_SumAdditionalHoursPlanned.Text = "00:00";
            //}
		}

		private void PrintActualAdditionalHours(object sender, PrintEventArgs e)
		{
            //if (_actualDayView != null)
            //{
            //    fieldCell_SumAdditionalCharges.Text = TextParser.TimeToString(_actualDayView.RecordingDay.CountDailyAdditionalCharges);
            //} else
            //{
            //    fieldCell_SumAdditionalCharges.Text = "00:00";
            //}
		}

		private void PrintPlannedPlusMinusHours(object sender, PrintEventArgs e)
		{
            //if (_plannedDayView != null)
            //{
            //    EmployeeWeek employeeWeek = _recordingContext.WorldPlanningState[GetCurrentEmployee().EmployeeId];
            //    if(employeeWeek != null)
            //    {
            //        fieldCell_PlusMinusHoursPlanned.Text = TextParser.TimeToString(employeeWeek.CountWeeklyPlusMinusHours);
            //        return;
            //    }
            //}

            //fieldCell_PlusMinusHoursPlanned.Text = "00:00";
		}

		private void PrintActualPlusMinusHours(object sender, PrintEventArgs e)
		{
            //if (_actualDayView != null)
            //{
            //    EmployeeWeek employeeWeek = _recordingContext.WorldActualState[GetCurrentEmployee().EmployeeId];
            //    if(employeeWeek != null)
            //    {
            //        fieldCell_PlusMinusHours.Text = TextParser.TimeToString(employeeWeek.CountWeeklyPlusMinusHours);
            //        return;
            //    }
            //}
            //fieldCell_PlusMinusHours.Text = "00:00";
		}

		private void PrintPlannedBalanceHours(object sender, PrintEventArgs e)
		{
            //if (_plannedDayView != null)
            //{
            //    EmployeeWeek employeeWeek = _recordingContext.WorldPlanningState[GetCurrentEmployee().EmployeeId];
            //    if(employeeWeek != null)
            //    {
            //        fieldCell_BalanceHoursPlanned.Text = TextParser.TimeToString(employeeWeek.Saldo);
            //        return;
            //    }
            //}
			
            //fieldCell_BalanceHoursPlanned.Text = "00:00";
		}

		private void PrintActualBalanceHours(object sender, PrintEventArgs e)
		{
            //if (_actualDayView != null)
            //{
            //    EmployeeWeek employeeWeek = _recordingContext.WorldActualState[GetCurrentEmployee().EmployeeId];
            //    if(employeeWeek != null)
            //    {
            //        fieldCell_BalanceHours.Text = TextParser.TimeToString(employeeWeek.Saldo);
            //        return;
            //    }
            //}
            //fieldCell_BalanceHours.Text = "00:00";
		}

        private void CellSizeChanged(object sender, ChangeEventArgs e)
        {
            XRTableCell cell = sender as XRTableCell;
            if (cell != null)
                foreach (XRControl control in cell.Controls)
                    control.Height = cell.Height;
        }
	}
}