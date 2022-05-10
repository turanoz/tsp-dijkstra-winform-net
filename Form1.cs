using Microsoft.VisualBasic;

namespace GezginSaticiProblemi;

public partial class Form1 : Form
{
   
    public Form1()
    {
        InitializeComponent();
    }

    private List<Node> Nodes = new();
    private List<Path> Paths = new();
    private bool baslangic = false;

    private bool durak = false;

    private bool uzaklik = false;
    private int counter = 0;
    private int firstNodeId = 0;

    Label weightLabel = new Label();


    private void panel1_MouseClick(object sender, MouseEventArgs e)
    {
        Label weightLabel = new Label();
        weightLabel.Width = 20;
        weightLabel.Height = 20;
        var g_0 = panel1.CreateGraphics();

        if (baslangic)
        {
            Brush orangeBrush = new SolidBrush(Color.Orange);
            g_0.FillEllipse(orangeBrush, e.X - 15, e.Y - 15, 30, 30);
            Nodes.Add(new Node()
            {
                id = 0,
                X = e.X - 15,
                Y = e.Y - 15
            });

            baslangic = false;
            durakEkleToolStripMenuItem.Visible = true;
        }
        else if (durak)
        {
            var isNodes = Nodes.Where(x => Math.Abs(x.X - e.X) < 61 && Math.Abs(x.Y - e.Y) < 61).ToList();
            if (isNodes.Any())
            {
                MessageBox.Show("Daha uzak bir yeri iþaretleyin");
            }
            else
            {
                Brush redBrush = new SolidBrush(Color.Red);
                g_0.FillEllipse(redBrush, e.X - 15, e.Y - 15, 30, 30);
                Nodes.Add(new Node()
                {
                    id = Nodes.Count + 1,
                    X = e.X - 15,
                    Y = e.Y - 15
                });
            }
        }
        else if (uzaklik)
        {
            var node = Nodes.FirstOrDefault(x => Math.Abs(x.X - e.X) < 61 && Math.Abs(x.Y - e.Y) < 61);
            var greenPen = new Pen(Color.Green);
            greenPen.Width = 3;
            
            if (node != null)
                switch (counter)
                {
                    case 0:
                        g_0.DrawEllipse(greenPen, node.X, node.Y, 30, 30);
                        firstNodeId = node.id;
                        counter++;
                        break;
                    case 1:
                        if (firstNodeId == node.id)
                        {
                            MessageBox.Show("Konumlar ayný olamaz!");
                            counter = 0;
                            break;
                        }

                        var path = Paths.FirstOrDefault(x =>
                            x.firstNodeId == firstNodeId && x.secondNodeId == node.id ||
                            x.firstNodeId == node.id && x.secondNodeId == firstNodeId);


                        if (path != null)
                        {
                            MessageBox.Show("Daha önce iki konumu iþaretlediniz!");
                            counter = 0;
                            break;
                        }
                        else
                        {
                            g_0.DrawEllipse(greenPen, node.X, node.Y, 30, 30);
                            Pen blackPen = new Pen(Color.Black, 3);
                            var weigths = Interaction.InputBox("Lütfen iki durak arasýndaki mesafeyi giriniz.",
                                "Uzaklýk Deðeri", "-1");

                            var pointNode1 = Nodes.FirstOrDefault(x => x.id == firstNodeId);
                            Point point1 = new Point(pointNode1.X + 15, pointNode1.Y + 15);
                            Point point2 = new Point(node.X + 15, node.Y + 15);
                            
                            
                            g_0.DrawLine(blackPen, point1, point2);

                            Paths.Add(
                                new Path()
                                {
                                    firstNodeId = firstNodeId,
                                    secondNodeId = node.id,
                                    weights = Convert.ToInt32(weigths)
                                });
                            counter = 0;

                            weightLabel.Text = weigths;
                            weightLabel.Location = new Point(((pointNode1.X + node.X) / 2 + 10),
                                ((pointNode1.Y + node.Y) / 2 + 10));
                            weightLabel.Name = "label" + firstNodeId + node.X.ToString();
                            panel1.Controls.Add(weightLabel);
                            break;
                        }

                        break;
                    default:
                        break;
                }
            else
                MessageBox.Show("Ayný nokta");
        }
        else if (e.Button != MouseButtons.Right)
        {
            MessageBox.Show("Lütfen Sað Click ile yapmak istediðiniz iþlemi seçiniz !", "Uyarý!");
        }
    }

    private void baslangicnoktasibelirle_Click(object sender, EventArgs e)
    {
        baslangic = true;
        baslangicnoktasibelirle.Visible = false;
    }

    private void durakEkleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        durak = true;
        durakEkleToolStripMenuItem.Visible = false;
        durakeklemeyibitir.Visible = true;
    }

    private void uzaklýkEkleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        uzaklik = true;
    }

    private void durakeklemeyibitir_Click(object sender, EventArgs e)
    {
        durak = false;
        durakeklemeyibitir.Visible = false;
        uzaklýkEkleToolStripMenuItem.Visible = true;
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        weightLabel.Width = 20;
        weightLabel.Height = 20;
        panel1.Controls.Add(weightLabel);
    }
}