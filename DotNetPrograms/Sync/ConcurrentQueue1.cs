using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPrograms.Sync
{
    public class ConcurrentQueue1
    {
        public static void Runner()
        {
            List<int> ints = new List<int>();
            ints.Add(1);
            ints.Add(2);
            ConcurrentQueue<int> coll = new ConcurrentQueue<int>(ints);
            coll.Enqueue(1);
            coll.Enqueue(2);
            coll.Enqueue(3);
            coll.Enqueue(4);
            int item;
            bool isSuccessful = coll.TryPeek(out item);
            Console.WriteLine(isSuccessful); //Returns True
            Console.WriteLine(item);    //Return "1"

            isSuccessful = coll.TryDequeue(out item);
            Console.WriteLine(isSuccessful); //Returns True
            Console.WriteLine(item);    //Return "1"

            isSuccessful = coll.TryDequeue(out item);
            Console.WriteLine(isSuccessful); //Returns True
            Console.WriteLine(item);    //Return "2"

            Console.WriteLine(String.Join(",", coll));

            int[] array = coll.ToArray();
            // ref: http://dotnetpattern.com/csharp-concurrentqueue
            Console.WriteLine(String.Join(",", array));
        }
    }
}
