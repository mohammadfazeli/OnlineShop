using System.Collections.Generic;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class Provider:BaseEntity
    {
        public Provider()
        {
            Products = new HashSet<Product>();
        }

        public string Name { get; set; }
        public string Addrss { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string ManagerName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}