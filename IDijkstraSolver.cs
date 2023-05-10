using TSP.Models;

namespace TSP
{
    internal interface IDijkstraSolver
    {
        public int Cost { get; }
        public string Path { get; }
        public int[,] Graph { get; }
        public List<KeyValuePair<int, int>> Animation { get; }
        public List<NodeModel> Nodes { get; }
        public List<PathModel> Paths { get; }
        public int[,] CreateAdjacencyMatrixFromNodesAndPaths();
        public HashSet<int> GetAllNodeIdsInPaths();
        public void CalculateDijkstraPath();
    }
}