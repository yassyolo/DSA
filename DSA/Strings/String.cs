using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DSA.Strings
{
    public class String
    {
        /*static void Main(string[] args)
        {
            //string is a sequence/array of characters that represent text, used for storing and manipulating textual data
            //sequence of unicode characters, sequental connection of system.char characters, represented by 
            //class system.string, max size is 2GB or about 1 billion characters
            // it is immutable, overloads ==, reference type
            //Problem1=>Given a string of size n, write functions to perform the following operations on a string-Left(Or anticlockwise) rotate the given string by d elements(where d <= n) Right(Or clockwise) rotate the given string by d elements(where d <= n).
            string s = "GeeksforGeeks";
            int d = 2;
            //O(N)
            Console.WriteLine(s.Substring(d, s.Length - d) + s.Substring(0, d));
            Console.WriteLine(s.Substring(s.Length - d) + s.Substring(0, s.Length - d));
            //Problme2=>Given a string of lowercase characters from ‘a’ – ‘z’. We need to write a program to print the characters of this string in sorted order.
            string s2 = "bbccdefbbaa";
            //O(nlogn)
            char[] s2AsCharArray = s2.ToCharArray();
            Array.Sort(s2AsCharArray);
            Console.WriteLine(string.Join("", s2AsCharArray));
            //Problem3=>Given a string str, the task is to print the frequency of each of the characters of str in alphabetical order.
            string str = "aabccccddd";
            //Todo
            //PrintFrequencyOfEachCharacterInAlphabeticalOrder(str);
            PrintFrequencyOfEachCharacterInAlphabeticalOrderWithMap(str);
            //Problem4=>Given a String S of length N, two integers B and C, the task is to traverse characters starting from the beginning, swapping a character with the character after C places from it, i.e. swap characters at position i and (i + C)%N. Repeat this process B times, advancing one position at a time. Your task is to find the final String after B swaps.
            string S = "ABCDEFGH";
            int B = 4;
            int C = 3;
            SwapCharactersInString(S, B, C);
            //Problem5=>Given a string str and an array of indices chars[] that describes the indices in the original string where the characters will be added. For this post, let the character to be inserted in star (*). Each star should be inserted before the character at the given index. Return the modified string after the stars have been added.
            string str2 = "geeksforgeeks";
            int[] chars = {1, 5, 7, 9};
            InsertCharactersInStringAtCertainPosition(str2, chars);
        }*/

        private static void InsertCharactersInStringAtCertainPosition(string str, int[] chars)
        {
            string result = string.Empty;
            int startIndex = 0;

            foreach (var item in chars)
            {
                int currIndex = item;
               
                if (startIndex == 0)
                {
                    for (int i = 0; i < currIndex; i++)
                    {
                        result += str[i].ToString();
                        startIndex++;
                    }
                    result += "*";
                }
                else if (startIndex != currIndex)
                {
                        for (int i = startIndex; i < currIndex; i++)
                        {
                            result += str[i].ToString();
                            startIndex++;
                        }
                        result += "*";
                }                  
            }            
            Console.WriteLine(result);
        }

        private static void SwapCharactersInString(string s, int b, int c)
        {
            char[] arr = s.ToCharArray();
            for (int i = 1; i <= b; i++)
            {             
                for (int j = 0; j < arr.Length; j++)
                {
                    int startIndex = j;
                    var temp = arr[startIndex];
                    arr[startIndex] = arr[c];
                    arr[c] = temp;
                    Console.Write(string.Join("",arr) + " ");
                    c++;
                    break;
                }
            }
            Console.WriteLine();
        }

        private static void PrintFrequencyOfEachCharacterInAlphabeticalOrderWithMap(string str)
        {
            Dictionary<string, int> map = new();
            foreach (var c in str)
            {
                if (!map.ContainsKey(c.ToString()))
                {
                    map[c.ToString()] = 1;
                }
                else
                {
                    map[c.ToString()]++;
                }
            }
            string result = string.Empty;
            foreach (var item in map)
            {
                result += $"{item.Key}{item.Value}";
            }
            Console.WriteLine(result);
        }
    }
}
