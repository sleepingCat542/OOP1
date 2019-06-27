using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab6
{
    class Exeption
    {
        public class ExceptionOfStruct : Exception
        {
            public ExceptionOfStruct(string mess) : base(mess) { }  //base значит, что мы берём mess из "класса-предка"
            public void GetInfo()
            {
                Console.WriteLine("ExceptionOfStruct: " + this.Message);
                Console.WriteLine(this.StackTrace);
                Console.WriteLine(this.TargetSite);
            }
        }
        public class StoneException : Exception
        {
            public StoneException(string mess) : base(mess) { }
            public void GetInfo()
            {
                Console.WriteLine("StoneException: " + this.Message);
                Console.WriteLine(this.StackTrace);
                Console.WriteLine(this.TargetSite);
            }
        }
        public class SenceException : Exception
        {
            public SenceException(string mess) : base(mess) { }
            public void GetInfo()
            {
                Console.WriteLine("SenceException: " + this.Message);
                Console.WriteLine(this.StackTrace);
                Console.WriteLine(this.TargetSite);
            }
        }
    }
}
