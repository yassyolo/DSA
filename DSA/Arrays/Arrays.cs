using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Arrays
{
    public class Arrays
    {
        //Linear data structure, elements are of the same type, stored in contiguous memry locations,
        //the idea is to represent a lot of implementations in a single variable
        //static array-memroy is alocated compile time-int[] arr = { 1, 2, 3 };
        //dynamic array-not fixed size, run-time memory allocation
        //O(N) of inserion, deletion
        //O(N) of traversial, seraching
        //Advantages-random access to any element
        //Disadvantages-fiex size, only one type of elements are stored(homogenous)
       /* static void Main(string[] args)
        {
            //Reverse Arrays-O(N)
            int[] arr = { 1, 2, 3, 4, 5 };
            //using extra array-O
            ReverseArrayExtraArray(arr);
            //using while loop-O
            ReverseUsingLoop(arr, 0, arr.Length - 1);
            //using recursion-O
            RecursiveReverseArray(arr, 0, arr.Length - 1);
            //using stack-O
            ReverseUsingStack(arr);
            //using built-in function
            Array.Reverse(arr);
            //Find Min and Max in array
            //using built-in function-O(NlogN)
            MinMaxUsingArraySort(arr);
            //using build-in math functions-O(N)
            MinMaxUsingMath(arr);
            MinMaxUsingMath2(arr);
            //Problem1=>Move all negative numbers to beginning and positive to end 
            int[] arr2 = { -12, 11, -13, -5, 6, -7, 5, -3, -6 };
            //O(NlogN)
            Array.Sort(arr2); 
            MoveNegativeNumbersToBeginningAndPositiveToEndWithStack(arr2);
            //O(N)
            MoveNegativeNumbersToBeginningAndPositiveToEndWithLoops(arr2, 0, arr.Length-1);
            //Problem2=>Find a peak element which is not smaller than its neighbours
            int[] arr3 = { 5, 10, 20, 15 };
            //O(N)
            FindPeakElementNotSmallerThanNeighbours(arr3);
            //ToDo:BinarySearch
            //Problem3=>Given an array A[] consisting of only 0s, 1s, and 2s. The task is to sort the array, i.e., put all 0s first, then all 1s and all 2s in last.
            int[] arr4 = { 1, 0, 2, 0, 1, 2};
            //O(2N)
            SortArrayOf0_1And2FirstApproach(arr4);
            //Dutch National Flag Algorithm
            int[] arr5 = { 1, 0, 2, 0, 1, 2 };
            SortArrayOf0_SutchNationalFlagAlgorithm(arr5);
            //Problem4=>Given a sorted array arr[] of size N and a number X, you need to find the number of occurrences of X in given array.
            int N = 7;
            int X = 2;
            int[] arr6 = { 1, 1, 2, 2, 2, 2, 3 };
            //O(N)
            CountOccurrencesInArrayLinearSearch(arr6, N, X);
            //ToDo:BinarySearch
            //Problem5=>Union and Intersection of two sorted arrays
            int[] arr7 = { 1, 3, 4, 5, 7 };
            int[] arr8 = { 2, 3, 5, 6 };
            //O(m*log(m) + n*log(n))
            UnionWithSortedSet(arr7, arr8);
            //O(m*log(m) + n*log(n))
             UnionWithDictionary(arr7, arr8);
            //O(m*log(m) + n*log(n))
            IntersectionWithSortedSet(arr7, arr8);
            IntersectionWithDictionary(arr7, arr8);
            //Problem6=>Given an array with all distinct elements, find the largest three elements.
            int[] arr9 = { 10, 4, 3, 50, 23, 90 };
            FindLargest3DistinctElementsInArray(arr9);
            //Problme7=>Given an array of integers, our task is to write a program that efficiently finds the second-largest element present in the array.
            FindLargest2NDistinctElementsInArray(arr9);
            FindLargest2NDistinctElementsInArrayAnother(arr9);
            //problem8=>Given an array of random numbers, Push all the zero’s of a given array to the end of the array. For example, if the given arrays is {1, 9, 8, 4, 0, 0, 2, 7, 0, 6, 0}, it should be changed to {1, 9, 8, 4, 2, 7, 6, 0, 0, 0, 0}. The order of all other elements should be same. Expected time complexity is O(n) and extra space is O(1).
            int[] arr10 = { 1, 2, 0, 4, 3, 0, 5, 0 };
            MoveZeroesToEndOfArray(arr10);
            //Problem9=>Write a program to print all the Leaders in the array. An element is a Leader if it is greater than all the elements to its right side.
            int[] arr11 = { 16, 17, 4, 3, 5, 2 };
            LeadersInArrayWithFlag(arr11);
            LeadersInArrayWithLeftToRighTraversal(arr11);
            //Problem10=>Given an array of integers. All numbers occur twice except one number which occurs once. Find the number in O(n) time & constant extra space.
            int[] arr12 = { 2, 3, 5, 4, 5, 3, 4 };
            FindElementThatAppearsOnceWithMap(arr12);
            FindElementThatAppearsOnceBruteForce(arr12);
            //Problem11=>Given an unsorted array of positive integers, find the number of triangles that can be formed with three different array elements as three sides of triangles. For a triangle to be possible from 3 values, the sum of any of the two values (or sides) must be greater than the third value (or third side). 
            int[] arr13 = { 4, 6, 3, 7 };
            CountNumberOfPossibleTriangles(arr13);
            //Problem12=>You have given an array which contain 1 to n element, your task is to sort this array in an efficient way and without replace with 1 to n numbers.
            int[] arr14 = { 10, 7, 9, 2, 8, 3, 5, 4, 6, 1 };
            //O(N)
            SortArrayWhichContains1ToNValues(arr14);
            //Problem13=>Given an array arr[] of integers, segregate even and odd numbers in the array such that all the even numbers should be present first, and then the odd numbers.
            int[] arr15 = { 7, 2, 9, 4, 6, 1, 3, 8, 5 };
            SegregateEvenAndOddNumbers(arr15);
        }*/

        private static void SegregateEvenAndOddNumbers(int[] arr)
        {
            int i = 0;
            int j = -1;
            while (i < arr.Length)
            {
                if (arr[i] % 2 == 0)
                {
                    i++;
                    var temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
                j++;
            }
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void SortArrayWhichContains1ToNValues(int[] arr)
        {
            int i = 0;
            while (i < arr.Length)
            {
                int currentEndIndex = arr[i] - 1;
                if (arr[currentEndIndex] != arr[i])
                {
                    Swap(ref arr[i], ref arr[currentEndIndex]);
                }
                else
                {
                    i++;
                }
            }
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Swap(ref int x, ref int y)
        {
            var temp = x;
            x = y;
            y = temp;
        }

        private static void CountNumberOfPossibleTriangles(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if (arr[i] + arr[j] > arr[k] && arr[i] + arr[k] > arr[j] && arr[j] + arr[k] > arr[i] )
                        {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }

        private static void FindElementThatAppearsOnceBruteForce(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int cnt = 1;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        cnt++;
                    }
                }

                if (cnt == 1)
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }

        private static void FindElementThatAppearsOnceWithMap(int[] arr)
        {
            Dictionary<int, int> map = new();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!map.ContainsKey(arr[i]))
                {
                    map[arr[i]] = 1;
                }
                else
                {
                    map[arr[i]]++;
                }
            }
            Console.WriteLine(map.FirstOrDefault(x => x.Value == 1).Key);
        }

        private static void LeadersInArrayWithLeftToRighTraversal(int[] arr)
        {
            var rightLeader = arr[arr.Length - 1];

            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] > rightLeader)
                {
                    Console.Write(rightLeader + " ");
                    rightLeader = arr[i];
                }   
            }
            Console.Write(rightLeader);
            Console.WriteLine();
        }

        private static void LeadersInArrayWithFlag(int[] arr)
        {
            bool isLeader = true;
            for (int i = 0; i < arr.Length; i++)
            {
                int curr = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (curr < arr[j])
                    {
                        isLeader = false;
                        break;
                    }
                    isLeader = true;
                }
                if (isLeader)
                {
                    Console.Write(curr + " ");
                }
            }
            Console.WriteLine();
        }

        private static void MoveZeroesToEndOfArray(int[] arr)
        {
            int nonZeroElementsCnt = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    arr[nonZeroElementsCnt] = arr[i];
                    nonZeroElementsCnt++;
                }
            }
            for (int i = nonZeroElementsCnt; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void FindLargest2NDistinctElementsInArrayAnother(int[] arr)
        {
            int largest = arr[0];
            int second = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                int curr = arr[i];
                if (curr > largest)
                {
                    second = largest;
                    largest = curr;                    
                }
                else if (curr > second)
                {
                    second = curr;
                }
            }
            Console.WriteLine(second);
        }

        private static void FindLargest2NDistinctElementsInArray(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr.OrderByDescending(x => x).Skip(1).Take(1)));
        }

        private static void FindLargest3DistinctElementsInArray(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr.OrderByDescending(x => x).Take(3))); 
        }

        private static void IntersectionWithDictionary(int[] arr1, int[] arr2)
        {
            Dictionary<int, int> kvps = new();
            for (int i = 0; i < arr1.Length; i++)
            {
                if (!kvps.ContainsKey(arr1[i]))
                {
                    kvps.Add(arr1[i], 1);
                }
                else
                {
                    kvps[arr1[i]]++;
                }
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                if (!kvps.ContainsKey(arr2[i]))
                {
                    kvps.Add(arr2[i], 1);
                }
                else
                {
                    kvps[arr2[i]]++;
                }
            }
            foreach (var kvp in kvps)
            {
                if (kvp.Value > 1)
                {
                    Console.Write(kvp.Key + " ");
                }
            }
            Console.WriteLine();
        }

        private static void IntersectionWithSortedSet(int[] arr1, int[] arr2)
        {
            SortedSet<int> set = new();
            List<int> result = new();
            for (int i = 0; i < arr1.Length; i++)
            {
                set.Add(arr1[i]);
            }
            for (int j = 0; j < arr2.Length; j++)
            {
                if (set.Contains(arr2[j]))
                {
                    result.Add(arr2[j]);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }

        private static void UnionWithDictionary(int[] arr1, int[] arr2)
        {
            SortedDictionary<int, int> kvps = new();
            foreach (var el in arr1)
            {
                if (!kvps.ContainsKey(el))
                {
                    kvps.Add(el, 1);
                }
                else
                {
                    kvps[el]++;
                }
                
            }
            foreach (var el in arr2)
            {
                if(!kvps.ContainsKey(el))
                {
                    kvps.Add(el, 1);
                }
                else
                {
                    kvps[el]++;
                }
            }
            foreach (var kvp in kvps)
            {               
                Console.Write(kvp.Key + " ");                
            }
            Console.WriteLine();
        }

        private static void UnionWithSortedSet(int[] arr1, int[] arr2)
        {
            SortedSet<int> set = new();
            for (int i = 0; i < arr1.Length; i++)
            {
                set.Add(arr1[i]);
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                set.Add(arr2[i]);
            }
            Console.WriteLine(string.Join(" ", set));
        }

        private static int CountOccurrencesInArrayLinearSearch(int[] arr6, int n, int x)
        {
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr6[i] == x)
                {
                    cnt++;
                }
            }
            return cnt;
        }

        private static void SortArrayOf0_SutchNationalFlagAlgorithm(int[] arr)
        {
            int startIndex = 0;
            int midIndex = 0;
            int endIndex = arr.Length - 1;
            int temp = 0;

            while (midIndex <= endIndex)
            {
                switch (arr[midIndex])
                {
                    case 0:
                        temp = arr[startIndex];
                        arr[startIndex] = arr[midIndex];
                        arr[midIndex] = temp;
                        startIndex++;
                        midIndex++;
                        break;
                    case 1:
                        midIndex++;
                        break;
                    case 2:
                        {
                            temp = arr[midIndex];
                            arr[midIndex] = arr[endIndex];
                            arr[endIndex] = temp;
                            endIndex--;
                        }
                        break;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        private static void SortArrayOf0_1And2FirstApproach(int[] arr)
        {
            int zeros = 0;
            int ones = 0;
            int twos = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                switch (arr[i])
                {
                    case 0:
                        zeros++;
                        break;
                    case 1:
                        ones++;
                        break;
                    case 2:
                        twos++;
                    break;
                }
            }
            int index = 0;
            for (int i = 0; i < zeros; i++)
            {
                arr[index++] = 0;
            }
            for (int i = 0; i < ones; i++)
            {
                arr[index++] = 1;
            }
            for (int i = 0; i < twos; i++)
            {
                arr[index++] = 2;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        private static int FindPeakElementNotSmallerThanNeighbours(int[] arr)
        {
            if (arr.Length == 1)
            {
                return 0;
            }
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[i + 1] && arr[i] > arr[i - 1] && i < arr.Length)
                {
                    return arr[i];
                }
            }
            return 0;
        }

        private static void MoveNegativeNumbersToBeginningAndPositiveToEndWithLoops(int[] arr, int startIndex, int endIndex)
        {
            while (startIndex > endIndex)
            {
                if (arr[startIndex] > arr[startIndex + 1])
                {
                    var temp = arr[startIndex];
                    arr[startIndex] = arr[endIndex];
                    arr[endIndex] = temp;
                    startIndex++;
                    endIndex--;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        private static void MoveNegativeNumbersToBeginningAndPositiveToEndWithStack(int[] arr)
        {
            Stack<int> stack1 = new();
            Stack<int> stack2 = new();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    stack1.Push(arr[i]);
                }
                else
                {
                    stack2.Push(arr[i]);
                }
            }
            Console.Write(string.Join(" ", stack1));
            Console.Write(string.Join(" ", stack2));
            Console.WriteLine();
        }

        private static void MinMaxUsingMath2(int[] arr)
        {
            var min = FindMin(arr,0, arr.Length);
            var max = FindMax(arr,0, arr.Length);
            Console.WriteLine($"min-{min} max-{max}");
        }

        private static int FindMin(int[] arr,int startIndex, int endIndex)
        {
            return (endIndex == 1) ? arr[startIndex] : Math.Min(arr[startIndex], FindMin(arr, startIndex + 1, endIndex - 1));
        }
        private static int FindMax(int[] arr, int startIndex, int endIndex)
        {
            return (endIndex == 1) ? arr[startIndex] : Math.Max(arr[startIndex], FindMax(arr, startIndex + 1, endIndex - 1));
        }

        private static void MinMaxUsingMath(int[] arr)
        {
            int resMin = arr[0];
            int resMax = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                resMin = Math.Min(resMin, arr[i]);
                resMax = Math.Max(resMax, arr[i]);
            }
            Console.WriteLine($"min-{resMin} max-{resMax}");
        }

        private static void MinMaxUsingArraySort(int[] arr)
        {
            Array.Sort(arr);
            Console.WriteLine($"min-{arr[0]} max-{arr[arr.Length - 1]}");
        }

        private static void ReverseUsingStack(int[] arr)
        {
            Stack<int> stack = new();
            foreach (var el in arr)
            {
                stack.Push(el);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine();
        }

        private static void RecursiveReverseArray(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }
            
            var temp = arr[startIndex];
            arr[startIndex] = arr[endIndex];
            arr[endIndex] = temp;
            RecursiveReverseArray(arr, startIndex + 1, endIndex - 1);

        }

        private static void ReverseUsingLoop(int[] arr, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                var temp = arr[startIndex];
                arr[startIndex] = arr[endIndex];
                arr[endIndex] = temp;
                startIndex++;
                endIndex--;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        private static void ReverseArrayExtraArray(int[] arr)
        {
            int[] reversedArray = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                reversedArray[i] = arr[arr.Length - 1 - i];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(reversedArray[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
