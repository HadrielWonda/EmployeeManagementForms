using System;

namespace Baumax.Contract
{
    [Serializable]
    public class OperationCompleteEventArgs : EventArgs
    {
        private bool _Success;
        private object _Param;

        public bool Success
        {
            get { return _Success; }
            set { _Success = value; }
        }

        public object Param
        {
            get { return _Param; }
            set { _Param = value; }
        }

        public OperationCompleteEventArgs(bool success, object param)
            : this(success)
        {
            _Param = param;
        }

        public OperationCompleteEventArgs(bool success)
        {
            this._Success = success;
        }
    }

    public delegate void OperationCompleteDelegate(object sender, OperationCompleteEventArgs e);

    public interface IOperationCompleteReceiver
    {
        // for remote subscription
        void ReceiveOperationComplete(object sender, OperationCompleteEventArgs e);

        // for local subscription
        event OperationCompleteDelegate OperationComplete;
    }
}