using Task3.Core;
using Task3.Shop.Dal.Models;
namespace Task3.Shop.Dal.Repositories;

public class GoodDaoFileRepository : FileRepository<GoodDao>
{
    public GoodDaoFileRepository()
        : base("goods.txt")
    {
    }

    protected override int GetId(GoodDao item)
    {
        return item.Id;
    }
}
