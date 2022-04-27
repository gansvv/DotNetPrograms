using System;

namespace DotNetPrograms.Sync
{
    // Implementing a queue in C#. Ref: https://masterdotnet.com/csharp/ds/queueincsharp/
    class Queue1
    {
        LinkedListNode front;
        LinkedListNode rear;

        public Queue1()
        {
            front = null;
            rear = null;
        }
        public LinkedListNode GetNode(int data)
        {
            LinkedListNode node = new LinkedListNode(data);
            return node;
        }
        public void Enqueue(int data)
        {
            LinkedListNode newNode = GetNode(data);
            if (front == null)
            {
                front = rear = newNode;
                return;
            }

            rear.next = newNode;
            rear = newNode;
        }
        public int DeQueue()
        {
            int peek = -1;
            if (front != null)
            {
                peek = front.data;
                front = front.next;
            }

            return peek;
        }
        public int GetPeek()
        {
            if (front != null)
            {
                return front.data;
            }
            return -1;
        }
        public bool IsEmpty()
        {
            if (front == null)
            {
                return true;
            }

            return false;
        }
    }

    public static class Queue1Runner
    {
        public static void Runner()
        {
            Console.WriteLine("Starting: " + nameof(Queue1Runner));

            Queue1 queue = new();
            queue.Enqueue(10);
            queue.Enqueue(15);
            queue.Enqueue(20);

            while (!queue.IsEmpty())
            {
                Console.WriteLine(queue.DeQueue());
            }

            // Console.WriteLine(String.Join(",", queue.DeQueue()));
        }
    }

    class LinkedListNode
    {
        public int data;
        public LinkedListNode next;

        public LinkedListNode(int data)
        {
            this.data = data;
            this.next = null;
        }
    }
}
