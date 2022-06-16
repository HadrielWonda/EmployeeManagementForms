namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class FormSelectEmployee
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
            this.lbl_SelectEmployee = new DevExpress.XtraEditors.LabelControl();
            this.ucEmployeeSelectGrid1 = new Baumax.ClientUI.FormEntities.Employee.UCEmployeeSelectGrid();
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
            this.panelTop.Controls.Add(this.lbl_SelectEmployee);
            this.panelTop.Size = new System.Drawing.Size(472, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ucEmployeeSelectGrid1);
            this.panelClient.Size = new System.Drawing.Size(472, 199);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(226, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 233);
            this.panelBottom.Size = new System.Drawing.Size(472, 40);
            // 
            // lbl_SelectEmployee
            // 
            this.lbl_SelectEmployee.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_SelectEmployee.Appearance.Options.UseFont = true;
            this.lbl_SelectEmployee.Appearance.Options.UseTextOptions = true;
            this.lbl_SelectEmployee.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_SelectEmployee.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_SelectEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_SelectEmployee.Location = new System.Drawing.Point(2, 2);
            this.lbl_SelectEmployee.Name = "lbl_SelectEmployee";
            this.lbl_SelectEmployee.Size = new System.Drawing.Size(468, 30);
            this.lbl_SelectEmployee.TabIndex = 0;
            this.lbl_SelectEmployee.Text = "Select employee";
            // 
            // ucEmployeeSelectGrid1
            // 
            this.ucEmployeeSelectGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEmployeeSelectGrid1.Entity = null;
            this.ucEmployeeSelectGrid1.Location = new System.Drawing.Point(2, 2);
            this.ucEmployeeSelectGrid1.LookAndFeel.SkinName = "iMaginary";
            this.ucEmployeeSelectGrid1.Name = "ucEmployeeSelectGrid1";
            this.ucEmployeeSelectGrid1.Size = new System.Drawing.Size(468, 195);
            this.ucEmployeeSelectGrid1.TabIndex = 0;
            this.ucEmployeeSelectGrid1.EmployeeSelected += new Baumax.ClientUI.FormEntities.Employee.UCEmployeeSelectGrid.DlgEmployeeSelected(this.ucEmployeeSelectGrid1_EmployeeSelected);
            // 
            // FormSelectEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 273);
            this.ControlBox = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.LookAndFeel.SkinName = "iMaginary";
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "FormSelectEmployee";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_SelectEmployee;
        private UCEmployeeSelectGrid ucEmployeeSelectGrid1;
    }
}