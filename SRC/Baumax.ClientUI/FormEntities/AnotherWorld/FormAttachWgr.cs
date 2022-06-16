using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class FormAttachWgr : FormBaseEntity
    {
        [Browsable(false)]
        public string EntityName
        {
            get { return uc.EntityName; }
            set { uc.EntityName = value; }
        }
        [Browsable(false)]
        public HwgrToWgr Attached
        {
            get { return uc.Attached; }
            set { uc.Attached = value; }
        }
	

        public FormAttachWgr()
        {
            InitializeComponent();
            EntityControl = uc;
            uc.BeginTime = DateTime.Now;
            uc.EndTime = DateTime.Now;
        }

        public void Bind(ViceHWGR hwgr)
        {
            uc.Bind(hwgr);
        }
    }
}