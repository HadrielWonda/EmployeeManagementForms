namespace Baumax.ClientUI.FormEntities.Controls
{
    partial class UCWeekSelector
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
            this.edYear = new DevExpress.XtraEditors.SpinEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_Week = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Month = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Monday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Sunday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Current = new DevExpress.XtraEditors.SimpleButton();
            this.lb_Year = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.edYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // edYear
            // 
            this.edYear.EditValue = new decimal(new int[] {
            1901,
            0,
            0,
            0});
            this.edYear.Location = new System.Drawing.Point(53, 8);
            this.edYear.Name = "edYear";
            this.edYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edYear.Properties.Mask.EditMask = "f0";
            this.edYear.Properties.MaxValue = new decimal(new int[] {
            2079,
            0,
            0,
            0});
            this.edYear.Properties.MinValue = new decimal(new int[] {
            1901,
            0,
            0,
            0});
            this.edYear.Size = new System.Drawing.Size(55, 20);
            this.edYear.TabIndex = 4;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 34);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(249, 371);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.ActiveFilterEnabled = false;
            this.gridView.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 1F);
            this.gridView.Appearance.GroupButton.Options.UseFont = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_Week,
            this.gc_Month,
            this.gc_Monday,
            this.gc_Sunday});
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupCount = 1;
            this.gridView.GroupFormat = "{1}";
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Standard;
            this.gridView.OptionsView.ShowDetailButtons = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowHorzLines = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.OptionsView.ShowVertLines = false;
            this.gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gc_Month, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            this.gridView.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.gridView_CustomColumnSort);
            // 
            // gc_Week
            // 
            this.gc_Week.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gc_Week.AppearanceCell.Options.UseFont = true;
            this.gc_Week.AppearanceCell.Options.UseTextOptions = true;
            this.gc_Week.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gc_Week.Caption = "Week";
            this.gc_Week.FieldName = "Number";
            this.gc_Week.Name = "gc_Week";
            this.gc_Week.OptionsColumn.AllowEdit = false;
            this.gc_Week.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Week.OptionsColumn.AllowMove = false;
            this.gc_Week.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Week.OptionsColumn.ReadOnly = true;
            this.gc_Week.OptionsFilter.AllowAutoFilter = false;
            this.gc_Week.OptionsFilter.AllowFilter = false;
            this.gc_Week.Visible = true;
            this.gc_Week.VisibleIndex = 0;
            // 
            // gc_Month
            // 
            this.gc_Month.Caption = "Month";
            this.gc_Month.FieldName = "Month";
            this.gc_Month.Name = "gc_Month";
            this.gc_Month.OptionsColumn.AllowEdit = false;
            this.gc_Month.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gc_Month.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.gc_Month.Visible = true;
            this.gc_Month.VisibleIndex = 1;
            // 
            // gc_Monday
            // 
            this.gc_Monday.AppearanceCell.ForeColor = System.Drawing.Color.Gray;
            this.gc_Monday.AppearanceCell.Options.UseForeColor = true;
            this.gc_Monday.AppearanceCell.Options.UseTextOptions = true;
            this.gc_Monday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gc_Monday.Caption = "Monday";
            this.gc_Monday.DisplayFormat.FormatString = "dd.MM.yy";
            this.gc_Monday.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gc_Monday.FieldName = "Monday";
            this.gc_Monday.Name = "gc_Monday";
            this.gc_Monday.OptionsColumn.AllowEdit = false;
            this.gc_Monday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Monday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Monday.OptionsFilter.AllowFilter = false;
            this.gc_Monday.Visible = true;
            this.gc_Monday.VisibleIndex = 1;
            // 
            // gc_Sunday
            // 
            this.gc_Sunday.AppearanceCell.ForeColor = System.Drawing.Color.Gray;
            this.gc_Sunday.AppearanceCell.Options.UseForeColor = true;
            this.gc_Sunday.AppearanceCell.Options.UseTextOptions = true;
            this.gc_Sunday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gc_Sunday.Caption = "Sunday";
            this.gc_Sunday.DisplayFormat.FormatString = "dd.MM.yy";
            this.gc_Sunday.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gc_Sunday.FieldName = "Sunday";
            this.gc_Sunday.Name = "gc_Sunday";
            this.gc_Sunday.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gc_Sunday.OptionsFilter.AllowAutoFilter = false;
            this.gc_Sunday.OptionsFilter.AllowFilter = false;
            this.gc_Sunday.Visible = true;
            this.gc_Sunday.VisibleIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btn_Current);
            this.panelControl1.Controls.Add(this.lb_Year);
            this.panelControl1.Controls.Add(this.edYear);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(249, 34);
            this.panelControl1.TabIndex = 5;
            // 
            // btn_Current
            // 
            this.btn_Current.Location = new System.Drawing.Point(127, 8);
            this.btn_Current.Name = "btn_Current";
            this.btn_Current.Size = new System.Drawing.Size(87, 20);
            this.btn_Current.TabIndex = 6;
            this.btn_Current.Text = "Current";
            this.btn_Current.Click += new System.EventHandler(this.btn_Current_Click);
            // 
            // lb_Year
            // 
            this.lb_Year.Location = new System.Drawing.Point(12, 11);
            this.lb_Year.Name = "lb_Year";
            this.lb_Year.Size = new System.Drawing.Size(22, 13);
            this.lb_Year.TabIndex = 5;
            this.lb_Year.Text = "Year";
            // 
            // UCWeekSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCWeekSelector";
            this.Size = new System.Drawing.Size(249, 405);
            ((System.ComponentModel.ISupportInitialize)(this.edYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit edYear;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Month;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Week;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Monday;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Sunday;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lb_Year;
        private DevExpress.XtraEditors.SimpleButton btn_Current;
    }
}
