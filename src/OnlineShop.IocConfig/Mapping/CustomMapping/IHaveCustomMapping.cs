using AutoMapper;
using Microsoft.Extensions.Options;
using OnlineShop.ViewModels.Identity.Settings;

namespace OnlineShop.IocConfig.CustomMapping
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile profile);
    }
}