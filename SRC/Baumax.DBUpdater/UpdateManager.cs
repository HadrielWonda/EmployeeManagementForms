using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

using Baumax.DBIUCommon;
using Baumax.DBIULocalization;

namespace Baumax.DBUpdater
{

	public class UpdateManager
	{
		#region Events

		public event MessageEventHandler OnMessage;
		public event UpdateCompleteEventHandler OnDbUpdateComplete;
		public event UpdateProgressEventHangler OnProgressUpdateChanged;
		public event UpdateCompleteEventHandler OnBatchComplete;
		public event UpdateProgressEventHangler OnProgressBatchChanged;
		#endregion

		const string scriptsFolder = "Scripts";
		string connectionString;
		List<Version> versionList;
		Version currVersion;
		Version maxVersion;
		Resources res;
		static object syncRoot = new object();
		private string[,] parameters;

		Version[] versions;

		public Version[] Versions
		{
			get { return versions; }
        }

        #region Constructors
        public UpdateManager(string serverName, string dbName)
			: this(serverName, dbName, "", "", true)
		{ }

		public UpdateManager(string serverName, string dbName, string userName, string password)
			: this(serverName,dbName,userName,password,false)
		{ }

		private UpdateManager(string serverName, string dbName, string userName, string password, bool integratedSecurity)
		{
			res = Localization.Instance.Resources;
			if (integratedSecurity)
				connectionString = string.Format("data source={0};initial catalog={1};persist security info=False;Integrated Security=SSPI;", serverName, dbName);
			else
				connectionString = string.Format("data source={0};initial catalog={1};persist security info=False;user id={2};Password={3};", serverName, dbName, userName, password);
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
				parameters = new string[,] { 
    				{"%Creating table%",res.CreatingTable},
				    {"%Creating procedure%",res.CreatingProcedure},
					{"%Updating database to version%",res.UpdateDBToVer}
				};
			}
			versionList = GetVersionList();
			versions = versionList.ToArray();
			currVersion = GetDBVersion();
			versionList.Sort();
			if (versionList.Count > 0)
				maxVersion = versionList[versionList.Count - 1];
			else
				maxVersion = new Version();
        }
        
        #endregion

        private void update(object arg)
		{
			try
			{
				Version toVersion = (Version)arg;
				if (null == toVersion)
					throw new Exception(res.DBUpdated);
				if (toVersion > maxVersion)
					throw new Exception(res.DBCantUpdated);
				if (toVersion < currVersion)
					throw new Exception(string.Format(res.DBCantUpdateToVersion, currVersion, toVersion));
				List<Version> versionsToUpdate = new List<Version>();
				foreach (Version version in versionList)
				{
					if ((version > currVersion) && (version <= toVersion))
						versionsToUpdate.Add(version);
				}
                //if (0 == versionsToUpdate.Count)
                //    throw new Exception(res.DBUpdated);
				update(versionsToUpdate);
			}
			catch (Exception ex)
			{
				sendMessage(ex.Message);
				updateComplete(false);
			}
		}
		
		private void OnSqlServerMessage(object sender, SqlInfoMessageEventArgs e)
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

		private void update(List<Version> _versionList)
		{
			if (null != OnMessage)
				OnMessage(this, new MessageEventArgs(res.DBUpdateStarted));
            if ((null == _versionList))//|| (0 == _versionList.Count)
			{
				updateComplete(true);
				return;
			}
			int versionsCount = _versionList.Count;
			int versionExec = 0;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
                connection.InfoMessage += new SqlInfoMessageEventHandler(OnSqlServerMessage);

				connection.Open();
				SqlTransaction transaction = connection.BeginTransaction();
				try
				{
					foreach (Version version in _versionList)
					{
						versionExec++;
						using (Stream stream = getUpdateScriptStream(version))
						{
							using (StreamReader sr = new StreamReader(stream))
							{
								updateDB(sr, transaction,false);
								if (null != OnProgressUpdateChanged)
									OnProgressUpdateChanged(this, new UpdateProgressEventArgs(versionExec, versionsCount));
							}
						}
					}
                    updateDB(null, transaction, true);
                    transaction.Commit();
					lock (syncRoot)
					{
                        if (_versionList.Count > 0)
                            currVersion = _versionList[_versionList.Count - 1];
					}
				}
				catch (Exception e)
				{
					try
					{
						transaction.Rollback();
					}
					catch
					{
						throw new Exception(res.DBExceptionWhenRollback);
					}
					if (null != OnMessage)
						OnMessage(this, new MessageEventArgs(e.Message));
					updateComplete(false);
					return;
				}
			}
			updateComplete(true);
		}

		private void sendMessage(string message)
		{
			if (null != OnMessage)
				OnMessage(this, new MessageEventArgs(message));
		}
		
		private void updateComplete(bool success)
		{ 
			string message;
			if (success)
				message = res.DBUpdateSuccess;
			else
				message = res.DBUpdateError;
			if (null != OnMessage)
				OnMessage(this, new MessageEventArgs(message));
			if (null != OnDbUpdateComplete)
				OnDbUpdateComplete(this, new UpdateCompleteEventArgs(success));
		}
		
		public void Update(Version newVersion)
		{
			Thread thread = new Thread(new ParameterizedThreadStart(update));
			thread.Start(newVersion);
		}

		public static List<Version> GetVersionList()
		{
			Assembly assembly = typeof(UpdateManager).Assembly;
			string[] resources = assembly.GetManifestResourceNames();
			List<Version> result = new List<Version>();
			if ((null != resources) && (resources.Length > 0))
			{
				string assemlyName = assembly.GetName().Name + string.Format(".{0}.",scriptsFolder);
				foreach (string resName in resources)
				{
					try
					{
						result.Add(new Version(resName.Remove(resName.Length - 4, 4).Replace(assemlyName, string.Empty)));
					}
					catch { }
				}
			}
			return result;
		}
		
		private Stream getUpdateScriptStream(Version version)
		{
			string name = string.Format("{0}.{1}.{2}.sql", Assembly.GetCallingAssembly().GetName().Name,scriptsFolder,version);
			return Assembly.GetCallingAssembly().GetManifestResourceStream(name);
		}

        private string[] getAdditionalScripts()
        {
            string[,] spMsgParams = new string[,] { 
				{"%Creating procedure%",res.CreatingProcedure},
				{"%Creating function%",res.CreatingFunction},
				{"%Creating triggers%",res.CreatingTriggers},
				{"%Creating trigger%",res.CreatingTrigger}
			};
            List<string> result = new List<string>();
            ScriptInfo[] scriptsToRun = Util.GetScriptsToRun(true);
            for (int i = 0; i < scriptsToRun.Length; i++)
            {
                using (StreamReader sr = new StreamReader(Util.GetResourceStream(scriptsToRun[i].Path, scriptsToRun[i].Assembly)))
                {
                    string[] cmdToExec = Util.GetBatchToRun(sr, spMsgParams);
                    result.AddRange(cmdToExec);
                }
            }
            return result.ToArray();
        }

		private void updateDB(StreamReader reader, SqlTransaction transaction, bool updateCommonData)
		{
			if ((null != transaction))
			{
				List<string> cmdToExec = new List<string>();
                if (!updateCommonData)
                {
                    if (null != reader)
                    {
                        string line;
                        string cmdText = "";
                        Regex rx = new Regex(@"^\s*GO+(?:--|\/\*|$|\s| .*)", RegexOptions.IgnoreCase);
                        Match m;
                        while ((line = reader.ReadLine()) != null)
                        {
                            m = rx.Match(line);
                            if (!m.Success)
                            {
                                for (int i = 0; i < parameters.GetLength(0); i++)
                                    line = Regex.Replace(line, parameters[i, 0], parameters[i, 1], RegexOptions.IgnoreCase);
                                cmdText += string.Format("{0}\n", line);
                            }
                            else
                            {
                                cmdToExec.Add(cmdText);
                                cmdText = "";
                            }
                        }
                        if (!string.IsNullOrEmpty(cmdText))
                            cmdToExec.Add(cmdText);
                    }
                }
                else
                {
                    cmdToExec.AddRange(getAdditionalScripts());
                }

                if (cmdToExec.Count == 0) return;
				using (SqlCommand cmd = new SqlCommand())
				{
                    cmd.CommandTimeout = 0;
                    cmd.Transaction = transaction;
					cmd.Connection = transaction.Connection;
						if (null == OnProgressBatchChanged)
							OnProgressBatchChanged(this,new UpdateProgressEventArgs(0,cmdToExec.Count));
					for (int i = 0; i < cmdToExec.Count; i++)
					{
						cmd.CommandText = cmdToExec[i];
						cmd.ExecuteNonQuery();
						if (null != OnProgressBatchChanged)
							OnProgressBatchChanged(this,new UpdateProgressEventArgs(i+1,cmdToExec.Count));
					}
					if (null != OnBatchComplete)
						OnBatchComplete(this, new UpdateCompleteEventArgs(true));
				}
			}
		}

		public Version GetDBVersion()
		{
			string version= "";
			SqlConnection.ClearAllPools();
			using (SqlCommand cmd = new SqlCommand("spDBVersionGet"))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					cmd.Connection = connection;
					connection.Open();
					using(SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.HasRows)
						{
							reader.Read();
							version = reader[0].ToString();
						}
					}
				}
			}
			return new Version(version);
		}

	}
}
