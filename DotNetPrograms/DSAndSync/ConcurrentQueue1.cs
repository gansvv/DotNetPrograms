using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace DotNetPrograms.Sync
{
    public class ConcurrentQueue1
    {
        public static void Runner()
        {
            List<int> ints = new ();
            ints.Add(1);
            ints.Add(2);
            ConcurrentQueue<int> conQ1 = new (ints);
            conQ1.Enqueue(1);
            conQ1.Enqueue(2);
            conQ1.Enqueue(3);
            conQ1.Enqueue(4);
            int item;
            bool isSuccessful = conQ1.TryPeek(out item);
            Console.WriteLine(isSuccessful); //Returns True
            Console.WriteLine(item);    //Return "1"

            isSuccessful = conQ1.TryDequeue(out item);
            Console.WriteLine(isSuccessful); //Returns True
            Console.WriteLine(item);    //Return "1"

            isSuccessful = conQ1.TryDequeue(out item);
            Console.WriteLine(isSuccessful); //Returns True
            Console.WriteLine(item);    //Return "2"

            Console.WriteLine(String.Join(",", conQ1));

            int[] array = conQ1.ToArray();
            // ref: http://dotnetpattern.com/csharp-concurrentqueue
            Console.WriteLine(String.Join(",", array));


            // --------------------  threads -----------------
            Thread thread1 = new (() =>
            {
                conQ1.Enqueue(10);
                conQ1.Enqueue(20);
            });
            Thread thread2 = new (() =>
            {
                conQ1.Enqueue(40);
                conQ1.Enqueue(60);
            });
            thread2.Start();
            thread1.Start();
            thread2.Join();
            thread1.Join();
            while (conQ1.Count != 0)
            {
                if (conQ1.TryDequeue(out int x))
                {
                    Console.WriteLine(x); ;
                }
            }
        }
    }
}
