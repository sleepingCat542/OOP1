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
        private int Mileage;
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
            int yearOfcommencement, int mileage, string br="МАЗ")
        {
            BusNumber = busNu;
            RouteNumber = routeNu;
            YearOfCommencementOfOperation = yearOfcommencement;
            Mileage = mileage;
            Surname = sur;
            Initials = init;
            Brand=br;
            id = FindId(BusNumber, RouteNumber, Surname);
            quantity++;
        }

        static Bus()//статический конструктор
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
                if (1000<BusNumber)
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
            return this.Brand== temp.Brand && this.YearOfCommencementOfOperation == temp.YearOfCommencementOfOperation;
        }

        public override string ToString()
        {
            return "Номер: " + BusNumber.ToString() + " Водитель " + Surname;
        }

        public int Age(ref int YearOfCommencementOfOperation, out int newAge)//red out
        {
            newAge = 2018 - YearOfCommencementOfOperation;
            string result = "Автобусу" + newAge + "лет";
            return (newAge);
        }

        public static void InformationAboutClass(Bus a)
        {
            Console.WriteLine("ИНФОРМАЦИЯ О КЛАССЕ:");
            Console.WriteLine("Количество объектов: " + quantity);
            Console.WriteLine("Номер автобуса: " +a.BusNumber);
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
    class Program
    {
        static void Main(string[] args)
        {
            //массив объектов
            Bus[] Arr = new Bus[8];
            Arr[0] = new Bus("Васневич", "Р.H.", 12, 2, 2009, 2400);
            Arr[1] = new Bus("Мисюто", "А.С", 18, 2, 2012, 1400);
            Arr[2] = new Bus("Ралович", "В.Д.", 305, 3, 2009, 2500, "Нёман");
            Arr[3] = new Bus("Николайчик", "О.М.", 47, 3, 2009, 2800);
            Arr[4] = new Bus("Римант", "А.А.", 177, 2, 2006, 3100);
            Arr[5] = new Bus();
            Arr[6] = new Bus("Азейкович", "Г.О.", 65, 1, 2010, 1800);
            Arr[7] = new Bus("Кривулько", "С.Н.", 19, 1, 2016, 900, "SuperBus");
            Arr[7].BusNumber = 45;
            Console.WriteLine(Arr[7].BusNumber);
            Arr[4].Surname = "Николов";
            Console.WriteLine(Arr[4].Surname);

            bool p1 = Arr[3].Equals(Arr[0]);
            Console.WriteLine(p1);
            bool p2 = Arr[3].Equals(Arr[2]);
            Console.WriteLine(p2);

            string m=Arr[6].ToString();
            Console.WriteLine(m);

            Bus.InformationAboutClass(Arr[1]);

            int age;
            Arr[5].Age(ref Arr[5].YearOfCommencementOfOperation,out age);
            Console.WriteLine(age);
            //a)  список автобусов для заданного номера маршрута;

            Console.WriteLine("Введите номер требуемого маршрута:");
            int te=Convert.ToInt32(Console.ReadLine());
            for(int i=0; i<=7; i++)
            {
                if (Arr[i].RouteNumber==te)
                {
                    Console.WriteLine("Автобус:"+ Arr[i].BusNumber);
                }
            }

            Bus.Info.Good(Arr[4].Surname, Arr[4].Initials);
            Bus.Info.Bad(Arr[6].Surname, Arr[6].Initials);


            //b)  список автобусов, которые эксплуатируются больше
            //заданного срока;

            Console.WriteLine("Введите срок после истечения которого автобус становится небезопасным:");
            int tem = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= 7; i++)
            {
                int Ag = Arr[i].Age(ref Arr[i].YearOfCommencementOfOperation, out age);
                
            
                if (Ag > tem)
                {
                    Console.WriteLine("Автобус:" + Arr[i].BusNumber+"небезопасен");
                }
            }

            // Создайте и выведите анонимный тип
            int cost = 242;
            var minicar = new { Arr[4].Surname, cost};
            Console.WriteLine(minicar);
        }
    }
}
