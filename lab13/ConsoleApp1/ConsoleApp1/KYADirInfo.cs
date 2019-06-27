using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
//3. Создать класс XXXDirInfo c методами для вывода информации о конкретном директории
//a.Количестве файлов
//b.Время создания
//c.Количестве поддиректориев
//d.Список родительских директориев
//e. Продемонстрируйте работу класса
namespace ConsoleApp1
{
    class KYADirInfo
    {
        public void DirInfo(string dirName)
        {
            Console.WriteLine("\nИнформация о папке:");

                string[] files = Directory.GetFiles(dirName);
                int countF = 0;
                foreach (string s in files)
                {
                    countF++;
                }
                Console.WriteLine($"\tКоличество файлов: {countF}");
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                Console.WriteLine("\tВремя создания: {dirInfo.CreationTime}");

                string[] dirs = Directory.GetDirectories(dirName);
                int countD = 0;
                foreach (string s in dirs)
                {
                    countD++;
                }
                Console.WriteLine($"\tКоличество поддиректориев: {countD}");

                Console.WriteLine($"\tРодительские директории: {dirInfo.Parent}");
            }

        }
    }

