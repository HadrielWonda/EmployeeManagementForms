using System;

namespace Baumax.DBInstaller
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
	public class InstallProgressEventArgs : EventArgs
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

		public InstallProgressEventArgs(int currValue, int maxValue)
		{
			this.currValue = currValue;
			this.maxValue = maxValue;
		}
	}
	public class InstallCompleteEventArgs : EventArgs
	{
		private bool success;

		public bool Success
		{
			get { return success; }
		}

		public InstallCompleteEventArgs(bool success)
		{
			this.success = success;
		}
	}
	#endregion

	#region Delegates
	public delegate void MessageEventHandler(object sender, MessageEventArgs e);
	public delegate void InstallProgressEventHangler(object sender, InstallProgressEventArgs e);
	public delegate void InstallCompleteEventHandler(object sender, InstallCompleteEventArgs e);
	#endregion

}
