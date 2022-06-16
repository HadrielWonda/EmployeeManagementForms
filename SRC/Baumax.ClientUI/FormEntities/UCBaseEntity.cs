using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Environment;
using Baumax.Localization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraTreeList;
using DevExpress.XtraVerticalGrid;

namespace Baumax.ClientUI.FormEntities
{
    public partial class UCBaseEntity : XtraUserControl, IEditableEntityCtrl 
    {
        public static bool IsDesignMode = true;
        private Form _ownerForm;
        //private long? _curLangId = null;
        protected ControlLocalizer _localizer = null;
        private bool _modified = false;
        private object _entity = null;
        private bool _readonly = false;
        
        protected UCBaseEntity()
        {
            InitializeComponent();
        }

        public UCBaseEntity(Form ownerForm)
        {
            InitializeComponent();

            _ownerForm = ownerForm;
        }

        #region Localizer
        public ControlLocalizer LocalizerControl
        {
            get
            {
                return _localizer;
            }
        }

        public string GetLocalized(string key)
        {
            return Localizer.GetLocalized(key);
        }

        public string GetLocalized(int key)
        {
            return Localizer.GetLocalized(key);
        }

        #endregion
        #region Protecetd Properties
        protected Form OwnerForm
        {
            get { return _ownerForm; }
        }
        
        #endregion

        

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!IsDesignMode)
            {
                Disposed += new EventHandler(UCBaseEntity_Disposed);

                LoadLayout();
                DoChangeLanguage = new NotifyChangedLanguageUI(NotificationService_ChangedLanguageUI);
                NotificationService.ChangedLanguageUI += DoChangeLanguage;
            }
            
        }

        void UCBaseEntity_Disposed(object sender, EventArgs e)
        {
            DoDispose();
            NotificationService.ChangedLanguageUI -= DoChangeLanguage;
        }

        public NotifyChangedLanguageUI DoChangeLanguage = null;

        void NotificationService_ChangedLanguageUI()
        {
            AssignLanguage();
        }

        protected virtual void ChangedReadOnlyState()
        {

        }

        protected virtual void EntityChanged()
        {
        }

        #region IEditableEntityCtrl 

        
        [DefaultValue(false)]
        public virtual bool Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        [DefaultValue(false)]
        public virtual bool ReadOnly
        {
            get { return _readonly; }
            set
            {
                if (_readonly != value)
                {
                    _readonly = value;
                    ChangedReadOnlyState();
                }
            }
        }

        [Browsable (false)]
        public virtual object Entity
        {
            get { return _entity; }
            set 
            {
                if (_entity != value)
                {
                    _entity = value;
                    EntityChanged();
                }
            }
        }

        public virtual bool IsValid()
        {
            return true;
        }

        public virtual bool Commit()
        {
            return true;
        }

        /// <summary>
        /// Binds data to controls. Should be implemented in descendants of UCBaseEntity
        /// </summary>
        public virtual void Bind()
        {
        }


        #endregion

        /// <summary>
        /// If UC allows add new items
        /// </summary>
        public virtual bool AddEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Add new item
        /// </summary>
        public virtual void Add()
        {
        }

        /// <summary>
        /// If UC allows edit existing items
        /// </summary>
        public virtual bool EditEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Edit current item
        /// </summary>
        public virtual void Edit()
        {
        }

        /// <summary>
        /// If UC allows delete items
        /// </summary>
        public virtual bool DeleteEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Delete selected items
        /// </summary>
        public virtual void Delete()
        {
        }
        
        public virtual void RefreshData()
        {
            Bind();
            Refresh();
        }

        // Igor Yakubov 15.06.2007


        // return localizer for customer translation  and messages
        /*public object Localizer
        {
            get { return null; }
        }*/
	
        /// <summary >
        /// Localized UC 
        ///</summary>
        ///Assign Language call after load layout becouse some control can save 
        ///self caption and need translate them.
        public virtual void AssignLanguage()
        {
            if (!IsDesignMode)
            {
                _localizer = new ControlLocalizer(UILocalizer.Current , this);
                AssignControlsStyle(Controls);
            }

        }

        // Load layout - like grid column order and size
        // splitter positins and ...
        protected virtual void LoadLayout()
        {
            // to do something than call AssignLangauge();
            AssignLanguage();
        }
        // Save layout - like grid column order and size
        protected virtual void SaveLayout()
        {
        }

        #region Util
        public const string ATTENTION = "Attention";
        public static DialogResult StopMessage(string message)
        {
            return StopMessage(message, Localizer.GetLocalized("Error"));
        }
        public static DialogResult StopMessage(string message, string caption)
        {
            return XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public static DialogResult ErrorMessage(string message)
        {
            return ErrorMessage(message, Localizer.GetLocalized("Error"));
        }
        public static DialogResult ErrorMessage(string message, string caption)
        {
            return XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult InfoMessage(string message)
        {
            return InfoMessage(message, Localizer.GetLocalized("Attention"));
        }
        public static DialogResult InfoMessage(string message, string caption)
        {
            return XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult QuestionMessage(string message)
        {
            return QuestionMessage(message, Localizer.GetLocalized("Confirm"));
        }

        public static DialogResult QuestionMessage(string message, string caption)
        {
            return XtraMessageBox.Show(message, caption, MessageBoxButtons.YesNo , MessageBoxIcon.Question);
        }

        public static bool QuestionMessageYes(string message, string caption)
        {
            return XtraMessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static bool QuestionMessageYes(string message)
        {
            return XtraMessageBox.Show(message, Localizer.GetLocalized("Confirm"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static bool QuestionMessageYes(int code)
        {
            return XtraMessageBox.Show(Localizer.GetLocalized(code), Localizer.GetLocalized("Confirm"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
        #endregion

        #region Exception processing


        protected virtual void ProcessEntityException(EntityException ex)
        {
            using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
            {
                //form.Text = GetLocalized("CannotSaveAbsence");
                form.ShowDialog(this);
            }
        }

        #endregion

      /*private  string GetCodeWord(string controlname)
        {

            if (controlname != null)
            {

                int pos = controlname.IndexOf('_');

                if (pos > 0)
                {
                    return controlname.Substring(pos + 1).ToLower();
                }
            }
            return null;
        }*/
        
       private void AssignControlsStyle(ControlCollection controls)
       {
            Color backColor = Color.FromArgb(122, 150, 223);

            foreach (object var in controls)
            {
                PropertyInfo pr = var.GetType().GetProperty("ToolTipController");
                if (pr != null)
                    pr.SetValue(var, toolTip, null);

                GridControl gridc = var as GridControl;
                if (gridc != null)
                {
                    gridc.ToolTipController = toolTip;
                    foreach (ColumnView bview in gridc.Views)
                    {
                        foreach (GridColumn column in bview.Columns)
                        {
                            string key = column.Name + "_Tip";
                            string tip = GetLocalized(key);
                            if (tip != null)
                                column.ToolTip = tip;
                            else
                            {
                                string caption = GetLocalized(column.Name);
                                if (caption != null)
                                    column.ToolTip = caption;
                            }
                        }
                        
                        GridView gview = bview as GridView;
                        if (gview != null)
                        {
                            gview.Appearance.FocusedCell.BackColor = backColor;
                            gview.Appearance.FocusedRow.BackColor = backColor;
                            gview.Appearance.SelectedRow.BackColor = backColor;
                        }
                    }
                }
                else
                {
                    VGridControl vgrid = var as VGridControl;
                    if (vgrid != null)
                    {
                        vgrid.ToolTipController = toolTip;
                        vgrid.Appearance.FocusedCell.BackColor = backColor;
                        vgrid.Appearance.FocusedRecord.BackColor = backColor;
                    }
                    else
                    {
                        TreeList tlist = var as TreeList;
                        if (tlist != null)
                        {
                            tlist.Appearance.FocusedCell.BackColor = backColor;
                            tlist.Appearance.FocusedRow.BackColor = backColor;
                            tlist.Appearance.SelectedRow.BackColor = backColor;
                        }
                        else 
                        {
                            LayoutControl lcontr = var as LayoutControl;
                            if (lcontr != null)
                            {
                                AssignControlsStyle(lcontr.Controls);
                                //lcontr.Root.GroupBordersVisible = false;
                            }
                            else 
                            {
                                PanelControl panel = var as PanelControl;
                                if (panel != null)
                                {
                                    AssignControlsStyle(panel.Controls);
                                    //panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                                }
                            }
                        }
                    }
                }
            }
        }


        protected virtual void OnLoad(object sender, EventArgs e)
        {
          //AssignControlsStyle(Controls);
        }
        // Igor Yakubov 12.12.2008
        // need for ask user save modified data or for dispose data
        public virtual void SomethingDoBeforeDispose()
        {

        }
        // call from dispose event
        public virtual void DoDispose()
        {

        }
    }
}
