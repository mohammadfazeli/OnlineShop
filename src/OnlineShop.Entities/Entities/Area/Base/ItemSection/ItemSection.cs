using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ItemSection:BaseEntity
    {
        public Guid? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public Guid? SectionId { get; set; }

        [ForeignKey(nameof(SectionId))]
        public virtual Section Section { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}