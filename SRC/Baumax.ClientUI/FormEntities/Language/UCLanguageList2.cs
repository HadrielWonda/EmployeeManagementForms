using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.ClientUI;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Baumax.Localization;
using Baumax.Domain;

namespace Baumax.ClientUI.FormEntities.Language
{
    public partial class UCLanguageList2 : UCBaseEntity
    {
        BindingTemplate<Domain.Language> _bindingLanguageList = new BindingTemplate<Domain.Language>();

        public delegate void FocusedLangaugeChanged(Domain.Language language);

        public event FocusedLangaugeChanged OnFocusedLanguageChanged = null;

        public delegate void ControlNeededAction();

        public event ControlNeededAction OnActionNeeded = null;


        public UCLanguageList2()
        {
            InitializeComponent();
        }

        public UCLanguageList2(Form ownerFrom)
            : base(ownerFrom)
        {
            InitializeComponent();
        }


        public void InitData()
        {
            IList _langList = ClientEnvironment.LanguageService.FindAll();
            _bindingLanguageList.Clear();
            _bindingLanguageList.CopyList(_langList);

            gridControlLanguages.DataSource = _bindingLanguageList;
        }


        public override void AssignLanguage()
        {
            if (ClientEnvironment.IsRuntimeMode)
            {
                base.AssignLanguage();
                LocalizerControl.ComponentsLocalize(this.components);
            }
        }

        #region New,Edit Delete Language

        public void NewEntity()
        {
            if (!ReadOnly)
            {
                using (FormLanguage2 f = new FormLanguage2())
                {
                    //f.Text = Localizer.GetLocalized("New Language");
                    f.Language = ClientEnvironment.LanguageService.CreateEntity();
                    //new Domain.Language();
                    if (f.ShowDialog(OwnerForm) == DialogResult.OK)
                    {
                        _bindingLanguageList.Add(f.Language);
                    }
                }
            }
        }

        public void EditEntity(Domain.Language aLang)
        {
            if (!ReadOnly)
            {
                Domain.Language l = (Domain.Language) gridViewLanguages.GetRow(gridViewLanguages.FocusedRowHandle);
                if (l != null)
                {
                    using (FormLanguage2 f = new FormLanguage2())
                    {
                        //f.Text = Localizer.GetLocalized("Edit Language");
                        f.Language = l;
                        if (f.ShowDialog(OwnerForm) == DialogResult.OK)
                        {
                            //  ClientEnvironment.LanguageService.SaveOrUpdate(f.Language);
                            _bindingLanguageList.ResetItemById(f.Language.ID);
                        }
                    }
                }
            }
        }

        public void DeleteEntity(Domain.Language aLang)
        {
            if (!ReadOnly)
            {
                List<long> ids = new List<long>();

                int[] selectedIds = gridViewLanguages.GetSelectedRows();

                foreach (int rowHandle in selectedIds)
                {
                    Domain.Language lang = (Domain.Language) gridViewLanguages.GetRow(rowHandle);
                    ids.Add(lang.ID);
                }

                if (ids.Count > 0)
                {
                    if (QuestionMessageYes(GetLocalized("questiondeletelanguage")))
                    {
                        // assume multiselect never be enabled. but just in case...
                        if (ids.Count == 1)
                        {
                            try
                            {
                                ClientEnvironment.LanguageService.DeleteByID(ids[0]);
                                System.Diagnostics.Debug.Assert(ids.Count == selectedIds.Length); // == 1
                                gridViewLanguages.DeleteRow(selectedIds[0]);
                            }
                            catch (DBReferenceConstraintConflictedException)
                            {
                                ErrorMessage(GetLocalized("LanguageAssignedToCountry"));
                            }
                            catch (ValidationException)
                            {
                                ErrorMessage(GetLocalized("CannotDeleteDefaultLanguage"));
                            }
                            catch (EntityException ex)
                            {
                                // 2think: what details should we show?
                                // 2think: how to localize?
                                using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                                {
                                    form.Text = GetLocalized("CannotDeleteLanguage");
                                    form.ShowDialog(this);
                                }
                            }
                        }
                        else
                        {
                            // assume multiselect will never be enabled. but just in case...
                            try
                            {
                                ClientEnvironment.LanguageService.DeleteListByID(ids);

                                foreach (int rowHandle in selectedIds)
                                {
                                    gridViewLanguages.DeleteRow(rowHandle);
                                }
                            }
                            catch (ValidationException)
                            {
                                ErrorMessage(GetLocalized("CannotDeleteDefaultLanguage"));
                            }
                                // can't exactly determine the reason of operation failure for each item separately
                                // so just remove successfully deleted items from list and notify user
                            catch (EntityException ex)
                            {
                                // 2think: isn't this too complicated? maybe we just should reread language list?
                                if (ex.IDs != null)
                                {
                                    List<long> failedIDs = new List<long>(ex.IDs);
                                    foreach (int rowHandle in selectedIds)
                                    {
                                        Domain.Language lang = (Domain.Language) gridViewLanguages.GetRow(rowHandle);
                                        if (failedIDs.Contains(lang.ID))
                                        {
                                            continue;
                                        }
                                        gridViewLanguages.DeleteRow(rowHandle);
                                    }
                                }
                                ErrorMessage(GetLocalized("SomeLanguagesNotDeleted"));
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Control properties

        protected Domain.Language GetEntityByRowHandle(int rowHandle)
        {
            if (gridViewLanguages.IsDataRow(rowHandle))
            {
                return (Domain.Language) gridViewLanguages.GetRow(rowHandle);
            }

            return null;
        }

        public Domain.Language FocusedEntity
        {
            get { return GetEntityByRowHandle(gridViewLanguages.FocusedRowHandle); }
        }

        public int CountEntities
        {
            get { return gridViewLanguages.RowCount; }
        }

        #endregion

        #region Popup menu events

        private void menuLanguages_Opening(object sender, CancelEventArgs e)
        {
            menuItem_newLanguage.Enabled = CanEditLanguage;
            menuItem_EditLanguage.Enabled = CanEditLanguage;
            menuItem_DeleteLanguage.Enabled = CanDeleteLanguage;
            menuItem_TranslateLanguage.Enabled = CanTranslateLanguage;
        }

        private void menuItem_newLanguage_Click(object sender, EventArgs e)
        {
            NewEntity();
        }

        private void menuItem_EditLanguage_Click(object sender, EventArgs e)
        {
            EditEntity(null);
        }

        private void menuItem_DeleteLangauge_Click(object sender, EventArgs e)
        {
            DeleteEntity(null);
        }

        #endregion

        #region Menu Item State function

        public bool CanNewLanguage
        {
            get { return !ReadOnly; }
        }

        public bool CanEditLanguage
        {
            get
            {
                Domain.Language language = FocusedEntity;
                return language != null && !ReadOnly;
            }
        }

        public bool CanDeleteLanguage
        {
            get
            {
                Domain.Language language = FocusedEntity;
                return language != null && !ReadOnly;
            }
        }

        public bool CanTranslateLanguage
        {
            get { return (_bindingLanguageList != null) && (_bindingLanguageList.Count > 0 && !ReadOnly); }
        }

        #endregion

        private void gridViewLanguages_RowCountChanged(object sender, EventArgs e)
        {
            if (OnFocusedLanguageChanged != null)
            {
                OnFocusedLanguageChanged(FocusedEntity);
            }
        }

        private void gridViewLanguages_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (OnFocusedLanguageChanged != null)
            {
                OnFocusedLanguageChanged(FocusedEntity);
            }
        }

        private void gridControlLanguages_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridViewLanguages.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewLanguages.IsDataRow(info.RowHandle))
            {
                EditEntity(null);
            }
        }

        private void menuItem_RefreshLanguages_Click(object sender, EventArgs e)
        {
            InitData();
        }

        private void menuItem_TranslateLanguage_Click(object sender, EventArgs e)
        {
            if (OnActionNeeded != null)
            {
                OnActionNeeded();
            }
        }

        private void gridViewLanguages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Control)
            {
                BuildEnglishLanguage();
            }
        }

        private void BuildEnglishLanguage()
        {
            if (!ReadOnly)
            {
                ItemResource[] ress =
                    Baumax.Localization.DefaultDiction.GetEnglishResource();

                Domain.Language ll = ClientEnvironment.LanguageService.CreateEntity();

                ll.Name = "English";
                ll.LanguageCode = "EN-US";

                ll = ClientEnvironment.LanguageService.Save(ll);

                List<UIResource> _lst = new List<UIResource>();
                UIResource uires = null;
                foreach (ItemResource res in ress)
                {
                    _lst.Add(new UIResource(res.Key, ll.ID, res.Value));
                }

                ClientEnvironment.LanguageService.UpdateResources(_lst);
            }
        }
    }
}