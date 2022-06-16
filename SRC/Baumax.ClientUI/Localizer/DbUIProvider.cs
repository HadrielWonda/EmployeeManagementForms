using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Localization;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI
{
    public class DbUIProvider : Dictionary<long, UIResource>, IUIProvider
    {
        private long m_LanguageId = 0;

        public DbUIProvider(long lid, List<UIResource> lst)
        {
            m_LanguageId = lid;
            FullDiction(lst);
        }

        public DbUIProvider(long lid)
        {
            m_LanguageId = lid;
            List<UIResource> lst = ClientEnvironment.LanguageService.GetResources(lid);
            FullDiction(lst);
        }


        private void FullDiction(List<UIResource> lst)
        {
            this.Clear();
            if (lst != null)
            {
                foreach (UIResource res in lst)
                {
                    if (LanguageId == res.LanguageID ) 
                        this.Add(res.ResourceID, res);
                }
            }
        }

        public string this[int idx]
        {
            get
            {
                UIResource value = null;
                if (this.TryGetValue(idx, out value))
                {
                    return value.Resource;
                }
                return null;
            }
        }

        public long LanguageId
        {
            get
            {
                return m_LanguageId;
            }
        }
    }
}
