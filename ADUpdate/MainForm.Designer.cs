namespace ADUpdate
{
    partial class MainForm
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
            this.groupBoxQueryFields = new System.Windows.Forms.GroupBox();
            this.panelAssociations = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.CampoOrigem = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CampoDestino = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracoesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRunQuery = new System.Windows.Forms.Button();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.buttonUpdateAD = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripServiceStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonInstallService = new System.Windows.Forms.Button();
            this.buttonRemoveService = new System.Windows.Forms.Button();
            this.buttonStartStopService = new System.Windows.Forms.Button();
            this.regrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxQueryFields.SuspendLayout();
            this.panelAssociations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxQueryFields
            // 
            this.groupBoxQueryFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxQueryFields.Controls.Add(this.panelAssociations);
            this.groupBoxQueryFields.Location = new System.Drawing.Point(12, 53);
            this.groupBoxQueryFields.Name = "groupBoxQueryFields";
            this.groupBoxQueryFields.Size = new System.Drawing.Size(473, 370);
            this.groupBoxQueryFields.TabIndex = 2;
            this.groupBoxQueryFields.TabStop = false;
            this.groupBoxQueryFields.Text = "Associações";
            // 
            // panelAssociations
            // 
            this.panelAssociations.AutoScroll = true;
            this.panelAssociations.Controls.Add(this.dataGridView);
            this.panelAssociations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAssociations.Location = new System.Drawing.Point(3, 16);
            this.panelAssociations.Name = "panelAssociations";
            this.panelAssociations.Size = new System.Drawing.Size(467, 351);
            this.panelAssociations.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CampoOrigem,
            this.CampoDestino});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView.Size = new System.Drawing.Size(467, 351);
            this.dataGridView.TabIndex = 4;
            // 
            // CampoOrigem
            // 
            this.CampoOrigem.HeaderText = "De";
            this.CampoOrigem.Name = "CampoOrigem";
            // 
            // CampoDestino
            // 
            this.CampoDestino.HeaderText = "Para";
            this.CampoDestino.Name = "CampoDestino";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.regrasToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(497, 24);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracoesToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "&Arquivo";
            // 
            // configuracoesToolStripMenuItem
            // 
            this.configuracoesToolStripMenuItem.Name = "configuracoesToolStripMenuItem";
            this.configuracoesToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.configuracoesToolStripMenuItem.Text = "&Configurações";
            this.configuracoesToolStripMenuItem.Click += new System.EventHandler(this.configuracoesToolStripMenuItem_Click);
            // 
            // buttonRunQuery
            // 
            this.buttonRunQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRunQuery.Location = new System.Drawing.Point(15, 27);
            this.buttonRunQuery.Name = "buttonRunQuery";
            this.buttonRunQuery.Size = new System.Drawing.Size(470, 20);
            this.buttonRunQuery.TabIndex = 4;
            this.buttonRunQuery.Text = "Atualizar Listagem";
            this.buttonRunQuery.UseVisualStyleBackColor = true;
            this.buttonRunQuery.Click += new System.EventHandler(this.buttonRunQuery_Click);
            // 
            // buttonGravar
            // 
            this.buttonGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGravar.Location = new System.Drawing.Point(15, 429);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(75, 23);
            this.buttonGravar.TabIndex = 5;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // buttonUpdateAD
            // 
            this.buttonUpdateAD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpdateAD.Location = new System.Drawing.Point(407, 429);
            this.buttonUpdateAD.Name = "buttonUpdateAD";
            this.buttonUpdateAD.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateAD.TabIndex = 6;
            this.buttonUpdateAD.Text = "Atualizar AD";
            this.buttonUpdateAD.UseVisualStyleBackColor = true;
            this.buttonUpdateAD.Click += new System.EventHandler(this.buttonUpdateAd_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel,
            this.toolStripServiceStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 455);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(497, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 7;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Step = 1;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(332, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripServiceStatusLabel
            // 
            this.toolStripServiceStatusLabel.Name = "toolStripServiceStatusLabel";
            this.toolStripServiceStatusLabel.Size = new System.Drawing.Size(48, 17);
            this.toolStripServiceStatusLabel.Text = "Serviço.";
            this.toolStripServiceStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonInstallService
            // 
            this.buttonInstallService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInstallService.Location = new System.Drawing.Point(96, 429);
            this.buttonInstallService.Name = "buttonInstallService";
            this.buttonInstallService.Size = new System.Drawing.Size(100, 23);
            this.buttonInstallService.TabIndex = 8;
            this.buttonInstallService.Text = "Instalar Serviço";
            this.buttonInstallService.UseVisualStyleBackColor = true;
            this.buttonInstallService.Click += new System.EventHandler(this.buttonInstallService_Click);
            // 
            // buttonRemoveService
            // 
            this.buttonRemoveService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveService.Location = new System.Drawing.Point(202, 429);
            this.buttonRemoveService.Name = "buttonRemoveService";
            this.buttonRemoveService.Size = new System.Drawing.Size(100, 23);
            this.buttonRemoveService.TabIndex = 9;
            this.buttonRemoveService.Text = "Remover Serviço";
            this.buttonRemoveService.UseVisualStyleBackColor = true;
            this.buttonRemoveService.Click += new System.EventHandler(this.buttonRemoveService_Click);
            // 
            // buttonStartStopService
            // 
            this.buttonStartStopService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStartStopService.Location = new System.Drawing.Point(308, 429);
            this.buttonStartStopService.Name = "buttonStartStopService";
            this.buttonStartStopService.Size = new System.Drawing.Size(93, 23);
            this.buttonStartStopService.TabIndex = 10;
            this.buttonStartStopService.Text = "Iniciar Serviço";
            this.buttonStartStopService.UseVisualStyleBackColor = true;
            this.buttonStartStopService.Click += new System.EventHandler(this.buttonStartStopService_Click);
            // 
            // regrasToolStripMenuItem
            // 
            this.regrasToolStripMenuItem.Name = "regrasToolStripMenuItem";
            this.regrasToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.regrasToolStripMenuItem.Text = "&Regras";
            this.regrasToolStripMenuItem.Click += new System.EventHandler(this.regrasToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 477);
            this.Controls.Add(this.buttonStartStopService);
            this.Controls.Add(this.buttonInstallService);
            this.Controls.Add(this.buttonRemoveService);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonUpdateAD);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.buttonRunQuery);
            this.Controls.Add(this.groupBoxQueryFields);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "AD Update";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBoxQueryFields.ResumeLayout(false);
            this.panelAssociations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxQueryFields;
        private System.Windows.Forms.Panel panelAssociations;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn CampoOrigem;
        private System.Windows.Forms.DataGridViewComboBoxColumn CampoDestino;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracoesToolStripMenuItem;
        private System.Windows.Forms.Button buttonRunQuery;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Button buttonUpdateAD;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripServiceStatusLabel;
        private System.Windows.Forms.Button buttonInstallService;
        private System.Windows.Forms.Button buttonRemoveService;
        private System.Windows.Forms.Button buttonStartStopService;
        private System.Windows.Forms.ToolStripMenuItem regrasToolStripMenuItem;
    }
}

