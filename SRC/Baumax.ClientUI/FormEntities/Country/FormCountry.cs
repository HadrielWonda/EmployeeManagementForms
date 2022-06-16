namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class FormCountry : FormBaseEntity
    {
        private Domain.Country _country;

        public Domain.Country Country
        {
            get { return _country; }
            set
            {
                _country = value;
                BindControls();
            }
        }

        public FormCountry()
        {
            InitializeComponent();
        }

        private void BindControls()
        {
            textEditName.DataBindings.Clear();
            textEditName.DataBindings.Add("EditValue", _country, "NameWrapper");
        }
    }
}