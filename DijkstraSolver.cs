using System.Text;
using TSP.Models;

namespace TSP
{
    internal class DijkstraSolver : IDijkstraSolver
    {
        private const int MaxNode = 20;
        public int Cost { get; private set; }
        public string Path { get; private set; }
        public int[,] Graph { get; private set; }
        public List<KeyValuePair<int, int>> Animation { get; private set; }

        public List<NodeModel> Nodes { get; private set; } = new();
        public List<PathModel> Paths { get; private set; } = new();


        public int[,] CreateAdjacencyMatrixFromNodesAndPaths()
        {
            var matrix = new int[Nodes.Count, Nodes.Count];

            for (var i = 0; i < Nodes.Count; i++)
            {
                for (var j = 0; j < Nodes.Count; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            foreach (var t in Paths)
            {
                matrix[t.FirstNodeId, t.SecondNodeId] = t.Weight;
                matrix[t.SecondNodeId, t.FirstNodeId] = t.Weight;
            }

            return matrix;
        }

        public HashSet<int> GetAllNodeIdsInPaths()
        {
            var set = new HashSet<int>();
            foreach (var t in Paths)
            {
                set.Add(t.FirstNodeId);
                set.Add(t.SecondNodeId);
            }

            return set;
        }

        public void CalculateDijkstraPath()
        {
            Graph = CreateAdjacencyMatrixFromNodesAndPaths();
            Animation = new List<KeyValuePair<int, int>>();
            var costs = new int[MaxNode, 1 << MaxNode];
            var pq = new PriorityQueue<int[], int>();
            var previousState = new int[MaxNode, 1 << MaxNode, 2];

            for (var i = 0; i < MaxNode; i++)
            {
                for (var j = 0; j < 1 << MaxNode; j++)
                {
                    costs[i, j] = int.MaxValue;
                    previousState[i, j, 0] = -1;
                    previousState[i, j, 1] = -1;
                }
            }

            costs[0, 1] = 0;
            pq.Enqueue(new[] { 0, 1 }, 0);

            while (pq.Count != 0)
            {
                var current = pq.Peek();
                pq.Dequeue();

                for (var i = 0; i < Nodes.Count; i++)
                {
                    if (Graph[current[0], i] == 0) continue;

                    var cost = Graph[current[0], i] + costs[current[0], current[1]];

                    if (costs[i, current[1] | 1 << i] <= cost) continue;

                    var nextState = new[] { i, current[1] | 1 << i };
                    pq.Enqueue(nextState, -1 * cost);
                    costs[i, nextState[1]] = cost;
                    previousState[i, nextState[1], 0] = current[0];
                    previousState[i, nextState[1], 1] = current[1];
                    Animation.Add(new KeyValuePair<int, int>(current[0], i));
                }
            }

            var cur = 0;
            var lastMask = (1 << Nodes.Count) - 1;
            var pathBuilder = new StringBuilder(cur.ToString());

            while (previousState[cur, lastMask, 0] != -1)
            {
                var temp = lastMask;
                lastMask = previousState[cur, lastMask, 1];
                cur = previousState[cur, temp, 0];
                pathBuilder.Append(" ").Append(cur);
            }

            Path = pathBuilder.ToString();
            Cost = costs[0, (1 << Nodes.Count) - 1];
        }
    }
}