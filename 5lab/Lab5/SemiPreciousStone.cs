using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class SemiPreciousStone : Stone, IJeweleryWorkshop
    {

        public SemiPreciousStone()
        {
            ProductType = "Неопределенный полудрагоценный камень";
        }

        public virtual void Magic() 
        {
            Console.WriteLine($"Этот камень имеет магические свойства");
        }

        // реализация абстрактоного метода класса Product
        public override string DefineMarket() // определить рынки сбыта
        {
            return "Рынки сбыта - Полудрагоценные камни";
        }

        public override string ToString()
        {
            return $"Информация о полудрагоценном камне: Вес - {Weight} грамм; Цвет - {Color}; Тип камня - {ProductType}; Цена - {Price}; Статус - {StatusDescription}.";
        }


        //  реализация IJeweleryWorkshop
        public void MakeJewelry()
        {
            Console.WriteLine($"Создано полудрагоценное украшение из: {ProductType}");
        }

        public void ProcessStone()
        {
            Console.WriteLine($"Обработан полудрагоценный камень: {ProductType}");
        }
    }
}
