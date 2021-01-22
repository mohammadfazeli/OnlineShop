using System;

namespace OnlineShop.ViewModels.Area
{
    public class CustomerCardItem
    {
        public CustomerCardItem()
        {
            Number = 1;
        }

        public Guid productId { get; set; }
        public string ProductName { get; set; }
        public int Number { get; set; }
        public decimal price { get; set; }
    }
}