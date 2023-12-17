using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ADUpdateData;
using Oracle.DataAccess.Client;
namespace ADUpdate
{
    /// <summary>
    /// Classe principal. Oracle 11g Client required
    /// </summary>
    public partial class MainForm : Form
    {
        #region Delegates
        private delegate void DelVoidInt(Int32 value);

        private delegate void DelVoidString(String value);

        private delegate void DelVoidVoid();

        private delegate void DelVoidControlBoolean(Control c, Boolean value);

        private delegate void DelVoidControlString(Control c, String value);
        #endregion

        #region Declarations
        /// <summary>
        /// Lista de campos do De-Para, para popular o AD a partir da tabela do Oracle.
        /// </summary>
        private List<String> m_Fields = new List<string>();
        /// <summary>
        /// Thread de atualização do AD (só é utilizado na atualização manual).
        /// </summary>
        private Thread m_AdUpdateThread;
        /// <summary>
        /// Thread monitor do serviço de atualização do AD.
        /// </summary>
        private Thread m_ServiceMonitorThread;
        #endregion

        #region DelegateFunctions
        /// <summary>
        /// Incrementa a progressbar.
        /// </summary>
        private void ProgressPerformStep()
        {
            try
            {
                if (statusStrip.InvokeRequired)
                {
                    statusStrip.Invoke(new DelVoidVoid(ProgressPerformStep));
                }
                else
                {
                    toolStripProgressBar.PerformStep();
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Reinicia a progressbar.
        /// </summary>
        private void ProgressReset()
        {
            try
            {
                if (statusStrip.InvokeRequired)
                {
                    statusStrip.Invoke(new DelVoidVoid(ProgressReset));
                }
                else
                {
                    toolStripProgressBar.Value = 0;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Altera o valor máximo da progressbar.
        /// </summary>
        /// <param name="value">Novo valor máximo</param>
        private void ProgressSetMax(Int32 value)
        {
            try
            {
                if (statusStrip.InvokeRequired)
                {
                    statusStrip.Invoke(new DelVoidInt(ProgressSetMax), value);
                }
                else
                {
                    toolStripProgressBar.Maximum = value;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Define o status da barra de status.
        /// </summary>
        /// <param name="value">Novo status</param>
        private void StatusSetLabel(String value)
        {
            try
            {
                if (statusStrip.InvokeRequired)
                {
                    statusStrip.Invoke(new DelVoidString(StatusSetLabel), value);
                }
                else
                {
                    toolStripStatusLabel.Text = value;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Define o status do thread monitor do serviço.
        /// </summary>
        /// <param name="value">Novo status</param>
        private void ThreadStatusSetLabel(String value)
        {
            try
            {
                if (statusStrip.InvokeRequired)
                {
                    statusStrip.Invoke(new DelVoidString(ThreadStatusSetLabel), value);
                }
                else
                {
                    toolStripServiceStatusLabel.Text = value;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Habilita ou desabilita um controle.
        /// </summary>
        /// <param name="c">Controle a ser habilitado/desabilitado</param>
        /// <param name="value">Verdadeiro - habilita o controle. Falso - desabilita o controle.</param>
        private void ControlSetEnabled(Control c, Boolean value)
        {
            try
            {
                if (c.InvokeRequired)
                {
                    c.Invoke(new DelVoidControlBoolean(ControlSetEnabled), c, value);
                }
                else
                {
                    c.Enabled = value;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Altera o texto referente a um controle.
        /// </summary>
        /// <param name="c">Controle a ter o texto alterado.</param>
        /// <param name="value">Novo texto do controle.</param>
        private void ControlSetText(Control c, String value)
        {
            try
            {
                if (c.InvokeRequired)
                {
                    c.Invoke(new DelVoidControlString(ControlSetText), c, value);
                }
                else
                {
                    c.Text = value;
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="automatic">Determina execução em batch ou interativa (Verdadeiro = batch).</param>
        public MainForm(Boolean automatic)
        {
            InitializeComponent();
            Visible = false;
            try
            {
                Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch
            {
            }
            LoadADParameters();

            if (automatic)
            {
                buttonRunQuery_Click(this, new EventArgs());
                adUpdate(true);
                Close();
            }
            else
            {
                m_ServiceMonitorThread = new Thread(ServiceMonitor);
                m_ServiceMonitorThread.Start();
                Visible = true;
            }
        }
        /// <summary>
        /// Procedimento que monitora o serviço a partir do thread m_ServiceMonitorThread.
        /// </summary>
        private void ServiceMonitor()
        {
            Setup setup = new Setup();
            while (true)
            {
                ServiceState state = ServiceInstaller.GetServiceStatus(setup.textBoxWinServiceName.Text);
                if (!ServiceInstaller.ServiceIsInstalled(setup.textBoxWinServiceName.Text))
                {
                    state = ServiceState.NotFound;
                }
                Int32 sleep = 0;
                switch (state)
                {
                    case ServiceState.NotFound:
                        ThreadStatusSetLabel("Serviço não instalado.");
                        ControlSetEnabled(buttonInstallService, true);
                        ControlSetEnabled(buttonRemoveService, false);
                        ControlSetEnabled(buttonStartStopService, false);
                        sleep = 100000;
                        break;
                    case ServiceState.Starting:
                        ThreadStatusSetLabel("Serviço em execução.");
                        ControlSetEnabled(buttonInstallService, false);
                        ControlSetEnabled(buttonRemoveService, true);
                        ControlSetEnabled(buttonStartStopService, true);
                        ControlSetText(buttonStartStopService, "Parar Serviço");
                        sleep = 10000;
                        break;
                    case ServiceState.Run:
                        ThreadStatusSetLabel("Iniciando serviço...");
                        ControlSetEnabled(buttonInstallService, false);
                        ControlSetEnabled(buttonRemoveService, false);
                        ControlSetEnabled(buttonStartStopService, false);
                        sleep = 1000;
                        break;
                    case ServiceState.Stop:
                        ThreadStatusSetLabel("Serviço parado.");
                        ControlSetEnabled(buttonInstallService, false);
                        ControlSetEnabled(buttonRemoveService, true);
                        ControlSetEnabled(buttonStartStopService, true);
                        ControlSetText(buttonStartStopService, "Iniciar Serviço");
                        sleep = 10000;
                        break;
                    case ServiceState.Stopping:
                        ThreadStatusSetLabel("Parando serviço...");
                        ControlSetEnabled(buttonInstallService, false);
                        ControlSetEnabled(buttonRemoveService, false);
                        ControlSetEnabled(buttonStartStopService, false);
                        sleep = 1000;
                        break;
                    case ServiceState.Unknown:
                        ThreadStatusSetLabel("Serviço indisponível");
                        ControlSetEnabled(buttonInstallService, true);
                        ControlSetEnabled(buttonRemoveService, false);
                        ControlSetEnabled(buttonStartStopService, false);
                        sleep = 100000;
                        break;
                    default:
                        ThreadStatusSetLabel("");
                        ControlSetEnabled(buttonInstallService, true);
                        ControlSetEnabled(buttonRemoveService, true);
                        ControlSetEnabled(buttonStartStopService, true);
                        ControlSetText(buttonStartStopService, "Iniciar Serviço");
                        sleep = 100000;
                        break;
                }
                try
                {
                    Thread.Sleep(sleep);
                }
                catch
                {
                }
            }
        }

        private void configuracoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new Setup().ShowDialog(this);
            }
            catch
            {
            }
        }

        public void buttonRunQuery_Click(object sender, EventArgs e)
        {
            Setup setup = new Setup();
            String OldOraHome = Environment.GetEnvironmentVariable("ORACLE_HOME");
            if (!String.IsNullOrEmpty(setup.textBoxOraHome.Text))
            {
                Environment.SetEnvironmentVariable("ORACLE_HOME", setup.textBoxOraHome.Text);
            }
            OracleConnection conn = new OracleConnection(setup.ConnectionStringOracle);
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT column_name FROM all_tab_columns WHERE upper(table_name) = upper('" +
                                  setup.textBoxOraView.Text + "') ORDER BY column_name ASC";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                m_Fields.Clear();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        try
                        {
                            m_Fields.Add(dr[0].ToString());
                        }
                        catch
                        {
                        }
                    }
                }
                
                m_Fields.Add("*BRANCO*");
                m_Fields.Sort();
                dr.Close();
                conn.Dispose();
                dataGridView.Rows.Clear();
                DataGridViewComboBoxColumn column = dataGridView.Columns["CampoOrigem"] as DataGridViewComboBoxColumn;
                if (column != null)
                    column.DataSource = m_Fields;

                List<String> properties = new List<String>();
                properties.Clear();
                IPAddress[] ips =
                    Dns.GetHostAddresses(setup.textBoxLdapServer.Text)
                        .Where(w => w.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        .ToArray();
                if (ips.Length > 0)
                {
                    DirectoryContext directoryContext = new DirectoryContext(DirectoryContextType.DirectoryServer,
                        ips[0].ToString() + ":389", setup.textBoxLdapUsername.Text, setup.textBoxLdapPassword.Text);
                    ActiveDirectorySchema adschema = ActiveDirectorySchema.GetSchema(directoryContext);
                    ActiveDirectorySchemaClass adschemaclass = adschema.FindClass("User");

                    // Read the OptionalProperties & MandatoryProperties
                    ReadOnlyActiveDirectorySchemaPropertyCollection propcol = adschemaclass.GetAllProperties();

                    foreach (ActiveDirectorySchemaProperty schemaProperty in propcol)
                        properties.Add(schemaProperty.Name.ToLower());
                }
                DataGridViewComboBoxColumn column2 = dataGridView.Columns["CampoDestino"] as DataGridViewComboBoxColumn;
                if (column2 != null)
                    column2.DataSource = properties;

                try
                {
                    FileInfo file = new FileInfo(Path.Combine(Application.StartupPath, "DePara.xml"));
                    if (file.Exists)
                    {
                        Dictionary<Int32, Dictionary<String, String>> data =
                            new Dictionary<int, Dictionary<string, string>>();
                        XmlReader xr = XmlReader.Create(file.FullName);
                        xr.MoveToContent();
                        while (xr.Read())
                        {
                            Dictionary<String, String> attributes = new Dictionary<string, string>();
                            while (xr.MoveToNextAttribute())
                            {
                                if (xr.Name != "CampoOrigem" && xr.Name != "CampoDestino")
                                    continue;
                                attributes.Add(xr.Name, xr.Value);
                            }
                            if (attributes.Count > 0)
                                data.Add(data.Count, attributes);
                        }
                        xr.Close();
                        foreach (KeyValuePair<Int32, Dictionary<String, String>> kp in data)
                        {
                            dataGridView.Rows.Add(kp.Value["CampoOrigem"], kp.Value["CampoDestino"]);
                        }
                    }
                }
                catch
                {
                }
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show(exc.Message,"Erro ao conectar com o BD",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                catch
                {
                }
            }
            if (!String.IsNullOrEmpty(setup.textBoxOraHome.Text))
            {
                Environment.SetEnvironmentVariable("ORACLE_HOME", OldOraHome);
            }
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            XmlWriter xw = XmlWriter.Create(Path.Combine(Application.StartupPath, "DePara.xml"), new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Auto, NewLineChars = "\r\n", IndentChars = "    ", CloseOutput = true, Encoding = Encoding.UTF8, NewLineOnAttributes = true, NamespaceHandling = NamespaceHandling.OmitDuplicates, Indent = true, CheckCharacters = true, NewLineHandling = NewLineHandling.None, OmitXmlDeclaration = true });
            xw.WriteStartDocument();
            xw.WriteStartElement(dataGridView.Name, "DePara");
            foreach (DataGridViewRow dr in dataGridView.Rows)
            {
                xw.WriteStartElement("Row", "DePara");
                foreach (DataGridViewCell cell in dr.Cells)
                {
                    if (cell.Value != null)
                        xw.WriteAttributeString(cell.OwningColumn.Name, cell.Value.ToString());
                }
                xw.WriteEndElement();
            }
            xw.WriteEndElement();
            xw.WriteEndDocument();
            xw.Close();
        }
        /// <summary>
        /// Carrega os parâmetros do AD do arquivo DePara.xml.
        /// </summary>
        private void LoadADParameters()
        {
            FileInfo file = new FileInfo(Path.Combine(Application.StartupPath, "DePara.xml"));
            if (file.Exists)
            {
                Dictionary<Int32, Dictionary<String, String>> data = new Dictionary<int, Dictionary<string, string>>();
                XmlReader xr = XmlReader.Create(file.FullName);
                xr.MoveToContent();
                while (xr.Read())
                {
                    Dictionary<String, String> attributes = new Dictionary<string, string>();
                    while (xr.MoveToNextAttribute())
                    {
                        if (xr.Name != "CampoOrigem" && xr.Name != "CampoDestino")
                            continue;
                        attributes.Add(xr.Name, xr.Value);
                    }
                    if (attributes.Count > 0)
                        data.Add(data.Count, attributes);
                }
                xr.Close();
            }
        }
        /// <summary>
        /// Atualiza o AD a partir das configurações especificadas. Método também acionado pelo thread m_AdUpdateThread.
        /// </summary>
        /// <param name="service">Determina execução em batch ou interativa (Verdadeiro = batch).</param>
        public void adUpdate(object service)
        {
            Boolean isService = (Boolean)service;
            if (!isService)
            {
                ControlSetEnabled(buttonUpdateAD, false);
                ControlSetEnabled(buttonRunQuery, false);
                ControlSetEnabled(dataGridView, false);
                StatusSetLabel("");
            }

            DateTime start = DateTime.Now;
            if (dataGridView.Rows.Count == 0 || dataGridView.Rows[0].Cells[0].Value == null)
                buttonRunQuery_Click(this, new EventArgs());

            Setup setup = new Setup();
            Boolean log = !String.IsNullOrEmpty(setup.textBoxLogFile.Text);

            StreamWriter swlog = null;
            
            if (log)
            {
                swlog = new StreamWriter(setup.textBoxLogFile.Text,true);
                swlog.WriteLine();
                swlog.WriteLine();
                swlog.WriteLine("*** Log Start: " + start.ToShortDateString() + " " + start.ToShortTimeString() + " ***");
            }
            String keyOrafield = "";
            String keyADfield = "";
            foreach (DataGridViewRow datareader in dataGridView.Rows)
            {
                if (datareader.Cells[0].Value != null)
                {
                    if (datareader.Cells[0].Value.ToString() == setup.textBoxKeyField.Text)
                    {
                        keyOrafield = datareader.Cells[0].Value.ToString();
                        keyADfield = datareader.Cells[1].Value.ToString();
                        break;
                    }
                }
            }

            if (String.IsNullOrEmpty(keyOrafield))
            {
                keyOrafield = setup.textBoxKeyField.Text;
                keyADfield = setup.textBoxKeyFieldAD.Text;
            }

            if (log)
            {
                swlog.WriteLine("keyOrafield: " + keyOrafield);
                swlog.WriteLine("keyADfield: " + keyADfield);
            }

            ADWork adw = new ADWork(setup.dataGridViewLdapStrings, setup.textBoxLdapUsername.Text, setup.textBoxLdapPassword.Text, setup.textBoxKeyFieldAD.Text);
            Dictionary<String, Userdata> usuarios = new Dictionary<string, Userdata>();
            String OldOraHome = Environment.GetEnvironmentVariable("ORACLE_HOME");
            if (!String.IsNullOrEmpty(setup.textBoxOraHome.Text))
            {
                Environment.SetEnvironmentVariable("ORACLE_HOME", setup.textBoxOraHome.Text);
            }

            if (log)
            {
                swlog.WriteLine("OldOraHome: " + OldOraHome);
                swlog.WriteLine("ORACLE_HOME: " + setup.textBoxOraHome.Text);
            }
            try
            {
                OracleConnection conn = new OracleConnection(setup.ConnectionStringOracle);
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * from " + setup.textBoxOraView.Text + " order by " + keyOrafield + " asc";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                usuarios.Clear();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Userdata us = new Userdata(dr, m_Fields,setup.textBoxKeyFieldAD.Text);
                        try
                        {
                            if (!usuarios.ContainsKey(us.Attribute[keyOrafield]) && !String.IsNullOrEmpty(us.Attribute[keyOrafield]))
                            {
                                usuarios.Add(us.Attribute[keyOrafield], us);
                            }
                            else
                            {
                                Int32 countNulls1 = 0;
                                Int32 countNulls2 = 0;
                                foreach (KeyValuePair<String, String> s in usuarios[us.Attribute[keyOrafield]].Attribute)
                                {
                                    if (String.IsNullOrEmpty(s.Value.Trim()))
                                    {
                                        countNulls1++;
                                    }
                                    if (String.IsNullOrEmpty(us.Attribute[s.Key].Trim()))
                                    {
                                        countNulls2++;
                                    }
                                }
                                if (countNulls2 > countNulls1)
                                {
                                    usuarios[us.Attribute[keyOrafield]] = us;
                                }
                                if (log && !String.IsNullOrEmpty(us.Attribute[keyOrafield].Trim()))
                                {
                                    swlog.WriteLine("Tentando adicionar usuário já existente na lista: " + us.Attribute[keyOrafield]);
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }

                dr.Close();
                conn.Dispose();

            }
            catch (Exception e)
            {
                if (log)
                {
                    swlog.WriteLine("Erro ao abrir BD: " + e.Message);
                }
            }

            if (!String.IsNullOrEmpty(setup.textBoxOraHome.Text))
            {
                Environment.SetEnvironmentVariable("ORACLE_HOME", OldOraHome);
            }
            Dictionary<Tuple<String, String>, Tuple<String, String>> m_ChangeLog = new Dictionary<Tuple<string, string>, Tuple<string, string>>();
            Dictionary<String, Boolean> m_EnableLog = new Dictionary<String,Boolean>();

            ProgressSetMax(usuarios.Count * (dataGridView.Rows.Count - 1));
            ProgressReset();

            Regras regras = new Regras();
            regras.RefreshFields(m_Fields);
            foreach (KeyValuePair<String, Userdata> user in usuarios)
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (user.Value.Attribute.ContainsKey(row.Cells["CampoOrigem"].Value.ToString().ToUpper()))
                        {
                            try
                            {
                                String username = user.Key;
                                String field = row.Cells["CampoDestino"].Value.ToString();
                                String value = user.Value.Attribute[row.Cells["CampoOrigem"].Value.ToString().ToUpper()];
                                String domain = setup.textBoxLdapDomain.Text;

                                StatusSetLabel("Atualizando " + username + ", campo " + field + " para " + value);
                                KeyValuePair<Tuple<String, String>, Tuple<String, String>> result;
                                Boolean allowBlankField = row.Cells["CampoOrigem"].Value.ToString() == "*BRANCO*";
                                result =
                                    adw.SetADInfo(user.Key, row.Cells["CampoDestino"].Value.ToString(),
                                        user.Value.Attribute[row.Cells["CampoOrigem"].Value.ToString().ToUpper()],
                                        setup.textBoxLdapDomain.Text, keyADfield, allowBlankField);

                                if (result.Key != null)
                                {
                                    if (!String.IsNullOrEmpty(result.Key.Item1) &&
                                        !String.IsNullOrEmpty(result.Key.Item2))
                                    {
                                        if (result.Value.Item1.Trim() != result.Value.Item2.Trim())
                                        {
                                            m_ChangeLog.Add(result.Key, result.Value);
                                            //Desativa usuário
                                            if (regras.rulesetDisableUser.checkBoxEnable.Checked)
                                            {
                                                Boolean disableUser = regras.rulesetDisableUser.MatchRule(user.Value);
                                                KeyValuePair<String, Boolean> result2 = adw.EnableUser(user.Key,
                                                    row.Cells["CampoDestino"].Value.ToString(), !disableUser,
                                                    setup.textBoxLdapDomain.Text, keyADfield);
                                                if (m_EnableLog.ContainsKey(result2.Key))
                                                {
                                                    m_EnableLog[result2.Key] = result2.Value;
                                                }
                                                else
                                                {
                                                    m_EnableLog.Add(result2.Key, result2.Value);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                if (log)
                                {
                                    swlog.WriteLine("Erro ao alterar usuário: " + e.Message);
                                }
                            }

                            ProgressPerformStep();
                        }
                    }
                }
            }
            if (setup.checkBoxSendMail.Checked && m_ChangeLog.Count > 0)
            {

                List<String> usuariosad = new List<string>(adw.ListADInfo());
                List<String> usuariosdel = new List<string>();
                foreach (KeyValuePair<String,Userdata> us in usuarios)
                {
                    if (us.Value.ContainsKey("USRRED"))
                    {
                        if (!usuariosad.Contains(us.Value["USRRED"]))
                        {
                            usuariosdel.Add(us.Value["USRRED"]);
                        }
                    }
                }
                FileInfo file = new FileInfo(Path.Combine(Path.GetTempPath(), "AlteraAD" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv"));
                FileInfo file2 = new FileInfo(Path.Combine(Path.GetTempPath(), "AtivaAD" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv"));
                
                SmtpClient client = new SmtpClient();
                client.Host = setup.textBoxSMTPServer.Text;
                client.Port = Int32.Parse(setup.textBoxSMTPPort.Text);
                if (setup.checkBoxSMTPAuth.Checked)
                {
                    client.Credentials = new NetworkCredential(setup.textBoxSMTPUser.Text,
                        setup.textBoxSMTPPassword.Text);
                }
                client.EnableSsl = setup.checkBoxSMTPSSL.Checked;
                MailMessage msg = new MailMessage();
                foreach (String to in setup.textBoxDstMailAddresses.Text.Split(','))
                {
                    try
                    {
                        msg.To.Add(new MailAddress(to.Trim()));
                    }
                    catch
                    {
                    }
                }
                try
                {
                    msg.From = new MailAddress(setup.textBoxSrcMailAddress.Text);
                }
                catch
                {
                }
                StreamWriter sw = new StreamWriter(file.FullName, false, Encoding.UTF8);
                sw.WriteLine("Usuario,Campo AD,Valor Original,Valor Novo");
                foreach (KeyValuePair<Tuple<String, String>, Tuple<String, String>> change in m_ChangeLog)
                {
                    sw.WriteLine("\"" + change.Key.Item1 + "\",\"" + change.Key.Item2 + "\",\"" + change.Value.Item1 + "\",\"" + change.Value.Item2 + "\"");
                    msg.Body += "Usuário: " + change.Key.Item1 + ", Campo AD: " + change.Key.Item2 + ", Valor Original: " + (String.IsNullOrEmpty(change.Value.Item1.Trim()) ? "Em Branco" : change.Value.Item1.Trim()) + ", Valor Novo: " + (String.IsNullOrEmpty(change.Value.Item2.Trim()) ? "Em Branco" : change.Value.Item2.Trim()) + ";\r\n";
                }
                sw.Close();
                msg.Body += "\r\n\r\n";
                sw = new StreamWriter(file2.FullName, false, Encoding.UTF8);
                sw.WriteLine("Usuario,Status");
                foreach (KeyValuePair<String, Boolean> change in m_EnableLog)
                {
                    sw.WriteLine("\"" + change.Key + "\",\"" + (change.Value ? "Ativado" : "Desativado") + "\"");
                    msg.Body += "Usuário: " + change.Key + ", Status: " + (change.Value ? "Ativado" : "Desativado") + ";\r\n";
                }
                sw.Close();
                if (usuariosdel.Count > 0)
                {
                    msg.Body += "\r\n\r\n";
                    msg.Body += "Usuarios da view inexistentes no AD:\r\n";
                    foreach (String us in usuariosdel)
                    {
                        if (usuarios[us].ContainsKey("CODSIT") && usuarios[us].Attribute["CODSIT"] != "7")
                        {
                            msg.Body += us + "\r\n";
                        }
                    }
                }
                msg.Subject = "Log Alterações AD - " + DateTime.Now;
                
                try
                {
                    if (m_ChangeLog.Count > 0)
                    {
                        msg.Attachments.Add(new Attachment(file.FullName));
                    }
                    if (m_EnableLog.Count > 0)
                    {
                        msg.Attachments.Add(new Attachment(file2.FullName));
                    }
                    client.Send(msg);
                    file.Delete();
                    file2.Delete();
                }
                catch (Exception e)
                {
                    if (log)
                    {
                        swlog.WriteLine("Erro ao enviar e-mail para " + msg.To + ": " + e.Message);
                    }
                }
            }

            if (!isService)
            {
                String unit = "";
                Double val = 0;
                if ((int)((DateTime.Now - start).TotalDays) > 0)
                {
                    val = (DateTime.Now - start).TotalDays;
                    unit = "dias";
                }
                else if ((int)((DateTime.Now - start).TotalHours) > 0)
                {
                    val = (DateTime.Now - start).TotalHours;
                    unit = "horas";
                }
                else if ((int)((DateTime.Now - start).TotalMinutes) > 0)
                {
                    val = (DateTime.Now - start).TotalMinutes;
                    unit = "minutos";
                }
                else if ((int)((DateTime.Now - start).TotalSeconds) > 0)
                {
                    val = (DateTime.Now - start).TotalSeconds;
                    unit = "segundos";
                }
                else if ((int)((DateTime.Now - start).TotalMilliseconds) > 0)
                {
                    val = (DateTime.Now - start).TotalMilliseconds;
                    unit = "milissegundos";
                }
                try
                {
                    MessageBox.Show(this, "Atualização completa em " + Math.Round(val, 0) + " " + unit + ".", "Atualização completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {

                }
                ControlSetEnabled(buttonUpdateAD, true);
                ControlSetEnabled(buttonRunQuery, true);
                ControlSetEnabled(dataGridView, true);
                ProgressReset();
                StatusSetLabel("");
                if (log)
                {
                    swlog.WriteLine("*** Log End: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " ***");
                    swlog.Close();
                }
            }
        }

        private void buttonUpdateAd_Click(object sender, EventArgs e)
        {
            m_AdUpdateThread = new Thread(adUpdate);
            m_AdUpdateThread.Start(false);
        }
        /// <summary>
        /// Evento de encerramento do programa. Aborta os threads em execução.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                m_AdUpdateThread.Abort();
            }
            catch
            {
            }
            try
            {
                m_ServiceMonitorThread.Abort();
            }
            catch
            {
            }
        }

        private void buttonInstallService_Click(object sender, EventArgs e)
        {
            Setup setup = new Setup();
            try
            {
                ServiceInstaller.Install(setup.textBoxWinServiceName.Text, setup.textBoxWinServiceName.Text,
                    Path.Combine(Application.StartupPath, "ADUpdateService.exe"));
            }
            catch
            {
            }
            m_ServiceMonitorThread.Interrupt();
        }

        private void buttonRemoveService_Click(object sender, EventArgs e)
        {
            Setup setup = new Setup();
            try
            {
                ServiceInstaller.Uninstall(setup.textBoxWinServiceName.Text);
            }
            catch
            {
            }
            m_ServiceMonitorThread.Interrupt();
        }

        private void buttonStartStopService_Click(object sender, EventArgs e)
        {
            Setup setup = new Setup();
            try
            {
                if (ServiceInstaller.GetServiceStatus(setup.textBoxWinServiceName.Text) == ServiceState.Run)
                {
                    ServiceInstaller.StopService(setup.textBoxWinServiceName.Text);
                }
                else if (ServiceInstaller.GetServiceStatus(setup.textBoxWinServiceName.Text) == ServiceState.Stop)
                {
                    ServiceInstaller.StartService(setup.textBoxWinServiceName.Text);
                }
            }
            catch
            {
            }
            m_ServiceMonitorThread.Interrupt();
        }
        #endregion

        private void regrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.Rows.Count <= 1)
                {
                    buttonRunQuery_Click(sender, e);
                }
                //else
                {
                    Regras r = new Regras();
                    r.RefreshFields(m_Fields);
                    r.Show();
                }
            }
            catch
            {
            }
        }
    }
}
