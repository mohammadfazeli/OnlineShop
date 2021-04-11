using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineShop.Entities.Entities.Area.Base.Coupon;
using OnlineShop.Entities.Entities.Area.WareHouse;
using OnlineShop.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Orders
{
    public class Order:BaseEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int? OrderNo { get; set; }

        public DateTime RegisterOrderDate { get; set; }

        public int? RegisterUserId { get; set; }

        [ForeignKey(nameof(RegisterUserId))]
        public virtual User RegisterUser { get; set; }

        public Guid? CouponId { get; set; }

        [ForeignKey(nameof(CouponId))]
        public virtual Coupon Coupon { get; set; }

        public decimal? TotalAmount { get; set; }
        public decimal? TotalAfterDiscount { get; set; }
        public decimal? EndFee { get; set; }
        public bool Lock { get; set; }
        public bool IsPayment { get; set; }
        public string PaymentResult { get; set; }
        public int? FactorNo { get; set; }
        public string BankFollowupNo { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}