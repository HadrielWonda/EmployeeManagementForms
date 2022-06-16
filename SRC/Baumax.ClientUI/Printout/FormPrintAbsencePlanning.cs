using System.Windows.Forms;
using Baumax.Printouts.AbsebcePlanning;
using DevExpress.XtraEditors;
using Baumax.Localization;
using System.Collections.Generic;
using Baumax.Contract.Absences;
using Baumax.Domain;
using Baumax.Printouts;
using System;
using Baumax.Environment;

namespace Baumax.ClientUI.Printout
{
	public partial class FormPrintAbsencePlanning : XtraForm
	{
        AbsencePrintArgs m_Args;

        public FormPrintAbsencePlanning()
		{
			InitializeComponent();
            
            if (ClientEnvironment.IsRuntimeMode)
            {
                ControlLocalizer localizer = new ControlLocalizer(UILocalizer.Current, this);
                localizer.ComponentsLocalize(components);
                localizer.LayoutControlLocalize(layoutControl);
                Text = Localizer.GetLocalized("PrintAbsenceTimePlanning");
            }
		}
        public AbsencePrintArgs Arguments
        {
            get { return m_Args; }
            set 
            {
                m_Args = value;
                edStore.Text = value.StoreName;
                rdo_World.Text = value.WorldName;
                rdo_World.Tag = value.WordID;
                ViewStyle = value.View;
                if (value.WordID <= 0)
                {
                    layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    rdo_AllWorlds.Checked = true;
                }
                ChangeViewStyle();
            }
        }
        public AbsencePlanningView ViewStyle
        {
            get 
            {
                if (rdo_Yearly.Checked)
                    return AbsencePlanningView.YearlyView;
                else
                    if (rdo_Monthly.Checked)
                        return AbsencePlanningView.MonthlyView;
                    else
                        return AbsencePlanningView.WeeklyView;
            }
            set 
            {
                if (m_Args.View != value)
                {
                    m_Args.View = value;
                    ChangeViewStyle();
                }
            }
        }

        private void ChangeViewStyle()
        {
            rgMode.Enabled = rdo_Monthly.Checked = m_Args.View == AbsencePlanningView.MonthlyView
                               || m_Args.View == AbsencePlanningView.WeeklyView;
            rdo_Yearly.Checked  = m_Args.View == AbsencePlanningView.YearlyView;
        }

        private void rdoCheckedChanged(object sender, System.EventArgs e)
        {
            ViewStyle = rdo_Yearly.Checked ? AbsencePlanningView.YearlyView
               // : rdo_WeeklyView.Checked ? AbsencePlanningView.Weekly
                                           : AbsencePlanningView.MonthlyView;
        }

        private void rdoWorldChecked(object sender, System.EventArgs e)
        {
            m_Args.WordID = rdo_AllWorlds.Checked ? 0 : (long)rdo_World.Tag;
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            AbsencePlanningPrintout printout = null;
            if ((bool)rgMode.EditValue || rdo_Yearly.Checked)
                printout = new AbsencePlanningPrintout();
            else
                printout = new AbsencePlanningPrintoutA4();
            ChangeViewStyle();
            printout.SetConfigs(m_Args);
            printout.ShowPreviewDialog();
            printout.Dispose();          
        }

        private void ed_OnlyHolidays_CheckedChanged(object sender, EventArgs e)
        {
            //m_Args.OnlyHolidays = ed_OnlyHolidays.Checked;
        }

	}
}