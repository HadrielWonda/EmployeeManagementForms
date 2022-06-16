namespace Baumax.HQLTest
{
    partial class MainForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelLog = new System.Windows.Forms.Panel();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.panelQuery = new System.Windows.Forms.Panel();
            this.btnClearGrid = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearLog = new DevExpress.XtraEditors.SimpleButton();
            this.btnGo = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelClient = new System.Windows.Forms.Panel();
            this.gridControlMain = new DevExpress.XtraGrid.GridControl();
            this.gridViewMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterTopGrid = new DevExpress.XtraEditors.SplitterControl();
            this.splitterQueryLog = new DevExpress.XtraEditors.SplitterControl();
            this.panelTop.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.panelQuery.SuspendLayout();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.splitterQueryLog);
            this.panelTop.Controls.Add(this.panelLog);
            this.panelTop.Controls.Add(this.panelQuery);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(853, 303);
            this.panelTop.TabIndex = 0;
            // 
            // panelLog
            // 
            this.panelLog.Controls.Add(this.textBoxOut);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLog.Location = new System.Drawing.Point(0, 176);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(853, 127);
            this.panelLog.TabIndex = 6;
            // 
            // textBoxOut
            // 
            this.textBoxOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOut.Location = new System.Drawing.Point(0, 6);
            this.textBoxOut.Multiline = true;
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.ReadOnly = true;
            this.textBoxOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOut.Size = new System.Drawing.Size(853, 121);
            this.textBoxOut.TabIndex = 2;
            // 
            // panelQuery
            // 
            this.panelQuery.Controls.Add(this.btnClearGrid);
            this.panelQuery.Controls.Add(this.btnClearLog);
            this.panelQuery.Controls.Add(this.btnGo);
            this.panelQuery.Controls.Add(this.textBoxIn);
            this.panelQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuery.Location = new System.Drawing.Point(0, 0);
            this.panelQuery.Name = "panelQuery";
            this.panelQuery.Size = new System.Drawing.Size(853, 176);
            this.panelQuery.TabIndex = 5;
            // 
            // btnClearGrid
            // 
            this.btnClearGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearGrid.Location = new System.Drawing.Point(278, 147);
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.Size = new System.Drawing.Size(75, 23);
            this.btnClearGrid.TabIndex = 8;
            this.btnClearGrid.Text = "Clear &grid";
            this.btnClearGrid.Click += new System.EventHandler(this.btnClearGrid_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearLog.Location = new System.Drawing.Point(137, 147);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(86, 23);
            this.btnClearLog.TabIndex = 7;
            this.btnClearLog.Text = "Clear &log";
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGo.Location = new System.Drawing.Point(12, 147);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "&Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // textBoxIn
            // 
            this.textBoxIn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIn.Location = new System.Drawing.Point(3, 3);
            this.textBoxIn.Multiline = true;
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxIn.Size = new System.Drawing.Size(847, 138);
            this.textBoxIn.TabIndex = 5;
            this.textBoxIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIn_KeyPress);
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 560);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(853, 31);
            this.panelBottom.TabIndex = 1;
            // 
            // panelClient
            // 
            this.panelClient.Controls.Add(this.gridControlMain);
            this.panelClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClient.Location = new System.Drawing.Point(0, 303);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(853, 257);
            this.panelClient.TabIndex = 2;
            // 
            // gridControlMain
            // 
            this.gridControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMain.EmbeddedNavigator.Name = "";
            this.gridControlMain.Location = new System.Drawing.Point(0, 0);
            this.gridControlMain.MainView = this.gridViewMain;
            this.gridControlMain.Name = "gridControlMain";
            this.gridControlMain.Size = new System.Drawing.Size(853, 257);
            this.gridControlMain.TabIndex = 0;
            this.gridControlMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMain});
            // 
            // gridViewMain
            // 
            this.gridViewMain.GridControl = this.gridControlMain;
            this.gridViewMain.Name = "gridViewMain";
            this.gridViewMain.OptionsBehavior.Editable = false;
            // 
            // splitterTopGrid
            // 
            this.splitterTopGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterTopGrid.Location = new System.Drawing.Point(0, 303);
            this.splitterTopGrid.Name = "splitterTopGrid";
            this.splitterTopGrid.Size = new System.Drawing.Size(853, 6);
            this.splitterTopGrid.TabIndex = 3;
            this.splitterTopGrid.TabStop = false;
            // 
            // splitterQueryLog
            // 
            this.splitterQueryLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterQueryLog.Location = new System.Drawing.Point(0, 176);
            this.splitterQueryLog.Name = "splitterQueryLog";
            this.splitterQueryLog.Size = new System.Drawing.Size(853, 6);
            this.splitterQueryLog.TabIndex = 10;
            this.splitterQueryLog.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 591);
            this.Controls.Add(this.splitterTopGrid);
            this.Controls.Add(this.panelClient);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "MainForm";
            this.Text = "HQL test";
            this.panelTop.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            this.panelLog.PerformLayout();
            this.panelQuery.ResumeLayout(false);
            this.panelQuery.PerformLayout();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelClient;
        private DevExpress.XtraGrid.GridControl gridControlMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMain;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.Panel panelQuery;
        private DevExpress.XtraEditors.SimpleButton btnClearGrid;
        private DevExpress.XtraEditors.SimpleButton btnClearLog;
        private DevExpress.XtraEditors.SimpleButton btnGo;
        private System.Windows.Forms.TextBox textBoxIn;
        private DevExpress.XtraEditors.SplitterControl splitterTopGrid;
        private DevExpress.XtraEditors.SplitterControl splitterQueryLog;
    }
}

