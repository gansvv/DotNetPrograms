using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetPrograms.DSAndSync
{
    public delegate void MyDelegate(long sum);
    public class CallBack
    {
        private int _count;

        // ref: https://masterdotnet.com/csharptutorial/threading-in-csharp-part1/
        // We can use delegate to do a call back after completing the task.
        public MyDelegate callback;
        public CallBack(int count, MyDelegate callback)
        {
            this._count = count;
            this.callback = callback;
        }
        public void LongRunningJob()
        {
            long sum = 0;
            for (int i = 0; i < _count; i++)
            {
                sum += _count;
            }
            callback(sum);
        }

        private readonly object _lockObject = new object();
        public void MyMethod()
        {
            Monitor.Enter(_lockObject);
            //Critical Code Section
            //Only one thread is allowed to execute this section.
            try
            {
                //code
            }
            catch
            {
                //handle execptions
            }
            finally
            {
                //always release lock
                Monitor.Exit(_lockObject);
            }
        }

        // By using Monitor class we can acquire an exclusive lock on a critical
        // section of the program thereby preventing multiple threads from executing simultaneously. 
        private readonly object _lockObject2 = new object();
        public void MyMethod2()
        {
            lock (_lockObject2)
            {
                //Critical Code Section
                //Only one thread is allowed to execute this section.
            }
        }

        public static void ParallelUsage()
        {
            //arg1:loop starts from 0
            //arg2:loop goes till 999
            //arg3:the operation needs to be performed ,here lamda function used
            Parallel.For(0, 1000, x => { Console.Write(x + ","); });
            Console.ReadLine();
            // ----------------------
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //arg1: source collection
            //arg2:task passed as lambda function here.
            Parallel.ForEach<int>(array, y => { Console.WriteLine(y); });
            Console.ReadKey();
            // ----------------------
            int[] array = Enumerable.Range(1, 10).ToArray();
            long grandTotal = 0;
            Parallel.ForEach<int, long>(array,
            () => 0,
            (j, loop, sumPartition) =>
            {
                Console.WriteLine("Item={0} on Thread={1}", j, Thread.CurrentThread.ManagedThreadId);
                sumPartition += j;
                return sumPartition;
            }, sT =>
            {
                Interlocked.Add(ref grandTotal, sT);
            }
            );
            Console.WriteLine("Total={0}", grandTotal);
            Console.ReadKey();
        }
    }
    class Learn
    {
        static void Main(string[] args)
        {
            // Here we have a class where we have a long-running job, we can pass a delegate
            // to the constructor of the class which will do a callback to the function after the job completes.
            Console.WriteLine("Main Started");
            CallBack myClass = new CallBack(1000, (x) => { Console.WriteLine("Sum from thread={0}", x); });
            Thread myThread = new Thread(myClass.LongRunningJob);
            myThread.Start();
            Console.WriteLine("Main Completed");
            Console.ReadLine();
        }
    }
}
