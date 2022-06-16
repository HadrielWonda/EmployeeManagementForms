using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Domain;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities.AbsencePlanning
{
    public partial class SelectAbsenceForm : FormBaseEntity 
    {
        private List<Absence> _AbsenceList;
        private Absence _absence = null;
        private string absenceTranslation = "Absence";
        private string holidayTranslation = "Holiday";
        private string illnessTranslation = "Illness";
        public SelectAbsenceForm()
        {
            InitializeComponent();
            edIgnore.Text = ucSelectIgnore1.ToString();
        }
        public short BeginTime
        {
            get { return DateTimeHelper.DateTimeToShort(teBegin.Time); }
            set { teBegin.Time = DateTimeHelper.ShortToDateTime(value); }
        }

        public short EndTime
        {
            get { return DateTimeHelper.DateTimeToShort(teEnd.Time); }
            set { teEnd.Time = DateTimeHelper.ShortToDateTime(value); }
        }

        public DateTime EndDate
        {
            get { return edEndDate.DateTime; }
            set { edEndDate.DateTime = value; }
        }

        public DateTime BeginDate
        {
            get { return edBeginDate.DateTime; }
            set { edBeginDate.DateTime = value; }
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
                return new List<BaumaxDayOfWeek>(ucSelectIgnore1.GetIgnoreDays());
            }
        }
        public Absence GetEntityByRowHandle(int rowHandle)
        {
            return (gridViewAbsence.IsDataRow(rowHandle)) ? (Absence)gridViewAbsence.GetRow(rowHandle) : null;
        }
        public Absence SelectedAbsence
        {
            get { return _absence; }
            set { _absence = value; }
        }
        public Absence FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewAbsence.FocusedRowHandle);
            }
        }
        public void SetMinMaxDate(DateTime minDate, DateTime maxDate)
        {
            edBeginDate.Properties.MinValue = minDate;
            edEndDate.Properties.MinValue = minDate;

            edBeginDate.Properties.MaxValue = maxDate;
            edEndDate.Properties.MaxValue = maxDate;
        }
        public void SetOpenCloseTime(short opentime, short endtime)
        {
            BeginTime = opentime;
            EndTime = endtime;
        }
        public List<Absence> AbsenceList
        {
            get { return _AbsenceList; }
            set 
            {
                if (value != null)
                {
                    _AbsenceList = new List<Absence>();
                    foreach (Absence a in value)
                    {

                        if (a.CanShowInPlanning)
                            _AbsenceList.Add(a);


                    }
                }
                else
                    _AbsenceList = null;
                //_absences = value;

                gridControl.DataSource = _AbsenceList;

                //_AbsenceList = value;
                //gridControl.DataSource = _AbsenceList;
            }
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();

            if (!UCBaseEntity.IsDesignMode)
            {
                absenceTranslation = GetLocalized("Absence");
                holidayTranslation = GetLocalized("Holiday");
                illnessTranslation = GetLocalized("Illness");
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateButtonEnable();
        }

        private void UpdateButtonEnable()
        {
            if (FocusedEntity != null)
                btn_Select.Enabled = true;
            else
                btn_Select.Enabled = false;
        }
        
        public bool Execute()
        {
            return ShowDialog() == DialogResult.OK;
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
            if (AbsenceList != null)
            {
                if (e.Column == gridColumn_AbsenceType)
                {
                    int idx = e.ListSourceRowIndex;
                    if (idx >= 0 && idx < AbsenceList.Count && e.IsGetData)
                    {
                        AbsenceType ate = AbsenceList[idx].AbsenceTypeID;

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
        private void SelectIgnoreIgnoreSelected(object sender, EventArgs e)
        {
            edIgnore.Text = ucSelectIgnore1.ToString();
        }

        private void gridViewAbsence_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            teEnd.Enabled = teBegin.Enabled = FocusedEntity != null && !FocusedEntity.IsFixed && (FocusedEntity.WithoutFixedTime || FocusedEntity.Value == 0d);
            UpdateButtonEnable();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            SelectAbsence();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}