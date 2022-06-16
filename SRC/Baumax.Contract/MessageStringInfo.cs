using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.Import;

namespace Baumax.Contract
{
    [Serializable]
    public class MessageStringInfo
    {
        public readonly BusinessVolumeType BusinessVolumeType; 
        public readonly string Message;
        public readonly bool NewLine;
        public bool LocalizeKey;
        public string[] MessageParams;

        public MessageStringInfo(BusinessVolumeType businessVolumeType, string message)
            : this(businessVolumeType,message, true)
        { }

        public MessageStringInfo(BusinessVolumeType businessVolumeType, string message, bool newLine)
            : this(businessVolumeType,message, true, false)
        { }

        public MessageStringInfo(BusinessVolumeType businessVolumeType, string message, bool newLine, bool localizeKey)
        {
            this.BusinessVolumeType = businessVolumeType;
            this.Message = message;
            this.NewLine = newLine;
            this.LocalizeKey = localizeKey;
        }
    }
}
