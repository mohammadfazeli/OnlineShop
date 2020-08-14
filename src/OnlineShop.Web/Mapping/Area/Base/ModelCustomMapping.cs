using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.Models;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ModelCustomMapping : IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Model, ModelDto>()
                .ReverseMap();
        }
    }
}