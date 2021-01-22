using AutoMapper;
using Microsoft.Extensions.Options;
<<<<<<< HEAD
using OnlineShop.ViewModels.Admin.Settings;
=======
using OnlineShop.ViewModels.Identity.Settings;
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2

namespace OnlineShop.IocConfig.CustomMapping
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile profile);
    }
}