using System;
using System.IO;
using System.Threading.Tasks;

namespace DotNetPrograms.DSAndSync
{

    public class SampleFile
    {
        public string fileName;
        public string directory;
        public SampleFile(string fileName, string directory)
        {
            this.fileName = fileName;
            this.directory = directory;
        }
    }

    // ref: https://masterdotnet.com/csharptutorial/task-async-await-in-c/
    class TaskFactory
    {
        //Reading File ,Independent and Time consuming process
        public static string ReadFile(string path, string fileName)
        {
            Console.WriteLine("Beginning ReadFile Program");
            string fullPath = path + "/" + fileName;
            string content = "";
            using (StreamReader rdr = new StreamReader(fullPath))
            {
                content = rdr.ReadToEnd();
            }
            Console.WriteLine("End of ReadFile Program");
            return content;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Beginning Main Program");
            SampleFile file = new SampleFile("test.txt", "C:/Test");
            Task<string> task = Task<string>.Factory.StartNew(
                (Object obj) =>
                {
                    SampleFile f = obj as SampleFile;
                    return ReadFile(f.directory, f.fileName);
                }, file);
            Console.WriteLine("Other Parts of Main Program");
            Console.WriteLine(".........................");
            Console.WriteLine(".........................");
            task.Wait();
            Console.WriteLine("File Contents:");
            Console.WriteLine(task.Result);
            Console.WriteLine("End of  Main Program");
        }
    }
}
