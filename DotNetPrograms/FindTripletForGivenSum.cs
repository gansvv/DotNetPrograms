using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPrograms
{
    // C# program to find if there is a triplet in array whose sum is equal
    // to the given value. If there is such a triplet present in array, then
    // print the triplet and return true. Else return false.
    class FindTripletForGivenSum
    {
        // returns true if there is triplet
        // with sum equal to 'sum' present
        // in A[]. Also, prints the triplet
        bool find3Numbers(int[] A, int arr_size, int sum)
        {
            int l, r;

            /* Sort the elements */
            quickSort(A, 0, arr_size - 1);

            /* Now fix the first element one by one and find the other two elements */
            for (int i = 0; i < arr_size - 2; i++)
            {

                // To find the other two elements, start two index variables from
                // two corners of the array and move them toward each other
                l = i + 1; // index of the first element in the remaining elements
                r = arr_size - 1; // index of the last element
                while (l < r)
                {
                    if (A[i] + A[l] + A[r] == sum)
                    {
                        Console.Write("Triplet is " + A[i] + ", " + A[l] + ", " + A[r]);
                        return true;
                    }
                    else if (A[i] + A[l] + A[r] < sum)
                        l++;

                    else // A[i] + A[l] + A[r] > sum
                        r--;
                }
            }

            // If we reach here, then no triplet was found
            return false;
        }

        int partition(int[] A, int si, int ei)
        {
            int x = A[ei];
            int i = (si - 1);
            int j;

            for (j = si; j <= ei - 1; j++)
            {
                if (A[j] <= x)
                {
                    i++;
                    int temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }
            }
            int temp1 = A[i + 1];
            A[i + 1] = A[ei];
            A[ei] = temp1;
            return (i + 1);
        }

    /* Implementation of Quick Sort
    A[] --> Array to be sorted
    si --> Starting index
    ei --> Ending index
    */
        void quickSort(int[] A, int si, int ei)
        {
            int pi;

            /* Partitioning index */
            if (si < ei)
            {
                pi = partition(A, si, ei);
                quickSort(A, si, pi - 1);
                quickSort(A, pi + 1, ei);
            }
        }

        // Driver Code
        static void Run()
        {
            FindTripletForGivenSum triplet = new FindTripletForGivenSum();
            int[] A = new int[] { 1, 4, 45, 6, 10, 8 };
            int sum = 22;
            int arr_size = A.Length;

            triplet.find3Numbers(A, arr_size, sum);
        }
    }
}
