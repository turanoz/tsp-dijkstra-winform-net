namespace TSP
{
    partial class TSPGUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TSPGUI));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.hesapla = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.uzaklikEkle = new System.Windows.Forms.Button();
            this.konumEkle = new System.Windows.Forms.Button();
            this.baslangicKonumEkle = new System.Windows.Forms.Button();
            this.tspPanel = new System.Windows.Forms.Panel();
            this.konumKaydet = new System.Windows.Forms.Button();
            this.uzaklikKaydet = new System.Windows.Forms.Button();
            this.temizle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(294, 511);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(573, 48);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // hesapla
            // 
            this.hesapla.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hesapla.ImageKey = "calculator.png";
            this.hesapla.ImageList = this.imageList1;
            this.hesapla.Location = new System.Drawing.Point(174, 511);
            this.hesapla.Name = "hesapla";
            this.hesapla.Size = new System.Drawing.Size(48, 48);
            this.hesapla.TabIndex = 4;
            this.hesapla.UseVisualStyleBackColor = true;
            this.hesapla.Click += new System.EventHandler(this.hesapla_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "marker.png");
            this.imageList1.Images.SetKeyName(1, "location.png");
            this.imageList1.Images.SetKeyName(2, "road.png");
            this.imageList1.Images.SetKeyName(3, "calculator.png");
            this.imageList1.Images.SetKeyName(4, "diskette.png");
            this.imageList1.Images.SetKeyName(5, "delivery-status.png");
            // 
            // uzaklikEkle
            // 
            this.uzaklikEkle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uzaklikEkle.ImageKey = "road.png";
            this.uzaklikEkle.ImageList = this.imageList1;
            this.uzaklikEkle.Location = new System.Drawing.Point(120, 511);
            this.uzaklikEkle.Name = "uzaklikEkle";
            this.uzaklikEkle.Size = new System.Drawing.Size(48, 48);
            this.uzaklikEkle.TabIndex = 5;
            this.uzaklikEkle.UseVisualStyleBackColor = true;
            this.uzaklikEkle.Click += new System.EventHandler(this.uzaklikEkle_Click);
            // 
            // konumEkle
            // 
            this.konumEkle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.konumEkle.ImageKey = "location.png";
            this.konumEkle.ImageList = this.imageList1;
            this.konumEkle.Location = new System.Drawing.Point(66, 511);
            this.konumEkle.Name = "konumEkle";
            this.konumEkle.Size = new System.Drawing.Size(48, 48);
            this.konumEkle.TabIndex = 6;
            this.konumEkle.UseVisualStyleBackColor = true;
            this.konumEkle.Click += new System.EventHandler(this.konumEkle_Click);
            // 
            // baslangicKonumEkle
            // 
            this.baslangicKonumEkle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.baslangicKonumEkle.ImageKey = "marker.png";
            this.baslangicKonumEkle.ImageList = this.imageList1;
            this.baslangicKonumEkle.Location = new System.Drawing.Point(12, 511);
            this.baslangicKonumEkle.Name = "baslangicKonumEkle";
            this.baslangicKonumEkle.Size = new System.Drawing.Size(48, 48);
            this.baslangicKonumEkle.TabIndex = 7;
            this.baslangicKonumEkle.UseVisualStyleBackColor = true;
            this.baslangicKonumEkle.Click += new System.EventHandler(this.baslangicKonumEkle_Click);
            // 
            // tspPanel
            // 
            this.tspPanel.BackgroundImage = global::TSP.Properties.Resources.Screenshot_1;
            this.tspPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tspPanel.Location = new System.Drawing.Point(12, 12);
            this.tspPanel.Name = "tspPanel";
            this.tspPanel.Size = new System.Drawing.Size(855, 493);
            this.tspPanel.TabIndex = 3;
            this.tspPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tspPanel_MouseClick);
            // 
            // konumKaydet
            // 
            this.konumKaydet.ImageKey = "diskette.png";
            this.konumKaydet.ImageList = this.imageList1;
            this.konumKaydet.Location = new System.Drawing.Point(66, 511);
            this.konumKaydet.Name = "konumKaydet";
            this.konumKaydet.Size = new System.Drawing.Size(48, 48);
            this.konumKaydet.TabIndex = 0;
            this.konumKaydet.UseVisualStyleBackColor = true;
            this.konumKaydet.Visible = false;
            this.konumKaydet.Click += new System.EventHandler(this.konumKaydet_Click);
            // 
            // uzaklikKaydet
            // 
            this.uzaklikKaydet.ImageKey = "diskette.png";
            this.uzaklikKaydet.ImageList = this.imageList1;
            this.uzaklikKaydet.Location = new System.Drawing.Point(120, 511);
            this.uzaklikKaydet.Name = "uzaklikKaydet";
            this.uzaklikKaydet.Size = new System.Drawing.Size(48, 48);
            this.uzaklikKaydet.TabIndex = 0;
            this.uzaklikKaydet.UseVisualStyleBackColor = true;
            this.uzaklikKaydet.Visible = false;
            this.uzaklikKaydet.Click += new System.EventHandler(this.uzaklikKaydet_Click);
            // 
            // temizle
            // 
            this.temizle.ImageIndex = 5;
            this.temizle.ImageList = this.imageList1;
            this.temizle.Location = new System.Drawing.Point(228, 511);
            this.temizle.Name = "temizle";
            this.temizle.Size = new System.Drawing.Size(48, 48);
            this.temizle.TabIndex = 9;
            this.temizle.UseVisualStyleBackColor = true;
            this.temizle.Click += new System.EventHandler(this.temizle_Click);
            // 
            // TSPGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 571);
            this.Controls.Add(this.temizle);
            this.Controls.Add(this.uzaklikKaydet);
            this.Controls.Add(this.konumKaydet);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.hesapla);
            this.Controls.Add(this.uzaklikEkle);
            this.Controls.Add(this.konumEkle);
            this.Controls.Add(this.baslangicKonumEkle);
            this.Controls.Add(this.tspPanel);
            this.Name = "TSPGUI";
            this.Text = "TSPGUI";
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox richTextBox1;
        private Button hesapla;
        private Button uzaklikEkle;
        private Button konumEkle;
        private Button baslangicKonumEkle;
        private ImageList imageList1;
        private Button konumKaydet;
        private Button uzaklikKaydet;
        private Button temizle;
        public Panel tspPanel;
    }
}