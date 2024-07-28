using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.SortingAlgorithms
{
	internal class InserionSort
	{

        /*Вмъква елементи от несортираната част на списъка в сортираната, един по един им намира място, започваме от 2 елемент, проверяваме дали е по-голям от първия, ако не ги разменяме, после вземаме третия сразнямваме с втори ако е по малък третия от втория разменяме и после сравняваме с първия
         Първа итерация=> 23 1 10 5 2 => 23 1 10 5 2
        Втора итерация => 23 1 10 5 2 => 1 23 10 5 2 
        Трета итерация => 1 23 10 5 2  => 1 10 23 5 2  
        Четвърта итерация => 1 10 23 5 2 => 1 5 10 23 2
        Пета итерация => 1 5 10 23 2 => 1 2 5 10 23
        Number of comparisons: (n-1) + (n-2) + (n-3) + ... + 1   
        Time Complexity: O(N2)
        Best carse: O(N^2) if its already sorted
        Worst carse: O(N^2)
        stable
        int[] arr1 = { 23, 1, 10, 5, 2 };
        int n = arr1.Length;

        NormalInsertionSort(arr1, n);
        int swaps = CountInsertionSortSwaps(arr1, n);*/


        private static int CountInsertionSortSwaps(int[] arr1, int n)
        {
			int swaps = 0;
			for (int i = 1; i < n; i++)
			{
				int key = arr1[i];
				int j = i - 1;
				while (arr1[j] <= key && j >= 0 )
				{
					arr1[j + 1] = arr1[j];
					j = j - 1;
					swaps++;
				}
				arr1[j + 1] = key;
			}
			return swaps;
        }

        private static void NormalInsertionSort(int[] arr1, int n)
		{
			for (int i = 1; i < n; i++)
			{
				int key = arr1[i];
				int j = i - 1; //last element of sorted aray
				while (j >= 0 && arr1[j] > key)
				{
					arr1[j + 1] = arr1[j];
					j = j - 1;
				}
				arr1[j + 1] = key;
			}
		}
	}
}
