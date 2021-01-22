using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ProductColor:BaseEntity
    {
        public ProductColor()
        {
        }

        public Guid? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public Guid? ColorId { get; set; }

        [ForeignKey(nameof(ColorId))]
        public virtual Color Color { get; set; }
    }
}