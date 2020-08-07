using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Entities.Entities.Area.Base.Colors;
using OnlineShop.IocConfig.CustomMapping;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ColorCustomMapping : IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Color, ColorDto>()
                .ReverseMap();
        }
    }
}
