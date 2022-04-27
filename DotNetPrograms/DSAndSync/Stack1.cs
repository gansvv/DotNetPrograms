using System;

namespace DotNetPrograms.Sync.Stack
{
    class Stack1
    {
        // Ref: https://masterdotnet.com/csharp/ds/stack-using-csharp/

        LinkedListNode top;

        public Stack1()
        {
            top = null;

        }

        public LinkedListNode GetNode(int data)
        {
            LinkedListNode node = new LinkedListNode(data);
            return node;
        }

        public void Push(int data)
        {
            LinkedListNode newNode = GetNode(data);
            if (top == null)
            {
                top = newNode;
                return;
            }

            newNode.next = top;
            top = newNode;
        }

        public int Peek()
        {
            if (top != null)
            {
                return top.data;
            }
            return -1;
        }

        public int Pop()
        {
            int peek = -1;
            if (top != null)
            {
                peek = top.data;
                top = top.next;
            }

            return peek;
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

    public static class Stack1Runner
    {
        public static void Runner()
        {
            Stack1 stack = new();

            stack.Push(10);
            stack.Push(20);
            stack.Push(100);
            stack.Push(40);

            while (stack.Peek() != -1)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
