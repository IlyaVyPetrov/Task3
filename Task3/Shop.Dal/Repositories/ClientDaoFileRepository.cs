using Task3.Core;
using Task3.Shop.Dal.Models;

namespace Task3.Shop.Dal.Repositories;

public class ClientDaoFileRepository : FileRepository<ClientDao>
{
    public ClientDaoFileRepository()
        : base("clients.txt")
    {
    }

    protected override int GetId(ClientDao item)
    {
        return item.Id;
    }
}