namespace Baumax.ClientUI.FormEntities
{
    partial class UCLongTimeAbsenceEmployees
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gc_EndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_BeginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlEntities = new DevExpress.XtraGrid.GridControl();
            this.gridViewEntities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_Employee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_LongTimeAbsence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bi_View = new DevExpress.XtraBars.BarSubItem();
            this.bi_ViewEmployeeHasLongAbsenceToday = new DevExpress.XtraBars.BarButtonItem();
            this.bi_ViewAllEmplHadLongAbsence = new DevExpress.XtraBars.BarButtonItem();
            this.bi_NewEmplLongTimeAbsence = new DevExpress.XtraBars.BarButtonItem();
            this.bi_EditEmplLongTimeAbsence = new DevExpress.XtraBars.BarButtonItem();
            this.bi_DeleteEmplLongTimeAbsence = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_EndDate
            // 
            this.gc_EndDate.Caption = "End";
            this.gc_EndDate.FieldName = "EndTime";
            this.gc_EndDate.Name = "gc_EndDate";
            this.gc_EndDate.OptionsColumn.AllowEdit = false;
            this.gc_EndDate.OptionsColumn.ReadOnly = true;
            this.gc_EndDate.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_EndDate.OptionsFilter.AllowFilter = false;
            this.gc_EndDate.Visible = true;
            this.gc_EndDate.VisibleIndex = 3;
            // 
            // gc_BeginDate
            // 
            this.gc_BeginDate.Caption = "Begin";
            this.gc_BeginDate.FieldName = "BeginTime";
            this.gc_BeginDate.Name = "gc_BeginDate";
            this.gc_BeginDate.OptionsColumn.AllowEdit = false;
            this.gc_BeginDate.OptionsColumn.ReadOnly = true;
            this.gc_BeginDate.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_BeginDate.OptionsFilter.AllowFilter = false;
            this.gc_BeginDate.Visible = true;
            this.gc_BeginDate.VisibleIndex = 2;
            // 
            // gridControlEntities
            // 
            this.gridControlEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlEntities.EmbeddedNavigator.Name = "";
            this.gridControlEntities.Location = new System.Drawing.Point(0, 24);
            this.gridControlEntities.MainView = this.gridViewEntities;
            this.gridControlEntities.Name = "gridControlEntities";
            this.gridControlEntities.Size = new System.Drawing.Size(532, 446);
            this.gridControlEntities.TabIndex = 1;
            this.gridControlEntities.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEntities,
            this.gridView2});
            this.gridControlEntities.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControlEntities_MouseDoubleClick);
            // 
            // gridViewEntities
            // 
            this.gridViewEntities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_Employee,
            this.gc_LongTimeAbsence,
            this.gc_BeginDate,
            this.gc_EndDate});
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Column = this.gc_EndDate;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition3.Value1 = new System.DateTime(2007, 8, 3, 0, 0, 0, 0);
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.LightCyan;
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.ApplyToRow = true;
            styleFormatCondition4.Column = this.gc_BeginDate;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Greater;
            styleFormatCondition4.Value1 = new System.DateTime(2007, 8, 3, 0, 0, 0, 0);
            this.gridViewEntities.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition3,
            styleFormatCondition4});
            this.gridViewEntities.GridControl = this.gridControlEntities;
            this.gridViewEntities.Name = "gridViewEntities";
            this.gridViewEntities.OptionsMenu.EnableColumnMenu = false;
            this.gridViewEntities.OptionsMenu.EnableFooterMenu = false;
            this.gridViewEntities.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewEntities.OptionsView.ShowGroupPanel = false;
            this.gridViewEntities.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewEntities_FocusedRowChanged);
            this.gridViewEntities.RowCountChanged += new System.EventHandler(this.gridViewEntities_RowCountChanged);
            this.gridViewEntities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewEntities_KeyDown);
            // 
            // gc_Employee
            // 
            this.gc_Employee.Caption = "Employee ";
            this.gc_Employee.FieldName = "EmployeeFullName";
            this.gc_Employee.Name = "gc_Employee";
            this.gc_Employee.OptionsColumn.AllowEdit = false;
            this.gc_Employee.OptionsColumn.ReadOnly = true;
            this.gc_Employee.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Employee.OptionsFilter.AllowFilter = false;
            this.gc_Employee.Visible = true;
            this.gc_Employee.VisibleIndex = 0;
            // 
            // gc_LongTimeAbsence
            // 
            this.gc_LongTimeAbsence.Caption = "Long-time absence";
            this.gc_LongTimeAbsence.FieldName = "LongTimeAbsenceName";
            this.gc_LongTimeAbsence.Name = "gc_LongTimeAbsence";
            this.gc_LongTimeAbsence.OptionsColumn.AllowEdit = false;
            this.gc_LongTimeAbsence.OptionsColumn.ReadOnly = true;
            this.gc_LongTimeAbsence.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_LongTimeAbsence.OptionsFilter.AllowFilter = false;
            this.gc_LongTimeAbsence.Visible = true;
            this.gc_LongTimeAbsence.VisibleIndex = 1;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControlEntities;
            this.gridView2.Name = "gridView2";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bi_EditEmplLongTimeAbsence,
            this.bi_NewEmplLongTimeAbsence,
            this.bi_DeleteEmplLongTimeAbsence,
            this.bi_View,
            this.bi_ViewEmployeeHasLongAbsenceToday,
            this.bi_ViewAllEmplHadLongAbsence});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 3";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_View),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_NewEmplLongTimeAbsence, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_EditEmplLongTimeAbsence),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_DeleteEmplLongTimeAbsence)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DisableClose = true;
            this.bar2.OptionsBar.DisableCustomization = true;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Custom 3";
            // 
            // bi_View
            // 
            this.bi_View.Caption = "View";
            this.bi_View.Id = 5;
            this.bi_View.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_ViewEmployeeHasLongAbsenceToday),
            new DevExpress.XtraBars.LinkPersistInfo(this.bi_ViewAllEmplHadLongAbsence)});
            this.bi_View.Name = "bi_View";
            // 
            // bi_ViewEmployeeHasLongAbsenceToday
            // 
            this.bi_ViewEmployeeHasLongAbsenceToday.Caption = "View today";
            this.bi_ViewEmployeeHasLongAbsenceToday.Id = 6;
            this.bi_ViewEmployeeHasLongAbsenceToday.Name = "bi_ViewEmployeeHasLongAbsenceToday";
            this.bi_ViewEmployeeHasLongAbsenceToday.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_ViewToday_ItemClick);
            // 
            // bi_ViewAllEmplHadLongAbsence
            // 
            this.bi_ViewAllEmplHadLongAbsence.Caption = "View all";
            this.bi_ViewAllEmplHadLongAbsence.Id = 7;
            this.bi_ViewAllEmplHadLongAbsence.Name = "bi_ViewAllEmplHadLongAbsence";
            this.bi_ViewAllEmplHadLongAbsence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_ViewAll_ItemClick);
            // 
            // bi_NewEmplLongTimeAbsence
            // 
            this.bi_NewEmplLongTimeAbsence.Caption = "New";
            this.bi_NewEmplLongTimeAbsence.Id = 3;
            this.bi_NewEmplLongTimeAbsence.Name = "bi_NewEmplLongTimeAbsence";
            this.bi_NewEmplLongTimeAbsence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_NewLongTimeAbsence_ItemClick);
            // 
            // bi_EditEmplLongTimeAbsence
            // 
            this.bi_EditEmplLongTimeAbsence.Caption = "Edit";
            this.bi_EditEmplLongTimeAbsence.Id = 2;
            this.bi_EditEmplLongTimeAbsence.Name = "bi_EditEmplLongTimeAbsence";
            this.bi_EditEmplLongTimeAbsence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_EditLongTimeAbsence_ItemClick);
            // 
            // bi_DeleteEmplLongTimeAbsence
            // 
            this.bi_DeleteEmplLongTimeAbsence.Caption = "Delete";
            this.bi_DeleteEmplLongTimeAbsence.Id = 4;
            this.bi_DeleteEmplLongTimeAbsence.Name = "bi_DeleteEmplLongTimeAbsence";
            this.bi_DeleteEmplLongTimeAbsence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bi_DeleteLongTimeAbsence_ItemClick);
            // 
            // UCLongTimeAbsenceEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlEntities);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCLongTimeAbsenceEmployees";
            this.Size = new System.Drawing.Size(532, 470);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlEntities;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEntities;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Employee;
        private DevExpress.XtraGrid.Columns.GridColumn gc_LongTimeAbsence;
        private DevExpress.XtraGrid.Columns.GridColumn gc_BeginDate;
        private DevExpress.XtraGrid.Columns.GridColumn gc_EndDate;
        private DevExpress.XtraBars.BarButtonItem bi_EditEmplLongTimeAbsence;
        private DevExpress.XtraBars.BarButtonItem bi_NewEmplLongTimeAbsence;
        private DevExpress.XtraBars.BarButtonItem bi_DeleteEmplLongTimeAbsence;
        private DevExpress.XtraBars.BarSubItem bi_View;
        private DevExpress.XtraBars.BarButtonItem bi_ViewEmployeeHasLongAbsenceToday;
        private DevExpress.XtraBars.BarButtonItem bi_ViewAllEmplHadLongAbsence;
    }
}
