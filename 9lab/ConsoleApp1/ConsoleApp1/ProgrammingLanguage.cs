using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
        class ProgrammingLanguage
        {
            public string nameLang { get; set; }
            public float versionLang { get; set; }

            public List<String> operationInLang = new List<String>();
            public string newOpt { get; set; }
            public string delOpt { get; set; }

        //public string NewOpt
        //{
        //    set => newOpt = value;
        //}
        //public string DelOpt
        //{
        //    set => delOpt = value;
        //}
        //public string NameLang
        //{
        //    get => nameLang;
        //    set => nameLang = value;
        //}

        //public float VersionLang
        //{
        //    get => versionLang;
        //    set => versionLang = value;
        //}

        public ProgrammingLanguage(string nameLang, float versionLang, params string[] optionsArr)
        {
            this.nameLang = nameLang;
            this.versionLang = versionLang;
            foreach (string arr in optionsArr)
            {
                operationInLang.Add(arr);
            }
        }

        public override string ToString()
        {
            string[] mass = operationInLang.ToArray();
            string Operations()
            {
                string set = "";
                foreach (string arr in mass)
                {
                    set = set +"\n" + arr;
                }
                return set;
            }
            return $"{nameLang} v-{versionLang} \n Доступные операции:\n {Operations()}";
        } 

        public void GetOperation()
            {
                foreach (string operations in operationInLang)
                {
                    Console.WriteLine($"{operations}");
                }
            }

            public void AddOperation(Object sender, EventArgs e)
            {
                operationInLang.Add(newOpt);
                Console.WriteLine($"Мы добавили в нашу программу: {nameLang}-{newOpt}");
            }

            public void DeleteOptions(Object sender, EventArgs e)
            {
                operationInLang.Remove(delOpt);
                Console.WriteLine($"Мы исключили из нашей программы: {nameLang}-{delOpt}");
            }

            public void NewVersion(Object sender, EventArgs e)
            {
                versionLang = versionLang + 1.0f;
                versionLang = (float)(int)(versionLang);
                Console.WriteLine($"Мы используем новую версию нашей программы: {nameLang}-{versionLang}");
            }     
    }
}
