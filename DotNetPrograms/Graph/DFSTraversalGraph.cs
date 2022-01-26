using System;
using System.Collections.Generic;

namespace DotNetPrograms
{
    /**
     * This class represents a directed graph
     * using adjacency list representation
     * Algorithm: 
     *      Create a recursive function that takes the index of the node and a visited array.
     *       1. Mark the current node as visited and print the node.
     *       2. Traverse all the adjacent and unmarked nodes and call the recursive function with the index of the adjacent node.
     */
    class DFSTraversalGraph
    {
        
        private int V; // No. of vertices

        // Array of lists for
        // Adjacency List Representation
        private List<int>[] adj;

        // Constructor
        DFSTraversalGraph(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }

        // Function to Add an edge into the graph
        void AddEdge(int v, int w)
        {
            adj[v].Add(w); // Add w to v's list.
        }

        // A function used by DFS
        void DFSUtil(int v, bool[] visited)
        {
            // Mark the current node as visited
            // and print it
            visited[v] = true;
            Console.Write(v + " ");

            // Recur for all the vertices
            // adjacent to this vertex
            List<int> vList = adj[v];
            foreach (var n in vList)
            {
                if (!visited[n])
                    DFSUtil(n, visited);
            }
        }

        // The function to do DFS traversal.
        // It uses recursive DFSUtil()
        void DFS(int v)
        {
            // Mark all the vertices as not visited
            // (set as false by default in c#)
            bool[] visited = new bool[V];

            // Call the recursive helper function
            // to print DFS traversal
            DFSUtil(v, visited);
        }

        // Driver Code
        public static void Run()
        {
            DFSTraversalGraph g = new DFSTraversalGraph(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine(
                "Following is Depth First Traversal (starting from vertex 2)");
            g.DFS(2);
            Console.ReadKey();
        }
        /*
         * Time complexity: O(V + E), where V is the number of vertices and E is the number of edges in the graph. 
         * Space Complexity: O(V), since an extra visited array of size V is required. 
         */
    }
}
