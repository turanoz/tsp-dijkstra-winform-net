namespace TSP.Models
{
    public class PathModel
    {
        public int Id { get; set; }
        public int FirstNodeId { get; set; }
        public int SecondNodeId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Weight { get; set; }
    }
}
