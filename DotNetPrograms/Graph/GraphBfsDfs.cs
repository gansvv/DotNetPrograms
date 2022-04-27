using System;
using System.Collections.Generic;

namespace DotNetPrograms.Graph
{
    class GraphBfsDfs
    {
        // ref: https://masterdotnet.com/csharp/ds/graphincsharp/

        public static void BFS(int[,] edges, int v, bool[] visited, int si)
        {

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(si);
            visited[si] = true;
            while (queue.Count != 0)
            {
                int currentVertex = queue.Dequeue();
                Console.Write(currentVertex + " ");
                for (int i = 0; i < v; i++)
                {
                    if (i == currentVertex)
                        continue;
                    if (!visited[i] && edges[currentVertex, i] == 1)
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }

            }
        }

        public static void DFS(int[,] edges, int v, bool[] visited, int si)
        {
            visited[si] = true;
            Console.Write(si + " ");

            for (int i = 0; i < v; i++)
            {
                if (i == si)
                    continue;
                if (!visited[i] && edges[si, i] == 1)
                {
                    DFS(edges, v, visited, i);
                }
            }
        }

        public static void Main(string[] args)
        {
            int v, e;

            Console.WriteLine("Enter Number of vertices");
            int.TryParse(Console.ReadLine(), out v);

            Console.WriteLine("Enter Number of edges");
            int.TryParse(Console.ReadLine(), out e);

            int[] vertices = new int[v];
            int[,] edges = new int[v, v];
            bool[] visited = new bool[v];

            Console.WriteLine("Enter Edges");
            for (int i = 0; i < e; i++)
            {
                int s, d;
                string[] input = Console.ReadLine().Split(' ');
                int.TryParse(input[0], out s);
                int.TryParse(input[1], out d);
                edges[s, d] = 1;
                edges[d, s] = 1;

            }

            Console.WriteLine("DFS");
            //for loop to handle disconnected Graph
            for (int i = 0; i < v; i++)
            {
                if (!visited[i])
                    DFS(edges, v, visited, i);
            }


            for (int i = 0; i < v; i++)
            {
                visited[i] = false;
            }

            Console.WriteLine();
            Console.WriteLine("BFS");
            //for loop to handle disconnected Graph
            for (int i = 0; i < v; i++)
            {
                if (!visited[i])
                    BFS(edges, v, visited, i);
            }
        }
    }
}
