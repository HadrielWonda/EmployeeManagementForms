using System;

namespace Baumax.Contract
{
    [Serializable]
    public class MessageInfoEventArgs : EventArgs
    {
        private object _Param;

        public object Param
        {
            get { return _Param; }
            set { _Param = value; }
        }

        public MessageInfoEventArgs(object param)
        {
            _Param = param;
        }
    }

    public delegate void MessageInfoDelegate(object sender, MessageInfoEventArgs e);

    public interface IMessageInfoReceiver
    {
        void ReceiveMessage(object sender, MessageInfoEventArgs e);

        // for local subscription
        event MessageInfoDelegate Message;
    }
}