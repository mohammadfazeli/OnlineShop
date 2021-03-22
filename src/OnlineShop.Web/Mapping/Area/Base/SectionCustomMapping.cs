using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.Section;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class SectionCustomMapping:IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Section,SectionDto>()
                .ForMember(d => d.SectionName,opt => opt.MapFrom(s => s.Name))
                .ReverseMap();

            profile.CreateMap<Section,SectionListDto>()
                .ForMember(d => d.SectionName,opt => opt.MapFrom(s => s.Name))
               .ReverseMap();
        }
    }
}