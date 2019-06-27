using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApp1
{
    //2. Создать класс XXXFileInfo c методами для вывода информации о конкретном файле
    //a.Полный путь
    //b.Размер, расширение, имя
    //c.Время создания
    //d. Продемонстрируйте работу класса
    class KYAFileInfo
    {
        public void FileData(string path)
        {
            Console.WriteLine("Информация о файле:");
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine($"\tПолный путь : {fileInf.DirectoryName}");
                Console.WriteLine($"\tИмя: {fileInf.Name}");
                Console.WriteLine($"\tРазмер: {fileInf.Length}\n\tРасширение: {fileInf.Extension}\n\t Время: {fileInf.CreationTime}");
            }
            else
            {
                Console.WriteLine("Такого файла нет");
            }
        }
    }
}
