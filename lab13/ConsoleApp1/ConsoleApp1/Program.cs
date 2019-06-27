using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace ConsoleApp1
{

    

    class Program
    {

        static void Main(string[] args)
        {

                KYADiskInfo diskInfo = new KYADiskInfo();   
                diskInfo.DiskInfo();

                KYAFileInfo fileInfo = new KYAFileInfo();
                fileInfo.FileData("E:\\Видео\\Death_NoteR2\\Death_NoteR2_[ru_jp].avi");

                KYADirInfo dirInfo = new KYADirInfo();
                dirInfo.DirInfo("E:\\Картинки");

                KYAFileManager fileManager = new KYAFileManager();
                fileManager.FileManager("E:");

           
        }
    }
}


