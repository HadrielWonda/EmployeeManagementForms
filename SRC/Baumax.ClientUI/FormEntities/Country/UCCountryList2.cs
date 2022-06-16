using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.ClientUI.Import;
using Baumax.Contract;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class UCCountryList2 : UCBaseEntity
    {
        public UCCountryList2()
        {
            InitializeComponent();
            if (!IsDesignMode)
            {
                isUserGlobaAdministrator = (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value ==
                 (long)UserRoleId.GlobalAdmin);
            }
        }
        private bool _enableContextMenu = true;
        private List<Domain.Country> _countrylist = null;
        private BindingTemplate<Domain.Country> _bindingEntities = null;
        private bool isUserGlobaAdministrator = false;
        /*(ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                                                       * 
                (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value ==
                 (long)UserRoleId.GlobalAdmin); */


        public delegate void ChangeFocusedEntity(BaseEntity entity);

        public event ChangeFocusedEntity OnChangeFocusedEntity = null;

        private BaseEntity _focusedEntity = null;
        private void CheckFocusedEntityAndRaiseEvent()
        {
            BaseEntity entity = FocusedEntity;
            if (entity != _focusedEntity)
            {
                _focusedEntity = entity;
                FireChangeFocusedEntity(entity);
            }
        }


        private void FireChangeFocusedEntity(BaseEntity entity)
        {
            if (OnChangeFocusedEntity != null)
                OnChangeFocusedEntity(entity);
        }

        [DefaultValue(true)]
        public bool EnabledContextMenu
        {
            get
            {
                return _enableContextMenu;
            }
            set
            {
                _enableContextMenu = value;
            }
        }

        private Domain.Country GetEntityByRowHandle(int rowHandle)
        {
            Domain.Country entity = null;
            if (gridViewCountries.IsDataRow(rowHandle))
            {
                entity = (Domain.Country)gridViewCountries.GetRow(rowHandle);
            }
            return entity;

        }
       
        public Domain.Country FocusedEntity
        {
            get
            {
                return GetEntityByRowHandle(gridViewCountries.FocusedRowHandle);
            }
        }

        public List<Domain.Country> CountryList
        {
            get { return _countrylist; }
            set 
            { 
                _countrylist = value;
                InitBindingList();
            }
        }

        private void InitBindingList()
        {
            if (_bindingEntities == null) _bindingEntities = new BindingTemplate<Domain.Country>();
            if (_bindingEntities.Count > 0) _bindingEntities.Clear();

            if (_countrylist != null)
            {
                foreach (Domain.Country c in _countrylist)
                {
                    if (c.LanguageID > 0)
                    {
                        Domain.Language lng = ClientEnvironment.LanguageService.FindById(c.CountryLanguage);
                        c.LanguageName = (lng != null) ? lng.Name : String.Empty;
                    }
                }
                _bindingEntities.CopyList(_countrylist);
            }


            if (gridControlCountries.DataSource == null)
                gridControlCountries.DataSource = _bindingEntities;

        }

        private void gridControlCountries_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridViewCountries.CalcHitInfo(e.X, e.Y);

            if (info.InRowCell && gridViewCountries.IsDataRow(info.RowHandle))
            {
                Domain.Country entity = GetEntityByRowHandle(info.RowHandle);
                if (entity != null) FireEditEntity(entity);
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (!EnabledContextMenu)
            {
                e.Cancel = true;
                return;
            }
            Domain.Country country = FocusedEntity ;
            toolStripMenuItem_ImportCountry.Visible = isUserGlobaAdministrator;
            toolStripMenuItem_EditCountry.Enabled = country != null;
            toolStripMenuItem_CountryDetails.Enabled = country != null;

        }


        private void gridViewCountries_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            CheckFocusedEntityAndRaiseEvent();
        }



        public void FireEditEntity(Domain.Country c)
        {
            if (ReadOnly) return;
            if (FocusedEntity == null && c == null) return;

            using (FormCountryEdit edit = new FormCountryEdit(FocusedEntity))
            {
                edit.ShowDialog();
                return;
            }
            
        }

        public void FireNewEntity()
        {
            if (ReadOnly) return;
			
            if (ImportUI.ImportCountries())
            {
                CountryList = ClientEnvironment.CountryService.FindAll();
            }
        }


        public void ShowCountryDetail()
        {
            if (FocusedEntity != null)
            {
                using (FormCountryRegions regionsForm = new FormCountryRegions())
                {
                    regionsForm.Entity = FocusedEntity;
                    regionsForm.ShowDialog();
                }
            }
            
        }

        public void FireDeleteEntity(Domain.Country c)
        {
            if (ReadOnly) return;

            ShowCountryDetail();
            /*Domain.Country entity = c;
            if (entity == null) entity = FocusedEntity;
            if (entity != null)
            {
                if (QuestionMessageYes(GetLocalized (UiConst.QUESTION_DELETE_COUNTRY)))
                {
                    try
                    {
                        ClientEnvironment.CountryService.DeleteByID(entity.ID);
                        _bindingEntities.Remove(entity);
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage(ex.Message);
                    }
                    
                }
            }*/
        }

        private void toolStripMenuItem_NewCountry_Click(object sender, EventArgs e)
        {
            FireNewEntity();
        }

        private void toolStripMenuItem_EditCountry_Click(object sender, EventArgs e)
        {
            Domain.Country entity = FocusedEntity;
            if (entity != null)
                FireEditEntity(entity);
        }

        private void toolStripMenuItem_DeleteCountry_Click(object sender, EventArgs e)
        {
            Domain.Country entity = FocusedEntity;
            if (entity != null)
                FireDeleteEntity(entity);
        }

        private void gridViewCountries_RowCountChanged(object sender, EventArgs e)
        {
            CheckFocusedEntityAndRaiseEvent();
        }

        private void gridViewCountries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FireEditEntity(null);
            }
            else if (e.KeyCode == Keys.Insert)
            {
                FireNewEntity();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                FireDeleteEntity(null);
            }
        }

        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode )
                LocalizerControl.ComponentsLocalize(components);
        }
    }
}
