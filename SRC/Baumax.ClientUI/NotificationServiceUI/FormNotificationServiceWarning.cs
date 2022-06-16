using System;
using System.Drawing;
using System.Windows.Forms;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Environment;
using Baumax.Localization;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace Baumax.ClientUI.NotificationServiceUI
{
	public partial class FormNotificationServiceWarning : XtraForm
	{
		private delegate void AddStringResultDelegate(string text);
		private delegate void AddDetailedResultDelegate(string text, UserControl userControl);
		
		private delegate void ProcessExceptionDelegate(Exception ex);

		private delegate void ProcessEntityExceptionDelegate(EntityException ex);

		public NotifyChangedLanguageUI DoChangeLanguage = null;

		public FormNotificationServiceWarning()
		{
			InitializeComponent();
		}

		#region Localization & Layout

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			if(ClientEnvironment.IsRuntimeMode)
			{
				Text = Localizer.GetLocalized("NotificationService");
				lbl_Analyzing.Text = Localizer.GetLocalized("AnalyzingData");
				
				LoadLayout();

				DoChangeLanguage = NotificationService_ChangedLanguageUI;
				NotificationService.ChangedLanguageUI += DoChangeLanguage;
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			//
			NotificationService.ChangedLanguageUI -= DoChangeLanguage;
		}

		private void NotificationService_ChangedLanguageUI()
		{
			AssignLanguage();
		}

		public virtual void AssignLanguage()
		{
			new ControlLocalizer(UILocalizer.Current, this);
		}

		protected virtual void LoadLayout()
		{
			//LayoutManager.Instance.LoadLayout(UniqueFormName, this);
			AssignLanguage();
		}

		protected virtual void SaveLayout()
		{
			//LayoutManager.Instance.SaveLayout(UniqueFormName, this);
		}

		#endregion

		public void SwitchAnalyzeMode()
		{
			Form formMain = ClientEnvironment.MainForm;
			if(formMain.InvokeRequired)
			{
				formMain.BeginInvoke(new MethodInvoker(SwitchAnalyzeMode));
				return;
			}
			tabControlWizard.SelectedTabPageIndex = 0;
		}

		public void SwitchToResultMode()
		{
			Form formMain = ClientEnvironment.MainForm;

			if(formMain.InvokeRequired)
			{
				formMain.BeginInvoke(new MethodInvoker(SwitchToResultMode));
				return;
			}
			if(layoutControlGroupRoot.Items.Count == 0)
			{
				Close();
			} else
			{
				tabControlWizard.SelectedTabPageIndex = 1;
				ShowDialog(formMain);
			}
		}

		public void ProcessException (Exception ex)
		{
			Form formMain = ClientEnvironment.MainForm;

			if (formMain.InvokeRequired)
			{
				formMain.BeginInvoke(new ProcessExceptionDelegate(ProcessException), ex);
				return;
			}
			MessageBox.Show(ex.ToString(), "Unhandled exception");
		}

		public void ProcessEntityException(EntityException ex)
		{
			Form formMain = ClientEnvironment.MainForm;

			if (formMain.InvokeRequired)
			{
				formMain.BeginInvoke(new ProcessEntityExceptionDelegate(ProcessEntityException), ex);
				return;
			}
			using (FrmEntityExceptionDetails form = new FrmEntityExceptionDetails(ex))
			{
				form.Text = Localizer.GetLocalized("Error");
				if (String.IsNullOrEmpty(form.Text))
				{
					form.Text = ex.Message;
				}
				form.ShowDialog(this);
			}
		}

		public void AddResultItem(string text)
		{
			Form formMain = ClientEnvironment.MainForm;
			
			if(formMain.InvokeRequired)
			{
				formMain.BeginInvoke(new AddStringResultDelegate(AddResultItem), text);
				return;
			}

			if (text == null)
			{
				throw new ArgumentNullException("text");
			}

			layoutControlWarnings.BeginUpdate();

			LabelControl label = new LabelControl();
			label.Text = text;
			label.Appearance.ImageList = imageCollection32;
			label.Appearance.ImageIndex = 0;
			label.Appearance.ImageAlign = ContentAlignment.MiddleLeft;
			label.Appearance.Options.UseImage = true;
			label.ImageAlignToText = ImageAlignToText.LeftCenter;
			LayoutControlItem item = new LayoutControlItem(layoutControlWarnings, label);
			item.TextVisible = false;
			item.SizeConstraintsType = SizeConstraintsType.Custom;
			item.MinSize = new Size(layoutControlWarnings.Width - 32, 40);
			item.MaxSize = new Size(layoutControlWarnings.Width, 40);
			layoutControlWarnings.AddItem(item);

			layoutControlWarnings.EndUpdate();
		}

		public void AddResultItem(string text, UserControl details)
		{
			Form formMain = ClientEnvironment.MainForm;

			if(formMain.InvokeRequired)
			{
				formMain.BeginInvoke(new AddDetailedResultDelegate(AddResultItem), text, details);
				return;
			}

			if (text == null)
			{
				throw new ArgumentNullException("text");
			}

			if (details == null)
			{
				throw new ArgumentNullException("details");
			}

			layoutControlWarnings.BeginUpdate();

			LayoutControlItem item = new LayoutControlItem();
			item.Control = details;
			item.TextVisible = false;
			item.Size = details.Size;
			item.SizeConstraintsType = SizeConstraintsType.Custom;
			item.MaxSize = new Size(layoutControlWarnings.Width, details.Height);
			item.MinSize = new Size(layoutControlWarnings.Width - 32, details.Height);

			LayoutGroup group = new LayoutControlGroup();
			group.TextVisible = true;
			group.Text = text;
			group.AppearanceGroup.Options.UseTextOptions = true;
			group.AppearanceGroup.TextOptions.WordWrap = WordWrap.Wrap;
			group.ExpandButtonVisible = true;
			group.ExpandButtonLocation = GroupElementLocation.AfterText;
			group.Expanded = false;

//			group.GroupBordersVisible = false;
			group.CaptionImageIndex = 0;

			layoutControlGroupRoot.AddItem(group);
			group.AddItem(item);

			layoutControlWarnings.EndUpdate();
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}