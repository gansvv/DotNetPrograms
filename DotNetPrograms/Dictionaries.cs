using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPrograms
{
    class Dictionaries
    {
        public static void Run()
        {
            Dictionary<int, string> TestStore = new();
            SortedDictionary<int, string> TestSortedStore = new();
            TestStore.Add(4, "test store.");
            TestStore.Add(2, "is");
            TestStore.Add(3, "a");
            TestStore.Add(1, "This");

            TestSortedStore.Add(10, "Test");
            TestSortedStore.Add(8, "AnotherTest");
            TestStore.ToList().ForEach(pair => TestSortedStore.Add(pair.Key, pair.Value));

            // PrintDictionary(TestStore);
            // PrintSortedDictionary(TestSortedStore);
            Console.WriteLine("SimpleDict:" + String.Join(Environment.NewLine, TestStore));
            Console.WriteLine("Sorted:" + String.Join(Environment.NewLine, TestSortedStore));

            TestStore.Remove(3);

            // PrintDictionary(TestStore);


            if (TestStore.ContainsKey(2))
            {
                Console.WriteLine("Contains key 2!");
            }

            if (TestStore.ContainsKey(3))
            {
                Console.WriteLine("Contains key 3!");
            }

            if (TestStore.ContainsValue("is"))
            {
                Console.WriteLine("Contains value 'is'!");
            }

            if (TestStore.ContainsValue("a"))
            {
                Console.WriteLine("Contains value 'a'!");
            }

            SortedDictionary<Student, List<string>> essays = new (new StudentNameComparer());
            essays.Add(new Student() { Name = "John" }, new List<string>());
            essays.Add(new Student() { Name = "Adam" }, new List<string>());
            essays.Add(new Student() { Name = "Paul" }, new List<string>());
            essays.Add(new Student() { Name = "Hannah" }, new List<string>());
            essays.Add(new Student() { Name = "Eve" }, new List<string>());
            essays.Add(new Student() { Name = "Anne" }, new List<string>());
            essays.Add(new Student() { Name = "Mary" }, new List<string>());

            foreach (var kvp in essays)
            {
                Console.WriteLine(kvp.Key.Name);
            }
        }

        static void PrintDictionary(Dictionary<int, string> Dict)
        {
            Console.WriteLine("Dict:");
            foreach (KeyValuePair<int, string> item in Dict)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            }
        }

        static void PrintSortedDictionary(SortedDictionary<int, string> Dict)
        {
            Console.WriteLine("Sorted Dict:");
            foreach (KeyValuePair<int, string> item in Dict)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public string SchoolName { get; set; }
    }
     class StudentNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    class DuplicatesInArray
    {
        public static void Run()
        {
            List<int> numberList = new ();
            // int[] values = new []{1,2,3,4,5,4,4,3};
            numberList.Add(1);
            numberList.Add(2);
            numberList.Add(3);
            numberList.Add(2);
            numberList.Add(2);
            numberList.Add(5);
            numberList.Add(6);
            numberList.Add(15);
            numberList.Add(12);
            numberList.Add(12);
            numberList.Add(10);
            Console.WriteLine(String.Join(",", numberList));

            Dictionary<int, int> numberDict = new();
            foreach(int i in numberList)
            {
                if (numberDict.ContainsKey(i))
                {
                    numberDict[i]++;
                }
                else
                {
                    numberDict[i] = 1;
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, numberDict));

            Console.WriteLine("Duplicates:");
            foreach (var pair in numberDict)
            {
                if (pair.Value > 1)
                {
                    Console.WriteLine("{0} found {1} times.", pair.Key, pair.Value);
                }
            }
        } 

        
    }
}
