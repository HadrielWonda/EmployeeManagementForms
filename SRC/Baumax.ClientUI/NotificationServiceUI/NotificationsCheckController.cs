using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Localization;

namespace Baumax.ClientUI.NotificationServiceUI
{
	public class NotificationsCheckController
	{
		private FormNotificationServiceWarning _notificationForm;
		private Thread _checkerThread;
		private User _currentUser;
		private long _interupt;

		public bool Interupt
		{
			get { return Interlocked.Read(ref _interupt) != 0; }
			set
			{
				if(value)
				{
					Interlocked.Increment(ref _interupt);
				}
			}
		}

		public void Start()
		{
			_currentUser = ClientEnvironment.AuthorizationService.GetCurrentUser();

			if(!_currentUser.UserRoleID.HasValue || (UserRoleId.GlobalAdmin != (UserRoleId)_currentUser.UserRoleID.Value && UserRoleId.CountryAdmin != (UserRoleId)_currentUser.UserRoleID.Value && UserRoleId.RegionAdmin != (UserRoleId)_currentUser.UserRoleID.Value && UserRoleId.StoreAdmin != (UserRoleId)_currentUser.UserRoleID.Value))
			{
				return;
			}

			// Initialize checker thread
			_checkerThread = new Thread(Check);
			_checkerThread.IsBackground = true;

			ShowProgress();

			_checkerThread.Start();
		}

		private void ShowProgress()
		{
			if (ClientEnvironment.MainForm.InvokeRequired)
			{
				ClientEnvironment.MainForm.BeginInvoke(new MethodInvoker(ShowProgress));
				return;
			}

			_notificationForm = new FormNotificationServiceWarning();
			_notificationForm.SwitchAnalyzeMode();
		}

		private void Check()
		{
			try
			{
				CheckStoreOpenCloseTimes();
				if(Interupt)
				{
					return;
				}
				CheckEstatiationIsPossible();
				if(Interupt)
				{
					return;
				}
				CheckNeedToMergeExternalEmployees();
				if(Interupt)
				{
					return;
				}
				CheckWorkingDaysFeasts();
				if(Interupt)
				{
					return;
				}

				_notificationForm.SwitchToResultMode();
			} catch(EntityException extityEx)
			{
				_notificationForm.ProcessEntityException(extityEx);
			} catch(Exception ex)
			{
				_notificationForm.ProcessException(ex);
			}
		}

		private bool IsAdminOrCountryManager()
		{
			return UserRoleId.GlobalAdmin == (UserRoleId)_currentUser.UserRoleID.Value || UserRoleId.CountryAdmin == (UserRoleId)_currentUser.UserRoleID.Value;
		}

		#region Check implementation

		private void CheckStoreOpenCloseTimes()
		{
			// ACPRO 119776: If a store has corrently no timerange at all or a time range is insert, 
			// but it has no values in it (e.g. MO-SU is empty then the notification mamanger at login shall 
			// warn the store manager and all users who own the market)

			long[] storeIDWithEmptyOpenCloseTimes = ClientEnvironment.StoreService.GetStoreEmptyOpenCloseTimeList(_currentUser.ID);
			IStoreService storeService = ClientEnvironment.StoreService;
			List<Store> stores = storeService.FindByIDList(new List<long>(storeIDWithEmptyOpenCloseTimes));
			if(stores != null && stores.Count > 0)
			{
				UCStoresListNotification displayUC = new UCStoresListNotification();
				displayUC.StoresList = stores;
				_notificationForm.AddResultItem(Localizer.GetLocalized("WarnNoOpenCloseTime"), displayUC);
			}
		}

		private void CheckEstatiationIsPossible()
		{
			// ACPRO 119082 Wether all data for the estimation is provided and that he can start estimation (see seperate mail) 
			// (this includes bufferhours for all worlds, min max values,...) 
			
			if(!IsAdminOrCountryManager())
			{
				return;
			}

			if(!ClientEnvironment.StoreService.CanEstimateCashDeskPeople(DateTime.Today.Year) || !ClientEnvironment.StoreService.CanEstimateWorkingHours(DateTime.Today.Year))
			{
				_notificationForm.AddResultItem(Localizer.GetLocalized("WarnEstimationNotPossible"));
			}
		}

		private void CheckNeedToMergeExternalEmployees()
		{
			// ACPRO 119082 Wether an employee is now available (due to latest import) 
			// that has the same name and same firstname as an unmigrated external employee 
			// (=> so user can start migrate usecase of this external user)

            // acpro item #119082
            // "The notification wether an external employee data is available for mergeing shall come for all userclass please!"
            //if(!IsAdminOrCountryManager())
            //{
            //    return;
            //}

			long[][] needMergeEmployee = ClientEnvironment.EmployeeService.GetEmployeeToMergeList();
			IDictionary<long, Store> storesMap = new Dictionary<long, Store>();

			IStoreService storeService = ClientEnvironment.StoreService;
			for(int idx = 0; idx < needMergeEmployee.Length; idx++)
			{
				if(!storesMap.ContainsKey(needMergeEmployee[idx][1]))
				{
					Store store = storeService.FindById(needMergeEmployee[idx][1]);
					if(store != null)
					{
						storesMap.Add(store.ID, store);
					}
				}
			}
			// Create UI
			if(storesMap.Count > 0)
			{
				UCStoresListNotification displayUC = new UCStoresListNotification();
				displayUC.StoresList = new List<Store>(storesMap.Values);
				_notificationForm.AddResultItem(Localizer.GetLocalized("WarnNeedMergeEmployees"), displayUC);
			}
		}

		private void CheckWorkingDaysFeasts()
		{
			// ACPRO 119082
			// Wether the working days (opening days) and feast have been entered (consider it entered as soon as at least one day is entered)

			if(!IsAdminOrCountryManager())
			{
				return;
			}

			long[] countryIds = ClientEnvironment.CountryService.GetCountryNoWorkingFeastDaysIDList();
			if(countryIds != null && countryIds.Length > 0)
			{
				List<Country> countries = ClientEnvironment.CountryService.FindByIDList(new List<long>(countryIds));
				if(countries != null && countries.Count > 0)
				{
					UCCountriesListNotification displayUC = new UCCountriesListNotification();
					displayUC.DataSource = countries;
											_notificationForm.AddResultItem(Localizer.GetLocalized("WarnNoWorkingDaysFeasts"), displayUC);
				}
			}
		}

		#endregion
	}
}