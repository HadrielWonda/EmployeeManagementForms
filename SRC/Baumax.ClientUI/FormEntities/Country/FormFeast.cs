using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baumax.Domain;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class FormFeast : Baumax.ClientUI.FormEntities.FormBaseEntity
    {
        public FormFeast()
        {
            InitializeComponent();
        }

        private Domain.Country  _country;

        public Domain.Country  Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public Feast[] GetNewFeast()
        {
            return feastEntityControl1.GetNewFeasts();
        }


        public override bool Modified
        {
            get
            {
                return feastEntityControl1.Modified;
            }
        }
    }
}

