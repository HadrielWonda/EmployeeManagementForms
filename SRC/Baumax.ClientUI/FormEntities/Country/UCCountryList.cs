using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Baumax.ClientUI;
using Baumax.Contract.Interfaces;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class UCCountryList : UCBaseEntityList
    {
        private IList _countryList;
        private ICountryService _svc = ClientEnvironment.CountryService;

        public UCCountryList()
        {
            InitializeComponent();

            Init();
        }

        public UCCountryList(Form ownerFrom)
            : base(ownerFrom)
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            AddGridColumns(new string[] {"Name"},
                           new string[] {"Name"});
        }

        public override void Bind()
        {
            //DateTime beginDT = DateTime.Now;
            _countryList = _svc.FindAll();
            //System.Diagnostics.Debug.WriteLine(string.Format("countrySvc.GetCountries(CurLangId) time : {0}", (DateTime.Now - beginDT).ToString()));

            gridControl.DataSource = _countryList;
        }

        public override void Add()
        {
            //XtraMessageBox.Show(this, "Add", this.Name, MessageBoxButtons.OK);
            FormCountry2 f = new FormCountry2();
            f.Text = GetLocalized("New Country");
            f.Country = new Domain.Country();
            if (f.ShowDialog(OwnerForm) == DialogResult.OK)
            {
                _svc.SaveOrUpdate(f.Country);
            }

            RefreshData();
        }

        public override void Edit()
        {
            //XtraMessageBox.Show(this, "Edit", this.Name, MessageBoxButtons.OK);
            Domain.Country l = (Domain.Country) mainGridView.GetRow(mainGridView.FocusedRowHandle);
            if (l == null)
            {
                return;
            }
            FormCountry f = new FormCountry();
            f.Text = GetLocalized("Edit Country");
            f.Country = l;
            if (f.ShowDialog(OwnerForm) == DialogResult.OK)
            {
                _svc.SaveOrUpdate(f.Country);
            }

            RefreshData();
        }

        public override void Delete()
        {
            //XtraMessageBox.Show(this, "Delete", this.Name, MessageBoxButtons.OK);
            List<long> ids = new List<long>();
            foreach (int rowHandle in mainGridView.GetSelectedRows())
            {
                Domain.Country entity = (Domain.Country) mainGridView.GetRow(rowHandle);
                ids.Add(entity.ID);
            }
            //--ICountryService countrySvc = (ICountryService) AppCtx.GetObject("countryService");
            //countrySvc.Delete(ids.ToArray());
            _svc.DeleteListByID(ids);

            RefreshData();
        }
    }
}