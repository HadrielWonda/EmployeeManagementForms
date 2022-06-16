using System.Collections;
using Baumax.Domain;

namespace Baumax.Dao
{
    public interface IColouringDao : IDao<Colouring>
    {
        IList GetCountryColouring(long countryID);
    }
}