using System;

namespace DotNetPrograms
{
    class Node
    {
        public int data;
        public Node left, right;
        public Node(int key)
        {
            data = key;
            left = right = null;
        }
    }

    class LevelOrderTreeTraversal
    {
        public Node root;

        // compute height of the tree.
        public virtual int Height(Node root)
        {
            int height = 0;
            if (root == null)
            {
                return height;
            }

            Console.WriteLine("Computing height of tree, root:" + root.data);

            /* compute height of each subtree */
            int lheight = Height(root.left);
            Console.WriteLine("lheight:" + lheight);
            int rheight = Height(root.right);
            Console.WriteLine("rheight:" + lheight);

            /* use the larger one */
            if (lheight > rheight)
            {
                height = (lheight + 1);
            }
            else
            {
                height = (rheight + 1);
            }

            Console.WriteLine("Current Height: " + height);
            return height;

        }

        // print level order.
        public virtual void PrintLevelOrder()
        {
            int h = Height(root);
            for (int i = 1; i <= h; i++)
            {
                PrintCurrentLevel(root, i);
            }
        }

        // print nodes at current level.
        public virtual void PrintCurrentLevel(Node root, int level)
        {
            if (root == null)
            {
                return;
            }
            if (level == 1)
            {
                Console.Write(root.data + ",");
            }
            else if (level > 1)
            {
                PrintCurrentLevel(root.left, level - 1);
                PrintCurrentLevel(root.right, level - 1);
            }
        }

        // Runner.
        public static void Run()
        {
            LevelOrderTreeTraversal tree = new();

            // Tree description:
            // InOrder: 4,2,5,1,3
            // PreOrder: 1,2,4,5,3
            // PostOrder: 4,5,2,3,1
            // Expected level order: 1,2,3,4,5
            tree.root = new Node(1)
            {
                left = new Node(2),
                right = new Node(3)
            };
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
             
            Console.WriteLine("Level order traversal of binary tree is: ");
            tree.PrintLevelOrder();
        }
    }
}
