using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab6
{
    public class Necklace
    {
        public List<Stone> Stones { get; set; }

        public Necklace(IEnumerable<Stone> stones)  // передаём коллекцию камней
        {
            Stones = stones.ToList();  // преобразовываем коллекцию в список
        }

        public Stone this[int i]
        {
            get
            {
                Debug.Assert(i < 2, "В списке должно быть хотя бы 2 элемента.");
                return Stones[i];
            }
            set { Stones[i] = value; }
        //Добавьте в код одной из функций макрос Assert. Объясните что он проверяет, как
        //будет выполняться программа в случае не выполнения условия.Объясните назначение Assert.
   

    }

        public void Add(Stone stone)
        {
            Stones.Add(stone);
        }

        public void Remove(Stone stone)
        {
            Stones.Remove(stone);
        }


        public override string ToString()
        {
            string result = "";
            foreach (var stone in Stones)
            {
                result += $"{stone}\n";
            }

            return result;
        }

        public void Print()
        {
            Console.WriteLine(this);
        }
    }
}
