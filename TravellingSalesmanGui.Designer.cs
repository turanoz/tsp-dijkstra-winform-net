namespace TSP
{
    partial class TravellingSalesmanGui
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TravellingSalesmanGui));
            richTextBox1 = new RichTextBox();
            btnCalculate = new Button();
            icons = new ImageList(components);
            btnAddPath = new Button();
            btnAddStartLocation = new Button();
            btnSaveLocation = new Button();
            btnSavePath = new Button();
            btnClear = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            panel1 = new Panel();
            btnAddLocation = new Button();
            map = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)map).BeginInit();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(498, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(491, 94);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // btnCalculate
            // 
            btnCalculate.Dock = DockStyle.Fill;
            btnCalculate.Enabled = false;
            btnCalculate.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCalculate.ImageKey = "calculator.png";
            btnCalculate.ImageList = icons;
            btnCalculate.Location = new Point(297, 0);
            btnCalculate.Margin = new Padding(0);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(99, 100);
            btnCalculate.TabIndex = 4;
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // icons
            // 
            icons.ColorDepth = ColorDepth.Depth32Bit;
            icons.ImageStream = (ImageListStreamer)resources.GetObject("icons.ImageStream");
            icons.TransparentColor = Color.Transparent;
            icons.Images.SetKeyName(0, "marker.png");
            icons.Images.SetKeyName(1, "location.png");
            icons.Images.SetKeyName(2, "road.png");
            icons.Images.SetKeyName(3, "calculator.png");
            icons.Images.SetKeyName(4, "diskette.png");
            icons.Images.SetKeyName(5, "delivery-status.png");
            // 
            // btnAddPath
            // 
            btnAddPath.Dock = DockStyle.Fill;
            btnAddPath.Enabled = false;
            btnAddPath.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddPath.ImageKey = "road.png";
            btnAddPath.ImageList = icons;
            btnAddPath.Location = new Point(0, 0);
            btnAddPath.Margin = new Padding(0);
            btnAddPath.Name = "btnAddPath";
            btnAddPath.Size = new Size(99, 100);
            btnAddPath.TabIndex = 5;
            btnAddPath.UseVisualStyleBackColor = true;
            btnAddPath.Click += btnAddPath_Click;
            // 
            // btnAddStartLocation
            // 
            btnAddStartLocation.Dock = DockStyle.Fill;
            btnAddStartLocation.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddStartLocation.ImageKey = "marker.png";
            btnAddStartLocation.ImageList = icons;
            btnAddStartLocation.Location = new Point(0, 0);
            btnAddStartLocation.Margin = new Padding(0);
            btnAddStartLocation.Name = "btnAddStartLocation";
            btnAddStartLocation.Size = new Size(99, 100);
            btnAddStartLocation.TabIndex = 7;
            btnAddStartLocation.UseVisualStyleBackColor = true;
            btnAddStartLocation.Click += btnAddStartLocation_Click;
            // 
            // btnSaveLocation
            // 
            btnSaveLocation.Dock = DockStyle.Fill;
            btnSaveLocation.ImageKey = "diskette.png";
            btnSaveLocation.ImageList = icons;
            btnSaveLocation.Location = new Point(0, 0);
            btnSaveLocation.Margin = new Padding(0);
            btnSaveLocation.Name = "btnSaveLocation";
            btnSaveLocation.Size = new Size(99, 100);
            btnSaveLocation.TabIndex = 0;
            btnSaveLocation.UseVisualStyleBackColor = true;
            btnSaveLocation.Visible = false;
            btnSaveLocation.Click += btnSaveLocation_Click;
            // 
            // btnSavePath
            // 
            btnSavePath.Dock = DockStyle.Fill;
            btnSavePath.ImageKey = "diskette.png";
            btnSavePath.ImageList = icons;
            btnSavePath.Location = new Point(0, 0);
            btnSavePath.Margin = new Padding(0);
            btnSavePath.Name = "btnSavePath";
            btnSavePath.Size = new Size(99, 100);
            btnSavePath.TabIndex = 0;
            btnSavePath.UseVisualStyleBackColor = true;
            btnSavePath.Visible = false;
            btnSavePath.Click += btnSavePath_Click;
            // 
            // btnClear
            // 
            btnClear.Dock = DockStyle.Fill;
            btnClear.Enabled = false;
            btnClear.ImageIndex = 5;
            btnClear.ImageList = icons;
            btnClear.Location = new Point(396, 0);
            btnClear.Margin = new Padding(0);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(99, 100);
            btnClear.TabIndex = 9;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnCalculate, 3, 0);
            tableLayoutPanel1.Controls.Add(btnAddStartLocation, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 2, 0);
            tableLayoutPanel1.Controls.Add(richTextBox1, 5, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Controls.Add(btnClear, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 610);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(992, 100);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnAddPath);
            panel2.Controls.Add(btnSavePath);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(198, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(99, 100);
            panel2.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAddLocation);
            panel1.Controls.Add(btnSaveLocation);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(99, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(99, 100);
            panel1.TabIndex = 11;
            // 
            // btnAddLocation
            // 
            btnAddLocation.Dock = DockStyle.Fill;
            btnAddLocation.Enabled = false;
            btnAddLocation.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddLocation.ImageKey = "location.png";
            btnAddLocation.ImageList = icons;
            btnAddLocation.Location = new Point(0, 0);
            btnAddLocation.Margin = new Padding(0);
            btnAddLocation.Name = "btnAddLocation";
            btnAddLocation.Size = new Size(99, 100);
            btnAddLocation.TabIndex = 6;
            btnAddLocation.UseVisualStyleBackColor = true;
            btnAddLocation.Click += btnAddLocation_Click;
            // 
            // map
            // 
            map.BackColor = Color.Transparent;
            map.Dock = DockStyle.Fill;
            map.ErrorImage = null;
            map.InitialImage = null;
            map.Location = new Point(0, 0);
            map.Name = "map";
            map.Size = new Size(992, 710);
            map.TabIndex = 11;
            map.TabStop = false;
            map.MouseClick += map_MouseClick;
            // 
            // TravellingSalesmanGui
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 710);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(map);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "TravellingSalesmanGui";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TSPGUI";
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)map).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnCalculate;
        private Button btnAddPath;
        private Button btnAddStartLocation;
        private Button btnSaveLocation;
        private Button btnSavePath;
        private Button btnClear;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel1;
        private PictureBox map;
        public RichTextBox richTextBox1;
        private Button btnAddLocation;
        private ImageList icons;
    }
}