using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Spring.Context;
using Spring.Context.Support;
using Baumax.Contract.Interfaces;

using Baumax.Import;
using Baumax.Import.UI;

using Baumax.Contract.QueryResult;
using Baumax.Environment;
using Baumax.Domain;
using Baumax.Contract;

using Baumax.Contract.Exceptions.EntityExceptions;

namespace Baumax.Import.Test
{
	public partial class FrmMain : Form
	{
		ICountryService _CountryService;
		IRegionService _RegionService;
		IStoreService _StoreService;
		IEmployeeService _EmployeeService;
		public FrmMain()
		{
			InitializeComponent();
		}

		private void test()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.CheckFileExists = true;
			openFileDialog.InitialDirectory = "";
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				ImportType it = ImportManager.FileImportType(openFileDialog.FileName);
				MessageBox.Show(it.ToString());
			}
		}

		private void login()
		{
			if (_CountryService != null) return;
			if (!string.IsNullOrEmpty(tbLogin.Text)&& !string.IsNullOrEmpty(tbPassword.Text))
                ClientEnvironment.DoLogin(tbLogin.Text, tbPassword.Text);
            else
                ClientEnvironment.DoLogin("admin", "2");
            tbLogin.Enabled = false;
            tbPassword.Enabled = false;
            btnLogin.Enabled = false;
			ClientEnvironment.InitServices();
            _CountryService = ClientEnvironment.CountryService;
			_RegionService = ClientEnvironment.RegionService;
			_StoreService = ClientEnvironment.StoreService;
			_EmployeeService = ClientEnvironment.EmployeeService;
            ClientEnvironment.StoreService.BVCopyFromStoreComplete += new OperationCompleteDelegate(StoreService_BVCopyFromStoreComplete);
        }

        void StoreService_BVCopyFromStoreComplete(object sender, OperationCompleteEventArgs e)
        {
            MessageBox.Show(string.Format("Complite. Result {0} ",e.Success));
        }

		private void addImportTypeInComboBox()
		{
			//cbImportType.Properties.Items.AddRange
			//    (new object[] 
			//        { 
			//            ImportType.Country
			//            ,ImportType.WorkingDays
			//            ,ImportType.Region
			//            ,ImportType.Store
			//            ,ImportType.World
			//            ,ImportType.HWGR
			//            ,ImportType.WGR
			//        });
			//cbImportType.SelectedIndex = 0;
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			login();
            FrmImport frmImport = new FrmImport(ClientEnvironment.ImportParam);
			frmImport.ShowDialog();
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
            testGetStoreStructure();
        }

		private void testGetStoreStructure()
		{
			login();
            ClientEnvironment.CountryService.TestImportServerSide();
			//List<Employee> list= (List<Employee>)_EmployeeService.GetEmployeeList(1, DateTime.Now);
            /*
            List<StoreStructure> list = (List<StoreStructure>)_StoreService.GetStoreStructure(1559);
			List<StoreWorldDetail> list2 = (List<StoreWorldDetail>)_StoreService.StoreToWorldService.GetStoreWorldDetail(1999);
			MessageBox.Show(list.Count.ToString());
            */
            //long[] storesID= ClientEnvironment.StoreService.GetStoreEmptyOpenCloseTimeList(0);
            //MessageBox.Show(storesID.Length.ToString());
            //bool bbb = ClientEnvironment.EmployeeService.HasWorkingOrAbsenceTime(23134, DateTime.Now.Date, DateTime.Now.Date);
            //TrendCorrection tc = new TrendCorrection();
            //tc.BeginTime = DateTime.Now;
            //tc.EndTime = DateTime.Now.AddYears(1);
            //tc.Name = "LOM6777";
            //tc.StoreWorldID = 10;
            //tc.Value = 1;
            //ClientEnvironment.TrendCorrectionService.Save(tc);
            //long[][] result = ClientEnvironment.EmployeeService.EmployeeTimeService.EmployeeTimeSaldoGet(new long[] { 1, 2, 3 }, EmployeeTimeSaldoType.Planning, DateTime.Now);
            //long[] result = ClientEnvironment.CountryService.GetInUseIDList(InUseEntity.AvgWorkingDaysInWeek, 1018);
            //result = ClientEnvironment.CountryService.GetInUseIDList(InUseEntity.Absence, 1018);
            //result = ClientEnvironment.CountryService.GetInUseIDList(InUseEntity.WorkingModel, 1018);
            //bool result = ClientEnvironment.StoreService.CanEstimateCashDeskPeople(2008);
            //result = ClientEnvironment.StoreService.CanEstimateWorkingHours(2008);
            //AvgAmount avgAmount= ClientEnvironment.CountryService.AvgAmountService.FindById(5555);
            //List<CashDeskPeoplePerHourEstimateShort> list = (List<CashDeskPeoplePerHourEstimateShort>)ClientEnvironment.StoreToWorldService.GetCashDeskPeopleEstimated(DateTime.ParseExact("20080101", "yyyyMMdd",null), DateTime.ParseExact("20080101", "yyyyMMdd",null), 1583);
            //List<Country> result= ClientEnvironment.CountryService.FindAll();
            //List<EstimatedWorldWorkingHours> result1 = (List<EstimatedWorldWorkingHours>) ClientEnvironment.StoreToWorldService.GetEstimatedWorldWorkingHours(new DateTime(2008, 1, 5), new DateTime(2008, 1, 30), 1245, 3140);
            //decimal result2 = ClientEnvironment.StoreToWorldService.GetEstimatedTargetedNetPerformance(2008, 1245, 3140);
            //IList result3 = ClientEnvironment.StoreService.CanEstimateCashDeskPeopleInfo(2008);
            //IList result4 = ClientEnvironment.StoreService.CanEstimateCashDeskPeopleInfo(1173, 2007);
            //ClientEnvironment.StoreService.EstimateCashDeskPeople(1272, 2007);
            //'20070101', '20071101', 1173, 3148
            //IList result = ClientEnvironment.StoreToWorldService.GetBusinessVolumeSumTest(new DateTime(2007, 1, 1), new DateTime(2007, 11, 1), 1173);
            //IList result = ClientEnvironment.StoreService.BVActualByYearInfoGet(2008);
            //result = ClientEnvironment.StoreService.BVActualByYearInfoGet(2008, 1173);
            //result = ClientEnvironment.StoreService.BVCcrYearInfoGet        (2008);
            //IList result = ClientEnvironment.StoreService.BVCcrYearInfoGet(2008, 1173);
            //result = ClientEnvironment.StoreService.BVTargetByYearInfoGet   (2008);
            //IList result = ClientEnvironment.StoreService.BVTargetByYearInfoGet(2008, 1174);
            //BVcopyFromStoreResult result = ClientEnvironment.StoreService.BVCopyFromStore(Baumax.Contract.Import.BusinessVolumeType.Actual, 2004, 2007, 1173, 1175);
            //ClientEnvironment.StoreService.BVCopyFromStoreAsync(Baumax.Contract.Import.BusinessVolumeType.Actual, 2004, 2007, 1173, 1174);
            //bool result = ClientEnvironment.StoreService.CopyStructureForEmptyStores();
            //List<StoreWorldDetail> result = ClientEnvironment.StoreToWorldService.GetStoreWorldDetail(2007, 1173);
            //IList result = ClientEnvironment.EmployeeService.GetEmployeeList(1173, new DateTime(2007, 11, 17));
            //Employee employee = ClientEnvironment.EmployeeService.GetEmployeeByID(20051, new DateTime(2007, 11, 30));
            //IList result = result = ClientEnvironment.StoreToWorldService.GetBusinessVolumeCRRTest(new DateTime(2007, 1, 1), new DateTime(2007, 1, 2), 1173);
            //19942
            //EmployeeAllIn ent = new EmployeeAllIn(19942, new DateTime(2007, 1, 1), new DateTime(2008, 1, 1),true);
            //ClientEnvironment.EmployeeAllInService.Save(ent);
            //ClientEnvironment.CountryService.TestImportServerSide();
            //IList listresult = ClientEnvironment.StoreService.EmlpoyeeHolidaysSumInfoGet(1173, new DateTime(2007, 1, 1), new DateTime(2008, 1, 1), new DateTime(2007, 12, 1));
/*
            IList listresult = ClientEnvironment.StoreService.GetStoresWithEmployeeWeekTimeRecordingDelay();
            DateTime? dateresult = ClientEnvironment.StoreService.LastEmployeeWeekTimeRecordingGet(1173);
            bool result = ClientEnvironment.StoreService.LastEmployeeWeekTimeRecordingUpdate(1173, new DateTime(2007, 12, 1));
*/
            //Store store = ClientEnvironment.StoreService.FindById(1173);
            //store.CountryID = 8989;
            //ClientEnvironment.StoreService.Save(store);
            //IList result = ClientEnvironment.StoreService.BVActualByYearInfoGet(2008, 1173);
            //IList result = ClientEnvironment.LongTimeAbsenceService.FindAll();
            /*
            Employee employee = ClientEnvironment.EmployeeService.GetEmployeeByID(19883, DateTime.Now);
            IList result = ClientEnvironment.EmployeeService.GetEmployeeList(1173, DateTime.Now);
            */
            //IList result = ClientEnvironment.BufferHourAvailableService.FindAll();
            /*
            WorkingModel wm = new WorkingModel();
            wm.Name = "test 111";
            wm.WorkingModelType = WorkingModelType.LunchModel;
            wm.CountryID = 1123;
            wm.LanguageID = SharedConsts.NeutralLangId;
            wm.BeginTime = DateTime.Now;
            wm.EndTime = DateTime.Now;
            ClientEnvironment.WorkingModelService.Save(wm);
            */
            /*
            IList result = ClientEnvironment.WorkingModelService.GetCountryWorkingModel(1123, new DateTime(2007, 9, 4), new DateTime(2079, 6, 6));
            result = ClientEnvironment.WorkingModelService.GetCountryLunchModel(1123, new DateTime(2007, 9, 4), new DateTime(2079, 6, 6));
            */
            /*
            IList result = ClientEnvironment.EmployeeWeekTimePlanningService.FindAll();
            result = ClientEnvironment.EmployeeWeekTimeRecordingService.FindAll();
            */
            /*
            IList result = ClientEnvironment.StoreService.EmlpoyeeHolidaysSumInfoGet(1173, new DateTime(2007, 1, 1), new DateTime(2008, 1, 1), new DateTime(2007, 12, 1));
            result = ClientEnvironment.StoreService.EmlpoyeeHolidaysSumInfoByEmployeeIDGet(19832,new DateTime(2007, 1, 1), new DateTime(2008, 1, 1), new DateTime(2007, 12, 1));
            */
            /*
            DateTime? dateresult = ClientEnvironment.StoreService.LastEmployeeWeekTimePlanningGet(1173);
            bool result = ClientEnvironment.StoreService.LastEmployeeWeekTimePlanningUpdate(1173, new DateTime(2007, 12, 1));
            */
            //IList result = ClientEnvironment.EmployeeService.EmployeeTimeService.EmployeeListContractEndOutsideChangedGet();

        }

		private void testEmployee()
		{
			login();
			List<Store> storelist= _StoreService.FindAll();

			Employee e = new Employee();
			e.PersID = "new2";
			e.FirstName = "Шура";
			e.LastName = "Мархонько";
			e.Import = false;
			e.CreateDate = DateTime.Now;
			if (storelist.Count > 0)
				e.MainStoreID = storelist[0].ID;
			e.OldHolidays = 7;
			e.NewHolidays = 55;
			e.BalanceHours = 78;
			e.ContractBegin = DateTime.Now;
			e.ContractEnd = DateTime.Now.AddYears(5);
			e.ContractWorkingHours = 12;
			try
			{
				e = _EmployeeService.Save(e);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void testDateTime()
        {
            //MessageBox.Show(System.Drawing.Color.Black.ToString());

            /*
            MessageBox.Show(string.Format("begin {0}, end {1}", DateTimeSql.GetBegin(DateTime.Now), DateTimeSql.GetEnd(DateTime.Now)));
            MessageBox.Show(string.Format("begin {0}, end {1}", DateTimeSql.GetBegin(DateTime.Now), DateTimeSql.GetEnd(DateTimeSql.SmallDatetimeMax)));
            MessageBox.Show(string.Format("begin {0}, end {1}", DateTimeSql.GetBegin(DateTime.Now), DateTimeSql.GetEnd(DateTimeSql.DatetimeMax)));
            */
            login();
            try
            {
                ClientEnvironment.EmployeeService.Merge(27753, 27754);
            }
            catch (EmployeeMergeException ex)
            {
                MessageBox.Show(ex.EmployeeMergeError.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void testBLToolkit()
        { 
            try
            {
                login();
                long ausrtriaCountryID = ClientEnvironment.CountryService.AustriaCountryID;
                MessageBox.Show(ausrtriaCountryID.ToString());
                //Employee list = ClientEnvironment.EmployeeService.GetEmployeeByID(23461, DateTime.Now);
                //short[] years= ClientEnvironment.StoreService.GetCalculatedYears();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
	    
	    void TestSqlMapping()
	    {
            login();
            _StoreService.GetStoreStructure(1178);
	    }

        private void btnImportBusinessVolume_Click(object sender, EventArgs e)
        {
            login();
            FrmImport frmImport = new FrmImport( ClientEnvironment.ImportParam, ImportType.ActualBusinessVolume);
            frmImport.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            login();
            FrmImport frmImport = new FrmImport(ClientEnvironment.ImportParam, ImportType.TargetBusinessVolume);
            frmImport.ShowDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            login();
            FrmImport frmImport = new FrmImport(ClientEnvironment.ImportParam, ImportType.CashRegisterReceipt);
            frmImport.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientEnvironment.EmployeeService.EmployeeTimeService.RecalculateInactiveEmployees();
        }
	}
}