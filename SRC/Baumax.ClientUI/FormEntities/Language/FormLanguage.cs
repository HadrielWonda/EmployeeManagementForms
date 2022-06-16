namespace Baumax.ClientUI.FormEntities.Language
{
    public partial class FormLanguage : FormBaseEntity
    {
        private Domain.Language _language;

        public Domain.Language Language
        {
            get { return _language; }
            set
            {
                _language = value;
                BindControls();
            }
        }

        public FormLanguage()
        {
            InitializeComponent();
        }

        private void BindControls()
        {
            textEditName.DataBindings.Clear();
            textEditName.DataBindings.Add("EditValue", _language, "Name");

            textEditCode.DataBindings.Clear();
            textEditCode.DataBindings.Add("EditValue", _language, "LanguageCode");
        }
    }
}