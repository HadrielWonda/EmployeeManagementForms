namespace Baumax.Environment.Interfaces
{
	/// <summary>
	/// 
	/// </summary>
	public interface IOnIdleService
	{
		/// <summary>
		/// Add new task.
		/// </summary>
		/// <param name="idleTask">Task.</param>
		void AddTask(IOnIdleTask idleTask);

		/// <summary>
		/// Remove task.
		/// </summary>
		/// <param name="idleTask">Task.</param>
		void RemoveTask(IOnIdleTask idleTask);

		/// <summary>
		/// Remove all tasks.
		/// </summary>
		void RemoveAllTasks();
	}
}