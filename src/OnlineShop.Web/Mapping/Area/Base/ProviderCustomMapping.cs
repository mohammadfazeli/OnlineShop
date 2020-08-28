using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.Provider;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ProviderCustomMapping : IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Provider, ProviderDto>()
                .ReverseMap();
        }
    }
}