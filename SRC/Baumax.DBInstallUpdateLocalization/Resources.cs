using System;

namespace Baumax.DBIULocalization
{
	[Serializable]
	public class Resources
	{
		public string CantConnect= "Can't connect to SQL Server";
		public string DBInstallSuccess= "Database installation completed successfully";
		public string DBInstallError = "Database installation completed with errors";
		public string DBInstallStarted= "Database installation started";

		public string DBUpdated = "Database is updated";
		public string DBCantUpdated = "Database can't be updated";
		public string DBCantUpdateToVersion = "Can't update from version {0} to version {1}";
		public string DBUpdateStarted = "Database updating started";
		public string DBExceptionWhenRollback = "An exception was encountered while attempting to roll back the transaction";
		public string DBUpdateSuccess= "Database update completed successfully";
		public string DBUpdateError= "Database update completed with errors";

		public string CreatingType = "Creating type";
		public string CreatingTypes = "Creating types";
		public string CreatingDB = "Creating database";
		public string CreatingTable = "Creating table";
		public string CreatingTables = "Creating tables";
		public string DropingDB= "Droping database";
		public string SetDBVersion= "Set DB version";
		public string CreatingRel= "Creating relationships";
		public string CreatingProcedure = "Creating procedure";
		public string CreatingView = "Creating view";
		public string CreatingFunction = "Creating function";
		public string UpdateDBToVer= "Updating database to version";
		public string DBNameCantBeEmpty = "DB name can't be empty";
		public string Error = "Error";
		public string CreateUserOperation= "Create user operation";
		public string CreateUserRole = "Create user role";
		public string ConnectUrOper = "Connect user role and operations";
		public string CreateUsers = "Create users";
		public string AddDBConsts = "Add db consts";
		public string CreatingIndexes = "Creating indexes";
		public string CreatingIndex = "Creating index";
        public string CreatingTriggers = "Creating triggers";
        public string CreatingTrigger = "Creating trigger";
        public string UIResDataInserting = "UI resources data is been inserting";
        public string UIDefaultBaumaxDataInserting = "Default bauMax data is been inserting";

		//DBInstall UI
		public string FrmMain_Text = "DB install";
		public string FrmMainl_cLanguage = "Language:";
		public string FrmMain_sbInstall = "DB install";
		public string FrmMain_sbSaveLog = "Save log";
		public string FrmMain_allFiles = "All files";
		public string FrmMain_logFiles = "Log files";
		public string FrmMain_installDBErrorMsg = "Install db error. Do you whant save log file ?";
		public string FrmMain_installDBErrorMsgCaption = "Install db error.";
		public string FrmMain_ServerName = "Server name:";
		public string FrmMain_DBName = "DB name:";
		public string FrmMain_UserName = "User name:";
		public string FrmMain_Password = "Password:";
		public string FrmMain_IntegratedSecurity = "Integrated security";

		//DBUpdate UI
		public string DBUpdate = "DB Update";
		public string Versions = "Versions:";
		public string Connect = "Connect";
		public string Disconnect = "Disconnect";
		public string ConnectedToServer= "Connected to server: {0}, db: {1}. DB version: {2}.";
		public string ConnectionError= "Connection error. Check server name, db name, user name, password";
		public string Disconnected= "Disconnected from server";
		public string MustConnect= "You must connect to server before update version";
	}
}
