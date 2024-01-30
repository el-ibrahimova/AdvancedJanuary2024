using System;
using System.Collections;
using System.Collections.Generic;

namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConcertHall concertHall = new(new List<int> { 1, 2, 3 });

            foreach (var seat in concertHall)
            {
                Console.WriteLine(seat);
            }
        }

//ConcertHallEnumerator concertHallEnumerator = new(new List<int> { 1, 2, 3 });

            //while (concertHallEnumerator.MoveNext()) //  докато мога да се движа надясно(докато има елементи в листа)
            //{
            //    Console.WriteLine(concertHallEnumerator.Current);
            //}


public class ConcertHall : IEnumerable<int>  // за да бъде обхождан (номериран, foreach-ван)този клас,  трябва да наследи интерфейса IEnumerable
        {
            private List<int> seats;

            public ConcertHall(List<int> seats)
            {
                this.seats = seats;
            }


            public IEnumerator<int> GetEnumerator()  // в този метод се пише логиката как да бъде foreach-ван
            {
                return new ConcertHallEnumerator(seats);

                //for (int i = 0; i < seats.Count; i++)
                //{
                //    yield return seats[i];
                //}

                //reversed    => обхождаме листа отзад напред
                //for (int i = seats.Count - 1; i >= 0; i--)
                //{
                //    yield return seats[i];
                //}
            }

            IEnumerator IEnumerable.GetEnumerator() // когато извикаме този метод, се връща метода public IEnumerator<int> GetEnumerator()
            {
                return GetEnumerator();
            }
            // може да се запише и така
            //   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        // когато използваме yield изобщо не е нужно за правим клас и да имплементираме IEnumerator, т.е. следващия код става излишен

        public class ConcertHallEnumerator : IEnumerator<int>
        {
            private int index = -1;  //  началния елемент е извън индексите на листа
            private List<int> seats;

            public ConcertHallEnumerator(List<int> seats)
            {
                this.seats = seats;
            }

            public int Current => seats[index];    // Current казва върни текущия елемент

            object IEnumerator.Current => Current;

            public bool MoveNext()   // преместваме индекса от  листа с едно 
            {
                index++;

                return index < seats.Count;   //  ако новия индекс е извън листа се връща false
            }

            public void Reset()
            {
                index = -1;   // върни се в началото (с първоначалната стойност)
            }

            public void Dispose()
            {
            }
        }

    }
}

