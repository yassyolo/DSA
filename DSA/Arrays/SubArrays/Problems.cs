using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA.Arrays.SubArrays
{
    internal class Problems
    {
        /*static void Main(string[] args)
        {
            /*Problem1
            int[] arr = { 1, 2, 3, 4, 5, 5 };
            SplitArrIntoTwoEqualSumSubArrays(arr);*/
            /*Problem2=>Given an array of both positive and negative integers and a number K., The task is to check if any subarray with product K is present in the array or not.
            int[] arr = { -2, -1, 3, -4, 5 };
            int K = 2;
            CheckIfSubarrayWithProductExists(arr2, K);*/
            /*Problem3=>Given an array arr[], an integer K and a Sum. The task is to check if there exists any subarray with K elements whose sum is equal to the given sum. If any of the subarray with size K has the sum equal to the given sum then print YES otherwise print NO.
            int[] arr = { 1, 4, 2, 10, 2, 3, 1, 0, 20 };
            int k = 4;
            int sum = 18;
            SubarrayOfSizeKWithGivenSum(arr, k, sum);*/
            /*Problem4=>Given an array of N numbers where a subarray is sorted in descending order and rest of the numbers in the array are in ascending order. The task is to sort an array where a subarray of a sorted array is in reversed order. 
            int[] arr = { 2, 5, 65, 55, 50, 70, 90 };
            SortArrayWhereSubarrayIsReversed(arr);
            //Problem5=>Given an array of N integers and a number K, the task is to find the number of subarrays such that all elements are greater than K in it. 
            int[] arr = { 3, 4, 5, 6, 7, 2, 10, 11 };
            int K = 5;
            CountSubarraysWithElementsGreaterThanK(arr, K);
            //Problem6=>Find Subarray with given Sum from Array of non-negative Numbers-Given a 1 - based indexing array arr[] of non - negative integers and an integer sum.You mainly need to return the left and right indexes(1 - based indexing) of that subarray.In case of multiple subarrays, return the subarray indexes which come first on moving from left to right.If no such subarray exists return an array consisting of element -1.
            int[] arr = { 15, 2, 4, 8, 9, 5, 10, 23 };
            int sum = 23;
            FindSubarrayWithSumFromArray(arr, sum);
        }*/

        private static void FindSubarrayWithSumFromArray(int[] arr, int sum)
        {
            int startIndex = 0;
            int endIndex = 0;
            var result = new int[2];
            for (int i = 0; i < arr.Length; i++)
            {
                int currSum = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    currSum += arr[j];
                    if (currSum == sum)
                    {
                        result[0] = i + 1;
                        result[1] = j + 1;
                    }
                    else if (currSum > sum)
                    {
                        break;
                    }
                }
                currSum = 0;
            }
            Console.WriteLine(string.Join(" ", result));
        }

        private static void CountSubarraysWithElementsGreaterThanK(int[] arr, int k)
            {
                var subarrayCnt = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > k)
                    {
                    
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[j] > k)
                        {
                            subarrayCnt++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > k)
                {
                    subarrayCnt++;
                }
            }
        }

        private static void SortArrayWhereSubarrayIsReversed(int[] arr)
        {
            int startIndex = 0;
            int endIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    var temp = i;
                    startIndex = i;
                    while (arr[i] > arr[i + 1])
                    {
                        endIndex = startIndex + 1;
                        startIndex++;
                        i++;
                    }
                    startIndex = temp;
                    break;
                }
            }
            while (startIndex < endIndex)
            {
                var temp = arr[startIndex];
                arr[startIndex] = arr[endIndex];
                arr[endIndex] = temp;
                startIndex++;
                endIndex--;
            }           
        }

        private static bool SubarrayOfSizeKWithGivenSum(int[] arr, int k, int sum)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int currentSum = arr[i];
                int subArrayElementCount = 1;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    currentSum+= arr[j];
                    subArrayElementCount++;
                    if (currentSum == sum && subArrayElementCount == k)
                    {
                        return true;
                    }
                    else if (currentSum > sum)
                    {
                        break;
                    }
                }
                
            }
            return false;
        }

        private static int CheckIfSubarrayWithProductExists(int[] arr, int k)
        {
            int product = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    product *= arr[i];
                    if (product == k)
                    {
                        return i + 1;
                    }
                }
            }
            return - 1;
        }
        private static void SplitArrayToSubarrayWithEqualSum(int[] arr, int n)
        {
            if (n == -1)
            {
                Console.WriteLine("Not possible");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            for (int i = n; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        private static void SplitArrIntoTwoEqualSumSubArrays(int[] arr)
        {
            int leftSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                leftSum += arr[i];
                int rightSum = 0;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    rightSum += arr[j];
                    if (leftSum == rightSum)
                    {
                        SplitArrayToSubarrayWithEqualSum(arr, i + 1);
                        return;
                    }
                }
            }
            SplitArrayToSubarrayWithEqualSum(arr, -1);
        }
    }
}
