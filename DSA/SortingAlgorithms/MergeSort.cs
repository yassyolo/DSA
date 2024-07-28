using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.SortingAlgorithms
{
    public class MergeSort
    {
        /*public static void Main()
        {
            /*Разделяй и владей, рекурсивно разделя масива на подмасивии ги сортира и после ги обединява
             * Разделяй: [38, 27, 43, 10] се разделя на [38, 27 ] и [43, 10] .
             [38, 27] е разделен на [38] и [27] .
             [43, 10] е разделен на [43] и [10] .
              Владей:
             [38] вече е сортиран.
             [27] вече е сортиран.
             [43] вече е сортиран.
             [10] вече е сортиран.
            Обединяване:
             Обединете [38] и [27], за да получите [27, 38] .
             Обединете [43] и [10], за да получите [10,43] .
             Обединете [27, 38] и [10,43], за да получите окончателния сортиран списък [10, 27, 38, 43]
			Time Complexity: O(N2)
			Best carse: O(N^2) if its already sorted
			Worst carse: O(N^2)
			stable
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            int n = arr.Length;

            SortArray(arr, 0, arr.Length - 1);//arr, first el, last el
        }*/

        private static void SortArray(int[] arr, int l, int r) //find the middle point, sort the first and the second half and merge them
        {
            if (l < r)
            {
                int m = l + (r - 1) / 2; //find the middle point

                SortArray(arr, l, m);//sort the first half
                SortArray(arr, m + 1, r);//sort the second half

                MergeSortArray(arr, r, m, l); // Merge the sorted halfs
            }
        }

        private static void MergeSortArray(int[] arr, int r, int m, int l)
        {
            int i, j;
            int n1 = m - l + 1; // size of the first subarray
            int n2 = r - m; //size of the second subArray

            int[] L = new int[n1];//to hold the subarrays
            int[] R = new int[n2];

            for (i = 0; i < n1; i++)
            {
                L[i] = arr[l + 1];
            }
            for (j = 0; j < n2; j++)
            {
                R[j] = arr[m + 1 + i];
            }
            // Initial indexes for merging
             i = 0; // Initial index of the first subarray
             j = 0; // Initial index of the second subarray
            int k = l; // Initial index of the merged array
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
            }
            // Copy the remaining elements of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy the remaining elements of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
    }
}
