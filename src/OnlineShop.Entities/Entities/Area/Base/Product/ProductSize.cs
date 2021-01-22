using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ProductSize:BaseEntity
    {
        public ProductSize()
        {
        }

        public Guid? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public Guid? SizeId { get; set; }

        [ForeignKey(nameof(SizeId))]
        public virtual Size Size { get; set; }
    }
}