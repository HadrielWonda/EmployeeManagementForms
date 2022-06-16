using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Spring.Context;
using Spring.Context.Support;

namespace Baumax.LocalServices
{
    class LocalLanguageService : LocalBaseCachingService<Language>, ILanguageService
    {
        private ILanguageService RemoteService
        {
            get { return (ILanguageService)_remoteService; }
        }

        public List<UIResource> GetResources(long id)
        {
            return RemoteService.GetResources(id);
        }

        public void UpdateResources(List<UIResource> lst)
        {
             RemoteService.UpdateResources(lst);
        }

        public LanguageCheckError CheckLanguage(string l_name, string l_code, long id)
        {
            if (CachingPolicy == CachingPolicy.Dictionary)
            {
                RefreshCacheIfNeed();
                IList<Language> lst = _cache.GetAll();
                bool bNew = id <= 0;
                foreach (Language l in lst)
                {
                    if (bNew || l.ID != id)
                    {
                        if (l.Name == l_name)
                        {
                            return LanguageCheckError.LanguageNameExists;
                        }
                        /*if (l.LanguageCode == l_code)
                        {
                            return LanguageCheckError.LanguageCodeExists;
                        }*/
                    }

                }
                return LanguageCheckError.OK;
            }
            else
            {
                return RemoteService.CheckLanguage(l_name, l_code, id);
            }
        }
    }
}
