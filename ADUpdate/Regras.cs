using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADUpdateData;

namespace ADUpdate
{
    public partial class Regras : Form
    {
        public List<String> Fields { get; set; }
        
        public void RefreshFields(List<String> fields)
        {
            if (fields != null)
            {
                Fields = fields;
                foreach (TabPage t in tabControlRegras.TabPages)
                {
                    foreach (Control c in t.Controls)
                    {
                        if (c.GetType() == new Ruleset().GetType())
                        {
                            ((Ruleset)c).RulesetName = t.Name;
                            ((Ruleset)c).Fields = Fields;
                            ((Ruleset)c).Refresh();
                        }
                    }
                }
                
            }
        }

        public Regras()
        {
            InitializeComponent();
            Fields = new List<string>();

            try
            {
                Icon = Icon.ExtractAssociatedIcon(Application.StartupPath);
            }
            catch
            {
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //rulesetDisableUser.Parse();
            //rulesetDisableUser.MatchRule(new Userdata());
            try
            {
                foreach (TabPage t in tabControlRegras.TabPages)
                {
                    foreach (Control c in t.Controls)
                    {
                        if (c.GetType() == new Ruleset(t.Name).GetType())
                        {
                            ((Ruleset) c).SaveData();
                        }
                    }
                }
                //var test = ce.Eval();
            }
            catch
            {
            }
        }
    }
}
