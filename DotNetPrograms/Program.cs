using System;
using DotNetPrograms.Sync;
using DotNetPrograms.Sync.Stack;

namespace DotNetPrograms
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting dot net programs....");

            // Test bed ------------------------
            Stack1Runner.Runner();

            // complete ------------------------
            return;

            MultiThread1.MutexRunner(new string[] { "test" });
            ConcurrentQueue1.Runner();
            Queue1Runner.Runner();

            // Dictionaries
            DuplicatesInArray.Run();

            LevelOrderTreeTraversal.Run();

            Console.WriteLine("LRU Cache:");

            LRUCache<int, int> cache = new LRUCache<int, int>(3);
            cache.Add(1, 10);
            cache.Add(2, 20);
            cache.Add(3, 30);
            Console.WriteLine("Get valid number from cache: {0}", cache.Get(2));
            cache.Add(4, 40);
            Console.WriteLine("TryGet using invalidated key from cache: {0}", cache.Get(1));
            Console.WriteLine("Get valid number from cache: {0}", cache.Get(4));
            Console.WriteLine("Get valid number from cache: {0}", cache.Get(2));

            PreLRUCache intCache = new PreLRUCache(3);
            intCache.Add(1, 10);
            intCache.Add(2, 20);
            intCache.Add(3, 30);
            Console.WriteLine("Get valid number from pre cache: {0}", intCache.Get(2));
            intCache.Add(4, 40);
            Console.WriteLine("TryGet using unknown key from pre cache: {0}", intCache.Get(100));
            Console.WriteLine("TryGet using invalidated key from pre cache: {0}", intCache.Get(1));
            Console.WriteLine("Get valid number from pre cache: {0}", intCache.Get(4));
            Console.WriteLine("Get valid number from pre cache: {0}", intCache.Get(2));

            Console.WriteLine("Floyd cycle detection in Linked List:");
            LinkedListCycle llist = new ();
            llist.AddNodeToHead(10);
            llist.AddNodeToHead(20);
            llist.AddNodeToHead(30);
            llist.AddNodeToHead(40);
            llist.AddNodeToHead(50);
            Console.WriteLine("Does cycle exist? {0}", llist.DetectCycle());
            // create loop
            llist.GetHeadNode.next.next.next.next.next = llist.GetHeadNode;
            Console.WriteLine("Does cycle exist? {0}", llist.DetectCycle());

            DotNetProgramsAnother.MaxPathSumBinaryTree.Runner();

            Console.WriteLine("Tree Traversals:");
            Tree.Traversals.Run();

            Console.WriteLine("Dictionaries:");
            Dictionaries.Run();

            Console.WriteLine("\nRun complete.");
        }
    }
}
