using System;
using System.Collections.Generic;

namespace Baumax.Scheduler
{
	/// <summary>
	/// Comparer for ScheduledTasks; tasks are compared by NextDateTime. 
	/// </summary>
	internal sealed class TriggerComparer : IComparer<ITrigger>
	{
		#region IComparer<Task> Members

		public int Compare(ITrigger lhs, ITrigger rhs)
		{
			if(lhs == rhs)
			{
				return 0;
			}
			if(lhs == null)
			{
				return -1;
			}
			if(rhs == null)
			{
				return 1;
			}
			int result = DateTime.Compare(lhs.NextDateTime, rhs.NextDateTime);

			return result;
		}

		#endregion
	}
}