using System;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Environment;

namespace Baumax.ClientUI.FormEntities.Language
{
    public partial class UCLanguageEntity : UCBaseEntity
    {
        public UCLanguageEntity()
        {
            InitializeComponent();
        }

        private Domain.Language _language;

        public Domain.Language Language
        {
            get { return _language; }
            set
            {
                _language = value;
                SetData();
            }
        }

        void SetData()
        {
            if (Language != null)
            {
                textEditName.Text = Language.Name;
                //textEditCode.Text = Language.LanguageCode;
            }
        }

        public override bool Commit()
        {
            if (Language != null)
            {
                String l_name = textEditName.Text.Trim();
                if (l_name != Language.Name)
                {
                    Language.Name = l_name;
                    Modified = true;
                }
                /*l_name = textEditCode.Text.Trim();
                if (l_name != Language.LanguageCode)
                {
                    Language.LanguageCode = l_name;
                    Modified = true;
                }*/
                if (Modified)
                {
                    if (Language.IsNew)
                    {
                        try
                        {
                            Domain.Language l = ClientEnvironment.LanguageService.Save(Language);
                            Language.ID = l.ID;
                            NotificationService.OnChangedLanguage(Language);
                        }
                        catch (DBDuplicateKeyException)
                        {
                            ErrorMessage(GetLocalized("languagenameexists"));
                            return false;
                        }
                        catch (EntityException ex)
                        {
                            // 2think: what details should we show?
                            // 2think: how to localize?
                            using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                            {
                                form.Text = GetLocalized("CannotSaveLanguage");
                                form.ShowDialog(this);
                            }
                            return false;
                        }
                    }
                    else
                    {
                        try
                        {
                            ClientEnvironment.LanguageService.SaveOrUpdate(Language);
                            NotificationService.OnChangedLanguage(Language);
                        }
                        catch (DBDuplicateKeyException)
                        {
                            ErrorMessage(GetLocalized("languagenameexists"));
                            return false;
                        }
                        catch (EntityException ex)
                        {
                            // 2think: what details should we show?
                            // 2think: how to localize?
                            using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
                            {
                                form.Text = GetLocalized("CannotSaveLanguage");
                                form.ShowDialog(this);
                            }
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public override bool IsValid()
        {
            String l_name = textEditName.Text.Trim();
            if (l_name.Length == 0)
            {
                ErrorMessage(GetLocalized("enterlanguagename"));
                textEditName.Focus();
                return false;
            }
            string l_code = String.Empty;
            /*string l_code = textEditCode.Text.Trim();
            if (l_code.Length == 0)
            {
                ErrorMessage("Enter language code");
                textEditCode.Focus();
                return false;
            }
            */
            LanguageCheckError error =
                ClientEnvironment.LanguageService.CheckLanguage(l_name, l_code, Language.ID);

            if (error == LanguageCheckError.LanguageNameExists)
            {
                ErrorMessage(GetLocalized("languagenameexists"));
                textEditName.Focus();
                return false;
            }
            /*else if (error == LanguageCheckError.LanguageCodeExists )
            {
                ErrorMessage("Language code exists");
                textEditCode.Focus();
                return false;
            }*/
            return true;
        }
    }
}