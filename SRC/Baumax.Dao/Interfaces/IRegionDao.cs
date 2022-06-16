using System;
using System.Collections;
using System.Collections.Generic;
using Baumax.Domain;

namespace Baumax.Dao
{
	public interface IRegionDao: IDao<Region>
	{
        IList GetUserRegions(long userId);
	}
}
