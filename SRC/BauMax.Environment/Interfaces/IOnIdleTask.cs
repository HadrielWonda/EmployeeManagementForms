using System;

namespace Baumax.Environment.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	public interface IOnIdleTask
	{
		/// <summary>
		/// Set "on idle" service.
		/// </summary>
		/// <param name="value"></param>
		IOnIdleService Service { get; set; }

		/// <summary>
		/// Execute.
		/// </summary>
		void Execute();
	}
}