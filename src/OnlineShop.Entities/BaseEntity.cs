using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities
{

    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            //CreateOn = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public bool InActive { get; set; }
        public bool IsDeleted { get; set; }
        //public DateTime CreateOn { get; set; }
    }
}