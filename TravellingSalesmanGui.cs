using Microsoft.VisualBasic;
using System.Drawing.Drawing2D;
using TSP.Models;

namespace TSP
{
    public partial class TravellingSalesmanGui : Form
    {
        private Bitmap _bmp;
        private Graphics _drawing;
        private int _menu = -1;
        private int _counter;
        private int _firstNodeId;

        private readonly IDijkstraSolver _solver = new DijkstraSolver();

        public TravellingSalesmanGui()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void ThreadCalculate()
        {
            _solver.CalculateDijkstraPath();
            foreach (var t in _solver.Animation)
            {
                var costAnimation = new Bitmap(_bmp);
                _drawing = Graphics.FromImage(costAnimation);
                _drawing.SmoothingMode = SmoothingMode.HighQuality;
                map.Image = costAnimation;
                map.Refresh();

                var start = _solver.Nodes.First(p => p.Id == t.Key);
                var finish = _solver.Nodes.First(p => p.Id == t.Value);
                var costPen = new Pen(Color.LightGray, 5);
                var pt1 = new Point(start.X + 15, start.Y + 15);
                var pt2 = new Point(finish.X + 15, finish.Y + 15);
                costPen.StartCap = LineCap.Round;
                costPen.EndCap = LineCap.ArrowAnchor;
                costPen.DashStyle = DashStyle.Dot;
                _drawing.DrawLine(costPen, pt1, pt2);
                map.Refresh();
                costAnimation.Dispose();
                Thread.Sleep(200);
            }

            _drawing = Graphics.FromImage(_bmp);
            map.Image = _bmp;
            map.Refresh();

            var path = _solver.Path;

            var pathNodes = path.Split(" ");

            richTextBox1.Text = "";

            var pathAnimation = new Bitmap(_bmp);
            _drawing = Graphics.FromImage(pathAnimation);
            map.Image = pathAnimation;
            map.Refresh();

            var drawnPath = new HashSet<Tuple<int, int>>();

            for (var i = 0; i < pathNodes.Length; i++)
            {
                if (i < pathNodes.Length - 1)
                {
                    var color = Color.Orange;
                    if (drawnPath.Contains(new Tuple<int, int>(int.Parse(pathNodes[i]),
                            int.Parse(pathNodes[i + 1]))))
                    {
                        color = Color.Blue;
                    }

                    var start = _solver.Nodes.First(p => p.Id == int.Parse(pathNodes[i]));
                    var finish = _solver.Nodes.First(p => p.Id == int.Parse(pathNodes[i + 1]));
                    drawnPath.Add(new Tuple<int, int>(int.Parse(pathNodes[i]), int.Parse(pathNodes[i + 1])));
                    drawnPath.Add(new Tuple<int, int>(int.Parse(pathNodes[i + 1]), int.Parse(pathNodes[i])));


                    var cadetBluePen = new Pen(color, 5);
                    var pt1 = new Point(start.X + 15, start.Y + 15);
                    var pt2 = new Point(finish.X + 15, finish.Y + 15);
                    cadetBluePen.StartCap = LineCap.Round;
                    cadetBluePen.EndCap = LineCap.ArrowAnchor;
                    cadetBluePen.DashStyle = DashStyle.DashDotDot;
                    _drawing.DrawLine(cadetBluePen, pt1, pt2);
                    richTextBox1.Text += pathNodes[i] + @"->";

                    map.Refresh();
                }
                else
                {
                    richTextBox1.Text += pathNodes[i];
                }

                Thread.Sleep(1500);
            }


            richTextBox1.Text += $@" Total Distance: {_solver.Cost}";
        }

        private void btnAddStartLocation_Click(object sender, EventArgs e)
        {
            btnAddStartLocation.Enabled = false;
            _menu = 0;
            _bmp = new Bitmap(map.Width, map.Height);
            _drawing = Graphics.FromImage(_bmp);
            _drawing.SmoothingMode = SmoothingMode.HighQuality;
            map.Image = _bmp;
            map.Refresh();
            btnClear.Enabled = true;
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            btnAddLocation.Visible = false;
            btnAddLocation.Enabled = false;
            btnSaveLocation.Visible = true;
            _menu = 1;
        }

        private void btnAddPath_Click(object sender, EventArgs e)
        {
            _menu = 2;
            btnAddPath.Visible = false;
            btnSavePath.Visible = true;
            btnCalculate.Enabled = false;
            richTextBox1.Text = "";
            _drawing = Graphics.FromImage(_bmp);
            _drawing.SmoothingMode = SmoothingMode.HighQuality;
            map.Image = _bmp;
            map.Refresh();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            var th = new Thread(ThreadCalculate);
            th.Start();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            map.Refresh();
            _drawing.Clear(default);
            btnAddStartLocation.Enabled = true;
            btnAddLocation.Enabled = false;
            btnAddLocation.Visible = true;
            btnSaveLocation.Visible = false;
            btnAddPath.Enabled = false;
            btnAddPath.Visible = true;
            btnSavePath.Visible = false;
            btnCalculate.Enabled = false;
            richTextBox1.Text = "";
            _solver.Nodes.Clear();
            _solver.Nodes.Clear();
        }

        private void btnSaveLocation_Click(object sender, EventArgs e)
        {
            _menu = -1;
            btnSaveLocation.Visible = false;
            btnAddLocation.Visible = true;
            btnAddPath.Enabled = true;
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            var hashSet = _solver.GetAllNodeIdsInPaths();

            if (hashSet.Count != _solver.Nodes.Count)
            {
                MessageBox.Show(
                    @"There is a location that you did not add path to it. Please add path to all locations.");
            }
            else
            {
                _menu = -1;
                btnAddPath.Visible = true;
                btnSavePath.Visible = false;
                btnCalculate.Enabled = true;
            }
        }

        private void map_MouseClick(object sender, MouseEventArgs e)
        {
            switch (_menu)
            {
                case 0:
                    AddNode(e.X, e.Y, Color.Orange, "0");
                    _solver.Nodes.Add(new NodeModel()
                    {
                        Id = 0,
                        X = e.X - 15,
                        Y = e.Y - 15
                    });
                    _menu = -1;
                    btnAddLocation.Enabled = true;
                    map.Refresh();
                    break;
                case 1:
                    AddNodeIfNotNearby(e.X, e.Y);
                    map.Refresh();
                    break;
                case 2:
                    var currentPath =
                        _solver.Paths.FirstOrDefault(p => Math.Abs(p.X - e.X) < 31 && Math.Abs(p.Y - e.Y) < 31);
                    if (currentPath != null)
                    {
                        UpdatePathWeight(currentPath);
                        map.Refresh();
                    }
                    else
                    {
                        var node = _solver.Nodes.FirstOrDefault(x =>
                            Math.Abs(x.X - e.X) < 61 && Math.Abs(x.Y - e.Y) < 61);
                        if (node == null)
                        {
                            MessageBox.Show(@"Please select a node !");
                        }
                        else
                        {
                            HandleNodeSelection(node);
                            map.Refresh();
                        }
                    }

                    break;
            }
        }

        private void AddNode(int x, int y, Color color, string label)
        {
            var brush = new SolidBrush(color);
            _drawing.FillEllipse(brush, x - 15, y - 15, 30, 30);

            using var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            _drawing.DrawString(label, new Font("Verdana", 12), Brushes.AliceBlue, x, y, sf);
        }

        private void AddNodeIfNotNearby(int x, int y)
        {
            var isNodes = _solver.Nodes.Where(n => Math.Abs(n.X - x) < 61 && Math.Abs(n.Y - y) < 61).ToList();
            if (!isNodes.Any())
            {
                AddNode(x, y, Color.Red, _solver.Nodes.Count.ToString());
                _solver.Nodes.Add(new NodeModel()
                {
                    Id = _solver.Nodes.Count,
                    X = x - 15,
                    Y = y - 15
                });
            }
            else
            {
                MessageBox.Show(@"Please select a location that is further away.");
            }
        }

        private void UpdatePathWeight(PathModel path)
        {
            var weight = Interaction.InputBox("Please enter the path between two nodes.", "Path Value",
                path.Weight.ToString());
            if (weight != "")
            {
                path.Weight = Convert.ToInt32(weight);
            }

            var drawFont = new Font("Verdana", 12);
            var drawBrush = new SolidBrush(Color.Black);
            var width = 30;
            var height = 30;
            var drawRect = new RectangleF(path.X - 15f, path.Y - 15f, width, height);
            _drawing.FillRectangle(drawBrush, path.X - 15f, path.Y - 15f, width, height);
            var drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            _drawing.DrawString(weight, drawFont, Brushes.AliceBlue, drawRect, drawFormat);
            map.Refresh();
        }

        private void HandleNodeSelection(NodeModel node)
        {
            switch (_counter)
            {
                case 0:
                    AddNode(node.X + 15, node.Y + 15, Color.Green, "");
                    _firstNodeId = node.Id;
                    _counter++;
                    break;
                case 1:
                    if (_firstNodeId == node.Id)
                    {
                        MessageBox.Show(@"Locations cannot be the same!");
                        _counter = 0;
                        break;
                    }

                    var path = _solver.Paths.FirstOrDefault(p =>
                        (p.FirstNodeId == _firstNodeId && p.SecondNodeId == node.Id) ||
                        (p.FirstNodeId == node.Id && p.SecondNodeId == _firstNodeId));
                    if (path == null)
                    {
                        AddPath(_firstNodeId, node.Id);
                        _counter = 0;
                    }
                    else
                    {
                        MessageBox.Show(@"You have already marked two locations!");
                        _counter = 0;
                    }

                    break;
            }
        }

        private void AddPath(int firstNodeId, int secondNodeId)
        {
            var random = new Random();
            var randomNumber = random.Next(1, 15);
            var blackPen = new Pen(Color.Black, 3);
            var weight = Interaction.InputBox("Please enter the path between two nodes.", "Path Value",
                randomNumber.ToString());
            if (weight == "")
            {
                _counter = 0;
                var first = _solver.Nodes.First(x => x.Id == _firstNodeId);
                AddNode(first.X + 15, first.Y + 15, first.Id == 0 ? Color.Orange : Color.Red, first.Id.ToString());
                map.Refresh();
                return;
            }

            var node1 = _solver.Nodes.First(x => x.Id == firstNodeId);
            var node2 = _solver.Nodes.First(x => x.Id == secondNodeId);
            var pt1 = new Point(node1.X + 15, node1.Y + 15);
            var pt2 = new Point(node2.X + 15, node2.Y + 15);
            var ptMed = new Point((pt1.X + pt2.X) / 2, (pt1.Y + pt2.Y) / 2);
            _drawing.DrawLine(blackPen, pt1, pt2);
            AddNode(ptMed.X, ptMed.Y, Color.Black, weight);
            DrawEllipseNode(node1);
            DrawEllipseNode(node2);
            _solver.Paths.Add(new PathModel()
            {
                Id = _solver.Paths.Count,
                FirstNodeId = firstNodeId,
                SecondNodeId = secondNodeId,
                X = ptMed.X,
                Y = ptMed.Y,
                Weight = Convert.ToInt32(weight)
            });
        }

        private void DrawEllipseNode(NodeModel nodeModel)
        {
            var color = nodeModel.Id == 0 ? Color.Orange : Color.Red;
            var brush = new SolidBrush(color);
            _drawing.FillEllipse(brush, nodeModel.X, nodeModel.Y, 30, 30);
            _drawing.DrawEllipse(new Pen(Color.Green, 3), nodeModel.X, nodeModel.Y, 30, 30);
            using var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            _drawing.DrawString(nodeModel.Id.ToString(), new Font("Verdana", 12), Brushes.AliceBlue, nodeModel.X + 15,
                nodeModel.Y + 15, sf);
        }
    }
}