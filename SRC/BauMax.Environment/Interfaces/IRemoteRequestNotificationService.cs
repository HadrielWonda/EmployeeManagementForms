using System;
using System.Windows.Forms;

namespace Baumax.Environment.Interfaces
{
	/// <summary>
	/// The interface descibes the service which is intended to un-freeze UI elements during remote invocations.
	/// </summary>
	public interface IRemoteRequestNotificationService
	{
		/// <summary>
		/// Subscribes a form for refreshing during remote invocations.
		/// The inheritor should track when the form will be Disposed and un-subscribe it automatically in such case
		/// </summary>
		/// <param name="form">Form to be subscribed</param>
		/// <exception cref="ArgumentNullException">Throw if <paramref name="form"/> is null</exception>
		void Attach(Form form);

		/// <summary>
		/// Manually un-subscribe form from refreshing.
		/// </summary>
		/// <param name="form"></param>
		/// <remarks>If the <paramref name="form"/> is not currently subscribed, no exceptions should be thrown</remarks>
		void Detach(Form form);
	}
}