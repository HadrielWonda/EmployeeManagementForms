namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class FormAssignToEmployee
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
            this.btn_Assign = new DevExpress.XtraEditors.SimpleButton();
            this.ucAssignToEmployee1 = new Baumax.ClientUI.FormEntities.Employee.UCAssignToEmployee();
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
            this.panelTop.Controls.Add(this.lblCaption);
            this.panelTop.Size = new System.Drawing.Size(553, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ucAssignToEmployee1);
            this.panelClient.Size = new System.Drawing.Size(553, 291);
            // 
            // button_OK
            // 
            this.button_OK.Visible = false;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(315, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btn_Assign);
            this.panelBottom.Location = new System.Drawing.Point(0, 325);
            this.panelBottom.Size = new System.Drawing.Size(553, 40);
            this.panelBottom.Controls.SetChildIndex(this.btn_Assign, 0);
            this.panelBottom.Controls.SetChildIndex(this.button_OK, 0);
            this.panelBottom.Controls.SetChildIndex(this.button_Cancel, 0);
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblCaption.Appearance.Options.UseFont = true;
            this.lblCaption.Appearance.Options.UseTextOptions = true;
            this.lblCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Location = new System.Drawing.Point(2, 2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(549, 30);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Assign External Employee";
            // 
            // btn_Assign
            // 
            this.btn_Assign.Location = new System.Drawing.Point(364, 8);
            this.btn_Assign.Name = "btn_Assign";
            this.btn_Assign.Size = new System.Drawing.Size(75, 23);
            this.btn_Assign.TabIndex = 54;
            this.btn_Assign.Text = "Assign";
            this.btn_Assign.Click += new System.EventHandler(this.btn_Assign_Click);
            // 
            // ucAssignToEmployee1
            // 
            this.ucAssignToEmployee1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAssignToEmployee1.Entity = null;
            this.ucAssignToEmployee1.Location = new System.Drawing.Point(2, 2);
            this.ucAssignToEmployee1.LookAndFeel.SkinName = "iMaginary";
            this.ucAssignToEmployee1.Name = "ucAssignToEmployee1";
            this.ucAssignToEmployee1.Size = new System.Drawing.Size(549, 287);
            this.ucAssignToEmployee1.TabIndex = 0;
            // 
            // FormAssignToEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 365);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormAssignToEmployee";
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

        private DevExpress.XtraEditors.LabelControl lblCaption;
        private DevExpress.XtraEditors.SimpleButton btn_Assign;
        private UCAssignToEmployee ucAssignToEmployee1;
    }
}