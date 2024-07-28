using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Strings
{
    public class Substrings
    {
        /*static void Main(string[] args)
        {
            //part of a string, string inside of striing
            //n*(n+1)/2 substrings in a string
            //Problme1=>Suppose we are given a string s1, we need to the find total number of substring(including multiple occurrences of the same substring) of s1 which are present in string s2. 
            string s1 = "aab";
            string s2 = "aaaab";
            NumberOfSubstringsOfStringPresentInAnother(s1, s2);
            //Problem2=>Given an integer N, the task is to print all the substring of N 
            int N = 12345;
            PrintSubstringsOfNumber(N);
            //Problem3=>Given string str, the task is to repeat every substring of the string X number of times where X is the number composed of the consecutive digits present just after the substring in the original string. 
            string str ="g1ee1ks1for1g1e2ks1";
            RepeatSubstringsOfStringRequiredNumberOfTimes(str);
            //Problem4=>Given string str, the task is to print the pattern given in the examples below: Input: str = “geeks” Output: geeks *kee* **e**
            string str2 = "geeks" ;
            SubstringReversePattern(str2);
            //Problem5=>Given a string ‘S’ (composed of digits) and an integer ‘X”, the task is to count all the sub-strings of ‘S’ that satisfy the following conditions: The sub-string must not begin with the digit ‘0’.And the numeric number it represents must be greater than ‘X’.
            string S = "471";
            int X = 47;
            CountNumberOfSubstringsWithValueGreaterThanX(S, X);
            //Problem6=>Given a string str and an integer N, the task is to find the number of possible sub-strings of length N.
            string str3 = "geeksforgeeks";
            int n = 5;
            CountOfSubstringsOfLengthN(str3, n);
        }*/

        private static void CountOfSubstringsOfLengthN(string str, int n)
        {
            int cnt = 0;
            for (int i = 0; i < str.Length; i++)
            {
                var result = str[i].ToString();
                int currCharCnt = 1;
                for (int j = i + 1; j < str.Length; j++)
                {
                    result += str[j].ToString();
                    currCharCnt++;
                    if (currCharCnt == n)
                    {
                        cnt++;
                    }
                }
            }
            Console.WriteLine(cnt);
        }

        private static void CountNumberOfSubstringsWithValueGreaterThanX(string s, int x)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var current = s[i].ToString();
                if (int.Parse(current) > x)
                {
                    count++;
                }
                for (int j = i + 1; j < s.Length; j++)
                {
                    current += s[j].ToString();
                    if (int.Parse(current) > x)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }

        private static void SubstringReversePattern(string str)
        {
            char[] result = str.ToCharArray();
            int i = 0;
            int n = result.Length - 1;
            Console.WriteLine(str);
            while (n / 2 > 0)
            {
                var temp = result[i];
                result[i] = result[n];
                result[n] = temp;
                i++;
                n--;                
            }
            i = 0;
            n = result.Length - 1;
            int endIndex = n;
            for (i = 0; i < n; i++)
            {
                if (i != n /2)
                {
                    result[i] = '*';
                    result[endIndex] = '*';
                    Console.WriteLine(result);
                    endIndex--;
                }
                
            }
        }

        private static void RepeatSubstringsOfStringRequiredNumberOfTimes(string str)
        {          
            string result = string.Empty;
            if (IsDigit(str[0]))
            {
                str = str.Substring(1);
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (IsDigit(str[i]))
                {
                    int value = int.Parse(str[i].ToString());
                    while (value > 0)
                    {
                        result += str[i - 1].ToString();
                        value--;
                    }
                }
                else if (!IsDigit(str[i]) && !IsDigit(str[i + 1]))
                {
                    result += str[i].ToString();
                }
            }
            Console.WriteLine(result);
        }

        private static bool IsDigit(char c)
        {
            return c >= '0' && c < '9';
        }

        private static void PrintSubstringsOfNumber(int n)
        {
            string s = n.ToString();
            for (int i = 0; i < s.Length; i++)
            {
                var current = s[i].ToString();
                Console.Write(current + " ");
                for (int j = i+1; j < s.Length; j++)
                {
                    current += s[j].ToString();
                    Console.Write(current + " ");
                }
            }
            Console.WriteLine();
        }

        private static void NumberOfSubstringsOfStringPresentInAnother(string s1, string s2)
        {
            Dictionary<string, int> map = new();
            for (int i = 0; i < s1.Length; i++)
            {
                var currentString = s1[i].ToString();
                if (!map.ContainsKey(currentString))
                {
                    map[currentString] = 1;
                }
                else
                {
                    map[currentString]++;
                }
                for (int j = i + 1; j < s1.Length; j++)
                {
                    currentString += s1[j];
                    if (!map.ContainsKey(currentString))
                    {
                        map[currentString] = 1;
                    }
                    else
                    {
                        map[currentString]++;
                    }
                }
            }
            int cnt = 0;
            foreach (var item in map)
            {
                if (s2.Contains(item.Key))
                {
                    int value = item.Value;
                    while(value > 0)
                    {
                        cnt++;
                        value--;
                    }
                }                
            }
            Console.WriteLine(cnt) ;
        }
    }
}
