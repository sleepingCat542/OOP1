using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class NecklaceController
    {
        public Necklace necklace { get; set; }

        public NecklaceController(Necklace nnecklace)
        {
            necklace = nnecklace;
        }

        public int GetTotalWeight()
        {
            return necklace.Stones.Sum(s => s.Weight);
        }

        public int GetTotalPrice()
        {
            return necklace.Stones.Sum(s => s.Price);
        }

        public void Sort()
        {
            necklace.Stones.Sort();  // Сортировка внутри себя вызывает метод CompareTo интерфейса IComparable у типа Stone (как элемента списка)
        }


    }
}
