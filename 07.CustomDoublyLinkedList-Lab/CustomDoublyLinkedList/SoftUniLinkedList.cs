using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class SoftUniLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public int Count { get; set; } // нужно ни е за метода int[] ToArray

        public void AddLast(int nodeValue)
        {
            Count++;

            Node newNode = new Node(nodeValue);   // create new Node somewhere in memory
            if (Head == null) // Head == Tail == null
            {
                Head = newNode;   // вече инициализираме Head и Tail  със стойности, първоначално са еднакви
                Tail = newNode;
                return;
            }

            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;

            
        }

        public void AddFirst(int nodeValue)
        {
            Count++; 

            Node newNode = new Node(nodeValue);

            if (Head == null) 
            {
                Head = newNode;   
                Tail = newNode;
                return;
            }

            newNode.Next = Head;
            Head.Previous = newNode;  // previous and next = това са посоките = стрелкичките от чертежа
            Head = newNode;
        }

        public Node RemoveLast()
        {
            Node nodeToRemove = Tail;

            Tail = nodeToRemove.Previous;
            Tail.Next = null;
            nodeToRemove.Previous = null;  // когато Previous и Next са null = тогава елемента не е свързан с листа и GarbageCollector-а го изтрива от паметта

            Count--;
            return nodeToRemove;
        }

        public Node RemoveFirst()
        {
            Node nodeToRemove = Head;

            Head = Head.Next;
            Head.Previous = null;
            nodeToRemove.Next = null;

            Count--;
            return nodeToRemove;
        }

        public void ForEach(Action<int> callback)
        {
            Node currentNode = Head;

            while (currentNode != null)
            {
                callback(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int index = 0;

            //Node currentNode = Head;
            //while (currentNode != null)
            //{
            //    array[index++] = currentNode.Value;
            //    currentNode = currentNode.Next;
            //}

            ForEach(n =>
            {
                array[index++] = n;
            });

            return array;
        }
    }
}
