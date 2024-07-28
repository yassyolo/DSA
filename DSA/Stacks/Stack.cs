using DSA.SortingAlgorithms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DSA.Stacks
{
    internal class Stack
    {
        //Implementation of stack structure using array
        private int[] stack;
        private int top;
        private int max;

        public Stack(int size)
        {
            this.stack = new int[size];
            this.top = -1;
            this.max = size;
        }

        public void Push(int item)
        {
            if (top == max - 1)
            {
                throw new OverflowException("Stack is full");
            }
            else { 
                stack[++top] = item;
            }
        }
        public bool IsEmpty()
        {
            if (top == max - 1)
            {
                return true;
            }
            return false;
        }
        public void PrintStack()
        {
            foreach (var item in stack)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public int Pop()
        {
            int temp = 0;
            if (top == -1)
            {
                throw new Exception("Stack is empty");
            }
            else
            {
                temp = stack[top];
                stack[top] = default;
                top--;
            }
            return temp;
        }
        public int Peek()
        {
            if (top == -1)
            {
                throw new Exception("Stack is empty");
            }
             return stack[top];
        }
        public void Reverse()
        {
            if (top == -1)
            {
                throw new Exception("Stack is empty");
            }
            var startIndex = top;
            for (int i = 0; i < stack.Length/2; i++)
            {               
                var temp = stack[startIndex];
                stack[startIndex] = stack[i];
                stack[i] = temp;
                startIndex--;
            }
        }
       /* static void Main(string[] args)
        {
            //Linear data structure, LIFo, fixed size with array or dinamic
            //O(1) of pop(),peek(),push(), isempty()
            //Advantages - limited memory usage, easy to implement, efficient
            //Disadvantages - limited acces(only the top of the element), can cause overflow, not suitable for random access
            //Application - function calls(keep track of addresses, allowing the program to return correct location
            //Problem1=> Write a program to convert an Infix expression to Postfix form.
            var stack = new Stack(4);
            for (int i = 0; i < 4; i++)
            {
                stack.Push(i);
            }
            stack.Reverse();
            stack.PrintStack();
            string infix = "A +B * C + D";
            //O(N)
            ConvertInfixToPostfix(infix);
            //Problem2=>Given string str, we need to print the reverse of individual words.
            string input = "Hello World";
            //O(N)-space efficient
            ReverseIndividualWords(input);
            //Using String Reader-O(N)
            ReverseIndividualWordsWithStream(input);
            //O(N)
            Console.WriteLine(string.Join(" ", input.Split(' ').Select(x => new string(x.Reverse().ToArray()))));
            //Problem3=>Prefix to Infix Conversion
            string prefix = " *+AB-CD";//=>((A+B)*(C-D))
            PrefixToInfixConversion(prefix);
            //Problem4=>Given a Prefix expression, convert it into a Postfix expression. 
            PrefixToPostfixConversion(prefix);//=>AB+CD-*
            //Problem4=>Postfix to Prefix Conversion
            string postfix = "AB+CD-*";//=>*+AB-CD
            PostfixToPrefixConversion(postfix);
            //Problem5=>Postfix to Infix
            string postfix2 = "ab*c+";
            PostfixToInfix(postfix2);
            //Problem6=>Evaluation of Postfix Expression
            string postfix3 = "2 3 1 * +9 -";
            EvaluationOfPostfixExpression(postfix3);
            //Problem7=>Given an expression string exp, write a program to examine whether the pairs and the orders of “{“, “}”, “(“, “)”, “[“, “]” are correct in the given expression.
            string exp = "[()] { }{ [()()]()}";
            //Todo
            var res = CheckForBalancedBrackets(exp);
            if (res)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("NOT BALANCED");
            }
        }*/

        private static bool CheckForBalancedBrackets(string exp)
        {
            var stack = new Stack<char>();
            exp = exp.Replace(" ", "");
            for (int i = 0; i < exp.Length; i++)
            {
                char c = exp[i];
                if (c == '{' || c == '(' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == '}' || c == ')' || c == ']')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                }
                else if(!(c == '}' && stack.Pop() == '{') || !(c == ')' && stack.Pop() == '(') || !(c == ']' && stack.Pop() == '['))
                {
                    return false;
                }    
            }
            return true;
        }

        private static void EvaluationOfPostfixExpression(string postfix)
        {
            var stack = new Stack<string>();
            string str = "";
            postfix = postfix.Replace(" ", "");
            for (int i = 0; i < postfix.Length; i++)
            {
                char c = postfix[i];
                if (IsOperand(c))
                {
                    stack.Push(c.ToString());
                }
                else
                {
                    var op1 = stack.Pop();
                    var op2 = stack.Pop();
                    if (c == '+')
                    {
                        str = (int.Parse(op1) + int.Parse(op2)).ToString();
                    }
                    else if (c == '*')
                    {
                        str = (int.Parse(op1) * int.Parse(op2)).ToString();
                    }
                    else if (c == '-')
                    {
                        str = (int.Parse(op2) - int.Parse(op1)).ToString();
                    }
                    else if (c == '/')
                    {
                        str = (int.Parse(op2) / int.Parse(op1)).ToString();
                    }

                    stack.Push(str);
                }
            }
            while (stack.Count() > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }

        private static void PostfixToInfix(string postfix)
        {
            var stack = new Stack<string>();
            for (int i = 0; i < postfix.Length; i++)
            {
                char c = postfix[i];
                if (IsOperand(c))
                {
                    stack.Push(c.ToString());
                }
                else
                {
                    var operand1 = stack.Pop();
                    var operand2 = stack.Pop();
                    var str = $"({operand2} {c} {operand1})";
                    stack.Push(str);
                }
            }
            while (stack.Count() > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }

        private static void PostfixToPrefixConversion(string postfix)
        {
            var stack = new Stack<string>();
            for (int i = 0; i < postfix.Length; i++)
            {
                char c = postfix[i];
                if (IsOperand(c))
                {
                    stack.Push(c.ToString());
                }
                else
                {
                    var operand1 = stack.Pop();
                    var operand2 = stack.Pop();
                    var str = $"({c} {operand2} {operand1})";
                    stack.Push(str);
                }
            }
            while (stack.Count() > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }

        private static void PrefixToPostfixConversion(string prefix)
        {
            var stack = new Stack<string>();
            for (int i = prefix.Length - 1; i > 0; i--)
            {
                char c = prefix[i];
                if (IsOperand(c))
                {
                    stack.Push(c.ToString());
                }
                else
                {
                    var str = $"({stack.Pop()} {stack.Pop()} {c})";
                    stack.Push(str);
                }
            }
            while (stack.Count() > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }

        private static void PrefixToInfixConversion(string prefix)
        {
            Stack<string> stack = new();
            for (int i = prefix.Length - 1; i > 0; i--)
            {
                char c = prefix[i];
                if (IsOperand(c))
                {
                    stack.Push(c.ToString());
                }
                else
                {
                    var str = $"({stack.Pop()} {c} {stack.Pop()})";
                    stack.Push(str);                                     
                }
            }
            while (stack.Count() > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
        private static bool IsOperand(char c)
        {
            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
            {
                return true;
            }
            return false;
        }


        private static void ReverseIndividualWordsWithStream(string input)
        {
            using (var sr = new StringReader(input))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (var w in line.Split(' '))
                    {
                        Console.Write(new string(w.Reverse().ToArray()));
                        Console.Write(" ");
                    }
                }
            }
            Console.WriteLine();
        }

        private static void ReverseIndividualWords(string input)
        {
            Stack<char> stack = new();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    stack.Push(input[i]);
                }
                else
                {
                    while (stack.Count() > 0)
                    {
                        Console.Write(stack.Pop());
                    }
                    Console.Write(" ");
                }
                             
            }
            while (stack.Count() >0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }

        private static void ConvertInfixToPostfix(string s)        
        {
            Stack<char> stack = new();
            List<char> result = new();

            s = s.Replace(" ", "");

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
                {
                    result.Add(c);
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count() > 0 && stack.Peek() != '(')
                    {
                        result.Add(stack.Pop());
                    }
                    stack.Pop();
                }
                else
                {
                    while (stack.Count > 0 && (Precedence(s[i]) < Precedence(stack.Peek()) ||
                                           Precedence(s[i]) == Precedence(stack.Peek()) &&
                                               Associativity(s[i]) == "L"))
                    {
                        result.Add(stack.Pop());
                    }
                    stack.Push(c);
                }
            }
            while (stack.Count()> 0)
            {
                result.Add(stack.Pop());
            }
            Console.WriteLine(string.Join(" ", result));
        }
        private static int Precedence(char c)
        {
            if (c == '^')
            {
                return 3;
            }
            else if (c == '/' || c == '*')
            {
                return 2;
            }
            else if (c == '-' || c == '+')
            {
                return 1;
            }
            return -1;
        }
        private static string Associativity(char c)
        {
            if (c == '^')
            {
                return "R";
            }
            return "L";
        }
        
    }
}
