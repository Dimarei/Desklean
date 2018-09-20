namespace Desklean
{
    partial class ucHome
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
            this.btnStart = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.removeFromlist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Image = global::Desklean.Properties.Resources.start;
            this.btnStart.Location = new System.Drawing.Point(225, 26);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(250, 80);
            this.btnStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnStart.TabIndex = 29;
            this.btnStart.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(0, 129);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(700, 95);
            this.listBox1.TabIndex = 30;
            // 
            // removeFromlist
            // 
            this.removeFromlist.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeFromlist.Location = new System.Drawing.Point(204, 230);
            this.removeFromlist.Name = "removeFromlist";
            this.removeFromlist.Size = new System.Drawing.Size(305, 32);
            this.removeFromlist.TabIndex = 31;
            this.removeFromlist.Text = "Remover ficheiro selecionado da lista";
            this.removeFromlist.UseVisualStyleBackColor = true;
            // 
            // ucHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.removeFromlist);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnStart);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ucHome";
            this.Size = new System.Drawing.Size(700, 300);
            this.Load += new System.EventHandler(this.ucHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox btnStart;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button removeFromlist;
    }
}
