using System;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Localization;
using Baumax.Printouts;
using Baumax.Printouts.TimeRecording;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.Printout
{
	public partial class FormPrintWorldsTimeRecording : XtraForm
	{
		private long _countryID;
		private long _storeID;
		private long _storeToWorldID;
        private SortField[] _sortFields;

		public FormPrintWorldsTimeRecording()
		{
			InitializeComponent();

			if (ClientEnvironment.IsRuntimeMode)
			{
				ControlLocalizer localizer = new ControlLocalizer(UILocalizer.Current, this);
				localizer.ComponentsLocalize(components);
				localizer.LayoutControlLocalize(layoutControl);

				ViewTypeChanged(this, EventArgs.Empty);

                de_StartDate.Properties.MinValue = DateTimeSql.SmallDatetimeMin;
                de_StartDate.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;
			}
		}

		public long CountryID
		{
			get { return _countryID; }
			set { _countryID = value; }
		}

		public long StoreID
		{
			get { return _storeID; }
			set
			{
				_storeID = value;
				Store store = ClientEnvironment.StoreService.FindById(value);
				lb_StoreName.Text = store != null ? store.Name : String.Empty;
			}
		}

		public long StoreToWorldID
		{
			get { return _storeToWorldID; }
			set
			{
				_storeToWorldID = value;
				string rdoCaption = Localizer.GetLocalized("World") + ": ";
				StoreToWorld storeToWorld = ClientEnvironment.StoreToWorldService.FindById(value);
				if (storeToWorld != null)
				{
					rdoCaption += storeToWorld.WorldName;
				}
				rdo_World.Text = rdoCaption;
			}
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
                de_StartDate.Properties.MinValue = DateTimeHelper.GetMonday(de_StartDate.DateTime);
                de_StartDate.Properties.MaxValue = DateTimeHelper.GetSunday(de_StartDate.DateTime);
			}
		}

	    public SortField[] SortFields
	    {
	        get { return _sortFields; }
	        set { _sortFields = value; }
	    }

	    protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			//
			Text = Localizer.GetLocalized("PrintWorldsTimeRecording");

		}

		private ViewType GetViewType()
		{
			return (rdo_WeeklyView.Checked) ? ViewType.Weekly : ViewType.Daily;
		}

		private void ViewTypeChanged(object sender, EventArgs e)
		{
			if (GetViewType() == ViewType.Weekly)
			{
				de_StartDate.EditValue = DateTimeHelper.GetMonday(de_StartDate.DateTime);
				de_EndDate.EditValue = DateTimeHelper.GetSunday(de_StartDate.DateTime);
				li_StartDate.Text = Localizer.GetLocalized("Week") + ":";
			}
			else
			{
				de_EndDate.EditValue = de_StartDate.DateTime;
				li_StartDate.Text = Localizer.GetLocalized("Date") + ":";
			}
		}

		private long? GetStoreToWorldID()
		{
			long? result = null;
			if (rdo_World.Checked)
			{
				result = _storeToWorldID;
			}

			return result;
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			//
			if (DialogResult == DialogResult.OK)
			{
				using (WorldsTimeRecordingPrintout doc = new WorldsTimeRecordingPrintout())
				{
                    doc.BuildWithCriteria(CountryID, StoreID, GetStoreToWorldID(), GetViewType(), de_StartDate.DateTime.Date, chk_PrintPlanningValues.Checked, chk_HideReportSums.Checked, _sortFields);
					doc.ShowPreviewDialog();
				}
				e.Cancel = true;
			}
		}
	}
}