using OnlineShop.Common.Enums;
using System;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class Attachment : BaseEntity

    {
        public string Name { get; set; }
        public string ExtentionFile { get; set; }
        public Guid RelateId { get; set; }
        public AttachmentType Type { get; set; }
    }
}