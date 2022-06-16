namespace Baumax.ClientUI.Admin
{
    partial class EmployeeListCtrl
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
            this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.ctrlNavBar = new DevExpress.XtraNavBar.NavBarControl();
            this.grpNED = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbNew = new DevExpress.XtraNavBar.NavBarItem();
            this.nbEdit = new DevExpress.XtraNavBar.NavBarItem();
            this.nbDelete = new DevExpress.XtraNavBar.NavBarItem();
            this.ctrlEmployeeGrid = new Baumax.ClientUI.Admin.EmployeeGridCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNavBar)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1.Controls.Add(this.ctrlNavBar);
            this.splitContainer.Panel1.Text = "Panel1";
            this.splitContainer.Panel2.Controls.Add(this.ctrlEmployeeGrid);
            this.splitContainer.Panel2.Text = "Panel2";
            this.splitContainer.Size = new System.Drawing.Size(638, 462);
            this.splitContainer.SplitterPosition = 148;
            this.splitContainer.TabIndex = 1;
            this.splitContainer.Text = "splitContainerControl1";
            // 
            // ctrlNavBar
            // 
            this.ctrlNavBar.ActiveGroup = this.grpNED;
            this.ctrlNavBar.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.grpNED});
            this.ctrlNavBar.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbNew,
            this.nbEdit,
            this.nbDelete});
            this.ctrlNavBar.Location = new System.Drawing.Point(1, 1);
            this.ctrlNavBar.Name = "ctrlNavBar";
            this.ctrlNavBar.Size = new System.Drawing.Size(140, 300);
            this.ctrlNavBar.TabIndex = 0;
            this.ctrlNavBar.Text = "navBarControl1";
            // 
            // grpNED
            // 
            this.grpNED.Caption = "";
            this.grpNED.Expanded = true;
            this.grpNED.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbNew),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbEdit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbDelete)});
            this.grpNED.Name = "grpNED";
            // 
            // nbNew
            // 
            this.nbNew.Caption = "New";
            this.nbNew.Name = "nbNew";
            this.nbNew.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbNew_LinkClicked);
            // 
            // nbEdit
            // 
            this.nbEdit.Caption = "Edit";
            this.nbEdit.Name = "nbEdit";
            this.nbEdit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbEdit_LinkClicked);
            // 
            // nbDelete
            // 
            this.nbDelete.Caption = "Delete";
            this.nbDelete.Name = "nbDelete";
            this.nbDelete.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbDelete_LinkClicked);
            // 
            // ctrlEmployeeGrid
            // 
            this.ctrlEmployeeGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlEmployeeGrid.EmployeeList = null;
            this.ctrlEmployeeGrid.Entity = null;
            this.ctrlEmployeeGrid.Location = new System.Drawing.Point(0, 0);
            this.ctrlEmployeeGrid.Name = "ctrlEmployeeGrid";
            this.ctrlEmployeeGrid.Size = new System.Drawing.Size(480, 458);
            this.ctrlEmployeeGrid.TabIndex = 0;
            // 
            // EmployeeListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "EmployeeListCtrl";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNavBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainer;
        protected DevExpress.XtraNavBar.NavBarControl ctrlNavBar;
        private DevExpress.XtraNavBar.NavBarGroup grpNED;
        private DevExpress.XtraNavBar.NavBarItem nbNew;
        private DevExpress.XtraNavBar.NavBarItem nbEdit;
        private DevExpress.XtraNavBar.NavBarItem nbDelete;
        private EmployeeGridCtrl ctrlEmployeeGrid;
    }
}
