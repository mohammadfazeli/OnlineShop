using System.Collections.Generic;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class Size:BaseEntity
    {
        public Size()
        {
            ProductSize = new HashSet<ProductSize>();
        }

        public string Name { get; set; }
        public string ForeignName { get; set; }
        public virtual ICollection<ProductSize> ProductSize { get; set; }
    }
}