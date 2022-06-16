//#define DEBUGGING

using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Baumax.Client.Configurator
{
    public partial class FormMain : Form
    {
        #region Constants

        private const string _configFileName = "Baumax.Client.exe.config";
        private const string _elHostSettings = "hostSettings";
        private const string _elAdd = "add";
        private const string _attrKey = "key";
        private const string _attrValue = "value";
        private const string _keyHostURL = "host.url";
        private const string _keyHostPort = "host.port";

        #endregion

        #region Fields

        private string _targetName = _configFileName;

        private XmlDocument _xmlDoc;
        private XmlNode _xnURLNode;
        private XmlNode _xnPortNode;

        #endregion

        #region Constructors

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(string TargetDir)
        {
            InitializeComponent();

#if DEBUGGING
            if (System.Diagnostics.Debugger.IsAttached)
            {
                System.Diagnostics.Debugger.Break();
            }
            else
            {
                System.Diagnostics.Debugger.Launch();
            }
#endif

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
                    sb.Append(_configFileName);
                    _targetName = sb.ToString();
                }
            }
            Init();
        }

        #endregion

        #region Private Methods

        private void Init()
        {
            if (!System.IO.File.Exists(_targetName))
            {
                throw new Exception(string.Format("File {0} does not exist", _targetName));
            }
            _xmlDoc = new XmlDocument();
            _xmlDoc.Load(_targetName);
            XmlNodeList xNl = _xmlDoc.GetElementsByTagName(_elHostSettings);
            if ((xNl == null) || (xNl.Count < 1))
            {
                // !!! should we create any missing elements ???
                throw new Exception(
                    string.Format("Element '{0}' is not found in configuration file", _elHostSettings));
            }
            _xnURLNode = _xnPortNode = null;
            if (xNl[0].HasChildNodes)
            {
                foreach (XmlNode xn in xNl[0].ChildNodes)
                {
                    if ((xn.NodeType == XmlNodeType.Element) &&
                        (xn.Name == _elAdd) &&
                        (xn.Attributes != null) &&
                        (xn.Attributes[_attrKey] != null))
                    {
                        if ((_xnURLNode == null) &&
                            (string.Compare(xn.Attributes[_attrKey].Value, _keyHostURL, true) == 0))
                        {
                            textBoxURL.Text = xn.Attributes[_attrValue].Value;
                            _xnURLNode = xn;
                        }
                        else
                        {
                            if ((_xnPortNode == null) &&
                                (string.Compare(xn.Attributes[_attrKey].Value, _keyHostPort, true) == 0))
                            {
                                textBoxPort.Text = xn.Attributes[_attrValue].Value;
                                _xnPortNode = xn;
                            }
                        }
                        if ((_xnURLNode != null) && (_xnPortNode != null))
                        {
                            break;
                        }
                    }
                }
            }
            if (_xnURLNode == null)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keyHostURL, _elHostSettings));
            }
            if (_xnPortNode == null)
            {
                throw new Exception(
                    string.Format("'{0}' key is not found in '{1}' section in configuration file",
                                  _keyHostPort, _elHostSettings));
            }
        }

        #endregion

        #region UI Event Handlers

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // url
                _xnURLNode.Attributes[_attrValue].Value = textBoxURL.Text;

                // parse tcp port number
                try
                {
                    Convert.ToUInt16(textBoxPort.Text);
                }
                catch
                {
                    MessageBox.Show("TCP Port number has invalid value. Please correct it.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _xnPortNode.Attributes[_attrValue].Value = textBoxPort.Text;

                // save document
                _xmlDoc.Save(_targetName);

                // close form (and application too)
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}