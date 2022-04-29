using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPrograms
{
    internal class MostFrequentElementInArray
    {
        static int mostFrequent(int[] arr, int n)
        {
            // Insert all elements in hash
            Dictionary<int, int> hp =
                        new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int key = arr[i];
                if (hp.ContainsKey(key))
                {
                    int freq = hp[key];
                    freq++;
                    hp[key] = freq;
                }
                else
                    hp.Add(key, 1);
            }

            // find max frequency.
            int min_count = 0, res = -1;

            foreach (KeyValuePair<int,
                        int> pair in hp)
            {
                if (min_count < pair.Value)
                {
                    res = pair.Key;
                    min_count = pair.Value;
                }
            }
            return res;
        }

        // Driver code
        static void Main()
        {
            int[] arr = new int[] { 40, 50, 30, 40, 50, 30, 30 };
            int n = arr.Length;

            Console.Write(mostFrequent(arr, n));
        }

        /// moore's voting algo
        static int maxFreqMoore(int[] arr, int n)
        {

            // using moore's voting algorithm
            int res = 0;
            int count = 1;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] == arr[res])
                {
                    count++;
                }
                else
                {
                    count--;
                }

                if (count == 0)
                {
                    res = i;
                    count = 1;
                }

            }

            return arr[res];
        }

        // Driver code
        public static void MainMoore(String[] args)
        {
            int[] arr = { 40, 50, 30, 40, 50, 30, 30 };
            int n = arr.Length;
            int freq = maxFreqMoore(arr, n);
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == freq)
                {
                    count++;
                }
            }
            Console.Write("Element " + maxFreqMoore(arr, n) + " occurs " + count + " times");
        }
    }
}
