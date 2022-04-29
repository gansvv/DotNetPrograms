using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPrograms.DSAndSync
{
    class AsyncFileReader
    {
        // ref: https://masterdotnet.com/csharptutorial/task-async-await-in-c/

        public static async Task<string> ReadFileAsync(string path, string fileName)
        {
            Console.WriteLine("Insise the ReadFileAsync method");
            string fullPath = path + "/" + fileName;
            StringBuilder content = new StringBuilder();
            using (FileStream streamToRead = new FileStream(fullPath, FileMode.Open, FileAccess.Read,
            FileShare.Read, bufferSize: 4096, useAsync: true))
            {
                byte[] buffer = new byte[0x1000];
                int numbersToRead;
                while ((numbersToRead = await streamToRead.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.UTF8.GetString(buffer, 0, numbersToRead);
                    content.Append(text);
                }
            }
            Console.WriteLine("Returning from ReadFileAsync method");
            return content.ToString();
        }
        public async static Task Main(string[] args)
        {
            Console.WriteLine("Inside Main Program");
            //Run the read file operation asynchronously
            Task<string> readFileTask = ReadFileAsync("c:/test", "test.txt");
            Console.WriteLine("Other methods to Run While ReadFileAsync running..........");
            //after this point , we can't conitnue without readFileTask completed
            string output = await readFileTask;
            Console.WriteLine("output:" + output);
            Console.WriteLine("End Main Program");
        }
    }
}
