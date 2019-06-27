using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class Owner
    {
        public int id;
        public string name;
        public string organization;

        public Owner()
        {
            id = 1;
            name = "Yuliana";
            organization = "Kill_me";
        }
    }


    public class Password
    {
        public int len { get; set; }
        public string passw { get; set; }
        public Password(string str)
        {
            passw = str;
            len = str.Length;
        }
 
        public static Password operator ++(Password temp)//сброс пароля на значение по умолчанию
        {
            temp.passw = "123456";
            return (temp);
        }
        //если перегружаются операторы == и !=, то для этого требуется переопределить методы Object.Equals() и Object.GetHashCode().
        public override bool Equals(object pasw) 
        {
            if (pasw == null)
            {
                return false;
            }
            if (pasw.GetType() != this.GetType())
            {
                return false;
            }
            Password temp = (Password)pasw;
            return this.passw==temp.passw;
        }

        public override int GetHashCode()
        {
            int hash = passw.Length * 185;
            return hash;
        }

        public static bool operator !=(Password temp1, Password temp2)//проверка паролей на неравенство
        {
            if (temp1.passw.Length != temp2.passw.Length)
                return true;
            else
                return false;
        }
        public static bool operator ==(Password temp1, Password temp2)//проверка паролей на равенство
        {
            if (temp1.passw.Length == temp2.passw.Length)
                return true;
            else
                return false;
        }

        public static bool operator >(Password temp1, Password temp2)//сравнение длин паролей
        {
            if (temp1.passw.Length > temp2.passw.Length)
            {
                return true;
            }
            else
                return false;
        }
        public static bool operator <(Password temp1, Password temp2)//сравнение длин паролей
        {
            if (temp1.passw.Length < temp2.passw.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }
        public static bool operator true(Password temp)//проверка пароля на стойкость
        {
            int stri = 0;
            int integ = 0;
            for (int i = 0; i < temp.passw.Length; i++)
            {
                System.Type type = temp.passw[i].GetType();
                if (type == typeof(string))
                {
                    stri++;
                }
                else if (type == typeof(int))
                {
                    integ++;
                }
            }
            if (stri > 3 && integ > 0)
                return true;
            else
                return false;
        }

        public static bool operator false(Password temp)
        {
            int stri = 0;
            int integ = 0;
            for (int i = 0; i < temp.passw.Length; i++)
            {
                System.Type type = temp.passw[i].GetType();
                if (type == typeof(string))
                {
                    stri++;
                }
                else if (type == typeof(int))
                {
                    integ++;
                }
            }
            if (stri < 3 || integ < 0)
                return false;
            else
                return false;
        }
    }


    public class PasswordAr
    {
        Password[] num;

        static int quantity;
        int length;
        public PasswordAr(int size)
        {
            this.owner = new Owner();
            num = new Password[size];
            length = size;
            quantity++;
        }
        //индексатор
        public Password this[int a]
        {
            get
            {  
                return num[a];
            }
            set
            {
                num[a] = value;
            }
        }

        public Owner owner;//вложенный объект  
        
        public class Date //вложенный класс
        {
            public int day;
            public int month;
            public int year;

            public Date(int da, int mon, int ye)
            {
                day = da;
                month = mon;
                year = ye;
            }
        }

        static class MathOperation  //Создайте статический класс MathOperation, содержащий 3 метода для работы с вашим классом: 
                                    //поиск максимального, минимального, подсчет количества элементов.
        {

            public static void SeekMax(PasswordAr test)
            {
                Password max = test[0];
                for (int i = 0; i < test.length; i++)
                {
                    if (test[i].passw.Length > max.passw.Length)
                    {
                        max = test[i];
                    }
                }
                Console.WriteLine("Максимальный элемент  " + max.passw);
            }
            public static void SeekMin(PasswordAr test)
            {
                Password min = test[0];
                for (int i = 0; i < test.length; i++)
                {
                    if (test[i].passw.Length < min.passw.Length)
                    {
                        min = test[i];
                    }
                }
                Console.WriteLine("Минимальный элемент  "+min.passw);

            }
            public static void Quantity()
            {
                Console.WriteLine("Количество элементов:" + quantity);
            }

            //Добавьте к классу MathOperation методы расширения вашего типа
            //1)  Выделение среднего символа строки
            public static void AverageСharacter(Password test)
            {
                int le = test.passw.Length;
                
                    char answer = test.passw[le / 2];
                    string answ = answer.ToString();
                
                Console.WriteLine(answer);
            }
            //2)  Проверка допустимой длины пароля(6-12)
            public static string CorrectPassword(Password test)
            {
                if (test.passw.Length >= 6 && test.passw.Length <= 12)
                    Console.WriteLine("Пароль правильной длины");
                else
                {
                    Console.WriteLine("Пароль неправильной длины");
                    test.passw= Console.ReadLine();
                }
                return (test.passw);
            }

        }

        class Program
        {
            static void Main(string[] args)
            {
                PasswordAr Ok = new PasswordAr(3);
                Ok[0] = new Password("1874820KY");
                Ok[1] = new Password("6584sryj7");
                Ok[2] = new Password("56856jlfgujk567");
                

                PasswordAr Wow = new PasswordAr(6);
                Wow[0] = new Password("6uw46jsrt");
                Wow[1] = new Password("4w6jurtratsj6rz");
                Wow[2] = new Password("5uae");
                Wow[3] = new Password("are5t");
                Wow[4] = new Password("dtuksd6k4");
                Wow[5] = new Password("s64ujar5t5souvhrt");
                


                Console.WriteLine("Ok[2] > Ok[1]  "+(Ok[2] > Ok[1]));
                Console.WriteLine("Wow[3] < Ok[1]  "+ (Wow[3] < Ok[1]));

                MathOperation.SeekMax(Wow);
                MathOperation.SeekMin(Ok);

                MathOperation.AverageСharacter(Ok[1]);
                MathOperation.AverageСharacter(Wow[3]);

                MathOperation.CorrectPassword(Wow[5]);
                MathOperation.CorrectPassword(Wow[2]);
                MathOperation.CorrectPassword(Ok[1]);

                if (Wow[3])
                    Console.WriteLine("Надёжный");
                else
                    Console.WriteLine("Ненадёжный");


                Console.WriteLine("Ok[0] != Ok[2]  " + (Ok[0] != Ok[2]));
                Console.WriteLine("Ok[0] == Wow[4]  " + (Ok[0] == Wow[4]));

                Password A=Wow[4]++;
                Console.WriteLine(A.passw);

                PasswordAr.Date date = new PasswordAr.Date(22, 10, 2018);
                Console.WriteLine("Owner: {0} {1} {2}", Ok.owner.id, Ok.owner.name, Ok.owner.organization);//ошибка
                Console.WriteLine("Creation date: {0}.{1}.{2}", date.day, date.month, date.year);
            }
        }
    }
}
