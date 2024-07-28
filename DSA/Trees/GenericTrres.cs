using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Trees
{
    public class GenericTrres
    {
        public static void InorderTraversal(Node node) //aproach: visiting all children except the last
                                                       //then the root and finally the last child recursively
        {
            if (node == null)
            {
                return;
            }
            int totalChildren = node.Children.Count;
            for (int i = 0; i < totalChildren - 1; i++)
            {
                InorderTraversal(node.Children[i]);
            }

            Console.Write(node.Data + " ");

            if (totalChildren > 0)
            {
                InorderTraversal(node.Children[totalChildren - 1]);
            }
        }
        static void Main(string[] args)
        {
            //collection of nodes where each node is a data structure that consists of records and list of references
            //to its children(stores the address of its children), every node stores the adresses of the children and
            //has a pointer called root that stores the adress of the very first node, with a list storing the address of 
            //the child we can randomly access each element so we have the advantage of increasing child adresses and accesing them
            //int n = 3;//3 children
            //var root = new Node(1);
            //var child2 = new Node(2);
            //var child3 = new Node(3);
            //var child4 = new Node(4);
            //var child5 = new Node(5);
            //var child6 = new Node(6);
            //var child7 = new Node(7);
            //root.Children.Add(child2);
            //root.Children.Add(child3);
            //root.Children.Add(child4);
            //child2.Children.Add(child5);
            // child2.Children.Add(child6);
            //child2.Children.Add(child7);
            //Inorder traversal of n-ary tree, O(N)
            //InorderTraversal(root);
            Node root = new Node(1);
            root.Children.Add(new Node(2));
            root.Children.Add(new Node(3));
            root.Children.Add(new Node(4));

            root.Children[0].Children.Add(new Node(5));
            root.Children[0].Children[0].Children.Add(new Node(10));
            root.Children[0].Children.Add(new Node(6));
            root.Children[0].Children[1].Children.Add(new Node(11));
            root.Children[0].Children[1].Children.Add(new Node(12));
            root.Children[0].Children[1].Children.Add(new Node(13));
            root.Children[2].Children.Add(new Node(7));
            root.Children[2].Children.Add(new Node(8));
            root.Children[2].Children.Add(new Node(9));
            //Preorder Traversal, O(N)
            preorderTraversal(root);
        }

        private static void preorderTraversal(Node root) //approach: pop the last node of the stack and
                                                         //insert it int the visited nodes, push the child nodes 
                                                         //into the stack from right to left
        {
            Stack<Node> stack = new();
            List<int> visitedNodes = new();
            stack.Push(root);

            while (stack.Count != 0)
            {
                Node temp = stack.Peek();
                stack.Pop();

                visitedNodes.Add(temp.Data);
                for (int i = temp.Children.Count - 1; i >= 0; i--)//put children from right to left into the stack
                {
                    stack.Push(temp.Children[i]);
                }
            }
            Console.WriteLine(string.Join(" ", visitedNodes));    
        }
    }
    public class Node
    {
        public int Data;
        public List<Node> Children;
        public Node(int data)
        {
            Data = data;
            Children = new() ;
        }
    }
}
