namespace Baumax.ClientUI.FormEntities.Employee
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
            ((System.ComponentModel.ISupportInitialize)(this.teAbsenceName.Properties)).BeginInit();
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
            this.teAbsenceName.Location = new System.Drawing.Point(3, 22);
            this.teAbsenceName.Name = "teAbsenceName";
            this.teAbsenceName.Properties.MaxLength = 30;
            this.teAbsenceName.Size = new System.Drawing.Size(361, 20);
            this.teAbsenceName.TabIndex = 1;
            // 
            // UCLongTimeAbsence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.teAbsenceName);
            this.Controls.Add(this.lbl_LongTimeAbsence);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCLongTimeAbsence";
            this.Size = new System.Drawing.Size(367, 81);
            ((System.ComponentModel.ISupportInitialize)(this.teAbsenceName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_LongTimeAbsence;
        private DevExpress.XtraEditors.TextEdit teAbsenceName;
    }
}
