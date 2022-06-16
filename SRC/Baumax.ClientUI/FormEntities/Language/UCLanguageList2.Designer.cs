namespace Baumax.ClientUI.FormEntities.Language
{
    partial class UCLanguageList2
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
            this.gridControlLanguages = new DevExpress.XtraGrid.GridControl();
            this.menuLanguages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem_newLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_EditLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_DeleteLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_RefreshLanguages = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_TranslateLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewLanguages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_LanguageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_LanguageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLanguages)).BeginInit();
            this.menuLanguages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLanguages)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlLanguages
            // 
            this.gridControlLanguages.ContextMenuStrip = this.menuLanguages;
            this.gridControlLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLanguages.EmbeddedNavigator.Name = "";
            this.gridControlLanguages.Location = new System.Drawing.Point(0, 0);
            this.gridControlLanguages.MainView = this.gridViewLanguages;
            this.gridControlLanguages.Name = "gridControlLanguages";
            this.gridControlLanguages.Size = new System.Drawing.Size(638, 462);
            this.gridControlLanguages.TabIndex = 0;
            this.gridControlLanguages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLanguages});
            this.gridControlLanguages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControlLanguages_MouseDoubleClick);
            // 
            // menuLanguages
            // 
            this.menuLanguages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_newLanguage,
            this.menuItem_EditLanguage,
            this.menuItem_DeleteLanguage,
            this.toolStripSeparator1,
            this.menuItem_RefreshLanguages,
            this.menuItem_TranslateLanguage});
            this.menuLanguages.Name = "menuLanguages";
            this.menuLanguages.Size = new System.Drawing.Size(181, 120);
            this.menuLanguages.Opening += new System.ComponentModel.CancelEventHandler(this.menuLanguages_Opening);
            // 
            // menuItem_newLanguage
            // 
            this.menuItem_newLanguage.Name = "menuItem_newLanguage";
            this.menuItem_newLanguage.Size = new System.Drawing.Size(180, 22);
            this.menuItem_newLanguage.Text = "New Language";
            this.menuItem_newLanguage.Click += new System.EventHandler(this.menuItem_newLanguage_Click);
            // 
            // menuItem_EditLanguage
            // 
            this.menuItem_EditLanguage.Name = "menuItem_EditLanguage";
            this.menuItem_EditLanguage.Size = new System.Drawing.Size(180, 22);
            this.menuItem_EditLanguage.Text = "Edit Language";
            this.menuItem_EditLanguage.Click += new System.EventHandler(this.menuItem_EditLanguage_Click);
            // 
            // menuItem_DeleteLanguage
            // 
            this.menuItem_DeleteLanguage.Name = "menuItem_DeleteLanguage";
            this.menuItem_DeleteLanguage.Size = new System.Drawing.Size(180, 22);
            this.menuItem_DeleteLanguage.Text = "Delete Language";
            this.menuItem_DeleteLanguage.Click += new System.EventHandler(this.menuItem_DeleteLangauge_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuItem_RefreshLanguages
            // 
            this.menuItem_RefreshLanguages.Name = "menuItem_RefreshLanguages";
            this.menuItem_RefreshLanguages.Size = new System.Drawing.Size(180, 22);
            this.menuItem_RefreshLanguages.Text = "Refresh Languages";
            this.menuItem_RefreshLanguages.Click += new System.EventHandler(this.menuItem_RefreshLanguages_Click);
            // 
            // menuItem_TranslateLanguage
            // 
            this.menuItem_TranslateLanguage.Name = "menuItem_TranslateLanguage";
            this.menuItem_TranslateLanguage.Size = new System.Drawing.Size(180, 22);
            this.menuItem_TranslateLanguage.Text = "Translate Language";
            this.menuItem_TranslateLanguage.Click += new System.EventHandler(this.menuItem_TranslateLanguage_Click);
            // 
            // gridViewLanguages
            // 
            this.gridViewLanguages.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_LanguageName,
            this.gridColumn_LanguageCode});
            this.gridViewLanguages.GridControl = this.gridControlLanguages;
            this.gridViewLanguages.Name = "gridViewLanguages";
            this.gridViewLanguages.OptionsBehavior.Editable = false;
            this.gridViewLanguages.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewLanguages.OptionsView.ShowGroupPanel = false;
            this.gridViewLanguages.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewLanguages_FocusedRowChanged);
            this.gridViewLanguages.RowCountChanged += new System.EventHandler(this.gridViewLanguages_RowCountChanged);
            this.gridViewLanguages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewLanguages_KeyDown);
            // 
            // gridColumn_LanguageName
            // 
            this.gridColumn_LanguageName.Caption = " Name";
            this.gridColumn_LanguageName.FieldName = "Name";
            this.gridColumn_LanguageName.Name = "gridColumn_LanguageName";
            this.gridColumn_LanguageName.OptionsColumn.ReadOnly = true;
            this.gridColumn_LanguageName.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_LanguageName.OptionsFilter.AllowFilter = false;
            this.gridColumn_LanguageName.Visible = true;
            this.gridColumn_LanguageName.VisibleIndex = 0;
            this.gridColumn_LanguageName.Width = 524;
            // 
            // gridColumn_LanguageCode
            // 
            this.gridColumn_LanguageCode.Caption = "Code";
            this.gridColumn_LanguageCode.FieldName = "LanguageCode";
            this.gridColumn_LanguageCode.Name = "gridColumn_LanguageCode";
            this.gridColumn_LanguageCode.OptionsColumn.ReadOnly = true;
            this.gridColumn_LanguageCode.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn_LanguageCode.OptionsFilter.AllowFilter = false;
            this.gridColumn_LanguageCode.Width = 93;
            // 
            // UCLanguageList2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlLanguages);
            this.LookAndFeel.SkinName = "iMaginary";
            this.Name = "UCLanguageList2";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLanguages)).EndInit();
            this.menuLanguages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLanguages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlLanguages;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLanguages;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_LanguageName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_LanguageCode;
        private System.Windows.Forms.ContextMenuStrip menuLanguages;
        private System.Windows.Forms.ToolStripMenuItem menuItem_newLanguage;
        private System.Windows.Forms.ToolStripMenuItem menuItem_EditLanguage;
        private System.Windows.Forms.ToolStripMenuItem menuItem_DeleteLanguage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_RefreshLanguages;
        private System.Windows.Forms.ToolStripMenuItem menuItem_TranslateLanguage;
    }
}
