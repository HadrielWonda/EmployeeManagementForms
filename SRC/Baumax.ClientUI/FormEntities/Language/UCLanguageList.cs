using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Baumax.ClientUI;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Language
{
    public partial class UCLanguageList : UCBaseEntityList
    {
        private IList _langList;

        protected UCLanguageList()
        {
            InitializeComponent();

            Init();
        }

        public UCLanguageList(Form ownerFrom)
            : base(ownerFrom)
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            AddGridColumns(new string[] {"Name", "LanguageCode"},
                           new string[] {"Name", "Code"});
        }

        public override void Bind()
        {
            _langList = ClientEnvironment.LanguageService.FindAll();

            gridControl.DataSource = _langList;
        }

        public override void Add()
        {
            FormLanguage f = new FormLanguage();
            f.Text = GetLocalized("New Language");
            f.Language = new Domain.Language();
            if (f.ShowDialog(OwnerForm) == DialogResult.OK)
            {
                ClientEnvironment.LanguageService.SaveOrUpdate(f.Language);
            }

            RefreshData();
        }

        public override void Edit()
        {
            Domain.Language l = (Domain.Language) mainGridView.GetRow(mainGridView.FocusedRowHandle);
            if (l == null)
            {
                return;
            }
            FormLanguage f = new FormLanguage();
            f.Text = GetLocalized("Edit Language");
            f.Language = l;
            if (f.ShowDialog(OwnerForm) == DialogResult.OK)
            {
                ClientEnvironment.LanguageService.SaveOrUpdate(f.Language);
            }

            RefreshData();
        }

        public override void Delete()
        {
            //XtraMessageBox.Show(this, "Delete", this.Name, MessageBoxButtons.OK);
            List<long> ids = new List<long>();
            foreach (int rowHandle in mainGridView.GetSelectedRows())
            {
                Domain.Language lang = (Domain.Language) mainGridView.GetRow(rowHandle);
                ids.Add(lang.ID);
            }
            ClientEnvironment.LanguageService.DeleteListByID(ids);

            RefreshData();
        }
    }
}