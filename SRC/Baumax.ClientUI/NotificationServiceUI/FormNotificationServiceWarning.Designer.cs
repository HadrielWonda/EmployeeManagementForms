namespace Baumax.ClientUI.NotificationServiceUI
{
	partial class FormNotificationServiceWarning
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNotificationServiceWarning));
			this.panelButtons = new DevExpress.XtraEditors.PanelControl();
			this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
			this.layoutControlWarnings = new DevExpress.XtraLayout.LayoutControl();
			this.imageCollection32 = new DevExpress.Utils.ImageCollection(this.components);
			this.layoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
			this.imageCollection16 = new DevExpress.Utils.ImageCollection(this.components);
			this.tabControlWizard = new DevExpress.XtraTab.XtraTabControl();
			this.tabPageAnalyzing = new DevExpress.XtraTab.XtraTabPage();
			this.lbl_Analyzing = new DevExpress.XtraEditors.LabelControl();
			this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
			this.tabPageResult = new DevExpress.XtraTab.XtraTabPage();
			this.imageCollection48 = new DevExpress.Utils.ImageCollection(this.components);
			((System.ComponentModel.ISupportInitialize)(this.panelButtons)).BeginInit();
			this.panelButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlWarnings)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection32)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection16)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tabControlWizard)).BeginInit();
			this.tabControlWizard.SuspendLayout();
			this.tabPageAnalyzing.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
			this.tabPageResult.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection48)).BeginInit();
			this.SuspendLayout();
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.btn_Close);
			this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelButtons.Location = new System.Drawing.Point(0, 454);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(680, 38);
			this.panelButtons.TabIndex = 0;
			// 
			// btn_Close
			// 
			this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Close.Location = new System.Drawing.Point(593, 10);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new System.Drawing.Size(75, 23);
			this.btn_Close.TabIndex = 0;
			this.btn_Close.Text = "Close";
			this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
			// 
			// layoutControlWarnings
			// 
			this.layoutControlWarnings.AllowCustomizationMenu = false;
			this.layoutControlWarnings.CaptionImages = this.imageCollection32;
			this.layoutControlWarnings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControlWarnings.Location = new System.Drawing.Point(0, 0);
			this.layoutControlWarnings.Name = "layoutControlWarnings";
			this.layoutControlWarnings.OptionsCustomizationForm.AllowUndoManager = false;
			this.layoutControlWarnings.OptionsCustomizationForm.EnableUndoManager = false;
			this.layoutControlWarnings.OptionsCustomizationForm.ShowLayoutTreeView = false;
			this.layoutControlWarnings.OptionsCustomizationForm.ShowLoadButton = false;
			this.layoutControlWarnings.OptionsCustomizationForm.ShowRedoButton = false;
			this.layoutControlWarnings.OptionsCustomizationForm.ShowSaveButton = false;
			this.layoutControlWarnings.OptionsCustomizationForm.ShowUndoButton = false;
			this.layoutControlWarnings.OptionsSerialization.RestoreLayoutItemText = false;
			this.layoutControlWarnings.Root = this.layoutControlGroupRoot;
			this.layoutControlWarnings.Size = new System.Drawing.Size(671, 445);
			this.layoutControlWarnings.TabIndex = 1;
			this.layoutControlWarnings.Text = "layoutControl1";
			// 
			// imageCollection32
			// 
			this.imageCollection32.ImageSize = new System.Drawing.Size(32, 32);
			this.imageCollection32.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection32.ImageStream")));
			// 
			// layoutControlGroupRoot
			// 
			this.layoutControlGroupRoot.CustomizationFormText = "layoutControlGroupRoot";
			this.layoutControlGroupRoot.GroupBordersVisible = false;
			this.layoutControlGroupRoot.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroupRoot.Name = "layoutControlGroupRoot";
			this.layoutControlGroupRoot.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroupRoot.Size = new System.Drawing.Size(671, 445);
			this.layoutControlGroupRoot.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroupRoot.Text = "layoutControlGroupRoot";
			this.layoutControlGroupRoot.TextVisible = false;
			// 
			// imageCollection16
			// 
			this.imageCollection16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection16.ImageStream")));
			// 
			// tabControlWizard
			// 
			this.tabControlWizard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlWizard.Location = new System.Drawing.Point(0, 0);
			this.tabControlWizard.Name = "tabControlWizard";
			this.tabControlWizard.SelectedTabPage = this.tabPageAnalyzing;
			this.tabControlWizard.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
			this.tabControlWizard.Size = new System.Drawing.Size(680, 454);
			this.tabControlWizard.TabIndex = 2;
			this.tabControlWizard.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageAnalyzing,
            this.tabPageResult});
			this.tabControlWizard.Text = "xtraTabControl1";
			// 
			// tabPageAnalyzing
			// 
			this.tabPageAnalyzing.Controls.Add(this.lbl_Analyzing);
			this.tabPageAnalyzing.Controls.Add(this.marqueeProgressBarControl1);
			this.tabPageAnalyzing.Name = "tabPageAnalyzing";
			this.tabPageAnalyzing.Size = new System.Drawing.Size(671, 445);
			this.tabPageAnalyzing.Text = "Analyzing";
			// 
			// lbl_Analyzing
			// 
			this.lbl_Analyzing.Appearance.Options.UseTextOptions = true;
			this.lbl_Analyzing.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.lbl_Analyzing.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lbl_Analyzing.Location = new System.Drawing.Point(13, 207);
			this.lbl_Analyzing.Name = "lbl_Analyzing";
			this.lbl_Analyzing.Size = new System.Drawing.Size(650, 13);
			this.lbl_Analyzing.TabIndex = 2;
			this.lbl_Analyzing.Text = "Analyzing data";
			// 
			// marqueeProgressBarControl1
			// 
			this.marqueeProgressBarControl1.EditValue = 0;
			this.marqueeProgressBarControl1.Location = new System.Drawing.Point(13, 227);
			this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
			this.marqueeProgressBarControl1.Size = new System.Drawing.Size(650, 18);
			this.marqueeProgressBarControl1.StyleController = this.layoutControlWarnings;
			this.marqueeProgressBarControl1.TabIndex = 1;
			// 
			// tabPageResult
			// 
			this.tabPageResult.Controls.Add(this.layoutControlWarnings);
			this.tabPageResult.Name = "tabPageResult";
			this.tabPageResult.Size = new System.Drawing.Size(671, 445);
			this.tabPageResult.Text = "Result";
			// 
			// imageCollection48
			// 
			this.imageCollection48.ImageSize = new System.Drawing.Size(48, 48);
			this.imageCollection48.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection48.ImageStream")));
			// 
			// FormNotificationServiceWarning
			// 
			this.AcceptButton = this.btn_Close;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Close;
			this.ClientSize = new System.Drawing.Size(680, 492);
			this.ControlBox = false;
			this.Controls.Add(this.tabControlWizard);
			this.Controls.Add(this.panelButtons);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormNotificationServiceWarning";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Notification Service";
			((System.ComponentModel.ISupportInitialize)(this.panelButtons)).EndInit();
			this.panelButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.layoutControlWarnings)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection32)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection16)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tabControlWizard)).EndInit();
			this.tabControlWizard.ResumeLayout(false);
			this.tabPageAnalyzing.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
			this.tabPageResult.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.imageCollection48)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.PanelControl panelButtons;
		private DevExpress.XtraEditors.SimpleButton btn_Close;
		private DevExpress.XtraLayout.LayoutControl layoutControlWarnings;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupRoot;
		private DevExpress.XtraTab.XtraTabControl tabControlWizard;
		private DevExpress.XtraTab.XtraTabPage tabPageAnalyzing;
		private DevExpress.XtraTab.XtraTabPage tabPageResult;
		private DevExpress.XtraEditors.LabelControl lbl_Analyzing;
		private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
		private DevExpress.Utils.ImageCollection imageCollection32;
		private DevExpress.Utils.ImageCollection imageCollection16;
		private DevExpress.Utils.ImageCollection imageCollection48;
	}
}