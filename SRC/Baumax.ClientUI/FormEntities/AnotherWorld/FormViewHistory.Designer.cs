namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class FormViewHistory
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
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_Parent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_BeginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_EndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblText = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTop.Controls.Add(this.lblText);
            this.panelTop.Size = new System.Drawing.Size(313, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Size = new System.Drawing.Size(313, 218);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(9, 8);
            this.button_OK.Visible = false;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-1342, 8);
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBottom.Location = new System.Drawing.Point(0, 252);
            this.panelBottom.Size = new System.Drawing.Size(313, 40);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Name = "";
            this.gridControl.Location = new System.Drawing.Point(0, 34);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(313, 218);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_Parent,
            this.gc_BeginDate,
            this.gc_EndDate});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gc_BeginDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_CustomUnboundColumnData);
            // 
            // gc_Parent
            // 
            this.gc_Parent.Caption = "Parent";
            this.gc_Parent.FieldName = "gc_Parent";
            this.gc_Parent.Name = "gc_Parent";
            this.gc_Parent.OptionsFilter.AllowAutoFilter = false;
            this.gc_Parent.OptionsFilter.AllowFilter = false;
            this.gc_Parent.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gc_Parent.Visible = true;
            this.gc_Parent.VisibleIndex = 0;
            // 
            // gc_BeginDate
            // 
            this.gc_BeginDate.Caption = "Begin date";
            this.gc_BeginDate.DisplayFormat.FormatString = "d";
            this.gc_BeginDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gc_BeginDate.FieldName = "BeginTime";
            this.gc_BeginDate.Name = "gc_BeginDate";
            this.gc_BeginDate.OptionsFilter.AllowAutoFilter = false;
            this.gc_BeginDate.OptionsFilter.AllowFilter = false;
            this.gc_BeginDate.Visible = true;
            this.gc_BeginDate.VisibleIndex = 1;
            // 
            // gc_EndDate
            // 
            this.gc_EndDate.Caption = "End date";
            this.gc_EndDate.DisplayFormat.FormatString = "d";
            this.gc_EndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gc_EndDate.FieldName = "EndTime";
            this.gc_EndDate.Name = "gc_EndDate";
            this.gc_EndDate.OptionsFilter.AllowAutoFilter = false;
            this.gc_EndDate.OptionsFilter.AllowFilter = false;
            this.gc_EndDate.Visible = true;
            this.gc_EndDate.VisibleIndex = 2;
            // 
            // lblText
            // 
            this.lblText.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblText.Appearance.Options.UseFont = true;
            this.lblText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblText.Size = new System.Drawing.Size(313, 13);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "labelControl1";
            // 
            // FormViewHistory
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 292);
            this.Controls.Add(this.gridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormViewHistory";
            this.ShowIcon = false;
            this.Text = " ";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.FormViewHistory_Activated);
            this.Controls.SetChildIndex(this.panelTop, 0);
            this.Controls.SetChildIndex(this.panelBottom, 0);
            this.Controls.SetChildIndex(this.panelClient, 0);
            this.Controls.SetChildIndex(this.gridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Parent;
        private DevExpress.XtraGrid.Columns.GridColumn gc_BeginDate;
        private DevExpress.XtraGrid.Columns.GridColumn gc_EndDate;
        private DevExpress.XtraEditors.LabelControl lblText;
    }
}