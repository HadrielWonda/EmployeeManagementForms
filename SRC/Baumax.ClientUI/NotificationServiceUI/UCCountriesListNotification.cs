using System;
using System.Collections.Generic;
using System.ComponentModel;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Localization;
using DevExpress.XtraEditors;

namespace Baumax.ClientUI.NotificationServiceUI
{
	public partial class UCCountriesListNotification : XtraUserControl
	{
		public UCCountriesListNotification()
		{
			InitializeComponent();
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			//
			if (ClientEnvironment.IsRuntimeMode)
			{
				new ControlLocalizer(UILocalizer.Current, this);
			}
		}

		public IList<Country> DataSource
		{
			set
			{
				if (value != null)
				{
					foreach (Country c in value)
					{
						if (c.LanguageID > 0)
						{
							Language lng = ClientEnvironment.LanguageService.FindById(c.CountryLanguage);
							c.LanguageName = (lng != null) ? lng.Name : String.Empty;
						}
					}
				}
				gridControlCountries.DataSource = value;
			}
		}
	}
}