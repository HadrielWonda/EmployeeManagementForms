using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    public partial class FormSelectAbsence : FormBaseEntity 
    {
        private List<Absence> _absences = null;
        private Absence _absence = null;
        private string absenceTranslation = "Absence";
        private string holidayTranslation = "Holiday";
        private string illnessTranslation = "Illness";

        private short OpenTime = 8 * 60;
        private short CloseTime = 18 * 60;
        private double AvgWorkingDays = 5F;
        private bool ignorechanged = false;

        private bool _planning = false;

        public bool IsPlanning
        {
            get { return _planning; }
            set { _planning = value; }
        }

        public short BeginTime
        {
            get { return DateTimeHelper.DateTimeToShort (teBegin.Time); }
            set { teBegin.Time = DateTimeHelper.ShortToDateTime (value); }
        }

	    public short EndTime
	    {
            get { return DateTimeHelper.DateTimeToShort (teEnd.Time); }
            set { teEnd.Time = DateTimeHelper.ShortToDateTime (value); }
	    }

	    public DateTime EndDate
	    {
		    get { return edEndDate.DateTime;}
		    set { edEndDate.DateTime = value;}
	    }
	
        public DateTime BeginDate
        {
            get { return edBeginDate.DateTime; }
            set { edBeginDate.DateTime = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateButtonEnable();
        }

        public FormSelectAbsence()
        {
            InitializeComponent();
            ignorechanged = true;
            BeginTime = OpenTime;
            EndTime = CloseTime;
            ignorechanged = false;
        }
        
        private void UpdateButtonEnable()
        {
            if (FocusedEntity != null)
                btn_Select.Enabled = true;
            else
                btn_Select.Enabled = false;
        }

        public void SetMinMaxByYearAndToday(int year)
        {
            int today_year = DateTimeHelper.GetYearByDate(DateTime.Today);

            if (today_year == year)
            {
                SetDateRange (DateTime.Today, DateTimeHelper.GetEndYearDate (today_year));
            }
            else
            {
                SetDateRange (DateTimeHelper.GetBeginYearDate (year), DateTimeHelper.GetEndYearDate (year));
            }
        }
        public bool Execute()
        {
            return ShowDialog() == DialogResult.OK;
        }


        public override void AssignLanguage()
        {
            base.AssignLanguage();

            if (ClientEnvironment.IsRuntimeMode)
            {
                absenceTranslation = GetLocalized("Absence");
                holidayTranslation = GetLocalized("Holiday");
                illnessTranslation = GetLocalized("Illness");
            }

        }

        public void SetDayInfo(short opentime, short closetime, double avgworkingdays)
        {
            OpenTime = opentime;
            CloseTime = closetime;
            AvgWorkingDays = avgworkingdays;
            ignorechanged = true;
            BeginTime = OpenTime;
            EndTime = CloseTime;
            ignorechanged = false;


            //lbl_AverageWorkingDayInWeek.Text = lbl_AverageWorkingDayInWeek.Text + ": " + AvgWorkingDays.ToString("0.0");
            lbAWGWeek.Text = AvgWorkingDays.ToString("0.0");
        }

        public Absence SelectedAbsence
        {
            get { return _absence; }
            set { _absence = value; }
        }

        public bool ShowTimePanel
        {
            get { return panelControlTime.Visible;}
            set { panelControlTime.Visible = value;}
        }

        public bool ShowDatePanel 
        {
            get { return panelDate.Visible; }
            set 
            { 
                panelDate.Visible = value;
                edIgnore.Text = ucSelectIgnore1.ToString();
            }
        }

        public List<Absence> Absences
        {
            get { return _absences; }
            set
            {
                if (value != null)
                {
                    _absences = new List<Absence> ();
                    foreach (Absence a in value)
                    {

                        if ((a.CanShowInPlanning && IsPlanning) ||(a.CanShowInRecording && !IsPlanning))
                            _absences.Add(a);
 

                    }
                }
                else
                    _absences = null;
                //_absences = value;

                gridControl.DataSource = _absences;
            }
        }

        Absence GetEntityByRowHandle(int rowHandle)
        {
            return (gridViewAbsence.IsDataRow(rowHandle)) ? (Absence)gridViewAbsence.GetRow(rowHandle) : null;
        }

        public Absence FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewAbsence.FocusedRowHandle);
            }
        }

        public bool IgnoreFeast
        {
            get { return ucSelectIgnore1.IgnoreFeast; }
        }

        public bool IgnoreClosedDay
        {
            get
            { return ucSelectIgnore1.IgnoreClosedDay; }
        }

        public List<BaumaxDayOfWeek> IgnoredDays
        {
            get
            { 
                return new List<BaumaxDayOfWeek> (ucSelectIgnore1.GetIgnoreDays ()); 
            }
        }

        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridViewAbsence.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewAbsence.IsDataRow(info.RowHandle))
            {
                Absence absence = GetEntityByRowHandle(info.RowHandle);

                if (absence != null)
                {
                    SelectAbsence();
                }
            }
        }

        private void gridViewAbsence_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (Absences != null)
            {
                if (e.Column == gridColumn_AbsenceType)
                {
                    int idx = e.ListSourceRowIndex;
                    if (idx >= 0 && idx < Absences.Count && e.IsGetData)
                    {
                        AbsenceType ate = Absences[idx].AbsenceTypeID;

                        switch (ate)
                        {
                            case AbsenceType.Holiday: e.Value = holidayTranslation;
                                break;
                            case AbsenceType.Absence: e.Value = absenceTranslation;
                                break;
                            case AbsenceType.Illness: e.Value = illnessTranslation;
                                break;
                            default:
                                Debug.Assert(false);
                                break;
                        }
                    }
                }
            }
        }

        private void SelectAbsence()
        {
            SelectedAbsence = FocusedEntity;
            bool isCorrect = SelectedAbsence != null;

            if (BeginDate > EndDate)
            {
                edBeginDate.ErrorText = GetLocalized("InvalidDateRange");
                isCorrect = false;
            }

            if (isCorrect)
                DialogResult = DialogResult.OK;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            SelectAbsence();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void teBegin_EditValueChanged(object sender, EventArgs e)
        {
            if (ignorechanged) 
                return;
            
            if (BeginTime != DateTimeHelper.DateTimeToShortWithoutRound(teBegin.Time))
            {
                ignorechanged = true;
                BeginTime = DateTimeHelper.DateTimeToShort(teBegin.Time);
                ignorechanged = false;
            }

            if (EndTime != DateTimeHelper.DateTimeToShortWithoutRound(teEnd.Time))
            {
                ignorechanged = true;
                EndTime = DateTimeHelper.DateTimeToShort(teEnd.Time);
                ignorechanged = false;
            }

            if (EndTime <= BeginTime)
            {
                ignorechanged = true;
                EndTime = (short)(BeginTime + 15);
                ignorechanged = false;
            }
        }

        public void SetDateRange(DateTime minDate, DateTime maxDate)
        {
            edBeginDate.Properties.MinValue = minDate;
            edEndDate.Properties.MinValue = minDate;
            edBeginDate.Properties.MaxValue = maxDate;
            edEndDate.Properties.MaxValue = maxDate;
        }

        private void SelectIgnoreIgnoreSelected(object sender, EventArgs e)
        {
            edIgnore.Text =ucSelectIgnore1.ToString();
        }

        private void gridViewAbsence_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            teEnd.Enabled = teBegin.Enabled = FocusedEntity != null && !FocusedEntity.IsFixed && (FocusedEntity.WithoutFixedTime || FocusedEntity.Value == 0d);
            UpdateButtonEnable();
        }
    }
}