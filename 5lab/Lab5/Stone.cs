﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Stone : Product
    {
        public int Weight { get; set; }
        public string Color { get; set; }


        public Stone()
        {
            ProductType = "Неопределенный камень";
        }

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
            return $"Информация о камне: Вес - {Weight} грамм; Цвет - {Color}; Тип камня - {ProductType}; Цена - {Price}; Статус - {StatusDescription}.";
        }

        public override bool Equals(object obj)
        {
            var stone = obj as Stone;//т.е. если obj совместим с типом Stone

            if (stone == null)//если не совместим
                return false;

            return this.Weight == stone.Weight &&
                   this.Color == stone.Color &&
                   this.Status == stone.Status &&
                   this.ProductType == stone.ProductType;
        }

        public override int GetHashCode()
        {
            return ProductType.GetHashCode() * 17 + Color.GetHashCode() * 19 + Price.GetHashCode() * 17;
        }

        // реализация абстрактоного метода класса Product
        public override string DefineMarket() // определить рынки сбыта
        {
            return "Рынки сбыта - камни и минералы";
        }
    }
}
