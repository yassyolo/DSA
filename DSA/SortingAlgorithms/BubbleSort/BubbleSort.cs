



public class BubbleSort
{
		/*разменя съседни елементи, ако са в грешен ред, щпочва се от ляво като се проверява съседния дали не е по голям, най големия елемент отива най в дясно и така се правят няколко итерациии, като всяка следваща започва с резултата от първата
		 Първа итерация=> 6 0 3 5 =>0 6 3 5=> 0 3 6 5 => 0 3 5 6
		Втора итерация => 0 3 5 6=> 0 3 5 6 => 0 3 5 6
		Трета итерация => 0 3 5 6 => 0 3 5 6
		Общ брой итерации: n*(n-1)/2
		Time Complexity: O(N2)
		Best carse: O(N) if its already sorted*/
		/*int[] arr1 = { 5, 1, 4, 2, 8 };
		int n = arr1.Length;

		NormalBubbleSort(arr1, n);
		PrintArray(arr1, n);
		int[] arr2 = { 5, 1, 4, 2, 8 };
		int n2 = arr2.Length;
		RecursiveBubbleSort(arr2, n2);
		string[] arr3 = { "abcd", "abc", "acccc", "cd", "a"};
		int n3 = arr3.Length;
		StringBubbleSort(arr3, n3);*/
	

	static void StringBubbleSort(string[] arr, int n)
	{
		for (int i = 0; i < n - 1; i++)
		{
			for (int j = i + 1; j < n; j++)
			{
				if (arr[i].CompareTo(arr[i+1]) > 0)
				{
					var temp = arr[i];
					arr[i] = arr[i + 1];
					arr[i + 1] = temp;
				}
			}
		}
	}

	static void RecursiveBubbleSort(int[] arr, int n)
	{
		if (n == 1)
		{
			return;
		}
		int count = 0;
		for (int i = 0; i < n - 1; i++)
		{
			if (arr[i] > arr[i + 1])
			{
				int temp = arr[i];
				arr[i] = arr[i + 1];
				arr[i + 1] = temp;
				count++;
			}
		}
		if (count == 0)
		{
			return;
		}
		RecursiveBubbleSort(arr, n - 1)
;	}

	static void NormalBubbleSort(int[] arr, int n)
	{
		bool swapped = false;
		//second last element
		for (int i = 0; i < n - 1; i++)
		{
			swapped = false;
			//unsorted part of the array
			for (int j = 0; j < n - i - 1; j++)
			{
				if (arr[j] > arr[j + 1])
				{
					int temp = arr[j];
					arr[j] = arr[j + 1];
					arr[j + 1] = temp;
					swapped = true;
				}
			}
		}
		if (swapped == false)
		{
			return;
		}		
	
	}


}
		
	

