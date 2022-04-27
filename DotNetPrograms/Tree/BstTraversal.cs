using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPrograms.Tree
{
    class BstTraversal
    {
        // ref: https://masterdotnet.com/csharp/ds/bstincsharp/

        public void PrintDFS_PreOrder(BSTNode root)
        {
            if (root == null)
                return;
            Console.Write(root.data + ",");
            PrintDFS_PreOrder(root.left);
            PrintDFS_PreOrder(root.right);
        }
        public void PrintDFS_InOrder(BSTNode root)
        {
            if (root == null)
                return;
            PrintDFS_InOrder(root.left);
            Console.Write(root.data + ",");
            PrintDFS_InOrder(root.right);
        }

        public void PrintDFS_PostOrder(BSTNode root)
        {
            if (root == null)
                return;
            PrintDFS_PostOrder(root.left);
            PrintDFS_PostOrder(root.right);
            Console.Write(root.data + ",");

        }

        public BSTNode Insert(BSTNode root, int data)
        {
            if (root == null)
            {
                root = new BSTNode(data);
                return root;
            }
            else if (data > root.data)
            {
                root.right = Insert(root.right, data);
            }
            else
            {
                root.left = Insert(root.left, data);
            }
            return root;
        }

        public void PrintBFS(BSTNode root)
        {
            Queue<BSTNode> bfsQueue = new Queue<BSTNode>();
            bfsQueue.Enqueue(root);
            BSTNode current = null;
            while (bfsQueue.Any())
            {
                current = bfsQueue.Peek();
                Console.Write(current.data + ",");
                if (current.left != null)
                    bfsQueue.Enqueue(current.left);
                if (current.right != null)
                    bfsQueue.Enqueue(current.right);
                bfsQueue.Dequeue();
            }
        }

        public bool IsExists(BSTNode root, int data)
        {
            if (root == null)
                return false;
            else if (root.data == data)
                return true;
            else if (data > root.data)
            {
                return IsExists(root.right, data);
            }
            else
            {
                return IsExists(root.left, data);
            }
        }
        public int FindMax(BSTNode root)
        {
            if (root.right == null)
                return root.data;
            return FindMax(root.right);

        }
        public int FindMin(BSTNode root)
        {
            if (root.left == null)
                return root.data;
            return FindMin(root.left);
        }
    }

    class BSTNode
    {
        public int data;
        public BSTNode left;
        public BSTNode right;

        public BSTNode(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
    }
}
