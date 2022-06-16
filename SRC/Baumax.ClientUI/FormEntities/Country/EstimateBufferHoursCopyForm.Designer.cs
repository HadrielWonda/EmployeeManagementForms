namespace Baumax.ClientUI.FormEntities.Country
{
    partial class EstimateBufferHoursCopyForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spin_Year = new DevExpress.XtraEditors.SpinEdit();
            this.gridControlEntity = new DevExpress.XtraGrid.GridControl();
            this.gridViewEntity = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_World = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Year = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_BufferHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.button_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Copy = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_yearappearance = new DevExpress.XtraEditors.LabelControl();
            this.gridLookUpEdit_Country = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.spin_Year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Country.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // spin_Year
            // 
            this.spin_Year.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spin_Year.Enabled = false;
            this.spin_Year.Location = new System.Drawing.Point(236, 226);
            this.spin_Year.Name = "spin_Year";
            this.spin_Year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spin_Year.Size = new System.Drawing.Size(77, 20);
            this.spin_Year.TabIndex = 0;
            // 
            // gridControlEntity
            // 
            this.gridControlEntity.EmbeddedNavigator.Name = "";
            this.gridControlEntity.Location = new System.Drawing.Point(-3, 12);
            this.gridControlEntity.MainView = this.gridViewEntity;
            this.gridControlEntity.Name = "gridControlEntity";
            this.gridControlEntity.Size = new System.Drawing.Size(579, 189);
            this.gridControlEntity.TabIndex = 1;
            this.gridControlEntity.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEntity,
            this.gridView2});
            // 
            // gridViewEntity
            // 
            this.gridViewEntity.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_World,
            this.gc_Year,
            this.gridColumn_BufferHours});
            this.gridViewEntity.GridControl = this.gridControlEntity;
            this.gridViewEntity.Name = "gridViewEntity";
            this.gridViewEntity.OptionsView.ShowGroupPanel = false;
            this.gridViewEntity.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gc_Year, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gc_World
            // 
            this.gc_World.Caption = "World";
            this.gc_World.FieldName = "WorldName";
            this.gc_World.Name = "gc_World";
            this.gc_World.OptionsColumn.AllowEdit = false;
            this.gc_World.OptionsColumn.AllowMove = false;
            this.gc_World.OptionsColumn.ReadOnly = true;
            this.gc_World.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_World.Visible = true;
            this.gc_World.VisibleIndex = 0;
            // 
            // gc_Year
            // 
            this.gc_Year.Caption = "Year";
            this.gc_Year.FieldName = "Year";
            this.gc_Year.Name = "gc_Year";
            this.gc_Year.OptionsColumn.AllowEdit = false;
            this.gc_Year.OptionsColumn.AllowMove = false;
            this.gc_Year.OptionsColumn.ReadOnly = true;
            this.gc_Year.OptionsColumn.ShowInCustomizationForm = false;
            this.gc_Year.Visible = true;
            this.gc_Year.VisibleIndex = 1;
            // 
            // gridColumn_BufferHours
            // 
            this.gridColumn_BufferHours.Caption = "Buffer Hours";
            this.gridColumn_BufferHours.FieldName = "Value";
            this.gridColumn_BufferHours.Name = "gridColumn_BufferHours";
            this.gridColumn_BufferHours.OptionsColumn.AllowEdit = false;
            this.gridColumn_BufferHours.OptionsColumn.AllowMove = false;
            this.gridColumn_BufferHours.OptionsColumn.ReadOnly = true;
            this.gridColumn_BufferHours.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_BufferHours.Visible = true;
            this.gridColumn_BufferHours.VisibleIndex = 2;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControlEntity;
            this.gridView2.Name = "gridView2";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(457, 207);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(104, 51);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "Cancel";
            // 
            // Btn_Copy
            // 
            this.Btn_Copy.Image = global::Baumax.ClientUI.Properties.Resources.paste;
            this.Btn_Copy.Location = new System.Drawing.Point(12, 207);
            this.Btn_Copy.Name = "Btn_Copy";
            this.Btn_Copy.Size = new System.Drawing.Size(208, 51);
            this.Btn_Copy.TabIndex = 3;
            this.Btn_Copy.Text = "Copy Buffer Hours to";
            // 
            // lbl_yearappearance
            // 
            this.lbl_yearappearance.Location = new System.Drawing.Point(328, 229);
            this.lbl_yearappearance.Name = "lbl_yearappearance";
            this.lbl_yearappearance.Size = new System.Drawing.Size(22, 13);
            this.lbl_yearappearance.TabIndex = 4;
            this.lbl_yearappearance.Text = "year";
            // 
            // gridLookUpEdit_Country
            // 
            this.gridLookUpEdit_Country.Location = new System.Drawing.Point(-3, -1);
            this.gridLookUpEdit_Country.Name = "gridLookUpEdit_Country";
            this.gridLookUpEdit_Country.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit_Country.Properties.View = this.gridLookUpEdit1View;
            this.gridLookUpEdit_Country.Size = new System.Drawing.Size(579, 20);
            this.gridLookUpEdit_Country.TabIndex = 5;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // EstimateBufferHoursCopyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 270);
            this.Controls.Add(this.gridLookUpEdit_Country);
            this.Controls.Add(this.lbl_yearappearance);
            this.Controls.Add(this.Btn_Copy);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.gridControlEntity);
            this.Controls.Add(this.spin_Year);
            this.Name = "EstimateBufferHoursCopyForm";
            this.Text = "EstimateBufferHoursCopyForm";
            ((System.ComponentModel.ISupportInitialize)(this.spin_Year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit_Country.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit spin_Year;
        private DevExpress.XtraGrid.GridControl gridControlEntity;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEntity;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton button_Cancel;
        private DevExpress.XtraEditors.SimpleButton Btn_Copy;
        private DevExpress.XtraEditors.LabelControl lbl_yearappearance;
        private DevExpress.XtraGrid.Columns.GridColumn gc_World;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Year;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_BufferHours;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit_Country;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
    }
}