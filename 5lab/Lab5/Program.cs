using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            // инициализация объектов
            var stone1 = new Stone {Color = "Белый", Price = 20, Status = ProductStatus.Ready, Weight = 100};
            var pStone1 = new PreciousStone { Color = "Желтый", Price = 40, Status = ProductStatus.Ready, Weight = 40};
            var ruby1 = new Ruby {Price = 57, Status = ProductStatus.None, Weight = 30};
            var diamond1 = new Diamond { Price = 89, Status = ProductStatus.Ready, Weight = 28 };
            var spStone1 = new SemiPreciousStone { Color = "Зелёный", Price = 30, Status = ProductStatus.None, Weight = 41 };
            var nefrit1 = new Nefrit { Price = 50, Status = ProductStatus.Ready, Weight = 44 };

            Product[] products = {stone1, pStone1, ruby1, diamond1, spStone1, nefrit1};

            var printer = new Printer();

            // тест класса Printer
            Console.WriteLine("Printer:");
            foreach (var product in products)
            {
                printer.IamPrinting(product);
            }

            // тест абстрактного класса
            Console.WriteLine("\nТест абстрактного класса:");
            Product pr_stone = stone1, pr_pStone = pStone1, pr_spStone = spStone1;

            Console.WriteLine($"Для камня {pr_stone.DefineMarket()}");
            Console.WriteLine($"Для драгоценного камня {pr_pStone.DefineMarket()}");
            Console.WriteLine($"Для полудрагоценного камня {pr_spStone.DefineMarket()}");

            // тест виртуального метода
            Console.WriteLine("\nТест виртуального метода:");
            

            diamond1.DamageTest(2000);
            ruby1.DamageTest(2000);
            stone1.DamageTest(2000);

            // тест интефейсов
            //1 способ
            Console.WriteLine("\nТест интерфесов:");
            var rubyWorkshop = ruby1 as IJeweleryWorkshop;     //проиводит ruby1 к IJeweleryWorkshop
            var rubyReseller = ruby1 as IJeweleryReseller;

            // 2 метода с одинаковым названием (но от разных интефейсов)
            rubyWorkshop.ProcessStone();// вызываем ProcessStone() от IJeweleryWorkshop
            rubyReseller.ProcessStone();// вызываем ProcessStone() от IJeweleryReseller

            
            Console.WriteLine("\nЗаказ товаров:");
            Console.WriteLine($"Алмаз: статус {diamond1.StatusDescription}; Рубин: статус {ruby1.StatusDescription}");


            //Итоги
            Console.WriteLine("\nИтоги:");
            Console.WriteLine($"Всего товаров: {products.Length}");
            Console.WriteLine($"Всего драгоценных камней: {products.OfType<PreciousStone>().Count()}");//фильтрация элементов объекта products по типу PreciousStone.
            Console.WriteLine($"Всего полудрагоценных камней: {products.OfType<SemiPreciousStone>().Count()}");//?


        }
    }
}
