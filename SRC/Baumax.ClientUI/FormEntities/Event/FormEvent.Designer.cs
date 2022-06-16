namespace Baumax.ClientUI.FormEntities.Event
{
    partial class FormEvent
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
            this.groupControlMain = new DevExpress.XtraEditors.GroupControl();
            this.spinEditValue = new DevExpress.XtraEditors.SpinEdit();
            this.labelValue = new DevExpress.XtraEditors.LabelControl();
            this.labelWorkingModel = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditWorkingModel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            this.labelName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).BeginInit();
            this.groupControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditWorkingModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(428, 0);
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.groupControlMain);
            this.panelClient.Location = new System.Drawing.Point(0, 0);
            this.panelClient.Size = new System.Drawing.Size(428, 173);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(119, 5);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-166, 5);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 173);
            this.panelBottom.Size = new System.Drawing.Size(428, 34);
            // 
            // groupControlMain
            // 
            this.groupControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlMain.Controls.Add(this.spinEditValue);
            this.groupControlMain.Controls.Add(this.labelValue);
            this.groupControlMain.Controls.Add(this.labelWorkingModel);
            this.groupControlMain.Controls.Add(this.comboBoxEditWorkingModel);
            this.groupControlMain.Controls.Add(this.textEditName);
            this.groupControlMain.Controls.Add(this.labelName);
            this.groupControlMain.Location = new System.Drawing.Point(5, 6);
            this.groupControlMain.Name = "groupControlMain";
            this.groupControlMain.Size = new System.Drawing.Size(418, 162);
            this.groupControlMain.TabIndex = 2;
            this.groupControlMain.Text = "Event";
            // 
            // spinEditValue
            // 
            this.spinEditValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditValue.Location = new System.Drawing.Point(5, 132);
            this.spinEditValue.Name = "spinEditValue";
            this.spinEditValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditValue.Properties.IsFloatValue = false;
            this.spinEditValue.Properties.Mask.EditMask = "N00";
            this.spinEditValue.Size = new System.Drawing.Size(91, 20);
            this.spinEditValue.TabIndex = 19;
            // 
            // labelValue
            // 
            this.labelValue.Location = new System.Drawing.Point(5, 113);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(26, 13);
            this.labelValue.TabIndex = 18;
            this.labelValue.Text = "Value";
            // 
            // labelWorkingModel
            // 
            this.labelWorkingModel.Location = new System.Drawing.Point(5, 68);
            this.labelWorkingModel.Name = "labelWorkingModel";
            this.labelWorkingModel.Size = new System.Drawing.Size(67, 13);
            this.labelWorkingModel.TabIndex = 16;
            this.labelWorkingModel.Text = "WorkingModel";
            // 
            // comboBoxEditWorkingModel
            // 
            this.comboBoxEditWorkingModel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEditWorkingModel.Location = new System.Drawing.Point(5, 87);
            this.comboBoxEditWorkingModel.Name = "comboBoxEditWorkingModel";
            this.comboBoxEditWorkingModel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditWorkingModel.Size = new System.Drawing.Size(406, 20);
            this.comboBoxEditWorkingModel.TabIndex = 15;
            // 
            // textEditName
            // 
            this.textEditName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditName.Location = new System.Drawing.Point(5, 42);
            this.textEditName.Name = "textEditName";
            this.textEditName.Properties.MaxLength = 100;
            this.textEditName.Size = new System.Drawing.Size(406, 20);
            this.textEditName.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(5, 23);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(27, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // FormEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 207);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormEvent";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).EndInit();
            this.groupControlMain.ResumeLayout(false);
            this.groupControlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditWorkingModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlMain;
        private DevExpress.XtraEditors.LabelControl labelWorkingModel;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditWorkingModel;
        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraEditors.LabelControl labelName;
        private DevExpress.XtraEditors.SpinEdit spinEditValue;
        private DevExpress.XtraEditors.LabelControl labelValue;

    }
}