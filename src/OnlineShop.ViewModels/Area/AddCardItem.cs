using OnlineShop.Common.Enums;
using System;

namespace OnlineShop.ViewModels.Area
{
    public class AddCardItem
    {
        public AddCardItem()
        {
            AddCardItemType = AddCardItemType.link;
        }

        public AddCardItemType AddCardItemType { get; set; }
        public Guid ProductId { get; set; }
    }
}