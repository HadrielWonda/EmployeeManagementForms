using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract.Import
{
	[Serializable]
	public class ImportDaysData
	{
		public long CountryID;
		public DateTime Date;

		public ImportDaysData()
		{

		}

		public ImportDaysData(long countryID, DateTime date)
		{
			CountryID = countryID;
			Date = date;
		}

	}
}
