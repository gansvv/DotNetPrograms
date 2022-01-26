using System;
using System.Collections.Generic;

namespace DotNetPrograms
{
    // This class represents a directed graph using adjacency
    // list representation
    public class DFSIterative
    {
        public int V; // Number of Vertices

        public LinkedList<int>[] adj; // adjacency lists

        // Constructor
        public DFSIterative(int V)
        {
            this.V = V;
            adj = new LinkedList<int>[V];

            for (int i = 0; i < adj.Length; i++)
                adj[i] = new LinkedList<int>();

        }

        // To add an edge to graph
        public void AddEdge(int v, int w)
        {
            adj[v].AddLast(w); // Add w to v’s list.
        }

        // prints all not yet visited vertices reachable from s
        public void DFS(int s)
        {
            // Initially mark all vertices as not visited
            Boolean[] visited = new Boolean[V];

            // Create a stack for DFS
            Stack<int> stack = new Stack<int>();

            // Push the current source node
            stack.Push(s);

            while (stack.Count > 0)
            {
                // Pop a vertex from stack and print it
                s = stack.Peek();
                stack.Pop();

                // Stack may contain same vertex twice. So
                // we need to print the popped item only
                // if it is not visited.
                if (visited[s] == false)
                {
                    Console.Write(s + " ");
                    visited[s] = true;
                }

                // Get all adjacent vertices of the popped vertex s
                // If a adjacent has not been visited, then push it
                // to the stack.
                foreach (int v in adj[s])
                {
                    if (!visited[v])
                        stack.Push(v);
                }

            }
        }

        // Driver code
        public static void Run()
        {
            // Total 5 vertices in graph
            DFSIterative g = new DFSIterative(5);

            g.AddEdge(1, 0);
            g.AddEdge(0, 2);
            g.AddEdge(2, 1);
            g.AddEdge(0, 3);
            g.AddEdge(1, 4);

            Console.Write("Following is the Depth First Traversal\n");
            g.DFS(0);
        }

        /*
         * Time complexity: O(V + E), where V is the number of vertices and E is the number of edges in the graph.
         * Space Complexity: O(V). Since an extra visited array is needed of size V.
         */
    }
}
