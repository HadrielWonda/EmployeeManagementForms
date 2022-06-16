using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using AopAlliance.Intercept;
using Baumax.Environment.Interfaces;

namespace Baumax.Environment
{
	public sealed class RemoteRequestNotificationService : IRemoteRequestNotificationService, IMethodInterceptor
	{
		private delegate void SetVisualisationDelegate(Form form, bool visualize);

		private readonly List<Form> _subscribedForms = new List<Form>();
		private long _invocationsCount;

		#region IRemoteRequestNotificationService Members

		/// <summary>
		/// Subscribes a form for refreshing during remote invocations.
		/// The inheritor should track when the form will be Disposed and un-subscribe it automatically in such case
		/// </summary>
		/// <param name="form">Form to be subscribed</param>
		/// <exception cref="ArgumentNullException">Throw if <paramref name="form"/> is null</exception>
		public void Attach(Form form)
		{
			if (form == null)
			{
				throw new ArgumentNullException("form");
			}
			lock(_subscribedForms)
			{
				if (!_subscribedForms.Contains(form))
				{
					_subscribedForms.Add(form);
					form.Disposed += subscribedFormDisposed;
				}
			}
		}

		/// <summary>
		/// Manually un-subscribe form from refreshing.
		/// </summary>
		/// <param name="form"></param>
		/// <remarks>If the <paramref name="form"/> is not currently subscribed, no exceptions should be thrown</remarks>
		public void Detach(Form form)
		{
			lock(_subscribedForms)
			{
				if (_subscribedForms.Contains(form))
				{
					_subscribedForms.Remove(form);
				}
			}
		}

		// Automatically unsubscribe disposed form
		private void subscribedFormDisposed (object sender, EventArgs e)
		{
			Detach(sender as Form);
		}

		#endregion

		#region IMethodInterceptor Members

		///<summary>
		///
		///            Implement this method to perform extra treatments before and after
		///            the call to the supplied <paramref name="invocation" />.
		///            
		///</summary>
		///
		///<remarks>
		///<p>
		///            Polite implementations would certainly like to invoke
		///            <see cref="M:AopAlliance.Intercept.IJoinpoint.Proceed" />. 
		///            </p>
		///</remarks>
		///
		///<param name="invocation">
		///            The method invocation that is being intercepted.
		///            </param>
		///<returns>
		///
		///            The result of the call to the
		///            <see cref="M:AopAlliance.Intercept.IJoinpoint.Proceed" /> method of
		///            the supplied <paramref name="invocation" />; this return value may
		///            well have been intercepted by the interceptor.
		///            
		///</returns>
		///
		///<exception cref="T:System.Exception">
		///            If any of the interceptors in the chain or the target object itself
		///            throws an exception.
		///            </exception>
		public object Invoke(IMethodInvocation invocation)
		{
			object result = null;
			Exception error = null;

			bool hasActiveInvocations = HasActiveInvocations;
			Interlocked.Increment(ref _invocationsCount);

			if(!hasActiveInvocations)
			{
				SetVisualizationState(true);
			}
			
			Thread invocationWorker = new Thread(delegate()
												 {
													 try
													 {
														 result = invocation.Proceed();
													 }
													 catch (Exception ex)
													 {
														 error = ex;
													 }
												 });
			invocationWorker.IsBackground = true;
			invocationWorker.Start();
			while (invocationWorker.ThreadState == ThreadState.Unstarted || invocationWorker.IsAlive)
			{
				Thread.Sleep(20);
				//DoInvalidate();
			}

			Interlocked.Decrement(ref _invocationsCount);
			if(!HasActiveInvocations)
			{
				SetVisualizationState(false);
			}

			if (error != null)
			{
				throw error;
			}

			return result;
		}

		#endregion

		private void SetVisualizationState(bool visualize)
		{
			Form[] subscribedForms = _subscribedForms.ToArray();
			foreach (Form form in subscribedForms)
			{
				if (form is IRemoteRequestVisualizer)
				{
					SetFormVisualization(form, visualize);
				}
			}
		}

		private void SetFormVisualization(Form form, bool visualize)
		{
			if (form.InvokeRequired)
			{
				form.Invoke(new SetVisualisationDelegate(SetFormVisualization), form, visualize);
			} else
			{
				((IRemoteRequestVisualizer)form).Visualizing = visualize;
			}
		}

		private void DoInvalidate()
		{
			lock (_subscribedForms)
			{
				foreach(Form form in _subscribedForms)
				{
					((IRemoteRequestVisualizer)form).UpdateProgress();
				}
			}
		}
	    
		private static bool ServiceTypeFilter (Type interfaceType, object filterCriteria)
		{
			Type criteriaType = filterCriteria as Type;
			if (criteriaType != null)
			{
				return criteriaType != interfaceType && criteriaType.IsAssignableFrom(interfaceType);
			}
			return false;
		}

		private bool HasActiveInvocations
		{
			get
			{
				return Interlocked.Read(ref _invocationsCount) > 0;
			}
		}
	}
}