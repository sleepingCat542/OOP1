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

        //public void CommandAddOperation()
        //{
        //    NewProperty?.Invoke(this, null);
        //}

        //public void CommandRenOperation()
        //{
        //    Rename?.Invoke(this, null);
        //}
    }


    class StringFunction
    {
        public delegate string StringFun(ref string str);
        static public string OperationString(string str, Func<string, string> func) => str != null ? func(str) : func("");

        static public string AddStr(string str1, string str2) => str1 += str2;


        static public string Reverse(ref string str) => str = new string(str.ToCharArray().Reverse().ToArray());


        static public string RemoveSpace(ref string str) => str = str.Replace(" ", String.Empty);



        static public string ToUpperFirstLetters(ref string str)
        {

            for (int i = 0; i < str.Length; i++)
            {
                bool flag = false;
                if (i == 0)
                {
                    str = str.Replace(str[i], Char.ToUpper(str[i]));
                }
                if (str[i] == ' ')
                {
                    flag = true;
                }
                if (flag == true)
                {
                    str = str.Replace(str[i + 1], Char.ToUpper(str[i + 1]));
                    flag = false;
                }
            }
            return str;
        }


        static public string RemoveSymbol(ref string str)
        {
            char[] sign = ".></?=+-|_)(*&^:%;$№#@".ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (sign.Contains(str[i]))
                {
                    str = str.Remove(i, 1);
                    --i;
                }
            }
            return str;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Programmer programmer = new Programmer("Скуби");
            ProgrammingLanguage p = new ProgrammingLanguage("JS", 4.5f, "Add", "Del", "Rename");
            ProgrammingLanguage c = new ProgrammingLanguage("C#", 7.0f, "Add", "Del");
            Console.WriteLine(p.ToString());
            p.GetOperation();
            Console.WriteLine(c.ToString());
            c.GetOperation();
            //c.NewOpt = p.NewOpt = "Concat";
            programmer.NewProperty += p.AddOperation;
            //programmer.NewProperty += c.AddOperation;
            //p.DelOpt = "Del";
            programmer.NewProperty += p.DeleteOptions;
            programmer.Rename += p.NewVersion;
            //programmer.CommandAddOperation();
            //programmer.CommandRenOperation();
            //p.NewOpt = "Range";
            //c.NewOpt = "District";
            programmer.NewProperty -= p.DeleteOptions;
            //programmer.CommandAddOperation();
            Console.WriteLine(p.ToString());
            p.GetOperation();
            Console.WriteLine(c.ToString());
            c.GetOperation();

            //------------------------------
            string str = "dne/ir*f @y#m ,";

            string forExampleStr = "Abrarkadabra";
            Console.WriteLine(StringFunction.OperationString(forExampleStr, x => x.Replace("bra", String.Empty)));


            Console.WriteLine($"Строка до: {str}");
            str = StringFunction.AddStr(str, "?dlr_ow_)_(     ^o_l_l)eh");
            Console.WriteLine($"После: {str}\n");

            Console.WriteLine($"Строка до: {str}");
            StringFunction.StringFun delStrFun = StringFunction.RemoveSymbol;
            delStrFun += StringFunction.Reverse;
            delStrFun += StringFunction.ToUpperFirstLetters;
            delStrFun += StringFunction.RemoveSpace;
            delStrFun(ref str);
            Console.WriteLine($"После: {str}\n");

            //Console.WriteLine($"Строка до: {str}");
            //str = StringFunction.RemoveSymbol(str);
            //Console.WriteLine($"После: {str}\n");

            //Console.WriteLine($"Строка до: {str}");
            //str = StringFunction.Reverse(str);
            //Console.WriteLine($"После: {str}\n");

            //Console.WriteLine($"Строка до: {str}");
            //str = StringFunction.ToUpperFirstLetters(str);
            //Console.WriteLine($"После: {str}\n");

            //Console.WriteLine($"Строка до: {str}");
            //str = StringFunction.RemoveSpace(str);
            //Console.WriteLine($"После: {str}\n");

            Console.ReadKey();
        }
    }
}
