namespace Baumax.ClientUI.FormEntities.Employee
{
    partial class EmployeeCtrl
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
            this.components = new System.ComponentModel.Container();
            this.lblFirstName = new DevExpress.XtraEditors.LabelControl();
            this.teFirstName = new DevExpress.XtraEditors.TextEdit();
            this.lblSecondName = new DevExpress.XtraEditors.LabelControl();
            this.teSecondName = new DevExpress.XtraEditors.TextEdit();
            this.lblPersonalID = new DevExpress.XtraEditors.LabelControl();
            this.tePersonalID = new DevExpress.XtraEditors.TextEdit();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.teFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSecondName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePersonalID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(12, 13);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(51, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name";
            // 
            // teFirstName
            // 
            this.teFirstName.Location = new System.Drawing.Point(12, 33);
            this.teFirstName.Name = "teFirstName";
            this.teFirstName.Size = new System.Drawing.Size(218, 20);
            this.teFirstName.TabIndex = 0;
            // 
            // lblSecondName
            // 
            this.lblSecondName.Location = new System.Drawing.Point(12, 63);
            this.lblSecondName.Name = "lblSecondName";
            this.lblSecondName.Size = new System.Drawing.Size(65, 13);
            this.lblSecondName.TabIndex = 0;
            this.lblSecondName.Text = "Second Name";
            // 
            // teSecondName
            // 
            this.teSecondName.Location = new System.Drawing.Point(12, 83);
            this.teSecondName.Name = "teSecondName";
            this.teSecondName.Size = new System.Drawing.Size(218, 20);
            this.teSecondName.TabIndex = 1;
            // 
            // lblPersonalID
            // 
            this.lblPersonalID.Location = new System.Drawing.Point(12, 115);
            this.lblPersonalID.Name = "lblPersonalID";
            this.lblPersonalID.Size = new System.Drawing.Size(55, 13);
            this.lblPersonalID.TabIndex = 0;
            this.lblPersonalID.Text = "Personal ID";
            // 
            // tePersonalID
            // 
            this.tePersonalID.Location = new System.Drawing.Point(12, 135);
            this.tePersonalID.Name = "tePersonalID";
            this.tePersonalID.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.tePersonalID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.tePersonalID.Size = new System.Drawing.Size(218, 20);
            this.tePersonalID.TabIndex = 2;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // EmployeeCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tePersonalID);
            this.Controls.Add(this.lblPersonalID);
            this.Controls.Add(this.teSecondName);
            this.Controls.Add(this.lblSecondName);
            this.Controls.Add(this.teFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Name = "EmployeeCtrl";
            this.Size = new System.Drawing.Size(255, 179);
            ((System.ComponentModel.ISupportInitialize)(this.teFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSecondName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePersonalID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblFirstName;
        private DevExpress.XtraEditors.TextEdit teFirstName;
        private DevExpress.XtraEditors.LabelControl lblSecondName;
        private DevExpress.XtraEditors.TextEdit teSecondName;
        private DevExpress.XtraEditors.LabelControl lblPersonalID;
        private DevExpress.XtraEditors.TextEdit tePersonalID;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}
