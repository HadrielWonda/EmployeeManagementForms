using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraEditors.Controls;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class AbsenceForm : FormBaseEntity
    {

        Absence _entity = null;

        const int lightWhite = 1, darkWhite = -5, lightBlack = -16777215, darkBlack = -16777218, red = -65536;
        private bool _countryreadonly = false;
        private bool _modified = false;
        private bool _used = false;
        bool isChecked = false;

        private AbsenceManager _absencemanager = null;
        #region ctor

        public AbsenceForm()
        {
            InitializeComponent();
            EntityControl = null;
        }

        public AbsenceForm(Absence entity)
        {
            InitializeComponent();
            EntityControl = null;
            Absence = entity;
        }

        #endregion

        public AbsenceManager AbsenceManager
        {
            get { return _absencemanager; }
            set { _absencemanager = value; }
        }

        [Browsable (false)]
        public Absence  Absence
        {
            get { return _entity; }
            set 
            {
                if (_entity != value)
                {
                    _entity = value;
                    BindEntity();
                }
            }
        }

        public bool CountryReadOnly
        {
            get { return _countryreadonly; }
            set
            {
                if (value != _countryreadonly)
                {
                    _countryreadonly = value;
                    cbCountries.Properties.ReadOnly = _countryreadonly;
                }
            }
        }

        public bool EntityUsed
        {
            get { return _used; }
            set {_used = value; }
        }
        
        private void RadioGroupTralnslate()
        {
            radioGroup_AvailableIn.Properties.Items[0].Description = GetLocalized("PlanningTimeRecording");
            radioGroup_AvailableIn.Properties.Items[1].Description = GetLocalized("PlanningOnly");
            radioGroup_AvailableIn.Properties.Items[2].Description = GetLocalized("TimeRecordingOnly");
            radioGroup_AvailableIn.Properties.Items[3].Description = GetLocalized("AvailableNone");


            radioGroup_AvailableIn.Properties.Items[0].Value = IsShowAbsence.PlanningRecording;
            radioGroup_AvailableIn.Properties.Items[1].Value = IsShowAbsence.Planning;
            radioGroup_AvailableIn.Properties.Items[2].Value = IsShowAbsence.Recording;
            radioGroup_AvailableIn.Properties.Items[3].Value = IsShowAbsence.None;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Absence.IsNew) 
                AbsenceColor = red;
            if (EntityUsed)
            {
                checkEdit_AbsenceAliquotTime.Enabled = 
                    spinEdit_CountFixedAmount.Enabled =
                    chk_UseAsWorkingTime.Enabled =
                    chk_WithoutFixedTime.Enabled = 
                    chk_CountAsOneDay.Enabled = 
                    lbl_AbsenceCountFixedAmount.Enabled = false;
            }
        }
        
        public override bool Modified
        {
            get
            {
                return _modified;
            }
        }

        #region Absence properties

        internal long CountryID
        {
            get 
            {
                if (cbCountries.EditValue == null) return -1;
                return Convert.ToInt64(cbCountries.EditValue); 
            }
            set 
            {
                cbCountries.EditValue = value; 
            }
        }

        internal string AbsenceName
        {
            get { return textEditAbsenceName.Text.Trim(); }
            set { textEditAbsenceName.Text = value; }
        }

        internal string Abbreviation
        {
            get { return textEditAbsenceAbbreviation.Text.Trim(); }
            set { textEditAbsenceAbbreviation.Text = value; }
        }

        internal int AbsenceColor
        {
            get
            {
                return Convert.ToInt32(cbAbsenceColor.EditValue);
            }
            set
            {
                cbAbsenceColor.EditValue = value;
            }
        }
        
        internal bool IsFixedAmount
        {
            get
            {
                return checkEdit_AbsenceAliquotTime.Checked;
            }
            set
            {
                checkEdit_AbsenceAliquotTime.Checked = value;
            }
        }

        internal double AbsenceValue
        {
            get
            {
                return Convert.ToDouble(spinEdit_CountFixedAmount.EditValue);
            }
            set
            {
                spinEdit_CountFixedAmount.EditValue = value;
            }
        }

        internal bool WithoutFixedTimeAmount
        {
            get
            {
                return chk_WithoutFixedTime.Checked;
            }
            set
            {
                chk_WithoutFixedTime.Checked = value;
            }
        }
        internal bool UseInCalculation
        {
            get
            {
                 
                return chk_UseAsWorkingTime.Checked;
            }
            set
            {
                chk_UseAsWorkingTime.Checked = value;
            }
        }
        internal bool CountAsOneDay
        {
            get
            {

                return chk_CountAsOneDay.Checked;
            }
            set
            {
                chk_CountAsOneDay.Checked = value;
            }
        }
        internal IsShowAbsence IsShow
        {
            get
            {
                return (IsShowAbsence)(radioGroup_AvailableIn.EditValue);
            }
            set
            {
                //byte v = (byte)value;
                radioGroup_AvailableIn.EditValue = value; // (byte)(value - 1);
            }
        }
        
        internal int? SystemId
        {

            get 
            {
                if (txtEditSystemId.Text.Length > 0)
                    return Convert.ToInt32(txtEditSystemId.Text);
                else
                    return null;

            }
            set
            {
                if (value.HasValue)
                    txtEditSystemId.Text = value.ToString();
                else
                    txtEditSystemId.Text = "0";
            }
        }
        #endregion

        private void BindCountryList()
        {
            List<Domain.Country> _countryList = ClientEnvironment.CountryService.FindAll();

            cbCountries.Properties.DisplayMember = "Name";
            cbCountries.Properties.ValueMember = "ID";
            cbCountries.Properties.Columns.Clear();
            cbCountries.Properties.Columns.Add(new LookUpColumnInfo("Name", 100, ""));

            cbCountries.Properties.DataSource = _countryList;
        }

        private void BindEntity()
        {
            Debug.Assert(Absence != null);
            {
                BindCountryList();
                RadioGroupTralnslate();

                _changingState = true;
                AbsenceName = Absence.Name;
                Abbreviation = Absence.CharID;
                CountryID = Absence.CountryID;
                AbsenceColor = Absence.Color;
                IsFixedAmount = Absence.IsFixed;
                WithoutFixedTimeAmount = Absence.WithoutFixedTime;
                AbsenceValue = Absence.Value;
                UseInCalculation = Absence.UseInCalck;
                _changingState = false;
                CountAsOneDay = Absence.CountAsOneDay;

                IsShow = Absence.IsShow;

                if (Absence.IsNew)
                {
                    WithoutFixedTimeAmount = true;
                    //IsShow = IsShowAbsence.PlanningRecording;
                    if (Absence.AbsenceTypeID == AbsenceType.Holiday)
                    {
                        Abbreviation = "u";
                    }
                    if (Absence.AbsenceTypeID == AbsenceType.Illness)
                    {
                        Abbreviation = "i";
                    }
                }
                //else
                //{
                //    IsShow = Absence.IsShow;   
                //}

                switch (Absence.AbsenceTypeID)
                {
                    case AbsenceType.Holiday:
                        {
                            lblCaption.Text = (Absence.IsNew) ? GetLocalized("NewHoliday") : GetLocalized("EditHoliday");
                        }
                        break;
                    case AbsenceType.Absence :
                        {
                            lblCaption.Text = (Absence.IsNew) ? GetLocalized("NewAbsence") : GetLocalized("EditAbsence");
                        }
                        break;
                    case AbsenceType.Illness :
                        {
                            lblCaption.Text = (Absence.IsNew) ? GetLocalized("NewIllness") : GetLocalized("EditIllness");
                        }
                        break;
                    default :
                        Debug.Assert(false); break;

                }


                if (Absence.CountryID == ClientEnvironment.CountryService.AustriaCountryID)
                {
                    lblSystemID.Visible = true;
                    txtEditSystemId.Visible = true;

                    SystemId = Absence.SystemID;
                    
                }
            }
        }

        protected override bool ValidateEntity()
        {
            Debug.Assert(Absence != null);

            if (String.IsNullOrEmpty(AbsenceName))
            {
                ErrorMessage(GetLocalized("err_enter_absence_name"));
                textEditAbsenceName.Focus();
                return false;
            }
            else
                textEditAbsenceName.ErrorText = String.Empty;
                
            if (Abbreviation.Length == 0 )
            {
                ErrorMessage(GetLocalized("err_enter_abbreviation"));
                //textEditAbsenceName.ErrorText = "Enter abbreviation";
                textEditAbsenceAbbreviation.Focus();
                return false;
            }
            else
                textEditAbsenceAbbreviation.ErrorText = String.Empty;
            if (IsModified() && !isChecked && ((AbsenceColor < lightWhite && AbsenceColor > darkWhite) || (AbsenceColor < lightBlack && AbsenceColor > darkBlack)))
            {
                InfoMessage(GetLocalized("err_enter_absence_colour"));
                cbAbsenceColor.Focus();
                isChecked = true;
                return false;
            }
            
            
            

            if (CountryID == -1)
            {
                ErrorMessage(GetLocalized("err_absence_select_country"));
                //cbCountries.ErrorText = "Select country";
                cbCountries.Focus();
                return false;
            }
            else
                cbCountries.ErrorText = String.Empty;



            if (Absence.CountryID == ClientEnvironment.CountryService.AustriaCountryID)
            {
                if (AbsenceManager != null)
                {
                    if (!String.IsNullOrEmpty(txtEditSystemId.Text))
                    {
                        int? systemid = Convert.ToInt32(txtEditSystemId.Text);
                        if (systemid == 0)
                            systemid = null;
                        if (!AbsenceManager.IsValidSystemId(Absence.ID, systemid))
                        {
                            ErrorMessage(GetLocalized("err_systemid_must_be_unique"));
                            txtEditSystemId.Focus();
                            return false;
                        }
                    }
                }
            }


            return true;
        }

        private bool IsModified()
        {
            Debug.Assert(Absence != null);

            return Absence.IsNew || (Absence.CountryID != CountryID) ||
                   (Absence.Name != AbsenceName) ||
                   (Absence.CharID != Abbreviation) ||
                   (Absence.IsFixed != IsFixedAmount) ||
                   (Absence.Value != AbsenceValue) ||
                   (Absence.Color != AbsenceColor) ||
                   (Absence.WithoutFixedTime != WithoutFixedTimeAmount) ||
                   (Absence.UseInCalck != UseInCalculation ) ||
                   (Absence.SystemID != SystemId) ||
                   (Absence.CountAsOneDay != CountAsOneDay ) ||
                   (Absence.IsShow != (IsShowAbsence)(radioGroup_AvailableIn.SelectedIndex + 1));
        }

        private Absence CreateCopyAbsence()
        {
            Absence copyAbsence = ClientEnvironment.AbsenceService.CreateEntity();

            AssignAbsence(Absence, copyAbsence);

            return copyAbsence;
        }

        private void AssignAbsence(Absence source, Absence dest)
        {
            Debug.Assert(source!= null);
            Debug.Assert(dest != null);
            BaseEntity.CopyTo(source, dest);
        }

        private void SaveInputDataTo(Absence entity)
        {
            entity.Name = AbsenceName;
            entity.CharID = Abbreviation;
            entity.CountryID = CountryID;
            entity.Color = AbsenceColor;
            entity.IsFixed = IsFixedAmount;
            entity.WithoutFixedTime = WithoutFixedTimeAmount;
            entity.Value = AbsenceValue;
            entity.UseInCalck = UseInCalculation;
            entity.SystemID = SystemId;
            entity.CountAsOneDay = CountAsOneDay;
            entity.IsShow = IsShow;
        }

        protected override bool SaveEntity()
        {
            Debug.Assert(Absence != null);
            if (!IsModified())
                return true;
            else 
            {
                if (Absence.IsNew)
                {
                    Absence.LanguageID = SharedConsts.NeutralLangId;
                }
                
                Absence copyAbsence = CreateCopyAbsence();
                
                SaveInputDataTo(copyAbsence);
                try
                {
                    if (Absence.IsNew)
                        copyAbsence = ClientEnvironment.AbsenceService.Save(copyAbsence);
                    else
                        ClientEnvironment.AbsenceService.SaveOrUpdate(copyAbsence);


                    AssignAbsence(copyAbsence, Absence);

                    _modified = true;

                    if (AbsenceManager != null && AbsenceManager.GetById (Absence.ID) == null)
                        AbsenceManager.AddToDiction(Absence);
                }
                catch (ValidationException)
                {
                    string str = GetLocalized("ErrorUniqueAbsenceNameOrAbb");
                    if (String.IsNullOrEmpty(str)) str = "Absence name or abbreviation not unique";
                    ErrorMessage(str);
                    return false;
                }
                catch (EntityException ex)
                {
                    ProcessEntityException(ex);
                    return false;
                }
            }
            return true;
        }

        private bool _changingState = false;
        private void ChangeState(int status)
        {
            if (!_changingState)
            {
                _changingState = true;

                switch (status)
                {
                    case 1:
                        if (IsFixedAmount)
                        {
                            AbsenceValue = 0;
                            WithoutFixedTimeAmount = false;
                            CountAsOneDay = false;
                        }

                        break;

                    case 2:
                        if (WithoutFixedTimeAmount)
                        {
                            AbsenceValue = 0;
                            IsFixedAmount = false;
                        }
                        break;

                    case 3:
                        if (AbsenceValue != 0)
                        {
                            IsFixedAmount = false;
                            WithoutFixedTimeAmount = false;
                        }
                        break;
                    case 4:
                        if (CountAsOneDay)
                        {
                            IsFixedAmount = false;
                        }
                        break;
                }

                _changingState = false;
            }
        }

        private void checkEdit_AbsenceAliquotTime_CheckedChanged(object sender, EventArgs e)
        {
            ChangeState(1);
        }

        private void checkEdit_WithoutFixed_CheckedChanged(object sender, EventArgs e)
        {
            ChangeState(2);
        }

        private void spinEdit_CountFixedAmount_EditValueChanged(object sender, EventArgs e)
        {
            ChangeState(3);
        }

        private void chk_CoutAsOneDay_CheckedChanged(object sender, EventArgs e)
        {
            ChangeState(4);
        }
    }
}

