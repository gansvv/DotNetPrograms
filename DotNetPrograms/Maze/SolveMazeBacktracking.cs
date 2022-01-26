using System;

namespace DotNetPrograms
{
    /*
     * The maze is given as N*N binary matrix of blocks where source block is the upper left most block i.e., maze[0][0] and destination block is lower rightmost block i.e., maze[N-1][N-1]. A user starts from source and has to reach the destination. The user can move only in two directions: forward and down. In the maze matrix, 0 means the block is a dead end and 1 means the block can be used in the path from source to destination.
     */
    class SolveMazeBacktracking
    {

        // Size of the maze
        static int N;

        // A utility function to print
        // solution matrix sol[N,N]
        static void PrintSolution(int[,] sol)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(" " + sol[i, j] + " ");

                Console.WriteLine();
            }
        }

        // A utility function to check if x, y
        // is valid index for N*N maze
        bool IsSafe(int[,] maze, int x, int y)
        {

            // If (x, y outside maze) return false
            return (x >= 0 && x < N && y >= 0 &&
                    y < N && maze[x, y] == 1);
        }

        // This function solves the Maze problem using
        // Backtracking. It mainly uses solveMazeUtil()
        // to solve the problem. It returns false if no
        // path is possible, otherwise return true and
        // prints the path in the form of 1s. Please note
        // that there may be more than one solutions, this
        // function prints one of the feasible solutions.
        bool SolveMaze(int[,] maze)
        {
            int[,] sol = new int[N, N];

            if (SolveMazeUtil(maze, 0, 0, sol) == false)
            {
                Console.Write("Solution doesn't exist");
                return false;
            }

            PrintSolution(sol);
            return true;
        }

        // A recursive utility function to solve Maze
        // problem
        bool SolveMazeUtil(int[,] maze, int x, int y, int[,] sol)
        {

            // If (x, y is goal) return true
            if (x == N - 1 && y == N - 1 &&
                maze[x, y] == 1)
            {
                sol[x, y] = 1;
                return true;
            }

            // Check if maze[x,y] is valid
            if (IsSafe(maze, x, y) == true)
            {
                // Check if the current block is already part of solution path.   
                if (sol[x, y] == 1)
                    return false;

                // Mark x, y as part of solution path
                sol[x, y] = 1;

                // Move forward in x direction
                if (SolveMazeUtil(maze, x + 1, y, sol))
                    return true;

                // If moving in x direction doesn't give
                // solution then Move down in y direction
                if (SolveMazeUtil(maze, x, y + 1, sol))
                    return true;

                // If moving in y direction doesn't give
                // solution then Move backward in x direction
                if (SolveMazeUtil(maze, x - 1, y, sol))
                    return true;

                // If moving in backwards in x direction doesn't give
                // solution then Move upwards in y direction
                if (SolveMazeUtil(maze, x, y - 1, sol))
                    return true;

                // If none of the above movements works then
                // BACKTRACK: unmark x, y as part of solution
                // path
                sol[x, y] = 0;
                return false;
            }
            return false;
        }

        // Driver Code
        public static void Run()
        {
            SolveMazeBacktracking rat = new ();

            int[,] maze = { { 1, 0, 0, 0 },
                    { 1, 1, 0, 1 },
                    { 0, 1, 0, 0 },
                    { 1, 1, 1, 1 } };

            N = maze.GetLength(0);
            rat.SolveMaze(maze);
        }
    }
}
