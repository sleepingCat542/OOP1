using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;



namespace ConsoleApp1
{
    //4. Создать класс XXXFileManager.Набор методов определите самостоятельно.С его помощью выполнить следующие действия:
    //a.Прочитать список файлов и папок заданного диска. Создать директорий XXXInspect, создать текстовый файл
    //xxxdirinfo.txt и сохранить туда информацию. Создать копию файла и переименовать его. 
    //Удалить первоначальный файл.
    class KYAFileManager
    {
        public void FileManager(string path)
        {
            Console.WriteLine("\nМенеджер Файлов:");
            string filepath = path + "KYAInspect";
            Directory.CreateDirectory(filepath);   //создаём папку с filepath

            string filename = filepath + "\\" + "kyadirinfo.txt";
            FileInfo file = new FileInfo(filename);

            using (FileStream fstream = new FileStream(filename, FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                if (Directory.Exists(path))
                {
                    sw.WriteLine("Файлы:");
                    string[] files = Directory.GetFiles(path);
                    foreach (string s in files)
                    {
                        sw.WriteLine(s);
                    }

                    sw.WriteLine("Папки:");
                    string[] dirs = Directory.GetDirectories(path);
                    foreach (string s in dirs)
                    {
                        sw.WriteLine(s);
                    }
                }
                else
                {
                    sw.WriteLine("Такой папки нет");
                }
                sw.Close();
            }

            file.CopyTo(filepath + "\\" + "newKYADirInfo.txt", true);
            file.Delete();

            //b.Создать еще один директорий XXXFiles.Скопировать в него все файлы с заданным расширением из заданного
            //пользователем директория. Переместить XXXFiles в XXXInspect.
            string filecopydir = path + "KYAFiles";
            DirectoryInfo directory = new DirectoryInfo(filecopydir);
            directory.Create();

            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files2 = d.GetFiles("*.pdf");
            foreach (FileInfo s in files2)
            {
                s.CopyTo(filecopydir + "\\" + s.Name, true);
            }
            directory.MoveTo("E:\\KYAInspect");  

            //c.Сделайте архив из файлов директория XXXFiles.
            //Разархивируйте его в другой директорий.
            ZipFile.CreateFromDirectory("E:\\KYAInspect\\KYAFiles", "H:\\ООП\\ar.zip");
            ZipFile.ExtractToDirectory("E:\\ar.zip", "E:\\Archive\\");
        }
    }
}
