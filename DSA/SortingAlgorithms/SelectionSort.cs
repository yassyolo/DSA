using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DSA.SortingAlgorithms
{
	public class SelectionSort
	{
			/*Избира се най-големия или най-малкия елемент от несортираната част и се премества в сортираната част катого размеря с първия елемент от несортираната част
			 Първа итерация=> 64 25 12 22 11 => 11 25 12 22 64-започваме със 64 обхождаме целия масив и откриваме че 11 е най малкото и ги разместваме
			Втора итерация => 64 25 12 22 11 => 11 12 25 22 64 - започваме със втората позиция 25, обхождаме целия масив и виждаме че 12 е най малкото и ги разменяме
			Трета итерация => 11 12 25 22 64 => 11 12 22 25 64 -започваме с трета позицуя 25, обхождаме масива и разменяме с 22
			Четвърта итерация => 11 12 22 25 64
			Number of comparisons: (n-1) + (n-2) + (n-3) + ... + 1   
			Time Complexity: O(N2)
			Best carse: O(N^2) if its already sorted
			Worst carse: O(N^2)
			unstable
			int[] arr1 = { 64 ,25 ,12 ,22, 11 };
			int n = arr1.Length;

			NormalSelectionSort(arr1, n);
			PrintArray(arr1, n);
			int[] arr2 = { 5, 1, 4, 2, 8 };
			int n2 = arr2.Length;
			RecursiveSelectionSort(arr2, n2, 0);*/
		

		private static void RecursiveSelectionSort(int[] arr, int n, int index)//starting index
		{
			if (index == n)
			{
				return;
			}
			int minIndex = FindMinimumIndex(arr, index, n - 1);
			if (minIndex != index)
			{
				int temp = arr[minIndex];
				arr[minIndex] = arr[index];
				arr[index] = temp;
			}
			RecursiveSelectionSort(arr, n, index + 1);
		}

		private static int FindMinimumIndex(int[] arr, int i, int j)
		{
			if (i == j)
			{
				return i;
			}
			int k = FindMinimumIndex(arr, i + 1, j);
			return (arr[i] < arr[k]) ? i : k;
		}

		private static void NormalSelectionSort(int[] arr1, int n)
		{
			for (int i = 0; i < n - 1; i++)
			{
				int minIndex = i;
				for (int j = i + 1; j < n; j++)
				{
					if (arr1[j] < arr1[i])
					{
						minIndex = j;
					}
					int temp = arr1[minIndex];
					arr1[minIndex] = arr1[i];
					arr1[i] = temp;
				}
			}			
		}

		static void PrintArray(int[] arr, int n)
		{
			for (int i = 0; i < n; i++)
			{
				Console.Write(arr[i] + " ");
			}
			Console.WriteLine();
		}
	}
}
