using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Задайте массив типа string, содержащий 12 месяцев (June, July, May,December, January ….). 
            //Используя LINQ to Object напишите:
            //запрос выбирающий последовательность месяцев с длиной строки равной n, 
            //запрос возвращающий только летние и зимние месяцы, 
            //запрос вывода месяцев в алфавитном порядке,
            //запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4 - х..
            string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

            int[] key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var calendar = months
                .Join(key, w => w.Length, q => q, (w, q) => new
                {
                    id = q,
                    name = w,
                });
            foreach (var item in calendar)
            {
                Console.WriteLine($"{item}");
            }

            int n;
            Console.Write("Введите длину строки n:");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Месяцы с длиной строки " + n + ":");
            IEnumerable<string> result1 = from y in months
                                          where y.Length == n
                                          select y;
            foreach (string month in result1)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();


            Console.WriteLine("Возврат только летних и зимних месяцев:");
            IEnumerable<string> result2 =
                                months.Where(y => (y.Equals("Январь") || y.Equals("Февраль") || y.Equals("Декабрь") || y.Equals("Июнь") || y.Equals("Июль") || y.Equals("Август")))
                                .Select(y => y);

            foreach (string month in result2)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            Console.WriteLine("Месяцы в алфавитном порядке:");
            IEnumerable<string> result3 =
                months.OrderBy(y => y)
                .Select(y => y);
            foreach (string month in result3)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            Console.WriteLine("Месяцы, содержащие 'р' и длиной не менее 4-x:");
            IEnumerable<string> result4 = months
                .Where(y => (y.Contains('р') && y.Length >= 4))
                .Select(y => y);
            foreach (string month in result4)
            {
                Console.WriteLine(month);
            }
            Console.WriteLine();

            //2.Создайте коллекцию List<T> и параметризируйте ее типом (классом)
            //из лабораторной №3(при необходимости реализуйте нужные интерфейсы).
            Bus[] arr = new Bus[7];
            arr[0] = new Bus("Васневич", "Р.H.", 12, 2, 2009, 2400);
            arr[1] = new Bus("Мисюто", "А.С", 18, 2, 2012, 1400);
            arr[2] = new Bus("Ралович", "В.Д.", 305, 3, 2009, 2500, "Нёман");
            arr[3] = new Bus("Николайчик", "О.М.", 47, 3, 2009, 2800);
            arr[4] = new Bus("Римант", "А.А.", 177, 2, 2006, 3100);
            arr[5] = new Bus();
            arr[6] = new Bus("Азейкович", "Г.О.", 65, 1, 2010, 1800);

            List<Bus> list = new List<Bus>
            {
                arr[0],arr[1],arr[2],arr[3],arr[4],arr[5],arr[6]
            };

            //3.На основе LINQ сформируйте следующие запросы по вариантам. При необходимости добавьте в класс T(тип параметра) свойства.
            //список автобусов для заданного номера маршрута;
            //список автобусов, которые эксплуатируются больше заданного срока;
            //минимальный по пробегу автобус
            //последние два автобуса максимальные по пробегу
            //упорядоченный список автобусов по номеру
            int z;
            Console.WriteLine("Введите номер маршрута:");
            z = Convert.ToInt32(Console.ReadLine());
            IEnumerable<Bus> request1 = from m in list
                                        where m.RouteNumber == z
                                        select m;
            foreach (Bus bus in request1)
            {
                Console.WriteLine(bus);
            }
            Console.WriteLine();


            int year;
            Console.WriteLine("Введите срок для эксплуатации автобуса:");
            year = Convert.ToInt32(Console.ReadLine());
            IEnumerable<Bus> request2 = list.Where(m => ((2018 - m.YearOfCommencementOfOperation) > year))
                                        .Select(m => m);

            foreach (Bus bus in request2)
            {
                Console.WriteLine(bus);
            }
            Console.WriteLine();



            IEnumerable<Bus> request3 = list.OrderBy(m => m.Mileage);
            Console.WriteLine($"Минимальный по пробегу автобус \n{request3.First()}");
            Console.WriteLine();

            IEnumerable<Bus> request4 = list.OrderByDescending(m => m.Mileage)
                                            .Take(2);
            Console.WriteLine("2 максимальных по пробегу автобуса:");
            foreach (Bus bus in request4)
            {
                Console.WriteLine(bus);
            }
            Console.WriteLine();


            Console.WriteLine("Упорядоченный список автобусов по номеру:");
            IEnumerable<Bus> request5 = list.OrderBy(m => m.BusNumber);
            foreach (Bus bus in request5)
            {
                Console.WriteLine(bus);
            }
            Console.WriteLine();



            //4.Придумайте и напишите свой собственный запрос, в котором было бы не менее 5 операторов из разных категорий: 
            //условия, проекций, упорядочивания, группировки, агрегирования, кванторов и разбиения.
            Console.WriteLine("Много операторов:");
            IEnumerable<Bus> many = list
                .Take(6)
                .Where(m => m.Mileage > 1500)
                .OrderBy(m => m.Surname)
                .TakeWhile(m => m.Surname.Length < 9)
                .Where(m => (m.Initials.Contains('Р')));
            foreach (Bus res in many)
            {
                Console.WriteLine(res);
            }
            Console.WriteLine();


        }
    }
}
    

