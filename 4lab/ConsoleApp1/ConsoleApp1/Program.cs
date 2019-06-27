using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Owner
    {
        public int id;
        public string name;
        public string organization;

        public Owner(int i, string nam, string organizat)
        {
            id = i;
            nam = name;
            organizat = organization;
        }
    }


    public class Password
    {
        public string pas;
        static int quantity;

        public Password(string p)
        {
            pas=p;
            quantity++;
        }
        // индексатор
        public char this[int index]
        {
            get
            {
                return pas[index];
            }
            set => pas[index] = value;
        }
        //если перегружаются операторы == и !=, то для этого требуется переопределить методы Object.Equals() и Object.GetHashCode().
        public override bool Equals(object str) //переопределение
        {
            if (str == null)
            {
                return false;
            }
            if (str.GetType() != this.GetType())
            {
                return false;
            }
            Strin temp = (Strin)str;
            return  this.stri == temp.stri;
        }
        public override int GetHashCode()
        {
            int hash= stri.Length*185;
            return hash;
        }


        // - удалить элемент из строки из заданной позиции
        public static Strin operator -(Strin st, int position)
        {
            int m = st.Length;
            if (position > m)
            {
                Console.WriteLine("Выходим за границу строки");
            }
            else
            {
                for (int i = 0; i < m; i++)
                {
                    if (i == position)
                    {
                        st[i] = st[i + 1];
                    }
                    m--;
                }
            }
                return (st);
        }

        public static Strin operator +(Strin st,  char ch)
        {
            int m = st.Length;
                for (int i = 0; i < m; i++)
                {
                    st[i+1]=ch;
                }
            
            return (st);
        }

        public static bool operator >(Strin st1, Strin st2)//проверка на вхождение подстроки
        {
            for(int i=0; i<st1.Length; i++)
            {
                for (int w = 0; w < st2.Length; w++)
                {
                    if (st1[i] == st2[w])
                    {

                        return true;
                    }
                    
                }
            }
                return false;

        }
        public static bool operator <(Strin st1, Strin st2)//проверка на вхождение подстроки
        {
            for (int i = 0; i < st2.Length; i++)
            {
                for (int w = 0; w < st1.Length; w++)
                {
                    if (st1[i] == st2[w])
                    {

                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator ==(Strin st1, Strin st2)
        {
            return st1.Equals(st2);
        }
        
        public static bool operator !=(Strin st1, Strin st2)
        {
            return !st1.Equals(st2);
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
        public static string SeekMax(Strin st)
        {
                string max = st[0];
                for (int i= 0; i < st.Length; i++ )
                {
                    if(st[i].Length > max.Length)
                    {
                        max = st[i];
                    }

                }
                return max;
        }
        public static string SeekMin(Strin st)
            {
                string min = st[0];
                for (int i = 0; i < st.Length; i++)
                {
                    if (st[i].Length > min.Length)
                    {
                        min = st[i];
                    }

                }
                return min;
            }
        public static void Quantity()
            {
                quantity++;
                Console.WriteLine("Количество элементов:" + quantity);
            }

        //Добавьте к классу MathOperation методы расширения вашего типа
        public static int QuantityWords(Strin st[m])  //Подсчет количества слов в строке  
        {
            for (int i=0; i<st.Length)
        }

        public static Strin Smile(Strin st)  //Добавление в строке смайликов 
        {
                //st = String.Concat(st, ":-):-):-):-):-)");
                Strin s = new Strin(4);
                s = "))))";
                st.stri=st.stri+s;
            return (st);
        }
    }
}
    
   
    class Program
    { 
        static void Main(string[] args)
        {
            int n = 5;
            Strin s1 = new Strin;
            s1[0] = "H";

        }
    }
}
