namespace Baumax.ClientUI
{
    partial class FrmEntityExceptionDetails
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
            this.buttonsPanel = new DevExpress.XtraEditors.PanelControl();
            this.btn_CopyToClipboard = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ok = new DevExpress.XtraEditors.SimpleButton();
            this.mainPanel = new DevExpress.XtraEditors.PanelControl();
            this.GroupControl_StackTrace = new DevExpress.XtraEditors.GroupControl();
            this.EditStackTrace = new DevExpress.XtraEditors.MemoEdit();
            this.GroupControl_Source = new DevExpress.XtraEditors.GroupControl();
            this.EditSource = new DevExpress.XtraEditors.MemoEdit();
            this.GroupControl_Message = new DevExpress.XtraEditors.GroupControl();
            this.EditMessage = new DevExpress.XtraEditors.MemoEdit();
            this.EditType = new DevExpress.XtraEditors.TextEdit();
            this.label_Type = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsPanel)).BeginInit();
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPanel)).BeginInit();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl_StackTrace)).BeginInit();
            this.GroupControl_StackTrace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditStackTrace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl_Source)).BeginInit();
            this.GroupControl_Source.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl_Message)).BeginInit();
            this.GroupControl_Message.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.btn_CopyToClipboard);
            this.buttonsPanel.Controls.Add(this.btn_ok);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 394);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(629, 48);
            this.buttonsPanel.TabIndex = 4;
            this.buttonsPanel.Text = "panelControl1";
            // 
            // btn_CopyToClipboard
            // 
            this.btn_CopyToClipboard.Location = new System.Drawing.Point(232, 11);
            this.btn_CopyToClipboard.Name = "btn_CopyToClipboard";
            this.btn_CopyToClipboard.Size = new System.Drawing.Size(289, 23);
            this.btn_CopyToClipboard.TabIndex = 1;
            this.btn_CopyToClipboard.Text = "&Copy details to clipboard";
            this.btn_CopyToClipboard.Click += new System.EventHandler(this.btn_CopyToClipboard_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_ok.Location = new System.Drawing.Point(108, 13);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "&OK";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.GroupControl_StackTrace);
            this.mainPanel.Controls.Add(this.GroupControl_Source);
            this.mainPanel.Controls.Add(this.GroupControl_Message);
            this.mainPanel.Controls.Add(this.EditType);
            this.mainPanel.Controls.Add(this.label_Type);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(629, 394);
            this.mainPanel.TabIndex = 5;
            this.mainPanel.Text = "panelControl2";
            // 
            // GroupControl_StackTrace
            // 
            this.GroupControl_StackTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupControl_StackTrace.Controls.Add(this.EditStackTrace);
            this.GroupControl_StackTrace.Location = new System.Drawing.Point(10, 222);
            this.GroupControl_StackTrace.Name = "GroupControl_StackTrace";
            this.GroupControl_StackTrace.Size = new System.Drawing.Size(605, 166);
            this.GroupControl_StackTrace.TabIndex = 11;
            this.GroupControl_StackTrace.Text = " StackTrace ";
            // 
            // EditStackTrace
            // 
            this.EditStackTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EditStackTrace.Location = new System.Drawing.Point(5, 23);
            this.EditStackTrace.Name = "EditStackTrace";
            this.EditStackTrace.Properties.ReadOnly = true;
            this.EditStackTrace.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.EditStackTrace.Size = new System.Drawing.Size(595, 138);
            this.EditStackTrace.TabIndex = 1;
            // 
            // GroupControl_Source
            // 
            this.GroupControl_Source.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupControl_Source.Controls.Add(this.EditSource);
            this.GroupControl_Source.Location = new System.Drawing.Point(10, 35);
            this.GroupControl_Source.Name = "GroupControl_Source";
            this.GroupControl_Source.Size = new System.Drawing.Size(607, 75);
            this.GroupControl_Source.TabIndex = 10;
            this.GroupControl_Source.Text = " Source ";
            // 
            // EditSource
            // 
            this.EditSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EditSource.Location = new System.Drawing.Point(5, 23);
            this.EditSource.Name = "EditSource";
            this.EditSource.Properties.ReadOnly = true;
            this.EditSource.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.EditSource.Size = new System.Drawing.Size(595, 47);
            this.EditSource.TabIndex = 0;
            // 
            // GroupControl_Message
            // 
            this.GroupControl_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupControl_Message.Controls.Add(this.EditMessage);
            this.GroupControl_Message.Location = new System.Drawing.Point(10, 116);
            this.GroupControl_Message.Name = "GroupControl_Message";
            this.GroupControl_Message.Size = new System.Drawing.Size(605, 100);
            this.GroupControl_Message.TabIndex = 8;
            this.GroupControl_Message.Text = " Message ";
            // 
            // EditMessage
            // 
            this.EditMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EditMessage.Location = new System.Drawing.Point(5, 23);
            this.EditMessage.Name = "EditMessage";
            this.EditMessage.Properties.ReadOnly = true;
            this.EditMessage.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.EditMessage.Size = new System.Drawing.Size(595, 72);
            this.EditMessage.TabIndex = 1;
            // 
            // EditType
            // 
            this.EditType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.EditType.Location = new System.Drawing.Point(49, 9);
            this.EditType.Name = "EditType";
            this.EditType.Properties.ReadOnly = true;
            this.EditType.Size = new System.Drawing.Size(568, 20);
            this.EditType.TabIndex = 5;
            // 
            // label_Type
            // 
            this.label_Type.Location = new System.Drawing.Point(12, 12);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(31, 13);
            this.label_Type.TabIndex = 4;
            this.label_Type.Text = "Type: ";
            // 
            // FrmEntityExceptionDetails
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_ok;
            this.ClientSize = new System.Drawing.Size(629, 442);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEntityExceptionDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entity Exception Details";
            ((System.ComponentModel.ISupportInitialize)(this.buttonsPanel)).EndInit();
            this.buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPanel)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl_StackTrace)).EndInit();
            this.GroupControl_StackTrace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EditStackTrace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl_Source)).EndInit();
            this.GroupControl_Source.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EditSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl_Message)).EndInit();
            this.GroupControl_Message.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EditMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl buttonsPanel;
        private DevExpress.XtraEditors.PanelControl mainPanel;
        private DevExpress.XtraEditors.GroupControl GroupControl_Source;
        private DevExpress.XtraEditors.MemoEdit EditSource;
        private DevExpress.XtraEditors.GroupControl GroupControl_Message;
        private DevExpress.XtraEditors.MemoEdit EditMessage;
        private DevExpress.XtraEditors.TextEdit EditType;
        private DevExpress.XtraEditors.LabelControl label_Type;
        private DevExpress.XtraEditors.GroupControl GroupControl_StackTrace;
        private DevExpress.XtraEditors.MemoEdit EditStackTrace;
        private DevExpress.XtraEditors.SimpleButton btn_CopyToClipboard;
        private DevExpress.XtraEditors.SimpleButton btn_ok;
    }
}