using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Import;

namespace Baumax.ClientUI.Import
{
    using Baumax.Environment;
    using Baumax.Contract;
    using Baumax.Domain;
    using Baumax.Import.UI;

    public class ImportUI
    {
        public static bool ImportLongTimeAbsences()
        {
            return DoImport(ImportType.LongTimeAbsence);
        }

        public static bool ImportEmployees()
        {
            return DoImport(ImportType.Employee);
        }

        public static bool ImportCountries()
        {
            return DoImport(ImportType.Country);
        }

        public static bool ImportRegions()
        {
            return DoImport(ImportType.Region);
        }

        public static bool ImportStores()
        {
            return DoImport(ImportType.Store);
        }

        public static bool ImportWorlds()
        {
            return DoImport(ImportType.World);
        }

        public static bool ImportHwgrs()
        {
            return DoImport(ImportType.HWGR);
        }

        public static bool ImportWgrs()
        {
            return DoImport(ImportType.WGR);
        }

        public static bool ImportFeasts()
        {
            return DoImport(ImportType.Feast);
        }

        public static bool ImportWorkingDays()
        {
            return DoImport(ImportType.WorkingDays);
        }

        public static bool ImportCashRegisterReceipt()
        {
            return DoImport(ImportType.CashRegisterReceipt);
        }

        public static bool ImportTargetBusinessVolume()
        {
            return DoImport(ImportType.TargetBusinessVolume);
        }

        public static bool ImportBusinessVolume()
        {
            return DoImport(ImportType.ActualBusinessVolume);
        }

        public static bool ImportTimePlanning()
        {
            return DoImport(ImportType.TimePlanning);
        }

        public static bool ImportTimeRecording()
        {
            return DoImport(ImportType.TimeRecording);
        }

        private static bool DoImport(ImportType importType)
        {
            using (FrmImport frmImport = new FrmImport(ClientEnvironment.ImportParam, importType))
            {
                frmImport.ShowDialog();
                return frmImport.BeenRunSuccessfully;
            }
        }
    }
}
