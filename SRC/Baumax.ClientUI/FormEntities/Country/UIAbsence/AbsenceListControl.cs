using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class AbsenceListControl : UCBaseEntity
    {

        private BindingTemplate<Absence> _bindingAbsences = new BindingTemplate<Absence>();
        //private List<Absence> listAllUsedAbsence = null;
        private string absenceTranslation = "Absence";
        private string holidayTranslation = "Holiday";
        private string illnessTranslation = "Illness";
        private bool isUserWriteRight = UCCountryEdit.isUserWriteRight();
        private AbsenceManager _absencemanager = null;
        private long[] _idsUsedAbsence = null;

        public AbsenceListControl()
        {
            InitializeComponent();
            if (!isUserWriteRight)
            {
                gridControl.ContextMenuStrip = null;
                bartools.Visible = false;
            }
        }

        private void LoadUsedAbsenceIds()
        {

            _idsUsedAbsence = ClientEnvironment.CountryService.GetInUseIDList(InUseEntity.Absence, Country.ID);


            
        }

        private bool CheckUsedAbsence(Absence absence)
        {
            if (absence == null)
                throw new ArgumentNullException();

            if (_idsUsedAbsence == null || _idsUsedAbsence.Length == 0) 
                return false;

            foreach (long id in _idsUsedAbsence)
                if (absence.ID == id) return true;

            return false;
        }
        
        public override void AssignLanguage()
        {
            base.AssignLanguage();

            if (!IsDesignMode)
            {
                LocalizerControl.ComponentsLocalize(components);

                absenceTranslation = GetLocalized("Absence");
                holidayTranslation = GetLocalized("Holiday");
                illnessTranslation = GetLocalized("Illness");
            }

        }
        public Domain.Country Country
        {
            get { return (Domain.Country)Entity; }
            set { Entity = value; }
        }


        protected override void EntityChanged()
        {
            InitControl();
            //if (listAllUsedAbsence == null) listAllUsedAbsence = GetAllUsedAbsence();
            UpdateButtonEnable();
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

        public void InitControl()
        {
            LoadAbsences();
        }

        void LoadAbsences()
        {

            if (Country == null)
            {
                _bindingAbsences.Clear();
            }
            else
            {
                gridViewAbsence.BeginDataUpdate();
                try
                {

                    _absencemanager = new AbsenceManager(ClientEnvironment.AbsenceService);
                    _absencemanager.CountryId = Country.ID;

                    _bindingAbsences.Clear();

                    _bindingAbsences.CopyList(_absencemanager.ToList);

                    LoadUsedAbsenceIds();
                }
                finally
                {
                    gridViewAbsence.EndDataUpdate();
                }
            }

            if (gridControl.DataSource == null)
                gridControl.DataSource = _bindingAbsences;
        }


        private void gridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isUserWriteRight) return;
            GridHitInfo info = gridViewAbsence.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewAbsence.IsDataRow(info.RowHandle))
            {
                Absence absence = GetEntityByRowHandle(info.RowHandle);
               // if (CheckUsedAbsence(absence)) return;
                if (absence != null)
                {
                    AbsenceType absType = absence.AbsenceTypeID;
                    if (absType == AbsenceType.Absence)
                        EditAbsence();
                    else 
                        if (absType == AbsenceType.Holiday) 
                            EditHoliday();
                        else
                            if (absType == AbsenceType.Illness) 
                                EditIllness ();
                }
            }
        }

        #region New, Edit, Delete

        private void NewAbsence()
        {
            Absence absence = ClientEnvironment.AbsenceService.CreateEntity();

            if (Country != null)
                absence.CountryID = Country.ID;
                //new Domain.Absence();
            absence.AbsenceTypeID = AbsenceType.Absence ;
            AbsenceForm form = new AbsenceForm(absence);
            form.AbsenceManager = _absencemanager;
            form.CountryReadOnly = Country != null;

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (_bindingAbsences.GetItemByID(form.Absence.ID) == null)
                {

                    _bindingAbsences.Add(form.Absence);
                }
            }

        }
        private void EditAbsence()
        {
            Absence absence = FocusedEntity;
            if (absence != null && absence.AbsenceTypeID == AbsenceType.Absence)
            {
                AbsenceForm form = new AbsenceForm(absence);
                form.CountryReadOnly = Country != null;
                form.AbsenceManager = _absencemanager;
                if (CheckUsedAbsence(FocusedEntity))
                {
                  form.EntityUsed = true;  
                }
                if (form.ShowDialog() == DialogResult.OK)
                {
                    
                    if (_bindingAbsences.GetItemByID(form.Absence.ID) != null)
                    {
                        _bindingAbsences.SetEntity (form.Absence);
                    }
                }
            }
        }
        
        void DeleteEntity()
        {
            Absence absence = FocusedEntity;
            if (absence == null) return;
            AbsenceType ate = absence.AbsenceTypeID;
            switch (ate)
            {
                case AbsenceType.Holiday:
                    DeleteHoliday();
                    break;
                case AbsenceType.Absence:
                    DeleteAbsence();
                    break;
                case AbsenceType.Illness:
                    DeleteIllness();
                    break;
            }
        }
        
        void EditEntity()
        {
            Absence absence = FocusedEntity;
            if (absence == null) return;
            AbsenceType ate = absence.AbsenceTypeID;
            switch (ate)
            {
                case AbsenceType.Holiday:
                    EditHoliday();
                    break;
                case AbsenceType.Absence:
                    EditAbsence();
                    break;
                case AbsenceType.Illness:
                    EditIllness();
                    break;
            }
        }

        private void DeleteAbsence()
        {
            Absence absence = FocusedEntity;
            if (absence != null && absence.AbsenceTypeID == AbsenceType.Absence)
            {
                if (QuestionMessageYes(GetLocalized ("questiondeleteabsence")))
                {
                    try
                    {
                        //ClientEnvironment.CountryService.AbsenceService.DeleteByID(absence.ID);
                        _absencemanager.Delete(absence.ID);
                        _bindingAbsences.Remove(absence);
                    }
                    catch (ValidationException)
                    {
                        ErrorMessage(GetLocalized("CantDeleteAbsence"));
                        return;
                    }
                    catch (EntityException ex)
                    {
                        ProcessEntityException(ex);
                        return;
                    }
                    
                }
            }
        }

        private void NewHoliday()
        {
            Absence absence = ClientEnvironment.AbsenceService.CreateEntity();
            if (Country != null)
                absence.CountryID = Country.ID;
            absence.AbsenceTypeID = AbsenceType.Holiday;
            AbsenceForm form = new AbsenceForm(absence);
            form.AbsenceManager = _absencemanager;
            form.CountryReadOnly = Country != null;
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (_bindingAbsences.GetItemByID(absence.ID) == null)
                {
                    _bindingAbsences.Add(absence);
                }
            }
        }

        private void EditHoliday()
        {
            Absence absence = FocusedEntity;

            if (absence != null && absence.AbsenceTypeID == AbsenceType.Holiday)
            {
                AbsenceForm form = new AbsenceForm(absence);
                form.AbsenceManager = _absencemanager;
                form.CountryReadOnly = Country != null;
                if (CheckUsedAbsence(FocusedEntity))
                {
                    form.EntityUsed = true;
                }
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (_bindingAbsences.GetItemByID(form.Absence.ID) != null)
                    {
                        _bindingAbsences.SetEntity(form.Absence);
                    }
                }
            }
        }

        private void DeleteHoliday()
        {
            Absence absence = FocusedEntity;
            if (absence != null && absence.AbsenceTypeID == AbsenceType.Holiday)
            {
                if (QuestionMessageYes(GetLocalized ("questiondeleteholiday")))//"Are you sure to remove holiday?"))
                {
                    try
                    {
                        //ClientEnvironment.CountryService.AbsenceService.DeleteByID(absence.ID);
                        _absencemanager.Delete(absence.ID);
                        _bindingAbsences.Remove(absence);
                    }
                    catch (ValidationException)
                    {
                        ErrorMessage(GetLocalized("CantDeleteAbsence"));
                        return;
                    }
                    catch (EntityException ex)
                    {
                        ProcessEntityException(ex);
                        return;
                    }
                    _bindingAbsences.Remove(absence);
                }
            }
        }

        private void NewIllness()
        {
            if (Country == null) return;

            Absence absence = ClientEnvironment.AbsenceService.CreateEntity();
            absence.CountryID = Country.ID;
            absence.AbsenceTypeID = AbsenceType.Illness;
            AbsenceForm form = new AbsenceForm(absence);
            form.AbsenceManager = _absencemanager;
            form.CountryReadOnly = true;
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (_bindingAbsences.GetItemByID(absence.ID) == null)
                {
                    _bindingAbsences.Add(absence);
                }
            }
        }

        private void EditIllness()
        {
            Absence absence = FocusedEntity;

            if (absence != null && absence.AbsenceTypeID == AbsenceType.Illness)
            {
                AbsenceForm form = new AbsenceForm(absence);
                form.AbsenceManager = _absencemanager;
                form.CountryReadOnly = true;
                if (CheckUsedAbsence(FocusedEntity))
                {
                    form.EntityUsed = true;
                }
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (_bindingAbsences.GetItemByID(form.Absence.ID) != null)
                    {
                        _bindingAbsences.SetEntity(form.Absence);
                    }
                }
            }
        }

        private void DeleteIllness()
        {
            Absence absence = FocusedEntity;
            if (absence != null && absence.AbsenceTypeID == AbsenceType.Illness)
            {
                if (QuestionMessageYes(GetLocalized("QuestionDeleteIllness")))//"Are you sure to remove holiday?"))
                {
                    try
                    {
                        //ClientEnvironment.CountryService.AbsenceService.DeleteByID(absence.ID);
                        _absencemanager.Delete(absence.ID);
                        _bindingAbsences.Remove(absence);
                    }
                    catch (ValidationException)
                    {
                        ErrorMessage(GetLocalized("CantDeleteAbsence"));
                        return;
                    }
                    catch (EntityException ex)
                    {
                        ProcessEntityException(ex);
                        return;
                    }
                    _bindingAbsences.Remove(absence);
                }
            }
        }
        public void RefreshAbsences()
        {
            LoadAbsences();
        }

        #endregion


        #region popup menu events

        private void toolStripMenuItem_NewAbsence_Click(object sender, EventArgs e)
        {
            NewAbsence();
        }

        private void toolStripMenuItem_NewHoliday_Click(object sender, EventArgs e)
        {
            NewHoliday();
        }

        private void toolStripMenuItem_RefreshAbsences_Click(object sender, EventArgs e)
        {
            RefreshAbsences();
        }
        private void mi_NewIllness_Click(object sender, EventArgs e)
        {
            NewIllness();
        }

        private void contextMenuStripAbsence_Opening(object sender, CancelEventArgs e)
        {
            Absence absence = FocusedEntity;

            if (absence == null)
            {
                mi_NewAbsence.Enabled =
                    mi_NewHoliday.Enabled = 
                mi_NewIllness.Enabled = true;

                mi_EditAbsence.Enabled =
                    mi_DeleteAbsence.Enabled = false;
            }
            else
            {
                AbsenceType ate = absence.AbsenceTypeID;

                mi_NewHoliday.Enabled = true;
                mi_NewAbsence.Enabled = true;
                mi_NewIllness.Enabled = true;
                mi_EditAbsence.Enabled = true;
                mi_DeleteAbsence.Enabled =  !CheckUsedAbsence(FocusedEntity);
                switch (ate)
                {
                    case AbsenceType.Holiday:
                         mi_EditAbsence.Text = GetLocalized("editholiday");
                         mi_DeleteAbsence.Text = GetLocalized( "deleteholiday"); 
                        break;
                    case AbsenceType.Absence:
                        mi_EditAbsence.Text = GetLocalized("editabsence");
                        mi_DeleteAbsence.Text = GetLocalized("deleteabsence");
                        break;
                    case AbsenceType.Illness:
                        mi_EditAbsence.Text = GetLocalized("editillness");
                        mi_DeleteAbsence.Text = GetLocalized("deleteillness");
                        break;
                }
            }
        }
        #endregion 

        private void gridViewAbsence_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == gridColumn_AbsenceType)
            {
                int idx = e.ListSourceRowIndex;
                if (idx >= 0 && idx < _bindingAbsences.Count && e.IsGetData)
                {
                    AbsenceType ate = _bindingAbsences[idx].AbsenceTypeID;

                    switch (ate)
                    {
                        case AbsenceType.Holiday: e.Value = holidayTranslation;
                            break;
                        case AbsenceType.Absence: e.Value = absenceTranslation;
                            break;
                        case AbsenceType.Illness: e.Value = illnessTranslation;
                            break;
                        default :
                            Debug.Assert(false);
                            break;
                    }
                }
            }
            
            if (e.Column == gridColumn_availablein)
            {
                int idx = e.ListSourceRowIndex;
                if (idx >= 0 && idx < _bindingAbsences.Count && e.IsGetData)
                {
                    IsShowAbsence ate = _bindingAbsences[idx].IsShow;

                    switch (ate)
                    {
                        case IsShowAbsence.PlanningRecording: e.Value = GetLocalized("PlanningTimeRecording");
                            break;
                        case IsShowAbsence.Planning: e.Value = GetLocalized("PlanningOnly");
                            break;
                        case IsShowAbsence.Recording: e.Value = GetLocalized("TimeRecordingOnly");
                            break;
                        case IsShowAbsence.None: e.Value = GetLocalized("AvailableNone");
                            break;
                        default :
                            Debug.Assert(false);
                            break;
                    }
                }
            }
        }

        private void gridControl_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && FocusedEntity != null && isUserWriteRight && !CheckUsedAbsence(FocusedEntity))
            DeleteEntity();
        }
        
        void UpdateButtonEnable()
        {
            if (!isUserWriteRight) return;
            bi_Delete.Enabled = (FocusedEntity != null && !CheckUsedAbsence(FocusedEntity));
            bi_editabsence.Enabled = FocusedEntity != null;
            if (FocusedEntity != null)
            {
                Absence absence = FocusedEntity;
                AbsenceType ate = absence.AbsenceTypeID;
                switch (ate)
                {
                    case AbsenceType.Holiday:
                        bi_editabsence.Caption = GetLocalized("editholiday");
                        bi_Delete.Caption = GetLocalized( "deleteholiday");  
                        break;
                    case AbsenceType.Absence:
                        bi_editabsence.Caption = GetLocalized("editabsence");
                        bi_Delete.Caption = GetLocalized("deleteabsence");
                        break;
                    case AbsenceType.Illness:
                        bi_editabsence.Caption = GetLocalized("editillness");
                        bi_Delete.Caption = GetLocalized("deleteillness"); 
                        break;
                }
            }
            else
            {
                bi_editabsence.Caption = GetLocalized("editabsence");
                bi_Delete.Caption = GetLocalized("delete");  
            }
        }

        private void bi_Delete_Click(object sender, ItemClickEventArgs e)
        {
            DeleteEntity();
        }

        private void bi_edit_Click(object sender, ItemClickEventArgs e)
        {
            EditEntity();
        }

        private void bi_NewAbsence_Click(object sender, ItemClickEventArgs e)
        {
            NewAbsence();
        }

        private void bi_NewHoliday_Click(object sender, ItemClickEventArgs e)
        {
            NewHoliday();
        }

        private void bi_NewIllness_Click(object sender, ItemClickEventArgs e)
        {
            NewIllness();
        }

        private void gridViewAbsence_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            UpdateButtonEnable();
        }

        private void toolStripMenuItem_Edit_Click(object sender, EventArgs e)
        {
            EditEntity();
        }

        private void toolStripMenuItem_Delete_Click(object sender, EventArgs e)
        {
            DeleteEntity();
        }
    }
}

