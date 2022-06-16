using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using LumenWorks.Framework.IO.Csv;
using Baumax.Contract.Interfaces;
using Baumax.Domain;
using Baumax.Contract.Exceptions;

namespace Baumax.Import
{
	internal abstract class ImportBase
	{
		#region protected consts
		protected const string _NA = "N.A.";
		protected const string _null = "NULL";
		
		//ImportCountry
		protected const string _CountryID = "LandID";
		protected const string _CountryName = "VLLangbezDE";
		protected const string _VLID = "VLID";

		//ImportYearlyWorkingDays
		protected const string _WorkingDay = "Arbeitstage";

		//ImportRegion
		protected const string _RegionName = "RegionBez";

		//ImportStore
		protected const string _StoreIDIndex = "MarktID";
		protected const string _StoreName = "MarktBez";
		protected const string _City = "Ort";
		protected const string _Adress = "Strasse";
		protected const string _Area = "Flaeche";
		protected const string _PostCode = "PLZ";

		//ImportWorld
		protected const string _WorldID = "WeltID";
		protected const string _WorldName = "WeltLangbez";

		//ImoprtHWGR
		protected const string _HWGR_ID = "HWGRID";
		protected const string _HWGR_Name = "HWGRBez";

		//ImoprtWGR
		protected const string _WGR_ID = "WGRID";
		protected const string _WGR_Name = "WGRBez";

		//Feasts
		protected const string _FeastDate= "Feiertage";

		protected const int _RowsToSend = 150;

		protected ICountryService _IContryServise;

		#endregion

		#region protected vars
		
		protected string _FileName;
		protected int _CurrentRow;
        protected bool _CompleteResult;
        protected object _Result;
		#endregion

		#region internal var
		internal event MessageEventHandler OnMessage;
		internal event CompleteEventHandler OnAllComplete;
		internal event ProgressEventHandler OnAllProgressChanged;
		internal event CompleteEventHandler OnTaskComplete;
		internal event ProgressEventHandler OnTaskProgressChanged;

		#endregion

		protected virtual string ImportName
		{
			get { return "ImportBase"; }
		}

		internal static ImportType FileImportType(string fileName)
		{
            try
			{
				using (CachedCsvReader csv = new CachedCsvReader(new StreamReader(fileName, System.Text.Encoding.GetEncoding("iso-8859-2")), true, ';', '"'))
				{
                    csv.ReadNextRecord();
                    ImportType result;
                    if (csv.HasHeaders)
                    {
                        string[] headers = csv.GetFieldHeaders();
                        Dictionary<string, string> headersHash = new Dictionary<string, string>(headers.Length);
                        foreach (string header in headers)
                        {
                            headersHash.Add(header, header);
                        }

                        if (headersHash.ContainsKey(_VLID) && headersHash.ContainsKey(_CountryName))
                            result = ImportType.Country;
                        else if (headersHash.ContainsKey(_VLID) && headersHash.ContainsKey(_WorkingDay))
                            result = ImportType.WorkingDays;
                        else if (headersHash.ContainsKey(_VLID)
                                   && headersHash.ContainsKey(_RegionName)
                                   && headersHash.ContainsKey(_StoreIDIndex)
                                   && headersHash.ContainsKey(_StoreName)
                                   && headersHash.ContainsKey(_City)
                                   && headersHash.ContainsKey(_Adress)
                                   && headersHash.ContainsKey(_Area)
                                   && headersHash.ContainsKey(_PostCode))
                            result = ImportType.Store;
                        else if (headersHash.ContainsKey(_VLID) && headersHash.ContainsKey(_RegionName))
                            result = ImportType.Region;
                        else if (headersHash.ContainsKey(_WorldID) && headersHash.ContainsKey(_WorldName))
                            result = ImportType.World;
                        else if (headersHash.ContainsKey(_WorldID)
                                   && headersHash.ContainsKey(_HWGR_ID)
                                   && headersHash.ContainsKey(_HWGR_Name))
                            result = ImportType.HWGR;
                        else if (headersHash.ContainsKey(_WorldID)
                                   && headersHash.ContainsKey(_HWGR_ID)
                                   && headersHash.ContainsKey(_WGR_ID)
                                   && headersHash.ContainsKey(_WGR_Name))
                            result = ImportType.WGR;
                        else if (headersHash.ContainsKey(_VLID) && headersHash.ContainsKey(_FeastDate))
                            result = ImportType.Feast;
                        else throw new UnknownImportFile();
                    }
                    else
                    {
                        throw new UnknownImportFile();
                    }
                    return result;
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
		}
		
		internal ImportBase(string fileName)
		{
			_FileName = fileName;
			_CurrentRow = 0;
		}

		internal ImportBase(string fileName, ICountryService countryService)
			:this(fileName)
		{
			_IContryServise = countryService;
		}
		
		protected string GetLocalized(string key)
		{
			return Baumax.Localization.Localizer.GetLocalized(key);
		}

		private List<Country> getImportedCountryList()
		{
			List<Country> dbCountryList = _IContryServise.FindAll();
			if (dbCountryList != null)
			{
				for (int i = dbCountryList.Count-1; i >= 0; i--)
				{
					if (!dbCountryList[i].Import)
						dbCountryList.RemoveAt(i);
				}
			}
			else
				dbCountryList = new List<Country>();
			return dbCountryList;
		}

		protected Dictionary<string, long> getDBCountryListSysKeyIDKey()
		{
			Dictionary<string, long> dbCountryHash;
			List<Country> dbCountryList = getImportedCountryList();
			dbCountryHash = new Dictionary<string, long>(dbCountryList.Count);
			for (int i = 0; i < dbCountryList.Count; i++)
				dbCountryHash.Add(dbCountryList[i].SystemID1.ToString(), dbCountryList[i].ID);
			return dbCountryHash;
		}

		protected Dictionary<string, Country> getDBCountryListSysKey()
		{
			Dictionary<string, Country> dbCountryHash;
			List<Country> dbCountryList = getImportedCountryList();
			dbCountryHash = new Dictionary<string, Country>(dbCountryList.Count);
			for (int i = 0; i < dbCountryList.Count; i++)
				dbCountryHash.Add(dbCountryList[i].SystemID1.ToString(), dbCountryList[i]);
			return dbCountryHash;
		}

		protected Dictionary<long, Country> getDBCountryListIDKey()
		{
			Dictionary<long, Country> dbCountryHash;
			List<Country> dbCountryList = getImportedCountryList();
			dbCountryHash = new Dictionary<long, Country>(dbCountryList.Count);
			for (int i = 0; i < dbCountryList.Count; i++)
				dbCountryHash.Add(dbCountryList[i].ID, dbCountryList[i]);
			return dbCountryHash;
		}

		internal void Run()
		{
			_CurrentRow = 0;
			_CompleteResult = true;
            try
            {
                message(string.Format(GetLocalized("ImportStarting"), ImportName, DateTime.Now.ToString()));
                message(string.Format(GetLocalized("ImportFileName"), _FileName));
                readCSVFile();
            }
            catch (AnotherImportRunning ex)
            {
                _CompleteResult = false;
                if (string.IsNullOrEmpty(ex.Message))
                    message(string.Format(GetLocalized("bvAlreadyRunning"), ImportName));
                else
                    message(ex.Message);
            }
            catch (Exception ex)
            {
                _CompleteResult = false;
                if (_CurrentRow > 0)
                    message(string.Format(GetLocalized("IncorrectDataInRow"), _CurrentRow));
                message(ex.Message);
            }
			string completeMessage;
			if (_CompleteResult)
				completeMessage = GetLocalized("ImportCompleteSuccessfuly");
			else
				completeMessage = GetLocalized("ImportCompleteError");
			message(string.Format(GetLocalized("At"), completeMessage, DateTime.Now.ToString()));
			allComplete(_CompleteResult);
		}

        protected virtual void readCSVFile()
		{
#if(UseHeaders)
			bool useHeaders = true;
#else
			bool useHeaders = false;
#endif
            Encoding encoding = Encoding.UTF8;
            //Encoding encoding= System.Text.Encoding.GetEncoding("iso-8859-2");
            using (CachedCsvReader csv = new CachedCsvReader(new StreamReader(_FileName, encoding), useHeaders, ';', '"'))
			{
				csv.MissingFieldAction = MissingFieldAction.ReplaceByEmpty;
				csv.ReadToEnd();
				//int fieldCount = csv.FieldCount;
				csv.MoveToStart();
				readCSVFile(csv);
			}
		}

		protected virtual void readCSVFile(CachedCsvReader csv)
		{ 
		
		}

		protected void SaveList<TEntity>(IBaseService<TEntity> servise, List<TEntity> list)
			where TEntity : BaseEntity
		{
			SaveOrUpdateList<TEntity>(servise, list, SaveMode.Save);
		}

		protected void SaveOrUpdateList<TEntity>(IBaseService<TEntity> servise, List<TEntity> list)
			where TEntity : BaseEntity
		{
			SaveOrUpdateList<TEntity>(servise, list, SaveMode.SaveOrUpdate);
		}

		private void SaveOrUpdateList<TEntity>(IBaseService<TEntity> servise, List<TEntity> list, SaveMode saveMode )
			where TEntity: BaseEntity
		{
			message(string.Format(GetLocalized("SavingOfRecords"), list.Count, typeof(TEntity).ToString()));
			if (list.Count > 0)
			{
				int listsCount = list.Count / _RowsToSend;
				int partLastCount = list.Count - listsCount * _RowsToSend;
				if (partLastCount > 0)
					listsCount++;
				Progress progress = new Progress(listsCount);
				progress.OnProgressChanged += OnTaskProgressChanged;

				for (int i = 0; i < listsCount; i++)
				{
					int count = _RowsToSend;
					if (i == (listsCount - 1))
						count = partLastCount;
					List<TEntity> listToSave = list.GetRange(i * _RowsToSend, count);
					if (saveMode == SaveMode.SaveOrUpdate)
						servise.SaveOrUpdateList(listToSave);
					else
						servise.SaveList(listToSave);
					progress.Next(i + 1);
				}
			}
			taskComplete(true);
		}

		#region protected metods
        protected void message(string message)
        {
            this.message(message, true);
        }

		protected void message(string message, bool newLine)
		{
			if (OnMessage != null)
				OnMessage(this, new MessageEventArgs(message,newLine));
		}

		protected void allComplete(bool success)
		{
			if (OnAllComplete != null)
				OnAllComplete(this, new CompleteEventArgs(success));
		}

		protected void allProgressChanged(int currValue, int maxValue)
		{ 
			if (OnAllProgressChanged != null)
				OnAllProgressChanged(this,new ProgressEventArgs(currValue, maxValue));
		}

		protected void taskComplete(bool success)
		{
			if (OnTaskComplete != null)
				OnTaskComplete(this, new CompleteEventArgs(success));
		}

		protected void taskProgressChanged(int currValue, int maxValue)
		{
			if (OnTaskProgressChanged != null)
				OnTaskProgressChanged(this, new ProgressEventArgs(currValue, maxValue));
		}

		protected void csvDataEndRead()
		{
			_CurrentRow = -1;
		}

		protected void csvDataNextRow()
		{
			_CurrentRow++;
		}

		#endregion

		enum SaveMode { SaveOrUpdate, Save }

	}
}
