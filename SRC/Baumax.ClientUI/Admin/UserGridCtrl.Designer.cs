namespace Baumax.ClientUI.Admin
{
    partial class UserGridCtrl
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
            this.components = new System.ComponentModel.Container();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_newUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_editUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_deleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_GroupByRole = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_ExpandedAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_CollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_LoginName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Active = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Role = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.contextMenuUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUser)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.contextMenuUsers;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridViewUser;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(544, 352);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUser});
            this.gridControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl_MouseDoubleClick);
            // 
            // contextMenuUsers
            // 
            this.contextMenuUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_newUser,
            this.toolStripMenuItem_editUser,
            this.toolStripMenuItem_deleteUser,
            this.toolStripSeparator1,
            this.menuItem_GroupByRole,
            this.toolStripSeparator2,
            this.menuItem_ExpandedAll,
            this.menuItem_CollapseAll});
            this.contextMenuUsers.Name = "contextMenuUsers";
            this.contextMenuUsers.Size = new System.Drawing.Size(159, 148);
            this.contextMenuUsers.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuUsers_Opening);
            // 
            // toolStripMenuItem_newUser
            // 
            this.toolStripMenuItem_newUser.Name = "toolStripMenuItem_newUser";
            this.toolStripMenuItem_newUser.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem_newUser.Text = "New user";
            this.toolStripMenuItem_newUser.Click += new System.EventHandler(this.toolStripMenuItem_newUser_Click);
            // 
            // toolStripMenuItem_editUser
            // 
            this.toolStripMenuItem_editUser.Name = "toolStripMenuItem_editUser";
            this.toolStripMenuItem_editUser.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem_editUser.Text = "Edit user";
            this.toolStripMenuItem_editUser.Click += new System.EventHandler(this.toolStripMenuItem_editUser_Click);
            // 
            // toolStripMenuItem_deleteUser
            // 
            this.toolStripMenuItem_deleteUser.Name = "toolStripMenuItem_deleteUser";
            this.toolStripMenuItem_deleteUser.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem_deleteUser.Text = "Delete user";
            this.toolStripMenuItem_deleteUser.Click += new System.EventHandler(this.toolStripMenuItem_deleteUser_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // menuItem_GroupByRole
            // 
            this.menuItem_GroupByRole.Name = "menuItem_GroupByRole";
            this.menuItem_GroupByRole.Size = new System.Drawing.Size(158, 22);
            this.menuItem_GroupByRole.Text = "Group by role";
            this.menuItem_GroupByRole.Click += new System.EventHandler(this.menuItem_GroupByRole_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // menuItem_ExpandedAll
            // 
            this.menuItem_ExpandedAll.Name = "menuItem_ExpandedAll";
            this.menuItem_ExpandedAll.Size = new System.Drawing.Size(158, 22);
            this.menuItem_ExpandedAll.Text = "Expanded All";
            this.menuItem_ExpandedAll.Click += new System.EventHandler(this.menuItem_ExpandedAll_Click);
            // 
            // menuItem_CollapseAll
            // 
            this.menuItem_CollapseAll.Name = "menuItem_CollapseAll";
            this.menuItem_CollapseAll.Size = new System.Drawing.Size(158, 22);
            this.menuItem_CollapseAll.Text = "Collapse All";
            this.menuItem_CollapseAll.Click += new System.EventHandler(this.menuItem_CollapseAll_Click);
            // 
            // gridViewUser
            // 
            this.gridViewUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_LoginName,
            this.gridColumn_Active,
            this.gridColumn_Role});
            this.gridViewUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewUser.GridControl = this.gridControl;
            this.gridViewUser.GroupPanelText = " ";
            this.gridViewUser.Name = "gridViewUser";
            this.gridViewUser.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridViewUser.OptionsBehavior.Editable = false;
            this.gridViewUser.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewUser.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewUser.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewUser.OptionsFilter.AllowFilterEditor = false;
            this.gridViewUser.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewUser.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridViewUser.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridViewUser.OptionsMenu.EnableColumnMenu = false;
            this.gridViewUser.OptionsMenu.EnableFooterMenu = false;
            this.gridViewUser.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewUser.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewUser.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewUser.OptionsView.ShowAutoFilterRow = true;
            this.gridViewUser.OptionsView.ShowGroupPanel = false;
            this.gridViewUser.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewUser_FocusedRowChanged);
            // 
            // gridColumn_LoginName
            // 
            this.gridColumn_LoginName.Caption = "Login";
            this.gridColumn_LoginName.FieldName = "Login";
            this.gridColumn_LoginName.Name = "gridColumn_LoginName";
            this.gridColumn_LoginName.OptionsColumn.AllowEdit = false;
            this.gridColumn_LoginName.OptionsColumn.ReadOnly = true;
            this.gridColumn_LoginName.OptionsFilter.AllowFilter = false;
            this.gridColumn_LoginName.Visible = true;
            this.gridColumn_LoginName.VisibleIndex = 0;
            // 
            // gridColumn_Active
            // 
            this.gridColumn_Active.Caption = "Active";
            this.gridColumn_Active.FieldName = "Active";
            this.gridColumn_Active.Name = "gridColumn_Active";
            this.gridColumn_Active.OptionsColumn.AllowEdit = false;
            this.gridColumn_Active.OptionsColumn.ReadOnly = true;
            this.gridColumn_Active.OptionsFilter.AllowFilter = false;
            this.gridColumn_Active.Visible = true;
            this.gridColumn_Active.VisibleIndex = 1;
            // 
            // gridColumn_Role
            // 
            this.gridColumn_Role.Caption = "Role";
            this.gridColumn_Role.FieldName = "RoleName";
            this.gridColumn_Role.Name = "gridColumn_Role";
            this.gridColumn_Role.OptionsFilter.AllowFilter = false;
            this.gridColumn_Role.Visible = true;
            this.gridColumn_Role.VisibleIndex = 2;
            // 
            // UserGridCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UserGridCtrl";
            this.Size = new System.Drawing.Size(544, 352);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.contextMenuUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_LoginName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Active;
        private System.Windows.Forms.ContextMenuStrip contextMenuUsers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_newUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_editUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_deleteUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Role;
        private System.Windows.Forms.ToolStripMenuItem menuItem_ExpandedAll;
        private System.Windows.Forms.ToolStripMenuItem menuItem_CollapseAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_GroupByRole;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
