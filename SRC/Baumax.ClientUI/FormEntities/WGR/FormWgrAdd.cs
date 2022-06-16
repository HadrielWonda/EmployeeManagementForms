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
    public partial class FormWgrAdd : FormBaseEntity
    {
        public FormWgrAdd()
        {
            InitializeComponent();
            EntityControl = entity;
        }

        public Domain.WGR WGR
        {
            get { return entity.WGR; }
            set { entity.WGR = value; }
        }

    }
}