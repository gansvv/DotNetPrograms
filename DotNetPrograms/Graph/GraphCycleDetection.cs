using System;
using System.Collections.Generic;

namespace DotNetPrograms
{
    class GraphCycleDetection
    {
        private readonly int V;
        private readonly List<List<int>> adj;

        public GraphCycleDetection(int V)
        {
            this.V = V;
            adj = new List<List<int>>(V);

            for (int i = 0; i < V; i++)
                adj.Add(new List<int>());
        }

        // This function is a variation of DFSUtil() in
        // https://www.geeksforgeeks.org/archives/18212
        private bool IsCyclicUtil(int i, bool[] visited, bool[] recStack)
        {

            // Mark the current node as visited and
            // part of recursion stack
            if (recStack[i])
                return true;

            if (visited[i])
                return false;

            visited[i] = true;

            recStack[i] = true;
            List<int> children = adj[i];

            foreach (int c in children)
                if (IsCyclicUtil(c, visited, recStack))
                    return true;

            recStack[i] = false;

            return false;
        }

        private void AddEdge(int sou, int dest)
        {
            adj[sou].Add(dest);
        }

        // Returns true if the graph contains a
        // cycle, else false.
        private bool IsCyclic()
        {

            // Mark all the vertices as not visited and
            // not part of recursion stack
            bool[] visited = new bool[V];
            bool[] recStack = new bool[V];


            // Call the recursive helper function to
            // detect cycle in different DFS trees
            for (int i = 0; i < V; i++)
                if (IsCyclicUtil(i, visited, recStack))
                    return true;

            return false;
        }

        // Driver code
        public static void Run()
        {
            GraphCycleDetection graph = new (4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);

            if (graph.IsCyclic())
                Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine("Graph doesn't "
                                        + "contain cycle");
        }
    }
}
