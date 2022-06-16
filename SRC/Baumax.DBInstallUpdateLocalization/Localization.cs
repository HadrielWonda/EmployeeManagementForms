using System;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Collections;
using System.Collections.Generic;

namespace Baumax.DBIULocalization
{
	public class Localization
	{
		Resources res;
		public Resources Resources
		{
			get 
			{
				if(null == res)
					res = new Resources();
				return res;
			}
		}

		Locale[] locales;
		public Locale[] Locales
		{
			get { return locales; }
		}

		private static volatile Localization localization;
		private static object syncRoot = new Object();

		private Localization()
		{
			locales = getLocaleList();
		}

		static public Localization Instance
		{
			get
			{
				if (localization == null)
				{
					lock (syncRoot)
					{
						if (localization == null)
						{
							localization = new Localization();
						}
					}
				}
				return localization;
			}
		}

		private void objectSave(string fileName, object obj)
		{
			try
			{
				using (StreamWriter writer = new StreamWriter(fileName))
				{
					XmlSerializer serializer = new XmlSerializer(obj.GetType());
					serializer.Serialize(writer, obj);
				}
			}
			catch { }
		}

		public void ResourcesSave(string fileName)
		{
			objectSave(fileName, Resources);
		}

		public void ResourcesLoad(string localeFileName)
		{
			using (Stream stream = getResourceStream(localeFileName))
			{
				try
				{
					XmlSerializer serializer = new XmlSerializer(typeof(Resources));
					res = (Resources)serializer.Deserialize(stream);
				}
				catch { }
			}
		}

		public void ResourcesLoad(Locale locale)
		{
			ResourcesLoad(locale.LocaleFileName);
		}

		private Stream getResourceStream(string name)
		{
			Assembly assembly = this.GetType().Assembly;
			name = string.Format("{0}.{1}", assembly.GetName().Name, name.Replace('\\', '.'));
			return assembly.GetManifestResourceStream(name);
		}

		private Locale[] getLocaleList()
		{
			List<Locale> localeList = new List<Locale>();
			XmlDocument xmlDoc = new XmlDocument();
			using (StreamReader sr = new StreamReader(getResourceStream("Resources.xml")))
			xmlDoc.LoadXml(sr.ReadToEnd());
			XmlNode sec = xmlDoc["resources"];
			if (sec != null)
			{
				IEnumerator ie = sec.GetEnumerator();
				XmlNode node;
				while (ie.MoveNext())
				{
					node = (XmlNode)ie.Current;
					if (node.Name == "locale")
						localeList.Add(new Locale(node.Attributes["desc"].Value, node.Attributes["path"].Value));
				}
			}
			return localeList.ToArray();
		}

	}
}
