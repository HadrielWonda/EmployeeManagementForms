using System;

namespace Baumax.Scheduler
{
	/// <summary>
	/// 
	/// </summary>
	public class SchedulerErrorEventArgs : EventArgs
	{
		//
		private readonly Object m_task;
		private readonly Exception m_error;
		//
		public SchedulerErrorEventArgs(Object task, Exception error)
		{
			m_task = task;
			m_error = error;
		}

		//
		public Object Task
		{
			get { return m_task; }
		}

		//
		public Exception Error
		{
			get { return m_error; }
		}
	}
}