using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LinkedLists
{
    public class DoublyLinkedList
    {
        public DLLNode Head;
        public DoublyLinkedList()
        {
            Head = null;
        }
        public void AddAtBeggining(int x)
        {
            DLLNode nodeToAdd = new DLLNode(x);
            if (Head == null)
            {
                Head = nodeToAdd;
            }
            else
            {
                Head.previous = nodeToAdd;
                nodeToAdd.next = Head;
                Head = nodeToAdd;
            }
        }
        public void AddAtMiddle(int x)
        {
            var nodeToAdd = new DLLNode(x);
            var current = Head;
            var length = Length();
            var middle = length / 2 ;


            for (int i = 0; i <= middle; i++)
            {
                if (i == middle - 1)
                {
                    var nextNode = current.next;
                    nextNode.previous = nodeToAdd;
                    current.next = nodeToAdd;
                    nodeToAdd.previous = current;
                    nodeToAdd.next = nextNode;
                    return;
                }
                current = current.next;
            }
        }
        private int Length()
        {
            var current = Head;
            int length = 0;
            if (Head == null)
            {
                return length;
            }
            while (current != null)
            {
                length++;
                current = current.next;
            }
            return length;
        }

        private void PrintList()
        {
            var current = Head;
            while (current!= null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
        public void AddAtEnd(int x)
        {
            var nodeToAdd = new DLLNode(x);
            var current = Head;
            while (current != null)
            {
                if (current.next == null)
                {
                    current.next = nodeToAdd;
                    nodeToAdd.previous = current;
                    return;
                }
                current = current.next;
            }
        }
        public void AddAtGivenPosition(int x, int pos)
        {
            var nodeToAdd = new DLLNode(x);
            var current = Head;
            for (int i = 0; i <= pos; i++)
            {
                if (i == pos - 1)
                {
                    var nextNode = current.next;
                    nextNode.previous = nodeToAdd;
                    current.next = nodeToAdd;
                    nodeToAdd.next = nextNode;
                    nodeToAdd.previous = current;
                    return;
                }
                current = current.next;
            }
        }
        public void FindAtGivenPosition(int pos)
        {
            var current = Head;
            for (int i = 0; i <= pos; i++)
            {
                if (i == pos - 1)
                {
                    Console.WriteLine(current.data);
                }
                current = current.next;
            }
        }
        public void SearchForElement(int x)
        {
            var current = Head;
            if (current.data == x)
            {
                Console.WriteLine("YES");
            }
            while (current != null)
            {
                if (current.data == x)
                {
                    Console.WriteLine("YES");
                }
                current = current.next;
            }
        }
        /*static void Main(string[] args)
        {
            //each node has value and pointer to the next and the previous node
            DoublyLinkedList doublyLinkedList = new();
            doublyLinkedList.AddAtBeggining(6);
            doublyLinkedList.AddAtBeggining(5);
            doublyLinkedList.AddAtBeggining(4);
            doublyLinkedList.AddAtBeggining(2);
            doublyLinkedList.AddAtBeggining(1);
            doublyLinkedList.Length();
            doublyLinkedList.AddAtMiddle(3);
            doublyLinkedList.AddAtEnd(7);
            doublyLinkedList.AddAtGivenPosition(8, 3);
            doublyLinkedList.FindAtGivenPosition(3);
            doublyLinkedList.SearchForElement(8);
            doublyLinkedList.PrintList();
        }*/

        
    }
    public class DLLNode
    {
        public int data;
        public DLLNode previous;
        public DLLNode next;
        public DLLNode(int x)
        {
            data = x;
            previous = null;
            next = null;
        }
    }
}
