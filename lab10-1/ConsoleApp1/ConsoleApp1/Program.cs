using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Student
    {
        public string Name;
        public string Spec;
        public Student(string name, string spec)
        {
            this.Name = name;
            this.Spec = spec;
        }
    }

    public class Stone
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }


        public Stone(string name, int weight, string color)
        {
            this.Name = name;
            this.Weight = weight;
            this.Color = color;
        }

        public override string ToString()
        {
            return $"Информация о камне {Name}: Вес - {Weight} грамм; Цвет - {Color}.";
        }

        public override bool Equals(object obj)
        {
            var stone = obj as Stone;//т.е. если obj совместим с типом Stone

            if (stone == null)//если не совместим
                return false;

            return this.Weight == stone.Weight &&
                   this.Color == stone.Color;
        }

        public override int GetHashCode()
        {
            return Color.GetHashCode() * 19;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //1. Создать необобщенную коллекцию ArrayList.
            //a.Заполните ее 5 - ю случайными целыми числами
            //b.Добавьте к ней строку
            //c.Добавьте объект типа Student
            //d.Удалите заданный элемент
            //e.Выведите количество элементов и коллекцию на консоль.
            //f.Выполните поиск в коллекции значения
            ArrayList Arr = new ArrayList(20); //определяется массив переменной длины, который состоит из ссылок на объекты
            Random random = new Random();
            for (int i = 0; i < 5; i++)
                Arr.Add(random.Next(1, 100));
            Arr.Add("Hi!");

            Student s1 = new Student("Миша", "ДЭВИ");
            Arr.Add(s1);

            Arr.Remove(3);


            Console.WriteLine("Количество элементов в массиве:" + Arr.Count + "\n");
            foreach (var x in Arr)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine($"Индекс элемента (Hi!)={Arr.IndexOf("Hi!")}");



            //Создать обобщенную  коллекцию в  соответствии с  вариантом задания  и
            //заполнить ее данными, тип которых определяется вариантом задания
            //a.Вывести коллекцию на консоль

            List<char> kollection1 = new List<char>();
            kollection1.Add('k');
            kollection1.Add('u');
            kollection1.Add('k');
            kollection1.Add('u');
            kollection1.Add('r');
            kollection1.Add('u');
            kollection1.Add('z');
            kollection1.Add('a');
            foreach (var i in kollection1)
                Console.WriteLine(i);

            //b.Удалите из коллекции n последовательных элементов

            Console.WriteLine("Введите номер 1-ого элемента:");
            int indOfFirstEl = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество элементов:");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = indOfFirstEl, kol=0; kol < n; kol++)
            {
                kollection1.RemoveAt(i);
            }
            foreach (var i in kollection1)
                Console.WriteLine(i);

            //c.Добавьте другие  элементы(используйте  все  возможные  методы добавления для вашего типа коллекции).
            kollection1.Insert(3, Convert.ToChar("v"));
            kollection1.Insert(3, Convert.ToChar("e"));


            //d.Создайте  вторую коллекцию(см.таблицу)  и заполните  ее данными  из первой коллекции.

            Dictionary<int, char> dictionary = new Dictionary<int, char>();
            for (int i = 0, j = 0; j < kollection1.Count; j++, i++)
            {
                char el1 = kollection1.ElementAt(i);
                dictionary.Add(i * 3, el1);
            }
            foreach (var i in dictionary)
                Console.WriteLine(i);

            //f.Найдите во второй коллекции заданное значение.
            Console.WriteLine("Введите значение, которое хотите найти:");
            char search = Convert.ToChar(Console.ReadLine());
            foreach (var i in dictionary)
            {
                if (i.Value == search)
                    Console.WriteLine($"Такой символ существует и вот его ключ:{i.Key}");
            }


            //3.Повторите задание п.2 для пользовательского типа данных(в качестве типа
            //T  возьмите любой  свой класс  из лабораторной  №5.
            Stone st1 = new Stone("Янтарь", 24, "Оранжевый");
            Stone st2 = new Stone("Аметист", 36, "Зелёный");
            Stone st3 = new Stone("Лазурит", 42, "Синий");

            Dictionary<int, Stone> stones = new Dictionary<int, Stone>();
            stones.Add(5, st1);
            stones.Add(10, st2);
            stones.Add(15, st3);

            foreach (var i in stones)
                Console.WriteLine(i);

            Console.WriteLine("Введите ключ для удаления элемента:");
            string s = Console.ReadLine();
            stones.Remove(int.Parse(s));
            foreach (var i in stones)
                Console.WriteLine(i);


            //Найдите во второй коллекции заданное значение.
            Console.WriteLine("Введите имя камня, который хотите найти:");
            string sear = Console.ReadLine();
            foreach (var i in stones)
            {
                if (i.Value.Name == sear)
                    Console.WriteLine($"Такой символ существует и вот его ключ:{i.Key}");
                
            }

            //4.Создайте объект наблюдаемой коллекции ObservableCollection<T>. Создайте
            //произвольный  метод и  зарегистрируйте его    на событие  CollectionChange.
            //Напишите демонстрацию  с добавлением  и удалением  элементов.В качестве
            //типа T используйте свой класс из лабораторной №5 Наследование…. 
            ObservableCollection<Stone> ob = new ObservableCollection<Stone>();
            ob.CollectionChanged += CollectionChanged;
            ob.Add(new Stone("Алмаз", 102, "Прозрачный"));
            ob.Add(new Stone("Рубин", 52, "Красный"));
            ob.RemoveAt(1);
            void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Stone newA = e.NewItems[0] as Stone;
                        Console.WriteLine("Объект был добавлен: " + newA.Name);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Stone oldA = e.OldItems[0] as Stone;
                        Console.WriteLine("Объект был удалён: " + oldA.Name);
                        break;
                }
            }
            foreach (Stone i in ob)
            {
                Console.WriteLine(i);
            }
        }
    }
}