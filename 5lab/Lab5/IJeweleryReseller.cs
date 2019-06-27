namespace Lab5
{
    public interface IJeweleryReseller // поставщик ювелирных камней
    {
        void PublishedInTheCatalog(); // подготовить камень для продажи
        void ProcessStone(); // камень в процессе получения из страны производителя
        void SendToShop(); // отправить камень в магазин
    }
}