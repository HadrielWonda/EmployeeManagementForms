using System;
using System.Xml;
using System.IO;
using System.Text;
using Baumax.Util;
using Baumax.Contract.Import;
using System.Collections.Generic;

namespace Baumax.Import.Util
{
    public static class ImportUtil
    {
        private const string _ErrorFilePrefix = "error";

        public static string ErrorFilePrefix
        {
            get { return _ErrorFilePrefix; }
        }

        private static string getRecourseFileName(BusinessVolumeType importType)
        {
            string result= @"Resources\FormatFiles\{0}";
            switch (importType)
            {
                case BusinessVolumeType.Actual:
                    result = string.Format(result, "BusinessVolume.ftm");
                    break;
                case BusinessVolumeType.Target:
                    result = string.Format(result, "BusinessVolumeTarget.ftm");
                    break;
                case BusinessVolumeType.CashRegisterReceipt:
                    result = string.Format(result, "CashRegisterReceipt.ftm");
                    break;
                default:
                    goto case BusinessVolumeType.Actual;
            }
            return result;
        }
        
        public static string GetFilesListInXml(string[] files)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = false;
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Root");
            for (int i = 0; i < files.Length; i++)
            {
                writer.WriteStartElement("File");
                writer.WriteAttributeString("name", files[i]);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
            return sb.ToString();
        }

        public static string GetFormatFile(string folderName, BusinessVolumeType importType)
        {
            string resourceName= getRecourseFileName(importType);
            string fileName= "";
            if (!string.IsNullOrEmpty(resourceName))
            {
                fileName = Path.Combine(folderName, Path.GetFileName(resourceName));
                if (!File.Exists(fileName))
                    EmbeddedResource.SaveResourceToFile(typeof(ImportUtil), resourceName, fileName,Encoding.Default);
            }
            return fileName;
        }

        public static string[] GetBusinessVolumeFilesList(string folderName, BusinessVolumeType bvImportType)
        {
            ImportType importType;
            switch (bvImportType)
            {
                case BusinessVolumeType.Actual:
                    importType = ImportType.ActualBusinessVolume;
                    break;
                case BusinessVolumeType.Target:
                    importType = ImportType.TargetBusinessVolume;
                    break;
                case BusinessVolumeType.CashRegisterReceipt:
                    importType = ImportType.CashRegisterReceipt;
                    break;
                default:
                    goto case BusinessVolumeType.Actual;
            }
            return GetImportFilesList(folderName, importType);
        }

        public static string[] GetImportFilesList(string folderName, ImportType importType)
        {
            string fileSearchPattern = GetFileSearchPattern(importType);
            string[] files = Directory.GetFiles(folderName, fileSearchPattern);
            List<string> result = new List<string>(files.Length);
            for (int i = 0; i < files.Length; i++)
                if (!Path.GetFileName(files[i]).StartsWith(ErrorFilePrefix, true, null))
                    result.Add(files[i]);
            return result.ToArray();
        }

        private static string GetFileSearchPattern(ImportType importType)
        {
            string fileSearchPattern;
            switch (importType)
            {
                case ImportType.Country:
                    fileSearchPattern = ImportManager.CountryFileSearchPattern;
                    break;
                case ImportType.Region:
                    fileSearchPattern = ImportManager.RegionFileSearchPattern;
                    break;
                case ImportType.Store:
                    fileSearchPattern = ImportManager.StoresFileSearchPattern;
                    break;
                case ImportType.World:
                    fileSearchPattern = ImportManager.WorldsFileSearchPattern;
                    break;
                case ImportType.HWGR:
                    fileSearchPattern = ImportManager.HwgrFileSearchPattern;
                    break;
                case ImportType.WGR:
                    fileSearchPattern = ImportManager.WgrFileSearchPattern;
                    break;
                case ImportType.WorkingDays:
                    fileSearchPattern = ImportManager.WorkingdaysFileSearchPattern;
                    break;
                case ImportType.Feast:
                    fileSearchPattern = ImportManager.FeastsFileSearchPattern;
                    break;
                case ImportType.Employee:
                    fileSearchPattern = ImportManager.EmployeeFileSearchPattern;
                    break;
                case ImportType.LongTimeAbsence:
                    fileSearchPattern = ImportManager.LongTimeAbsenceFileSearchPattern;
                    break;
                case ImportType.Absence:
                    fileSearchPattern = ImportManager.AbsenceFileSearchPattern;
                    break;
                case ImportType.TimePlanning:
                    fileSearchPattern = ImportManager.TimePlanningFileSearchPattern;
                    break;
                case ImportType.TimeRecording:
                    fileSearchPattern = ImportManager.TimeRecordingFileSearchPattern;
                    break;
                case ImportType.ActualBusinessVolume:
                    fileSearchPattern = ImportManager.BusinessVolumeActualFileSearchPattern;
                    break;
                case ImportType.TargetBusinessVolume:
                    fileSearchPattern = ImportManager.BusinessVolumeTargetFileSearchPattern;
                    break;
                case ImportType.CashRegisterReceipt:
                    fileSearchPattern = ImportManager.CashRegisterReceiptFileSearchPattern;
                    break;
                default:
                    throw new NotSupported();
            }
            return fileSearchPattern;
        }

        public static void MoveFilesInFolder(string folderName, string[] files)
        {
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);
            for(int i= 0; i < files.Length; i++)
            {
                string destFile = Path.Combine(folderName, Path.GetFileName(files[i]));
                if (File.Exists(destFile))
                    File.Delete(destFile);
                File.Move(files[i], destFile);
            }
        }

        public static string GetErrorFileName(string fileName)
        {
            string result = string.Format("{0}{1}",_ErrorFilePrefix, Path.GetFileName(fileName));
            return Path.Combine(Path.GetDirectoryName(fileName),result);
        }

        public static string GetErrorDetailsFileName(string errorFileName)
        {
            return string.Format("{0}.Error.Txt", errorFileName);
        }

        public static string [] GetFilesWithErrorsForFile(string fileName)
        {
            string[] result= new string[3];
            result[0] = fileName;
            result[1] = GetErrorFileName(fileName);
            result[2] = GetErrorDetailsFileName(result[1]);
            return result;
        }

        public static string GetTableName(BusinessVolumeType importType)
        {
            string result;
            switch (importType)
            {
                case BusinessVolumeType.Actual:
                    result = "BusinessVolumeActual";
                    break;
                case BusinessVolumeType.Target:
                    result = "BusinessVolumeTarget";
                    break;
                case BusinessVolumeType.CashRegisterReceipt:
                    result= "CashRegisterReceipt";
                    break;
                default:
                    goto case BusinessVolumeType.Actual;
            }
            return result;
        }

        public static string[] GetImportLogFileNames()
        {
            List<string> result = new List<string>();
            string name;
            foreach (ImportType importType in Enum.GetValues(typeof(ImportType)))
            {
                if (importType != ImportType.All)
                {
                    name = GetFileSearchPattern(importType);
                    name = name.Substring(1, name.Length - 6);
                }
                else
                    name = importType.ToString();
                result.Add(name);
            }
            return result.ToArray();
        }

    }
}
