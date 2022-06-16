using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.ClientUI;
using Baumax.Localization;
using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.ClientUI.FormEntities
{
    using Baumax.Environment;

    public partial class FormBaseEntity : XtraForm
    {
        private string _uniqueformname = "formbaseentity";
        private bool _Modified = false;
        
        private IEditableEntityCtrl _entityControl = null;
        public NotifyChangedLanguageUI DoChangeLanguage = null;


        public FormBaseEntity()
        {
            InitializeComponent();
            Disposed += new EventHandler(FormBaseEntity_Disposed);
        }

        public string GetLocalized(string key)
        {
            return Localizer.GetLocalized(key);
        }

        public string GetLocalized(int key)
        {
            return Localizer.GetLocalized(key);
        }
        public IEditableEntityCtrl EntityControl
        {
            get { return _entityControl; }
            set { _entityControl = value; }
        }

        public virtual object Entity
        {
            get
            {
                if (EntityControl != null) return EntityControl.Entity;
                return null;
            }
            set
            {
                if (EntityControl != null) 
                {
                    EntityControl.Entity = value;
                    EntityControl.Bind();
                }
            }
        }

        #region Protected Methods
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            SaveLayout();

        }


        

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (ClientEnvironment.IsRuntimeMode)
            {
                LoadLayout();
                button_Cancel.Left = panelBottom.Width - button_Cancel.Width - 16;


                DoChangeLanguage = new NotifyChangedLanguageUI(NotificationService_ChangedLanguageUI);
                NotificationService.ChangedLanguageUI += DoChangeLanguage;
            }

        }

        void NotificationService_ChangedLanguageUI()
        {
            AssignLanguage();
        }

        void FormBaseEntity_Disposed(object sender, EventArgs e)
        {
            NotificationService.ChangedLanguageUI -= DoChangeLanguage;
        }
        #endregion

        protected virtual bool ValidateEntity()
        {
            if (EntityControl != null)
                return EntityControl.IsValid();
            return true;
        }


        /// <summary>
        /// Does the after validate.
        /// Save data after validate on press OK
        /// </summary>
        /// <returns></returns>
        protected virtual bool SaveEntity()
        {
            if (EntityControl != null)
                return EntityControl.Commit();
            return true;
        }

        /// <summary>
        /// Does the before cancel.
        /// Somethings do before close form on press Cancel
        /// </summary>
        /// <returns></returns>
        protected virtual bool DoBeforeCancel()
        {
            return true;
        }

        public virtual void AssignLanguage()
        {
            ControlLocalizer _localizer = new ControlLocalizer(UILocalizer.Current, this);
        }

        protected virtual void LoadLayout()
        {
            //LayoutManager.Instance.LoadLayout(UniqueFormName, this);
            AssignLanguage();
        }
        protected virtual void SaveLayout()
        {
            //LayoutManager.Instance.SaveLayout(UniqueFormName, this);
        }

        /// <summary>
        /// Gets or sets the name of the unique form.
        /// Need for load and save layout
        /// </summary>
        /// <value>The name of the unique form.</value>
        public string UniqueFormName
        {
            get { return _uniqueformname; }
            set { _uniqueformname = value; }
        }

        public virtual bool Modified
        {
            get
            {
                if (EntityControl != null)
                    return _Modified || EntityControl.Modified;

                return _Modified;
            }
            set { _Modified = value;}
        }

        #region Message util
        public const string ATTENTION = "Attention";
        public DialogResult StopMessage(string message)
        {
            return StopMessage(message, ATTENTION);
        }
        public DialogResult StopMessage(string message, string caption)
        {
            return XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public DialogResult ErrorMessage(string message)
        {
            return ErrorMessage(message, ATTENTION);
        }
        public DialogResult ErrorMessage(string message, string caption)
        {
            return XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public DialogResult InfoMessage(string message)
        {
            return InfoMessage(message, ATTENTION);
        }
        public DialogResult InfoMessage(string message, string caption)
        {
            return XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DialogResult QuestionMessage(string message)
        {
            return QuestionMessage(message, ATTENTION);
        }

        public DialogResult QuestionMessage(string message, string caption)
        {
            return XtraMessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public bool QuestionMessageYes(string message, string caption)
        {
            return XtraMessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public bool QuestionMessageYes(string message)
        {
            return XtraMessageBox.Show(message, ATTENTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public bool QuestionMessageYes(int code)
        {
            return XtraMessageBox.Show(code.ToString(), ATTENTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
        #endregion

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (ValidateEntity() && SaveEntity())
            {
                DialogResult = (Modified) ? DialogResult.OK : DialogResult.Cancel;
#if DEBUG
    //            InfoMessage(Modified.ToString() + "  " + DialogResult.ToString());
#endif
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            if (DoBeforeCancel())
                DialogResult = DialogResult.Cancel;
        }


        protected virtual void ProcessEntityException(EntityException ex)
        {
            using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
            {
                form.Text = GetLocalized("CannotSaveAbsence");
                form.ShowDialog(this);
            }
        }

    }
}
