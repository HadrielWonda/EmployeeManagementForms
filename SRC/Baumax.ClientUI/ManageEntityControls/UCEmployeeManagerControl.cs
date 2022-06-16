using System;
using System.Windows.Forms;
using Baumax.ClientUI.FormEntities;
using Baumax.ClientUI.FormEntities.Employee;
using Baumax.ClientUI.Import;
using Baumax.Contract;
using Baumax.Environment;
using DevExpress.XtraNavBar;

namespace Baumax.ClientUI.ManageEntityControls
{
    public partial class UCEmployeeManagerControl : UCBaseEntity 
    {
        private bool _CanEdit;

        public UCEmployeeManagerControl()
        {
            InitializeComponent();
            bi_ImportLongTimeAbsence.Visible = false;
            if (!IsDesignMode)
            {
                AccessType access = ClientEnvironment.AuthorizationService.GetAccess(ClientEnvironment.EmployeeService);
                _CanEdit = (access & AccessType.Write) != 0;
                ucEmployeeList1.ReadOnly = !_CanEdit;

                if (!isCurentuserRoleCentralGlobalAdministration())
                    bi_ImportEmployee.Visible = false;
            }
        }

        private bool isCurentuserRoleCentralGlobalAdministration()
        {
            if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
             (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value == (long)UserRoleId.GlobalAdmin))
                return true;
            else 
                return false;
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsDesignMode)
            {
                ucEmployeeList1.Init();
                UpdateButtonState();
            }
        }

        private void bi_NewExternalEmployee_LinkClicked(object sender, NavBarLinkEventArgs e)
        {

            if (ucEmployeeList1.EntityStore != null)
            {
                ucEmployeeList1.NewExternalEmployee();
            }
        }

        private void ucEmployeeList1_OnChangeListState()
        {
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            bool isExistEmployee = ucEmployeeList1.FocusedEntity != null;
            bool isExternalEmployee = !ucEmployeeList1.IsNormalEmployee;
            bool isExistsStore = ucEmployeeList1.EntityStore != null;
			bool isDeligatedEmployee = ucEmployeeList1.IsDeligatedEmployee;
        	bool isContractExpired = ucEmployeeList1.IsFocusedEmployeeContractExpired;
        	
            bi_ImportEmployee.Enabled = _CanEdit;
            bi_NewEmplLongTimeAbsence.Enabled = isExistEmployee && !isContractExpired && _CanEdit;
            bi_DelegateToStore.Enabled = isExistEmployee && !isDeligatedEmployee && !isContractExpired && _CanEdit;
            bi_AssignToWorld.Enabled = isExistEmployee && !isContractExpired && _CanEdit;
            bi_AssignEmployeeToHWGR.Enabled = isExistEmployee && _CanEdit;
            bi_EmployeeWorkingHistory.Enabled = isExistEmployee;
            bi_AssignToEmployee.Enabled = isExistEmployee && isExternalEmployee && _CanEdit;

            bi_NewExternalEmployee.Enabled = isExistsStore && _CanEdit;
            bi_EditExternalEmployee.Enabled = isExistEmployee && isExternalEmployee && _CanEdit;
            bi_DeleteExternalEmployee.Enabled = isExistEmployee && isExternalEmployee && _CanEdit;

            bi_ViewEmployeesHasLongTimeAbsence.Enabled = isExistsStore;
        }

        private void bi_EditExternalEmployee_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ucEmployeeList1.EntityStore != null && ucEmployeeList1.FocusedEntity != null && !ucEmployeeList1.FocusedEntity.Import)
            {
                ucEmployeeList1.EditExternalEmployee();
            }
        }

        private void bi_DeleteExternalEmployee_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ucEmployeeList1.EntityStore != null && ucEmployeeList1.FocusedEntity != null && !ucEmployeeList1.FocusedEntity.Import)
            {
                ucEmployeeList1.DeleteExternalEmployee();
            }
        }

        private void bi_AssignEmployeeToWorld_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ucEmployeeList1.EntityStore != null && ucEmployeeList1.FocusedEntity != null)
            {
                ucEmployeeList1.AssignToWorld ();
            }

        }

        private void bi_ImportEmployee_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ucEmployeeList1.ImportEmployees();
        }

        private void bi_ImportLongTimeAbsence_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ImportUI.ImportLongTimeAbsences ())
            {
                
            }
            /*using (FrmImport frmImport = new FrmImport(ClientEnvironment.CountryService, ClientEnvironment.RegionService, ClientEnvironment.StoreService, ClientEnvironment.EmployeeService, Baumax.Import.ImportType.LongTimeAbsence))
            {
                frmImport.ShowDialog();
                if (frmImport.BeenRunSuccessfully)
                {

                }
            }*/
        }

        private void bi_EnterLongTimeAbsence_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ucEmployeeList1.EnterLongTimeAbsence();
        }

        private void bi_DelegateToAnotherStore_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ucEmployeeList1.DelegateToStore();
        }

        private void bi_ViewEmployeesLongTimeAbsences_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ucEmployeeList1.EntityStore != null)
            {
                using (FormLongTimeAbsenceEmployees f = new FormLongTimeAbsenceEmployees())
                {
                    f.Entity = ucEmployeeList1.Context;
                    f.ShowDialog();
                }
            }
        }
        /*
        private void bi_NewLongTimeAbsence_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            using (FormLongTimeAbsence newAbsenceForm = new FormLongTimeAbsence())
            {
                LongTimeAbsence newAbsence = new LongTimeAbsence();
                newAbsenceForm.Entity = newAbsence;

                newAbsenceForm.ShowDialog();
            }
        }

        private void bi_ViewLongTimeAbsences_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            using (FormLongTimeAbsenceList absenceListForm = new FormLongTimeAbsenceList())
            {
                absenceListForm.InitAbsenceList();
                absenceListForm.ShowDialog();
            }
        }
        */
        private void bi_AssignExtrenalEmployeeToEmployee_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ucEmployeeList1.AssignExtEmployeeToEmployee();
        }

        private void bi_ViewEmployeePlaceHistory_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ucEmployeeList1.FocusedEntity != null)
            {

                using (FormEmployeeWorkHistory form = new FormEmployeeWorkHistory())
                {
                    EmployeeContext context = ucEmployeeList1.Context;
                    context.CurrentEmployee = ucEmployeeList1.FocusedEntity;
                    form.Entity = context;

                    form.ShowDialog();
                }
            }
        }

        private void bi_AssignHWGR_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ucEmployeeList1.FocusedEntity != null)
            {
                ucEmployeeList1.AssignEmployeeToHWGR();
                //using (FormAssignEmployeeToHwgr form = new FormAssignEmployeeToHwgr())
                //{
                //    form.Entity = ucEmployeeList1.FocusedEntity;

                //    if (form.ShowDialog() != DialogResult.Cancel)
                //        ucEmployeeList1.RefreshGrid();
                //}
            }
        }
    }
}
