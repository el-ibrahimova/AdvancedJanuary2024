using CustomLinkedList;
using System;

namespace CustomLinkedList
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            DoubliLinkedList<int> list = new();

            list.AddFirst(3);
            list.AddFirst(2);
            list.AddFirst(1);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            DoubliLinkedList<string> listString = new();

            listString.AddFirst("some");
            listString.AddFirst("random");
            listString.AddFirst("string");

            foreach (var item in listString)
            {
                Console.WriteLine(item);
            }
        }
    }
}
