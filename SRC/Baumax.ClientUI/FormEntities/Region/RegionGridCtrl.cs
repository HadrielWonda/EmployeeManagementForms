using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.ClientUI;
using Baumax.Contract;
using Baumax.Environment;
using DevExpress.XtraEditors;
using Baumax.Localization;
namespace Baumax.ClientUI.FormEntities.Region
{
    public partial class RegionGridCtrl : UCBaseEntityList
    {
        private IList<Domain.Region> _RegionList;
        public RegionGridCtrl()
        {
            InitializeComponent();
            AddGridColumns(new string[] { "Name", "Import"}, new string[] { "Name", "Imported" });
        }

        public override void Bind()
        {
            base.Bind();
            _RegionList = ClientEnvironment.RegionService.FindAll();
            gridControl.DataSource = RegionList;
        }

        /// <summary>
        /// Add new item
        /// </summary>
        public override void Add()
        {
            Domain.Region r = ClientEnvironment.RegionService.CreateEntity();
            r.LanguageID = ClientEnvironment.LanguageId;
            
            using (RegionFrm frm = new RegionFrm())
            {
                frm.Entity = r;
                if (frm.ShowDialog(this) == DialogResult.OK && frm.Modified)
                {
                    if (r.IsNew)
                        ClientEnvironment.RegionService.Save(r);
                    else
                        ClientEnvironment.RegionService.SaveOrUpdate(r);
                    RefreshData();
                }
            }
        }

        /// <summary>
        /// Edit current item
        /// </summary>
        public override void Edit()
        {
            Domain.Region r = (Domain.Region)mainGridView.GetRow(mainGridView.FocusedRowHandle);
            if (r != null)
            {
                using (RegionFrm frm = new RegionFrm())
                {
                    frm.Entity = r;
                    if (frm.ShowDialog(this) == DialogResult.OK && frm.Modified)
                    {
                        if (r.IsNew)
                            ClientEnvironment.RegionService.Save(r);
                        else
                            ClientEnvironment.RegionService.SaveOrUpdate(r);
                        RefreshData();
                    }
                }
            }
        }

        /// <summary>
        /// Delete selected items
        /// </summary>
        public override void Delete()
        {
            List<long> ids = new List<long>();
            foreach (int rowHandle in mainGridView.GetSelectedRows())
            {
                Domain.Region entity = (Domain.Region)mainGridView.GetRow(rowHandle);
                ids.Add(entity.ID);
            }
            if (XtraMessageBox.Show(this, Localizer.GetLocalized("Are you sure you want to delete selected items"),
                                    Localizer.GetLocalized("Confirm"), MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            ClientEnvironment.RegionService.DeleteListByID(ids);

            RefreshData();
        }

        [Browsable(false)]
        public IList<Domain.Region> RegionList
        {
            get { return _RegionList; }
            set
            {
                if (_RegionList != value)
                {
                    _RegionList = value;
                    RefreshData();
                }
            }
        }

        [Browsable(false)]
        public Domain.Region FocusedEntity
        {
            get
            {
                return (Domain.Region)mainGridView.GetRow(mainGridView.FocusedRowHandle);
            }
        }
    }
}
