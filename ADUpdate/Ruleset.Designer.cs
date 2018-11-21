namespace ADUpdate
{
    partial class Ruleset
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxRegras = new System.Windows.Forms.ListBox();
            this.buttonAbreParentese = new System.Windows.Forms.Button();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.checkBoxIsCampo = new System.Windows.Forms.CheckBox();
            this.checkBoxEquals = new System.Windows.Forms.CheckBox();
            this.labelCampo = new System.Windows.Forms.Label();
            this.comboBoxCampoOrigem = new System.Windows.Forms.ComboBox();
            this.comboBoxCampo = new System.Windows.Forms.ComboBox();
            this.buttonFechaParentese = new System.Windows.Forms.Button();
            this.buttonE = new System.Windows.Forms.Button();
            this.buttonOu = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.checkBoxEnable = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBoxRegras
            // 
            this.listBoxRegras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRegras.FormattingEnabled = true;
            this.listBoxRegras.Location = new System.Drawing.Point(0, 30);
            this.listBoxRegras.Name = "listBoxRegras";
            this.listBoxRegras.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxRegras.Size = new System.Drawing.Size(520, 225);
            this.listBoxRegras.TabIndex = 0;
            // 
            // buttonAbreParentese
            // 
            this.buttonAbreParentese.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbreParentese.Location = new System.Drawing.Point(526, 30);
            this.buttonAbreParentese.Name = "buttonAbreParentese";
            this.buttonAbreParentese.Size = new System.Drawing.Size(31, 23);
            this.buttonAbreParentese.TabIndex = 1;
            this.buttonAbreParentese.Text = "(";
            this.buttonAbreParentese.UseVisualStyleBackColor = true;
            this.buttonAbreParentese.Click += new System.EventHandler(this.buttonAbreParentese_Click);
            // 
            // textBoxValor
            // 
            this.textBoxValor.Location = new System.Drawing.Point(335, 4);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(185, 20);
            this.textBoxValor.TabIndex = 104;
            // 
            // checkBoxIsCampo
            // 
            this.checkBoxIsCampo.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxIsCampo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxIsCampo.Location = new System.Drawing.Point(270, 3);
            this.checkBoxIsCampo.Name = "checkBoxIsCampo";
            this.checkBoxIsCampo.Size = new System.Drawing.Size(59, 21);
            this.checkBoxIsCampo.TabIndex = 103;
            this.checkBoxIsCampo.Text = "Valor";
            this.checkBoxIsCampo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxIsCampo.UseVisualStyleBackColor = true;
            this.checkBoxIsCampo.CheckedChanged += new System.EventHandler(this.checkBoxIsCampo_CheckedChanged);
            // 
            // checkBoxEquals
            // 
            this.checkBoxEquals.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxEquals.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEquals.Location = new System.Drawing.Point(242, 3);
            this.checkBoxEquals.Name = "checkBoxEquals";
            this.checkBoxEquals.Size = new System.Drawing.Size(22, 21);
            this.checkBoxEquals.TabIndex = 102;
            this.checkBoxEquals.Text = "≠";
            this.checkBoxEquals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEquals.UseVisualStyleBackColor = true;
            this.checkBoxEquals.CheckedChanged += new System.EventHandler(this.checkBoxEquals_CheckedChanged);
            // 
            // labelCampo
            // 
            this.labelCampo.AutoSize = true;
            this.labelCampo.Location = new System.Drawing.Point(2, 6);
            this.labelCampo.Name = "labelCampo";
            this.labelCampo.Size = new System.Drawing.Size(50, 15);
            this.labelCampo.TabIndex = 101;
            this.labelCampo.Text = "Campo:";
            // 
            // comboBoxCampoOrigem
            // 
            this.comboBoxCampoOrigem.FormattingEnabled = true;
            this.comboBoxCampoOrigem.Location = new System.Drawing.Point(51, 3);
            this.comboBoxCampoOrigem.Name = "comboBoxCampoOrigem";
            this.comboBoxCampoOrigem.Size = new System.Drawing.Size(185, 21);
            this.comboBoxCampoOrigem.TabIndex = 100;
            // 
            // comboBoxCampo
            // 
            this.comboBoxCampo.FormattingEnabled = true;
            this.comboBoxCampo.Location = new System.Drawing.Point(335, 3);
            this.comboBoxCampo.Name = "comboBoxCampo";
            this.comboBoxCampo.Size = new System.Drawing.Size(185, 21);
            this.comboBoxCampo.TabIndex = 105;
            this.comboBoxCampo.Visible = false;
            // 
            // buttonFechaParentese
            // 
            this.buttonFechaParentese.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFechaParentese.Location = new System.Drawing.Point(526, 59);
            this.buttonFechaParentese.Name = "buttonFechaParentese";
            this.buttonFechaParentese.Size = new System.Drawing.Size(31, 23);
            this.buttonFechaParentese.TabIndex = 106;
            this.buttonFechaParentese.Text = ")";
            this.buttonFechaParentese.UseVisualStyleBackColor = true;
            this.buttonFechaParentese.Click += new System.EventHandler(this.buttonFechaParentese_Click);
            // 
            // buttonE
            // 
            this.buttonE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonE.Location = new System.Drawing.Point(526, 88);
            this.buttonE.Name = "buttonE";
            this.buttonE.Size = new System.Drawing.Size(31, 23);
            this.buttonE.TabIndex = 107;
            this.buttonE.Text = "E";
            this.buttonE.UseVisualStyleBackColor = true;
            this.buttonE.Click += new System.EventHandler(this.buttonE_Click);
            // 
            // buttonOu
            // 
            this.buttonOu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOu.Location = new System.Drawing.Point(526, 117);
            this.buttonOu.Name = "buttonOu";
            this.buttonOu.Size = new System.Drawing.Size(31, 23);
            this.buttonOu.TabIndex = 108;
            this.buttonOu.Text = "Ou";
            this.buttonOu.UseVisualStyleBackColor = true;
            this.buttonOu.Click += new System.EventHandler(this.buttonOu_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Location = new System.Drawing.Point(526, 175);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(31, 23);
            this.buttonRemove.TabIndex = 110;
            this.buttonRemove.Text = "-";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(526, 146);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(31, 23);
            this.buttonAdd.TabIndex = 109;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveDown.Location = new System.Drawing.Point(526, 233);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(31, 23);
            this.buttonMoveDown.TabIndex = 112;
            this.buttonMoveDown.Text = "↓";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveUp.Location = new System.Drawing.Point(526, 204);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(31, 23);
            this.buttonMoveUp.TabIndex = 111;
            this.buttonMoveUp.Text = "↑";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // checkBoxEnable
            // 
            this.checkBoxEnable.AutoSize = true;
            this.checkBoxEnable.Location = new System.Drawing.Point(542, 6);
            this.checkBoxEnable.Name = "checkBoxEnable";
            this.checkBoxEnable.Size = new System.Drawing.Size(15, 14);
            this.checkBoxEnable.TabIndex = 113;
            this.checkBoxEnable.UseVisualStyleBackColor = true;
            // 
            // Ruleset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxEnable);
            this.Controls.Add(this.buttonMoveDown);
            this.Controls.Add(this.buttonMoveUp);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonOu);
            this.Controls.Add(this.buttonE);
            this.Controls.Add(this.buttonFechaParentese);
            this.Controls.Add(this.textBoxValor);
            this.Controls.Add(this.checkBoxIsCampo);
            this.Controls.Add(this.checkBoxEquals);
            this.Controls.Add(this.labelCampo);
            this.Controls.Add(this.comboBoxCampoOrigem);
            this.Controls.Add(this.buttonAbreParentese);
            this.Controls.Add(this.listBoxRegras);
            this.Controls.Add(this.comboBoxCampo);
            this.MinimumSize = new System.Drawing.Size(562, 203);
            this.Name = "Ruleset";
            this.Size = new System.Drawing.Size(562, 255);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAbreParentese;
        private System.Windows.Forms.TextBox textBoxValor;
        public System.Windows.Forms.CheckBox checkBoxIsCampo;
        public System.Windows.Forms.CheckBox checkBoxEquals;
        private System.Windows.Forms.Label labelCampo;
        private System.Windows.Forms.ComboBox comboBoxCampoOrigem;
        private System.Windows.Forms.ComboBox comboBoxCampo;
        private System.Windows.Forms.Button buttonFechaParentese;
        private System.Windows.Forms.Button buttonE;
        private System.Windows.Forms.Button buttonOu;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button buttonMoveUp;
        public System.Windows.Forms.ListBox listBoxRegras;
        public System.Windows.Forms.CheckBox checkBoxEnable;
    }
}
