using Baumax.ClientUI.NotificationServiceUI;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.ClientUI
{
	public static class NotificationService
	{
		// TO-DO Need write accesor add /remove 
		public static event NotifyChangedLanguage ChangedLanguage = null;
		public static event NotifyChangedLanguageUI ChangedLanguageUI = null;

		public static void OnChangedLanguage(Language entity)
		{
			if(ChangedLanguage != null)
			{
				ChangedLanguage(entity);
			}
		}

		public static void OnChangedLanguageUI()
		{
			if(ChangedLanguageUI != null)
			{
				ChangedLanguageUI();
			}
		}

		#region Notifications shown at application startup

		public static void RunDataCheck()
		{
			NotificationsCheckController checkController = new NotificationsCheckController();
			checkController.Start();
		}

		#endregion
	}

	public delegate void NotifyChangedLanguage(Language entity);

	public delegate void NotifyChangedLanguageUI();
}