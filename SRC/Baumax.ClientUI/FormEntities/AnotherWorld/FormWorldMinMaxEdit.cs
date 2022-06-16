using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Baumax.Domain;
using Baumax.Localization;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public partial class FormWorldMinMaxEdit : FormBaseEntity
    {
        public FormWorldMinMaxEdit()
        {
            InitializeComponent();
            EntityControl = uc;
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
                PersonMinMax p = (value as StoreStructureContext).TakePersonMinMax.PersonMinMax;
                if (p != null)
                    lbAddRecord.Text = (p.IsNew)
                        ? Localizer.GetLocalized("AddPersonMinMax")
                        : Localizer.GetLocalized("EditPersonMinMax");
            }
        }
    }
}