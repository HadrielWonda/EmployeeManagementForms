using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.WGR
{
    public partial class FormHwgrAdd : FormBaseEntity
    {
        public FormHwgrAdd()
        {
            InitializeComponent();
            EntityControl = myEntity;
        }

        public Domain.HWGR HWGR
        {
            get { return myEntity.HWGR; }
            set { myEntity.HWGR = value; }
        }
    }
}