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
        public virtual int height(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                /* compute height of each subtree */
                int lheight = height(root.left);
                int rheight = height(root.right);

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

        // print level order.
        public virtual void printLevelOrder()
        {
            int h = height(root);
            for (int i = 1; i <= h; i++)
            {
                printCurrentLevel(root, i);
            }
        }

        // print nodes at current level.
        public virtual void printCurrentLevel(Node root, int level)
        {
            if (root == null)
            {
                return;
            }
            if (level == 1)
            {
                Console.Write(root.data + " ");
            }
            else if (level > 1)
            {
                printCurrentLevel(root.left, level - 1);
                printCurrentLevel(root.right, level - 1);
            }
        }

        // Runner.
        public static void Run()
        {
            LevelOrderTreeTraversal tree = new();
            tree.root = new Node(1)
            {
                left = new Node(2),
                right = new Node(3)
            };
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            Console.WriteLine("Level order traversal of binary tree is: ");
            tree.printLevelOrder();
        }
    }
}
