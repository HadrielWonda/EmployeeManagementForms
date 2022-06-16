using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Baumax.Setup.UI
{
    public partial class UCConfigSettings : UserControl
    {
        #region Constants

        // TODO: move constants (perhaps and config reader too) to separate class (module?)
        // these consts and read methods are currently in server.configurator and ServerEnvironment
        private const string _elDatabaseSettings = "databaseSettings";
        private const string _elSystemRuntimeRemoting = "system.runtime.remoting";
        private const string _elAdd = "add";
        private const string _elApplication = "application";
        private const string _elChannels = "channels";
        private const string _elChannel = "channel";
        private const string _attrValue = "value";
        private const string _attrKey = "key";
        //private const string _attrRef = "ref";
        private const string _attrRef = "type";
        //private const string _attrPort = "port";
        private const string _attrPort = "Port";
        private const string _keyConnectionString = "db.connection_string";
        //private const string _keyProtocol = "tcp";
        private const string _keyProtocol = "Belikov.GenuineChannels.GenuineTcp.GenuineTcpChannel, GenuineChannels";

        private const string _elImportSettings = "importSettings";
        private const string _keySourceFolder = "sourceFolder";
        private const string _keyImportedFolder = "importedFolder";
        private const string _keyImportErrorsFolder = "importErrorsFolder";
        private const string _keyImportLogsFolder = "importLogsFolder";
        private const string _keyDaysFilesOutOfDate = "daysFilesOutOfDate";

        #endregion

        #region Fields

        private string _targetName;

        private string _unmanagedParams;
        private XmlDocument _xmlDoc;
        private XmlNode _xnConnString;
        private XmlNode _xnChannel;
        private XmlNode _xnImportSourceFolder;
        private XmlNode _xnImportImportedFolder;
        private XmlNode _xnImportErrorsFolder;
        private XmlNode _xnImportLogsFolder;
        private XmlNode _xnDaysFilesOutOfDate;

        #endregion

        #region Constructors

        public UCConfigSettings()
        {
            InitializeComponent();
        }

        #endregion

        #region Public methods

        public void Init(string TargetDir, string ConfigFileName)
        {
            if ((TargetDir != null) && (TargetDir.Length > 0))
            {
                StringBuilder sb = new StringBuilder(TargetDir);
                // remove quote symbols at begin and at end of string
                if ((sb.Length > 0) && (sb[0] == '"'))
                {
                    sb.Remove(1, 1);
                }
                if ((sb.Length > 0) && (sb[sb.Length - 1] == '"'))
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                // add backslash if need to
                if ((sb.Length > 0) && (sb[sb.Length - 1] != '\\'))
                {
                    sb.Append('\\');
                }
                if (sb.Length > 0)
                {
                    sb.Append(ConfigFileName);
                    _targetName = sb.ToString();
                }
            }
            else
            {
                _targetName = ConfigFileName;
            }

            if (!File.Exists(_targetName))
            {
                throw new Exception(string.Format("File {0} does not exist", _targetName));
            }
            _xmlDoc = new XmlDocument();
            _xmlDoc.Load(_targetName);
            XmlNodeList xNl = _xmlDoc.GetElementsByTagName(_elDatabaseSettings);
            if ((xNl == null) || (xNl.Count < 1))
            {
                // !!! should we create any missing elements ???
                throw new Exception(
                    string.Format("Element '{0}' is not found in configuration file", _elDatabaseSettings));
            }
            string connString = null;
            if (xNl[0].HasChildNodes)
            {
                foreach (XmlNode xn in xNl[0].ChildNodes)
                {
                    if ((xn.NodeType == XmlNodeType.Element) &&
                        (xn.Name == _elAdd) &&
                        (xn.Attributes != null) &&
                        (xn.Attributes[_attrKey] != null) &&
                        (string.Compare(xn.Attributes[_attrKey].Value, _keyConnectionString, true) == 0))
                    {
                        connString = xn.Attributes[_attrValue].Value;
                        _xnConnString = xn;
                        break;
                    }
                }
            }
            if (connString == null)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keyConnectionString, _elDatabaseSettings));
            }
            string[] parameters = connString.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder umgParams = new StringBuilder();
            foreach (string param in parameters)
            {
                string[] paramNameValue = param.Split(new char[] {'='}, StringSplitOptions.RemoveEmptyEntries);
                if (paramNameValue.Length != 2)
                {
                    // or we should throw exception?
                    continue;
                }
                switch (paramNameValue[0].Trim().ToLower())
                {
                    case "data source":
                    case "server":
                    case "address":
                    case "addr":
                    case "network address":
                        textBoxDataSource.Text = paramNameValue[1].Trim();
                        break;
                    case "database":
                    case "initial catalog":
                        textBoxDatabase.Text = paramNameValue[1].Trim();
                        break;
                    case "integrated security":
                    case "trusted_connection":
                        switch (paramNameValue[1].Trim().ToLower())
                        {
                            case "true":
                            case "sspi":
                                radioButtonIntegratedSecurity.Checked = true;
                                break;
                            case "false":
                                radioButtonSQLAuthentification.Checked = true;
                                break;
                        }
                        break;
                    case "user id":
                        textBoxUserID.Text = paramNameValue[1].Trim();
                        break;
                    case "password":
                    case "pwd":
                        textBoxPassword.Text = paramNameValue[1].Trim();
                        break;
                    default:
                        umgParams.AppendFormat(";{0}={1}", paramNameValue[0].Trim(), paramNameValue[1].Trim());
                        break;
                }
            }
            _unmanagedParams = umgParams.ToString();

            // listening port number
            xNl = _xmlDoc.GetElementsByTagName(_elSystemRuntimeRemoting);
            if ((xNl == null) || (xNl.Count < 1))
            {
                throw new Exception(
                    string.Format("Element '{0}' is not found in configuration file", _elSystemRuntimeRemoting));
            }
            XmlNode appNode = null;
            if (xNl[0].HasChildNodes)
            {
                foreach (XmlNode xn in xNl[0].ChildNodes)
                {
                    if ((xn.NodeType == XmlNodeType.Element) &&
                        (xn.Name == _elApplication))
                    {
                        appNode = xn;
                        break;
                    }
                }
            }
            if (appNode == null)
            {
                throw new Exception(
                    string.Format("Element '{0}' is not found in '{1}' section of configuration file",
                                  _elApplication, _elSystemRuntimeRemoting));
            }
            XmlNode channelsNode = null;
            if (appNode.HasChildNodes)
            {
                foreach (XmlNode xn in appNode.ChildNodes)
                {
                    if ((xn.NodeType == XmlNodeType.Element) &&
                        (xn.Name == _elChannels))
                    {
                        channelsNode = xn;
                        break;
                    }
                }
            }
            if (channelsNode == null)
            {
                throw new Exception(
                    string.Format("Element '{0}' is not found in '{1}/{2}' section of configuration file",
                                  _elChannels, _elSystemRuntimeRemoting, _elApplication));
            }
            // is it possible that tcp channels be more than one? reading the first one.
            _xnChannel = null;
            if (channelsNode.HasChildNodes)
            {
                foreach (XmlNode xn in channelsNode.ChildNodes)
                {
                    if ((xn.NodeType == XmlNodeType.Element) &&
                        (xn.Name == _elChannel))
                    {
                        _xnChannel = xn;
                        break;
                    }
                }
            }
            if (_xnChannel == null)
            {
                throw new Exception(
                    string.Format("Element '{0}' is not found in '{1}/{2}/{3}' section of configuration file",
                                  _elChannel, _elSystemRuntimeRemoting, _elApplication, _elChannels));
            }
            if ((_xnChannel.Attributes != null) &&
                (_xnChannel.Attributes[_attrRef] != null) &&
                (string.Compare(_xnChannel.Attributes[_attrRef].Value, _keyProtocol, true) == 0) &&
                (_xnChannel.Attributes[_attrPort] != null))
            {
                try
                {
                    Convert.ToUInt16(_xnChannel.Attributes[_attrPort].Value);
                }
                catch (Exception ex)
                {
                    throw new Exception(
                        string.Format("'{0}' attribute has invalid value in '{1}' element", _attrPort, _elChannel),
                        ex);
                }
                textBoxTCPPort.Text = _xnChannel.Attributes[_attrPort].Value;
            }

            // import source/imported folder
            xNl = _xmlDoc.GetElementsByTagName(_elImportSettings);
            if ((xNl == null) || (xNl.Count < 1))
            {
                // !!! should we create any missing elements ???
                throw new Exception(
                    string.Format("Element '{0}' is not found in configuration file", _elImportSettings));
            }
            string sourceFolder = null;
            string importedFolder = null;
            string importErrorsFolder = null;
            string importLogsFolder = null;
            int daysFilesOutOfDate = -1;

            if (xNl[0].HasChildNodes)
            {
                foreach (XmlNode xn in xNl[0].ChildNodes)
                {
                    if ((xn.NodeType == XmlNodeType.Element) &&
                        (xn.Name == _elAdd) &&
                        (xn.Attributes != null) &&
                        (xn.Attributes[_attrKey] != null))
                    {
                        if ((sourceFolder == null) &&
                            (string.Compare(xn.Attributes[_attrKey].Value, _keySourceFolder, true) == 0))
                        {
                            sourceFolder = xn.Attributes[_attrValue].Value;
                            _xnImportSourceFolder = xn;
                        }
                        else
                        {
                            if ((importedFolder == null) &&
                                (string.Compare(xn.Attributes[_attrKey].Value, _keyImportedFolder, true) == 0))
                            {
                                importedFolder = xn.Attributes[_attrValue].Value;
                                _xnImportImportedFolder = xn;
                            }
                            else if ((importLogsFolder == null) &&
                                     (string.Compare(xn.Attributes[_attrKey].Value, _keyImportLogsFolder, true) == 0))
                            {
                                importLogsFolder = xn.Attributes[_attrValue].Value;
                                _xnImportLogsFolder = xn;
                            }
                            else if ((importErrorsFolder == null) &&
                                (string.Compare(xn.Attributes[_attrKey].Value, _keyImportErrorsFolder, true) == 0))
                            {
                                importErrorsFolder = xn.Attributes[_attrValue].Value;
                                _xnImportErrorsFolder = xn;
                            }
                            else if ((daysFilesOutOfDate == -1) &&
                                (string.Compare(xn.Attributes[_attrKey].Value, _keyDaysFilesOutOfDate, true) == 0))
                            {
                                daysFilesOutOfDate = int.Parse(xn.Attributes[_attrValue].Value);
                                _xnDaysFilesOutOfDate = xn;
                            }
                        }

                        if ((sourceFolder != null) && (importedFolder != null) && (importErrorsFolder != null) &&
                            (importLogsFolder != null) && (daysFilesOutOfDate != -1) )
                        {
                            break;
                        }
                    }
                }
            }
            if (sourceFolder == null)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keySourceFolder, _elImportSettings));
            }
            if (importedFolder == null)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keyImportedFolder, _elImportSettings));
            }
            if (importErrorsFolder == null)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keyImportErrorsFolder, _elImportSettings));
            }
            if (importLogsFolder == null)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keyImportLogsFolder, _elImportSettings));
            }
            if (daysFilesOutOfDate == -1)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keyImportLogsFolder, _elImportSettings));
            }

            textBoxImportSourceFolder.Text = sourceFolder;
            textBoxImportImportedFolder.Text = importedFolder;
            textBoxImportErrorsFolder.Text = importErrorsFolder;
            textBoxImportLogsFolder.Text = importLogsFolder;
            numericUpDownDaysFilesOutOfDate.Value = daysFilesOutOfDate;
        }

        #endregion

        #region Private Methods

        private string CombineConnectionString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Data Source={0};", textBoxDataSource.Text);
            sb.AppendFormat("Database={0};", textBoxDatabase.Text);
            if (radioButtonIntegratedSecurity.Checked)
            {
                sb.Append("Trusted_Connection=True");
            }
            else
            {
                sb.AppendFormat("User ID={0};", textBoxUserID.Text);
                sb.AppendFormat("Password={0};", textBoxPassword.Text);
                sb.Append("Trusted_Connection=False");
            }
            sb.Append(_unmanagedParams);
            return sb.ToString();
        }

        #endregion

        #region UI Event Handlers

        private void radioButtonIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIntegratedSecurity.Checked)
            {
                labelUserID.Enabled = labelPassword.Enabled =
                                      textBoxUserID.Enabled = textBoxPassword.Enabled = false;
            }
            else
            {
                labelUserID.Enabled = labelPassword.Enabled =
                                      textBoxUserID.Enabled = textBoxPassword.Enabled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _xnConnString.Attributes[_attrValue].Value = CombineConnectionString();

                // parse tcp port number
                try
                {
                    Convert.ToUInt16(textBoxTCPPort.Text);
                }
                catch
                {
                    MessageBox.Show("TCP Port number has invalid value. Please correct it.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _xnChannel.Attributes[_attrPort].Value = textBoxTCPPort.Text;
                _xnImportSourceFolder.Attributes[_attrValue].Value = textBoxImportSourceFolder.Text;
                _xnImportImportedFolder.Attributes[_attrValue].Value = textBoxImportImportedFolder.Text;
                _xnImportErrorsFolder.Attributes[_attrValue].Value = textBoxImportErrorsFolder.Text;
                _xnImportLogsFolder.Attributes[_attrValue].Value = textBoxImportLogsFolder.Text;
                _xnDaysFilesOutOfDate.Attributes[_attrValue].Value = numericUpDownDaysFilesOutOfDate.Value.ToString ();
                // save document
                _xmlDoc.Save(_targetName);

                // close form (and application too)
                // embarrassing when configuring service
                /*Form parent = Parent as Form;
                if ((parent != null) && (parent.AcceptButton == buttonSave))
                {
                    parent.Close();
                }*/
                MessageBox.Show("Configuration is saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkDBConnectionButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(CombineConnectionString()))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    connection.Open();

                    MessageBox.Show("Connected successfully", "Connection validation", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception /*ex*/)
                {
                    //MessageBox.Show(string.Format("Connection error: {0}\n\nDetails:\n{1}", ex.Message, ex.ToString()),
                    //                "Connection validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(
                        "Cannot connect to specified database.\nPlease check server name, database name, user login and password",
                        "Connection validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;

                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void ellipsisImportSourceFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = textBoxImportSourceFolder.Text;
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                textBoxImportSourceFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ellipsisImportImportedFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = textBoxImportImportedFolder.Text;
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                textBoxImportImportedFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ellipsisImportErrorsFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = textBoxImportErrorsFolder.Text;
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                textBoxImportErrorsFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ellipsisImportLogsFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = textBoxImportLogsFolder.Text;
            if(folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                textBoxImportLogsFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        #endregion
    }
}