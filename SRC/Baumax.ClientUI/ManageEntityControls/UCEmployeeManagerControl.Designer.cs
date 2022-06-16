namespace Baumax.ClientUI.ManageEntityControls
{
    partial class UCEmployeeManagerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.gc_EmployeeManager = new DevExpress.XtraNavBar.NavBarGroup();
            this.bi_ImportEmployee = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_AssignToWorld = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_EmployeeWorkingHistory = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_DelegateToStore = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_AssignEmployeeToHWGR = new DevExpress.XtraNavBar.NavBarItem();
            this.gc_ExternalEmployeeManager = new DevExpress.XtraNavBar.NavBarGroup();
            this.bi_NewExternalEmployee = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_EditExternalEmployee = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_DeleteExternalEmployee = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_AssignToEmployee = new DevExpress.XtraNavBar.NavBarItem();
            this.gc_EmployeeLongTimeAbsenceManager = new DevExpress.XtraNavBar.NavBarGroup();
            this.bi_ImportLongTimeAbsence = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_ViewEmployeesHasLongTimeAbsence = new DevExpress.XtraNavBar.NavBarItem();
            this.bi_NewEmplLongTimeAbsence = new DevExpress.XtraNavBar.NavBarItem();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.ucEmployeeList1 = new Baumax.ClientUI.FormEntities.Employee.UCEmployeeList();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.navBarControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(200, 573);
            this.panelControl1.TabIndex = 0;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.gc_EmployeeManager;
            this.navBarControl1.AllowDrop = false;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.gc_EmployeeManager,
            this.gc_ExternalEmployeeManager,
            this.gc_EmployeeLongTimeAbsenceManager});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.bi_ImportEmployee,
            this.bi_NewEmplLongTimeAbsence,
            this.bi_AssignToWorld,
            this.bi_DelegateToStore,
            this.bi_NewExternalEmployee,
            this.bi_EditExternalEmployee,
            this.bi_AssignToEmployee,
            this.bi_DeleteExternalEmployee,
            this.bi_ImportLongTimeAbsence,
            this.bi_ViewEmployeesHasLongTimeAbsence,
            this.bi_EmployeeWorkingHistory,
            this.bi_AssignEmployeeToHWGR});
            this.navBarControl1.Location = new System.Drawing.Point(2, 2);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 196;
            this.navBarControl1.Size = new System.Drawing.Size(196, 569);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.SkinExplorerBarViewInfoRegistrator();
            // 
            // gc_EmployeeManager
            // 
            this.gc_EmployeeManager.Caption = "Employee manager";
            this.gc_EmployeeManager.Expanded = true;
            this.gc_EmployeeManager.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_ImportEmployee),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_AssignToWorld),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_AssignEmployeeToHWGR),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_DelegateToStore),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_EmployeeWorkingHistory)

            });
            this.gc_EmployeeManager.Name = "gc_EmployeeManager";
            // 
            // bi_ImportEmployee
            // 
            this.bi_ImportEmployee.Caption = "Import employee";
            this.bi_ImportEmployee.Name = "bi_ImportEmployee";
            this.bi_ImportEmployee.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_ImportEmployee_LinkClicked);
            // 
            // bi_AssignToWorld
            // 
            this.bi_AssignToWorld.Caption = "Assign employee to world";
            this.bi_AssignToWorld.Enabled = false;
            this.bi_AssignToWorld.Name = "bi_AssignToWorld";
            this.bi_AssignToWorld.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_AssignEmployeeToWorld_LinkClicked);
            // 
            // bi_EmployeeWorkingHistory
            // 
            this.bi_EmployeeWorkingHistory.Caption = "Employee working history";
            this.bi_EmployeeWorkingHistory.Name = "bi_EmployeeWorkingHistory";
            this.bi_EmployeeWorkingHistory.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_ViewEmployeePlaceHistory_LinkClicked);
            // 
            // bi_DelegateToStore
            // 
            this.bi_DelegateToStore.Caption = "Delegate to another store";
            this.bi_DelegateToStore.Name = "bi_DelegateToStore";
            this.bi_DelegateToStore.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_DelegateToAnotherStore_LinkClicked);
            // 
            // bi_AssignEmployeeToHWGR
            // 
            this.bi_AssignEmployeeToHWGR.Caption = "Assign HWGR";
            this.bi_AssignEmployeeToHWGR.Name = "bi_AssignEmployeeToHWGR";
            this.bi_AssignEmployeeToHWGR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_AssignHWGR_LinkClicked);
            // 
            // gc_ExternalEmployeeManager
            // 
            this.gc_ExternalEmployeeManager.Caption = "External Employee ";
            this.gc_ExternalEmployeeManager.Expanded = true;
            this.gc_ExternalEmployeeManager.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_NewExternalEmployee),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_EditExternalEmployee),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_DeleteExternalEmployee),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_AssignToEmployee)});
            this.gc_ExternalEmployeeManager.Name = "gc_ExternalEmployeeManager";
            // 
            // bi_NewExternalEmployee
            // 
            this.bi_NewExternalEmployee.Caption = "Create external employee";
            this.bi_NewExternalEmployee.Name = "bi_NewExternalEmployee";
            this.bi_NewExternalEmployee.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_NewExternalEmployee_LinkClicked);
            // 
            // bi_EditExternalEmployee
            // 
            this.bi_EditExternalEmployee.Caption = "Edit external employee";
            this.bi_EditExternalEmployee.Name = "bi_EditExternalEmployee";
            this.bi_EditExternalEmployee.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_EditExternalEmployee_LinkClicked);
            // 
            // bi_DeleteExternalEmployee
            // 
            this.bi_DeleteExternalEmployee.Caption = "Delete external employee";
            this.bi_DeleteExternalEmployee.Name = "bi_DeleteExternalEmployee";
            this.bi_DeleteExternalEmployee.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_DeleteExternalEmployee_LinkClicked);
            // 
            // bi_AssignToEmployee
            // 
            this.bi_AssignToEmployee.Caption = "Assign external employee to employee data";
            this.bi_AssignToEmployee.Name = "bi_AssignToEmployee";
            this.bi_AssignToEmployee.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_AssignExtrenalEmployeeToEmployee_LinkClicked);
            // 
            // gc_EmployeeLongTimeAbsenceManager
            // 
            this.gc_EmployeeLongTimeAbsenceManager.Caption = "Employee absence manager";
            this.gc_EmployeeLongTimeAbsenceManager.Expanded = true;
            this.gc_EmployeeLongTimeAbsenceManager.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_ImportLongTimeAbsence),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_ViewEmployeesHasLongTimeAbsence),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bi_NewEmplLongTimeAbsence)});
            this.gc_EmployeeLongTimeAbsenceManager.Name = "gc_EmployeeLongTimeAbsenceManager";
            // 
            // bi_ImportLongTimeAbsence
            // 
            this.bi_ImportLongTimeAbsence.Caption = "Import Long-Time Absence";
            this.bi_ImportLongTimeAbsence.Name = "bi_ImportLongTimeAbsence";
            this.bi_ImportLongTimeAbsence.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_ImportLongTimeAbsence_LinkClicked);
            // 
            // bi_ViewEmployeesHasLongTimeAbsence
            // 
            this.bi_ViewEmployeesHasLongTimeAbsence.Caption = "View long-time absence history";
            this.bi_ViewEmployeesHasLongTimeAbsence.Name = "bi_ViewEmployeesHasLongTimeAbsence";
            this.bi_ViewEmployeesHasLongTimeAbsence.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_ViewEmployeesLongTimeAbsences_LinkClicked);
            // 
            // bi_NewEmplLongTimeAbsence
            // 
            this.bi_NewEmplLongTimeAbsence.Caption = "New employee long-time absence";
            this.bi_NewEmplLongTimeAbsence.Name = "bi_NewEmplLongTimeAbsence";
            this.bi_NewEmplLongTimeAbsence.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bi_EnterLongTimeAbsence_LinkClicked);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(200, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 573);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.ucEmployeeList1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(206, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(483, 573);
            this.panelControl2.TabIndex = 2;
            // 
            // ucEmployeeList1
            // 
            this.ucEmployeeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEmployeeList1.Entity = null;
            this.ucEmployeeList1.EntityStore = null;
            this.ucEmployeeList1.ListStores = null;
            this.ucEmployeeList1.Location = new System.Drawing.Point(2, 2);
            this.ucEmployeeList1.LookAndFeel.SkinName = "iMaginary";
            this.ucEmployeeList1.Name = "ucEmployeeList1";
            this.ucEmployeeList1.Size = new System.Drawing.Size(479, 569);
            this.ucEmployeeList1.TabIndex = 0;
            this.ucEmployeeList1.OnChangeListState += new Baumax.ClientUI.FormEntities.Employee.UCEmployeeList.ChangeEmployeeListState(this.ucEmployeeList1_OnChangeListState);
            // 
            // UCEmployeeManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCEmployeeManagerControl";
            this.Size = new System.Drawing.Size(689, 573);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup gc_EmployeeManager;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraNavBar.NavBarItem bi_ImportEmployee;
        private DevExpress.XtraNavBar.NavBarItem bi_NewEmplLongTimeAbsence;
        private DevExpress.XtraNavBar.NavBarItem bi_AssignToWorld;
        private DevExpress.XtraNavBar.NavBarItem bi_DelegateToStore;
        private DevExpress.XtraNavBar.NavBarGroup gc_ExternalEmployeeManager;
        private DevExpress.XtraNavBar.NavBarItem bi_NewExternalEmployee;
        private DevExpress.XtraNavBar.NavBarItem bi_EditExternalEmployee;
        private DevExpress.XtraNavBar.NavBarItem bi_DeleteExternalEmployee;
        private DevExpress.XtraNavBar.NavBarItem bi_AssignToEmployee;
        private Baumax.ClientUI.FormEntities.Employee.UCEmployeeList ucEmployeeList1;
        private DevExpress.XtraNavBar.NavBarItem bi_ImportLongTimeAbsence;
        private DevExpress.XtraNavBar.NavBarItem bi_ViewEmployeesHasLongTimeAbsence;
        private DevExpress.XtraNavBar.NavBarGroup gc_EmployeeLongTimeAbsenceManager;
        private DevExpress.XtraNavBar.NavBarItem bi_EmployeeWorkingHistory;
        private DevExpress.XtraNavBar.NavBarItem bi_AssignEmployeeToHWGR;
    }
}
