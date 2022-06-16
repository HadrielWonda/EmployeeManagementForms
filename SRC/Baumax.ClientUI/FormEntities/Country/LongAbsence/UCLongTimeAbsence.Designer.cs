namespace Baumax.ClientUI.FormEntities
{
    partial class UCLongTimeAbsence
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
            this.lbl_LongTimeAbsence = new DevExpress.XtraEditors.LabelControl();
            this.teAbsenceName = new DevExpress.XtraEditors.TextEdit();
            this.lbl_Abbreviation = new DevExpress.XtraEditors.LabelControl();
            this.teAbsenceAbbreviation = new DevExpress.XtraEditors.TextEdit();
            this.lbl_AbsenceColor = new DevExpress.XtraEditors.LabelControl();
            this.cbLongTimeColor = new DevExpress.XtraEditors.ColorEdit();
            ((System.ComponentModel.ISupportInitialize)(this.teAbsenceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAbsenceAbbreviation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLongTimeColor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_LongTimeAbsence
            // 
            this.lbl_LongTimeAbsence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_LongTimeAbsence.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_LongTimeAbsence.Location = new System.Drawing.Point(3, 3);
            this.lbl_LongTimeAbsence.Name = "lbl_LongTimeAbsence";
            this.lbl_LongTimeAbsence.Size = new System.Drawing.Size(361, 13);
            this.lbl_LongTimeAbsence.TabIndex = 0;
            this.lbl_LongTimeAbsence.Text = "Long-time absence";
            // 
            // teAbsenceName
            // 
            this.teAbsenceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.teAbsenceName.Location = new System.Drawing.Point(3, 23);
            this.teAbsenceName.Name = "teAbsenceName";
            this.teAbsenceName.Properties.MaxLength = 30;
            this.teAbsenceName.Size = new System.Drawing.Size(361, 20);
            this.teAbsenceName.TabIndex = 1;
            // 
            // lbl_Abbreviation
            // 
            this.lbl_Abbreviation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Abbreviation.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Abbreviation.Location = new System.Drawing.Point(3, 50);
            this.lbl_Abbreviation.Name = "lbl_Abbreviation";
            this.lbl_Abbreviation.Size = new System.Drawing.Size(361, 13);
            this.lbl_Abbreviation.TabIndex = 2;
            this.lbl_Abbreviation.Text = "Abbreviation";
            // 
            // teAbsenceAbbreviation
            // 
            this.teAbsenceAbbreviation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.teAbsenceAbbreviation.Location = new System.Drawing.Point(3, 70);
            this.teAbsenceAbbreviation.Name = "teAbsenceAbbreviation";
            this.teAbsenceAbbreviation.Properties.MaxLength = 6;
            this.teAbsenceAbbreviation.Size = new System.Drawing.Size(91, 20);
            this.teAbsenceAbbreviation.TabIndex = 3;
            // 
            // lbl_AbsenceColor
            // 
            this.lbl_AbsenceColor.Location = new System.Drawing.Point(267, 49);
            this.lbl_AbsenceColor.Name = "lbl_AbsenceColor";
            this.lbl_AbsenceColor.Size = new System.Drawing.Size(25, 13);
            this.lbl_AbsenceColor.TabIndex = 4;
            this.lbl_AbsenceColor.Text = "Color";
            // 
            // cbLongTimeColor
            // 
            this.cbLongTimeColor.EditValue = System.Drawing.Color.Empty;
            this.cbLongTimeColor.Location = new System.Drawing.Point(267, 69);
            this.cbLongTimeColor.Name = "cbLongTimeColor";
            this.cbLongTimeColor.Properties.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.cbLongTimeColor.Properties.Appearance.Options.UseForeColor = true;
            this.cbLongTimeColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLongTimeColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbLongTimeColor.Properties.StoreColorAsInteger = true;
            this.cbLongTimeColor.Size = new System.Drawing.Size(100, 20);
            this.cbLongTimeColor.TabIndex = 5;
            // 
            // UCLongTimeAbsence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbLongTimeColor);
            this.Controls.Add(this.lbl_AbsenceColor);
            this.Controls.Add(this.teAbsenceAbbreviation);
            this.Controls.Add(this.lbl_Abbreviation);
            this.Controls.Add(this.teAbsenceName);
            this.Controls.Add(this.lbl_LongTimeAbsence);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCLongTimeAbsence";
            this.Size = new System.Drawing.Size(367, 110);
            ((System.ComponentModel.ISupportInitialize)(this.teAbsenceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAbsenceAbbreviation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLongTimeColor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_LongTimeAbsence;
        private DevExpress.XtraEditors.TextEdit teAbsenceName;
		private DevExpress.XtraEditors.LabelControl lbl_Abbreviation;
		private DevExpress.XtraEditors.TextEdit teAbsenceAbbreviation;
        private DevExpress.XtraEditors.LabelControl lbl_AbsenceColor;
        private DevExpress.XtraEditors.ColorEdit cbLongTimeColor;
    }
}
