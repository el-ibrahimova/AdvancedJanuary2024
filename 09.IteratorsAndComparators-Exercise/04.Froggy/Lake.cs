using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Froggy
{
    public class Lake: IEnumerable<int>
    {
        private List<int> stones;

        public Lake(List<int> stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            // Първате пътека е от четните индекси
            for (int i = 0; i < stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return stones[i];
                }
            }

            // пътят на връщане е от нечетните индекси
            for (int i = stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
