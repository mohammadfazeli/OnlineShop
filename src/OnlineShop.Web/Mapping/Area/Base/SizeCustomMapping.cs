using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.Sizes;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class SizeCustomMapping:IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Size,SizeDto>()
                .ReverseMap();
        }
    }
}