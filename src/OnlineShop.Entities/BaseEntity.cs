using OnlineShop.Entities.AuditableEntity;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Entities
{

    public abstract class BaseEntity : IAuditableEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreateOn = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }
        public bool InActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateOn { get; set; }

        public string Description { get; set; }
    }
}