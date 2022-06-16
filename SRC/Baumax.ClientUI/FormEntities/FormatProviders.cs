using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.ClientUI.FormEntities
{
    public class IntToTimeFormatProvider : ICustomFormatter, IFormatProvider
    {
        public object GetFormat(Type type)
        {

            if (type == typeof(ICustomFormatter))
            {
                return this;

            }
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            int value = Convert.ToInt32(arg);

            int hour = value / 60;
            int minute = value % 60;

            return String.Format("{0:d2}:{1:d2}", hour, minute);
        }
    }
}
