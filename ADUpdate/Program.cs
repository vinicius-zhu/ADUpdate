using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ADUpdate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Environment.GetCommandLineArgs().Contains("/auto"))
            {
                try
                {
                    Application.Run(new MainForm(true));
                }
                catch
                {
                }
            }
            else
            {
                Application.Run(new MainForm(false));
            }
        }
    }
}
