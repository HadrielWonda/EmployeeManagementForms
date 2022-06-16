using System;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using BaumaxLocalizer = Baumax.Localization.Localizer;
using DXLocalizer = DevExpress.XtraEditors.Controls.Localizer;

namespace Baumax.ClientUI
{
	public class DevExLocalizer : DXLocalizer
	{
		private const string StrStringId = "StringId.";

		private static DevExLocalizer _instance;

		private DevExLocalizer() {}

		public static void InitDevExLocalizer()
		{
			if (_instance == null)
			{
				_instance = new DevExLocalizer();
			}
			Active = _instance;
		}

		public override string GetLocalizedString(StringId id)
		{
			string localized = BaumaxLocalizer.GetLocalized(StrStringId + id);
			if (String.IsNullOrEmpty(localized))
			{
				localized = base.GetLocalizedString(id);
			}

			return localized;
		}
	}

	public class DevExGridLocalizer : GridLocalizer
	{
		private const string StringGridStringId = "GridStringId.";

		private static DevExGridLocalizer _instance;

		private DevExGridLocalizer() {}

		public static void InitDevExGridLocalizer()
		{
			if (_instance == null)
			{
				_instance = new DevExGridLocalizer();
			}
			Active = _instance;
		}

		public override string GetLocalizedString(GridStringId id)
		{
			string localized = BaumaxLocalizer.GetLocalized(StringGridStringId + id);
			if (String.IsNullOrEmpty(localized))
			{
				localized = base.GetLocalizedString(id);
			}

			return localized;
		}
	}
}