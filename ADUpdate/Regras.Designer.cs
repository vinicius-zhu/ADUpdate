namespace ADUpdate
{
    partial class Regras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Regras));
            this.buttonOk = new System.Windows.Forms.Button();
            this.tabControlRegras = new System.Windows.Forms.TabControl();
            this.tabPageDisableUser = new System.Windows.Forms.TabPage();
            this.rulesetDisableUser = new ADUpdate.Ruleset();
            this.tabControlRegras.SuspendLayout();
            this.tabPageDisableUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.Location = new System.Drawing.Point(12, 305);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // tabControlRegras
            // 
            this.tabControlRegras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlRegras.Controls.Add(this.tabPageDisableUser);
            this.tabControlRegras.Location = new System.Drawing.Point(12, 12);
            this.tabControlRegras.Name = "tabControlRegras";
            this.tabControlRegras.SelectedIndex = 0;
            this.tabControlRegras.Size = new System.Drawing.Size(576, 287);
            this.tabControlRegras.TabIndex = 101;
            // 
            // tabPageDisableUser
            // 
            this.tabPageDisableUser.Controls.Add(this.rulesetDisableUser);
            this.tabPageDisableUser.Location = new System.Drawing.Point(4, 22);
            this.tabPageDisableUser.Name = "tabPageDisableUser";
            this.tabPageDisableUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDisableUser.Size = new System.Drawing.Size(568, 261);
            this.tabPageDisableUser.TabIndex = 0;
            this.tabPageDisableUser.Text = "Desativar Usuário";
            this.tabPageDisableUser.UseVisualStyleBackColor = true;
            // 
            // rulesetDisableUser
            // 
            this.rulesetDisableUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rulesetDisableUser.Fields = ((System.Collections.Generic.List<string>)(resources.GetObject("rulesetDisableUser.Fields")));
            this.rulesetDisableUser.Location = new System.Drawing.Point(3, 3);
            this.rulesetDisableUser.m_FieldsDestino = ((System.Collections.Generic.List<string>)(resources.GetObject("rulesetDisableUser.m_FieldsDestino")));
            this.rulesetDisableUser.m_FieldsOrigem = ((System.Collections.Generic.List<string>)(resources.GetObject("rulesetDisableUser.m_FieldsOrigem")));
            this.rulesetDisableUser.MinimumSize = new System.Drawing.Size(562, 203);
            this.rulesetDisableUser.Name = "rulesetDisableUser";
            this.rulesetDisableUser.Size = new System.Drawing.Size(562, 255);
            this.rulesetDisableUser.TabIndex = 0;
            // 
            // Regras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 340);
            this.Controls.Add(this.tabControlRegras);
            this.Controls.Add(this.buttonOk);
            this.MinimumSize = new System.Drawing.Size(616, 380);
            this.Name = "Regras";
            this.Text = "Regras";
            this.tabControlRegras.ResumeLayout(false);
            this.tabPageDisableUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TabControl tabControlRegras;
        private System.Windows.Forms.TabPage tabPageDisableUser;
        public Ruleset rulesetDisableUser;
    }
}