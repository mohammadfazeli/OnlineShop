using AutoMapper;

namespace OnlineShop.IocConfig.CustomMapping
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile profile);
    }
}