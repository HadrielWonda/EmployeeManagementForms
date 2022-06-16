using System.Drawing.Printing;
using Baumax.Contract;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Contract.Absences;
using DevExpress.XtraReports.UI;
using Baumax.Environment;
using Baumax.Localization;
using System.ComponentModel;
using System.Reflection;

namespace Baumax.Printouts.AbsebcePlanning
{
	public partial class AbsencePlanningPrintout : ReportBase
	{
        protected AbsencePrintArgs _Props;
        protected DataTableFactory _DataTable = null;

        public AbsencePlanningPrintout()
		{
			InitializeComponent();
		}


        public void SetConfigs(AbsencePrintArgs properties)
        {
            _Props = properties;
        }

        protected override void OnBeforePrint(PrintEventArgs e)
        {
            base.OnBeforePrint(e);
            ReportLocalizer.Localize(this);
            
            tc_World.Text = Localizer.GetLocalized("world") + " :";
            fieldStore.Text = string.Format("{0}: {1}",Localizer.GetLocalized("Store"), _Props.StoreName);
            fieldWorld.Text = _Props.WorldName;

            if (_Props.WordID <= 0)
                tc_World.Text = fieldWorld.Text = string.Empty;

            tc_TimeRange.Text += string.Format("{0} {1}:\t{2} - {3}",Localizer.GetLocalized("year"), _Props.Year, 
                                                                    _Props.StartDate.ToShortDateString(),
                                                                    _Props.EndDate.ToShortDateString());
            switch (_Props.View)
            {
                case AbsencePlanningView.YearlyView:
                    _DataTable = new YearTableFactory(AdaptToList(), _Props.Year, _Props.OnlyHolidays, _Props.ShowSummary);
                        xrSubreport.ReportSource = (_Props.IsAustria 
                            ? new AbsenceYearlyAustria() as AbsenceYearly 
                            : new AbsenceYearly()).Bind(_DataTable as YearTableFactory);
                    break;

                case AbsencePlanningView.MonthlyView:
                    _DataTable = new MonthTableFactory(AdaptToList(), _Props.Year, _Props.MonthOrWeek, _Props.OnlyHolidays, _Props.ShowSummary);
                    if (PaperKind == PaperKind.A3)
                        if (_Props.IsAustria)
                            xrSubreport.ReportSource = new AbsenceQuartlyAustria().Bind(_DataTable as MonthTableFactory);
                        else
                            xrSubreport.ReportSource = new AbsenceQartly().Bind(_DataTable as MonthTableFactory);
                    else
                        if (_Props.IsAustria)
                            xrSubreport.ReportSource = new AbsenceQuartlyAustriaA4().Bind(_DataTable as MonthTableFactory);
                        else
                            xrSubreport.ReportSource = new AbsenceQuartlyA4().Bind(_DataTable as MonthTableFactory);
                    break;

                case AbsencePlanningView.WeeklyView:
                    _DataTable = new WeekTableFactory(AdaptToList(), _Props.Year, _Props.MonthOrWeek);
                    xrSubreport.ReportSource = new AbsenceWeekly();
                    break;
            }
        }
        
        protected IList<BzEmployeeHoliday> AdaptToList()
        {
            Dictionary<long, BindingList<BzEmployeeHoliday>> dataSource = _Props.DataSource;
            List<BzEmployeeHoliday> result = new List<BzEmployeeHoliday>();

            foreach (KeyValuePair<long, BindingList<BzEmployeeHoliday>> pair in dataSource)
            {
                World wor = ClientEnvironment.WorldService.GetByStoreToWorldID(pair.Key);
                if (wor != null && (_Props.WordID == wor.ID || _Props.WordID <= 0))
                {
                    StoreToWorld world = ClientEnvironment.StoreToWorldService.FindById(pair.Key);
                    string worldName = world != null ? world.WorldName : string.Empty;

                    foreach (BzEmployeeHoliday employee in pair.Value)
                    {
                        employee.WorldName = worldName;
                        result.Add(employee);
                    }
                }
            }
            Dictionary<long, BzEmployeeHoliday> dc = new Dictionary<long, BzEmployeeHoliday>(100);
            foreach (BzEmployeeHoliday bz in result)
            {
                dc[bz.EmployeeId] = bz;
            }
            result.Clear();
            //foreach (BzEmployeeHoliday bz in dc.Values)
                result.AddRange(dc.Values);

            result.Sort(new EmployeeComparer(_Props.SortInfo));
            return result;
        }
	}
}