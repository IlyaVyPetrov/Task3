using Task3.Core;
using Task3.Shop.Dal.Models;


namespace Task3.Shop.Dal.Repositories;

public class ShopDaoFileRepository : FileRepository<ShopDao>
{
    public ShopDaoFileRepository()
        : base("shops.txt")
    {
    }

    protected override int GetId(ShopDao item)
    {
        return item.Id;
    }
}