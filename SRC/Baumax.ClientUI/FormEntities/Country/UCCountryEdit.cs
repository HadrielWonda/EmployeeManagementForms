using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Baumax.ClientUI.FormEntities.Country.UIColoring;
using Baumax.ClientUI.FormEntities.Country.UIWorkingModel;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Environment;
using Baumax.Import;
using Baumax.Import.UI;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Baumax.ClientUI.FormEntities.Country
{
    public partial class UCCountryEdit : UCBaseEntity
    {

        private XtraUserControl _currentControl = null;

        private FeastListControl ucFeastControl = null;
        private UCClosedDays ucClosedDaysControl = null;
        private UCAvgWorkingDaysInWeek ucAvgWDIWeekControl = null;
        private YearlyAppearanceListControl ucYearlyAppearance = null;
        private UCCountryProperties ucCountryProperties = null;
        private ColoringListControl ucColorControl;
        private AbsenceListControl ucAbsenceList;
        private UCLongTimeAbsenceList ucLongTimeAbsenceList;
        private WModelList ucWorkingModels;
        private UCUnavoidableAddHours ucUnAdHours = null;
        private UCLunchBrakes ucLucnchBrk = null;

        public UCCountryEdit()
        {
            InitializeComponent();
        }
        
        static public bool isUserWriteRight()
        {
            IAuthorizationService auth = ClientEnvironment.AuthorizationService;
            AccessType country_service = auth.GetAccess(ClientEnvironment.CountryService);
            return (country_service & AccessType.Write) != 0;
        }
        #region Check Estimation years

        static private Dictionary<short, bool> listEstimationYears = new Dictionary<short, bool>();
        static private Store[] stores;
        static private long countryID = 0;
        
        static private void FillListEstimationWorkingHoursExistsInYear(short year)
        {
            if (!listEstimationYears.ContainsKey(year))
                listEstimationYears[year] = IsEstimationExistByCountry(year);
            //ClientEnvironment.StoreService.EstimationWorkingHoursExists(year);
        }

       /* static public void RecheckEstimationWorkingHoursExistsInYear(short year)
        {
            if (listEstimationYears != null)
                listEstimationYears[year] = ClientEnvironment.StoreService.EstimationWorkingHoursExists(year);
        }
        */
        static public  void ClearListEstimationYears()
        {
            if (listEstimationYears != null && listEstimationYears.Count != 0)
            {
                listEstimationYears.Clear();
            }
        }

        static public bool IsEstimationExist(DateTime amount, long countryid) 
        {
           countryID = countryid;
           FillListEstimationWorkingHoursExistsInYear((short)amount.Year);
           return listEstimationYears[(short) amount.Year];    
                 
        }

        static public bool IsEstimationExist(short year, long countryid)
        {
            countryID = countryid;
            FillListEstimationWorkingHoursExistsInYear(year);
            return listEstimationYears[year];
        }
        
        static private bool IsEstimationExistByCountry(int year)
        {
            if (countryID > 0)
                stores = ClientEnvironment.StoreService.GetStoresByCountryId(countryID);
            else
                throw new Exception("CountryID < 1");
            if (stores != null && stores.Length != 0)
            {
                foreach (Store store in stores)
                {
                    if (ClientEnvironment.StoreService.EstimationWorkingHoursExists(store.ID, year))
                        return true;
                }
            }
            return false;
        }
        #endregion
        
        private void InitMainToolBar()
        {
            //if (bar_Common.ItemLinks.Count != 0)
            {
                bar_Common.ClearLinks();

                bi_CountryColor.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                bi_Country.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                bi_Feasts.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                bi_ClosedDays.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                bi_YearlyAppearance.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                bi_WorkingModels.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                bi_AverageWorkingDayInWeek.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                bi_UnAddHours.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                bi_lunchModels.PaintStyle = BarItemPaintStyle.CaptionGlyph;

                bar_Common.ItemLinks.Add(bi_Country);  
                bar_Common.ItemLinks.Add(bi_AverageWorkingDayInWeek);
                bar_Common.ItemLinks.Add(bi_YearlyAppearance);
                bar_Common.ItemLinks.Add(bi_UnAddHours);
                bar_Common.ItemLinks.Add(bi_ClosedDays);
                bar_Common.ItemLinks.Add(bi_Feasts);
                bar_Common.ItemLinks.Add(bi_CountryColor);
                bar_Common.ItemLinks.Add(bi_Absences);
                bar_Common.ItemLinks.Add(bi_LongTimeAbsences);
                bar_Common.ItemLinks.Add(bi_WorkingModels);
                bar_Common.ItemLinks.Add(bi_lunchModels);
            }

        }

        public override void AssignLanguage()
        {
            if (ClientEnvironment.IsRuntimeMode)
            {
                base.AssignLanguage();
                LocalizerControl.ComponentsLocalize(components);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                bar_Common.LinksPersistInfo.Clear();
                InitMainToolBar();
                InitCountryPropertiesControl();
            }
        }

        public Domain.Country EntityCountry
        {
            get { return (Domain.Country)Entity; }
            set { Entity = value; }
        }
        protected override void EntityChanged()
        {
            if (Entity != null)
            {
                UCBaseEntity uc = (_currentControl as UCBaseEntity);
                if (uc != null) uc.Entity = Entity;
            }
        }
        
         private void  ClearPressedButtons()
         {
             bi_CountryColor.Border = 
             bi_Country.Border = 
             bi_Absences.Border = 
             bi_Feasts.Border = 
             bi_ClosedDays.Border = 
             bi_WorkingModels.Border = 
             bi_YearlyAppearance.Border = 
             bi_LongTimeAbsences.Border = 
             bi_UnAddHours.Border =
             bi_lunchModels.Border =
             bi_AverageWorkingDayInWeek.Border = BorderStyles.NoBorder;
             
         }
        
        private void CreateBarControl()
        {
            ClearPressedButtons();
            
            if (_currentControl is UCClosedDays)
            {
                bi_ClosedDays.Border = BorderStyles.Simple;
                return;
            }

            if (_currentControl is AbsenceListControl)
            {
                bi_Absences.Border = BorderStyles.Simple;
                return;
            }
            if (_currentControl is UCLongTimeAbsenceList)
            {
                bi_LongTimeAbsences.Border = BorderStyles.Simple;
                return;
            }

            
            if (_currentControl is ColoringListControl)
            {
                bi_CountryColor.Border = BorderStyles.Simple;
                return;
            }
            if (_currentControl is WModelList)
            {
                bi_WorkingModels.Border = BorderStyles.Simple;
                return;

            }
            if (_currentControl is FeastListControl)
            {
                bi_Feasts.Border = BorderStyles.Simple;
                return;
            }
            if (_currentControl is YearlyAppearanceListControl)
            {
                bi_YearlyAppearance.Border = BorderStyles.Simple;
                return;
            }

            if (_currentControl is UCCountryProperties)
            {
                bi_Country.Border = BorderStyles.Simple;
                return;
            }
            
            if (_currentControl is UCAvgWorkingDaysInWeek)
            {
                bi_AverageWorkingDayInWeek.Border = BorderStyles.Simple;
                return;
            }
            
            if (_currentControl is UCUnavoidableAddHours)
            {
                bi_UnAddHours.Border = BorderStyles.Simple;
                return;
            }

            if (_currentControl is UCLunchBrakes)
            {
                bi_lunchModels.Border = BorderStyles.Simple;
                return;
            }
        }

        private void ReleaseControl()
        {
            if (_currentControl != null)
            {
                _currentControl.Hide();
                _currentControl.Parent = null;
                _currentControl.Dispose();
                _currentControl = null;
            }
        }

        void InitColoringControl()
        {
            if (_currentControl == null || !(_currentControl is ColoringListControl))
            {

                ReleaseControl();
                ucColorControl = new ColoringListControl();
                ucColorControl.Parent = pcClient;

                ucColorControl.Dock = DockStyle.Fill;
                ucColorControl.Show();
                ucColorControl.Country = EntityCountry;

                if (ClientEnvironment.IsRuntimeMode )

                    ucColorControl.InitControl();

                _currentControl = ucColorControl;

                CreateBarControl();
            }

        }
        void InitYearAppearanceControl()
        {
            if (_currentControl == null || !(_currentControl is YearlyAppearanceListControl))
                {
                ClearListEstimationYears();
                ReleaseControl();
                ucYearlyAppearance = new YearlyAppearanceListControl();
                ucYearlyAppearance.Parent = pcClient;

                ucYearlyAppearance.Dock = DockStyle.Fill;
                ucYearlyAppearance.Show();

                ucYearlyAppearance.EntityCountry = EntityCountry;
                _currentControl = ucYearlyAppearance;
                CreateBarControl();
                
            }

        }
        void InitAbsenceControl()
        {
            if (_currentControl == null || !(_currentControl is AbsenceListControl))
            {
                ReleaseControl();
                ucAbsenceList = new AbsenceListControl();
                ucAbsenceList.Parent = pcClient;
                ucAbsenceList.Dock = DockStyle.Fill;
                ucAbsenceList.Show();
                ucAbsenceList.Entity = Entity;
                ucAbsenceList.InitControl();

                _currentControl = ucAbsenceList;
                CreateBarControl();
            }

        }
        void InitLongTimeAbsenceControl()
        {
            if (_currentControl == null || !(_currentControl is UCLongTimeAbsenceList))
            {
                ReleaseControl();
                ucLongTimeAbsenceList = new UCLongTimeAbsenceList();
                ucLongTimeAbsenceList.Parent = pcClient;
                ucLongTimeAbsenceList.Dock = DockStyle.Fill;
                ucLongTimeAbsenceList.Show();
                ucLongTimeAbsenceList.Entity = Entity;
               // ucLongTimeAbsenceList.InitLongTimeAbsence();

                _currentControl = ucLongTimeAbsenceList;
                CreateBarControl();
            }

        }
        void InitWorkingModelControl()
        {
            if (_currentControl == null || !(_currentControl is WModelList))
            {
                ReleaseControl();

                ucWorkingModels = new WModelList();
                ucWorkingModels.Parent = pcClient;
                ucWorkingModels.Dock = DockStyle.Fill;
                ucWorkingModels.Show();
                ucWorkingModels.Entity = Entity;

                _currentControl = ucWorkingModels;
                CreateBarControl();
            }

        }

        void InitFeastControl()
        {
            if (_currentControl == null || !(_currentControl is FeastListControl))
            {
                ReleaseControl();
                //ClearListEstimationYears();
                ucFeastControl = new FeastListControl();
                ucFeastControl.Parent = pcClient;
                ucFeastControl.Dock = DockStyle.Fill;
                ucFeastControl.Show();
                ucFeastControl.Entity = Entity;

                _currentControl = ucFeastControl;
                CreateBarControl();
                
            }

        }

        void InitClosedDaysControl()
        {
            if (_currentControl == null || !(_currentControl is UCClosedDays))
            {
                ReleaseControl();
                ClearListEstimationYears();
                ucClosedDaysControl = new UCClosedDays();
                ucClosedDaysControl.Parent = pcClient;
                ucClosedDaysControl.Dock = DockStyle.Fill;
                ucClosedDaysControl.Show();
                ucClosedDaysControl.Entity = Entity;

                _currentControl = ucClosedDaysControl;
                CreateBarControl();
                
            }

        }


        void InitCountryPropertiesControl()
        {
            if (_currentControl == null || !(_currentControl is UCCountryProperties))
            {
                ReleaseControl();

                ucCountryProperties = new UCCountryProperties();
                ucCountryProperties.Parent = pcClient;
                ucCountryProperties.Dock = DockStyle.Fill;
                ucCountryProperties.Show();
                ucCountryProperties.Init();
                ucCountryProperties.Entity = Entity;
                _currentControl = ucCountryProperties;
                CreateBarControl();
            }

        }

        void InitAvgWorkingDaysInWeekControl()
        {
            if (_currentControl == null || !(_currentControl is UCAvgWorkingDaysInWeek))
            {
                ReleaseControl();

                ucAvgWDIWeekControl = new UCAvgWorkingDaysInWeek();
                ucAvgWDIWeekControl.Parent = pcClient;
                ucAvgWDIWeekControl.Dock = DockStyle.Fill;
                ucAvgWDIWeekControl.Show();
                ucAvgWDIWeekControl.Entity = Entity;

                _currentControl = ucAvgWDIWeekControl;
                CreateBarControl();
            }

        }

        void InitUnavoidableAdditionalHoursControl()
        {
            if (_currentControl == null || !(_currentControl is UCUnavoidableAddHours))
            {
                ReleaseControl();
                ClearListEstimationYears();
                ucUnAdHours = new UCUnavoidableAddHours();
                ucUnAdHours.Parent = pcClient;
                ucUnAdHours.Dock = DockStyle.Fill;
                ucUnAdHours.Show();
                ucUnAdHours.Entity = Entity;
                _currentControl = ucUnAdHours;
                CreateBarControl();
                
            }
        }

        void InitLunchBreakControl()
        {
            if (_currentControl == null || !(_currentControl is UCLunchBrakes))
            {
                ReleaseControl();
                ClearListEstimationYears(); // may be not need
                ucLucnchBrk = new UCLunchBrakes();
                ucLucnchBrk.Parent = pcClient;
                ucLucnchBrk.Dock = DockStyle.Fill;
                ucLucnchBrk.Show();
                ucLucnchBrk.Entity = Entity;
                _currentControl = ucLucnchBrk;
                CreateBarControl();
            }
        }
        
        private void bi_DefineColoring_ItemClick(object sender, ItemClickEventArgs e)
        {

            InitColoringControl();
        }

        private void bi_AbsenceDefinition_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitAbsenceControl();
        }

        private void bi_WorkingModels_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitWorkingModelControl();
        }

        private void bi_YearlyFeasts_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitFeastControl();
        }

        private void bi_CountryProperties_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitYearAppearanceControl();
        }

        private void bi_TimeRecordingRange_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitCountryPropertiesControl();
        }

        private void bi_Import_ItemClick(object sender, ItemClickEventArgs e)
        {
           if (_currentControl is FeastListControl)
            {
                using (FrmImport frmImport = new FrmImport(ClientEnvironment.ImportParam, 
                                                            ImportType.Feast))
                {
                    frmImport.ShowDialog();
                    if (frmImport.BeenRunSuccessfully)
                        ucFeastControl.ReloadFeasts();
                }
            }
        }

        private void bi_LongTimeAbsences_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitLongTimeAbsenceControl();
        }

        private void bi_CloseDays_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitClosedDaysControl();
        }
        
        private void bi_AvgWorkingDayInWeek_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitAvgWorkingDaysInWeekControl();
        }

        private void bi_UnAddHours_Click(object sender, ItemClickEventArgs e)
        {
            InitUnavoidableAdditionalHoursControl(); 
        }

        private void bi_LunchBrakes_Click(object sender, ItemClickEventArgs e)
        {
            InitLunchBreakControl();
        }
    }
}
