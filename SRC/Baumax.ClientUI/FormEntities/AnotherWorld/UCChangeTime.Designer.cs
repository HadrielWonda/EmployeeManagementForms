namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCChangeTime
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
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.timeRange = new Baumax.ClientUI.FormEntities.AnotherWorld.UCTimeRange();
            this.edParent = new DevExpress.XtraEditors.LookUpEdit();
            this.btnShowHistory = new DevExpress.XtraEditors.ButtonEdit();
            this.popupControl = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.ucDropHwgrHistory = new Baumax.ClientUI.FormEntities.AnotherWorld.UCDropHwgrHistory();
            this.lb_ShowHistory = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edParent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowHistory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControl)).BeginInit();
            this.popupControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // timeRange
            // 
            this.timeRange.BeginTime = new System.DateTime(((long)(0)));
            this.timeRange.EndTime = new System.DateTime(((long)(0)));
            this.timeRange.Location = new System.Drawing.Point(12, 92);
            this.timeRange.Name = "timeRange";
            this.timeRange.Size = new System.Drawing.Size(249, 83);
            this.timeRange.TabIndex = 0;
            this.timeRange.Load += new System.EventHandler(this.timeRange_Load);
            // 
            // edParent
            // 
            this.edParent.Enabled = false;
            this.edParent.Location = new System.Drawing.Point(12, 54);
            this.edParent.Name = "edParent";
            this.edParent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edParent.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemName", "ItemName", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edParent.Properties.DisplayMember = "ItemName";
            this.edParent.Properties.NullText = "";
            this.edParent.Size = new System.Drawing.Size(239, 20);
            this.edParent.TabIndex = 1;
            // 
            // btnShowHistory
            // 
            this.btnShowHistory.Location = new System.Drawing.Point(57, 5);
            this.btnShowHistory.Name = "btnShowHistory";
            this.btnShowHistory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right)});
            this.btnShowHistory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnShowHistory.Properties.Click += new System.EventHandler(this.buttonEdit1_Properties_Click);
            this.btnShowHistory.Size = new System.Drawing.Size(23, 20);
            this.btnShowHistory.TabIndex = 13;
            this.btnShowHistory.EditValueChanged += new System.EventHandler(this.btnShowHistory_EditValueChanged);
            // 
            // popupControl
            // 
            this.popupControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControl.Controls.Add(this.ucDropHwgrHistory);
            this.popupControl.Location = new System.Drawing.Point(74, 5);
            this.popupControl.Name = "popupControl";
            this.popupControl.Size = new System.Drawing.Size(181, 140);
            this.popupControl.TabIndex = 12;
            this.popupControl.Visible = false;
            // 
            // ucDropHwgrHistory
            // 
            this.ucDropHwgrHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDropHwgrHistory.Entity = null;
            this.ucDropHwgrHistory.Location = new System.Drawing.Point(0, 0);
            this.ucDropHwgrHistory.LookAndFeel.SkinName = "iMaginary";
            this.ucDropHwgrHistory.Name = "ucDropHwgrHistory";
            this.ucDropHwgrHistory.Size = new System.Drawing.Size(181, 140);
            this.ucDropHwgrHistory.TabIndex = 0;
            // 
            // lb_ShowHistory
            // 
            this.lb_ShowHistory.Location = new System.Drawing.Point(3, 8);
            this.lb_ShowHistory.Name = "lb_ShowHistory";
            this.lb_ShowHistory.Size = new System.Drawing.Size(62, 13);
            this.lb_ShowHistory.TabIndex = 14;
            this.lb_ShowHistory.Text = "Show history";
            // 
            // UCChangeTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_ShowHistory);
            this.Controls.Add(this.btnShowHistory);
            this.Controls.Add(this.popupControl);
            this.Controls.Add(this.edParent);
            this.Controls.Add(this.timeRange);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCChangeTime";
            this.Size = new System.Drawing.Size(268, 166);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edParent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowHistory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControl)).EndInit();
            this.popupControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private UCTimeRange timeRange;
        private DevExpress.XtraEditors.LookUpEdit edParent;
        private DevExpress.XtraEditors.LabelControl lb_ShowHistory;
        private DevExpress.XtraEditors.ButtonEdit btnShowHistory;
        private DevExpress.XtraBars.PopupControlContainer popupControl;
        private UCDropHwgrHistory ucDropHwgrHistory;
    }
}
