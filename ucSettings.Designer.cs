namespace Desklean
{
    partial class ucSettings
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
            this.comboTimeType = new System.Windows.Forms.ComboBox();
            this.chkCreateSubfolders = new System.Windows.Forms.CheckBox();
            this.chkSendNotofications = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSelectDir = new System.Windows.Forms.Button();
            this.fldTargetDir = new System.Windows.Forms.TextBox();
            this.numAddTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkMoveShortcuts = new System.Windows.Forms.CheckBox();
            this.chkMoveFolders = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkAutorun = new System.Windows.Forms.CheckBox();
            this.numTimeInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbExt = new System.Windows.Forms.TextBox();
            this.listRestr = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAddTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeInterval)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboTimeType
            // 
            this.comboTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTimeType.FormattingEnabled = true;
            this.comboTimeType.Items.AddRange(new object[] {
            "Segundos",
            "Minutos",
            "Horas",
            "Dias"});
            this.comboTimeType.Location = new System.Drawing.Point(185, 21);
            this.comboTimeType.Name = "comboTimeType";
            this.comboTimeType.Size = new System.Drawing.Size(85, 21);
            this.comboTimeType.TabIndex = 41;
            // 
            // chkCreateSubfolders
            // 
            this.chkCreateSubfolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCreateSubfolders.AutoSize = true;
            this.chkCreateSubfolders.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCreateSubfolders.Location = new System.Drawing.Point(11, 115);
            this.chkCreateSubfolders.Name = "chkCreateSubfolders";
            this.chkCreateSubfolders.Size = new System.Drawing.Size(263, 17);
            this.chkCreateSubfolders.TabIndex = 40;
            this.chkCreateSubfolders.Text = "Criar subdiretotias conforme a extensão do ficheiro\r\n";
            this.chkCreateSubfolders.UseVisualStyleBackColor = true;
            // 
            // chkSendNotofications
            // 
            this.chkSendNotofications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSendNotofications.AutoSize = true;
            this.chkSendNotofications.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSendNotofications.Location = new System.Drawing.Point(11, 92);
            this.chkSendNotofications.Name = "chkSendNotofications";
            this.chkSendNotofications.Size = new System.Drawing.Size(259, 17);
            this.chkSendNotofications.TabIndex = 39;
            this.chkSendNotofications.Text = "Enviar notificação quando novo ficheiro detetado";
            this.chkSendNotofications.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(238, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "segundos";
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDir.Location = new System.Drawing.Point(485, 15);
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDir.TabIndex = 28;
            this.btnSelectDir.Text = "Escolher";
            this.btnSelectDir.UseVisualStyleBackColor = true;
            this.btnSelectDir.Click += new System.EventHandler(this.btnSelectDir_Click);
            // 
            // fldTargetDir
            // 
            this.fldTargetDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fldTargetDir.Location = new System.Drawing.Point(115, 18);
            this.fldTargetDir.Name = "fldTargetDir";
            this.fldTargetDir.ReadOnly = true;
            this.fldTargetDir.Size = new System.Drawing.Size(355, 20);
            this.fldTargetDir.TabIndex = 27;
            // 
            // numAddTime
            // 
            this.numAddTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numAddTime.Location = new System.Drawing.Point(123, 21);
            this.numAddTime.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numAddTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAddTime.Name = "numAddTime";
            this.numAddTime.Size = new System.Drawing.Size(56, 20);
            this.numAddTime.TabIndex = 37;
            this.numAddTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Diretório de destino:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Mover ficheiros cada:";
            // 
            // chkMoveShortcuts
            // 
            this.chkMoveShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMoveShortcuts.AutoSize = true;
            this.chkMoveShortcuts.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMoveShortcuts.Location = new System.Drawing.Point(13, 46);
            this.chkMoveShortcuts.Name = "chkMoveShortcuts";
            this.chkMoveShortcuts.Size = new System.Drawing.Size(93, 17);
            this.chkMoveShortcuts.TabIndex = 35;
            this.chkMoveShortcuts.Text = "Mover atalhos";
            this.chkMoveShortcuts.UseVisualStyleBackColor = true;
            // 
            // chkMoveFolders
            // 
            this.chkMoveFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMoveFolders.AutoSize = true;
            this.chkMoveFolders.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMoveFolders.Location = new System.Drawing.Point(11, 23);
            this.chkMoveFolders.Name = "chkMoveFolders";
            this.chkMoveFolders.Size = new System.Drawing.Size(101, 17);
            this.chkMoveFolders.TabIndex = 34;
            this.chkMoveFolders.Text = "Mover diretorias";
            this.chkMoveFolders.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Ex: \"png\" e em seguida clique Adicionar";
            // 
            // chkAutorun
            // 
            this.chkAutorun.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutorun.AutoSize = true;
            this.chkAutorun.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutorun.Location = new System.Drawing.Point(11, 69);
            this.chkAutorun.Name = "chkAutorun";
            this.chkAutorun.Size = new System.Drawing.Size(63, 17);
            this.chkAutorun.TabIndex = 32;
            this.chkAutorun.Text = "Autorun";
            this.chkAutorun.UseVisualStyleBackColor = true;
            // 
            // numTimeInterval
            // 
            this.numTimeInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numTimeInterval.Location = new System.Drawing.Point(176, 50);
            this.numTimeInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numTimeInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimeInterval.Name = "numTimeInterval";
            this.numTimeInterval.Size = new System.Drawing.Size(56, 20);
            this.numTimeInterval.TabIndex = 25;
            this.numTimeInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Verificar por novos ficheiros cada:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.tbExt);
            this.groupBox1.Controls.Add(this.listRestr);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(371, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 219);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exceções";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(165, 104);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remover";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(165, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbExt
            // 
            this.tbExt.Location = new System.Drawing.Point(30, 27);
            this.tbExt.Name = "tbExt";
            this.tbExt.Size = new System.Drawing.Size(120, 20);
            this.tbExt.TabIndex = 1;
            this.tbExt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbExt_KeyDown);
            // 
            // listRestr
            // 
            this.listRestr.FormattingEnabled = true;
            this.listRestr.Location = new System.Drawing.Point(30, 104);
            this.listRestr.Name = "listRestr";
            this.listRestr.Size = new System.Drawing.Size(120, 95);
            this.listRestr.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkCreateSubfolders);
            this.groupBox2.Controls.Add(this.chkSendNotofications);
            this.groupBox2.Controls.Add(this.chkMoveShortcuts);
            this.groupBox2.Controls.Add(this.chkMoveFolders);
            this.groupBox2.Controls.Add(this.chkAutorun);
            this.groupBox2.Location = new System.Drawing.Point(51, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 138);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outros";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numAddTime);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.comboTimeType);
            this.groupBox3.Controls.Add(this.numTimeInterval);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(51, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(293, 75);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configurações de horário";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSelectDir);
            this.groupBox4.Controls.Add(this.fldTargetDir);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(51, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(588, 56);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Diretório";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(313, 293);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 34);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucSettings";
            this.Size = new System.Drawing.Size(700, 330);
            ((System.ComponentModel.ISupportInitialize)(this.numAddTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeInterval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboTimeType;
        private System.Windows.Forms.CheckBox chkCreateSubfolders;
        private System.Windows.Forms.CheckBox chkSendNotofications;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSelectDir;
        private System.Windows.Forms.TextBox fldTargetDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkMoveShortcuts;
        private System.Windows.Forms.CheckBox chkMoveFolders;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkAutorun;
        private System.Windows.Forms.NumericUpDown numTimeInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbExt;
        private System.Windows.Forms.ListBox listRestr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numAddTime;
        private System.Windows.Forms.Button btnSave;
    }
}
