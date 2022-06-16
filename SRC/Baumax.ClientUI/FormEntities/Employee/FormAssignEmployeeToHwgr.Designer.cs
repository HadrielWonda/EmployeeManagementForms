namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class FormAssignEmployeeToHwgr
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
            this.ucAssignEmployeeToHWGR = new Baumax.ClientUI.FormEntities.Employee.UCAssignEmployeeToHWGR();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Size = new System.Drawing.Size(439, 34);
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ucAssignEmployeeToHWGR);
            this.panelClient.Size = new System.Drawing.Size(439, 74);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(347, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 108);
            this.panelBottom.Size = new System.Drawing.Size(439, 40);
            // 
            // ucAssignEmployeeToHWGR
            // 
            this.ucAssignEmployeeToHWGR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAssignEmployeeToHWGR.Entity = null;
            this.ucAssignEmployeeToHWGR.Hwgr = ((long)(0));
            this.ucAssignEmployeeToHWGR.Location = new System.Drawing.Point(2, 2);
            this.ucAssignEmployeeToHWGR.LookAndFeel.SkinName = "iMaginary";
            this.ucAssignEmployeeToHWGR.Name = "ucAssignEmployeeToHWGR";
            this.ucAssignEmployeeToHWGR.Size = new System.Drawing.Size(435, 70);
            this.ucAssignEmployeeToHWGR.TabIndex = 0;
            // 
            // FormAssignEmployeeToHwgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 148);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormAssignEmployeeToHwgr";
            this.Text = "FormAssignEmployeeToHwgr";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCAssignEmployeeToHWGR ucAssignEmployeeToHWGR;
    }
}