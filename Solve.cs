using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    internal class Solve
    {

        private int N, start;
        private double[,] distance;
        private List<int> tour = new List<int>();
        private double minTourCost = Double.PositiveInfinity;
        private bool ranSolver = false;

        public Solve(double[,] distance) : this(0, distance)
        {
        }

        public Solve(int start, double[,] distance)
        {
            N = distance.GetLength(0);
            this.start = start;
            this.distance = distance;
        }

        // Returns the optimal tour for the traveling salesman problem.
        public List<int> getTour()
        {
            if (!ranSolver) solve();
            return tour;
        }

        // Returns the minimal tour cost.
        public double getTourCost()
        {
            if (!ranSolver) solve();
            return minTourCost;
        }

        // Solves the traveling salesman problem and caches solution.
        public void solve()
        {
            if (ranSolver) return;

            int END_STATE = (1 << N) - 1;
            Double[,] memo = new Double[N, 1 << N];

            // Add all outgoing edges from the starting node to memo table.
            for (int end = 0; end < N; end++)
            {
                if (end == start) continue;
                memo[end, (1 << start) | (1 << end)] = distance[start, end];
            }

            for (int r = 3; r <= N; r++)
            {
                foreach (int subset in combinations(r, N))
                {
                    if (notIn(start, subset)) continue;
                    for (int next = 0; next < N; next++)
                    {
                        if (next == start || notIn(next, subset)) continue;
                        int subsetWithoutNext = subset ^ (1 << next);
                        double minDist = Double.PositiveInfinity;
                        for (int end = 0; end < N; end++)
                        {
                            if (end == start || end == next || notIn(end, subset)) continue;
                            double newDistance = memo[end, subsetWithoutNext] + distance[end, next];
                            if (newDistance < minDist)
                            {
                                minDist = newDistance;
                            }
                        }

                        memo[next, subset] = minDist;
                    }
                }
            }

            // Connect tour back to starting node and minimize cost.
            for (int i = 0; i < N; i++)
            {
                if (i == start) continue;
                double tourCost = memo[i, END_STATE] + distance[i, start];
                if (tourCost < minTourCost)
                {
                    minTourCost = tourCost;
                }
            }

            int lastIndex = start;
            int state = END_STATE;
            tour.Add(start);

            // Reconstruct TSP path from memo table.
            for (int i = 1; i < N; i++)
            {
                int index = -1;
                for (int j = 0; j < N; j++)
                {
                    if (j == start || notIn(j, state)) continue;
                    if (index == -1) index = j;
                    double prevDist = memo[index, state] + distance[index, lastIndex];
                    double newDist = memo[j, state] + distance[j, lastIndex];
                    if (newDist < prevDist)
                    {
                        index = j;
                    }
                }

                tour.Add(index);
                state = state ^ (1 << index);
                lastIndex = index;
            }

            tour.Add(start);
            tour.Reverse();

            ranSolver = true;
        }

        private static bool notIn(int elem, int subset)
        {
            return ((1 << elem) & subset) == 0;
        }

        // This method generates all bit sets of size n where r bits 
        // are set to one. The result is returned as a list of integer masks.
        public static List<int> combinations(int r, int n)
        {
            List<int> subsets = new List<int>();
            combinations(0, 0, r, n, subsets);
            return subsets;
        }

        // To find all the combinations of size r we need to recurse until we have
        // selected r elements (aka r = 0), otherwise if r != 0 then we still need to select
        // an element which is found after the position of our last selected element
        private static void combinations(int set, int at, int r, int n, List<int> subsets)
        {
            // Return early if there are more elements left to select than what is available.
            int elementsLeftToPick = n - at;
            if (elementsLeftToPick < r) return;

            // We selected 'r' elements so we found a valid subset!
            if (r == 0)
            {
                subsets.Add(set);
            }
            else
            {
                for (int i = at; i < n; i++)
                {
                    // Try including this element
                    set |= 1 << i;

                    combinations(set, i + 1, r - 1, n, subsets);

                    // Backtrack and try the instance where we did not include this element
                    set &= ~(1 << i);
                }
            }
        }


    }
}
