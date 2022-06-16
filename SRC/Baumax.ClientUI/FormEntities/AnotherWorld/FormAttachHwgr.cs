using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class FormAttachHwgr : FormBaseEntity
    {
        [Browsable(false)]
        public string EntityName
        {
            get { return uc.EntityName; }
            set { uc.EntityName = value; }
        }
        [Browsable(false)]
        public WorldToHwgr Attached
        {
            get { return uc.Attached; }
            set { uc.Attached = value; }
        }
	

        public FormAttachHwgr()
        {
            InitializeComponent();
            EntityControl = uc;
            uc.BeginTime = DateTime.Now;
            uc.EndTime = DateTime.Now;
        }

        public void Bind(ViceWorld world)
        {
            uc.Bind(world);
        }
    }
}