using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Environment;
using Baumax.Contract;
using Baumax.Localization;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class CountryEntityControl : UCBaseEntity 
    {
        public CountryEntityControl()
        {
            InitializeComponent();
        }

        private Domain.Country _country;

        public Domain.Country Country
        {
            get { return _country; }
            set { _country = value; Bind(); }
        }

        void InitLanguages()
        {
            

            languageLookUpList.InitControl();
        }

        public override void Bind()
        {
            base.Bind();
            if (_country != null)
            {
                InitLanguages();

                //textEditBaumaxDescription.Text = _country.SystemID2;
                //spinEditBaumaxID.Value = _country.SystemID1;
                textEditName.Text = _country.Name;
                languageLookUpList.LanguageID = _country.CountryLanguage;
                
            }
        }

        public override bool IsValid()
        {
            string value = textEditName.Text.Trim();
            if (value.Length == 0)
            {
                ErrorMessage(GetLocalized(UiConst.ERROR_ENTER_COUNTRY_NAME));
                textEditName.Focus();
                return false;
            }


            return !ClientEnvironment.CountryService.IsCountryExist(_country.ID, value);

            /*value = textEditBaumaxDescription.Text;

            if (value.Trim().Length == 0)
            {
                ErrorMessage("Enter country description ");
                textEditBaumaxDescription.Focus();
                return false;
            }
           
            short b = Convert.ToByte(spinEditBaumaxID.Value);
            if (b > 255)
            {
                ErrorMessage("Country internal id must be less 256");
                spinEditBaumaxID.Focus();
                return false;
            }
            */

            //return true;
        }

        public override bool Commit()
        {
            if (_country != null)
            {
                long oldid = _country.CountryLanguage;
                long newid = (languageLookUpList.LanguageID);
                if (oldid != newid)
                {
                    Modified = true;
                }
                _country.CountryLanguage = languageLookUpList.LanguageID;
                _country.LanguageID = SharedConsts.NeutralLangId;
                //languageLookUpList.LanguageID;
                    //ClientEnvironment.LogonUser.LanguageID.Value ;

                /*byte b = Convert.ToByte(spinEditBaumaxID.Value);
                if (_country.SystemID1 != b)
                {
                    _country.SystemID1 = b;
                    Modified = true;
                }
                if (_country.SystemID2 != textEditBaumaxDescription.Text)
                {
                    _country.SystemID2 = textEditBaumaxDescription.Text;
                    Modified = true;
                }
                */
                string value = textEditName.Text.Trim();

                if (value != _country.Name)
                {
                    Modified = true;
                    _country.Name = value;
                }
                if (_country.IsNew)
                {
                    Modified = true;
                    try
                    {
                        _country = ClientEnvironment.CountryService.Save(_country);
                    }
                    catch (EntityException ex)
                    {
                        // 2think: what details should we show?
                        // 2think: how to localize?
                        using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                        {
                            form.Text = GetLocalized("CannotSaveCountry");
                            form.ShowDialog(this);
                            return false;
                        }
                    }
                }
                else if (Modified)
                {
                    try
                    {
                        ClientEnvironment.CountryService.SaveOrUpdate(_country);
                    }
                    catch (EntityException ex)
                    {
                        // 2think: what details should we show?
                        // 2think: how to localize?
                        using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                        {
                            form.Text = GetLocalized("CannotSaveCountry");
                            form.ShowDialog(this);
                            return false;
                        }
                    }
                }

                
                if (Modified)
                {
                    if (languageLookUpList.Language != null)
                    {
                        _country.LanguageName = languageLookUpList.Language.Name;
                    }
                }


            }
            return true;
        }
    }
}
