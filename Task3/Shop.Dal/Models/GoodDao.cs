using Task3.Core;

namespace Task3.Shop.Dal.Models
{
    public class GoodDao: IPrimary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public GoodDao()
        {
            Name = string.Empty;
            Code = string.Empty;
        }
    }
}
