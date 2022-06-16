namespace Baumax.ClientUI.FormEntities.Country.UIWorkingModel
{
    partial class WorkingModelForm
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
            this.workModelControl1 = new Baumax.ClientUI.FormEntities.Country.UIWorkingModel.WorkModelControl();
            this.lbl_WorkingModel = new DevExpress.XtraEditors.LabelControl();
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
            this.panelTop.Controls.Add(this.lbl_WorkingModel);
            this.panelTop.Size = new System.Drawing.Size(670, 34);
            this.panelTop.Visible = true;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.workModelControl1);
            this.panelClient.Size = new System.Drawing.Size(670, 512);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(622, 8);
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 546);
            this.panelBottom.Size = new System.Drawing.Size(670, 40);
            // 
            // workModelControl1
            // 
            this.workModelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workModelControl1.Entity = null;
            this.workModelControl1.Location = new System.Drawing.Point(2, 2);
            this.workModelControl1.LookAndFeel.SkinName = "iMaginary";
            this.workModelControl1.Name = "workModelControl1";
            this.workModelControl1.Size = new System.Drawing.Size(666, 508);
            this.workModelControl1.TabIndex = 0;
            this.workModelControl1.WModel = null;
            // 
            // lbl_WorkingModel
            // 
            this.lbl_WorkingModel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_WorkingModel.Appearance.Options.UseFont = true;
            this.lbl_WorkingModel.Appearance.Options.UseTextOptions = true;
            this.lbl_WorkingModel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_WorkingModel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl_WorkingModel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_WorkingModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_WorkingModel.Location = new System.Drawing.Point(2, 2);
            this.lbl_WorkingModel.Name = "lbl_WorkingModel";
            this.lbl_WorkingModel.Size = new System.Drawing.Size(666, 30);
            this.lbl_WorkingModel.TabIndex = 0;
            this.lbl_WorkingModel.Text = "Working Model";
            // 
            // WorkingModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(670, 586);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "WorkingModelForm";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClient)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WorkModelControl workModelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_WorkingModel;


    }
}
