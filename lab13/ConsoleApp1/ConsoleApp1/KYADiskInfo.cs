using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    //Создать класс XXXDiskInfo c методами для вывода информации о
    //a.свободном месте на диске
    //b.  Файловой системе
    //c.Для каждого существующего диска  - имя, объем, доступный
    //объем, метка тома. 
    //d.Продемонстрируйте работу класса
    public class KYADiskInfo
    {
        public void DiskInfo()
        {
            var allDrives = DriveInfo.GetDrives();  // получение массива DriveInfo
            foreach (var d in allDrives)
            {
                if (d.Name == "C:\\" || d.Name == "E:\\" || d.Name == "H:\\")
                {
                    Console.WriteLine($"Диск {d.Name}\nСвободное место: {d.TotalFreeSpace}");
                    Console.WriteLine($"\nОбъём {d.TotalSize}\nМетка тома {d.VolumeLabel}\nДоступный объём { d.AvailableFreeSpace}");
                    string dirName = d.Name;
                    Console.WriteLine("Каталоги:");
                    if (Directory.Exists(dirName))
                    {
                        string[] dirs = Directory.GetDirectories(dirName); //получает список каталогов в каталоге dirName
                        foreach (string s in dirs)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
            }
        }
    }
    }


