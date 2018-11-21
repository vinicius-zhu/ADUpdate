﻿namespace ADUpdateData
{
    partial class Setup
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
            this.textBoxOraAddress = new System.Windows.Forms.TextBox();
            this.labelOraAddress = new System.Windows.Forms.Label();
            this.textBoxOraPort = new System.Windows.Forms.TextBox();
            this.labelOraPort = new System.Windows.Forms.Label();
            this.textBoxOraServiceName = new System.Windows.Forms.TextBox();
            this.labelOraServiceName = new System.Windows.Forms.Label();
            this.textBoxOraUsername = new System.Windows.Forms.TextBox();
            this.labelOraUsername = new System.Windows.Forms.Label();
            this.textBoxOraPassword = new System.Windows.Forms.TextBox();
            this.labelOraPassword = new System.Windows.Forms.Label();
            this.labelLdapUsername = new System.Windows.Forms.Label();
            this.textBoxLdapUsername = new System.Windows.Forms.TextBox();
            this.labelLdapPassword = new System.Windows.Forms.Label();
            this.textBoxLdapPassword = new System.Windows.Forms.TextBox();
            this.dataGridViewLdapStrings = new System.Windows.Forms.DataGridView();
            this.LdapString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelLdapStrings = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelLdapServer = new System.Windows.Forms.Label();
            this.textBoxLdapServer = new System.Windows.Forms.TextBox();
            this.textBoxLdapDomain = new System.Windows.Forms.TextBox();
            this.labelLdapDomain = new System.Windows.Forms.Label();
            this.labelOraView = new System.Windows.Forms.Label();
            this.textBoxOraView = new System.Windows.Forms.TextBox();
            this.textBoxUpdateInterval = new System.Windows.Forms.TextBox();
            this.labelUpdateInterval = new System.Windows.Forms.Label();
            this.textBoxSMTPServer = new System.Windows.Forms.TextBox();
            this.labelSMTPServer = new System.Windows.Forms.Label();
            this.labelSMTPPort = new System.Windows.Forms.Label();
            this.labelSMTPUser = new System.Windows.Forms.Label();
            this.labelSMTPPassword = new System.Windows.Forms.Label();
            this.checkBoxSMTPSSL = new System.Windows.Forms.CheckBox();
            this.checkBoxSMTPAuth = new System.Windows.Forms.CheckBox();
            this.textBoxSMTPPort = new System.Windows.Forms.TextBox();
            this.textBoxSMTPUser = new System.Windows.Forms.TextBox();
            this.textBoxSMTPPassword = new System.Windows.Forms.TextBox();
            this.textBoxSrcMailAddress = new System.Windows.Forms.TextBox();
            this.labelSrcMailAddress = new System.Windows.Forms.Label();
            this.textBoxDstMailAddresses = new System.Windows.Forms.TextBox();
            this.labelDstMailAddresses = new System.Windows.Forms.Label();
            this.labelDstMailAddresses1 = new System.Windows.Forms.Label();
            this.labelKeyField = new System.Windows.Forms.Label();
            this.textBoxKeyField = new System.Windows.Forms.TextBox();
            this.labelKeyField1 = new System.Windows.Forms.Label();
            this.checkBoxSendMail = new System.Windows.Forms.CheckBox();
            this.textBoxWinServiceName = new System.Windows.Forms.TextBox();
            this.labelWinServiceName = new System.Windows.Forms.Label();
            this.dateTimePickerInicioUpdate = new System.Windows.Forms.DateTimePicker();
            this.labelInicioUpdates = new System.Windows.Forms.Label();
            this.dateTimePickerFimUpdate = new System.Windows.Forms.DateTimePicker();
            this.labelFimUpdates = new System.Windows.Forms.Label();
            this.labelOracleHome = new System.Windows.Forms.Label();
            this.textBoxOraHome = new System.Windows.Forms.TextBox();
            this.buttonBrowseOracleHome = new System.Windows.Forms.Button();
            this.labelLogFile = new System.Windows.Forms.Label();
            this.textBoxLogFile = new System.Windows.Forms.TextBox();
            this.buttonBrowseLogFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLdapStrings)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxOraAddress
            // 
            this.textBoxOraAddress.Location = new System.Drawing.Point(141, 38);
            this.textBoxOraAddress.Name = "textBoxOraAddress";
            this.textBoxOraAddress.Size = new System.Drawing.Size(365, 20);
            this.textBoxOraAddress.TabIndex = 10;
            // 
            // labelOraAddress
            // 
            this.labelOraAddress.AutoSize = true;
            this.labelOraAddress.Location = new System.Drawing.Point(12, 41);
            this.labelOraAddress.Name = "labelOraAddress";
            this.labelOraAddress.Size = new System.Drawing.Size(80, 13);
            this.labelOraAddress.TabIndex = 1;
            this.labelOraAddress.Text = "Servidor Oracle";
            // 
            // textBoxOraPort
            // 
            this.textBoxOraPort.Location = new System.Drawing.Point(141, 64);
            this.textBoxOraPort.Name = "textBoxOraPort";
            this.textBoxOraPort.Size = new System.Drawing.Size(365, 20);
            this.textBoxOraPort.TabIndex = 20;
            // 
            // labelOraPort
            // 
            this.labelOraPort.AutoSize = true;
            this.labelOraPort.Location = new System.Drawing.Point(12, 67);
            this.labelOraPort.Name = "labelOraPort";
            this.labelOraPort.Size = new System.Drawing.Size(66, 13);
            this.labelOraPort.TabIndex = 3;
            this.labelOraPort.Text = "Porta Oracle";
            // 
            // textBoxOraServiceName
            // 
            this.textBoxOraServiceName.Location = new System.Drawing.Point(141, 90);
            this.textBoxOraServiceName.Name = "textBoxOraServiceName";
            this.textBoxOraServiceName.Size = new System.Drawing.Size(365, 20);
            this.textBoxOraServiceName.TabIndex = 30;
            // 
            // labelOraServiceName
            // 
            this.labelOraServiceName.AutoSize = true;
            this.labelOraServiceName.Location = new System.Drawing.Point(12, 93);
            this.labelOraServiceName.Name = "labelOraServiceName";
            this.labelOraServiceName.Size = new System.Drawing.Size(108, 13);
            this.labelOraServiceName.TabIndex = 5;
            this.labelOraServiceName.Text = "Service Name Oracle";
            // 
            // textBoxOraUsername
            // 
            this.textBoxOraUsername.Location = new System.Drawing.Point(141, 116);
            this.textBoxOraUsername.Name = "textBoxOraUsername";
            this.textBoxOraUsername.Size = new System.Drawing.Size(365, 20);
            this.textBoxOraUsername.TabIndex = 40;
            // 
            // labelOraUsername
            // 
            this.labelOraUsername.AutoSize = true;
            this.labelOraUsername.Location = new System.Drawing.Point(12, 119);
            this.labelOraUsername.Name = "labelOraUsername";
            this.labelOraUsername.Size = new System.Drawing.Size(77, 13);
            this.labelOraUsername.TabIndex = 7;
            this.labelOraUsername.Text = "Usuário Oracle";
            // 
            // textBoxOraPassword
            // 
            this.textBoxOraPassword.Location = new System.Drawing.Point(141, 142);
            this.textBoxOraPassword.Name = "textBoxOraPassword";
            this.textBoxOraPassword.Size = new System.Drawing.Size(365, 20);
            this.textBoxOraPassword.TabIndex = 50;
            this.textBoxOraPassword.UseSystemPasswordChar = true;
            // 
            // labelOraPassword
            // 
            this.labelOraPassword.AutoSize = true;
            this.labelOraPassword.Location = new System.Drawing.Point(12, 145);
            this.labelOraPassword.Name = "labelOraPassword";
            this.labelOraPassword.Size = new System.Drawing.Size(72, 13);
            this.labelOraPassword.TabIndex = 9;
            this.labelOraPassword.Text = "Senha Oracle";
            // 
            // labelLdapUsername
            // 
            this.labelLdapUsername.AutoSize = true;
            this.labelLdapUsername.Location = new System.Drawing.Point(12, 223);
            this.labelLdapUsername.Name = "labelLdapUsername";
            this.labelLdapUsername.Size = new System.Drawing.Size(74, 13);
            this.labelLdapUsername.TabIndex = 11;
            this.labelLdapUsername.Text = "Usuário LDAP";
            // 
            // textBoxLdapUsername
            // 
            this.textBoxLdapUsername.Location = new System.Drawing.Point(141, 220);
            this.textBoxLdapUsername.Name = "textBoxLdapUsername";
            this.textBoxLdapUsername.Size = new System.Drawing.Size(365, 20);
            this.textBoxLdapUsername.TabIndex = 60;
            // 
            // labelLdapPassword
            // 
            this.labelLdapPassword.AutoSize = true;
            this.labelLdapPassword.Location = new System.Drawing.Point(12, 249);
            this.labelLdapPassword.Name = "labelLdapPassword";
            this.labelLdapPassword.Size = new System.Drawing.Size(69, 13);
            this.labelLdapPassword.TabIndex = 13;
            this.labelLdapPassword.Text = "Senha LDAP";
            // 
            // textBoxLdapPassword
            // 
            this.textBoxLdapPassword.Location = new System.Drawing.Point(141, 246);
            this.textBoxLdapPassword.Name = "textBoxLdapPassword";
            this.textBoxLdapPassword.Size = new System.Drawing.Size(365, 20);
            this.textBoxLdapPassword.TabIndex = 70;
            this.textBoxLdapPassword.UseSystemPasswordChar = true;
            // 
            // dataGridViewLdapStrings
            // 
            this.dataGridViewLdapStrings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLdapStrings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLdapStrings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLdapStrings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LdapString});
            this.dataGridViewLdapStrings.Location = new System.Drawing.Point(15, 370);
            this.dataGridViewLdapStrings.Name = "dataGridViewLdapStrings";
            this.dataGridViewLdapStrings.Size = new System.Drawing.Size(973, 173);
            this.dataGridViewLdapStrings.TabIndex = 100;
            // 
            // LdapString
            // 
            this.LdapString.HeaderText = "LDAP String";
            this.LdapString.Name = "LdapString";
            // 
            // labelLdapStrings
            // 
            this.labelLdapStrings.AutoSize = true;
            this.labelLdapStrings.Location = new System.Drawing.Point(12, 352);
            this.labelLdapStrings.Name = "labelLdapStrings";
            this.labelLdapStrings.Size = new System.Drawing.Size(70, 13);
            this.labelLdapStrings.TabIndex = 15;
            this.labelLdapStrings.Text = "Strings LDAP";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(15, 549);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 998;
            this.buttonSave.Text = "Salvar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(913, 549);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 999;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelLdapServer
            // 
            this.labelLdapServer.AutoSize = true;
            this.labelLdapServer.Location = new System.Drawing.Point(12, 275);
            this.labelLdapServer.Name = "labelLdapServer";
            this.labelLdapServer.Size = new System.Drawing.Size(77, 13);
            this.labelLdapServer.TabIndex = 19;
            this.labelLdapServer.Text = "Servidor LDAP";
            // 
            // textBoxLdapServer
            // 
            this.textBoxLdapServer.Location = new System.Drawing.Point(141, 272);
            this.textBoxLdapServer.Name = "textBoxLdapServer";
            this.textBoxLdapServer.Size = new System.Drawing.Size(365, 20);
            this.textBoxLdapServer.TabIndex = 80;
            // 
            // textBoxLdapDomain
            // 
            this.textBoxLdapDomain.Location = new System.Drawing.Point(141, 298);
            this.textBoxLdapDomain.Name = "textBoxLdapDomain";
            this.textBoxLdapDomain.Size = new System.Drawing.Size(365, 20);
            this.textBoxLdapDomain.TabIndex = 90;
            // 
            // labelLdapDomain
            // 
            this.labelLdapDomain.AutoSize = true;
            this.labelLdapDomain.Location = new System.Drawing.Point(12, 301);
            this.labelLdapDomain.Name = "labelLdapDomain";
            this.labelLdapDomain.Size = new System.Drawing.Size(78, 13);
            this.labelLdapDomain.TabIndex = 112;
            this.labelLdapDomain.Text = "Domínio LDAP";
            // 
            // labelOraView
            // 
            this.labelOraView.AutoSize = true;
            this.labelOraView.Location = new System.Drawing.Point(12, 171);
            this.labelOraView.Name = "labelOraView";
            this.labelOraView.Size = new System.Drawing.Size(64, 13);
            this.labelOraView.TabIndex = 121;
            this.labelOraView.Text = "View Oracle";
            // 
            // textBoxOraView
            // 
            this.textBoxOraView.Location = new System.Drawing.Point(141, 168);
            this.textBoxOraView.Name = "textBoxOraView";
            this.textBoxOraView.Size = new System.Drawing.Size(365, 20);
            this.textBoxOraView.TabIndex = 55;
            // 
            // textBoxUpdateInterval
            // 
            this.textBoxUpdateInterval.Location = new System.Drawing.Point(141, 12);
            this.textBoxUpdateInterval.Name = "textBoxUpdateInterval";
            this.textBoxUpdateInterval.Size = new System.Drawing.Size(365, 20);
            this.textBoxUpdateInterval.TabIndex = 5;
            // 
            // labelUpdateInterval
            // 
            this.labelUpdateInterval.AutoSize = true;
            this.labelUpdateInterval.Location = new System.Drawing.Point(12, 15);
            this.labelUpdateInterval.Name = "labelUpdateInterval";
            this.labelUpdateInterval.Size = new System.Drawing.Size(70, 13);
            this.labelUpdateInterval.TabIndex = 1;
            this.labelUpdateInterval.Text = "Intervalo (ms)";
            // 
            // textBoxSMTPServer
            // 
            this.textBoxSMTPServer.Location = new System.Drawing.Point(653, 10);
            this.textBoxSMTPServer.Name = "textBoxSMTPServer";
            this.textBoxSMTPServer.Size = new System.Drawing.Size(335, 20);
            this.textBoxSMTPServer.TabIndex = 110;
            // 
            // labelSMTPServer
            // 
            this.labelSMTPServer.AutoSize = true;
            this.labelSMTPServer.Location = new System.Drawing.Point(549, 13);
            this.labelSMTPServer.Name = "labelSMTPServer";
            this.labelSMTPServer.Size = new System.Drawing.Size(79, 13);
            this.labelSMTPServer.TabIndex = 123;
            this.labelSMTPServer.Text = "Servidor SMTP";
            // 
            // labelSMTPPort
            // 
            this.labelSMTPPort.AutoSize = true;
            this.labelSMTPPort.Location = new System.Drawing.Point(549, 39);
            this.labelSMTPPort.Name = "labelSMTPPort";
            this.labelSMTPPort.Size = new System.Drawing.Size(65, 13);
            this.labelSMTPPort.TabIndex = 124;
            this.labelSMTPPort.Text = "Porta SMTP";
            // 
            // labelSMTPUser
            // 
            this.labelSMTPUser.AutoSize = true;
            this.labelSMTPUser.Location = new System.Drawing.Point(549, 65);
            this.labelSMTPUser.Name = "labelSMTPUser";
            this.labelSMTPUser.Size = new System.Drawing.Size(76, 13);
            this.labelSMTPUser.TabIndex = 125;
            this.labelSMTPUser.Text = "Usuário SMTP";
            // 
            // labelSMTPPassword
            // 
            this.labelSMTPPassword.AutoSize = true;
            this.labelSMTPPassword.Location = new System.Drawing.Point(549, 91);
            this.labelSMTPPassword.Name = "labelSMTPPassword";
            this.labelSMTPPassword.Size = new System.Drawing.Size(71, 13);
            this.labelSMTPPassword.TabIndex = 126;
            this.labelSMTPPassword.Text = "Senha SMTP";
            // 
            // checkBoxSMTPSSL
            // 
            this.checkBoxSMTPSSL.AutoSize = true;
            this.checkBoxSMTPSSL.Location = new System.Drawing.Point(653, 115);
            this.checkBoxSMTPSSL.Name = "checkBoxSMTPSSL";
            this.checkBoxSMTPSSL.Size = new System.Drawing.Size(46, 17);
            this.checkBoxSMTPSSL.TabIndex = 150;
            this.checkBoxSMTPSSL.Text = "SSL";
            this.checkBoxSMTPSSL.UseVisualStyleBackColor = true;
            // 
            // checkBoxSMTPAuth
            // 
            this.checkBoxSMTPAuth.AutoSize = true;
            this.checkBoxSMTPAuth.Location = new System.Drawing.Point(705, 115);
            this.checkBoxSMTPAuth.Name = "checkBoxSMTPAuth";
            this.checkBoxSMTPAuth.Size = new System.Drawing.Size(89, 17);
            this.checkBoxSMTPAuth.TabIndex = 160;
            this.checkBoxSMTPAuth.Text = "Autenticação";
            this.checkBoxSMTPAuth.UseVisualStyleBackColor = true;
            // 
            // textBoxSMTPPort
            // 
            this.textBoxSMTPPort.Location = new System.Drawing.Point(653, 36);
            this.textBoxSMTPPort.Name = "textBoxSMTPPort";
            this.textBoxSMTPPort.Size = new System.Drawing.Size(335, 20);
            this.textBoxSMTPPort.TabIndex = 120;
            // 
            // textBoxSMTPUser
            // 
            this.textBoxSMTPUser.Location = new System.Drawing.Point(653, 62);
            this.textBoxSMTPUser.Name = "textBoxSMTPUser";
            this.textBoxSMTPUser.Size = new System.Drawing.Size(335, 20);
            this.textBoxSMTPUser.TabIndex = 130;
            // 
            // textBoxSMTPPassword
            // 
            this.textBoxSMTPPassword.Location = new System.Drawing.Point(653, 88);
            this.textBoxSMTPPassword.Name = "textBoxSMTPPassword";
            this.textBoxSMTPPassword.Size = new System.Drawing.Size(335, 20);
            this.textBoxSMTPPassword.TabIndex = 140;
            this.textBoxSMTPPassword.UseSystemPasswordChar = true;
            // 
            // textBoxSrcMailAddress
            // 
            this.textBoxSrcMailAddress.Location = new System.Drawing.Point(653, 140);
            this.textBoxSrcMailAddress.Name = "textBoxSrcMailAddress";
            this.textBoxSrcMailAddress.Size = new System.Drawing.Size(335, 20);
            this.textBoxSrcMailAddress.TabIndex = 170;
            // 
            // labelSrcMailAddress
            // 
            this.labelSrcMailAddress.AutoSize = true;
            this.labelSrcMailAddress.Location = new System.Drawing.Point(549, 143);
            this.labelSrcMailAddress.Name = "labelSrcMailAddress";
            this.labelSrcMailAddress.Size = new System.Drawing.Size(71, 13);
            this.labelSrcMailAddress.TabIndex = 133;
            this.labelSrcMailAddress.Text = "E-mail Origem";
            // 
            // textBoxDstMailAddresses
            // 
            this.textBoxDstMailAddresses.Location = new System.Drawing.Point(653, 166);
            this.textBoxDstMailAddresses.Name = "textBoxDstMailAddresses";
            this.textBoxDstMailAddresses.Size = new System.Drawing.Size(335, 20);
            this.textBoxDstMailAddresses.TabIndex = 180;
            // 
            // labelDstMailAddresses
            // 
            this.labelDstMailAddresses.AutoSize = true;
            this.labelDstMailAddresses.Location = new System.Drawing.Point(549, 169);
            this.labelDstMailAddresses.Name = "labelDstMailAddresses";
            this.labelDstMailAddresses.Size = new System.Drawing.Size(83, 13);
            this.labelDstMailAddresses.TabIndex = 192;
            this.labelDstMailAddresses.Text = "E-mails Destino*";
            // 
            // labelDstMailAddresses1
            // 
            this.labelDstMailAddresses1.AutoSize = true;
            this.labelDstMailAddresses1.Location = new System.Drawing.Point(883, 189);
            this.labelDstMailAddresses1.Name = "labelDstMailAddresses1";
            this.labelDstMailAddresses1.Size = new System.Drawing.Size(105, 13);
            this.labelDstMailAddresses1.TabIndex = 193;
            this.labelDstMailAddresses1.Text = "*separar por vírgulas";
            // 
            // labelKeyField
            // 
            this.labelKeyField.AutoSize = true;
            this.labelKeyField.Location = new System.Drawing.Point(549, 221);
            this.labelKeyField.Name = "labelKeyField";
            this.labelKeyField.Size = new System.Drawing.Size(58, 13);
            this.labelKeyField.TabIndex = 195;
            this.labelKeyField.Text = "Key Field †";
            // 
            // textBoxKeyField
            // 
            this.textBoxKeyField.Location = new System.Drawing.Point(653, 218);
            this.textBoxKeyField.Name = "textBoxKeyField";
            this.textBoxKeyField.Size = new System.Drawing.Size(335, 20);
            this.textBoxKeyField.TabIndex = 200;
            // 
            // labelKeyField1
            // 
            this.labelKeyField1.AutoSize = true;
            this.labelKeyField1.Location = new System.Drawing.Point(784, 241);
            this.labelKeyField1.Name = "labelKeyField1";
            this.labelKeyField1.Size = new System.Drawing.Size(204, 13);
            this.labelKeyField1.TabIndex = 1000;
            this.labelKeyField1.Text = "† Campo da visão do BD que será chave.";
            // 
            // checkBoxSendMail
            // 
            this.checkBoxSendMail.AutoSize = true;
            this.checkBoxSendMail.Location = new System.Drawing.Point(653, 193);
            this.checkBoxSendMail.Name = "checkBoxSendMail";
            this.checkBoxSendMail.Size = new System.Drawing.Size(144, 17);
            this.checkBoxSendMail.TabIndex = 190;
            this.checkBoxSendMail.Text = "Enviar relatório por e-mail";
            this.checkBoxSendMail.UseVisualStyleBackColor = true;
            // 
            // textBoxWinServiceName
            // 
            this.textBoxWinServiceName.Location = new System.Drawing.Point(653, 270);
            this.textBoxWinServiceName.Name = "textBoxWinServiceName";
            this.textBoxWinServiceName.Size = new System.Drawing.Size(335, 20);
            this.textBoxWinServiceName.TabIndex = 210;
            // 
            // labelWinServiceName
            // 
            this.labelWinServiceName.AutoSize = true;
            this.labelWinServiceName.Location = new System.Drawing.Point(549, 273);
            this.labelWinServiceName.Name = "labelWinServiceName";
            this.labelWinServiceName.Size = new System.Drawing.Size(74, 13);
            this.labelWinServiceName.TabIndex = 1002;
            this.labelWinServiceName.Text = "Nome Serviço";
            // 
            // dateTimePickerInicioUpdate
            // 
            this.dateTimePickerInicioUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerInicioUpdate.Location = new System.Drawing.Point(653, 298);
            this.dateTimePickerInicioUpdate.Name = "dateTimePickerInicioUpdate";
            this.dateTimePickerInicioUpdate.ShowUpDown = true;
            this.dateTimePickerInicioUpdate.Size = new System.Drawing.Size(88, 20);
            this.dateTimePickerInicioUpdate.TabIndex = 94;
            this.dateTimePickerInicioUpdate.Value = new System.DateTime(1753, 1, 1, 7, 0, 0, 0);
            // 
            // labelInicioUpdates
            // 
            this.labelInicioUpdates.AutoSize = true;
            this.labelInicioUpdates.Location = new System.Drawing.Point(549, 301);
            this.labelInicioUpdates.Name = "labelInicioUpdates";
            this.labelInicioUpdates.Size = new System.Drawing.Size(77, 13);
            this.labelInicioUpdates.TabIndex = 1004;
            this.labelInicioUpdates.Text = "Início Updates";
            // 
            // dateTimePickerFimUpdate
            // 
            this.dateTimePickerFimUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerFimUpdate.Location = new System.Drawing.Point(900, 298);
            this.dateTimePickerFimUpdate.Name = "dateTimePickerFimUpdate";
            this.dateTimePickerFimUpdate.ShowUpDown = true;
            this.dateTimePickerFimUpdate.Size = new System.Drawing.Size(88, 20);
            this.dateTimePickerFimUpdate.TabIndex = 98;
            this.dateTimePickerFimUpdate.Value = new System.DateTime(9998, 12, 30, 19, 0, 0, 0);
            // 
            // labelFimUpdates
            // 
            this.labelFimUpdates.AutoSize = true;
            this.labelFimUpdates.Location = new System.Drawing.Point(817, 301);
            this.labelFimUpdates.Name = "labelFimUpdates";
            this.labelFimUpdates.Size = new System.Drawing.Size(66, 13);
            this.labelFimUpdates.TabIndex = 1005;
            this.labelFimUpdates.Text = "Fim Updates";
            // 
            // labelOracleHome
            // 
            this.labelOracleHome.AutoSize = true;
            this.labelOracleHome.Location = new System.Drawing.Point(12, 197);
            this.labelOracleHome.Name = "labelOracleHome";
            this.labelOracleHome.Size = new System.Drawing.Size(69, 13);
            this.labelOracleHome.TabIndex = 1007;
            this.labelOracleHome.Text = "Oracle Home";
            // 
            // textBoxOraHome
            // 
            this.textBoxOraHome.Location = new System.Drawing.Point(141, 194);
            this.textBoxOraHome.Name = "textBoxOraHome";
            this.textBoxOraHome.Size = new System.Drawing.Size(337, 20);
            this.textBoxOraHome.TabIndex = 57;
            // 
            // buttonBrowseOracleHome
            // 
            this.buttonBrowseOracleHome.Location = new System.Drawing.Point(484, 194);
            this.buttonBrowseOracleHome.Name = "buttonBrowseOracleHome";
            this.buttonBrowseOracleHome.Size = new System.Drawing.Size(22, 20);
            this.buttonBrowseOracleHome.TabIndex = 58;
            this.buttonBrowseOracleHome.UseVisualStyleBackColor = true;
            this.buttonBrowseOracleHome.Click += new System.EventHandler(this.buttonBrowseOracleHome_Click);
            // 
            // labelLogFile
            // 
            this.labelLogFile.AutoSize = true;
            this.labelLogFile.Location = new System.Drawing.Point(549, 327);
            this.labelLogFile.Name = "labelLogFile";
            this.labelLogFile.Size = new System.Drawing.Size(79, 13);
            this.labelLogFile.TabIndex = 1009;
            this.labelLogFile.Text = "Arquivo de Log";
            // 
            // textBoxLogFile
            // 
            this.textBoxLogFile.Location = new System.Drawing.Point(653, 324);
            this.textBoxLogFile.Name = "textBoxLogFile";
            this.textBoxLogFile.Size = new System.Drawing.Size(307, 20);
            this.textBoxLogFile.TabIndex = 1008;
            // 
            // buttonBrowseLogFile
            // 
            this.buttonBrowseLogFile.Location = new System.Drawing.Point(966, 324);
            this.buttonBrowseLogFile.Name = "buttonBrowseLogFile";
            this.buttonBrowseLogFile.Size = new System.Drawing.Size(22, 20);
            this.buttonBrowseLogFile.TabIndex = 1010;
            this.buttonBrowseLogFile.UseVisualStyleBackColor = true;
            this.buttonBrowseLogFile.Click += new System.EventHandler(this.buttonBrowseLogFile_Click);
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 584);
            this.Controls.Add(this.buttonBrowseLogFile);
            this.Controls.Add(this.labelLogFile);
            this.Controls.Add(this.textBoxLogFile);
            this.Controls.Add(this.buttonBrowseOracleHome);
            this.Controls.Add(this.labelOracleHome);
            this.Controls.Add(this.textBoxOraHome);
            this.Controls.Add(this.labelFimUpdates);
            this.Controls.Add(this.dateTimePickerFimUpdate);
            this.Controls.Add(this.labelInicioUpdates);
            this.Controls.Add(this.dateTimePickerInicioUpdate);
            this.Controls.Add(this.labelWinServiceName);
            this.Controls.Add(this.textBoxWinServiceName);
            this.Controls.Add(this.checkBoxSendMail);
            this.Controls.Add(this.labelKeyField1);
            this.Controls.Add(this.textBoxKeyField);
            this.Controls.Add(this.labelKeyField);
            this.Controls.Add(this.labelDstMailAddresses1);
            this.Controls.Add(this.labelDstMailAddresses);
            this.Controls.Add(this.textBoxDstMailAddresses);
            this.Controls.Add(this.labelSrcMailAddress);
            this.Controls.Add(this.textBoxSrcMailAddress);
            this.Controls.Add(this.textBoxSMTPPassword);
            this.Controls.Add(this.textBoxSMTPUser);
            this.Controls.Add(this.textBoxSMTPPort);
            this.Controls.Add(this.checkBoxSMTPAuth);
            this.Controls.Add(this.checkBoxSMTPSSL);
            this.Controls.Add(this.labelSMTPPassword);
            this.Controls.Add(this.labelSMTPUser);
            this.Controls.Add(this.labelSMTPPort);
            this.Controls.Add(this.labelSMTPServer);
            this.Controls.Add(this.textBoxSMTPServer);
            this.Controls.Add(this.textBoxUpdateInterval);
            this.Controls.Add(this.labelOraView);
            this.Controls.Add(this.textBoxOraView);
            this.Controls.Add(this.labelLdapDomain);
            this.Controls.Add(this.textBoxLdapDomain);
            this.Controls.Add(this.labelLdapServer);
            this.Controls.Add(this.textBoxLdapServer);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelLdapStrings);
            this.Controls.Add(this.dataGridViewLdapStrings);
            this.Controls.Add(this.labelLdapPassword);
            this.Controls.Add(this.textBoxLdapPassword);
            this.Controls.Add(this.labelLdapUsername);
            this.Controls.Add(this.textBoxLdapUsername);
            this.Controls.Add(this.labelOraPassword);
            this.Controls.Add(this.textBoxOraPassword);
            this.Controls.Add(this.labelOraUsername);
            this.Controls.Add(this.textBoxOraUsername);
            this.Controls.Add(this.labelOraServiceName);
            this.Controls.Add(this.textBoxOraServiceName);
            this.Controls.Add(this.labelOraPort);
            this.Controls.Add(this.textBoxOraPort);
            this.Controls.Add(this.labelUpdateInterval);
            this.Controls.Add(this.labelOraAddress);
            this.Controls.Add(this.textBoxOraAddress);
            this.MinimumSize = new System.Drawing.Size(870, 550);
            this.Name = "Setup";
            this.Text = "Setup";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLdapStrings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelOraAddress;
        private System.Windows.Forms.Label labelOraPort;
        private System.Windows.Forms.Label labelOraServiceName;
        private System.Windows.Forms.Label labelOraUsername;
        private System.Windows.Forms.Label labelOraPassword;
        private System.Windows.Forms.Label labelLdapUsername;
        private System.Windows.Forms.Label labelLdapPassword;
        private System.Windows.Forms.Label labelLdapStrings;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn LdapString;
        public System.Windows.Forms.TextBox textBoxOraAddress;
        public System.Windows.Forms.TextBox textBoxOraPort;
        public System.Windows.Forms.TextBox textBoxOraServiceName;
        public System.Windows.Forms.TextBox textBoxOraUsername;
        public System.Windows.Forms.TextBox textBoxOraPassword;
        public System.Windows.Forms.TextBox textBoxLdapUsername;
        public System.Windows.Forms.TextBox textBoxLdapPassword;
        public System.Windows.Forms.DataGridView dataGridViewLdapStrings;
        private System.Windows.Forms.Label labelLdapServer;
        public System.Windows.Forms.TextBox textBoxLdapServer;
        public System.Windows.Forms.TextBox textBoxLdapDomain;
        private System.Windows.Forms.Label labelLdapDomain;
        private System.Windows.Forms.Label labelOraView;
        public System.Windows.Forms.TextBox textBoxOraView;
        public System.Windows.Forms.TextBox textBoxUpdateInterval;
        private System.Windows.Forms.Label labelUpdateInterval;
        public System.Windows.Forms.TextBox textBoxSMTPServer;
        private System.Windows.Forms.Label labelSMTPServer;
        private System.Windows.Forms.Label labelSMTPPort;
        private System.Windows.Forms.Label labelSMTPUser;
        private System.Windows.Forms.Label labelSMTPPassword;
        public System.Windows.Forms.TextBox textBoxSMTPPort;
        public System.Windows.Forms.TextBox textBoxSMTPUser;
        public System.Windows.Forms.TextBox textBoxSMTPPassword;
        public System.Windows.Forms.TextBox textBoxSrcMailAddress;
        private System.Windows.Forms.Label labelSrcMailAddress;
        public System.Windows.Forms.CheckBox checkBoxSMTPSSL;
        public System.Windows.Forms.CheckBox checkBoxSMTPAuth;
        public System.Windows.Forms.TextBox textBoxDstMailAddresses;
        private System.Windows.Forms.Label labelDstMailAddresses;
        private System.Windows.Forms.Label labelDstMailAddresses1;
        private System.Windows.Forms.Label labelKeyField;
        public System.Windows.Forms.TextBox textBoxKeyField;
        private System.Windows.Forms.Label labelKeyField1;
        public System.Windows.Forms.CheckBox checkBoxSendMail;
        public System.Windows.Forms.TextBox textBoxWinServiceName;
        private System.Windows.Forms.Label labelWinServiceName;
        public System.Windows.Forms.DateTimePicker dateTimePickerInicioUpdate;
        private System.Windows.Forms.Label labelInicioUpdates;
        public System.Windows.Forms.DateTimePicker dateTimePickerFimUpdate;
        private System.Windows.Forms.Label labelFimUpdates;
        private System.Windows.Forms.Label labelOracleHome;
        public System.Windows.Forms.TextBox textBoxOraHome;
        private System.Windows.Forms.Button buttonBrowseOracleHome;
        private System.Windows.Forms.Label labelLogFile;
        public System.Windows.Forms.TextBox textBoxLogFile;
        private System.Windows.Forms.Button buttonBrowseLogFile;
    }
}