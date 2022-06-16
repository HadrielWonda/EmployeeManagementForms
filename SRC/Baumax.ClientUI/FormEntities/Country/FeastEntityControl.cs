using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Baumax.Domain;
using Baumax.TestGUIClient.Templates;
namespace Baumax.TestGUIClient.UI.FormEntities.Country
{
    public partial class FeastEntityControl : Baumax.TestGUIClient.UI.FormEntities.UCBaseEntity
    {
        public FeastEntityControl()
        {
            InitializeComponent();
        }

        private Domain.Country  _country;

        public Domain.Country  Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public Feast[] GetNewFeasts()
        {
            Feast[] _arr = new Feast[_bindingFeasts.Count];
            _bindingFeasts.CopyTo(_arr, 0);
            return _arr;
        }
        protected override void BindData()
        {
            base.BindData();
            gridControl1.DataSource = _bindingFeasts;
        }

        BindingTemplate<Feast> _bindingFeasts = new BindingTemplate<Feast>();

        private void dateNavigator1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            DateTime dt = dateNavigator1.DateTime;

            Feast feast = new Feast();
            feast.Country = Country;
            feast.Date = dt;
            _bindingFeasts.Add(feast);

            Modified = true;
        }
    }
}

