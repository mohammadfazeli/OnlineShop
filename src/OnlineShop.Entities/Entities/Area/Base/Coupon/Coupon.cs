using OnlineShop.Entities.Entities.Orders;
using System;
using System.Collections.Generic;

namespace OnlineShop.Entities.Entities.Area.Base.Coupon
{
    public class Coupon:BaseEntity
    {
        public Coupon()
        {
            Orders = new HashSet<Order>();
        }

        public string Name { get; set; }
        public int PercentDiscount { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}