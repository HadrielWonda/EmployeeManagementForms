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
    public partial class FormAssignWgrToHwgr : FormBaseEntity 
    {
        public FormAssignWgrToHwgr()
        {
            InitializeComponent();
            EntityControl = ucEditWgrToHwgr1;
        }
        public StoreStructureContext Context
        {
            get { return ucEditWgrToHwgr1.Context; }
            set { ucEditWgrToHwgr1.Context = value; }
        }
	
    }
}