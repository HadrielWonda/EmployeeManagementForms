using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.Region
{
    using Baumax.Templates;
    using Baumax.Environment;

    public partial class UCRegionStores : UCBaseEntity 
    {
        BindingTemplate<Domain.Store> _listStores = new BindingTemplate<Baumax.Domain.Store>();
        public UCRegionStores()
        {
            InitializeComponent();
        }

        public Domain.Region EntityRegion
        {
            get
            {
                return (Domain.Region)Entity;
            }
        }

        protected override void EntityChanged()
        {
            base.EntityChanged();
            LoadStores();
        }

        private void LoadStores()
        {
            gridControl.BeginUpdate();
            try
            {
                _listStores.Clear();

                if (EntityRegion != null)
                {
                    List<Domain.Store> lst = ClientEnvironment.StoreService.FindAll();
                    if (lst != null)
                    {
                        foreach (Domain.Store store in lst)
                            if (store.RegionID == EntityRegion.ID) _listStores.Add(store);
                    }
                }

                if (gridControl.DataSource == null)
                    gridControl.DataSource = _listStores;
            }
            finally
            {
                gridControl.EndUpdate();
            }


        }
    }
}
