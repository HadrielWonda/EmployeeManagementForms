using System;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Localization;
using Baumax.Printouts;
using Baumax.Printouts.ManpowerTimePlanning;
using DevExpress.XtraEditors;
using Baumax.ClientUI.FormEntities;

namespace Baumax.ClientUI.Printout
{
	public partial class FormPrintTimePlanning : XtraForm
	{
		private long _countryID;
		private long _storeID;
		private long _worldID;
	    private SortField[] _sortFields;

		public FormPrintTimePlanning()
		{
			InitializeComponent();
            
			if (!UCBaseEntity.IsDesignMode)
			{
				ControlLocalizer localizer = new ControlLocalizer(UILocalizer.Current, this);
				localizer.ComponentsLocalize(components);
				localizer.LayoutControlLocalize(layoutControl);

				ViewTypeChanged(this, EventArgs.Empty);

                de_StartDate.Properties.MinValue = DateTimeSql.SmallDatetimeMin;
                de_StartDate.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			//
			Text = Localizer.GetLocalized("PrintManpowerTimePlanning");
		}

		public long StoreID
		{
			get { return _storeID; }
			set
			{
				_storeID = value;
				lb_StoreName.Text = ClientEnvironment.StoreService.FindById(value).Name;
			}
		}

		public long StoreWorldID
		{
			get { return _worldID; }
			set
			{
				_worldID = value;
				string rdoCaption = Localizer.GetLocalized("World") + ": ";
				StoreToWorld storeToWorld = ClientEnvironment.StoreToWorldService.FindById(value);
				if (storeToWorld != null)
				{
					rdoCaption += storeToWorld.WorldName;
				}
				rdo_World.Text = rdoCaption;
			}
		}

		public long CountryID
		{
			get { return _countryID; }
			set { _countryID = value; }
		}

		public DateTime StartDate
		{
			get
			{
				return de_StartDate.DateTime;
			}
			set
			{
				de_StartDate.DateTime = value;
                de_StartDate.Properties.MinValue = DateTimeHelper.GetMonday (de_StartDate.DateTime);
                de_StartDate.Properties.MaxValue = DateTimeHelper.GetSunday(de_StartDate.DateTime);
			}
		}

	    public SortField[] SortFields
	    {
	        get { return _sortFields; }
	        set { _sortFields = value; }
	    }

	    private ViewType GetViewType()
		{
			return (rdo_WeeklyView.Checked) ? ViewType.Weekly : ViewType.Daily;
		}

		private long? GetWorldID ()
		{
			long? result = null;
			if (rdo_World.Checked)
			{
				result = _worldID;
			}

			return result;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			//
			if (DialogResult == DialogResult.OK)
			{
				using (ManpowerTimePlanningPrintout doc = new ManpowerTimePlanningPrintout())
				{
					doc.BuildWithCriteria(CountryID, StoreID, GetWorldID(), GetViewType(), de_StartDate.DateTime.Date, chk_AddManualFilling.Checked, chk_ManualFillingOnly.Checked, chk_HideReportSums.Checked, _sortFields);
					doc.ShowPreviewDialog();
				}
				e.Cancel = true;
			}
		}

		private void ViewTypeChanged(object sender, EventArgs e)
		{
			if (GetViewType() == ViewType.Weekly)
			{
				de_StartDate.EditValue = DateTimeHelper.GetMonday(de_StartDate.DateTime);
				de_EndDate.EditValue = DateTimeHelper.GetSunday(de_StartDate.DateTime);
				li_StartDate.Text = Localizer.GetLocalized("Week") + ":";
			} else
			{
				de_EndDate.EditValue = de_StartDate.DateTime;
				li_StartDate.Text = Localizer.GetLocalized("Date") + ":";
			}
		}
	}
}