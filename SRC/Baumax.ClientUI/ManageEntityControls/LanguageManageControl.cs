using System;
using System.Windows.Forms;
using Baumax.ClientUI.FormEntities;
using Baumax.ClientUI.TranslationUI;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraNavBar;

namespace Baumax.ClientUI.ManageEntityControls
{
    public partial class LanguageManageControl : UCBaseEntity 
    {
        TranslationUIControl translationUI = null;
        private bool _CanEdit;

        private bool bTranslation = false;

        public LanguageManageControl()
        {
            InitializeComponent();
            ApplyUserRights();

        }
        
        public LanguageManageControl( Form ownerFrom)
            : base(ownerFrom)
        {
            InitializeComponent();
            ApplyUserRights();
        }


        public bool TranslationMode
        {
            get { return bTranslation; }
            set 
            {
                if (bTranslation != value)
                {
                    if (value)
                    {
                        translationUI = new TranslationUIControl();
                        panelDummy.Controls.Add(translationUI);
                        translationUI.Parent = panelDummy;
                        translationUI.Dock = DockStyle.Fill;
                        translationUI.Visible = true;
                        translationUI.OnChangeContent += new TranslationUIControl.ChangeContent(translationUI_OnChangeContent);
                        cntrlLanguageList.Visible = false;
                        translationUI.Bind();

                    }
                    else
                    {
                        cntrlLanguageList.Visible = true;

                        if (translationUI != null)
                        {
                            translationUI.Visible = false;
                            panelDummy.Controls.Remove(translationUI);
                            translationUI.Dispose();
                            translationUI = null;
                        }
                    }

                    bTranslation = value;

                    UpdateNavBarItemsState();
                }
            }
        }

        private void ApplyUserRights()
        {
            AccessType access = ClientEnvironment.AuthorizationService.GetAccess(ClientEnvironment.LanguageService);
            _CanEdit = (access & AccessType.Write) != 0;

            navBarItem_NewLanguage.Enabled = _CanEdit;
            navBarItem_EditLanguage.Enabled = _CanEdit;
            navBarItem_DeleteLanguage.Enabled = _CanEdit;
            navBarItem_TranslateUI.Enabled = _CanEdit;

            cntrlLanguageList.ReadOnly = !_CanEdit;
        }

        void translationUI_OnChangeContent()
        {
            UpdateNavBarItemsState();            
        }

        private void LanguageManageControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                cntrlLanguageList.InitData();
                ApplyUserRights();
            }
        }

        private void cntrlLanguageList_OnFocusedLanguageChanged(Language language)
        {
            UpdateNavBarItemsState();
        }

        private void navBarItem_NewLanguage_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            cntrlLanguageList.NewEntity();
        }

        private void navBarItem_EditLanguage_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            cntrlLanguageList.EditEntity(null);
        }

        private void navBarItem_DeleteLanguage_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            cntrlLanguageList.DeleteEntity(null);
        }

        public void UpdateNavBarItemsState()
        {
            if (!bTranslation)
            {
                navBarItem_NewLanguage.Visible =
                    navBarItem_EditLanguage.Visible =
                        navBarItem_DeleteLanguage.Visible = 
                            navBarItem_TranslateUI.Visible = true;

                navBarItem_SaveTranslation.Visible = false;
                navBarItem_SaveTranslation.Enabled = false;

                navBarItem_NewLanguage.Enabled = cntrlLanguageList.CanNewLanguage;
                navBarItem_EditLanguage.Enabled = cntrlLanguageList.CanEditLanguage;
                navBarItem_DeleteLanguage.Enabled = cntrlLanguageList.CanDeleteLanguage;
                navBarItem_TranslateUI.Enabled = cntrlLanguageList.CanTranslateLanguage;
            }
            else
            {
                navBarItem_NewLanguage.Visible =
                    navBarItem_EditLanguage.Visible =
                        navBarItem_DeleteLanguage.Visible =
                            navBarItem_TranslateUI.Visible = false;

                navBarItem_SaveTranslation.Visible = true;
                if (translationUI != null)
                    navBarItem_SaveTranslation.Enabled = translationUI.Modified;
                else navBarItem_SaveTranslation.Enabled = false;

                navBarItem_NewLanguage.Enabled = false;
                navBarItem_EditLanguage.Enabled = false;
                navBarItem_DeleteLanguage.Enabled = false;
                navBarItem_TranslateUI.Enabled = false;
                navBarItem_ListLanguage.Enabled = true;
            }
            ApplyUserRights();
        }

        public override void AssignLanguage()
        {
            if (ClientEnvironment.IsRuntimeMode)
            {
                base.AssignLanguage();
                LocalizerControl.NavBarLocalize(barLanguageManager);
            }
        }

        private void navBarItem_TranslateUI_LinkClicked(object sender, NavBarLinkEventArgs e)
        {

            TranslationMode = true;
        }

        private void navBarItem_ListLanguage_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            TranslationMode = false;
        }

        private void navBarItem_SaveTranslation_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (TranslationMode)
            {
                translationUI.ChangedLanguage();
            }
        }

        private void cntrlLanguageList_OnActionNeeded()
        {
            TranslationMode = true;
        }

    }
}
