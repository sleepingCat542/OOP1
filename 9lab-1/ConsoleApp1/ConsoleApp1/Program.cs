using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    //Создать класс  Программист с событиями Переименовать  и Новое свойство
    class Programmer
    {

        public event EventHandler Rename;     //событие стандартного типа
        public event EventHandler NewProperty;

        public string name;

        public Programmer(string name)
        {
            this.name = name;
        }
        public void CommandAddOperation()
        {
            NewProperty?.Invoke(this, null);
        }

        public void CommandRenOperation()
        {
            Rename?.Invoke(this, null);
        }
    }

    class ProgrammingLanguage
    {
        public string nameLang { get; set; }
        public double versionLang { get; set; }
        public string[] optionsArr { get; set; }

        public ProgrammingLanguage(string nameLang, double versionLang, params string[] optionsArr)
        {
            this.nameLang = nameLang;
            this.versionLang = versionLang;
            this.optionsArr = optionsArr;
        }

        public override string ToString()
        {
            string s= "";
            for (int i = 0; i < this.optionsArr.Length; i++)
            {
                s = s +" "+ this.optionsArr[i];
            }
            
                return $"Язык:{this.nameLang} версии {this.versionLang}\nОперации:{s}";
        }

        public void AddOperation(string operation)
        {
            int count = optionsArr.Length+1;
            string[] NewArr = new string[count];
            for (int i=0, j=0; i< optionsArr.Length; i++, j++)
            {
                NewArr[j] = optionsArr[i]; 
            }
            NewArr[count-1] = operation;
            Console.WriteLine($"Мы добавили в язык {nameLang} операцию:{operation}");
        }

        public void Add(Object sender, EventArgs e)
        {
            Console.WriteLine($"Add");
            AddOperation(Console.ReadLine());
        }

        public void DeleteOptions(string operation)
        {
            for (int o=0; o < optionsArr.Length; o++)
            {
                if (optionsArr[o] == operation)
                    optionsArr[o] = "";
            }
            Console.WriteLine($"Мы исключили из языка { nameLang} операцию: {operation}");  
        }

        public void Delete(Object sender, EventArgs e)
        {
            Console.WriteLine($"Delete");
            DeleteOptions(Console.ReadLine());
            
        }

        public void NewVersion(double vers)
        {
            versionLang = vers;
            Console.WriteLine($"Мы используем новую версию нашего языка: {nameLang} {versionLang}");
        }

        public void NewName(string name)
        {
            nameLang = name;
            Console.WriteLine($"Мы переименовали язык: {nameLang}");
        }

        public void Rename_L(Object sender, EventArgs e)
        {
            
            Console.WriteLine("Rename");
            NewName(Console.ReadLine());
            NewVersion(Convert.ToDouble(Console.ReadLine()));
        }

    }
   

    public static class StringHandler
    {
        //2. Создайте пять методов пользовательской обработки строки (например, удаление знаков препинания, добавление символов, замена на заглавные,
        //удаление лишних пробелов и т.п.). Используя стандартные типы делегатов (Action, Func) организуйте алгоритм последовательной обработки строки
        //написанными вами методами.
        public static string RemoveS(string str, Func<string, string> test1) { return test1(str); }      //удаление знаков
        public static void AddToString(string str, Action<string> test2) => test2(str);                 //добавление строки
        public static string RemoveSpase(string str, Func<string, string> test3) { return test3(str); }  //удаление пробелов
        public static string Upper(string str, Func<string, string> test4) { return test4(str); }       //в верхний регистр
        public static string Lower(string str, Func<string, string> test5) { return test5(str); }       //в нижний регистр
    }

    class Program
    {
        static void Main(string[] args)
        {
            Programmer p1 = new Programmer("Серёга");

            //создать некоторое количество объектов (языков программирования)
            ProgrammingLanguage Lang1 = new ProgrammingLanguage("JS", 4.5f, "Add", "Del", "Rename");
            ProgrammingLanguage Lang2 = new ProgrammingLanguage("C#", 7.0f, "Add", "Del");

            Console.WriteLine(Lang2);


            p1.NewProperty += Lang1.Add;        //подписываем объект на событие
            p1.NewProperty += Lang1.Add;
            p1.NewProperty += Lang1.Add;

            p1.NewProperty += Lang2.Delete;
            p1.NewProperty += Lang2.Delete;

            p1.Rename += Lang1.Rename_L;
            p1.NewProperty -= Lang1.Add;

            Lang2.NewVersion(3.1);

            Lang2.AddOperation("Input");
            Lang1.DeleteOptions("Add");
            Console.WriteLine(Lang2);
            Console.WriteLine(Lang1);

            p1.CommandAddOperation();


            Func<string, string> test1;  //обобщенный делегат, второй параметр - возврат 
            Action<string> test2;       //не возвр значений
            Func<string, string> test3;
            Func<string, string> test4;
            Func<string, string> test5;
            test1 = str1 =>
            {  //блочное лямбда-выражение(упрощенная запись анонимных методов) 
                char[] sign = { '.', ',', '!', '?', '-', ':' };
                for (int i = 0; i < str1.Length; i++)
                {
                    if (sign.Contains(str1[i]))
                    {
                        str1 = str1.Remove(i, 1);
                    }
                }
                Console.WriteLine(str1);
                return str1;
            };
            test2 = delegate (string str2)   //анонимный метод
            {
                str2 += " World";
                Console.WriteLine(str2);
            };
            test3 = str3 =>
            {
                str3 = str3.Replace(" ", string.Empty);
                Console.WriteLine(str3);
                return str3;
            };
            test4 = str4 =>
            {
                str4 = str4.ToUpper();
                Console.WriteLine(str4);
                return str4;
            };
            test5 = str5 =>
            {
                str5 = str5.ToLower();
                Console.WriteLine(str5);
                return str5;
            };

            string str = "Hel?lo!";
            Console.WriteLine("Строка в начале: " + str);
            Console.WriteLine("Строки в конце: ");
            string s1, s2, s3;
            s1 = StringHandler.RemoveS(str, test1);
            StringHandler.AddToString(s1, test2);
            s2 = StringHandler.RemoveSpase(s1, test3);
            s3 = StringHandler.Upper(s2, test4);
            StringHandler.Lower(s3, test5);


        }
    }
    
}
