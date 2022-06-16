using System;
using System.Windows.Forms;
using Baumax.Environment.Interfaces;

namespace Baumax.Environment
{
	public abstract class OnIdleTask : IOnIdleTask
	{
		//
		private IOnIdleService m_service;

		/// <summary>
		/// Set "on idle" service.
		/// </summary>
		/// <param name="value"></param>
		public IOnIdleService Service
		{
			get { return m_service; }
			set
			{
				if(m_service != null && m_service != value)
				{
					throw new InvalidOperationException("Service already assigned.");
				}
				m_service = value;
			}
		}

		/// <summary>
		/// Execute.
		/// </summary>
		public virtual void Execute()
		{
		}

		/// <summary>
		/// Remive task.
		/// </summary>
		protected void RemoveTask()
		{
			if(m_service != null)
			{
				m_service.RemoveTask(this);
			}
		}
	}

	/// <summary>
	/// OnIdlePeriodicTask class
	/// </summary>
	public class OnIdlePeriodicTask : OnIdleTask
	{
		//
		private readonly MethodInvoker _handler = null;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="handler">Event handler.</param>
		public OnIdlePeriodicTask(MethodInvoker handler)
		{
			if(handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			_handler = handler;
		}

		/// <summary>
		/// Execute.
		/// </summary>
		public override void Execute()
		{
			_handler.Invoke();
		}
	}

	/// <summary>
	/// OnIdleSingleStartTask class.
	/// </summary>
	public class OnIdleOneRunTask : OnIdlePeriodicTask
	{
		private bool _executed = false;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="handler">Event handler.</param>
		public OnIdleOneRunTask(MethodInvoker handler) : base(handler)
		{
		}

		/// <summary>
		/// Execute.
		/// </summary>
		public override void Execute()
		{
			if(_executed)
			{
				return;
			}
			lock(this)
			{
				if(_executed)
				{
					return;
				}
				_executed = true;
				base.Execute();
				RemoveTask();
			}
		}
	}
}