using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using Baumax.Contract;
using Baumax.Contract.TimePlanning;
using Baumax.Domain;
using Baumax.Localization;
using DevExpress.XtraReports.UI;

namespace Baumax.Printouts.ManpowerTimePlanning
{
	public class WeeklyPlanningPrintController
	{
		private readonly TimePlanningReportContext _planningContext;
		private XtraReport _report;
		private XRTable _captionTable;
		private XRTable _dataTable;

		private long _currentWorldID;
		private bool _manualFill;
		private bool _manualFillOnly;
		private bool _hideSums;

		public WeeklyPlanningPrintController(TimePlanningReportContext planningContext)
		{
			_planningContext = planningContext;
		}

		public IStoreDaysList StoreDays
		{
			get { return _planningContext.StoreDays; }
		}

		public DateTime StartDate
		{
			get { return _planningContext.StartDate; }
		}

		public DateTime EndDate
		{
			get { return _planningContext.EndDate; }
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

		public long CurrentWorldID
		{
			get { return _currentWorldID; }
			set { _currentWorldID = value; }
		}

		public bool HideSums
		{
			get { return _hideSums; }
			set { _hideSums = value; }
		}

		#region Event Handlers

		private void PrintDataRow(object sender, PrintEventArgs e)
		{
			XRTableRow dataRow = (XRTableRow) sender;
			int height = 25;

			for (int idx=1; idx<8; idx++)
			{
				PrintDataCell(dataRow.Cells[idx]);
			}

			dataRow.Height = height;
		}

		private void PrintManualFillCell(object sender, PrintEventArgs args)
		{
			XRTableCell cell = (XRTableCell)sender;
			ProcessDayCell(cell);

			cell.Text = String.Empty;
		}

		private void PrintSummaryCell(object sender, PrintEventArgs args)
		{
			XRTableCell cell = (XRTableCell)sender;
			EmployeePlanningWeek employeeWeek = GetCurrentRow();
			if(employeeWeek == null)
			{
				return;
			}

			switch((string)cell.Tag)
			{
				case PrintoutConst.ContractWorkingHours:
					cell.Text = DateTimeHelper.IntTimeToStr(employeeWeek.ContractHoursPerWeek);
					break;
				case PrintoutConst.AvailableHolidays:
					cell.Text = DateTimeHelper.DecimalTimeToStr(0);
					break;
				case PrintoutConst.PlannedWorkingHours:
					cell.Text = DateTimeHelper.IntTimeToStr(employeeWeek.CountWeeklyPlanningWorkingHours);
					break;
                case PrintoutConst.AdditionalWorkingHours:
                    {
                        if (employeeWeek.AllIn)
                            cell.Text = "--:--";
                        else 
                            cell.Text = DateTimeHelper.IntTimeToStr(employeeWeek.CountWeeklyAdditionalCharges);
                    }
                    break;
				case PrintoutConst.PlusMinusHours:
					cell.Text = DateTimeHelper.IntTimeToStr(employeeWeek.CountWeeklyPlusMinusHours);
					break;
                case PrintoutConst.BalanceHours:
                    {
                        if (employeeWeek.AllIn)
                            cell.Text = "--:--";
                        else 
                            cell.Text = DateTimeHelper.IntTimeToStr(employeeWeek.Saldo);
                    }
                    break;
			}
		}

		#endregion

		public void Assign(XtraReport report, XRTable captionTable, XRTable dataTable)
		{
			DetachEvents();

			_report = report;

			_captionTable = captionTable;
			SetCaptions();

			_dataTable = dataTable;
			WireUpEvents();
			//
			if(ManualFill && ! ManualFillOnly)
			{
				XRTableRow dataRow = _dataTable.Rows.FirstRow;
				_dataTable.InsertRowBelow(dataRow);
				XRTableRow manualFillRow = _dataTable.Rows[1];
				// set tags for cells 1 - 7 (days of week, first cell is name)
				for(int idx = 0; idx < manualFillRow.Cells.Count; idx++)
				{
					if (idx>0 && idx<=7)
					{
						manualFillRow.Cells[idx].Tag = dataRow.Cells[idx].Tag;
						manualFillRow.Cells[idx].BeforePrint += PrintManualFillCell;
					}
					manualFillRow.Cells[idx].Borders = dataRow.Cells[idx].Borders;
					manualFillRow.Cells[idx].Font = dataRow.Cells[idx].Font;
				}
				if(!HideSums)
				{
					manualFillRow.Cells[8].BackColor = Color.Black;
				}
			}
		}

		private void SetCaptions()
		{
			foreach(XRTableCell cell in _captionTable.Rows.FirstRow.Cells)
			{
				if(cell.Tag is DateTime)
				{
					StoreDay storeDay = _planningContext.StoreDays[(DateTime)cell.Tag];
					cell.Text = String.Format("{0}{3}{2}{3}{1}{3}", Localizer.GetLocalized(storeDay.Date.DayOfWeek.ToString()), DateTimeHelper.ShortTimeRangeToStr(storeDay.OpenTime, storeDay.CloseTime), storeDay.Date.ToShortDateString(), System.Environment.NewLine);
				}
			}
		}

		private void WireUpEvents()
		{
			XRTableRow dataRow = _dataTable.Rows.FirstRow;
			foreach(XRTableCell cell in dataRow.Cells)
			{
				if(cell.Tag != null)
				{
					if(cell.Tag.GetType() == typeof(DateTime))
					{
						if(ManualFillOnly)
						{
							cell.BeforePrint += PrintManualFillCell;
						} 
					} else if(cell.Tag.GetType() == typeof(string))
					{
						cell.BeforePrint += PrintSummaryCell;
					}
				}
			}
			if (!ManualFillOnly)
			{
				dataRow.BeforePrint += PrintDataRow;
			}
		}

		private void DetachEvents()
		{
			if(_dataTable != null)
			{
				XRTableRow dataRow = _dataTable.Rows.FirstRow;
				foreach(XRTableCell cell in dataRow.Cells)
				{
					if(cell.Tag != null)
					{
						if(cell.Tag.GetType() == typeof(DateTime))
						{
							if(ManualFillOnly)
							{
								cell.BeforePrint -= PrintManualFillCell;
							} 
						} else if(cell.Tag.GetType() == typeof(string))
						{
							cell.BeforePrint -= PrintSummaryCell;
						}
					}
				}
				if (!ManualFillOnly)
				{
					dataRow.BeforePrint -= PrintDataRow;
				}
			}
		}

		private void PrintDataCell(XRTableCell cell)
		{
			XRPanel panel = ReportPainter.GetPanelControl(cell);
			panel.Dock = XRDockStyle.Fill;
			panel.Controls.Clear();

			EmployeePlanningDay planningDay = ProcessDayCell(cell);

			if(planningDay.HasLongAbsence)
			{
                

				string s = _planningContext.GetLongTimeAbbreviation(planningDay.LongAbsenceId);
				if(!String.IsNullOrEmpty(s))
				{
                    XRLabel label = ReportPainter.AddLabelLine(panel, s, Color.Black, 0, false);
                    
                    label.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    int? color = _planningContext.GetLongTimeAbsenceColor(planningDay.LongAbsenceId);
                    if (color.HasValue)
                    {
                        label.BackColor = Color.FromArgb(color.Value);
                        cell.BackColor = Color.FromArgb(color.Value);
                    }
                    //cell.Text = s;
                    //cell.ForeColor = Color.White;
                    //cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
				}
				return;
			} else
			{
				cell.ForeColor = Color.Black;
			}

			int y = 0;

			foreach(__TimeRange range in GetDayTimes(planningDay))
			{
				XRLabel label = ReportPainter.AddLabelLine(panel, range.AsTimeString, String.IsNullOrEmpty(range.AbsenceCode) ? Color.Black : range.BeginColor, y, false);
				y = y + label.Height + 1;
			}
		}

		private EmployeePlanningDay ProcessDayCell(XRControl cell)
		{
			EmployeePlanningDay result = null;

			EmployeePlanningWeek employeeWeek = GetCurrentRow();

			StoreDay storeDay = _planningContext.StoreDays[(DateTime)cell.Tag];

			if(employeeWeek != null && storeDay != null && employeeWeek.Days.ContainsKey(storeDay.Date))
			{
				result = employeeWeek.Days[storeDay.Date];
			}

			ReportPainter.ApplyEmployeePlanningDayStyle(cell, storeDay, result, CurrentWorldID);

			return result;
		}

		private static List<__TimeRange> GetDayTimes(EmployeePlanningDay epd)
		{
			List<__TimeRange> result = new List<__TimeRange>();
			if(epd.WorkingTimeList != null)
			{
				foreach(WorkingTimePlanning wtp in epd.WorkingTimeList)
				{
					result.Add(new __TimeRange(wtp.Begin, wtp.End));
				}
			}

			if(epd.AbsenceTimeList != null)
			{
				foreach(AbsenceTimePlanning atp in epd.AbsenceTimeList)
				{
					result.Add(new __TimeRange(atp.Begin, atp.End, atp.Absence.CharID, Color.FromArgb(atp.Absence.Color)));
				}
			}
			result.Sort();

			return result;
		}

		private EmployeePlanningWeek GetCurrentRow()
		{
			return (EmployeePlanningWeek)_report.GetCurrentRow();
		}
	}
}