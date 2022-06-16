using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Baumax.Scheduler
{
    public static class SerializeHelper
    {
        public static string ToXml(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            StringBuilder output = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(output, settings))
            {
                serializer.Serialize(writer, obj);
                writer.Flush();
            }
            return output.ToString();
        }

        public static object FromXml(string xml, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            StringReader textReader = new StringReader(xml);
            return serializer.Deserialize(textReader);
        }
    }
}
