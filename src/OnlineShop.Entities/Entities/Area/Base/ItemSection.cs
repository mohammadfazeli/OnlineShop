using OnlineShop.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ItemSection : BaseEntity
    {
        public Guid? ProductDetailId { get; set; }

        [ForeignKey(nameof(ProductDetailId))]
        public virtual ProductDetail ProductDetail { get; set; }

        public ItemSectionType itemSectionType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}