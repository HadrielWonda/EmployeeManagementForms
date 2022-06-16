namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class FormEmployeeWorkHistory
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
            this.ucEmployeeWorkingHistory1 = new Baumax.ClientUI.FormEntities.Employee.UCEmployeeWorkingHistory();
            this.lbl_EmployeeWorkingHistory = new DevExpress.XtraEditors.LabelControl();
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
            this.panelTop.Controls.Add(this.lbl_EmployeeWorkingHistory);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ucEmployeeWorkingHistory1);
            this.panelClient.Size = new System.Drawing.Size(626, 349);
            // 
            // button_OK
            // 
            this.button_OK.Visible = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 383);
            // 
            // ucEmployeeWorkingHistory1
            // 
            this.ucEmployeeWorkingHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEmployeeWorkingHistory1.Entity = null;
            this.ucEmployeeWorkingHistory1.Location = new System.Drawing.Point(2, 2);
            this.ucEmployeeWorkingHistory1.LookAndFeel.SkinName = "iMaginary";
            this.ucEmployeeWorkingHistory1.Name = "ucEmployeeWorkingHistory1";
            this.ucEmployeeWorkingHistory1.Size = new System.Drawing.Size(622, 345);
            this.ucEmployeeWorkingHistory1.TabIndex = 0;
            // 
            // lbl_EmployeeWorkingHistory
            // 
            this.lbl_EmployeeWorkingHistory.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_EmployeeWorkingHistory.Appearance.Options.UseFont = true;
            this.lbl_EmployeeWorkingHistory.Appearance.Options.UseTextOptions = true;
            this.lbl_EmployeeWorkingHistory.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_EmployeeWorkingHistory.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_EmployeeWorkingHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_EmployeeWorkingHistory.Location = new System.Drawing.Point(2, 2);
            this.lbl_EmployeeWorkingHistory.Name = "lbl_EmployeeWorkingHistory";
            this.lbl_EmployeeWorkingHistory.Size = new System.Drawing.Size(622, 30);
            this.lbl_EmployeeWorkingHistory.TabIndex = 0;
            this.lbl_EmployeeWorkingHistory.Text = "Employee working history";
            // 
            // FormEmployeeWorkHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 423);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormEmployeeWorkHistory";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCEmployeeWorkingHistory ucEmployeeWorkingHistory1;
        private DevExpress.XtraEditors.LabelControl lbl_EmployeeWorkingHistory;
    }
}