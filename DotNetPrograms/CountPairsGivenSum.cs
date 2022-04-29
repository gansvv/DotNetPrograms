using System;
using System.Collections.Generic;

namespace DotNetPrograms
{
    // C# implementation of simple method to find count of
    // pairs with given sum.
    internal class CountPairsGivenSum
    {
        // Returns number of pairs in arr[0..n-1] with sum equal
        // to 'sum'
        static int getPairsCount(int[] arr, int n, int k)
        {
            Dictionary<int, int> m = new Dictionary<int, int>();
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (m.ContainsKey(k - arr[i]))
                {
                    count += m[k - arr[i]];
                }
                if (m.ContainsKey(arr[i]))
                {
                    m[arr[i]] = m[arr[i]] + 1;
                }
                else
                {
                    m.Add(arr[i], 1);
                }
            }
            return count;
        }

        // Driver function to test the above function
        public static void Main(String[] args)
        {
            int[] arr = { 1, 5, 7, -1, 5 };
            int n = arr.Length;
            int sum = 6;
            Console.Write("Count of pairs is " + getPairsCount(arr, n, sum));
        }
    }
}
