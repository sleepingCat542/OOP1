using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab6.Exeption;

namespace Lab6
{
    public sealed class Ruby: PreciousStone
    {
        public Ruby()
        {
            Color = "Красный";
            ProductType = "Рубин";
        }

        public override string ToString()
        {
            return $"Информация о рубине: Вес - {Weight} грамм; Цвет - {Color}; Тип камня - {ProductType}; Цена - {Price}; Статус - {StatusDescription}; Прозрачность - {OpticProperty.Opacity}; Преломление - {OpticProperty.Refraction}.";
        }

        public override void DamageTest(int power)
        {
            if (power < 3000)
            {
                throw new StoneException("Рубин не прошел тест на прочность");
            }
            else Console.WriteLine("Рубин прошел тест на прочность");
        }
    }
}
