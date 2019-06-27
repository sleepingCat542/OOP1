using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Configuration;
using System.Runtime.Serialization.Formatters;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;

namespace ConsoleApp1
{
    [DataContract]
    [Serializable]      //сериализуемый тип, все его поля также имеют сериализуемый тип
    public abstract class Product 
    {
        [DataMember] public int Price { get; set; }
        [DataMember] public ProductStatus Status { get; set; }

        public Product()
        {
            Status = ProductStatus.None;
        }

        public string StatusDescription //описание состояния
        {
            get
            {
                switch (Status)
                {
                    case ProductStatus.None:
                        return "Нет на складе";
                    case ProductStatus.Ordered:
                        return "Заказан";
                    case ProductStatus.Ready:
                        return "На складе";
                    case ProductStatus.Damaged:
                        return "Поврежден";
                    default:
                        return "Нет на складе";
                }
            }
        }

        public abstract string DefineMarket(); // определить рынки сбыта


    }
    public enum ProductStatus
    {
        None, // Нет на складе
        Ordered, // Заказан
        Ready, // На складе
        Damaged // Поврежден
    }

    [DataContract]
    [Serializable]
    public class Stone : Product
    {
        [DataMember] public int Weight { get; set; }
        [DataMember] public string Color { get; set; }



        public virtual void DamageTest(int power) // виртуальный метод - тест на прочность 
        {
            if (power < 1000)
            {
                Console.WriteLine("Камень не прошел тест на прочность");
                Status = ProductStatus.Damaged;
            }
            else Console.WriteLine("Камень прошел тест на прочность");
        }

        public override string ToString()
        {
            return $"Информация о камне: Вес - {Weight} грамм; Цвет - {Color}; Цена - {Price}; Статус - {StatusDescription}.";
        }

        public override bool Equals(object obj)
        {
            var stone = obj as Stone;//т.е. если obj совместим с типом Stone

            if (stone == null)//если не совместим
                return false;

            return this.Weight == stone.Weight &&
                   this.Color == stone.Color &&
                   this.Status == stone.Status;
        }


        // реализация абстрактоного метода класса Product
        public override string DefineMarket() // определить рынки сбыта
        {
            return "Рынки сбыта - камни и минералы";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Из лабораторной  №5    выберите класс  с наследованием  и / или
            //композицией / агрегацией  для сериализации.  Выполните
            //сериализацию / десериализацию объекта используя
            //a.бинарный,  
            var stone1 = new Stone { Color = "Белый", Price = 20, Status = ProductStatus.Ready, Weight = 100 };
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("Product1.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, stone1);
            }
            // десериализация 
            using (FileStream fs = new FileStream("Product1.dat",
            FileMode.OpenOrCreate))
            {
                Stone newStone = (Stone)formatter.Deserialize(fs);
                Console.WriteLine($"{newStone}");
            }

            //b.SOAP,
            var pStone1 = new Stone { Color = "Желтый", Price = 40, Status = ProductStatus.Ready, Weight = 40 };
                SoapFormatter soapFormatter = new SoapFormatter();
                using (Stream fStream = new FileStream("Product2.soap",
                FileMode.Create))
                {
                    soapFormatter.Serialize(fStream, pStone1);
                }
                using (FileStream fs = new FileStream("Product2.soap",
                FileMode.Open))
                {
                Stone newStone2 = (Stone)soapFormatter.Deserialize(fs);
                Console.WriteLine($"{newStone2}");
                }

            //c.JSON формат

            var ruby1 = new Stone { Color = "Red", Price = 57, Status = ProductStatus.None, Weight = 30 };
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Stone));
            using (FileStream fs = new FileStream("Product3.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, ruby1);
            }
            using (FileStream fs = new FileStream("Product3.json", FileMode.OpenOrCreate))
            {
                Stone newStone3 = (Stone)jsonFormatter.ReadObject(fs);
                Console.WriteLine($"{newStone3}");
            }

            //d.XML формат
            var diamond1 = new Stone { Color = "Прозрачный", Price = 89, Status = ProductStatus.Ready, Weight = 28 };
            XmlSerializer xml = new XmlSerializer(typeof(Stone));
            using (FileStream fs = new FileStream("Product4.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, diamond1);
            }
            using (FileStream fs = new FileStream("Product4.xml", FileMode.OpenOrCreate))
            {
                Stone newStone4 = xml.Deserialize(fs) as Stone;
                Console.WriteLine($"{newStone4}");
            }

            //2.Создайте  коллекцию(массив)  объектов и  выполните
            //сериализацию / десериализацию.
            var s1 = new Stone { Color = "Розовый", Price = 57, Status = ProductStatus.None, Weight = 30 };
            var s2 = new Stone { Color = "Синий", Price = 89, Status = ProductStatus.Ready, Weight = 28 };
            var s3 = new Stone { Color = "Зелёный", Price = 30, Status = ProductStatus.None, Weight = 41 };
            var s4 = new Stone { Color = "Чёрный",  Price = 50, Status = ProductStatus.Ready, Weight = 44 };
            Stone[] arr = new Stone[] { s1, s2, s3, s4 };

            DataContractSerializer array = new DataContractSerializer(typeof(Stone[]));  
            using (FileStream fs = new FileStream("array.xml", FileMode.OpenOrCreate))
            {
                array.WriteObject(fs, arr);
            }
            using (FileStream fs = new FileStream("array.xml", FileMode.OpenOrCreate))
            {
                Stone[] newS = (Stone[])array.ReadObject(fs);
                foreach (Stone s in newS)
                {
                    Console.WriteLine($"{s}");
                }
            }

            //3.Используя XPath напишите два селектора для вашего XML документа.

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("array.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList all = xRoot.SelectNodes("*");   //выбирает все узлы
            foreach (XmlNode x in all)
            {
                Console.WriteLine(x.OuterXml);         //вывод всей разметки
            }

            XmlNode parts = xRoot.FirstChild;  //выбирает узлы Stone
             Console.WriteLine(parts.FirstChild.InnerText); //вывод значения первого узла 


            //4.Используя Linq to XML(или Linq to JSON) создайте новый xml(json) - документ и напишите несколько запросов.
            XDocument xdoc = new XDocument();
            XElement stoneshop = new XElement("stoneshop"); //первый эл
            XAttribute bs_name_attr = new XAttribute("name", "theorite");
            XElement bs_country_elem = new XElement("country", "Belgium");
            XElement bs_auc_elem = new XElement("auction", "yes");
            stoneshop.Add(bs_name_attr);            //заполняем аттрибутом и элем-ми
            stoneshop.Add(bs_country_elem);
            stoneshop.Add(bs_auc_elem);

            XElement stoneshop2 = new XElement("stoneshop"); // второй эл
            XAttribute bs_name_attr2 = new XAttribute("name", "ametrine");
            XElement bs_country_elem2 = new XElement("country", "Bolivia");
            XElement bs_auc_elem2 = new XElement("auction", "yes");
            stoneshop2.Add(bs_name_attr2);          //заполняем аттрибутом и элем-ми
            stoneshop2.Add(bs_country_elem2);
            stoneshop2.Add(bs_auc_elem2);

            XElement root = new XElement("root");   //корневой элемент
            root.Add(stoneshop);
            root.Add(stoneshop2);
            xdoc.Add(root);
            xdoc.Save("linq.xml");                  //сохраняем в файл

            Console.WriteLine("Где найти Аметрин?"); //1-й запрос
            var items = xdoc.Element("root").Elements("stoneshop")
                .Where(p => p.Attribute("name").Value == "ametrine")
                .Select(p => p);
            foreach (var item in items)
            {
                Console.WriteLine(item.Element("country").Value);
            }
            Console.WriteLine("Какие камни представлены на аукционе?");//2-й запрос
            var coun = xdoc.Element("root").Elements("stoneshop")
                .Where(p => p.Element("auction").Value == "yes")
                .Select(p => p);
            foreach (var c in coun)
            {
                Console.WriteLine(c.Attribute("name").Value);
            }
        }
    }
}
