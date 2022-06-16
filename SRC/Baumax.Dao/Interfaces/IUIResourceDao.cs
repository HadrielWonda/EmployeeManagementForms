using System.Collections;
using Baumax.Domain;

namespace Baumax.Dao
{
    public interface IUIResourceDao : IDao<UIResource>
    {
        /// <summary>
        /// Finds all resources for specified language.
        /// </summary>
        /// <param name="langID">The language ID.</param>
        /// <returns>List of localized resources</returns>
        IList FindForLanguage(long langID);
    }
}