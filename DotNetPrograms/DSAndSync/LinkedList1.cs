using System;

namespace DotNetPrograms.DSAndSync
{
    class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
        public Node() { }
    };

    class Linkedlist1
    {
        // Ref: https://masterdotnet.com/csharp/ds/linkedlist/

        Node head;
        public Node GetHeadNode
        {
            get
            {
                return head;
            }
        }
        public Linkedlist1()
        {

        }

        public void PrintAll()
        {
            Console.WriteLine("The Linked List Contents");
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + "--> ");
                temp = temp.next;

            }
            Console.WriteLine();
        }

        public void AddFirst(int data)
        {
            Node newNode = new Node(data);
            newNode.next = head;
            head = newNode;
        }

        public void AddLast(int data)
        {
            Node temp = head;
            Node newNode = new Node(data);
            if (head == null)
            {
                head = new Node();
                head.next = newNode;
                head = newNode;
            }
            else
            {
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = newNode;
            }
        }

        public void AddAt(int data, int position)
        {
            if (head != null)
            {
                Node temp = head;
                Node current = null;
                Node next = null;
                for (int i = 0; i < position - 2; i++)
                {
                    temp = temp.next;
                }
                current = temp;
                next = temp.next;

                Node newNode = new Node(data);
                current.next = newNode;
                newNode.next = next;
            }
        }

        public void ReverseLinkedList()
        {
            Node current = head;
            Node previous = null;
            Node next = current.next;

            while (next != null)
            {
                current.next = previous;
                previous = current;
                current = next;
                next = next.next;
            }
            current.next = previous;
            head = current;
        }

        public void PrintAllRecursively(Node temp)
        {
            if (temp == null)
                return;
            Console.Write(temp.data + "-->");
            PrintAllRecursively(temp.next);
        }

        public void PrinAllReverseRecursively(Node temp)
        {
            if (temp == null)
                return;
            PrinAllReverseRecursively(temp.next);
            Console.Write(temp.data + "-->");

        }
    }
}
