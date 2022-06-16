using System;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.EntityStore
{
    public partial class FormExtendOpenCloseHours : XtraForm
	{
		public FormExtendOpenCloseHours()
		{
			InitializeComponent();
		    UCBaseEntity Local = new  UCBaseEntity(this);
		    if (ClientEnvironment.IsRuntimeMode)
		    {
                rdo_ExpandNext.Text = Local.GetLocalized("ExpandNext");
                rdo_ExpandPrevious.Text = Local.GetLocalized("ExpandPrevious");
                rdo_LeaveRangesUnchanged.Text = Local.GetLocalized("LeaveRangesUnchanged");
                lbl_ExpandOpenCloseHours.Text = Local.GetLocalized("ExpandOpenCloseHours");    
		    }
		}
             

		public OpenCloseHoursExtendOption SelectedExtendOption
		{
			get
			{
				if (rdo_ExpandPrevious.Checked)
				{
					return OpenCloseHoursExtendOption.Previous;
				} else if (rdo_ExpandNext.Checked)
				{
					return OpenCloseHoursExtendOption.Next;
				} else if (rdo_LeaveRangesUnchanged.Checked)
				{
					return OpenCloseHoursExtendOption.LeaveUnchanged;
				}
				return OpenCloseHoursExtendOption.Undefined;
			}
		}

		public void SuggestOptions (StoreWorkingTime previousWorkingTime, StoreWorkingTime nextWorkingTime)
		{
			rdo_ExpandPrevious.Enabled = previousWorkingTime != null;
			rdo_ExpandNext.Enabled = nextWorkingTime != null;
			rdo_LeaveRangesUnchanged.Enabled = (previousWorkingTime != null && nextWorkingTime == null);
		    if (!rdo_ExpandPrevious.Enabled && rdo_ExpandPrevious.Checked)
		    {
		        rdo_ExpandPrevious.Checked = false;
		        rdo_ExpandNext.Checked = true; 
		    }
            if (!rdo_ExpandNext.Enabled && rdo_ExpandNext.Checked)
            {
                rdo_ExpandNext.Checked = false;
                if (rdo_LeaveRangesUnchanged.Enabled) 
                    rdo_LeaveRangesUnchanged.Checked = true;
                else
                    if (rdo_ExpandPrevious.Enabled)
                        rdo_ExpandPrevious.Checked = true;
            }
		        
		}
	}

	[Flags]
	public enum OpenCloseHoursExtendOption
	{
		Undefined = 0,
		LeaveUnchanged = 1,
		Previous = 2,
		Next = 4
	}
}