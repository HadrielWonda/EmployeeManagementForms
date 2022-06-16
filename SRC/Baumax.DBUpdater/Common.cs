using System;

namespace Baumax.DBUpdater
{
	#region Arguments
	public class MessageEventArgs : EventArgs
	{
		private string message;

		public string Message
		{
			get { return message; }
		}

		public MessageEventArgs(string message)
		{
			this.message = message;
		}
	}
	public class UpdateProgressEventArgs : EventArgs
	{
		private int currValue;
		private int maxValue;

		public int CurrValue
		{
			get { return currValue; }
		}

		public int MaxValue
		{
			get { return maxValue; }
		}

		public UpdateProgressEventArgs(int currValue, int maxValue)
		{
			this.currValue = currValue;
			this.maxValue = maxValue;
		}
	}
	public class UpdateCompleteEventArgs : EventArgs
	{
		private bool success;

		public bool Success
		{
			get { return success; }
		}

		public UpdateCompleteEventArgs(bool success)
		{
			this.success = success;
		}
	}
	#endregion

	#region Delegates
	public delegate void MessageEventHandler(object sender, MessageEventArgs e);
	public delegate void UpdateProgressEventHangler(object sender, UpdateProgressEventArgs e);
	public delegate void UpdateCompleteEventHandler(object sender, UpdateCompleteEventArgs e);
	#endregion
}
