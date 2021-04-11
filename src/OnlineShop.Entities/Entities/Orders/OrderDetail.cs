using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Entities.Entities.Orders;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.WareHouse
{
    public class OrderDetail:BaseEntity
    {
        public OrderDetail()
        {
        }

        public Guid? OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        public Guid? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public int? PercentDiscount { get; set; }
        public int? Number { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalAfterDiscount { get; set; }
        public decimal? EndFee { get; set; }
    }
}