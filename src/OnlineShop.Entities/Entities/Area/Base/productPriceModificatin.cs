using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ProductPriceModificatin : BaseEntity
    {
        public Guid? ProductDetailId { get; set; }

        [ForeignKey(nameof(ProductDetailId))]
        public virtual ProductDetail ProductDetail { get; set; }

        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public DateTime FromDate { get; set; }
    }
}