using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels
{
    public class BaseDto
    {
        public BaseDto()
        {
            Id = Guid.NewGuid();
            CreateOn = DateTime.Now;
        }

        public Guid Id { get; set; }

        [Display(Name = nameof(Resource.Resource.InActive),ResourceType = typeof(Resource.Resource))]
        public bool InActive { get; set; }

        public bool IsDeleted { get; set; }
        public string CreatedByBrowserName { get; set; }
        public string ModifiedByBrowserName { get; set; }
        public string CreatedByIp { get; set; }
        public string ModifiedByIp { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? ModifiedByUserId { get; set; }

        [Display(Name = nameof(Resource.Resource.Description),ResourceType = typeof(Resource.Resource))]
        public string Description { get; set; }

        [Display(Name = nameof(Resource.Resource.CreateOn),ResourceType = typeof(Resource.Resource))]
        public DateTime CreateOn { get; set; }

        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}