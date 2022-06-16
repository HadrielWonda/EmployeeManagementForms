namespace Baumax.ClientUI.FormEntities.Country
{
    partial class AbsenceForm
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
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            this.lbl_AbsenceName = new DevExpress.XtraEditors.LabelControl();
            this.textEditAbsenceName = new DevExpress.XtraEditors.TextEdit();
            this.lbl_Abbreviation = new DevExpress.XtraEditors.LabelControl();
            this.textEditAbsenceAbbreviation = new DevExpress.XtraEditors.TextEdit();
            this.groupControl_AbsenceAction = new DevExpress.XtraEditors.GroupControl();
            this.lb_availablein = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup_AvailableIn = new DevExpress.XtraEditors.RadioGroup();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.chk_UseAsWorkingTime = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chk_CountAsOneDay = new DevExpress.XtraEditors.CheckEdit();
            this.chk_WithoutFixedTime = new DevExpress.XtraEditors.CheckEdit();
            this.spinEdit_CountFixedAmount = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_AbsenceCountFixedAmount = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.checkEdit_AbsenceAliquotTime = new DevExpress.XtraEditors.CheckEdit();
            this.lbl_Country = new DevExpress.XtraEditors.LabelControl();
            this.cbCountries = new DevExpress.XtraEditors.LookUpEdit();
            this.lbl_AbsenceColor = new DevExpress.XtraEditors.LabelControl();
            this.cbAbsenceColor = new DevExpress.XtraEditors.ColorEdit();
            this.lblSystemID = new DevExpress.XtraEditors.LabelControl();
            this.txtEditSystemId = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAbsenceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAbsenceAbbreviation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_AbsenceAction)).BeginInit();
            this.groupControl_AbsenceAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup_AvailableIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_UseAsWorkingTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_CountAsOneDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_WithoutFixedTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_CountFixedAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_AbsenceAliquotTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCountries.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbsenceColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditSystemId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblCaption);
            this.panelTop.Size = new System.Drawing.Size(370, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.txtEditSystemId);
            this.panelClient.Controls.Add(this.lblSystemID);
            this.panelClient.Controls.Add(this.cbAbsenceColor);
            this.panelClient.Controls.Add(this.lbl_AbsenceColor);
            this.panelClient.Controls.Add(this.cbCountries);
            this.panelClient.Controls.Add(this.lbl_Country);
            this.panelClient.Controls.Add(this.groupControl_AbsenceAction);
            this.panelClient.Controls.Add(this.textEditAbsenceAbbreviation);
            this.panelClient.Controls.Add(this.lbl_Abbreviation);
            this.panelClient.Controls.Add(this.textEditAbsenceName);
            this.panelClient.Controls.Add(this.lbl_AbsenceName);
            this.panelClient.Size = new System.Drawing.Size(370, 478);
            // 
            // button_OK
            // 
            this.button_OK.TabIndex = 0;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(-5610, 8);
            this.button_Cancel.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 512);
            this.panelBottom.Size = new System.Drawing.Size(370, 40);
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblCaption.Appearance.Options.UseFont = true;
            this.lblCaption.Appearance.Options.UseTextOptions = true;
            this.lblCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCaption.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Location = new System.Drawing.Point(2, 2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(366, 30);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Absence";
            // 
            // lbl_AbsenceName
            // 
            this.lbl_AbsenceName.Location = new System.Drawing.Point(12, 51);
            this.lbl_AbsenceName.Name = "lbl_AbsenceName";
            this.lbl_AbsenceName.Size = new System.Drawing.Size(71, 13);
            this.lbl_AbsenceName.TabIndex = 1;
            this.lbl_AbsenceName.Text = "Absence Name";
            // 
            // textEditAbsenceName
            // 
            this.textEditAbsenceName.Location = new System.Drawing.Point(12, 70);
            this.textEditAbsenceName.Name = "textEditAbsenceName";
            this.textEditAbsenceName.Properties.MaxLength = 50;
            this.textEditAbsenceName.Size = new System.Drawing.Size(349, 20);
            this.textEditAbsenceName.TabIndex = 1;
            // 
            // lbl_Abbreviation
            // 
            this.lbl_Abbreviation.Location = new System.Drawing.Point(12, 96);
            this.lbl_Abbreviation.Name = "lbl_Abbreviation";
            this.lbl_Abbreviation.Size = new System.Drawing.Size(61, 13);
            this.lbl_Abbreviation.TabIndex = 3;
            this.lbl_Abbreviation.Text = "Abbreviation";
            // 
            // textEditAbsenceAbbreviation
            // 
            this.textEditAbsenceAbbreviation.Location = new System.Drawing.Point(12, 115);
            this.textEditAbsenceAbbreviation.Name = "textEditAbsenceAbbreviation";
            this.textEditAbsenceAbbreviation.Properties.MaxLength = 6;
            this.textEditAbsenceAbbreviation.Size = new System.Drawing.Size(96, 20);
            this.textEditAbsenceAbbreviation.TabIndex = 2;
            // 
            // groupControl_AbsenceAction
            // 
            this.groupControl_AbsenceAction.Controls.Add(this.lb_availablein);
            this.groupControl_AbsenceAction.Controls.Add(this.radioGroup_AvailableIn);
            this.groupControl_AbsenceAction.Controls.Add(this.panelControl4);
            this.groupControl_AbsenceAction.Controls.Add(this.panelControl2);
            this.groupControl_AbsenceAction.Controls.Add(this.panelControl1);
            this.groupControl_AbsenceAction.Location = new System.Drawing.Point(11, 141);
            this.groupControl_AbsenceAction.Name = "groupControl_AbsenceAction";
            this.groupControl_AbsenceAction.Size = new System.Drawing.Size(350, 331);
            this.groupControl_AbsenceAction.TabIndex = 5;
            this.groupControl_AbsenceAction.Text = "Action";
            // 
            // lb_availablein
            // 
            this.lb_availablein.Location = new System.Drawing.Point(5, 211);
            this.lb_availablein.Name = "lb_availablein";
            this.lb_availablein.Size = new System.Drawing.Size(56, 13);
            this.lb_availablein.TabIndex = 11;
            this.lb_availablein.Text = "Available In";
            // 
            // radioGroup_AvailableIn
            // 
            this.radioGroup_AvailableIn.EditValue = 1;
            this.radioGroup_AvailableIn.Location = new System.Drawing.Point(5, 229);
            this.radioGroup_AvailableIn.Name = "radioGroup_AvailableIn";
            this.radioGroup_AvailableIn.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Planning / Time-Recordin"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Planning only"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Time Recording only"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "None")});
            this.radioGroup_AvailableIn.Size = new System.Drawing.Size(340, 97);
            this.radioGroup_AvailableIn.TabIndex = 10;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.chk_UseAsWorkingTime);
            this.panelControl4.Location = new System.Drawing.Point(5, 172);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(340, 33);
            this.panelControl4.TabIndex = 3;
            // 
            // chk_UseAsWorkingTime
            // 
            this.chk_UseAsWorkingTime.Location = new System.Drawing.Point(10, 7);
            this.chk_UseAsWorkingTime.Name = "chk_UseAsWorkingTime";
            this.chk_UseAsWorkingTime.Properties.Caption = "Calculates as working time ";
            this.chk_UseAsWorkingTime.Size = new System.Drawing.Size(323, 19);
            this.chk_UseAsWorkingTime.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.chk_CountAsOneDay);
            this.panelControl2.Controls.Add(this.chk_WithoutFixedTime);
            this.panelControl2.Controls.Add(this.spinEdit_CountFixedAmount);
            this.panelControl2.Controls.Add(this.lbl_AbsenceCountFixedAmount);
            this.panelControl2.Location = new System.Drawing.Point(5, 68);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(340, 98);
            this.panelControl2.TabIndex = 1;
            // 
            // chk_CountAsOneDay
            // 
            this.chk_CountAsOneDay.Location = new System.Drawing.Point(5, 68);
            this.chk_CountAsOneDay.Name = "chk_CountAsOneDay";
            this.chk_CountAsOneDay.Properties.Caption = "Count always as one day";
            this.chk_CountAsOneDay.Size = new System.Drawing.Size(328, 19);
            this.chk_CountAsOneDay.TabIndex = 2;
            this.chk_CountAsOneDay.CheckedChanged += new System.EventHandler(this.chk_CoutAsOneDay_CheckedChanged);
            // 
            // chk_WithoutFixedTime
            // 
            this.chk_WithoutFixedTime.Location = new System.Drawing.Point(5, 40);
            this.chk_WithoutFixedTime.Name = "chk_WithoutFixedTime";
            this.chk_WithoutFixedTime.Properties.Caption = "Without Fixed time amount";
            this.chk_WithoutFixedTime.Size = new System.Drawing.Size(323, 19);
            this.chk_WithoutFixedTime.TabIndex = 1;
            this.chk_WithoutFixedTime.CheckedChanged += new System.EventHandler(this.checkEdit_WithoutFixed_CheckedChanged);
            // 
            // spinEdit_CountFixedAmount
            // 
            this.spinEdit_CountFixedAmount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_CountFixedAmount.Location = new System.Drawing.Point(7, 5);
            this.spinEdit_CountFixedAmount.Name = "spinEdit_CountFixedAmount";
            this.spinEdit_CountFixedAmount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_CountFixedAmount.Properties.Mask.EditMask = "n1";
            this.spinEdit_CountFixedAmount.Properties.MaxLength = 4;
            this.spinEdit_CountFixedAmount.Properties.MaxValue = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.spinEdit_CountFixedAmount.Size = new System.Drawing.Size(100, 20);
            this.spinEdit_CountFixedAmount.TabIndex = 0;
            this.spinEdit_CountFixedAmount.EditValueChanged += new System.EventHandler(this.spinEdit_CountFixedAmount_EditValueChanged);
            // 
            // lbl_AbsenceCountFixedAmount
            // 
            this.lbl_AbsenceCountFixedAmount.Location = new System.Drawing.Point(113, 8);
            this.lbl_AbsenceCountFixedAmount.Name = "lbl_AbsenceCountFixedAmount";
            this.lbl_AbsenceCountFixedAmount.Size = new System.Drawing.Size(95, 13);
            this.lbl_AbsenceCountFixedAmount.TabIndex = 0;
            this.lbl_AbsenceCountFixedAmount.Text = "Count fixed amount";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.checkEdit_AbsenceAliquotTime);
            this.panelControl1.Location = new System.Drawing.Point(5, 23);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(340, 39);
            this.panelControl1.TabIndex = 0;
            // 
            // checkEdit_AbsenceAliquotTime
            // 
            this.checkEdit_AbsenceAliquotTime.Location = new System.Drawing.Point(5, 11);
            this.checkEdit_AbsenceAliquotTime.Name = "checkEdit_AbsenceAliquotTime";
            this.checkEdit_AbsenceAliquotTime.Properties.Caption = "Count aliquot time";
            this.checkEdit_AbsenceAliquotTime.Size = new System.Drawing.Size(330, 19);
            this.checkEdit_AbsenceAliquotTime.TabIndex = 0;
            this.checkEdit_AbsenceAliquotTime.CheckedChanged += new System.EventHandler(this.checkEdit_AbsenceAliquotTime_CheckedChanged);
            // 
            // lbl_Country
            // 
            this.lbl_Country.Location = new System.Drawing.Point(11, 6);
            this.lbl_Country.Name = "lbl_Country";
            this.lbl_Country.Size = new System.Drawing.Size(39, 13);
            this.lbl_Country.TabIndex = 6;
            this.lbl_Country.Text = "Country";
            // 
            // cbCountries
            // 
            this.cbCountries.Location = new System.Drawing.Point(12, 25);
            this.cbCountries.Name = "cbCountries";
            this.cbCountries.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCountries.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 100)});
            this.cbCountries.Properties.DisplayMember = "Name";
            this.cbCountries.Properties.NullText = "";
            this.cbCountries.Properties.ValueMember = "ID";
            this.cbCountries.Size = new System.Drawing.Size(349, 20);
            this.cbCountries.TabIndex = 0;
            // 
            // lbl_AbsenceColor
            // 
            this.lbl_AbsenceColor.Location = new System.Drawing.Point(213, 96);
            this.lbl_AbsenceColor.Name = "lbl_AbsenceColor";
            this.lbl_AbsenceColor.Size = new System.Drawing.Size(25, 13);
            this.lbl_AbsenceColor.TabIndex = 8;
            this.lbl_AbsenceColor.Text = "Color";
            // 
            // cbAbsenceColor
            // 
            this.cbAbsenceColor.EditValue = System.Drawing.Color.Empty;
            this.cbAbsenceColor.Location = new System.Drawing.Point(213, 115);
            this.cbAbsenceColor.Name = "cbAbsenceColor";
            this.cbAbsenceColor.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbAbsenceColor.Properties.Appearance.Options.UseBackColor = true;
            this.cbAbsenceColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAbsenceColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbAbsenceColor.Properties.StoreColorAsInteger = true;
            this.cbAbsenceColor.Size = new System.Drawing.Size(148, 20);
            this.cbAbsenceColor.TabIndex = 4;
            // 
            // lblSystemID
            // 
            this.lblSystemID.Location = new System.Drawing.Point(129, 96);
            this.lblSystemID.Name = "lblSystemID";
            this.lblSystemID.Size = new System.Drawing.Size(46, 13);
            this.lblSystemID.TabIndex = 9;
            this.lblSystemID.Text = "SystemID";
            this.lblSystemID.Visible = false;
            // 
            // txtEditSystemId
            // 
            this.txtEditSystemId.Location = new System.Drawing.Point(129, 115);
            this.txtEditSystemId.Name = "txtEditSystemId";
            this.txtEditSystemId.Properties.Mask.EditMask = "\\d{0,4}";
            this.txtEditSystemId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtEditSystemId.Properties.MaxLength = 4;
            this.txtEditSystemId.Size = new System.Drawing.Size(53, 20);
            this.txtEditSystemId.TabIndex = 3;
            this.txtEditSystemId.Visible = false;
            // 
            // AbsenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(370, 552);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "AbsenceForm";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            this.panelClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditAbsenceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAbsenceAbbreviation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_AbsenceAction)).EndInit();
            this.groupControl_AbsenceAction.ResumeLayout(false);
            this.groupControl_AbsenceAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup_AvailableIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chk_UseAsWorkingTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_CountAsOneDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_WithoutFixedTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_CountFixedAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_AbsenceAliquotTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCountries.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbsenceColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditSystemId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblCaption;
        private DevExpress.XtraEditors.TextEdit textEditAbsenceName;
        private DevExpress.XtraEditors.LabelControl lbl_AbsenceName;
        private DevExpress.XtraEditors.GroupControl groupControl_AbsenceAction;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit checkEdit_AbsenceAliquotTime;
        private DevExpress.XtraEditors.TextEdit textEditAbsenceAbbreviation;
        private DevExpress.XtraEditors.LabelControl lbl_Abbreviation;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SpinEdit spinEdit_CountFixedAmount;
        private DevExpress.XtraEditors.LabelControl lbl_AbsenceCountFixedAmount;
        private DevExpress.XtraEditors.LookUpEdit cbCountries;
        private DevExpress.XtraEditors.LabelControl lbl_Country;
        private DevExpress.XtraEditors.ColorEdit cbAbsenceColor;
        private DevExpress.XtraEditors.LabelControl lbl_AbsenceColor;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.CheckEdit chk_UseAsWorkingTime;
        private DevExpress.XtraEditors.TextEdit txtEditSystemId;
        private DevExpress.XtraEditors.LabelControl lblSystemID;
        private DevExpress.XtraEditors.LabelControl lb_availablein;
        private DevExpress.XtraEditors.RadioGroup radioGroup_AvailableIn;
        private DevExpress.XtraEditors.CheckEdit chk_CountAsOneDay;
        private DevExpress.XtraEditors.CheckEdit chk_WithoutFixedTime;
    }
}
