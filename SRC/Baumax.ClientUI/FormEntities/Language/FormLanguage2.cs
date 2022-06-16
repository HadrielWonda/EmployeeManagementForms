namespace Baumax.ClientUI.FormEntities.Language
{
    public partial class FormLanguage2 : FormBaseEntity 
    {
        public FormLanguage2()
        {
            InitializeComponent();
            EntityControl = ucLanguageEntity1;
            this.Text = "    ";
            button_Cancel.Left = 177;
        }


        public Domain.Language Language
        {
            get
            {
                return ucLanguageEntity1.Language;
            }
            set
            {
                ucLanguageEntity1.Language = value;

                lblCaption.Text = GetLocalized("editlanguage");
                if (ucLanguageEntity1.Language != null && ucLanguageEntity1.Language.IsNew)
                {
                    lblCaption.Text = GetLocalized("newlanguage");
                }
            }

        }
    }
}