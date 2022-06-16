using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class FormAssignHwgrToWorld : FormBaseEntity 
    {
        public StoreStructureContext Context
        {
            get { return ucEditWorldToHwgr1.Context; }
            set { ucEditWorldToHwgr1.Context = value; }
        }

        public FormAssignHwgrToWorld()
        {
            InitializeComponent();
            EntityControl = ucEditWorldToHwgr1;
        }
    }
}