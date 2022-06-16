namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class EmployeeFrm
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
            this.ctrlEmployee = new Baumax.ClientUI.FormEntities.Employee.EmployeeCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(253, 34);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 207);
            this.panelBottom.Size = new System.Drawing.Size(253, 40);
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ctrlEmployee);
            this.panelClient.Size = new System.Drawing.Size(253, 173);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(43, 9);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Cancel.Location = new System.Drawing.Point(129, 9);
            // 
            // ctrlEmployee
            // 
            this.ctrlEmployee.Entity = null;
            this.ctrlEmployee.Location = new System.Drawing.Point(0, 0);
            this.ctrlEmployee.Name = "ctrlEmployee";
            this.ctrlEmployee.Size = new System.Drawing.Size(255, 178);
            this.ctrlEmployee.TabIndex = 0;
            // 
            // EmployeeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 247);
            this.Name = "EmployeeFrm";
            this.Text = "Employee";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EmployeeCtrl ctrlEmployee;
    }
}