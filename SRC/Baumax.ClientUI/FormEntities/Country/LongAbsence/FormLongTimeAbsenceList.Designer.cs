namespace Baumax.ClientUI.FormEntities
{
    partial class FormLongTimeAbsenceList
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
            this.lbl_LongTimeAbsenceList = new DevExpress.XtraEditors.LabelControl();
            this.ucLongTimeAbsenceList1 = new Baumax.ClientUI.FormEntities.UCLongTimeAbsenceList();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lbl_LongTimeAbsenceList);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ucLongTimeAbsenceList1);
            // 
            // button_OK
            // 
            this.button_OK.Visible = false;
            // 
            // lbl_LongTimeAbsenceList
            // 
            this.lbl_LongTimeAbsenceList.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_LongTimeAbsenceList.Appearance.Options.UseFont = true;
            this.lbl_LongTimeAbsenceList.Appearance.Options.UseTextOptions = true;
            this.lbl_LongTimeAbsenceList.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_LongTimeAbsenceList.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_LongTimeAbsenceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_LongTimeAbsenceList.Location = new System.Drawing.Point(2, 2);
            this.lbl_LongTimeAbsenceList.Name = "lbl_LongTimeAbsenceList";
            this.lbl_LongTimeAbsenceList.Size = new System.Drawing.Size(622, 30);
            this.lbl_LongTimeAbsenceList.TabIndex = 0;
            this.lbl_LongTimeAbsenceList.Text = " Long-time absences";
            // 
            // ucLongTimeAbsenceList1
            // 
            this.ucLongTimeAbsenceList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLongTimeAbsenceList1.Entity = null;
            this.ucLongTimeAbsenceList1.Location = new System.Drawing.Point(2, 2);
            this.ucLongTimeAbsenceList1.LookAndFeel.SkinName = "iMaginary";
            this.ucLongTimeAbsenceList1.Name = "ucLongTimeAbsenceList1";
            this.ucLongTimeAbsenceList1.Size = new System.Drawing.Size(622, 197);
            this.ucLongTimeAbsenceList1.TabIndex = 0;
            // 
            // FormLongTimeAbsenceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 275);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormLongTimeAbsenceList";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_LongTimeAbsenceList;
        private UCLongTimeAbsenceList ucLongTimeAbsenceList1;
    }
}