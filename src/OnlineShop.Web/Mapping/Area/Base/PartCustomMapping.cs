using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class PartCustomMapping : IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Part, PartDto>()
                .ForMember(d => d.FullInfo,
                    opt => opt.MapFrom(s => s.Name + "" + s.Title))
                .ReverseMap();
        }
    }
}
