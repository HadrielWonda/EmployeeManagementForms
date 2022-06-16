using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.World
{
    public partial class UCWorldDetails : UCBaseEntity 
    {
        List<WorldDetailItem> _listDetails = new List<WorldDetailItem>();
        public UCWorldDetails()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            seYear.Value = DateTime.Today.Year;
            BuildDetailList();
        }
        private void ClearList()
        {
            foreach (WorldDetailItem item in _listDetails)
                item.Value = 0;

            gridView1.RefreshData();
        }
        protected override void EntityChanged()
        {
            base.EntityChanged();

            if (Entity == null)
                ClearList();
            else
            {

            }
        }

        public void BuildDetailList()
        {
            _listDetails.Clear();
            Array vals = Enum.GetValues(typeof(WorldDetailType));
            foreach (int i in vals)
            {
                WorldDetailItem item = new WorldDetailItem();
                item.DetailType = (WorldDetailType)i;
                item.DetailName = item.DetailType.ToString();
                item.Value = 0;

                _listDetails.Add(item);
            }
            gridControl1.DataSource = _listDetails;
        }
        public Domain.StoreToWorld EntityStoreWorld
        {
            get
            {
                return (Domain.StoreToWorld)Entity;
            }
        }

    }
}
