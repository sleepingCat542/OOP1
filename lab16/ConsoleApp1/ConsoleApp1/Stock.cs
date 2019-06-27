using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Stock
    {
        public static void Work()
        {
            BlockingCollection<int> appliances = new BlockingCollection<int>();
            Thread tprod = new Thread(() => AllProd());
            Thread tcust = new Thread(() => AllCust());
            tprod.Start();
            tcust.Start();
            void AllProd()
            {
                Task.Factory.StartNew(() => Producer(ref appliances, 5000, 1));
                Task.Factory.StartNew(() => Producer(ref appliances, 900, 2));
                Task.Factory.StartNew(() => Producer(ref appliances, 200, 3));
                Task.Factory.StartNew(() => Producer(ref appliances, 700, 4));
                Task.Factory.StartNew(() => Producer(ref appliances, 100, 5));
            }
            void AllCust()
            {
                Task.Factory.StartNew(() => Customer(ref appliances, 1000));
                Task.Factory.StartNew(() => Customer(ref appliances, 500));
                Task.Factory.StartNew(() => Customer(ref appliances, 3000));
                Task.Factory.StartNew(() => Customer(ref appliances, 500));
                Task.Factory.StartNew(() => Customer(ref appliances, 400));
                Task.Factory.StartNew(() => Customer(ref appliances, 234));
                Task.Factory.StartNew(() => Customer(ref appliances, 1807));
                Task.Factory.StartNew(() => Customer(ref appliances, 423));
                Task.Factory.StartNew(() => Customer(ref appliances, 2012));
                Task.Factory.StartNew(() => Customer(ref appliances, 600));
            }
        }

        public static void Producer(ref BlockingCollection<int> blockingCollection, int timeMs, int id)
        {
            blockingCollection.Add(id);
            int[] a = blockingCollection.ToArray();
            for (int z = 0; z < a.Length; z++)
            {
                Console.WriteLine($"p + {a[z]}");

            }
            Console.WriteLine();
            Thread.Sleep(timeMs);
        }

        public static void Customer(ref BlockingCollection<int> blockingCollection, int timeMs)
        {
            if (blockingCollection.Count != 0)
            {
                foreach (var n in blockingCollection.GetConsumingEnumerable())
                {
                    Console.WriteLine($"c - {n}");

                }

            }
            else { Console.WriteLine("c leave"); }
            Thread.Sleep(timeMs);
        }
    }
}
