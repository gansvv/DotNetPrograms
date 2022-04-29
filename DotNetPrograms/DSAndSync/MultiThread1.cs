using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace DotNetPrograms.Sync
{
    public class MultiThread1
    {
        public static void MutexRunner(string[] args)
        {
            const string SHARED_MUTEX_NAME = "something";
            int pid = Environment.ProcessId;

            using (Mutex mtx = new (false, SHARED_MUTEX_NAME))
            {
                ConsoleKeyInfo input;
                while (true)
                {
                    Console.WriteLine("Press any key to let process {0} acquire the shared mutex.", pid);
                    input = Console.ReadKey();

                    if (input.Key == ConsoleKey.Q)
                    {
                        Console.WriteLine($"input: {input.KeyChar}. EXITING......");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"input: {input.KeyChar}");
                    }

                    while (!mtx.WaitOne(1000))
                    {
                        Console.WriteLine("Process {0} is waiting for the shared mutex...", pid);
                    }

                    Console.WriteLine("Process {0} has acquired the shared mutex. Press any key to release it.", pid);
                    Console.ReadKey();

                    mtx.ReleaseMutex();
                    Console.WriteLine("Process {0} released the shared mutex.", pid);
                }
            }

            /*
            static object linksLock = new object();

            static void AddLine()
            {
                lock (linksLock)
                {
                    using (var fileStream = new FileStream("links.txt"...))
                    {
                        // add a line
                    }
                }
            }

            static void RemoveLine()
            {
                lock (linksLock)
                {
                    using (var fileStream = new FileStream("links.txt"...))
                    {
                        // remove a line
                    }
                }
            }

            if (Monitor.TryEnter(SHARED_MUTEX_NAME, 300))
            {
                try
                {
                    // Place code protected by the Monitor here.  
                }
                finally
                {
                    Monitor.Exit(SHARED_MUTEX_NAME);
                }
            }
            else
            {
                // Code to execute if the attempt times out.  
            }*/
        }



        public static string NormalizePath(string path)
        {
            return Path.GetFullPath(new Uri(path).LocalPath)
                       .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                       .ToUpperInvariant();
        }
    }
}
