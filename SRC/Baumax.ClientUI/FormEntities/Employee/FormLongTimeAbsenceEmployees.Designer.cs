namespace Baumax.ClientUI.FormEntities
{
    partial class FormLongTimeAbsenceEmployees
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
            this.ucLongTimeAbsenceEmployees1 = new Baumax.ClientUI.FormEntities.UCLongTimeAbsenceEmployees();
            this.lbl_ViewEmployeesHasLongTimeAbsence = new DevExpress.XtraEditors.LabelControl();
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
            this.panelTop.Controls.Add(this.lbl_ViewEmployeesHasLongTimeAbsence);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ucLongTimeAbsenceEmployees1);
            this.panelClient.Size = new System.Drawing.Size(626, 395);
            // 
            // button_OK
            // 
            this.button_OK.Visible = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 429);
            // 
            // ucLongTimeAbsenceEmployees1
            // 
            this.ucLongTimeAbsenceEmployees1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLongTimeAbsenceEmployees1.Entity = null;
            this.ucLongTimeAbsenceEmployees1.Location = new System.Drawing.Point(2, 2);
            this.ucLongTimeAbsenceEmployees1.LookAndFeel.SkinName = "iMaginary";
            this.ucLongTimeAbsenceEmployees1.Name = "ucLongTimeAbsenceEmployees1";
            this.ucLongTimeAbsenceEmployees1.Size = new System.Drawing.Size(622, 391);
            this.ucLongTimeAbsenceEmployees1.TabIndex = 0;
            // 
            // lbl_ViewEmployeesHasLongTimeAbsence
            // 
            this.lbl_ViewEmployeesHasLongTimeAbsence.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_ViewEmployeesHasLongTimeAbsence.Appearance.Options.UseFont = true;
            this.lbl_ViewEmployeesHasLongTimeAbsence.Appearance.Options.UseTextOptions = true;
            this.lbl_ViewEmployeesHasLongTimeAbsence.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_ViewEmployeesHasLongTimeAbsence.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_ViewEmployeesHasLongTimeAbsence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ViewEmployeesHasLongTimeAbsence.Location = new System.Drawing.Point(2, 2);
            this.lbl_ViewEmployeesHasLongTimeAbsence.Name = "lbl_ViewEmployeesHasLongTimeAbsence";
            this.lbl_ViewEmployeesHasLongTimeAbsence.Size = new System.Drawing.Size(622, 30);
            this.lbl_ViewEmployeesHasLongTimeAbsence.TabIndex = 0;
            this.lbl_ViewEmployeesHasLongTimeAbsence.Text = "View employees has long-time absence";
            // 
            // FormLongTimeAbsenceEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 469);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormLongTimeAbsenceEmployees";
            this.Text = "    ";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCLongTimeAbsenceEmployees ucLongTimeAbsenceEmployees1;
        private DevExpress.XtraEditors.LabelControl lbl_ViewEmployeesHasLongTimeAbsence;
    }
}