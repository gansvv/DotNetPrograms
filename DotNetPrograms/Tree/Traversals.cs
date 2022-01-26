using System;

namespace DotNetPrograms.Tree
{
    // Program showing different tree traversals.
    class Traversals
    {
        class Node
        {
            public int key;
            public Node left, right;

            public Node(int item)
            {
                key = item;
                left = right = null;
            }
        }

        // Root of Binary Tree
        Node root;

        Traversals() { root = null; }

        /* Given a binary tree, print
           its nodes according to the
           "bottom-up" postorder traversal. */
        void PrintPostorder(Node node)
        {
            if (node == null)
                return;

            // first recur on left subtree
            PrintPostorder(node.left);

            // then recur on right subtree
            PrintPostorder(node.right);

            // now deal with the node
            Console.Write(node.key + " ");
        }

        /* Given a binary tree, print
           its nodes in inorder*/
        void PrintInorder(Node node)
        {
            if (node == null)
                return;

            /* first recur on left child */
            PrintInorder(node.left);

            /* then print the data of node */
            Console.Write(node.key + " ");

            /* now recur on right child */
            PrintInorder(node.right);
        }

        /* Given a binary tree, print
           its nodes in preorder*/
        void PrintPreorder(Node node)
        {
            if (node == null)
                return;

            /* first print data of node */
            Console.Write(node.key + " ");

            /* then recur on left subtree */
            PrintPreorder(node.left);

            /* now recur on right subtree */
            PrintPreorder(node.right);
        }

        // Wrappers over above recursive functions
        void PrintPostorder() { PrintPostorder(root); }
        void PrintInorder() { PrintInorder(root); }
        void PrintPreorder() { PrintPreorder(root); }

        /* Compute the "height" of a tree --
        the number of nodes along the longest
        path from the root node down to the
        farthest leaf node.*/
        int Height(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                /* compute height of each subtree */
                int lheight = Height(root.left);
                int rheight = Height(root.right);

                /* use the larger one */
                if (lheight > rheight)
                {
                    return (lheight + 1);
                }
                else
                {
                    return (rheight + 1);
                }
            }
        }

        /* function to print level order traversal of tree*/
        void PrintLevelOrder()
        {
            int h = Height(root);
            int i;
            for (i = 1; i <= h; i++)
            {
                PrintCurrentLevel(root, i);
            }
        }

        /* Print nodes at the current level */
        void PrintCurrentLevel(Node root, int level)
        {
            if (root == null)
            {
                return;
            }
            if (level == 1)
            {
                Console.Write(root.key + " ");
            }
            else if (level > 1)
            {
                PrintCurrentLevel(root.left, level - 1);
                PrintCurrentLevel(root.right, level - 1);
            }
        }

        // Driver Code
        static public void Run()
        {
            Traversals tree = new Traversals();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            Console.WriteLine("Preorder traversal of binary tree is ");
            tree.PrintPreorder();

            Console.WriteLine("\nInorder traversal of binary tree is ");
            tree.PrintInorder();

            Console.WriteLine("\nPostorder traversal of binary tree is ");
            tree.PrintPostorder();

            /*       1
             *      / \
             *     2   3
             *    / \ 
             *   4   5
             *   
             *   Tree Traversals:
             *       Preorder traversal of binary tree is
             *       1 2 4 5 3
             *       Inorder traversal of binary tree is
             *       4 2 5 1 3
             *       Postorder traversal of binary tree is
             *       4 5 2 3 1
             *       Level order traversal of binary tree is
             *       1 2 3 4 5
             */
            Console.WriteLine("\nLevel order traversal of binary tree is ");
            tree.PrintLevelOrder();
        }
    }
}
