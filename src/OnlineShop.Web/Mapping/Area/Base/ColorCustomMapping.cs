using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.Colors;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ColorCustomMapping : IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Color, ColorstDto>()
                .ReverseMap();
        }
    }
}