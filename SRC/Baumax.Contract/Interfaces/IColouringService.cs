using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface IColouringService : IBaseService<Colouring>
    {
        List<Colouring> GetCountryColouring(long countryID);
    }
}