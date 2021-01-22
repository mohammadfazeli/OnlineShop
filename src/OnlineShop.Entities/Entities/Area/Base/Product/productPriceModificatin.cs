using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ProductSalePrice:BaseEntity
    {
        public ProductSalePrice()
        {
        }

        public Guid? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public DateTime FromDate { get; set; }
    }
}