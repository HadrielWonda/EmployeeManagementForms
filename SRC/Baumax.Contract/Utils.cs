using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Baumax.Contract
{
    public static class Utils
    {
        private static string LongToString(long value)
        {
            return value.ToString();
        }

        private static string IntToString(int value)
        {
            return value.ToString();
        }

        public static string GetParamsInXml(long[] values, string startElement, string attribName)
        {
            string[] strValues = Array.ConvertAll<long, string>(values, new Converter<long, string>(LongToString));
            return GetParamsInXml(strValues, startElement, attribName);
        }

        public static string GetParamsInXml(int[] values, string startElement, string attribName)
        {
            string[] strValues = Array.ConvertAll<int, string>(values, new Converter<int, string>(IntToString));
            return GetParamsInXml(strValues, startElement, attribName);
        }

        public static string GetParamsInXml(string[] values, string startElement, string attribName)
        {
            const string root = "Root";
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = false;
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement(root);
            for (int i = 0; i < values.Length; i++)
            {
                writer.WriteStartElement(startElement);
                writer.WriteAttributeString(attribName, values[i]);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
            return sb.ToString();
        }

        public static bool IsDelegateSubscribers(Delegate _delegate)
        {
            bool result = false;
            if (_delegate != null)
            {
                lock (_delegate)
                {
                    if (_delegate != null)
                    {
                        Delegate[] list = _delegate.GetInvocationList();
                        result = ((list != null) && (list.Length != 0));
                    }
                }
            }

            return result;
        }
    }
}
