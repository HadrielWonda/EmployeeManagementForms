using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Domain;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class FormWorldMinMax : FormBaseEntity
    {
       public FormWorldMinMax()
        {
            InitializeComponent();
        }

        private void FormWorldMinMax_FormClosing(object sender, FormClosingEventArgs e)
        {
            StoreStructureContext context = Entity as StoreStructureContext;
            if (context != null)
                context.TakeWorldDetail.CurrentDetailList.Update(context);
        }
    }
}