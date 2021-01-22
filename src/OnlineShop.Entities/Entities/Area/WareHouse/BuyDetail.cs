using OnlineShop.Entities.Entities.Area.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.WareHouse
{
    public class BuyDetail:BaseEntity
    {
        public Guid? BuyId { get; set; }

        [ForeignKey(nameof(BuyId))]
        public virtual ProductRequest Buy { get; set; }

        public Guid? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public decimal BuyPrice { get; set; }
        public int Number { get; set; }
    }
}