using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Baumax.ClientUI.FormEntities;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Localization;
using Baumax.Templates;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Baumax.ClientUI.Admin
{
    public partial class CountrySelectFrm : FormBaseEntity
    {
        private List<Country> _countrylist = null;
        private BindingTemplate<Country> _bindingEntities = null;

        public CountrySelectFrm()
        {
            InitializeComponent();

            Modified = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                CountryList = ClientEnvironment.CountryService.FindAll();
                button_OK.Text = Localizer.GetLocalized("ButtonSelect");
            }
        }

        public Country SelectedCountry
        {
            get { return FocusedEntity; }
        }

        private Country GetEntityByRowHandle(int rowHandle)
        {
            Country entity = null;
            if (gridViewCountries.IsDataRow(rowHandle))
            {
                entity = (Country) gridViewCountries.GetRow(rowHandle);
            }
            return entity;
        }

        public Country FocusedEntity
        {
            get { return GetEntityByRowHandle(gridViewCountries.FocusedRowHandle); }
        }

        public List<Country> SelectedCountries
        {
            get
            {
                int[] selection = gridViewCountries.GetSelectedRows();
                List<Country> res = new List<Country>(selection.Length);
                foreach (int i in selection)
                {
                    res.Add(GetEntityByRowHandle(i));
                }
                return res;
            }
        }

        public List<Country> CountryList
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
            if (_bindingEntities == null) _bindingEntities = new BindingTemplate<Country>();
            if (_bindingEntities.Count > 0) _bindingEntities.Clear();

            if (_countrylist != null)
            {
                foreach (Country c in _countrylist)
                {
                    if (c.LanguageID > 0)
                    {
                        Language lng = ClientEnvironment.LanguageService.FindById(c.CountryLanguage);
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
                Country entity = GetEntityByRowHandle(info.RowHandle);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}