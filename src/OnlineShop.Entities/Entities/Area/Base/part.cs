using OnlineShop.Entities.AuditableEntity;
using System;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class Part : BaseEntity, IAuditableEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }

    }
}