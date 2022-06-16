using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Baumax.Environment.Interfaces;
using log4net;

namespace Baumax.Environment
{
	/// <summary>
	/// On idle service.
	/// </summary>
	public class OnIdleService : IOnIdleService
	{
		#region Fields

		//
		private static readonly ILog Log = LogManager.GetLogger(typeof(OnIdleService));
		//
		private readonly List<IOnIdleTask> _tasks = new List<IOnIdleTask>();
		private bool _registered;
		private bool _stop;
		private bool _cycleRunning;

		#endregion

		#region IStartable implementation

		//
		public virtual void Start()
		{
			Log.Info("Start");
		}

		//
		public virtual void Stop()
		{
			Log.Info("Stop");
			_stop = true;
			RemoveAllTasks();
		}

		#endregion

		#region IOnIdleService implementation

		/// <summary>
		/// Add new task.
		/// </summary>
		/// <param name="idleTask">Task.</param>
		public void AddTask(IOnIdleTask idleTask)
		{
			if(idleTask == null)
			{
				throw new ArgumentNullException("idleTask");
			}
			lock(_tasks)
			{
				idleTask.Service = this;
				_tasks.Add(idleTask);
				if(!_registered)
				{
					Application.Idle += StartCycle;
					_registered = true;
				}
			}
		}

		/// <summary>
		/// Remove task.
		/// </summary>
		/// <param name="idleTask">Task.</param>
		public void RemoveTask(IOnIdleTask idleTask)
		{
			if(idleTask != null)
			{
				lock(_tasks)
				{
					if(_tasks.Contains(idleTask))
					{
						_tasks.Remove(idleTask);
						if(_registered && _tasks.Count == 0)
						{
							Application.Idle -= StartCycle;
							_registered = false;
						}
					}
				}
			}
		}

		/// <summary>
		/// Remove all tasks.
		/// </summary>
		public void RemoveAllTasks()
		{
			lock(_tasks)
			{
				_tasks.Clear();
				if(_registered)
				{
					Application.Idle -= StartCycle;
					_registered = false;
				}
			}
		}

		#endregion

		#region OnIdleService implementation

		/// <summary>
		/// Start circle.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event args.</param>
		private void StartCycle(object sender, EventArgs e)
		{
			lock(this)
			{
				if(_cycleRunning || _stop)
				{
					return;
				} else
				{
					_cycleRunning = true;
				}
			}
			IOnIdleTask[] taskArray;
			lock(_tasks)
			{
				taskArray = _tasks.ToArray();				
			}
			foreach(IOnIdleTask task in taskArray)
			{
				try
				{
					task.Execute();
				} catch(Exception ex)
				{
					Log.Error("Error task execution", ex);
				}
				Application.DoEvents();
			}
			_cycleRunning = false;
		}

		#endregion
	}
}