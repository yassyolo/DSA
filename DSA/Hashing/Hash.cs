using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA.Hashing
{
    public class Hash
    {
        /*static void Main(string[] args)
        {
            //is a technique in data structurs that stores and receives data with quick access, it works through a hash function
            //that maps the data to a specific index and stores it in hash table and then retrieves the information
            //through a key, optimizes search and retrieval
            //hashing is a technique used to store and retrieve data efficiently, it uses a hash function to map data 
            //to fixed size arrays called hash tables
            //hash table(map) is data structure that holds key-value pair items, it uses a hash function to map keys to
            //fixed size arrays
            //hash function takes a key and returns an index to the hash table, the goal is to distribute keys evenly
            //thorught the hash table and to minimize collisions(when 2 keys map to the same index)
            //hash function includes:
            //=>division method => key % hash table size
            //=>multiplication method=> (key * constant) % hashtable size
            //hash collisions is when 2 keys are mapped to the same index in the hash table
            //causes => 1)poor hash functions=> a function that does not distribute the keys evently
            //2)high load factor=> ratio of keys to hash table size
            //3)similar keys
            //collision resolution techniques=>1)open addressing=> 1-linear probing-search for an empty slot sequentally
            //2-quadratic probing-search for an empty slot using quadratic function
            //2)closed addressing=> 1-chaining-store colliding keys in linked list or binary serach index at each index
            //2-cuckoo hashing-use multiple hashing functions to distribute hashing
            //hashing is the process of generating a fixed size output from an input of variable size using mathematical formulas(hash functions)
            //this technique determines the index or location for the storage of the item
            //hashing involves mapping data to an index in a hash table using hash function and also provides fast retrieval based on its key
            //storing and retrieval is very efficient - O(1)
            //Properties of good hash function- a perfect one would be that the hash function maps each element into its own unique slot
            //we can achieve perfect hash function if we make the hash table with bigger size therefore it would have enough unique slots for storing the items
            //properties are: 1)efficiently computable 2) minimize colliions 2)should evenly distribute keys 4)low load factor
            //collision happens when 2 different keys map to the same value, the hashing process generates a samll values
            //for big keys so 2 different keys can produce the same value
            //collision handling techniques=>1)Open hashing(Separate chaning) 2)Closed hashing(Open addreasing)
            //Separate chaning(open hashing)-each cell of the hash table point to a linked list with records that
            //have the same hash function value, requires additional memroy
            //Advantages: key-value support(ideal fo implementing such structures), fast data retrieval at constant time
            //efficiency, memory usage reduction(fixed space for storing items), scalability, security and encryption
            //Problem1=>Given two arrays arr1[] and arr2[] of size m and n respectively, the task is to determine whether arr2[] is a subset of arr1[]. Both arrays are not sorted, and elements are distinct.
            int[] arr1 = { 11, 1, 13, 21, 3, 7 };
            int[] arr2 = { 11, 3, 7, 1 ,4};
            //O(m+n)
            Console.WriteLine(FindIfArrayIsSubsetOfAnotherArray(arr1, arr2));
            //O(m*n)
            Console.WriteLine(FindIfArrayIsSubsetOfAnotherArrayAnother(arr1, arr2));
            //Problem2=>Given an array, find the most frequent element in it. If there are multiple elements that appear a maximum number of times, print any one of them.
            int[] arr3 = { 1, 3, 2, 1, 4, 1 , 4, 4, 4, 4};
            MostFrequentElementInArray(arr3);
            //O(N2)
            MostFrequentElementInArrayAnother(arr3);
        }*/

        private static void MostFrequentElementInArrayAnother(int[] arr)
        {
            var res = arr[0];
            int maxCount = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                var currentCount = 0;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        
                        currentCount++;
                    }
                }
                if (currentCount > maxCount )
                {
                    res = arr[i];
                    maxCount = currentCount;
                }
            }
            Console.WriteLine(res);
        }

        private static void MostFrequentElementInArray(int[] arr)
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
            Console.WriteLine(map.FirstOrDefault(x => x.Value == map.Values.Max()).Key);

        }

        private static string FindIfArrayIsSubsetOfAnotherArrayAnother(int[] arr1, int[] arr2)
        {
            int count = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        count++;
                    }
                }
            }
            return count == arr2.Length ? "YES" : "NO";
        }

        private static string FindIfArrayIsSubsetOfAnotherArray(int[] arr1, int[] arr2)
        {
            HashSet<int> array = new(arr1);
            int count = 0;
            foreach (var item in arr2)
            {
                if (array.Contains(item))
                {
                    count++;
                }
            }

            return count == arr2.Length ? "YES" : "NO";
        }
    }
}
