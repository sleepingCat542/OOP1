﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class PreciousStone : Stone, IJeweleryWorkshop, IJeweleryReseller
    {
        public PreciousStone()
        {
            ProductType = "Неопределенный драгоценный камень";
        }

        public override string ToString()
        {
            return $"Информация о драгоценном: Вес - {Weight} грамм; Цвет - {Color}; Тип камня - {ProductType}; Цена - {Price}; Статус - {StatusDescription};  Прозрачность - {OpticProperty.Opacity}; Преломление - {OpticProperty.Refraction}.";
        }

        // реализация абстрактного метода класса Product
        public override string DefineMarket() // определить рынки сбыта
        {
            return "Рынки сбыта - Драгоценные камни";
        }

        //  реализация IJeweleryWorkshop
        public void MakeJewelry()
        {
            Console.WriteLine($"Создано драгоценное изделие из: {ProductType}");
        }

        public void MakeEarrings()
        {
            Console.WriteLine($"Созданы драгоценные серьги из: {ProductType}");
        }

        void IJeweleryWorkshop.ProcessStone()
        {
            Console.WriteLine($"Обработан камень: {ProductType}");
        }

        // реализация IJeweleryReseller
        public void SendToShop()
        {
            Console.WriteLine($"Камень: {ProductType} отправлен в ювелирный магазин");
        }

        public void PublishedInTheCatalog()
        {
            Console.WriteLine($"Камень: {ProductType} опубликован в каталоге");
        }

        void IJeweleryReseller.ProcessStone()
        {
            Console.WriteLine($"Камень: {ProductType} доставляется из страны происхождения");
        }
    }
}
