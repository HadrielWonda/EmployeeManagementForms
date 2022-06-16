using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public enum LanguageCheckError
    {
        OK,
        LanguageNameExists,
        LanguageCodeExists
    }

    public interface ILanguageService : IBaseService<Language>
    {
        /// <summary>
        /// Gets the localized resources.
        /// </summary>
        /// <param name="langID">The language ID.</param>
        /// <returns>List of resources for language with "langID" key.</returns>
        List<UIResource> GetResources(long langID);

        /// <summary>
        /// Updates the localized resources.
        /// </summary>
        /// <param name="list">The list of resources to insert or update.</param>
        void UpdateResources(List<UIResource> list);

        LanguageCheckError CheckLanguage(string languageName, string languageCode, long id);
    }
}