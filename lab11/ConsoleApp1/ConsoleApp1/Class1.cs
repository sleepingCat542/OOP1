using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{

        public class Bus
        {
            public string Surname { get; set; }
            public string Initials { get; set; }
            public int BusNumber;
            public int RouteNumber { get; set; }
            public string Brand;//константа
            private const string err = "Ошибка";  //константа
            public int YearOfCommencementOfOperation;
            public int Mileage;
            public readonly string id; //только для чтения
            static int quantity;//статическое поле

            public Bus()//конструктор без параметров
            {
                BusNumber = 15;
                RouteNumber = 345;
                YearOfCommencementOfOperation = 2005;
                Mileage = 1300;
                Surname = "Зелёнков";
                Initials = "А.Л.";
                id = FindId(BusNumber, RouteNumber, Surname);
                Brand = "МАЗ";
                quantity++;
            }

            public Bus(string sur, string init, int busNu, int routeNu,
                int yearOfcommencement, int mileage, string br = "МАЗ")
            {
                BusNumber = busNu;
                RouteNumber = routeNu;
                YearOfCommencementOfOperation = yearOfcommencement;
                Mileage = mileage;
                Surname = sur;
                Initials = init;
                Brand = br;
                id = FindId(BusNumber, RouteNumber, Surname);
                quantity++;
            }

            static Bus()
            {
                Console.WriteLine("Наши автобусы:");
            }

            public string FindId(int BusNumber, int RouteNumber, string Surname)
            {
                string p1 = BusNumber.ToString();
                string p2 = RouteNumber.ToString();
                string iD = Surname + p1 + p2;
                return iD;
            }


            public int BBusNumber
            {
                get
                {
                    return BusNumber;
                }
                set
                {
                    if (1000 < BusNumber)
                    {
                        Console.WriteLine("Такого автобуса у нас не существует");
                        Console.WriteLine(err);
                    }
                    else
                    {
                        BusNumber = value;
                    }
                }
            }

            public int YearOf
            {
                get
                {
                    return YearOfCommencementOfOperation;
                }

                set
                {
                    if (YearOfCommencementOfOperation > 2018 && YearOfCommencementOfOperation < 1900)
                    {
                        Console.WriteLine("Введите корректный год:");
                        Console.WriteLine(err);
                    }
                    else
                    {
                        YearOfCommencementOfOperation = value;
                    }
                }
            }
            public int Mmileage
            {
                get
                {
                    return Mileage;
                }
                private set
                {
                    Mileage = value;
                }
            }


            public override bool Equals(object obj) //переопределение
            {
                if (obj == null)
                {
                    return false;
                }
                if (obj.GetType() != this.GetType())
                {
                    return false;
                }
                Bus temp = (Bus)obj;
                return this.Brand == temp.Brand && this.YearOfCommencementOfOperation == temp.YearOfCommencementOfOperation;
            }

            public override string ToString()
            {
                return "Номер: " + BusNumber.ToString() + " Водитель " + Surname;
            }

            public int Age(ref int YearOfCommencementOfOperation, out int newAge)
            {
                newAge = 2018 - YearOfCommencementOfOperation;
                string result = "Автобусу" + newAge + "лет";
                return (newAge);
            }

            public static void InformationAboutClass(Bus a)
            {
                Console.WriteLine("ИНФОРМАЦИЯ О КЛАССЕ:");
                Console.WriteLine("Количество объектов: " + quantity);
                Console.WriteLine("Номер автобуса: " + a.BusNumber);
                Console.WriteLine("Номер маршрута: " + a.RouteNumber);
                Console.WriteLine("Фамилия водителя: " + a.Surname);
                Console.WriteLine("Инициалы: " + a.Initials);
                Console.WriteLine("Марка: " + a.Brand);
                Console.WriteLine("Год начала эксплуатации: " + a.YearOfCommencementOfOperation);
                Console.WriteLine("Пробег: " + a.Mileage);
                Console.WriteLine("Идентификатор: " + a.id);
            }


            public partial class Info  //частичный класс
            {
                public static void Good(string Surname, string Initials)
                {
                    Console.WriteLine("Лучший работник месяца:" + Surname + " " + Initials + "!");
                }
            }
            public partial class Info
            {
                public static void Bad(string Surname, string Initials)
                {
                    Console.WriteLine("Худший работник месяца:" + Surname + " " + Initials + "(");
                }
            }
        }
    
}
