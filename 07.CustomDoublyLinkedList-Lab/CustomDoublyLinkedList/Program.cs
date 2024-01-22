using CustomDoublyLinkedList;

namespace CustomDoublyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SoftUniLinkedList linkedList = new SoftUniLinkedList();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            linkedList.AddFirst(0);
            linkedList.AddFirst(-1);

            Console.WriteLine($"Head {linkedList.Head}");
            Console.WriteLine($"Tail {linkedList.Tail}");

            int listSum = 0;
            linkedList.ForEach(x =>
            {
                listSum += x;
                Console.WriteLine($"From ForEach: {x}");
            });
            Console.WriteLine($"Sum: {listSum}");

            int[] array = linkedList.ToArray();

            //  Node currentNode = linkedList.Head;

            //while (currentNode != null)
            //{
            //    Console.WriteLine(currentNode.Value);
            //    currentNode = currentNode.Next;
            //}
        }
    }
}
