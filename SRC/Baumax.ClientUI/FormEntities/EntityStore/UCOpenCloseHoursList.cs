using System;
using System.ComponentModel;
using System.Windows.Forms;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraGrid.Views.Base;

namespace Baumax.ClientUI.FormEntities.EntityStore
{
	public partial class UCOpenCloseHoursList : UCBaseEntity
	{
		private StoreManagerContext _context;

		private StoreWorkingTime _focusedRange;

		private bool _showstores = true;
	    private bool _CanEdit;
        private bool isUserControlling = false;

		public UCOpenCloseHoursList()
		{
			InitializeComponent();

			if(ClientEnvironment.IsRuntimeMode)
			{
				lookUpEditStores.Properties.PopupFormWidth = lookUpEditStores.Width;
				gridColumn_Country.GroupIndex = 0;
				gridColumn_Region.GroupIndex = 1;
			    AccessType access =
			        ClientEnvironment.AuthorizationService.GetAccess(ClientEnvironment.StoreService.StoreWorkingTimeService);

			    _CanEdit = (access & AccessType.Write) != 0;
			    ucOpenCloseHours.ReadOnly = !_CanEdit;
			}
		}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsDesignMode)
            {
                if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value == (long)UserRoleId.Controlling))
                    isUserControlling = true;
                if (isUserControlling)
                    gridControl.ContextMenuStrip = null;
            }
        }
        public override void AssignLanguage()
        {
            base.AssignLanguage();
            if (ClientEnvironment.IsRuntimeMode)
            {
                LocalizerControl.ComponentsLocalize(components);

                // Localize popup menu
                mi_NewOpenCloseRange.Text = GetLocalized("NewOpenCloseTimeRange");
                mi_DeleteOpenCloseRange.Text = GetLocalized("DeleteOpenCloseTimeRange");
            }
		}

		public OpenCloseTimesList OpenCloseTimes
		{
			get { return Context.OpenCloseTimes; }
		}

		[Browsable(false)]
		public Store EntityStore
		{
			get { return (Store)Entity; }
			set { Entity = value; }
		}

		public bool ShowStoresList
		{
			get { return _showstores; }
			set
			{
				if(_showstores != value)
				{
					_showstores = value;
					if(value)
					{
						InitContext();
						gp_Store.Visible = true;
						if(EntityStore != null)
						{
							lookUpEditStores.EditValue = EntityStore.ID;
						}
					} else
					{
						gp_Store.Visible = false;
					}
				}
			}
		}

		public void LoadControlData()
		{
			if(ShowStoresList)
			{
				InitContext();
			}
		}

		private int GetIndexOfStoreById(long id)
		{
			if(Context != null && ListOfStoresView != null)
			{
				for(int i = 0; i < ListOfStoresView.Count; i++)
				{
					if(ListOfStoresView[i].ID == id)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public StoreManagerContext Context
		{
			get { return _context; }
		}

		public StoreViewList ListOfStoresView
		{
			get { return Context.ListOfStoresView; }
		}

		public void SetStoreContext(StoreManagerContext context)
		{
			_context = context;
			lookUpEditStores.Properties.DataSource = ListOfStoresView;

			if(Context.CurrentView != null)
			{
				lookUpEditStores.EditValue = Context.CurrentView.ID;
			}
			lookUpEditStores.Properties.View.ExpandAllGroups();
            if((ListOfStoresView != null) && (ListOfStoresView.Count == 1))
            {
                lookUpEditStores.EditValue = ListOfStoresView[0].ID;
            }
		}

		private void InitContext()
		{
			_context = new StoreManagerContext();
			_context.Init();
			SetStoreContext(Context);
		}

		private void LoadOpenCloseHours()
		{
			if(EntityStore == null)
			{
				gridControl.DataSource = null;
				ucOpenCloseHours.CurrentStore = null;
			} else
			{
				gridControl.BeginUpdate();
				try
				{
					gridControl.DataSource = null;

					Context.LoadOpenCloseTimes();

					ucOpenCloseHours.CurrentStore = EntityStore;

					ucOpenCloseHours.OpenCloseTimes = Context.OpenCloseTimes;

					gridControl.DataSource = OpenCloseTimes;
				} finally
				{
					gridControl.EndUpdate();
				}

				if(FocusedEntity != null)
				{
					ucOpenCloseHours.EntityOpenCloseTime = FocusedEntity;
				}
			}
		}

		protected override void EntityChanged()
		{
			LoadOpenCloseHours();
			if (IsEmptyOrHasRangeToEternal())
			{
				InfoMessage(GetLocalized("WarningNoTimeRangeToEternity"));
			}
		}

		protected StoreWorkingTime GetEntityByRowHandle(int rowHandle)
		{
			if(gridViewEntities.IsDataRow(rowHandle))
			{
				return (StoreWorkingTime)gridViewEntities.GetRow(rowHandle);
			}
			return null;
		}

		public StoreWorkingTime FocusedEntity
		{
			get { return GetEntityByRowHandle(gridViewEntities.FocusedRowHandle); }
		}

		private void ShowFocusedEntityDetails ()
		{
			BeforeChangeEntity();
			_focusedRange = FocusedEntity;
			FireChangeTimeRange();
		}

		private void gridViewEntities_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
		{
			ShowFocusedEntityDetails();
		}

		private void BeforeChangeEntity()
		{
			/*IsValid();
            if (Modified)
            {
                if (QuestionMessageYes("Data was change. Do you want save changes?"))
                {
                    Commit();
                }
            }*/
		}

		private void FireChangeTimeRange()
		{
			if(_focusedRange != null)
			{
				ucOpenCloseHours.EntityOpenCloseTime = _focusedRange;
			}
		}

		private void DeleteFocusedWorkingHours()
		{
			if (FocusedEntity != null)
			{
				if (FocusedEntity.BeginTime > DateTime.Today)
				{
					if (QuestionMessageYes(GetLocalized("QuestionRemoveStoreOpenClose")))
					{
						StoreWorkingTime previousWorkingTime = OpenCloseTimes.FindPrevious(FocusedEntity);
						StoreWorkingTime nextWorkingTime = OpenCloseTimes.FindNext(FocusedEntity);
						OpenCloseHoursExtendOption extendAction = OpenCloseHoursExtendOption.Undefined;

						if (OpenCloseTimes.Count > 1)
						{
							// Check whether a hole in schedule is created, prompt user to select which range should be extended to cover the hole
							using (FormExtendOpenCloseHours formExtendOptions = new FormExtendOpenCloseHours())
							{
								formExtendOptions.SuggestOptions(previousWorkingTime, nextWorkingTime);
								if (formExtendOptions.ShowDialog(FindForm()) != DialogResult.OK)
								{
									return;
								}
								extendAction = formExtendOptions.SelectedExtendOption;
							}
						}

						try
						{
							StoreWorkingTime focusedWorkingTime = FocusedEntity;
							ClientEnvironment.StoreService.StoreWorkingTimeService.DeleteByID(focusedWorkingTime.ID);
							OpenCloseTimes.RemoveEntityById(FocusedEntity.ID);
							switch (extendAction)
							{
								case OpenCloseHoursExtendOption.Previous:
									previousWorkingTime.EndTime = focusedWorkingTime.EndTime;
									ClientEnvironment.StoreService.StoreWorkingTimeService.Update(previousWorkingTime);
									OpenCloseTimes.SetEntity(previousWorkingTime);
									break;
								case OpenCloseHoursExtendOption.Next:
									nextWorkingTime.BeginTime = focusedWorkingTime.BeginTime;
									ClientEnvironment.StoreService.StoreWorkingTimeService.Update(nextWorkingTime);
									OpenCloseTimes.SetEntity(nextWorkingTime);
									break;
								default:
									break;
							}
						}
						catch (EntityException ex)
						{
							ProcessEntityException(ex);
						}
						ShowFocusedEntityDetails();
					}
				}
				else
				{
					ErrorMessage(GetLocalized("CantDeleteOpenClose-EntityInUsed"));
				}
			}
		}

		private void newOpencloseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(OpenCloseTimes != null)
			{
				StoreWorkingTime newtime = OpenCloseTimes.BuildNewEntity();

				if(newtime != null)
				{
					ucOpenCloseHours.EntityOpenCloseTime = newtime;
				} else
				{
					ErrorMessage(GetLocalized("ErrorCantNewOpenCloseOutOfRange"));
					return;
				}
			}
		}

		private void lookUpEditStores_EditValueChanged(object sender, EventArgs e)
		{
			if(lookUpEditStores.EditValue != null)
			{
				long p = Convert.ToInt64(lookUpEditStores.EditValue);

				Context.CurrentView = Context.ListOfStoresView.GetById(p);

				if(Context.CurrentView != null)
				{
					EntityStore = Context.CurrentStore;
				}
			}
		}

		private void UCOpenCloseHoursList_Resize(object sender, EventArgs e)
		{
			lookUpEditStores.Properties.PopupFormWidth = lookUpEditStores.Width;
		}

		private void lookUpEditStores_QueryPopUp(object sender, CancelEventArgs e)
		{
			lookUpEditStores.Properties.PopupFormWidth = lookUpEditStores.Width;
		}

		private void ucOpenCloseHours_OnEntityChanged(EntityChangedArgs args)
		{
			if(args.ChangedType == ChangedEntityType.New)
			{
				OpenCloseTimes.Add((StoreWorkingTime)args.Entity);
			} else if(args.ChangedType == ChangedEntityType.Edit)
			{
				OpenCloseTimes.ResetItemById(args.Entity.ID);
			}
			if (IsEmptyOrHasRangeToEternal())
			{
				InfoMessage(GetLocalized("WarningNoTimeRangeToEternity"));
			}
		}

		private void deleteOpencloseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DeleteFocusedWorkingHours();
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			mi_DeleteOpenCloseRange.Enabled = (FocusedEntity != null) && (FocusedEntity.BeginTime > DateTime.Today);
		}

		private bool IsEmptyOrHasRangeToEternal ()
		{
			if (OpenCloseTimes != null)
			{
				foreach (StoreWorkingTime workingTime in OpenCloseTimes)
				{
					if (workingTime.EndTime == DateTimeSql.SmallDatetimeMax)
					{
						return false;
					}
				}
				return true;
			}

			return false;
		}

		private void ucOpenCloseHours_DeleteWorkingHours(object sender, EventArgs e)
		{
			DeleteFocusedWorkingHours();
		}
	}
}
