using Microsoft.Extensions.Caching.Memory;

namespace OnlineShop.Services.Contracts
{
    public interface ICacheHelper
    {
        IMemoryCache _cache { set; get; }

        void Add<T>(T o,string key);
    }
}