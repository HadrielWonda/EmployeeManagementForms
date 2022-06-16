using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.FormEntities.Controls
{
    class LanguageLookUpCtrl : LookUpEdit
    {
        public LanguageLookUpCtrl():base()
        {
        }

        private void InitControl()
        {
            if (Properties.Columns.Count != 1)
            {
                Properties.Columns.Clear();
                Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Language", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
                Properties.DisplayMember = "Name";
                Properties.NullText = "";
                Properties.ShowFooter = false;
                Properties.ValueMember = "ID";

            }

        }

        private List<Domain.Language> m_LanguageList = null;

        public List<Domain.Language> LanguageList
        {
            get
            {
                return m_LanguageList;
            }
            set
            {
                if (m_LanguageList != value)
                {
                    InitControl();
                    m_LanguageList = value;
                    Properties.DataSource = m_LanguageList;

                    if (m_LanguageList != null && m_LanguageList.Count > 0)
                    {
                        CurrentLanguageId = m_LanguageList[0].ID;
                    }
                }
            }
        }
        
        public Domain.Language CurrentLanguage
        {
            get
            {
                long lid = CurrentLanguageId;

                if (lid != 0)
                {
                    for (int i = 0; i < LanguageList.Count; i++)
                        if (LanguageList[i].ID == lid) return LanguageList[i];
                }

                return null;
            }
        }
        public long CurrentLanguageId
        {
            get
            {
                if (EditValue != null && LanguageList != null)
                    return Convert.ToInt64(EditValue);
                else return 0;
            }
            set
            {
                if (LanguageList != null)
                {
                    EditValue = value;
                }
            }
        }
    }
}
