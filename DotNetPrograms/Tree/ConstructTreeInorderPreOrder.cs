using System;

namespace DotNetPrograms.Tree
{
    // Program to construct a tree using inorder and preorder traversal
    class ConstructTreeInorderPreOrder
    {
        /* A binary tree node has data, pointer
            to left child and a pointer to right child */
        public class Node
        {
            public char data;
            public Node left, right;

            public Node(char item)
            {
                data = item;
                left = right = null;
            }
        }

        // public Node root;
        public static int preIndex = 0;

        /* Recursive function to construct binary
            of size len from Inorder traversal in[]
            and Preorder traversal pre[]. Initial values
            of inStrt and inEnd should be 0 and len -1.
            The function doesn't do any error checking for
            cases where inorder and preorder do not form a tree */
        public virtual Node buildTree(char[] arr, char[] pre,
                                      int inStrt, int inEnd)
        {
            if (inStrt > inEnd)
            {
                return null;
            }

            /* Pick current node from Preorder traversal
         using preIndex and increment preIndex */
            Node tNode = new Node(pre[preIndex++]);

            /* If this node has no children then return */
            if (inStrt == inEnd)
            {
                return tNode;
            }

            /* Else find the index of this
                node in Inorder traversal */
            int inIndex = search(arr, inStrt,
                                 inEnd, tNode.data);

            /* Using index in Inorder traversal,
             construct left and right subtress */
            tNode.left = buildTree(arr, pre, inStrt, inIndex - 1);
            tNode.right = buildTree(arr, pre, inIndex + 1, inEnd);

            return tNode;
        }

        /* UTILITY FUNCTIONS */

        /* Function to find index of value in arr[start...end]
            The function assumes that value is present in in[] */
        public virtual int search(char[] arr, int strt,
                                  int end, char value)
        {
            int i;
            for (i = strt; i <= end; i++)
            {
                if (arr[i] == value)
                {
                    return i;
                }
            }
            return i;
        }

        /* This function is here just to test buildTree() */
        public virtual void PrintInorder(Node node)
        {
            if (node == null)
            {
                return;
            }

            /* first recur on left child */
            PrintInorder(node.left);

            /* then print the data of node */
            Console.Write(node.data + " ");

            /* now recur on right child */
            PrintInorder(node.right);
        }

        // Driver Code
        public static void Run()
        {
            ConstructTreeInorderPreOrder tree = new ConstructTreeInorderPreOrder();
            char[] arr = new char[] { 'D', 'B', 'E', 'A', 'F', 'C' };
            char[] pre = new char[] { 'A', 'B', 'D', 'E', 'C', 'F' };
            int len = arr.Length;
            Node root = tree.buildTree(arr, pre, 0, len - 1);

            // building the tree by printing inorder traversal
            Console.WriteLine("Inorder traversal of constructed tree is : ");
            tree.PrintInorder(root);
        }
    }
}
