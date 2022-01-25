using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPrograms
{
    // Detects cycle in Linked List.
    // Uses Floyd's cycle finding algorithm.
    // Time: O(1) because only one traversal of loop is needed,
    // Space: O(1).
    class LinkedListCycle
    {
        public Node GetHeadNode => head;
        Node head;

        public class Node
        {
            public int data;
            public Node next;
            public Node(int v)
            {
                this.data = v;
                this.next = null;
            }
        }

        public void AddNodeToHead(int v)
        {
            Node n = new Node(v);
            n.next = head;
            head = n;
        }

        public bool DetectCycle()
        {
            Node slow = head, fast = head;
            while (slow != null && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast) // can perform equality check via node value or address
                {
                    return true;
                }
            }

            return false;
        }
    }
}
