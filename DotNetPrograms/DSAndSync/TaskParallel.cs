using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPrograms.DSAndSync.Parallel
{
    class SampleFile
    {
        public string fileName;
        public string directory;
        public SampleFile(string fileName, string directory)
        {
            this.fileName = fileName;
            this.directory = directory;
        }
    }
    class TaskParallel
    {
        public static string ReadFile(string path, string fileName)
        {
            string fullPath = path + "/" + fileName;
            string content = "";
            using (StreamReader rdr = new StreamReader(fullPath))
            {
                content = rdr.ReadToEnd();
            }
            return content;
        }
        static void Main(string[] args)
        {
            List<SampleFile> files = new List<SampleFile>();
            files.Add(new SampleFile("test.txt", "C:/Test"));
            files.Add(new SampleFile("test1.txt", "C:/Test"));
            files.Add(new SampleFile("test2.txt", "C:/Test"));
            files.Add(new SampleFile("test3.txt", "C:/Test"));
            List<Task<string>> tasks = new List<Task<string>>();
            foreach (SampleFile file in files)
            {
                tasks.Add(Task<string>.Factory.StartNew((Object obj) => { 
                    SampleFile f = obj as SampleFile; 
                    return ReadFile(f.directory, f.fileName); 
                }, file));
            }
            Console.WriteLine("File Contents:");
            Task.WaitAll(tasks.ToArray());
            foreach (Task<string> task in tasks)
            {
                Console.WriteLine($"File Name : {(task.AsyncState as SampleFile).fileName}");
                Console.WriteLine(task.Result); Console.WriteLine();
            }
        }

        // More Ref: https://masterdotnet.com/csharptutorial/task-async-await-in-c/
    }
}
