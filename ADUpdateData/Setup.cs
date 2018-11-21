using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ADUpdate.Properties;

namespace ADUpdateData
{
    /// <summary>
    /// Classe com o formulário de configuração do aplicativo, utilizada 
    /// </summary>
    public partial class Setup : Form
    {
        #region Declarations
        public String ConnectionStringOracle
        {
            get
            {
                return "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + textBoxOraAddress.Text + ")(PORT=" +
                       textBoxOraPort.Text + ")))(CONNECT_DATA=(SERVICE_NAME=" + textBoxOraServiceName.Text + ")));User Id=" + textBoxOraUsername.Text + ";Password=" +
                       textBoxOraPassword.Text + ";Connection Timeout=240;";
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Instancia um formulário de configuração. Carrega toda a configuração do arquivo Setup.ini na pasta do aplicativo.
        /// </summary>
        public Setup()
        {
            InitializeComponent();
            try
            {
                Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch
            {
            }
            FileInfo settings = new FileInfo(Path.Combine(Application.StartupPath, "Setup.ini"));
            if (settings.Exists)
            {
                try
                {
                    XmlDocument xd = new XmlDocument();
                    xd.Load(settings.FullName);
                    
                    foreach (Control c in Controls)
                    {
                        try
                        {
                            if (c.GetType() == new TextBox().GetType())
                            {
                                try
                                {
                                    XmlNodeList xnl = xd.GetElementsByTagName(c.Name);
                                    if (xnl.Count > 0)
                                    {
                                        if (c.Name.ToLower().Contains("password") || ((TextBox)c).PasswordChar != '\0' || ((TextBox)c).UseSystemPasswordChar) // Descriptografa os campos de senha
                                        {
                                            c.Text = Crypto.DecryptStringAES(xnl[0].InnerText, "906");
                                        }
                                        else
                                        {
                                            c.Text = xnl[0].InnerText;
                                        }
                                    }
                                }
                                catch
                                {
                                    c.Text = "";
                                }
                            }
                            else if (c.GetType() == new DataGridView().GetType())
                            {
                                XmlNodeList xnl = xd.GetElementsByTagName(c.Name);
                                if (xnl.Count > 0)
                                {
                                    if (xnl[0].HasChildNodes)
                                    {
                                        foreach (XmlNode xn in xnl[0].ChildNodes)
                                        {
                                            ((DataGridView) c).Rows.Add(xn.InnerText);
                                        }
                                    }
                                }
                            }
                            else if (c.GetType() == new CheckBox().GetType())
                            {
                                XmlNodeList xnl = xd.GetElementsByTagName(c.Name);
                                if (xnl.Count > 0)
                                {
                                    ((CheckBox)c).Checked = Boolean.Parse(xnl[0].InnerText);
                                }
                            }
                            else if (c.GetType() == new DateTimePicker().GetType())
                            {
                                XmlNodeList xnl = xd.GetElementsByTagName(c.Name);
                                if (xnl.Count > 0)
                                {
                                    ((DateTimePicker) c).Value =
                                        DateTime.FromBinary(long.Parse(xnl[0].InnerText));
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// Salva os dados da configuração no arquivo Setup.ini na pasta do aplicativo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            FileInfo settings = new FileInfo(Path.Combine(Application.StartupPath, "Setup.ini"));
            if (settings.Exists)
            {
                try
                {
                    DialogResult dr = MessageBox.Show(Resources.Setup_buttonSave_Click_ReplaceExistingInfoText,
                        Resources.Setup_buttonSave_Click_ReplaceExistingInfoCaption, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation);

                    if (dr == DialogResult.Yes)
                    {
                        settings.Delete();
                    }
                }
                catch
                {
                }
            }
            settings = new FileInfo(Path.Combine(Application.StartupPath, "Setup.ini"));
            if (!settings.Exists)
            {
                XmlWriter xw = XmlWriter.Create(settings.FullName,new XmlWriterSettings{ ConformanceLevel = ConformanceLevel.Auto, NewLineChars = "\r\n", IndentChars = "    ", CloseOutput = true, Encoding = Encoding.UTF8, NewLineOnAttributes = true, NamespaceHandling = NamespaceHandling.OmitDuplicates, Indent = true, CheckCharacters = true, NewLineHandling = NewLineHandling.None, OmitXmlDeclaration = true});
                xw.WriteStartDocument();
                xw.WriteStartElement("Config", "Setup");
                foreach (Control c in Controls)
                {
                    if (c.GetType() == new TextBox().GetType())
                    {
                        try
                        {
                            if (c.Name.ToLower().Contains("password") || ((TextBox)c).PasswordChar != '\0' || ((TextBox)c).UseSystemPasswordChar) // Criptografa os campos de senha
                            {
                                xw.WriteElementString(c.Name, "Setup", Crypto.EncryptStringAES(c.Text, "906"));
                            }
                            else
                            {
                                xw.WriteElementString(c.Name, "Setup", c.Text);
                            }
                        }
                        catch
                        {
                        }
                    }
                    else if (c.GetType() == new DataGridView().GetType())
                    {
                        xw.WriteStartElement(c.Name, "Setup");
                        foreach (DataGridViewRow row in ((DataGridView) c).Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Value != null)
                                    xw.WriteElementString(cell.OwningColumn.Name, "Setup", cell.Value.ToString());
                            }
                        }
                        xw.WriteEndElement();
                    }
                    else if (c.GetType() == new CheckBox().GetType())
                    {
                        xw.WriteElementString(c.Name, "Setup", ((CheckBox) c).Checked.ToString());
                    }
                    else if (c.GetType() == new DateTimePicker().GetType())
                    {
                        xw.WriteElementString(c.Name, "Setup", ((DateTimePicker) c).Value.ToBinary().ToString(CultureInfo.InvariantCulture));
                    }
                }
                xw.WriteEndElement();
                xw.WriteEndDocument();
                xw.Close();
            }
        }

        private void buttonBrowseOracleHome_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            String oldhome = Environment.GetEnvironmentVariable("ORACLE_HOME");
            if (!String.IsNullOrEmpty(textBoxOraHome.Text))
            {
                fbd.SelectedPath = textBoxOraHome.Text;
            }
            else if (!String.IsNullOrEmpty(oldhome))
            {
                fbd.SelectedPath = oldhome;
            }
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBoxOraHome.Text = fbd.SelectedPath;
            }
        }

        private void buttonBrowseLogFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog fbd = new SaveFileDialog();
            fbd.Filter = "*.txt|*.txt";
            fbd.AddExtension = true;
            fbd.DefaultExt = ".txt";
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                textBoxLogFile.Text = fbd.FileName;
            }
        }

        #endregion
    }
}
