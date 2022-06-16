namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class FormAssignEmployeeToWorld
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
            this.ucAssignEmployeeToWorld1 = new Baumax.ClientUI.FormEntities.Employee.UCAssignEmployeeToWorld();
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
            this.panelTop.Size = new System.Drawing.Size(411, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.ucAssignEmployeeToWorld1);
            this.panelClient.Size = new System.Drawing.Size(411, 146);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(104, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 180);
            this.panelBottom.Size = new System.Drawing.Size(411, 40);
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
            this.lblCaption.Size = new System.Drawing.Size(407, 30);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Assign employee to world";
            // 
            // ucAssignEmployeeToWorld1
            // 
            this.ucAssignEmployeeToWorld1.BeginTime = new System.DateTime(((long)(0)));
            this.ucAssignEmployeeToWorld1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAssignEmployeeToWorld1.EndTime = new System.DateTime(((long)(0)));
            this.ucAssignEmployeeToWorld1.Entity = null;
            this.ucAssignEmployeeToWorld1.Location = new System.Drawing.Point(2, 2);
            this.ucAssignEmployeeToWorld1.LookAndFeel.SkinName = "iMaginary";
            this.ucAssignEmployeeToWorld1.Name = "ucAssignEmployeeToWorld1";
            this.ucAssignEmployeeToWorld1.Size = new System.Drawing.Size(407, 142);
            this.ucAssignEmployeeToWorld1.StoreWorldId = ((long)(0));
            this.ucAssignEmployeeToWorld1.TabIndex = 0;
            // 
            // FormAssignEmployeeToWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 220);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "FormAssignEmployeeToWorld";
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
        private UCAssignEmployeeToWorld ucAssignEmployeeToWorld1;
    }
}