using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TSP
{
    public partial class TSPGUI : Form
    {
        public TSPGUI()
        {
            InitializeComponent();
            cizim = tspPanel.CreateGraphics();
            cizim.SmoothingMode = SmoothingMode.HighQuality;
            cizim.InterpolationMode = InterpolationMode.HighQualityBicubic;
            konumEkle.Enabled = false;
            uzaklikEkle.Enabled = false;
            hesapla.Enabled = false;
        }

        private Graphics cizim;
        private List<Node> Nodes = new();
        private List<Path> Paths = new();
        private int menu = -1;
        private int counter = 0;
        private int firstNodeId = 0;

        private void baslangicKonumEkle_Click(object sender, EventArgs e)
        {
            baslangicKonumEkle.Enabled = false;
            menu = 0;
        }

        private void konumEkle_Click(object sender, EventArgs e)
        {
            konumEkle.Visible = false;
            konumEkle.Enabled = false;
            konumKaydet.Visible = true;
            menu = 1;
        }

        private void konumKaydet_Click(object sender, EventArgs e)
        {
            menu = -1;
            konumKaydet.Visible = false;
            konumEkle.Visible = true;
            uzaklikEkle.Enabled = true;
        }

        private void uzaklikEkle_Click(object sender, EventArgs e)
        {
            menu = 2;
            uzaklikEkle.Visible = false;
            uzaklikKaydet.Visible = true;
        }

        private HashSet<int> getSet()
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < Paths.Count; i++)
            {
                set.Add(Paths[i].firstNodeId);
                set.Add(Paths[i].secondNodeId);
            }

            return set;
        }

        private void uzaklikKaydet_Click(object sender, EventArgs e)
        {
            var hashSet = getSet();

            if (hashSet.Count != Nodes.Count)
            {
                MessageBox.Show("Uzaklık eklemediğiniz konum bulunmaktadır.");
            }
            else
            {
                menu = -1;
                uzaklikEkle.Visible = true;
                uzaklikKaydet.Visible = false;
                hesapla.Enabled = true;
            }
        }


        private double[,] adjacency_matrix()
        {
            var matrix = new Double[Nodes.Count, Nodes.Count];

            for (int i = 0; i < Nodes.Count; i++)
            {
                for (int j = 0; j < Nodes.Count; j++)
                {
                    matrix[i, j] = 10000;
                }
            }

            for (var j = 0; j < Paths.Count; j++)
            {
                matrix[Paths[j].firstNodeId, Paths[j].secondNodeId] = Paths[j].weight;
                matrix[Paths[j].secondNodeId, Paths[j].firstNodeId] = Paths[j].weight;
            }

            return matrix;
        }

        private void hesapla_Click(object sender, EventArgs e)
        {
            int startNode = 0;
            Solve solver = new Solve(startNode, adjacency_matrix());


            foreach (var item in solver.getTour())
            {
                richTextBox1.Text += item.ToString();
            }


            richTextBox1.Text += "Tour cost: " + solver.getTourCost();
        }

        private void temizle_Click(object sender, EventArgs e)
        {
            tspPanel.Refresh();
            Nodes.Clear();
            Paths.Clear();
            baslangicKonumEkle.Enabled = true;
            konumEkle.Enabled = false;
            konumEkle.Visible = true;
            konumKaydet.Visible = false;
            uzaklikEkle.Enabled = false;
            uzaklikEkle.Visible = true;
            uzaklikKaydet.Visible = false;
            hesapla.Enabled = false;
        }


        private void tspPanel_MouseClick(object sender, MouseEventArgs e)
        {
            switch (menu)
            {
                case 0:
                {
                    var orangeBrush = new SolidBrush(Color.Orange);
                    cizim.FillEllipse(orangeBrush, e.X - 15, e.Y - 15, 30, 30);

                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        cizim.DrawString("0", new Font("Verdana", 12), Brushes.AliceBlue, e.X, e.Y, sf);
                    }

                    Nodes.Add(new Node()
                    {
                        id = 0,
                        X = e.X - 15,
                        Y = e.Y - 15
                    });
                    menu = -1;
                    konumEkle.Enabled = true;
                    break;
                }
                case 1:
                {
                    var isNodes = Nodes.Where(n => Math.Abs(n.X - e.X) < 61 && Math.Abs(n.Y - e.Y) < 61).ToList();
                    if (!isNodes.Any())
                    {
                        cizim.FillEllipse(new SolidBrush(Color.Red), e.X - 15, e.Y - 15, 30, 30);
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;
                            cizim.DrawString(Nodes.Count.ToString(), new Font("Verdana", 12), Brushes.AliceBlue, e.X,
                                e.Y, sf);
                        }

                        Nodes.Add(new Node()
                        {
                            id = Nodes.Count,
                            X = e.X - 15,
                            Y = e.Y - 15
                        });
                    }
                    else
                    {
                        MessageBox.Show("Daha uzak bir yeri işaretleyin");
                    }

                    break;
                }
                case 2:
                {
                    var currentPath = Paths.FirstOrDefault(p => Math.Abs(p.X - e.X) < 31 && Math.Abs(p.Y - e.Y) < 31);
                    if (currentPath != null)
                    {
                        var weight = Interaction.InputBox("Lütfen iki durak arasındaki mesafeyi giriniz.",
                            "Uzaklık Değeri", currentPath.weight.ToString());

                        // Create string to draw.
                        String drawString = weight.ToString();

                        // Create font and brush.
                        Font drawFont = new Font("Verdana", 12);
                        SolidBrush drawBrush = new SolidBrush(Color.Black);

                        // Create rectangle for drawing.
                        float width = 30;
                        float height = 30;
                        RectangleF drawRect =
                            new RectangleF(currentPath.X - 15f, currentPath.Y - 15f, width, height);

                        cizim.FillRectangle(drawBrush, currentPath.X - 15f, currentPath.Y - 15f, width, height);

                        // Set format of string.
                        StringFormat drawFormat = new StringFormat();
                        drawFormat.Alignment = StringAlignment.Center;
                        drawFormat.LineAlignment = StringAlignment.Center;

                        // Draw string to screen.
                        cizim.DrawString(drawString, drawFont, Brushes.AliceBlue, drawRect, drawFormat);
                        Paths.RemoveAt(currentPath.Id);
                        Paths.Add(
                            new Path()
                            {
                                Id = currentPath.Id,
                                firstNodeId = currentPath.firstNodeId,
                                secondNodeId = currentPath.secondNodeId,
                                X = currentPath.X,
                                Y = currentPath.Y,
                                weight = Convert.ToInt32(weight)
                            });
                        break;
                    }


                    var node = Nodes.FirstOrDefault(x => Math.Abs(x.X - e.X) < 61 && Math.Abs(x.Y - e.Y) < 61);
                    var greenPen = new Pen(Color.Green, 3);

                    if (node == null)
                    {
                        MessageBox.Show("Lütfen düğüm seçiniz !");
                        break;
                    }

                    switch (counter)
                    {
                        case 0:
                        {
                            cizim.DrawEllipse(greenPen, node.X, node.Y, 30, 30);
                            firstNodeId = node.id;
                            counter++;
                            break;
                        }
                        case 1:
                        {
                            if (firstNodeId == node.id)
                            {
                                MessageBox.Show("Konumlar aynı olamaz!");
                                counter = 0;
                                break;
                            }

                            var path = Paths.FirstOrDefault(p =>
                                (p.firstNodeId == firstNodeId && p.secondNodeId == node.id) ||
                                (p.firstNodeId == node.id && p.secondNodeId == firstNodeId));

                            if (path == null)
                            {
                                cizim.DrawEllipse(greenPen, node.X, node.Y, 30, 30);

                                var blackPen = new Pen(Color.Black, 3);
                                var weight = Interaction.InputBox("Lütfen iki durak arasındaki mesafeyi giriniz.",
                                    "Uzaklık Değeri", "-1");

                                var pointNode1 = Nodes.FirstOrDefault(x => x.id == firstNodeId);

                                if (pointNode1 != null)
                                {
                                    var pt1 = new Point(pointNode1.X + 15, pointNode1.Y + 15);
                                    var pt2 = new Point(node.X + 15, node.Y + 15);
                                    var ptMed = new Point((pt1.X + pt2.X) / 2, (pt1.Y + pt2.Y) / 2);
                                    cizim.DrawLine(blackPen, pt1, pt2);
                                    // Create string to draw.
                                    String drawString = weight.ToString();

                                    // Create font and brush.
                                    Font drawFont = new Font("Verdana", 12);
                                    SolidBrush drawBrush = new SolidBrush(Color.Black);

                                    // Create rectangle for drawing.
                                    float width = 30;
                                    float height = 30;
                                    RectangleF drawRect =
                                        new RectangleF(ptMed.X - 15f, ptMed.Y - 15f, width, height);

                                    cizim.FillRectangle(drawBrush, ptMed.X - 15f, ptMed.Y - 15f, width, height);

                                    // Set format of string.
                                    StringFormat drawFormat = new StringFormat();
                                    drawFormat.Alignment = StringAlignment.Center;
                                    drawFormat.LineAlignment = StringAlignment.Center;

                                    // Draw string to screen.
                                    cizim.DrawString(drawString, drawFont, Brushes.AliceBlue, drawRect, drawFormat);

                                    DrawEllipseNode(cizim, node);
                                    DrawEllipseNode(cizim, pointNode1);

                                    Paths.Add(
                                        new Path()
                                        {
                                            Id = Paths.Count,
                                            firstNodeId = firstNodeId,
                                            secondNodeId = node.id,
                                            X = ptMed.X,
                                            Y = ptMed.Y,
                                            weight = Convert.ToInt32(weight)
                                        });
                                    counter = 0;
                                }

                                break;
                            }
                            else
                            {
                                MessageBox.Show("Daha önce iki konumu işaretlediniz!");
                                counter = 0;
                                break;
                            }
                        }
                    }

                    break;
                }
            }
        }

        private static void DrawEllipseNode(Graphics cizim, Node node)
        {
            if (node.id == 0)
            {
                cizim.FillEllipse(new SolidBrush(Color.Orange), node.X, node.Y, 30, 30);
            }
            else
            {
                cizim.FillEllipse(new SolidBrush(Color.Red), node.X, node.Y, 30, 30);
            }

            cizim.DrawEllipse(new Pen(Color.Green, 3), node.X, node.Y, 30, 30);

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                cizim.DrawString(node.id.ToString(), new Font("Verdana", 12),
                    Brushes.AliceBlue, node.X + 15,
                    node.Y + 15, sf);
            }
        }
    }
}