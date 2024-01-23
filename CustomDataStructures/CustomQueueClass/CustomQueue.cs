using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueueClass
{
    public class CustomQueue
    {
        private const int InitialCapacity = 4;
        private const int FirstElementIndex = 0;
        private int[] items;
        private int count;

        public CustomQueue()
        {
            items = new int[InitialCapacity];
        }

        public int Count => count; // еквивалентно на  public int Count { get; private set; } записано без полето private int count. 
        // В този случай за променлива използваме private count, не public Count

        public void Enqueue(int item)
        {
            if (items.Length == count)
            {
                Resize();
            }

            items[count] = item;
            count++;
        }

        public int Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            int removed = items[FirstElementIndex];
            ShiftLeft();

            // TODO Shrink if needed
            count--;
            return removed;
        }

        public int Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            return items[FirstElementIndex];
        }

        public void Clear()
        {
            items = new int[InitialCapacity]; // създаваме чисто нов масив, без да трием елементите един по един
            count = 0;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                int currentItem = items[i];
                action(currentItem);
            }
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }

        private void ShiftLeft()
        {
            for (int i = FirstElementIndex; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            items[Count - 1] = default; // only for debugging. Този елемент остава извън границите на масива и няма значение каква стойност има
        }
    }
}
