using System;
using System.Collections.Generic;

namespace DotNetPrograms.Tree.VerticalOrder
{
    // Tree node
    public class Node
    {
        public int key;
        public Node left;
        public Node right;

        // Constructor
        public Node(int data)
        {
            key = data;
            left = null;
            right = null;
        }
    }

    // C# program for printing vertical order of a given binary tree
    public class VerticalOrder
    {
    // Utility function to store vertical order in map 'm'
    // 'hd' is horizontal distance of current node from root.
    // 'hd' is initially passed as 0
    static void getVerticalOrder(Node root, int hd, SortedDictionary<int, List<int>> m)
    {
        // Base case
        if (root == null)
            return;

        // get the vector list at 'hd'
        List<int> get = new List<int>();//m[hd];
        if (m.ContainsKey(hd))
            get.AddRange(m[hd]);

        // Store current node in map 'm'
        if (get == null)
        {
            get = new List<int>();
            get.Add(root.key);
        }
        else
            get.Add(root.key);

        m[hd] = get;

        // Store nodes in left subtree
        getVerticalOrder(root.left, hd - 1, m);

        // Store nodes in right subtree
        getVerticalOrder(root.right, hd + 1, m);
    }

    // The main function to print vertical order of a binary tree
    // with the given root
    static void printVerticalOrder(Node root)
    {

        // Create a map and store vertical order in map using
        // function getVerticalOrder()
        SortedDictionary<int, List<int>> m = new SortedDictionary<int, List<int>>();
        int hd = 0;
        getVerticalOrder(root, hd, m);

        // Traverse the map and print nodes at every horizontal
        // distance (hd)
        foreach (KeyValuePair<int, List<int>> entry in m)
        {
            foreach (int v in entry.Value)
                Console.Write(v + " ");
            Console.WriteLine();
        }
    }

    // Driver program to test above functions
    public static void Main(String[] args)
    {

        // TO DO Auto-generated method stub
        Node root = new Node(1);
        root.left = new Node(2);
        root.right = new Node(3);
        root.left.left = new Node(4);
        root.left.right = new Node(5);
        root.right.left = new Node(6);
        root.right.right = new Node(7);
        root.right.left.right = new Node(8);
        root.right.right.right = new Node(9);
        Console.WriteLine("Vertical Order traversal is");
        printVerticalOrder(root);
    }
}
}
