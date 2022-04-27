using System;

namespace DotNetPrograms.DSAndSync.DLL
{
    class DoublyLinkedlist1
    {
        // ref: https://masterdotnet.com/csharp/ds/linkedlist/

        Node head;

        Node GetHeadNode
        {
            get
            {
                return head;
            }
        }
        public DoublyLinkedlist1()
        {
            head = null;
        }

        public void AddFirst(int data)
        {
            Node newNode = new Node(data);
            if (head != null)
            {
                newNode.next = head;
                head.previous = newNode;
                head = newNode;
            }
            else
            {
                head = newNode;
            }
        }

        public void AddLast(int data)
        {
            Node temp = head;
            Node newNode = new Node(data);
            if (temp != null)
            {
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = newNode;
                newNode.previous = temp;
            }
            else
            {
                head = newNode;
            }
        }
        public void PrintAll()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine("Previous={0},Current ={1},Next={2}", temp.previous?.data, temp.data, temp.next?.data);
                temp = temp.next;
            }
        }
    }

    class Node
    {
        public int data;
        public Node next;
        public Node previous;
        public Node(int data)
        {
            this.data = data;
            this.next = null;
            this.previous = null;

        }
        public Node()
        {

        }
    }
}
