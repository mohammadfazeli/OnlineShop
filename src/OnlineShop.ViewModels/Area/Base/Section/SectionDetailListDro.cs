using OnlineShop.ViewModels.Area.Base.Products;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Section
{
    public class SectionDetailListDro:BaseDto
    {
        [Display(Name = nameof(Resource.Resource.SectionName),Prompt = nameof(Resource.Resource.SectionName),ResourceType = typeof(Resource.Resource))]
        public string SectionName { get; set; }

        [Display(Name = nameof(Resource.Resource.SectionName),Prompt = nameof(Resource.Resource.SectionName),ResourceType = typeof(Resource.Resource))]
        public List<ProdcutGeneralInfoDto> Items { get; set; }
    }
}