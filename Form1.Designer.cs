namespace GezginSaticiProblemi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.baslangicnoktasibelirle = new System.Windows.Forms.ToolStripMenuItem();
            this.durakEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.durakeklemeyibitir = new System.Windows.Forms.ToolStripMenuItem();
            this.uzaklıkEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hesaplaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(879, 571);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baslangicnoktasibelirle,
            this.durakEkleToolStripMenuItem,
            this.durakeklemeyibitir,
            this.uzaklıkEkleToolStripMenuItem,
            this.hesaplaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(203, 136);
            // 
            // baslangicnoktasibelirle
            // 
            this.baslangicnoktasibelirle.Name = "baslangicnoktasibelirle";
            this.baslangicnoktasibelirle.Size = new System.Drawing.Size(202, 22);
            this.baslangicnoktasibelirle.Text = "Başlangıç Noktası Belirle";
            this.baslangicnoktasibelirle.Click += new System.EventHandler(this.baslangicnoktasibelirle_Click);
            // 
            // durakEkleToolStripMenuItem
            // 
            this.durakEkleToolStripMenuItem.Name = "durakEkleToolStripMenuItem";
            this.durakEkleToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.durakEkleToolStripMenuItem.Text = "Durak Ekle";
            this.durakEkleToolStripMenuItem.Visible = false;
            this.durakEkleToolStripMenuItem.Click += new System.EventHandler(this.durakEkleToolStripMenuItem_Click);
            // 
            // durakeklemeyibitir
            // 
            this.durakeklemeyibitir.Name = "durakeklemeyibitir";
            this.durakeklemeyibitir.Size = new System.Drawing.Size(202, 22);
            this.durakeklemeyibitir.Text = "Durak Eklemeyi Bitir";
            this.durakeklemeyibitir.Visible = false;
            this.durakeklemeyibitir.Click += new System.EventHandler(this.durakeklemeyibitir_Click);
            // 
            // uzaklıkEkleToolStripMenuItem
            // 
            this.uzaklıkEkleToolStripMenuItem.Name = "uzaklıkEkleToolStripMenuItem";
            this.uzaklıkEkleToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.uzaklıkEkleToolStripMenuItem.Text = "Uzaklık Ekle";
            this.uzaklıkEkleToolStripMenuItem.Visible = false;
            this.uzaklıkEkleToolStripMenuItem.Click += new System.EventHandler(this.uzaklıkEkleToolStripMenuItem_Click);
            // 
            // hesaplaToolStripMenuItem
            // 
            this.hesaplaToolStripMenuItem.Name = "hesaplaToolStripMenuItem";
            this.hesaplaToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.hesaplaToolStripMenuItem.Text = "Hesapla";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 595);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem baslangicnoktasibelirle;
        private ToolStripMenuItem durakEkleToolStripMenuItem;
        private ToolStripMenuItem uzaklıkEkleToolStripMenuItem;
        private ToolStripMenuItem durakeklemeyibitir;
        private ToolStripMenuItem hesaplaToolStripMenuItem;
    }
}