using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Localization;
using DevExpress.XtraEditors;
using Baumax.ClientUI.FormEntities;

namespace Baumax.ClientUI.NotificationServiceUI
{
	public partial class UCStoresListNotification : XtraUserControl
	{
		private readonly StoreViewList _storeListView;

		public UCStoresListNotification()
		{
			InitializeComponent();
			if (ClientEnvironment.IsRuntimeMode)
			{
				_storeListView = new StoreViewList();
			}
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

		public List<Store> StoresList
		{
			set
			{
				_storeListView.AssignStores(value);
				gridControl.DataSource = _storeListView;
				//
				gridViewEntities.ExpandAllGroups();
			}
		}
	}
}