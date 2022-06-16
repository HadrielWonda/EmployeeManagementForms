using System.Collections;
using System.Collections.Generic;
using Baumax.Contract.ZLib;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
	public interface IRegionService : IBaseService<Region>
	{
        IList<Region> GetUserRegions(long userId);
	}
}
