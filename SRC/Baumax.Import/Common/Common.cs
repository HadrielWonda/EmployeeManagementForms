using System;
using System.Collections.Generic;
using System.Text;

using Baumax.Contract.Interfaces;

namespace Baumax.Import
{
	public class NotSupported : Exception
	{
		public NotSupported() { }
		public NotSupported(string message)
			: base(message)
		{ }
	}

    public class SameColumnsInImportFile : Exception
    { 
		public SameColumnsInImportFile() { }
        public SameColumnsInImportFile(string message)
			: base(message)
		{ }
    }

    public class UnknownImportFile : Exception
    { 
        public UnknownImportFile() { }
        public UnknownImportFile(string message)
			: base(message)
		{ }

    }

    public class ImportParam
    {
        public ICountryService CountryService;
        public IRegionService RegionService;
        public IStoreService StoreService;
        public IEmployeeService EmployeeService;
    }

    public enum ImportType { Country, Region, Store, World, HWGR, WGR, WorkingDays, Feast, Employee, LongTimeAbsence, Absence, TimePlanning, TimeRecording, ActualBusinessVolume, TargetBusinessVolume, CashRegisterReceipt, All }

	#region Arguments
	public class MessageEventArgs : EventArgs
	{
		private string _message;
        private bool _NewLine;

		public string Message
		{
			get { return _message; }
		}

        public bool NewLine
        {
            get {return _NewLine;}
        }

        public MessageEventArgs(string message)
            : this(message, true)
        { }

		public MessageEventArgs(string message, bool newLine)
		{
			this._message = message;
            this._NewLine = newLine;
		}
	}
	public class ProgressEventArgs : EventArgs
	{
		private int _currValue;
		private int _maxValue;

		public int CurrValue
		{
			get { return _currValue; }
		}
		public int MaxValue
		{
			get { return _maxValue; }
		}

		public ProgressEventArgs(int currValue, int maxValue)
		{
			this._currValue = currValue;
			this._maxValue = maxValue;
		}
	}
	public class CompleteEventArgs : EventArgs
	{
		private bool _success;

		public bool Success
		{
			get { return _success; }
		}

		public CompleteEventArgs(bool success)
		{
			this._success = success;
		}
	}
	#endregion

	#region Delegates
	public delegate void MessageEventHandler(object sender, MessageEventArgs e);
	public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);
	public delegate void CompleteEventHandler(object sender, CompleteEventArgs e);
	#endregion

	//Classes

}
