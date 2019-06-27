using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    //Создайте обобщенный интерфейс с операциями добавить, удалить, просмотреть.
    interface IFunction<T> where T : struct
    {
        void Add(T element, int p);
        void Remove(int pos);
        void Show();
    }

    //Создайте обобщенный класс на основе 4 л.р.
    //Наследуйте обобщенный интерфейс, реализуйте необходимые методы.
    //Наложите какое-либо ограничение на обобщение.
    public class CollectionType<T> : IFunction<T> where T : struct
    {
        public T element;      //элемент массива
        public T[] Passwords;  //массив паролей
        public int Count { get { return this.Passwords.Length; } } //длина массива

        public CollectionType( int n) //конструктор для массива паролей
        {
            if (n < 1)
            {
                throw new Exception("Недостаточный размер!");
            }
            this.Passwords = new T[n];
        }
        public void Add(T el, int pos)
        {
            if(pos<Passwords.Length)
                Passwords[pos] = el;
            
        }
        
        public void Show()
        {
            if (Passwords.Length < 1)
            {
                throw new Exception("Недостаточный размер!");
            }
            for (int i = 0; i < Passwords.Length; i++)
            {
                System.Type A = Passwords[i].GetType();
                string s1 = "ConsoleApp1.Stone";
                if ((A.ToString()).Equals(s1)) 
                {
                    Console.WriteLine((i + 1) + " элемент: " + Passwords[i].ToString());
                } 
                else
                Console.WriteLine((i + 1) + " элемент: " + Passwords[i]);
            }

        }
        public void Remove(int pos) //удалить пароль
        {
            for (int o = pos; o < Passwords.Length; o++)
            {
                Passwords[o] = Passwords[o + 1];
            }
        }
        //Добавьте методы сохранения объекта (объектов) обобщённого типа CollectionType<T> в файл и чтения из него.
        public void ToFile(CollectionType<T> type)
        {
            string[] elem = new string[Passwords.Length];
            for (int i = 0; i < Passwords.Length; i++)
            {
                    elem[i] = Convert.ToString(Passwords[i]);
            }

            File.WriteAllLines(@"H:\ООП\Лабы\8lab\v.txt", elem);
        }
        public void FromFile()
        {
            Console.WriteLine(File.ReadAllText(@"H:\ООП\Лабы\8lab\v.txt"));
        }
    }


    //Определить пользовательский класс, который будет использоваться в качестве параметра обобщения(из 5 л.р.).
    struct Stone
    {
        public int Weight { get; set; }
        public string Color { get; set; }

        public Stone(int weight, string color)
        {
            this.Weight = weight;
            this.Color =color;
        }
        public override string ToString()
        {
            return $"Камень:\n цвет: {this.Color}, вес: {this.Weight}";
        }
    }

    //Добавьте обработку исключений с finally.
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CollectionType<int> pas1 = new CollectionType<int>(3);
                CollectionType<short> pas2 = new CollectionType<short>(2);
                //CollectionType<long> pas3 = new CollectionType<long>(0);

                pas1.Add(45735, 0);
                pas1.Add(2469824, 1);
                pas1.Add(244574, 2);
                pas2.Add(455, 0);
                pas2.Add(537, 1);

                Stone a = new Stone(436, "Белый");
                Stone b = new Stone(426, "Жёлтый");
                Stone c = new Stone(76, "Синий");
                Stone d = new Stone(37, "Прозрачный");
                CollectionType<Stone> wb1 = new CollectionType<Stone>(3);
                CollectionType<Stone> wb2 = new CollectionType<Stone>(2);
                Console.WriteLine("Выводим через Show()");
                pas1.Show();
                wb1.Add(c, 0);
                wb1.Add(d, 1);
                wb1.Add(a, 2);
                pas1.ToFile(pas1);
                Console.WriteLine("Выводим из файла");
                pas1.FromFile();
                wb1.ToFile(wb1);
                wb1.FromFile();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Конец.");
            }

        }
    }
}
