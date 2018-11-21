using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADUpdate
{
    public partial class Regra : Form
    {
        public Regra()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.StartupPath);
        }

        private void checkBoxEquals_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEquals.Checked)
            {
                checkBoxEquals.Text = @"=";
            }
            else
            {
                checkBoxEquals.Text = @"≠";
            }
        }
    }
}
