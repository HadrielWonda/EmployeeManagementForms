using System;
using System.Drawing;
using Baumax.Contract.TimePlanning;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace Baumax.Printouts
{
	internal static class ReportPainter
	{
        static Font dayCellFont = new Font("Arial", 9f, FontStyle.Regular);

		public static void ApplyCaptionCellFormat (XRLabel cell, DateTime time)
		{
            cell.Font = dayCellFont;
            cell.TextAlignment = TextAlignment.MiddleJustify;
			cell.BackColor = Color.Silver;
            cell.BorderWidth = 1;
            //cell.Borders = BorderSide.Bottom | BorderSide.Left   | BorderSide.Top;
			cell.WordWrap = true;
            cell.Multiline = true;
            cell.Text = string.Format("{0:HH:mm}\n{1:HH:mm}", time, time.AddHours(1d));
			cell.Angle = 90;
		}

        public static void AcceptShape(XRLabel shape, XRTableCell cell, Color color)
        {
            shape.BackColor = color;
            shape.Height = cell.Height - 2;
            shape.KeepTogether = true;
        }

		public static void Insert15MinuteShapes(XRControl target, DateTime baseTime, bool manualFill)
		{
			int shapeWidth = (target.Width - 5) / 4;
			int shapeHeight = target.Height - 2;

			for (int idx=0; idx<4; idx++)
			{
				TimeSpan cellTime = baseTime.AddMinutes(idx * 15).TimeOfDay;
				
				XRLabel label = new XRLabel();
				label.Tag = new TimeCellInfo(cellTime, manualFill);
				if (manualFill)
				{
					label.Borders = BorderSide.All;
					label.BorderColor = Color.Black;
				} else
				{
					label.Borders = BorderSide.None;
				}
				target.Controls.Add(label);
				label.Location = new Point((shapeWidth * idx) + idx + 1, 1);
				label.Size = new Size(shapeWidth, shapeHeight);
				label.BackColor = Color.Transparent;
			}
		}

		public static void ApplyStoreDayStyle(XRControl control, StoreDay storeDay)
		{
			if (storeDay == null || storeDay.ClosedDay)
			{
				control.BackColor = Color.LightGray;
			}
			else if (storeDay.Feast)
			{
				control.BackColor = Color.LightGreen;
			}
		}

		public static void ApplyEmployeePlanningDayStyle(XRControl control, StoreDay storeDay, EmployeePlanningDay employeeDay, long worldID)
		{
			control.BackColor = Color.Transparent;

			ApplyStoreDayStyle(control, storeDay);

			if (employeeDay != null)
			{
				if (employeeDay.CountDailyAdditionalCharges > 0)
				{
					control.BackColor = Color.Yellow ;
				}
				else if (employeeDay.WorldId != worldID || employeeDay.HasLongAbsence)
				{
					control.BackColor = Color.Gray;
				}
			}
		}

		public static void ApplyEmployeeDayStyle(XRControl control, StoreDay storeDay, EmployeeDay employeeDay, long worldID, IRecordingContext context)
		{
			control.BackColor = Color.Transparent;

			ApplyStoreDayStyle(control, storeDay);

			if (employeeDay != null)
			{
				if (employeeDay.CountDailyAdditionalCharges > 0)
				{
					control.BackColor = Color.Yellow;
				}
				else if (employeeDay.StoreWorldId != worldID || employeeDay.HasLongAbsence || !employeeDay.HasRelation)
				{
					control.BackColor = Color.Gray;

                    if (employeeDay.HasLongAbsence)
                    {
                        int? color = context.LongAbsences.GetColor(employeeDay.LongAbsenceId);
                        if (color.HasValue)
                            control.BackColor = Color.FromArgb(color.Value);
                        //control.ForeColor = Color.Black;
                    }
				}
			}
		}

		public static XRPanel GetPanelControl(XRControl container)
		{
			XRPanel result = null;

			foreach(XRControl control in container.Controls)
			{
				result= control as XRPanel;
				if(result != null)
				{
                    result.Height = container.Height;
					break;
				}
			}

			return result;
		}

		public static void PrintDayCellValues(XRControl container, EmployeeDay employeeDay, IRecordingContext recordingContext)
		{
			if (employeeDay != null)
			{
				if (employeeDay.HasLongAbsence)
				{
					string s = recordingContext.LongAbsences.GetAbbreviation(employeeDay.LongAbsenceId);
					if (!String.IsNullOrEmpty(s))
					{
						XRLabel label = AddLabelLine(container, s, Color.Black, 0, false);
						label.TextAlignment = TextAlignment.MiddleCenter;
					}
					return;
				}

				if(employeeDay.TimeList != null)
				{
					int y = 0;

					foreach (EmployeeTimeRange range in employeeDay.TimeList)
					{
						XRLabel label = AddLabelLine(container, TextParser.EmployeeTimeToString(range), range.Absence == null ? Color.Black : Color.FromArgb(range.Absence.Color), y, false);
						y = y + label.Height + 1;
					}
				}
			}
		}

		public static XRLabel AddLabelLine (XRControl container, string text, Color color, int yPosition, bool canGrow)
		{
			XRLabel label = new XRLabel();
			container.Controls.Add(label);
			label.Size = new Size(container.Width, 16);
			label.BorderColor = Color.Transparent;
			label.Borders = BorderSide.None;
			label.Location = new Point(0, yPosition);
			label.CanGrow = false;
			label.Dock = XRDockStyle.Top;
			label.Font = container.Font;
			label.Text = text;
			label.ForeColor = color;

			return label;
		}
	}

	internal class TimeCellInfo
	{
		public readonly TimeSpan DayTime;
		public readonly bool ManualFill;

		public TimeCellInfo(TimeSpan dayTime, bool manualFill)
		{
			DayTime = dayTime;
			ManualFill = manualFill;
		}
	}
}