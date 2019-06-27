using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        public static void ToWriteNum()
        {
                Console.WriteLine("Введите n: ");
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    using (StreamWriter sw = new StreamWriter("nums.txt", true))
                    {
                        sw.WriteLine(i);
                        Console.WriteLine(i);
                        Thread.Sleep(100);//Статический метод Sleep останавливает поток на определенное количество миллисекунд
                    }
                }
        }


        static class TwoThreads
        {
            public static void Consistently()                           //сначала чет, потом нечет
            {
                object locker = new object();               //объект-заглушка
                if (File.Exists("ch_nech.txt"))
                {
                    File.Delete("ch_nech.txt");
                }
                Thread CheT = new Thread(new ThreadStart(Chet));
                Thread NecheT = new Thread(new ThreadStart(Nechet));
                NecheT.Priority = ThreadPriority.AboveNormal;           //поменяли приоритет
                CheT.Start();
                NecheT.Start();

                void Chet()
                {
                    lock (locker)                   //блокирует блок кода до завершения работы текущего потока
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.WriteLine(i + " чёт");
                                WriteResultToFile(i);
                                Thread.Sleep(300);

                            }
                        }
                    }
                }
                void Nechet()
                {
                    lock (locker)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (i % 2 != 0)
                            {
                                Console.WriteLine(i + " нечёт");
                                WriteResultToFile(i);
                                Thread.Sleep(500);

                            }
                        }
                    }
                }
                void WriteResultToFile(int data)
                {
                    StreamWriter sw = new StreamWriter("ch_nech.txt", true);
                    sw.WriteLine(data);
                    sw.Close();
                }
            }



            public static void OneByOne()                           //чередуясь
            {
                Mutex mutex = new Mutex();
                if (File.Exists("ch_n_ch.txt"))
                {
                    File.Delete("ch_n_ch.txt");
                }
                Thread CheT = new Thread(new ThreadStart(Chet));
                Thread NecheT = new Thread(new ThreadStart(Nechet));
                CheT.Start();
                NecheT.Start();

                void Chet()
                {
                    for (int i = 0; i < 10; i++)
                    {
                        mutex.WaitOne();            //точка входа в критическую секцию для нескольких процессов    
                        if (i % 2 == 0)             //критич секция - участок прог-мы с общим ресурсом
                        {                                     //приостанавливает вып потока, пока не будет получен мьютекс
                            Console.WriteLine(i + " чёт");
                            WriteResultToFile(i);
                            Thread.Sleep(300);
                        }
                        mutex.ReleaseMutex();       //выход, потоко освобождает мьютекс
                    }
                }
                void Nechet()
                {
                    for (int i = 0; i < 10; i++)
                    {
                        mutex.WaitOne();
                        if (i % 2 != 0)
                        {
                            Console.WriteLine(i + " нечёт");
                            WriteResultToFile(i);
                            Thread.Sleep(500);
                        }
                        mutex.ReleaseMutex();
                    }
                }
                void WriteResultToFile(int data)
                {
                    StreamWriter sw = new StreamWriter("ch_n_ch.txt", true);
                    sw.WriteLine(data);
                    sw.Close();
                }
            }
        }
    
        static void Main(string[] args)
        {
            //1. Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет,
            //время запуска, текущее состояние, сколько всего времени использовал процессор и т.д.
            using (StreamWriter sw = new StreamWriter("processes.txt"))
            {
                Process[] allProcesses = Process.GetProcesses();    //получение всех процессов
                foreach (Process p in allProcesses)          //при запуске приложения ОС создает для него процесс,
                {                                           //которому выделяется определенное адр пр-во в памяти
                    sw.WriteLine("Имя компьютера: " + p.MachineName);
                    sw.WriteLine("id: " + p.Id);
                    sw.WriteLine("Имя: " + p.ProcessName);
                    sw.WriteLine("Приоритет: " + p.BasePriority);
                    //sw.WriteLine("Время запуска: " + p.StartTime);
                    sw.WriteLine("Ответ пользовательского интерфейса: " + p.Responding);
                    sw.WriteLine("Объём памяти: " + p.WorkingSet64);
                    sw.WriteLine("Общее время: " + p.TotalProcessorTime);
                    sw.WriteLine();
                }
            }
            //2. Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки, загруженные в домен.
            //При запуске приложения, написанного на C#, операционная система создает процесс, а среда CLR создает внутри этого процесса
            //логический контейнер, который называется доменом приложения и внутри которого работает запущенное приложение.
            AppDomain domain = AppDomain.CurrentDomain;               
            Console.WriteLine("Текущий домен");
            Console.WriteLine("Имя: " + domain.FriendlyName);
            Console.WriteLine("Детали конфигурации: " + domain.SetupInformation);
            Console.WriteLine("Сборки, загруженные в домен:");
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly a in assemblies)
            {
                Console.WriteLine(a.GetName().Name);
            }
            //Создайте новый домен.
            AppDomain newDomain = AppDomain.CreateDomain("New");
            newDomain.Load(new AssemblyName("ConsoleApp1"));
            //Загрузите туда сборку.
            Console.WriteLine("Имя нового домена: " + newDomain.FriendlyName + "\nСборки нового домена:");
            foreach (Assembly a in newDomain.GetAssemblies())
            {
                Console.WriteLine(a.GetName().Name);
            }
            //Выгрузите домен.
            AppDomain.Unload(newDomain);
            //Console.WriteLine("\nPress any key\n");
            //Console.ReadKey();


            //3. Создайте в отдельном потоке следующую задачу расчета (можно сделать sleep для задержки)
            //и записи в файл и на консоль простых чисел от 1 до n(задает пользователь).
            //Вызовите методы управления потоком(запуск, приостановка, возобновление и тд.) 
            //Во время выполнения выведите информацию о статусе потока, имени, приоритете.
            Console.WriteLine("\nПоток");                         //поток - используемый внутри процесса путь выполнения
            Thread thread = new Thread(ToWriteNum);                 //процесс содержит мин один поток - главный
            thread.Start();                                         //из главного - вторичные
            thread.Name = "MyThread";
            Thread.Sleep(1000);
            thread.Suspend();
            Console.WriteLine("Имя: " + thread.Name);
            Thread.Sleep(100);
            Console.WriteLine("Статус: " + thread.ThreadState);
            Thread.Sleep(100);
            Console.WriteLine("Приоритет: " + thread.Priority);
            Thread.Sleep(1000);
            thread.Resume();
            Thread.Sleep(3000);




            //4. Создайте два потока.Первый выводит четные числа, второй нечетные до n и
            //записывают их в общий файл и на консоль.Скорость расчета чисел у потоков – разная.
            //a.Поменяйте приоритет одного из потоков.
            //b.Используя средства синхронизации организуйте работу потоков, таким образом, чтобы
            //i. выводились сначала четные, потом нечетные числа
            Console.WriteLine("Сначала чётные");
            TwoThreads.Consistently();
            Thread.Sleep(4000);
            Console.WriteLine("\nНажмите кнопку\n");
            Console.ReadKey();
            //ii. последовательно выводились одно четное, другое нечетное.
            Console.WriteLine("Чередуясь:");
            TwoThreads.OneByOne();

            Thread.Sleep(7000);
            Console.WriteLine("\nНажмите кнопку\n");
            Console.ReadKey();


            //5. Придумайте и реализуйте повторяющуюся задачу на основе класса Timer
            TimerCallback tm = new TimerCallback(Count);    //метод обратного вызова
                                                            //таймер - запускает опред действия по истечению некоторого периода времени
            Timer timer = new Timer(tm, null, 500, 1000); //метод, объект для передачи в метод, мс через кот таймер запускается, интервал между вызовами метода
            Thread.Sleep(5000);
            Console.WriteLine("Времени прошло...");
            timer.Dispose();
            Process music = Process.Start("clock.mp3");
            Console.ReadKey();
            void Count(object obj)
            {
                Console.WriteLine($"Сейчас {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}");
            }



        }
    }
}
