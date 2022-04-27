using System;

namespace DotNetPrograms
{
    class QuickSortRunner
    {
        // ref: https://masterdotnet.com/csharp/algorithms/sorting-techniques-csharp/

        public static void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;

        }
        public static int Partiton(int[] array, int start, int end)
        {
            int Pivot = array[start];
            int PivotIndex = -1;
            int countLessthanPivot = 0;
            int i = 0;
            int j = 0;
            for (i = start + 1; i <= end; i++)
            {
                if (array[i] <= Pivot)
                {
                    countLessthanPivot++;
                }

            }
            PivotIndex = countLessthanPivot + start;
            Swap(array, start, PivotIndex);

            i = start;
            j = end;
            while (i < PivotIndex && j > PivotIndex)
            {
                if (array[i] <= Pivot)
                {
                    i++;
                }
                else if (array[j] > Pivot)
                {
                    j--;
                }
                else
                {
                    Swap(array, i, j);
                    i++; j--;
                }
            }

            return PivotIndex;

        }

        public static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
                return;

            int pivotIndex = Partiton(array, start, end);
            QuickSort(array, start, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, end);
        }

        static void Main(string[] args)
        {
            int[] array = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            QuickSort(array, 0, 9);

            for (int i = 0; i <= 9; i++)
            {
                Console.WriteLine(array[i]);
            }

        }
    }
}
