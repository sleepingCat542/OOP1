using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static Lab6.Exeption;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            // инициализация объектов

            try
            {
                var stone1 = new Stone { Color = "Белый", Price = 20, Status = ProductStatus.Ready, Weight = 100 };
                var pStone1 = new PreciousStone { Color = "Желтый", Price = 40, Status = ProductStatus.Ready, Weight = 40 };
                var ruby1 = new Ruby { Price = 57, Status = ProductStatus.None, Weight = 30 };
                var diamond1 = new Diamond { Price = 89, Status = ProductStatus.Ready, Weight = 28 };
                var spStone1 = new SemiPreciousStone { Color = "Зелёный", Price = 30, Status = ProductStatus.None, Weight = 41 };
                var nefrit1 = new Nefrit { Price = 50, Status = ProductStatus.Ready, Weight = 44 };
                var diamond2= new Diamond { Price = 91, Status = ProductStatus.Ready, Weight = 30 };
                /*diamond2.DamageTest(21000); */      //исключение

                var ruby3 = new Ruby { Price = 57, Status = ProductStatus.None, Weight = 20 };
                var stone4 = new Stone { Color = "Белый", Price = 27, Status = ProductStatus.Ready, Weight = 5 };

                List<Stone> stones = new List<Stone> { stone1, spStone1, pStone1, nefrit1, ruby1, diamond1 };
                var necklace = new Necklace(stones);

                List<Stone> stones4 = new List<Stone> { stone4, ruby3};
                var necklace2 = new Necklace(stones4);
                var controller2 = new NecklaceController(necklace2);




                necklace.Print();

               
                /*stone4.DamageTest(400);*/      //исключение
               /* ruby3.DamageTest(2500);  */   //исключение

               necklace.Remove(necklace[0]);
                Console.WriteLine();
                necklace.Print();

                necklace.Add(new Ruby { Weight = 33, Price = 50, OpticProperty = new OpticProperty(5, 10) });
                                                                                                             

                Console.WriteLine();

                var controller = new NecklaceController(necklace);

                controller.Sort();

                necklace.Print();

                var stones2 = controller.GetStonesByOpacity(2, 11);

                Console.WriteLine();
                Necklace stones3 = new Necklace(stones2);
                stones3.Print();

                Console.WriteLine();
                Console.WriteLine($"Общая ценность ожерелья: {controller.GetTotalPrice()}");
                Console.WriteLine($"Общий вес ожерелья: {controller.GetTotalWeight()}");
                //Console.WriteLine($"Общий вес ожерелья: {controller2.GetTotalWeight()}");      \\исключение
                //Console.WriteLine($"Общий ценность ожерелья: {controller2.GetTotalPrice()}");
            }



            catch (StoneException e)
            {
                e.GetInfo();
            }
            catch (SenceException e)
            {
                e.GetInfo();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine("ArgumentOutOfRangeException");
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine(exception.TargetSite);
            }
            
            finally
            {
                try
                {
                    Console.WriteLine("Подтвердите завершение операций:");
                    string confirmation = Console.ReadLine();
                    if (confirmation != "подтверждено")
                        throw new ExceptionOfStruct("Ошибка завершения:");
                }
                catch (ExceptionOfStruct e)
                {
                    e.GetInfo();
                }
                Console.WriteLine("Конец.");
            }
        }
    }
}
