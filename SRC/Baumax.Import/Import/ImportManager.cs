using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract.Import;

namespace Baumax.Import
{
    public class ImportManager
    {
        #region consts

        private const string country = "country";
        private const string workingdays = "workingdays";
        private const string feasts = "yearlyfeasts";
        private const string region = "region";
        private const string stores = "stores";
        private const string worlds = "worlds";
        private const string hwgr = "hwgr";
        private const string wgr = "wgr";
        private const string employee = "personal";
        private const string longtimeabsence = "austria_inactiv_personal_ltabs";
        private const string absence = "austria_absencetypes";
        private const string timeplanning = "austria_absences";
        private const string timerecording = "austria_actualworkingtime";
        private const string businessvolume = "actualbusinessvolume";
        private const string businessvolumetarget = "targetbusinessvolume";
        private const string cashregisterreceipt = "crr";

        #endregion

        #region public static 

        public static readonly string BusinessVolumeActualFileSearchPattern;
        public static readonly string BusinessVolumeTargetFileSearchPattern;
        public static readonly string CashRegisterReceiptFileSearchPattern;
        public static readonly string CountryFileSearchPattern;
        public static readonly string WorkingdaysFileSearchPattern;
        public static readonly string FeastsFileSearchPattern;
        public static readonly string RegionFileSearchPattern;
        public static readonly string StoresFileSearchPattern;
        public static readonly string WorldsFileSearchPattern;
        public static readonly string HwgrFileSearchPattern;
        public static readonly string WgrFileSearchPattern;
        public static readonly string EmployeeFileSearchPattern;
        public static readonly string LongTimeAbsenceFileSearchPattern;
        public static readonly string AbsenceFileSearchPattern;
        public static readonly string TimePlanningFileSearchPattern;
        public static readonly string TimeRecordingFileSearchPattern;


        public static string ImportName(ImportType importType)
        {
            string result = "";
            switch (importType)
            {
                case ImportType.Country:
                    result = "inCountries";
                    break;
                case ImportType.Region:
                    result = "inRegions";
                    break;
                case ImportType.Store:
                    result = "inStories";
                    break;
                case ImportType.World:
                    result = "inWorlds";
                    break;
                case ImportType.HWGR:
                    result = "inHWGRs";
                    break;
                case ImportType.WGR:
                    result = "inWGRs";
                    break;
                case ImportType.WorkingDays:
                    result = "inWorkingDays";
                    break;
                case ImportType.Feast:
                    result = "inFeasts";
                    break;
                case ImportType.Employee:
                    result = "inEmployee";
                    break;
                case ImportType.LongTimeAbsence:
                    result = "inLongTimeAbsence";
                    break;
                case ImportType.Absence:
                    result = "inAbsence";
                    break;
                case ImportType.TimePlanning:
                    result = "inTimePlanning";
                    break;
                case ImportType.TimeRecording:
                    result = "inTimeRecording";
                    break;
                case ImportType.ActualBusinessVolume:
                    result = "inActualBusinessVolume";
                    break;
                case ImportType.TargetBusinessVolume:
                    result = "inTargetBusinessVolume";
                    break;
                case ImportType.CashRegisterReceipt:
                    result = "inCashRegisterReceipt";
                    break;
                case ImportType.All:
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(result))
            {
                result = Baumax.Localization.Localizer.GetLocalized(result);
            }
            return result;
        }

        #endregion

        #region public var

        public event MessageEventHandler OnMessage;
        public event CompleteEventHandler OnAllComplete;
        public event ProgressEventHandler OnAllProgressChanged;
        public event CompleteEventHandler OnTaskComplete;
        public event ProgressEventHandler OnTaskProgressChanged;

        #endregion

        #region constructors

        public ImportManager()
        {
        }

        static ImportManager()
        {
            string format = "*{0}*.txt";
            BusinessVolumeActualFileSearchPattern = string.Format(format, businessvolume);
            BusinessVolumeTargetFileSearchPattern = string.Format(format, businessvolumetarget);
            CashRegisterReceiptFileSearchPattern = string.Format(format, cashregisterreceipt);
            CountryFileSearchPattern = string.Format(format, country);
            WorkingdaysFileSearchPattern = string.Format(format, workingdays);
            FeastsFileSearchPattern = string.Format(format, feasts);
            RegionFileSearchPattern = string.Format(format, region);
            StoresFileSearchPattern = string.Format(format, stores);
            WorldsFileSearchPattern = string.Format(format, worlds);
            HwgrFileSearchPattern = string.Format(format, hwgr);
            WgrFileSearchPattern = string.Format(format, wgr);
            EmployeeFileSearchPattern = string.Format(format, employee);
            LongTimeAbsenceFileSearchPattern = string.Format(format, longtimeabsence);
            AbsenceFileSearchPattern = string.Format(format, absence);
            TimePlanningFileSearchPattern = string.Format(format, timeplanning);
            TimeRecordingFileSearchPattern = string.Format(format, timerecording);
        }

        #endregion

        #region private metods

        private void import(object param)
        {
            ImportBase import = null;
            ImportParam importParam = (ImportParam) param;
            switch (importParam.ImportType)
            {
                case ImportType.Country:
                    import = new ImportCountry(importParam.FileName, (ICountryService) importParam.Service[0]);
                    break;
                case ImportType.Region:
                    import =
                        new ImportRegion(importParam.FileName, (ICountryService) importParam.Service[0],
                                         (IRegionService) importParam.Service[1]);
                    break;
                case ImportType.Store:
                    import =
                        new ImportStore(importParam.FileName, (ICountryService) importParam.Service[0],
                                        (IRegionService) importParam.Service[1], (IStoreService) importParam.Service[2]);
                    break;
                case ImportType.World:
                    import = new ImportWorld(importParam.FileName, (IStoreService) importParam.Service[0]);
                    break;
                case ImportType.HWGR:
                    import = new ImportHWGRdb(importParam.FileName, (IStoreService) importParam.Service[0]);
                    break;
                case ImportType.WGR:
                    import = new ImportWGRdb2(importParam.FileName, (IStoreService) importParam.Service[0]);
                    break;
                case ImportType.WorkingDays:
                    import = new ImportYearlyWorkingDays(importParam.FileName, (ICountryService) importParam.Service[0]);
                    break;
                case ImportType.Feast:
                    import = new ImportFeasts(importParam.FileName, (ICountryService) importParam.Service[0]);
                    break;
                case ImportType.Employee:
                    import = new ImportEmployee(importParam.FileName, (IEmployeeService) importParam.Service[0]);
                    break;
                case ImportType.LongTimeAbsence:
                    import = new ImportLongTimeAbsence(importParam.FileName, (IEmployeeService) importParam.Service[0]);
                    break;
                case ImportType.Absence:
                    import =
                        new ImportAbsence(importParam.FileName,
                                          ((ICountryService) importParam.Service[0]).AbsenceService);
                    break;
                case ImportType.TimePlanning:
                    import =
                        new ImportTime(importParam.FileName,
                                       ((IEmployeeService) importParam.Service[0]).EmployeeTimeService,
                                       ImportTimeType.Planning);
                    break;
                case ImportType.TimeRecording:
                    import =
                        new ImportTime(importParam.FileName,
                                       ((IEmployeeService) importParam.Service[0]).EmployeeTimeService,
                                       ImportTimeType.Recording);
                    break;
                case ImportType.ActualBusinessVolume:
                    import = new ImportBusinessVolume((IStoreService) importParam.Service[0], BusinessVolumeType.Actual);
                    break;
                case ImportType.TargetBusinessVolume:
                    import = new ImportBusinessVolume((IStoreService) importParam.Service[0], BusinessVolumeType.Target);
                    break;
                case ImportType.CashRegisterReceipt:
                    import =
                        new ImportBusinessVolume((IStoreService) importParam.Service[0],
                                                 BusinessVolumeType.CashRegisterReceipt);
                    break;
                default:
                    throw new NotSupported();
            }
            try
            {
                if (import != null)
                {
                    import.OnAllComplete += OnAllComplete;
                    import.OnAllProgressChanged += OnAllProgressChanged;
                    import.OnMessage += OnMessage;
                    import.OnTaskComplete += OnTaskComplete;
                    import.OnTaskProgressChanged += OnTaskProgressChanged;
                    import.Run();
                }
                else
                {
                    if (OnAllComplete != null)
                    {
                        OnAllComplete(this, new CompleteEventArgs(true));
                    }
                }
            }
            catch (Exception ex)
            {
                if (OnMessage != null)
                {
                    OnMessage(this, new MessageEventArgs(ex.Message));
                }
                if (OnAllComplete != null)
                {
                    OnAllComplete(this, new CompleteEventArgs(false));
                }
            }
        }

        #endregion

        #region public metods

        public static ImportType FileImportType(string fileName)
        {
#if(UseHeaders)
			return ImportBase.FileImportType(fileName);
#else
            return fileImportType(fileName);
#endif
        }

        private static ImportType fileImportType(string fileName)
        {
            fileName = fileName.ToLower();
            ImportType result;
            try
            {
                if (fileName.Contains(country))
                {
                    result = ImportType.Country;
                }
                else if (fileName.Contains(workingdays))
                {
                    result = ImportType.WorkingDays;
                }
                else if (fileName.Contains(workingdays))
                {
                    result = ImportType.WorkingDays;
                }
                else if (fileName.Contains(feasts))
                {
                    result = ImportType.Feast;
                }
                else if (fileName.Contains(region))
                {
                    result = ImportType.Region;
                }
                else if (fileName.Contains(stores))
                {
                    result = ImportType.Store;
                }
                else if (fileName.Contains(worlds))
                {
                    result = ImportType.World;
                }
                else if (fileName.Contains(hwgr))
                {
                    result = ImportType.HWGR;
                }
                else if (fileName.Contains(wgr))
                {
                    result = ImportType.WGR;
                }
                else if (fileName.Contains(longtimeabsence))
                {
                    result = ImportType.LongTimeAbsence;
                }
                else if (fileName.Contains(employee))
                {
                    result = ImportType.Employee;
                }
                else if (fileName.Contains(absence))
                {
                    result = ImportType.Absence;
                }
                else if (fileName.Contains(timeplanning))
                {
                    result = ImportType.TimePlanning;
                }
                else if (fileName.Contains(timerecording))
                {
                    result = ImportType.TimeRecording;
                }
                else
                {
                    throw new UnknownImportFile();
                }
            }
            catch (ArgumentException)
            {
                throw new SameColumnsInImportFile();
            }
            catch (Exception)
            {
                throw new UnknownImportFile();
            }
            return result;
        }

        public void Import(string fileName, ImportType importType, object[] service)
        {
            /*
			Thread thread = new Thread(new ParameterizedThreadStart(import));
			thread.Start(new ImportParam(fileName, importType, service));
            */

            InheritedContextAsyncStarter.Run(import, new ImportParam(fileName, importType, service));
        }

        #endregion

        private struct ImportParam
        {
            public string FileName;
            public ImportType ImportType;
            public object[] Service;

            public ImportParam(string fileName, ImportType importType, object[] service)
            {
                FileName = fileName;
                ImportType = importType;
                Service = service;
            }
        }
    }
}