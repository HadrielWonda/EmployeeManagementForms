using System;
using System.Collections.Generic;
using System.Collections;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Templates;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.UIControls
{
    public partial class LanguageLookUpList : XtraUserControl
    {
        BindingTemplate<Language> _listLanguages = null;

        public LanguageLookUpList()
        {
            InitializeComponent();
        }
        
        
        public long LanguageID
        {
            get { return SelectedLanguageID; }
            set { SelectedLanguageID = value; }
        }
        
        public Language Language
        {
            get
            {

                long id = SelectedLanguageID;
                if (id != -1)
                    return _listLanguages.GetItemByID(id);
                else return null;
                
            }
        }

        long SelectedLanguageID
        {
            get
            {
                long id = -1;
                if (lookUpEdit1.EditValue != null) id = Convert.ToInt64(lookUpEdit1.EditValue);
                return id;
            }
            set
            {
                lookUpEdit1.EditValue = value;
            }
        }

        public void InitControl()
        {
            if (_listLanguages == null)
            {
                List<Language> lst = ClientEnvironment.LanguageService.FindAll();

                _listLanguages = new BindingTemplate<Language>();
                _listLanguages.CopyList(lst);
                lookUpEdit1.Properties.DataSource = _listLanguages;
            }
        }

        public void InitControl(IList listLanguages)
        {
            if (listLanguages != null)
            {
                if (_listLanguages == null)
                {
                    _listLanguages = new BindingTemplate<Language>();
                }

                _listLanguages.Clear();
                _listLanguages.CopyList(listLanguages);

                if (lookUpEdit1.Properties.DataSource == null)
                    lookUpEdit1.Properties.DataSource = _listLanguages;
            }
        }
    }
}
