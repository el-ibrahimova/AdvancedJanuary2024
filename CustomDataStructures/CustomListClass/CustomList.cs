using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListClass
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; } // за да няма достъп от външния свят за задаване на броя на елементите

        public int this[int index]
        {
            get
            {
                ThrowExceptionIfIndexOutOfRange(index);
                return items[index];
            }
            set
            {
                ThrowExceptionIfIndexOutOfRange(index);
                items[index] = value;
            }
        }

        public void Add(int item)
        {
            if (items.Length == Count) // ако масива от елементи е запълнен, тогава увеличаваме размера му по 2 и тогава добавяме следващия елемент
            {
                Resize();
            }

            items[Count] = item;
            Count++;
        }

        public void AddRange(int[] items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
        public int RemoveAt(int index)
        {
            ThrowExceptionIfIndexOutOfRange(index);
            int removedItem = items[index];

            ShiftLeft(index);
            Count--;

            if (Count <= items.Length / 4)
            {
                Shrink();
            }
            return removedItem;
        }

        public void InsertAt(int index, int item)
        {
            ThrowExceptionIfIndexOutOfRange(index);
            if (items.Length == Count)
            {
                Resize();
            }

            ShiftRight(index);
            Count++;
            items[index] = item;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ThrowExceptionIfIndexOutOfRange(firstIndex);
            ThrowExceptionIfIndexOutOfRange(secondIndex);

            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        private void ShiftRight(int index)
        {
            for (int i = Count - 1; i >= index; i--)
            {
                items[i + 1] = items[i];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            items[Count - 1] = default; // only for debugging. Този елемент остава извън границите на масива и няма значение каква стойност има
        }
        private void Resize()
        {
            int[] copy = new int[items.Length * 2]; // създаваме нов масив, копие на оригиналния, за да не правим промени в неговите елементи (референтните стойности в паметта)

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy; // оригиналния масив + умножено по 2 нови клетки (ако са били 2, са станали 4)
        }
        
        private void Shrink() // Обратен на метода Resize. Използва се за оптимизация. Ако има много заделена памет, но масива е с малко елементи, тогава разчиатваме ненужните клетки
        {
            int[] copy = new int[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        private void ThrowExceptionIfIndexOutOfRange(int index)
        {
            if (index < 0 || index >= this.Count) // ако се опитаме да достъпим индекс, за който не е зададена стойност
            {
                throw new IndexOutOfRangeException("Invalid index value");
            }
        }
    }
}
