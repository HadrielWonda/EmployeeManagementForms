using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.QueryResult;
using Baumax.Contract;
using Baumax.Contract.Interfaces;
using Baumax.Contract.Import;

namespace Baumax.Import
{
    internal class ImportBusinessVolume : ImportBase
    {
        private BusinessVolumeType _ImportType;
        private IStoreService _StoreService;
        private bool _ImportRunning;
        private string _ImportName;
        private Exception _Exception;

        internal ImportBusinessVolume(IStoreService storeService, BusinessVolumeType importType)
            : base(null, null)
        {
            _StoreService = storeService;
            _ImportRunning = true;
            _ImportType = importType;
        }

        protected override string ImportName
        {
            get
            {
                if (string.IsNullOrEmpty(_ImportName))
                {
                    if (_ImportType == BusinessVolumeType.Actual)
                    {
                        _ImportName = GetLocalized("inActualBusinessVolume");
                    }
                    else if (_ImportType == BusinessVolumeType.Target)
                    {
                        _ImportName = GetLocalized("inTargetBusinessVolume");
                    }
                    else
                    {
                        _ImportName = GetLocalized("inCashRegisterReceipt");
                    }
                }
                return _ImportName;
            }
        }

        protected override void readCSVFile()
        {
            _StoreService.ImportBusinessVolumeComplete +=
                new OperationCompleteDelegate(storeService_OnImportBusinessVolumeComplete);
            _StoreService.ImportBusinessVolumeMessageInfo +=
                new MessageInfoDelegate(storeService_OnImportBusinessVolumeMessageInfo);
            try
            {
                _StoreService.ImportBusinessVolume(_ImportType);
                while (_ImportRunning)
                {
                    Thread.Sleep(1000);
                }
            }
            finally
            {
                _StoreService.ImportBusinessVolumeComplete -=
                    new OperationCompleteDelegate(storeService_OnImportBusinessVolumeComplete);
                _StoreService.ImportBusinessVolumeMessageInfo -=
                    new MessageInfoDelegate(storeService_OnImportBusinessVolumeMessageInfo);
            }
            if (!_CompleteResult && _Exception != null)
            {
                throw _Exception;
            }
        }
/*
        private void storeService_OnImportBusinessVolumeMessageInfo(object sender, MessageInfoEventArgs e)
        {
            string[] files = (string[]) e.Param;
            if (files != null && files.Length > 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    message(files[i]);
                }
            }
        }
*/
        private void storeService_OnImportBusinessVolumeMessageInfo(object sender, MessageInfoEventArgs e)
        {
            MessageStringInfo messageStringInfo = (MessageStringInfo)e.Param;
            if (messageStringInfo != null && messageStringInfo.BusinessVolumeType == _ImportType)
            {
                if (!messageStringInfo.LocalizeKey)
                {
                    if (messageStringInfo.MessageParams != null)
                        message(string.Format(messageStringInfo.Message, messageStringInfo.MessageParams), messageStringInfo.NewLine);
                    else
                        message(messageStringInfo.Message, messageStringInfo.NewLine);
                }
                else
                { 
                    if (messageStringInfo.MessageParams != null)
                        message(string.Format(GetLocalized(messageStringInfo.Message), messageStringInfo.MessageParams), messageStringInfo.NewLine);
                    else
                        message(GetLocalized(messageStringInfo.Message), messageStringInfo.NewLine);
                
                }
            }
        }

        private void storeService_OnImportBusinessVolumeComplete(object sender, OperationCompleteEventArgs e)
        {
            ImportBusinessValuesResult importBusinessValuesResult = (ImportBusinessValuesResult)e.Param;
            if (importBusinessValuesResult.BusinessVolumeType == _ImportType)
            {
                _CompleteResult = e.Success;
                if (_CompleteResult)
                {
                    if (importBusinessValuesResult.FilesCount <= 0)
                    {
                        _CompleteResult = false;
                        _Exception = new Exception(GetLocalized("NoFilesMatchSpec"));
                    }
                }
                else
                {
                    _Exception = (Exception)importBusinessValuesResult.Data;
                }
                _ImportRunning = false;
            }
        }
    }
}