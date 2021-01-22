using System;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ProductGroupSlider : BaseEntity
    {
        public ProductGroupSlider()
        {
        }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}