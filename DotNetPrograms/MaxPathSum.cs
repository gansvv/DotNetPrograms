using System;

namespace DotNetProgramsAnother
{
    /* Class containing left and right child of current node and key value*/
    public class Node
    {

        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

    // An object of Res is passed around so that the same value
    // can be used by multiple recursive calls.
    class Res
    {
        public int val;
    }

    // Finding max path sum in Binary Tree
    public class MaxPathSumBinaryTree
    {

        // Root of the Binary Tree
        Node root;

        // This function returns overall
        // maximum path sum in 'res' And
        // returns max path sum going through root.
        int FindMaxUtil(Node node, Res res)
        {

            // Base Case
            if (node == null)
                return 0;

            // l and r store maximum path
            // sum going through left and
            // right child of root respectively
            int l = FindMaxUtil(node.left, res);
            int r = FindMaxUtil(node.right, res);

            // Max path for parent call of root.
            // This path must include
            // at-most one child of root
            int max_single = Math.Max(Math.Max(l, r) +
                                node.data, node.data);


            // Max Top represents the sum
            // when the Node under
            // consideration is the root
            // of the maxsum path and no
            // ancestors of root are there
            // in max sum path
            int max_top = Math.Max(max_single,
                            l + r + node.data);

            // Store the Maximum Result.
            res.val = Math.Max(res.val, max_top);

            return max_single;
        }

        int FindMaxSum()
        {
            return FindMaxSum(root);
        }

        // Returns maximum path
        // sum in tree with given root
        int FindMaxSum(Node node)
        {

            // Initialize result
            // int res2 = int.MinValue;
            Res res = new();
            res.val = int.MinValue;

            // Compute and return result
            FindMaxUtil(node, res);
            return res.val;
        }

        /* Driver code */
        public static void Runner()
        {
            MaxPathSumBinaryTree tree = new MaxPathSumBinaryTree();
            tree.root = new Node(10);
            tree.root.left = new Node(2);
            tree.root.right = new Node(10);
            tree.root.left.left = new Node(20);
            tree.root.left.right = new Node(1);
            tree.root.right.right = new Node(-25);
            tree.root.right.right.left = new Node(3);
            tree.root.right.right.right = new Node(4);
            Console.WriteLine("Max path sum is : " + tree.FindMaxSum());
        }
    }

}
