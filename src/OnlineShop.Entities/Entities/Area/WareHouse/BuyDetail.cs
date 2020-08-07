using OnlineShop.Entities.Entities.Area.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.WareHouse
{
    public class BuyDetail : BaseEntity
    {


        public Guid? BuyId { get; set; }
        [ForeignKey(nameof(BuyId))]
        public virtual ProductRequest Buy { get; set; }

        public Guid? ProductDetailId { get; set; }
        [ForeignKey(nameof(ProductDetailId))]
        public virtual ProductDetail  ProductDetail { get; set; }

        public decimal BuyPrice { get; set; }
        public int Number { get; set; }

    }

}
