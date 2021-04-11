using System.Collections.Generic;

namespace OnlineShop.ViewModels.Area.Base.Products
{
    public class DisplayProdcutDto:BaseDto
    {
        public ProdcutGeneralInfoDto Product { get; set; }
        public List<ProdcutGeneralInfoDto> RelatedProducts { get; set; }
    }
}