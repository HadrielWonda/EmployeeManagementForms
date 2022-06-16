using System;
using System.Collections;
using System.Text;

namespace Baumax.Contract.QueryResult
{
	[Serializable]
	public class SaveDataResult
	{
		public bool Success;
		public IList Data;
	}
}
