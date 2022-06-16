using System;
using System.Collections.Generic;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Localization;
using DevExpress.XtraEditors;
using Baumax.ClientUI.FormEntities;

namespace Baumax.ClientUI.General
{
	public partial class FrmWarnEmptyOpenCloseTime : XtraForm
	{
		private StoreViewList _storeListView;

		public FrmWarnEmptyOpenCloseTime()
		{
			InitializeComponent();
			if (ClientEnvironment.IsRuntimeMode)
			{
				_storeListView = new StoreViewList();
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			//
			if (ClientEnvironment.IsRuntimeMode)
			{
				// Localize
				Text = Localizer.GetLocalized("Attention");
				btnClose.Text = Localizer.GetLocalized("Close");
				lblMessage.Text = Localizer.GetLocalized("WarnNoOpenCloseTime");
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