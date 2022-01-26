using System;

namespace DotNetPrograms.Tree
{
    // Program to construct a BST from its level order traversal
    class ConstructBstFromLevelOrderTraversal
    {
        // node of a BST
        public class Node
        {
            public int data;
            public Node left, right;
        };

        // function to get a new node
        static Node GetNode(int data)
        {
            // Allocate memory
            Node newNode = new Node();

            // put in the data
            newNode.data = data;
            newNode.left = newNode.right = null;
            return newNode;
        }

        // function to construct a BST from
        // its level order traversal
        static Node LevelOrder(Node root,
                               int data)
        {
            if (root == null)
            {
                root = GetNode(data);
                return root;
            }

            if (data <= root.data)
                root.left = LevelOrder(root.left, data);
            else
                root.right = LevelOrder(root.right, data);
            return root;
        }

        static Node ConstructBst(int[] arr, int n)
        {
            if (n == 0) return null;
            Node root = null;

            for (int i = 0; i < n; i++)
                root = LevelOrder(root, arr[i]);

            return root;
        }

        // function to print the inorder traversal
        static void InorderTraversal(Node root)
        {
            if (root == null)
                return;

            InorderTraversal(root.left);
            Console.Write(root.data + " ");
            InorderTraversal(root.right);
        }

        // Driver code
        public static void Run()
        {
            int[] arr = {7, 4, 12, 3,
                 6, 8, 1, 5, 10};
            int n = arr.Length;

            Node root = ConstructBst(arr, n);

            Console.Write("Inorder Traversal: ");
            InorderTraversal(root);
        }
    }
}
