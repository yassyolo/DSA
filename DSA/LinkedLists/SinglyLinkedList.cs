using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LinkedLists
{
    public class SinglyLinkedList
    {
        public Node Head;
        public SinglyLinkedList()
        {
            Head = null;   
        }

        public void InsertAtBeginning(int x) //O(1)
        {
            Node newNode = new Node(x);
            newNode.next = Head;
            Head = newNode;
        }
        public void InsertAfterGivenNode(int x, Node prevNode)//O(1)
        {
            if (prevNode == null)
            {
                Console.WriteLine("Previous Node doesn't exist");
                return;
            }
            Node newNode = new Node(x);
            newNode.next = prevNode.next;
            prevNode.next = newNode;

        }
        public void InsertNodeAtEnd(int x)//O(N)
        {
            Node newNode = new Node(x);
            if (Head == null)
            {
                newNode.next = Head;
                Head = newNode;
            }
            newNode.next = null;
            Node last = Head;
            while (last.next != null)
            {
                last = last.next;
            }
            last.next = newNode;
        }
        public void SearchIterative(Node head, int x)//O(N)
        {
            if (head.data == x)
            {
                Console.WriteLine("Yes");
                return;
            }
            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.data == x)
                {
                    Console.WriteLine("Yes");
                    return;
                }
                currentNode = currentNode.next;
            }
            Console.WriteLine("No");
        }
        public void SearchRecursive(Node head, int x)//O(N)
        {
            if (head == null)
            {
                Console.WriteLine("No");
            }
            if (head.data == x)
            {
                Console.WriteLine("Yes");
            }
            SearchIterative(head.next, x);
        }
        public void Length()//O(N)
        {
            int length = 0;
            Node temp = Head;
            if (temp == null)
            {
                Console.WriteLine(length); 
            }
            while (temp != null)
            {
                length++;
                temp = temp.next;
            }
            Console.WriteLine(length);
        }
        public void PrintList()
        {
            Node temp = Head;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
        public void ReverseList(Node head)//O(N) See again!
        {
            Node previous = null;
            Node current = head;
            Node temp = null;
            while (current != null)
            {
                temp = current.next;
                current.next = previous;
                previous = current;
                current = temp;
            }
        }
        public void DeleteAtBeginning()
        {
            if (Head == null)
            {
                return;
            }
            var temp = Head;
            var tempNext = Head.next;
            Head = tempNext;
            temp = null;
        }
        public void DeleteAtEnd(Node head)
        {
            Node current = head;
            Node previous = null;
            while (current != null)
            {
                if (current.next == null)
                {
                    previous.next = null;
                    current = null;
                    return;
                }
                previous = current;
                current = current.next;                
            }
        }
        public void DeleteNodeFRomPositionIterative(int x, Node head)
        {
            var current = head;
            Node previous = null;
            while (true)
            {
                if (current.data == x)
                {
                    previous.next = current.next;
                    current = null;
                    return;
                }
                previous = current;
                current = current.next;
            }
        }
        public void DeleteNodeFRomPositionRecursive(int x, Node head, Node previous)
        {
            if (head.data == x)
            {
                previous.next = head.next;
                head = null;
            }
            DeleteNodeFRomPositionRecursive(x, head.next, previous.next);
        }
        public void DeleteNodeFromGivenPosition(int pos)//O(N)
        {
            var current = Head;
            Node previous = null;

            for (int i = 0; i <= pos; i++)
            {
                if(i == pos)
                {
                    previous.next = current.next;
                    current = null;
                    return;
                }
                previous = current;
                current = current.next;
            }
        }
        public void DeleteList()
        {
            Head = null;
        }
        public void FindNodeAtGivenPosition(int pos)
        {
            var current = Head;
            for (int i = 0; i <= pos; i++)
            {
                if (i == pos)
                {
                    Console.WriteLine(current.data);
                    return;
                }
                current = current.next;
            }
        }
        public void FindNodeAtGivenPositionFromEnd(int pos)
        {
            var current = Head;
            int length = 0;
            while (current != null)
            {
                length++;
                current = current.next;
            }
            
            var positionToFind = length - pos;
            if (positionToFind == 0)
            {
                Console.WriteLine(Head.data);
            }
            current = Head.next;
            for (int i = 0; i <= positionToFind; i++)
            {
                if (i == positionToFind - 1)
                {
                    Console.WriteLine(current.data);
                    return;
                }
            }
        }
        public void FindMiddleOfLinkedListNormal()
        {
            var current = Head;
            int length = 0;
            while (current != null)
            {
                length++;
                current = current.next;
            }
            int middle = length / 2 + 1;
            
            current = Head;
            for (int i = 0; i <= middle; i++)
            {
                if (i == middle - 1)
                {
                    Console.WriteLine(current.data);
                    return;
                }
                current = current.next;
            }
        }
        public void FindMiddleOfLinkedListWithList()
        {
            var list = new List<int>();
            var current = Head;
            while (current != null)
            {
                list.Add(current.data);
                current = current.next;
            }
            int middle = list.Count() / 2 ;
            Console.WriteLine(list[middle]);
        }
        private void FindMiddleOfLinkedListHareAndTortoiseAlgorithm()
        {
            Node fast = Head;
            Node slow = Head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            Console.WriteLine(slow.data); 
        }
        public void ReverseClockWise(int k)
        {
            if (k == 0)
            {
                return;
            }
            var current = Head;
            int count = 0;
            if (current != null && count < k)
            {
                current = current.next;
                count++;
            }
            if (current == null)
            {
                return;
            }
            Node kth = current;
            while (current.next !=null)
            {
                current = current.next;
            }
            current.next = Head;
            Head = kth.next;
            kth.next = null;
        }
        private void RemoveDuplicatesFromSortedLinkedList()
        {
            var current = Head;
            while (current != null)
            {
                if (current.data == current.next.data)
                {
                    current.next = current.next.next;
                    current.next = default;
                }
                current = current.next;                
            }
        }

        private void SortLinkedListOf01And2()
        {
            int[] count = { 0, 0, 0 };
            var current = Head;
            while (current != null)
            {
                count[current.data]++;
                current = current.next;
            }
            int i = 0;
            current = Head;
            while (current != null)
            {
                if (count[i] == 0)
                {
                    i++;
                }
                else
                {
                    current.data = i;
                    current = current.next;
                    count[i]--;
                }
            }
        }

        /*static void Main(string[] args)
        {
            //Chains of nodes, each node holds data(value) and pointer to the next one, Each node has a link to the next one, each node holds a single value and reference(address) to
            //the next one, has a head which is the first el and tail the last el, there is no direct acces to
            //a specific node, you should traverse the whole list to access it, insertion and deletion is efficient
            //tail node points to null, head node is the fisrt
            //Insertion, deletion, searching-O(N), Insertion, deletion at begining-O(1)
            //Advantages:dynamic memory allocation-the size can change, space-efficient-the only hold the referenvce to the next one
            //Disadvantages:poor random access, increased memory overhead-they store additional reference for the next one unlike the array, vulnerability to data loss, backward traversing is not possible
            SinglyLinkedList linkedList = new SinglyLinkedList();
            //linkedList.InsertAtBeginning(1);
            //linkedList.InsertAtBeginning(2);
            //linkedList.InsertAtBeginning(3);
            //linkedList.InsertNodeAtEnd(4);
            //linkedList.SearchIterative(linkedList.Head, 1);
            //linkedList.SearchRecursive(linkedList.Head, 1);
            //linkedList.Length();
            //linkedList.PrintList();
            //ToDo
            //linkedList.ReverseList(linkedList.Head);
            //linkedList.DeleteAtBeginning();
            //linkedList.DeleteAtEnd(linkedList.Head);
            //linkedList.DeleteNodeFRomPositionIterative(1, linkedList.Head);
            //linkedList.DeleteNodeFromGivenPosition(2);
            //linkedList.FindNodeAtGivenPosition(2);
            //linkedList.FindNodeAtGivenPositionFromEnd(3);
            //Problem1=>Given a Singly Linked List, the task is to find the middle of the linked list. If the number of nodes are even, then there would be two middle nodes, so return the second middle node.
            //linkedList.FindMiddleOfLinkedListNormal();
            //O(N)
            //linkedList.FindMiddleOfLinkedListWithList();
            //O(N)
            //linkedList.FindMiddleOfLinkedListHareAndTortoiseAlgorithm();
            //linkedList.InsertAtBeginning(4);
            //linkedList.InsertAtBeginning(3);
            //linkedList.InsertAtBeginning(2);
            //linkedList.InsertAtBeginning(1);
            //linkedList.ReverseList(linkedList.Head);
            //Problem2=>Given a singly linked list, The task is to rotate the linked list counter-clockwise by k nodes.
            //linkedList.InsertAtBeginning(60);
            //linkedList.InsertAtBeginning(50);
            //linkedList.InsertAtBeginning(40);
            //linkedList.InsertAtBeginning(30);
            //linkedList.InsertAtBeginning(20);
            //linkedList.InsertAtBeginning(10);
            //linkedList.ReverseClockWise(4);//Todo
            //Problem3=>Given a singly linked list consisting of N nodes. The task is to remove duplicates (nodes with duplicate values) from the given list (if exists).
            // linkedList.InsertAtBeginning(2);
            //linkedList.InsertAtBeginning(2);
            //linkedList.InsertAtBeginning(4);
            // linkedList.InsertAtBeginning(5);
            //linkedList.RemoveDuplicatesFromSortedLinkedList();
            //Problem4=>Given a linked list of 0s, 1s and 2s, The task is to sort and print it.
            linkedList.InsertAtBeginning(2);
            linkedList.InsertAtBeginning(2);
            linkedList.InsertAtBeginning(1);
            linkedList.InsertAtBeginning(0);
            linkedList.InsertAtBeginning(1);
            linkedList.InsertAtBeginning(2);
            linkedList.SortLinkedListOf01And2();
        }*/

    }
    public class Node
    {
        public int data;
        public Node next;
        public Node(int x)
        {
            data = x;
            next = null;
        }
    }    
}
