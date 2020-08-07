using OnlineShop.Common.Enum;
using System;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class Attachment : BaseEntity

    {
        public string Name { get; set; }
        public Guid RelateId { get; set; }
        public AttachmentType Type { get; set; }
    }
}