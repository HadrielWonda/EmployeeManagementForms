using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Baumax.Contract;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Baumax.ClientUI.FormEntities.EntityStore
{
	public partial class UCOpenCloseHours : UCBaseEntity
	{
		private readonly Dictionary<byte, TextEdit> _dictOfEdit = new Dictionary<byte, TextEdit>();
		private readonly Dictionary<byte, _TimeRange> _copyList = new Dictionary<byte, _TimeRange>();

		private OpenCloseTimesList _listOpenTimeRanges = null;

		private Store _store = null;

		private object _entity;

		public event EventHandler DeleteWorkingHours;

		public UCOpenCloseHours()
		{
			InitializeComponent();

			if(ClientEnvironment.IsRuntimeMode)
			{
				BuildDictionaryOfEdits();
				StartDate = DateTime.Today;
				EndDate = DateTimeSql.SmallDatetimeMax;

				if(ClientEnvironment.IsRuntimeMode)
				{
					deStart.Properties.MinValue = DateTimeSql.SmallDatetimeMin;
					deStart.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;

					deEnd.Properties.MinValue = DateTimeSql.SmallDatetimeMin;
					deEnd.Properties.MaxValue = DateTimeSql.SmallDatetimeMax;
				}
				UpdateButtonState();
			}
		}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsDesignMode)
            {
                if ((ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.HasValue) &&
                (ClientEnvironment.AuthorizationService.GetCurrentUser().UserRoleID.Value == (long)UserRoleId.Controlling))
                    btnOK.Visible = btnNew.Visible = btnDelete.Visible = false;
            }
        }

		private class _TimeRange
		{
			private byte _weekday;
			private short _opentime;
			private short _closetime;

			public byte Weekday
			{
				get { return _weekday; }
				set { _weekday = value; }
			}

			public short OpenTime
			{
				get { return _opentime; }
				set { _opentime = value; }
			}

			public short CloseTime
			{
				get { return _closetime; }
				set { _closetime = value; }
			}

			public _TimeRange(byte wd, short ot, short ct)
			{
				_weekday = wd;
				_opentime = ot;
				_closetime = ct;
			}

			public void Assign(StoreWTWeekday w)
			{
				Debug.Assert(_weekday == w.Weekday);
				_opentime = w.Opentime;
				_closetime = w.Closetime;
			}

			public bool IsModified(StoreWTWeekday w)
			{
				Debug.Assert(_weekday == w.Weekday);
				return (OpenTime != w.Opentime) || (CloseTime != w.Closetime);
			}

			public void Copy(StoreWTWeekday w)
			{
				Debug.Assert(_weekday == w.Weekday);
				w.Opentime = OpenTime;
				w.Closetime = CloseTime;
			}

			public string DisplayString
			{
				get
				{
					if(CloseTime == 0)
					{
						return String.Empty;
					} else
					{
						return BaumaxTimeHelper.GetTimeAsString(OpenTime, CloseTime);
					}
				}
				set
				{
					string sValue = value.Trim();
					if(String.IsNullOrEmpty(sValue))
					{
						OpenTime = CloseTime = 0;
					} else
					{
						short[] times = BaumaxTimeHelper.GetTimeRangeFromString(sValue);
						if(times != null && times.Length == 2)
						{
							OpenTime = times[0];
							CloseTime = times[1];
						}
					}
				}
			}
		}

		private void BuildDictionaryOfEdits()
		{
			_dictOfEdit.Add((byte)DayOfWeek.Monday, teMonday);
			_dictOfEdit.Add((byte)DayOfWeek.Tuesday, teTuesday);
			_dictOfEdit.Add((byte)DayOfWeek.Wednesday, teWednesday);
			_dictOfEdit.Add((byte)DayOfWeek.Thursday, teThursday);
			_dictOfEdit.Add((byte)DayOfWeek.Friday, teFriday);
			_dictOfEdit.Add((byte)DayOfWeek.Saturday, teSaturday);
			_dictOfEdit.Add((byte)DayOfWeek.Sunday, teSunday);

			_copyList.Add((byte)DayOfWeek.Monday, new _TimeRange((byte)DayOfWeek.Monday, 0, 0));
			_copyList.Add((byte)DayOfWeek.Tuesday, new _TimeRange((byte)DayOfWeek.Tuesday, 0, 0));
			_copyList.Add((byte)DayOfWeek.Wednesday, new _TimeRange((byte)DayOfWeek.Wednesday, 0, 0));
			_copyList.Add((byte)DayOfWeek.Thursday, new _TimeRange((byte)DayOfWeek.Thursday, 0, 0));
			_copyList.Add((byte)DayOfWeek.Friday, new _TimeRange((byte)DayOfWeek.Friday, 0, 0));
			_copyList.Add((byte)DayOfWeek.Saturday, new _TimeRange((byte)DayOfWeek.Saturday, 0, 0));
			_copyList.Add((byte)DayOfWeek.Sunday, new _TimeRange((byte)DayOfWeek.Sunday, 0, 0));
		}

		public DateTime StartDate
		{
			get { return deStart.DateTime; }
			set { deStart.DateTime = value; }
		}

		public DateTime EndDate
		{
			get { return deEnd.DateTime; }
			set { deEnd.DateTime = value; }
		}

		public Store CurrentStore
		{
			get { return _store; }
			set
			{
				if(_store != value)
				{
					_store = value;

					if(CurrentStore == null)
					{
						ReadOnly = true;
					}
					_listOpenTimeRanges = null;
					EntityOpenCloseTime = null;
					UpdateButtonState();
				}
			}
		}

		public override object Entity
		{
			get { return _entity; }
			set{
				_entity = value;
				EntityChanged();
			}
		}

		public StoreWorkingTime EntityOpenCloseTime
		{
			get { return (StoreWorkingTime)Entity; }
			set { Entity = value; }
		}

		public long CurrentStoreID
		{
			get { return CurrentStore.ID; }
		}

		public OpenCloseTimesList OpenCloseTimes
		{
			get
			{
				if(_listOpenTimeRanges == null)
				{
					if(CurrentStore != null)
					{
						_listOpenTimeRanges = new OpenCloseTimesList(CurrentStoreID);
					}
				}
				return _listOpenTimeRanges;
			}
			set { _listOpenTimeRanges = value; }
		}

		public override void AssignLanguage()
		{
			base.AssignLanguage();
			if(ClientEnvironment.IsRuntimeMode)
			{
				btnOK.ToolTip = GetLocalized("SaveOpenCloseTimeRange");
				btnNew.ToolTip = GetLocalized("NewOpenCloseTimeRange");
				btnDelete.ToolTip = GetLocalized("DeleteOpenCloseTimeRange");
			}
		}

		protected override void EntityChanged()
		{
			base.EntityChanged();

			if(Entity != null)
			{
				SetReadOnlyMode(false);
				StartDate = EntityOpenCloseTime.BeginTime;
				EndDate = EntityOpenCloseTime.EndTime;

				BindWeekDays();
			} else
			{
				ClearWeekDays();
				SetReadOnlyMode(true);
			}
			UpdateButtonState();

			SetRulesForDates();
		}

		private void SetRulesForDates()
		{
			if(EntityOpenCloseTime != null)
			{
				if(EntityOpenCloseTime.IsNew)
				{
					deStart.Properties.MinValue = DateTime.Today;
				} else
				{
					deStart.Properties.MinValue = DateTimeSql.SmallDatetimeMin;

					if(CanEditEndDate())
					{
						deEnd.Properties.MinValue = DateTime.Today;
					} else
					{
						deEnd.Properties.MinValue = DateTimeSql.SmallDatetimeMin;
					}
				}
			}
		}

		protected override void ChangedReadOnlyState()
		{
			SetReadOnlyMode(ReadOnly);
		}

		private void SetReadOnlyMode(bool readOnly)
		{
			deStart.Properties.ReadOnly = readOnly;
			deEnd.Properties.ReadOnly = readOnly;
            if (readOnly)
            {
                btnNew.Enabled = false;
                btnDelete.Enabled = false;
                btnOK.Enabled = false;
            }

			foreach(TextEdit te in _dictOfEdit.Values)
			{
				te.Properties.ReadOnly = true;
			}
		}

		public override bool IsValid()
		{
			Debug.Assert(EntityOpenCloseTime != null);

			if(CurrentStore == null)
			{
				return false;
			}

			if(StartDate > EndDate)
			{
				ErrorMessage(GetLocalized("ErrorDateRange"));
				deStart.Focus();
				return false;
			}

			if(OpenCloseTimes != null)
			{
				if(OpenCloseTimes.IsIntersect(EntityOpenCloseTime.ID, StartDate, EndDate))
				{
					ErrorMessage(GetLocalized("ErrorDateRangeIntersect"));
					deStart.Focus();
					return false;
				}
			}

			return true;
		}

		private static void CopyEntity(StoreWorkingTime source, StoreWorkingTime dest)
		{
			dest.ID = source.ID;
			dest.StoreID = source.StoreID;
			dest.BeginTime = source.BeginTime;
			dest.EndTime = source.EndTime;
			foreach(StoreWTWeekday wdSource in source.StoreWTWeekdays)
			{
				foreach(StoreWTWeekday wdDest in dest.StoreWTWeekdays)
				{
					if(wdDest.Weekday == wdSource.Weekday)
					{
						wdDest.ID = wdSource.ID;
						wdDest.Opentime = wdSource.Opentime;
						wdDest.Closetime = wdSource.Closetime;
						continue;
					}
				}
			}
		}

		public override bool Commit()
		{
			if(Entity != null && IsValid() && IsModified() && !ReadOnly)
			{
				StoreWorkingTime holeCoverWorkingTime = null;
				StoreWorkingTime copyHoleCoverWorkingTime = null;

				if(OpenCloseTimes.Count > 1)
				{
					// If Start Date or End Date is modified, the hole in Schedule should be covered by previous or next schedule
					if(StartDate != EntityOpenCloseTime.BeginTime)
					{
						holeCoverWorkingTime = OpenCloseTimes.FindPrevious(EntityOpenCloseTime);
						if (holeCoverWorkingTime != null)
						{
							copyHoleCoverWorkingTime = ClientEnvironment.StoreService.StoreWorkingTimeService.CreateEntity();
							CopyEntity(holeCoverWorkingTime, copyHoleCoverWorkingTime);
							copyHoleCoverWorkingTime.EndTime = StartDate.AddDays(-1);
						}
					} 
                    else if(EndDate != EntityOpenCloseTime.EndTime)
					{
						holeCoverWorkingTime = OpenCloseTimes.FindNext(EntityOpenCloseTime);
						if(holeCoverWorkingTime != null)
						{
							copyHoleCoverWorkingTime = ClientEnvironment.StoreService.StoreWorkingTimeService.CreateEntity();
							CopyEntity(holeCoverWorkingTime, copyHoleCoverWorkingTime);
							copyHoleCoverWorkingTime.BeginTime = EndDate.AddDays(1);
						}
					}
				}

				StoreWorkingTime copyWorkingTime = ClientEnvironment.StoreWorkingTimeService.CreateEntity();

				CopyEntity(EntityOpenCloseTime, copyWorkingTime);

				foreach(StoreWTWeekday wd in copyWorkingTime.StoreWTWeekdays)
				{
					_copyList[wd.Weekday].DisplayString = _dictOfEdit[wd.Weekday].Text;
					_copyList[wd.Weekday].Copy(wd);
				}

				copyWorkingTime.BeginTime = StartDate;
				copyWorkingTime.EndTime = EndDate;
				copyWorkingTime.StoreID = CurrentStoreID;

				try
				{
					bool isNew = copyWorkingTime.IsNew;

					copyWorkingTime = ClientEnvironment.StoreService.StoreWorkingTimeService.SaveOrUpdate(copyWorkingTime);
                    
					CopyEntity(copyWorkingTime, EntityOpenCloseTime);
					UpdateButtonState();
                    if(OnEntityChanged != null)
					{
						OnEntityChanged(new EntityChangedArgs(EntityOpenCloseTime, (isNew) ? ChangedEntityType.New : ChangedEntityType.Edit));
					}

					// Update previous or next Working Time range to cover the hole create
					if(holeCoverWorkingTime != null)
					{
						CopyEntity(ClientEnvironment.StoreService.StoreWorkingTimeService.Update(copyHoleCoverWorkingTime), holeCoverWorkingTime);
						if(OnEntityChanged != null)
						{
							OnEntityChanged(new EntityChangedArgs(holeCoverWorkingTime, ChangedEntityType.Edit));
						}
					}
                    //Recalculate  Additional hours  
                    //Delete calculated Additional hours after change Date range for out of range data
				    RecalculateStoreAdditionalHours();
					Modified = true;
					return true;
				} catch(ValidationException)
				{
					ErrorMessage(GetLocalized("ErrorDateRangeIntersect"));
					deStart.Focus();
					return false;
				}
					/*catch (DBDuplicateKeyException)
                {
                    ErrorMessage(GetLocalized("ErrorDateRangeIntersect"));
                    deStart.Focus();
                    return false;
                }*/
				catch(EntityException ex)
				{
					ProcessEntityException(ex);
					return false;
				}
			}
			return false;
		}
	    
	    private void RecalculateStoreAdditionalHours()
	    {
            long storeID = CurrentStoreID;
            List<short> allyears = ClientEnvironment.StoreService.GetYearsWithCountryAdditinalHourByStoreID(storeID, DateTime.Now.Year,
                                                                                           2079);
            if (allyears != null && allyears.Count != 0)
            {
                foreach (short year in allyears)
                {
                    ClientEnvironment.StoreService.DeleteCalculatedCountryAdditionalHours(year, storeID);
                    ClientEnvironment.StoreService.CalculateStoreAdditionalHours(year, storeID);
                }
            }
	    }

		private void BindWeekDays()
		{
			ClearWeekDays();
			if(Entity != null && EntityOpenCloseTime.IsNew)
			{
				BuildNewOpenCloseList();
			}

			if(Entity != null && EntityOpenCloseTime.StoreWTWeekdays != null)
			{
				foreach(StoreWTWeekday wd in EntityOpenCloseTime.StoreWTWeekdays)
				{
					_copyList[wd.Weekday].Assign(wd);
					_dictOfEdit[wd.Weekday].Text = _copyList[wd.Weekday].DisplayString;
				}
			}
		}

		private void BuildNewOpenCloseList()
		{
			if(Entity != null)
			{
				if(EntityOpenCloseTime.StoreWTWeekdays == null)
				{
					EntityOpenCloseTime.StoreWTWeekdays = new List<StoreWTWeekday>();
				}

				if(EntityOpenCloseTime.StoreWTWeekdays.Count != 7)
				{
					for(int i = 0; i < 7; i++)
					{
						bool bExist = false;
						foreach(StoreWTWeekday swt in EntityOpenCloseTime.StoreWTWeekdays)
						{
							if(swt.Weekday == i)
							{
								bExist = true;
								break;
							}
						}
						if(!bExist)
						{
							StoreWTWeekday wd = new StoreWTWeekday();
							wd.ID = 0;
							wd.StoreWorkingTime = EntityOpenCloseTime;
							wd.Weekday = (byte)i;
							wd.Opentime = 0;
							wd.Closetime = 0;
							EntityOpenCloseTime.StoreWTWeekdays.Add(wd);
						}
					}
				}
			}
		}

		private void ClearWeekDays()
		{
			foreach(TextEdit edit in _dictOfEdit.Values)
			{
				edit.Text = String.Empty;
				edit.Properties.ReadOnly = ReadOnly;
			}
		}

		private void deEnd_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			if(e.Button.Kind == ButtonPredefines.Delete)
			{
				deEnd.DateTime = DateTimeSql.SmallDatetimeMax;
			}
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			Commit();
		}

		private void teMonday_Validating(object sender, CancelEventArgs e)
		{
			Regex reg = new Regex(@"(0?\d|1\d|2[0-3])\:[0-5]\d-(0?\d|1\d|2[0-3])\:[0-5]\d");
			TextEdit te = (TextEdit) sender;

			string s = te.Text;
			if(!String.IsNullOrEmpty(s))
			{
				if(reg.IsMatch(s))
				{
					short[] result = BaumaxTimeHelper.GetTimeRangeFromString(s);
					if(result[1] <= result[0])
					{
						te.ErrorText = GetLocalized("ErrorBeginTimeEndTime"); // "Время окончание работы магазина меньше времени начала работы магазина";
						e.Cancel = true;
					}
				} else
				{
					te.ErrorText = GetLocalized("InvalidValue"); // "Некорректное значение времени";
					e.Cancel = true;
				}

				if(!e.Cancel)
				{
					te.ErrorText = String.Empty;
				}
			}

			UpdateButtonState();
		}

		private void UpdateButtonState()
		{
			if(CurrentStore == null)
			{
				btnNew.Enabled = false;
				btnOK.Enabled = false;
				btnDelete.Enabled = false;
				foreach(TextEdit te in _dictOfEdit.Values)
				{
					te.Enabled = false;
					te.Text = String.Empty;
				}
				deStart.Enabled = false;
				deEnd.Enabled = false;
				return;
			}

			deStart.Enabled = CanEditBeginDate(); ;
			deEnd.Enabled = CanEditEndDate();

			bool canEdit = CanEditTimes();
			foreach(TextEdit te in _dictOfEdit.Values)
			{
				te.Enabled = canEdit;
			}

			btnNew.Enabled = ((EntityOpenCloseTime == null) || (!EntityOpenCloseTime.IsNew)) && !ReadOnly;
            btnOK.Enabled = (IsModified() && CanEditEndDate()) && !ReadOnly;
            btnDelete.Enabled = EntityOpenCloseTime != null && !EntityOpenCloseTime.IsNew && EntityOpenCloseTime.BeginTime > DateTime.Today && !ReadOnly;
		}

		private bool CanEditBeginDate()
		{
			if(EntityOpenCloseTime == null || ReadOnly)
			{
				return false;
			}

			return (!EntityOpenCloseTime.IsNew && EntityOpenCloseTime.BeginTime.Date > DateTime.Today.AddDays(1));
		}

		private bool CanEditEndDate()
		{
			if(EntityOpenCloseTime == null || ReadOnly)
			{
				return false;
			}

			if(EntityOpenCloseTime.IsNew)
			{
				return true;
			}
			// can not edit if last 
			if(EntityOpenCloseTime.EndTime <= DateTime.Today)
			{
				return false;
			}

			return true;
		}

		private bool CanEditTimes()
		{
			if (EntityOpenCloseTime == null || ReadOnly)
			{
				return false;
			}
			return EntityOpenCloseTime.IsNew || EntityOpenCloseTime.BeginTime > DateTime.Today;
		}

		private bool IsModified()
		{
			if(EntityOpenCloseTime == null)
			{
				return false;
			}

			if(EntityOpenCloseTime.IsNew)
			{
				return true;
			}

			foreach(_TimeRange tr in _copyList.Values)
			{
				if(tr.DisplayString != _dictOfEdit[tr.Weekday].Text)
				{
					return true;
				}
			}

			if((StartDate != EntityOpenCloseTime.BeginTime) || (EndDate != EntityOpenCloseTime.EndTime))
			{
				return true;
			}

			return false;
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			if(CurrentStore != null)
			{
				if(OpenCloseTimes != null)
				{
					StoreWorkingTime newtime = OpenCloseTimes.BuildNewEntity();

					if(newtime != null)
					{
						EntityOpenCloseTime = newtime;
					} else
					{
						ErrorMessage(GetLocalized("ErrorCantNewOpenCloseOutOfRange"));
						return;
					}
				} else
				{
					EntityOpenCloseTime = ClientEnvironment.StoreService.StoreWorkingTimeService.CreateEntity();
					EntityOpenCloseTime.StoreID = CurrentStoreID;
					StartDate = DateTime.Today;
					EndDate = DateTimeSql.SmallDatetimeMax;
				}
				UpdateButtonState();
			}
		}

		public delegate void DlgEntityChanged(EntityChangedArgs args);

		public event DlgEntityChanged OnEntityChanged = null;

		private void deStart_DateTimeChanged(object sender, EventArgs e)
		{
			UpdateButtonState();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (DeleteWorkingHours != null)
			{
				DeleteWorkingHours(this, EventArgs.Empty);
			    RecalculateStoreAdditionalHours();
			}
		}
	}
}