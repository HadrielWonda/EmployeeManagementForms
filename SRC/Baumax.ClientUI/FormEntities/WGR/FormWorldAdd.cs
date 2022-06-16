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
    public partial class FormWorldAdd : FormBaseEntity
    {

        public Domain.World World
        {
            get { return _myEntity.World; }
            set { _myEntity.World = value; }
        }

        public FormWorldAdd()
        {
            InitializeComponent();
            EntityControl = _myEntity;
        }
    }
}