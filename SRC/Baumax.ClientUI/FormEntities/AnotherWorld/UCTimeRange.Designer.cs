namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    partial class UCTimeRange
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
            this.lbl_BeginTime = new DevExpress.XtraEditors.LabelControl();
            this.edBeginTime = new DevExpress.XtraEditors.DateEdit();
            this.lbl_EndTime = new DevExpress.XtraEditors.LabelControl();
            this.edEndTime = new DevExpress.XtraEditors.DateEdit();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edBeginTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBeginTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edEndTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_BeginTime
            // 
            this.lbl_BeginTime.Location = new System.Drawing.Point(3, 5);
            this.lbl_BeginTime.Name = "lbl_BeginTime";
            this.lbl_BeginTime.Size = new System.Drawing.Size(49, 13);
            this.lbl_BeginTime.TabIndex = 0;
            this.lbl_BeginTime.Text = "Begin time";
            // 
            // edBeginTime
            // 
            this.edBeginTime.EditValue = null;
            this.edBeginTime.Location = new System.Drawing.Point(3, 24);
            this.edBeginTime.Name = "edBeginTime";
            this.edBeginTime.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.edBeginTime.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.edBeginTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edBeginTime.Properties.ReadOnly = true;
            this.edBeginTime.Properties.ShowWeekNumbers = true;
            this.edBeginTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edBeginTime.Properties.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstDay;
            this.edBeginTime.Size = new System.Drawing.Size(116, 20);
            this.edBeginTime.TabIndex = 2;
            this.edBeginTime.EditValueChanged += new System.EventHandler(this.edBeginTime_EditValueChanged);
            // 
            // lbl_EndTime
            // 
            this.lbl_EndTime.Location = new System.Drawing.Point(125, 5);
            this.lbl_EndTime.Name = "lbl_EndTime";
            this.lbl_EndTime.Size = new System.Drawing.Size(41, 13);
            this.lbl_EndTime.TabIndex = 2;
            this.lbl_EndTime.Text = "End time";
            // 
            // edEndTime
            // 
            this.edEndTime.EditValue = null;
            this.edEndTime.Location = new System.Drawing.Point(125, 24);
            this.edEndTime.Name = "edEndTime";
            this.edEndTime.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.edEndTime.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.edEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edEndTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edEndTime.Properties.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstDay;
            this.edEndTime.Size = new System.Drawing.Size(116, 20);
            this.edEndTime.TabIndex = 3;
            this.edEndTime.EditValueChanged += new System.EventHandler(this.edEndTime_EditValueChanged);
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // UCTimeRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edEndTime);
            this.Controls.Add(this.lbl_EndTime);
            this.Controls.Add(this.edBeginTime);
            this.Controls.Add(this.lbl_BeginTime);
            this.Name = "UCTimeRange";
            this.Size = new System.Drawing.Size(245, 49);
            ((System.ComponentModel.ISupportInitialize)(this.edBeginTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edBeginTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edEndTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_BeginTime;
        private DevExpress.XtraEditors.DateEdit edBeginTime;
        private DevExpress.XtraEditors.LabelControl lbl_EndTime;
        private DevExpress.XtraEditors.DateEdit edEndTime;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}
