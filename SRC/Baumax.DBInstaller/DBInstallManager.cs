using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using Baumax.DBIUCommon;

using Baumax.DBIULocalization;

namespace Baumax.DBInstaller
{
	public class DBInstallManager
	{
		#region Variables

		string connectionString;
		string[,] parameters;

		static object syncRoot = new object();
		Resources res;
		#endregion

		#region Constructors
		public DBInstallManager(string serverName, string dbName)
			: this(serverName, dbName, "", "", true)
		{ }

		public DBInstallManager(string serverName, string dbName, string userName, string password)
			: this(serverName, dbName, userName, password, false)
		{ }

		private DBInstallManager(string serverName, string dbName, string userName, string password, bool integratedSecurity)
		{
			res = Localization.Instance.Resources;
			if (integratedSecurity)
				connectionString = string.Format("data source={0};initial catalog={1};persist security info=False;Integrated Security=SSPI;", serverName, "master");
			else
				connectionString = string.Format("data source={0};initial catalog={1};persist security info=False;user id={2};Password={3};", serverName, "master", userName, password);
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					conn.Open();
				}
				catch
				{
					throw new Exception(res.CantConnect);
				}
			}
			parameters = new string[,] { 
				{"%dbName%", dbName },
				{"%Creating type%",res.CreatingType},
				{"%Creating types%",res.CreatingTypes},
				{"%Creating database%",res.CreatingDB},
				{"%Creating table%",res.CreatingTable},
				{"%Creating tables%",res.CreatingTables},
				{"%Droping database%",res.DropingDB},
				{"%Set DB version%",res.SetDBVersion},
				{"%Creating relationships%",res.CreatingRel},
				{"%Creating procedure%",res.CreatingProcedure},
				{"%Creating view%",res.CreatingView},
				{"%Creating function%",res.CreatingFunction},
				{"%Add db consts%", res.AddDBConsts},
				{"%Create user operation%",res.CreateUserOperation},
				{"%Create user role%",res.CreateUserRole},
				{"%Connect user role and operations%",res.ConnectUrOper},
				{"%Create users%",res.CreateUsers},
				{"%Creating indexes%",res.CreatingIndexes},
				{"%Creating index%",res.CreatingIndex},
				{"%Creating triggers%",res.CreatingTriggers},
				{"%Creating trigger%",res.CreatingTrigger}
			};
		}

		#endregion

		#region Public members
		public event MessageEventHandler OnMessage;
		public event InstallCompleteEventHandler OnDbInstallComplete;
		public event InstallProgressEventHangler OnInstallProgressChanged;
		public event InstallCompleteEventHandler OnInstallBatchComplete;
		public event InstallProgressEventHangler OnInstallBatchProgressChanged;


		public void InstallDB()
		{
			InstallDB(false);
		}

		public void InstallDB(bool sp_udf_Only)
		{
			Thread thread = new Thread(new ParameterizedThreadStart(installDB));
			thread.Start(sp_udf_Only);
		}

		#endregion

		#region Private members
        private Stream getResourceStream(string resourceName, string assemblyName)
        {
            Assembly assembly;
            if (string.IsNullOrEmpty(assemblyName))
                assembly = this.GetType().Assembly;
            else
                assembly = Assembly.Load(assemblyName);
            return Util.GetResourceStream(resourceName, assembly);
        }

        private Stream getResourceStream(string resourceName)
        {
            return Util.GetResourceStream(resourceName, this.GetType().Assembly);
        }

        //private Stream getResourceStream(string resourceName , Assembly assembly)
        //{
        //    resourceName = string.Format("{0}.{1}", assembly.GetName().Name, resourceName.Replace('\\', '.'));
        //    return assembly.GetManifestResourceStream(resourceName);
        //}

		private void onSqlServerMessage(object sender, SqlInfoMessageEventArgs e)
		{
			if (null != OnMessage)
			{
				foreach (SqlError sqle in e.Errors)
				{
					if (!sqle.Message.StartsWith("Changed database context to"))
						OnMessage(this, new MessageEventArgs(sqle.Message));
				}
			}
		}

		private void installComplete(bool success)
		{
			string message;
			if (success)
				message = res.DBInstallSuccess;
			else
				message = res.DBInstallError;
			if (null != OnMessage)
				OnMessage(this, new MessageEventArgs(message));
			if (null != OnDbInstallComplete)
				OnDbInstallComplete(this, new InstallCompleteEventArgs(success));
		}

        //private ScriptInfo[] getScriptsToRun(bool sp_udf_Only)
        //{
        //    string[] sections;
        //    if (sp_udf_Only)
        //        sections = new string[] { "udf", "sp", "sp_rpt" };
        //    else
        //        sections = new string[] { "drop", "db", "udf", "sp", "sp_rpt", "views", "triggers", "data", "run" };

        //    XmlDocument xmlDoc = new XmlDocument();
        //    using (StreamReader sr = new StreamReader(getResourceStream("Scripts.xml")))
        //        xmlDoc.LoadXml(sr.ReadToEnd());
        //    List<ScriptInfo> scripts = new List<ScriptInfo>();
        //    for (int i = 0; i < sections.Length; i++)
        //    {
        //        XmlNode sec = xmlDoc["scripts"][sections[i]];
        //        if (sec == null) 
        //            continue;
        //        string assemblyName= sec.Attributes["assembly"].Value;
        //        IEnumerator ie = sec.GetEnumerator();
        //        XmlNode node;
        //        while (ie.MoveNext())
        //        {
        //            node = (XmlNode)ie.Current;
        //            if (node.Name == "script")
        //                scripts.Add(new ScriptInfo(assemblyName, node.Attributes["path"].Value));
        //        }
        //    }
        //    return scripts.ToArray();
        //}

        //private string[] getBatchToRun(StreamReader sr)
        //{
        //    List<string> batchList = new List<string>();
        //    string line;
        //    string batchText = "";
        //    Regex rx = new Regex(@"^\s*GO+(?:--|\/\*|$|\s| .*)", RegexOptions.IgnoreCase);
        //    Match m;
        //    while ((line = sr.ReadLine()) != null)
        //    {
        //        m = rx.Match(line);
        //        if (!m.Success)
        //        {
        //            for (int i = 0; i < parameters.GetLength(0); i++)
        //                line = Regex.Replace(line, parameters[i, 0], parameters[i, 1], RegexOptions.IgnoreCase);
        //            batchText += string.Format("{0}\n", line);
        //        }
        //        else
        //        {
        //            batchList.Add(batchText);
        //            batchText = "";
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(batchText))
        //        batchList.Add(batchText);
        //    return batchList.ToArray();
        //}

        private void insertUIResources(SqlCommand comm)
        {
            using (StreamReader sr = new StreamReader(getResourceStream("Scripts\\dataImportSp\\UIResources.xml")))
            {
                if (null != OnMessage)
                    OnMessage(this, new MessageEventArgs(res.UIResDataInserting)); 
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "spUIResource_ImportData";
                comm.Parameters.Clear();
                SqlParameter xmlDocument = new SqlParameter("@xmlDocument", SqlDbType.NText);
                xmlDocument.Value = sr.ReadToEnd();
                comm.Parameters.Add(xmlDocument);
                if (null != OnInstallBatchProgressChanged)
                    OnInstallBatchProgressChanged(this, new InstallProgressEventArgs(1, 2));
                comm.ExecuteNonQuery();
                if (null != OnInstallBatchComplete)
                    OnInstallBatchComplete(this, new InstallCompleteEventArgs(true));
            }
        }

        private void insertXmlResources(SqlCommand comm)
        {
            string[] resources = new string[] 
            { 
                "Scripts\\dataImportSp\\Country.xml"
                ,"Scripts\\dataImportSp\\CountryName.xml"
                ,"Scripts\\dataImportSp\\Region.xml"
                ,"Scripts\\dataImportSp\\RegionName.xml"
                ,"Scripts\\dataImportSp\\Store.xml"
                ,"Scripts\\dataImportSp\\StoreName.xml"
                ,"Scripts\\dataImportSp\\Feasts.xml"
                ,"Scripts\\dataImportSp\\YearlyWorkingDays.xml"
                ,"Scripts\\dataImportSp\\Absence.xml"
                ,"Scripts\\dataImportSp\\AbsenceName.xml"
                ,"Scripts\\dataImportSp\\LongTimeAbsence.xml"
                ,"Scripts\\dataImportSp\\WorkingModel.xml"
                ,"Scripts\\dataImportSp\\WorkingModelName.xml"
                ,"Scripts\\dataImportSp\\StoreWorkingTime.xml"
                ,"Scripts\\dataImportSp\\StoreWTWeekday.xml"
                ,"Scripts\\dataImportSp\\CountryPersShowMode.xml"
                ,"Scripts\\dataImportSp\\CountryReportingIdentifier.xml"
            };
            if (null != OnMessage)
                OnMessage(this, new MessageEventArgs(res.UIDefaultBaumaxDataInserting));
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "spXmlResource_ImportData";
            comm.Parameters.Clear();
            SqlParameter resNumber = new SqlParameter("@resNumber", SqlDbType.Int);
            comm.Parameters.Add(resNumber);
            SqlParameter xmlDocument = new SqlParameter("@xmlDocument", SqlDbType.NText);
            comm.Parameters.Add(xmlDocument);
            for (int i = 0; i < resources.Length; i++)
            {
                using (StreamReader sr = new StreamReader(getResourceStream(resources[i])))
                {
                    resNumber.Value = i + 1;
                    xmlDocument.Value = sr.ReadToEnd();
                    comm.ExecuteNonQuery();
                }
                if (null != OnInstallBatchProgressChanged)
                    OnInstallBatchProgressChanged(this, new InstallProgressEventArgs(i + 1, resources.Length));
            }
            if (null != OnInstallBatchComplete)
                OnInstallBatchComplete(this, new InstallCompleteEventArgs(true));

        }

        private void setPKGenValue(SqlCommand comm, long value)
        {
            string query = @"
                update PKGen
                set
	                [Value] = {0}
                where 
	                DomainName = 'Entities'";
            comm.Parameters.Clear();
            comm.CommandType = CommandType.Text;
            comm.CommandText = string.Format(query, value);
            comm.ExecuteNonQuery();
        }

		private void installDB(object args)
		{
			bool sp_udf_Only = (bool)args;
			try
			{
				if (null != OnMessage)
					OnMessage(this, new MessageEventArgs(res.DBInstallStarted));

                ScriptInfo[] scriptsToRun = Util.GetScriptsToRun(sp_udf_Only);

				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.InfoMessage += new SqlInfoMessageEventHandler(onSqlServerMessage);
					SqlCommand comm = new SqlCommand();
					comm.Connection = conn;
					conn.Open();
					for (int i = 0; i < scriptsToRun.Length; i++)
					{
                        using (StreamReader sr = new StreamReader(getResourceStream(scriptsToRun[i].Path, scriptsToRun[i].Assembly)))
						{
							string[] cmdToExec = Util.GetBatchToRun(sr,parameters);
							for (int j = 0; j < cmdToExec.Length; j++)
							{
								comm.CommandText = cmdToExec[j];
								comm.ExecuteNonQuery();
								if (null != OnInstallBatchProgressChanged)
									OnInstallBatchProgressChanged(this, new InstallProgressEventArgs(j + 1, cmdToExec.Length));
							}
							if (null != OnInstallBatchComplete)
								OnInstallBatchComplete(this, new InstallCompleteEventArgs(true));
						}
						if (null != OnInstallProgressChanged)
							OnInstallProgressChanged(this, new InstallProgressEventArgs(i+1, scriptsToRun.Length));
					}
                    insertXmlResources(comm);
                    insertUIResources(comm);
                    setPKGenValue(comm, 3138);
				}

			}
			catch (Exception ex)
			{
				if (null != OnMessage)
					OnMessage(this, new MessageEventArgs(ex.Message));
				installComplete(false);
				return;
			}
			installComplete(true);
		}

        //private class ScriptInfo
        //{
        //    public readonly string Assembly;
        //    public readonly string Path;
        //    public ScriptInfo(string assembly, string path)
        //    {
        //        Assembly = assembly;
        //        Path = path;
        //    }
        //}


		#endregion
	}
}
