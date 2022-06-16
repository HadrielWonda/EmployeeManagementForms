using System;
using Baumax.Environment;

namespace Baumax.Printouts.ManpowerTimePlanning
{
	internal partial class TimePlanningWeekly : ReportBase
	{
		private WeeklyPlanningPrintController _controller;

		public TimePlanningWeekly()
		{
			InitializeComponent();

			if(ClientEnvironment.IsRuntimeMode)
			{
				fieldCell_FullName.DataBindings.Add("Text", DataSource, "FullName");

				// Localize
				ReportLocalizer.Localize(this);
			}
		}

		public WeeklyPlanningPrintController Controller
		{
			get { return _controller; }
			set
			{
				_controller = value;
				InitColumnsTags(value.StartDate);
				_controller.Assign(this, tbl_DetailsCaption, tbl_WeekPlanningData);
			}
		}

		private void InitColumnsTags(DateTime startDate)
		{
			lbCell_Monday.Tag = fieldCell_Monday.Tag = startDate;
			lbCell_Tuesday.Tag = fieldCell_Tuesday.Tag = startDate.AddDays(1);
			lbCell_Wednesday.Tag = fieldCell_Wednesday.Tag = startDate.AddDays(2);
			lbCell_Thursday.Tag = fieldCell_Thursday.Tag = startDate.AddDays(3);
			lbCell_Friday.Tag = fieldCell_Friday.Tag = startDate.AddDays(4);
			lbCell_Saturday.Tag = fieldCell_Saturday.Tag = startDate.AddDays(5);
			lbCell_Sunday.Tag = fieldCell_Sunday.Tag = startDate.AddDays(6);

			fieldCell_WorkingHours.Tag = PrintoutConst.ContractWorkingHours;
			//fieldCell_AvailableHolidays.Tag = PrintoutConst.AvailableHolidays;
			//fieldCell_PlannedWorking.Tag = PrintoutConst.PlannedWorkingHours;
			fieldCell_SumAdditional.Tag = PrintoutConst.AdditionalWorkingHours;
			fieldCell_PlusMinusHours.Tag = PrintoutConst.PlusMinusHours;
			fieldCell_BalanceHours.Tag = PrintoutConst.BalanceHours;
		}
	}
}