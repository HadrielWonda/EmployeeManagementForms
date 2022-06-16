using System;

namespace Baumax.DBIULocalization
{
	public struct Locale
	{
		public string LocaleDesc;
		public string LocaleFileName;

		public Locale(string LocaleDesc, string LocaleFileName)
		{
			this.LocaleDesc = LocaleDesc;
			this.LocaleFileName = LocaleFileName;
		}

		public override string ToString()
		{
			return LocaleDesc;
		}
	}
}
