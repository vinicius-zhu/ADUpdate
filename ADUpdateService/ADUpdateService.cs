using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ADUpdate;
using ADUpdateData;
using Oracle.DataAccess.Client;

namespace ADUpdateService
{
    /// <summary>
    /// Serviço para atualização do AD.
    /// </summary>
    public partial class ADUpdateService : ServiceBase
    {
        #region Declarations
        /// <summary>
        /// Thread que executa a atualização do AD.
        /// </summary>
        public Thread Runner;
        #endregion

        #region Methods
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        
        public ADUpdateService()
        {
            InitializeComponent();
        }

        /*
        /// <summary>
        /// (Deprecated) Método invocado pelo Thread Runner para atualizar o AD.
        /// </summary>
        /// <param name="o">Identifica se o método é chamado por um serviço ou não.</param>
        public void run_old(object o)
        {
            bool service = (bool)o;
            bool runforever = true;
            while (runforever)
            {
                Int32 sleepinterval;
                List<String> fields = new List<string>();
                Setup setup = new Setup();
                DataGridView dataGridView = new DataGridView();
                dataGridView.Columns.Add("CampoOrigem", "CampoOrigem");
                dataGridView.Columns.Add("CampoDestino", "CampoDestino");
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

                        ADWork adw = new ADWork(setup.dataGridViewLdapStrings, setup.textBoxLdapUsername.Text,
                            setup.textBoxLdapPassword.Text);
                        Dictionary<String, Userdata> usuarios = new Dictionary<string, Userdata>();
                        String keyfield = "USRRED";
                        OracleConnection conn = new OracleConnection(setup.ConnectionStringOracle);
                        conn.Open();
                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * from " + setup.textBoxOraView.Text;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Userdata us = new Userdata(dr, fields);
                                try
                                {
                                    usuarios.Add(us.Attribute[keyfield], us);
                                }
                                catch
                                {
                                }
                            }
                        }

                        dr.Close();
                        conn.Dispose();

                        foreach (KeyValuePair<String, Userdata> user in usuarios)
                        {
                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    if (
                                        user.Value.Attribute.ContainsKey(
                                            row.Cells["CampoOrigem"].Value.ToString().ToUpper()))
                                    {
                                        adw.SetAdInfo(user.Key, row.Cells["CampoDestino"].Value.ToString(),
                                            user.Value.Attribute[row.Cells["CampoOrigem"].Value.ToString().ToUpper()],
                                            setup.textBoxLdapDomain.Text);
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
                if (Int32.TryParse(setup.textBoxUpdateInterval.Text, out sleepinterval))
                {
                    Thread.Sleep(sleepinterval);
                }
                else
                {
                    if (service)
                    {
                        Thread.Sleep(720000);
                    }
                    else
                    {
                        runforever = false;
                    }
                }
            }
        }
        */

        /// <summary>
        /// Método invocado pelo Thread Runner para atualizar o AD.
        /// </summary>
        /// <param name="o">Identifica se o método é chamado por um serviço ou não.</param>
        public void run(object o)
        {
            bool service = (bool) o;
            bool runforever = true;
            //ServiceName = setup.textBoxWinServiceName.Text;
            ((ISupportInitialize)(this.EventLog)).BeginInit();

            if (!EventLog.SourceExists(this.EventLog.Source))
            {
                EventLog.CreateEventSource(this.EventLog.Source, this.EventLog.Log);
            }
            ((ISupportInitialize)(this.EventLog)).EndInit();


            while (runforever)
            {
                try
                {
                    Setup setup = new Setup();
                    if (DateTime.Now.TimeOfDay < setup.dateTimePickerInicioUpdate.Value.TimeOfDay ||
                        DateTime.Now.TimeOfDay > setup.dateTimePickerFimUpdate.Value.TimeOfDay)
                    {
                        DateTime tomorrow = DateTime.Now.AddDays(1);
                        DateTime nextstart = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day,
                            setup.dateTimePickerInicioUpdate.Value.TimeOfDay.Hours,
                            setup.dateTimePickerInicioUpdate.Value.TimeOfDay.Minutes,
                            setup.dateTimePickerInicioUpdate.Value.TimeOfDay.Seconds);

                        Thread.Sleep(nextstart - DateTime.Now);
                    }
                    setup.Dispose();
                    MainForm mainform = new MainForm(false);
                    DateTime start = DateTime.Now;
                    mainform.buttonRunQuery_Click(this, new EventArgs());
                    //mainform.buttonUpdateAD_Click(this, new EventArgs());
                    mainform.adUpdate(service);
                    TimeSpan totaltime = DateTime.Now - start;
                    mainform.Dispose();
                    setup = new Setup();
                    Int32 sleep = Int32.Parse(setup.textBoxUpdateInterval.Text);
                    EventLog.WriteEntry("Atualização AD completa em " + totaltime.TotalMilliseconds + "ms.");
                    setup.Dispose();

                    DateTime temp = DateTime.Now.AddMilliseconds(sleep);
                    if (temp.Day != DateTime.Now.Day)
                    {
                        Int32 sleeptime =
                            (int)
                                ((new DateTime(temp.Year, temp.Month, temp.Day, 0, 0, 0) - DateTime.Now)
                                    .TotalMilliseconds);
                        if (sleep > sleeptime)
                        {
                            Thread.Sleep(sleep);
                        }
                        else
                        {
                            Thread.Sleep(sleeptime);
                        }
                    }
                    else
                    {
                        Thread.Sleep(sleep);
                    }
                }
                catch (Exception e)
                {
                    EventLog.WriteEntry("Erro no processo de atualização: " +  e.Message + "\nExceção: " + e.InnerException + "\nStack Trace: " + e.StackTrace);
                    runforever = false;
                }
            }
        }

        /// <summary>
        /// Evento de início do serviço.
        /// </summary>
        /// <param name="args">Argumentos passados como parâmetro da inicialização do serviço.</param>
        protected override void OnStart(string[] args)
        {
            try
            {
                //Thread.Sleep(20000);
                //Debugger.Break();
                Runner = new Thread(run);
                Runner.Start(true);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Evento de parada do serviço.
        /// </summary>
        protected override void OnStop()
        {
            try
            {
                Runner.Abort();
            }
            catch
            {
            }
            GC.Collect();
        }
        #endregion
    }
}
