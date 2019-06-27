using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Paralleler
    {
        //5.Используя Класс Parallel распараллельте вычисления циклов For(), ForEach().
        //Например, на выбор: генерация нескольких массивов по 1000000 элементов. 
        //Оцените производительность по сравнению с обычными циклами
        public static void For()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Generate(10000);    //создали вектор
            stopwatch.Stop();
            Console.WriteLine("\nFor:\nОбщий цикл: " + stopwatch.Elapsed);
            stopwatch.Start();
            Parallel.For(1, 10000, Generate);
            stopwatch.Stop();
            Console.WriteLine("Параллельный цикл: " + stopwatch.Elapsed);
        }
        public static void ForEach()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (int v in new List<int>() { 10000, 10000 })
            {
                Generate(v);
            }
            stopwatch.Stop();
            Console.WriteLine("\nForEach:\nОбщий цикл: " + stopwatch.Elapsed);
            stopwatch.Start();
            ParallelLoopResult result = Parallel.ForEach<int>(new List<int>() { 10000, 10000 }, Generate);
            stopwatch.Stop();
            Console.WriteLine("Параллельный цикл: " + stopwatch.Elapsed);
        }
        public static void Generate(int n)
        {
            Vector vector = new Vector(n);
        }

        //6.Используя Parallel.Invoke() распараллельте выполнение блока операторов.
        public static void DoubleTask(int n)
        {
            Parallel.Invoke(Display,
                () => Console.WriteLine("Текущий id: " + Task.CurrentId),
                () => Console.WriteLine("Текущий iD: " + Task.CurrentId)
            );
        }
        private static void Display()
        {
            Console.WriteLine("\nТекущий ID: " + Task.CurrentId);
        }
    }
}
