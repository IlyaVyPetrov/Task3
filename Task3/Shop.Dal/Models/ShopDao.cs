namespace Task3.Shop.Dal.Models;

using Task3.Core;

public class ShopDao: IPrimary
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    public ShopDao()
    {
        Name = string.Empty;
        Code = string.Empty;
    }

}
