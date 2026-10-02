using Task3.Shop.Dal.Models;
using Task3.Shop.Dal.Repositories;

class Program
{
    static void Main()
    {

        // Магазины
        var shopRepository = new ShopDaoFileRepository();

        shopRepository.Create(new ShopDao
        {
            Id = 1,
            Name = "Магазин №1",
            Code = "SHOP001"
        });

        shopRepository.Create(new ShopDao
        {
            Id = 2,
            Name = "Магазин №2",
            Code = "SHOP002"
        });

        Console.WriteLine("Магазины:");

        foreach (var shop in shopRepository.ReadAll())
        {
            Console.WriteLine(
                $"{shop.Id}: {shop.Name}, код: {shop.Code}");
        }


        // Клиенты

        var clientRepository = new ClientDaoFileRepository();

        var client = new ClientDao
        {
            Id = 1,
            FirstName = "Иван",
            LastName = "Иванов",
            Patronymic = "Иванович",
            BirthDate = new DateTime(2000, 5, 10)
        };

        clientRepository.Create(client);

        Console.WriteLine("\nКлиенты:");

        foreach (var c in clientRepository.ReadAll())
        {
            Console.WriteLine(
                $"{c.Id}: {c.LastName} {c.FirstName} {c.Patronymic}, " +
                $"возраст: {c.Age}");
        }



        // Товары
        var goodRepository = new GoodDaoFileRepository();

        goodRepository.Create(new GoodDao
        {
            Id = 1,
            Name = "Ноутбук",
            Code = "GOOD001"
        });

        Console.WriteLine("\nТовары:");

        foreach (var good in goodRepository.ReadAll())
        {
            Console.WriteLine(
                $"{good.Id}: {good.Name}, код: {good.Code}");
        }



        // Read
        var foundShop = shopRepository.Read(1);

        if (foundShop != null)
        {
            Console.WriteLine(
                $"\nНайден магазин: {foundShop.Name}");
        }



        // Update
        shopRepository.Update(new ShopDao
        {
            Id = 1,
            Name = "Обновлённый магазин",
            Code = "SHOP-NEW"
        });


        // Delete
        goodRepository.Delete(1);

        Console.WriteLine("\nТовар с Id = 1 удалён.");

        //shopRepository.Delete(1);
        //clientRepository.Delete(1);
    }
}