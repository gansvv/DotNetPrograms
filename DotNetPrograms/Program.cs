using System;

namespace DotNetPrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting dot net programs....");

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

            Console.WriteLine("\nRun complete.");
        }
    }
}
