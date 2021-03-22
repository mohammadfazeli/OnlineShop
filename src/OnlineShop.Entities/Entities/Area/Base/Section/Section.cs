using System.Collections.Generic;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class Section:BaseEntity
    {
        public Section()
        {
            ItemSections = new HashSet<ItemSection>();
        }

        public string Name { get; set; }

        public virtual ICollection<ItemSection> ItemSections { get; set; }
    }
}