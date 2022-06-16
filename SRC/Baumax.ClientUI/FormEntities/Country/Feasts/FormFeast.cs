using System.Windows.Forms;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class FormFeast : FormBaseEntity
    {
        public FormFeast()
        {
            InitializeComponent();

            EntityControl = feastEntityControl1;
        }

        private Domain.Country  _country;

        public Domain.Country  Country
        {
            get { return _country; }
            set 
            {
                if (_country != value)
                {
                    _country = value;
                    feastEntityControl1.Country = _country;
                    lblCaption.Text = GetLocalized("Feasts");
                }
            }
        }

        private void FormFeast_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Escape: if (DoBeforeCancel()) 
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }
    }
}

