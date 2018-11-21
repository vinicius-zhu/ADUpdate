using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ADUpdate.Properties;
using ADUpdateData;

namespace ADUpdate
{
    public partial class Ruleset : UserControl
    {
        public String RulesetName = "";
        public List<String> Fields { get; set; }
        public List<String> m_FieldsOrigem { get; set; }
        public List<String> m_FieldsDestino { get; set; }

        public void LoadData()
        {
            FileInfo settings = new FileInfo(Path.Combine(Application.StartupPath, RulesetName + ".xml"));
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
                            else if (c.GetType() == new ComboBox().GetType())
                            {
                                XmlNodeList xnl = xd.GetElementsByTagName(c.Name);
                                if (xnl.Count > 0)
                                {
                                    if (xnl[0].HasChildNodes)
                                    {
                                        foreach (XmlNode xn in xnl[0].ChildNodes)
                                        {
                                            ((ComboBox)c).Items.Add(xn.InnerText);
                                        }
                                    }
                                }
                            }
                            else if (c.GetType() == new ListBox().GetType())
                            {
                                XmlNodeList xnl = xd.GetElementsByTagName(c.Name);
                                if (xnl.Count > 0)
                                {
                                    if (xnl[0].HasChildNodes)
                                    {
                                        foreach (XmlNode xn in xnl[0].ChildNodes)
                                        {
                                            ((ListBox)c).Items.Add(xn.InnerText);
                                        }
                                    }
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

        public void SaveData()
        {
            FileInfo settings = new FileInfo(Path.Combine(Application.StartupPath, RulesetName + ".xml"));
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
            settings = new FileInfo(Path.Combine(Application.StartupPath, RulesetName + ".xml"));
            if (!settings.Exists)
            {
                XmlWriter xw = XmlWriter.Create(settings.FullName, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Auto, NewLineChars = "\r\n", IndentChars = "    ", CloseOutput = true, Encoding = Encoding.UTF8, NewLineOnAttributes = true, NamespaceHandling = NamespaceHandling.OmitDuplicates, Indent = true, CheckCharacters = true, NewLineHandling = NewLineHandling.None, OmitXmlDeclaration = true });
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
                        foreach (DataGridViewRow row in ((DataGridView)c).Rows)
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
                        xw.WriteElementString(c.Name, "Setup", ((CheckBox)c).Checked.ToString());
                    }
                    else if (c.GetType() == new DateTimePicker().GetType())
                    {
                        xw.WriteElementString(c.Name, "Setup", ((DateTimePicker)c).Value.ToBinary().ToString(CultureInfo.InvariantCulture));
                    }
                    else if (c.GetType() == new ComboBox().GetType())
                    {
                        xw.WriteStartElement(c.Name, "Setup");
                        foreach (String item in ((ComboBox)c).Items)
                        {
                                if (!String.IsNullOrEmpty(item))
                                    xw.WriteElementString("li", "Setup", item);
                            }
                        xw.WriteEndElement();
                    }
                    else if (c.GetType() == new ListBox().GetType())
                    {
                        xw.WriteStartElement(c.Name, "Setup");
                        foreach (String item in ((ListBox)c).Items)
                        {
                            if (!String.IsNullOrEmpty(item))
                                xw.WriteElementString("li", "Setup", item);
                        }
                        xw.WriteEndElement();
                    }
                }
                xw.WriteEndElement();
                xw.WriteEndDocument();
                xw.Close();
            }
        }

        public Ruleset()
        {
            m_FieldsDestino = new List<string>();
            m_FieldsOrigem = new List<string>();
            Fields = new List<string>();
            InitializeComponent();
        }

        public Ruleset(String rulesetName)
        {
            m_FieldsDestino = new List<string>();
            m_FieldsOrigem = new List<string>();
            Fields = new List<string>();
            RulesetName = rulesetName;
            InitializeComponent();

            LoadData();
            Refresh();
        }

        private void checkBoxEquals_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEquals.Checked)
            {
                checkBoxEquals.Text = "=";
            }
            else
            {
                checkBoxEquals.Text = "≠";
            }
        }

        private void checkBoxIsCampo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsCampo.Checked)
            {
                checkBoxIsCampo.Text = "Campo";
                comboBoxCampo.Visible = true;
                textBoxValor.Visible = false;
            }
            else
            {
                checkBoxIsCampo.Text = "Valor";
                comboBoxCampo.Visible = false;
                textBoxValor.Visible = true;
            }
        }

        private void buttonAbreParentese_Click(object sender, EventArgs e)
        {
            listBoxRegras.Items.Add("(");
        }

        private void buttonFechaParentese_Click(object sender, EventArgs e)
        {
            listBoxRegras.Items.Add(")");
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            listBoxRegras.Items.Add("E");
        }

        private void buttonOu_Click(object sender, EventArgs e)
        {
            listBoxRegras.Items.Add("OU");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxCampoOrigem.SelectedIndex != -1) // campo da esquerda não é vazio
            {
                if (checkBoxIsCampo.Checked) // é campo
                {
                    if (comboBoxCampo.SelectedIndex != -1) // campo da direita não é vazio
                    {
                        listBoxRegras.Items.Add(comboBoxCampoOrigem.SelectedItem + (checkBoxEquals.Checked ? " = " : " ≠ ") + comboBoxCampo.SelectedItem);
                    }
                }
                else // é valor
                {
                    if (!String.IsNullOrEmpty(textBoxValor.Text)) // campo da direita não é vazio
                    {
                        listBoxRegras.Items.Add(comboBoxCampoOrigem.SelectedItem + (checkBoxEquals.Checked ? " = " : " ≠ ") + "\"" + textBoxValor.Text.Trim() + "\"");
                    }
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Object o in listBoxRegras.SelectedItems)
                {
                    try
                    {
                        listBoxRegras.Items.Remove(o);
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

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxRegras.SelectedItems.Count > 0)
                {
                    if (listBoxRegras.SelectedIndices.Contains(0))
                    {

                    }
                    else
                    {
                        List<Int32> selectedindexes = new List<int>();
                        foreach (Int32 i in listBoxRegras.SelectedIndices)
                        {
                            var temp = listBoxRegras.Items[i - 1];
                            listBoxRegras.Items[i - 1] = listBoxRegras.Items[i];
                            listBoxRegras.Items[i] = temp;
                            selectedindexes.Add(i - 1);
                        }
                        listBoxRegras.ClearSelected();
                        foreach (Int32 i in selectedindexes)
                        {
                            listBoxRegras.SetSelected(i, true);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxRegras.SelectedItems.Count > 0)
                {
                    if (listBoxRegras.SelectedIndices.Contains(listBoxRegras.Items.Count-1))
                    {

                    }
                    else
                    {
                        List<Int32> selectedindexes = new List<int>();
                        foreach (Int32 i in listBoxRegras.SelectedIndices)
                        {
                            var temp = listBoxRegras.Items[i + 1];
                            listBoxRegras.Items[i + 1] = listBoxRegras.Items[i];
                            listBoxRegras.Items[i] = temp;
                            selectedindexes.Add(i + 1);
                        }
                        listBoxRegras.ClearSelected();
                        foreach (Int32 i in selectedindexes)
                        {
                            listBoxRegras.SetSelected(i, true);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void Refresh()
        {
            try
            {
                comboBoxCampoOrigem.DataSource = null;
                comboBoxCampo.DataSource = null;

                m_FieldsDestino = new List<string>();
                m_FieldsOrigem = new List<string>();

                foreach (String s in Fields)
                {
                    m_FieldsOrigem.Add(s);
                    m_FieldsDestino.Add(s);
                }

                if (m_FieldsOrigem.Contains("*BRANCO*"))
                {
                    m_FieldsOrigem.Remove("*BRANCO*");
                }
                comboBoxCampoOrigem.Items.Clear();
                comboBoxCampo.Items.Clear();

                comboBoxCampoOrigem.DataSource = m_FieldsOrigem;
                comboBoxCampo.DataSource = m_FieldsDestino;

                LoadData();
            }
            catch
            {
            }
        }

        public Boolean MatchRule(Userdata usr)
        {
            String rule = "";
            foreach (Object o in listBoxRegras.Items)
            {
                String s = o.ToString();
                if (s == "E")
                    s = "And";
                if (s == "OU")
                    s = "Or";
                if (s.Contains("="))
                {
                    String left = s.Split('=').First().Trim();
                    String right = s.Split('=').Last().Trim();
                    if (right.Contains("\"")) // valor
                    {
                        right = right.Trim('\"');
                        s = (usr[left] == right).ToString();
                    }
                    else // campo
                    {
                        s = (usr[left] == usr[right]).ToString();
                    }
                }
                //s = s.Replace("=", "Equal");
                if (s.Contains("≠"))
                {
                    String left = s.Split('≠').First().Trim();
                    String right = s.Split('≠').Last().Trim();
                    if (right.Contains("\"")) // valor
                    {
                        right = right.Trim('\"');
                        s = (usr[left] != right).ToString();
                    }
                    else // campo
                    {
                        s = (usr[left] != usr[right]).ToString();
                    }
                }
                //s = s.Replace("≠", "NotEqual");

                rule += " " + s;
            }
            rule = rule.Trim();
            try
            {
                return new Parser(new Tokenizer(rule).Tokenize()).Parse();
            }
            catch
            {
                return false;
            }
        }
    }
}
