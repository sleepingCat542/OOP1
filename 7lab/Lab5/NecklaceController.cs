using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab6.Exeption;

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
            int weight = necklace.Stones.Sum(s => s.Weight);
            if (weight < 30)
                throw new SenceException("Недостаточно камней, это кулон");
            else
                return weight;
            
        }

        public IEnumerable<Stone> GetStonesByOpacity(int start, int end)
        {
            return necklace.Stones.Where(s => s.OpticProperty.Opacity >= start && s.OpticProperty.Opacity <= end);
        }

        public int GetTotalPrice()
        {
            int sum = necklace.Stones.Sum(s => s.Price);
            if (sum < 100)
                throw new SenceException("Недостаточная стоимость");
            else
                return sum;
        }

        public void Sort()
        {
            necklace.Stones.Sort();  // Сортировка внутри себя вызывает метод CompareTo интерфейса IComparable у типа Stone (как элемента списка)
        }


    }
}
