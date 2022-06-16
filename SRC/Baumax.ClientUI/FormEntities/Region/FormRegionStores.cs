using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.Region
{
    public partial class FormRegionStores : FormBaseEntity 
    {
        public FormRegionStores()
        {
            InitializeComponent();
            EntityControl = ucRegionStores1;
        }

        public override object Entity
        {
            get
            {
                return base.Entity;
            }
            set
            {
                base.Entity = value;

                if (value != null)
                {
                    if (Entity is Domain.Region)
                        lblRegionName.Text = string.Format("{0} : {1}", GetLocalized("Region"), (Entity as Domain.Region).Name);
                    else 
                        lblRegionName.Text = GetLocalized("Region");
                }
            }
        }
    }
}