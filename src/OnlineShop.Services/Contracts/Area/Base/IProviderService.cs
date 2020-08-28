using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.Provider;
using System;
using System.Collections.Generic;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IProviderService : IEntityService<Provider, ProviderDto>
    {
        List<ProviderDto> GetList();

        ProviderDto GetInfo(Guid id);
    }
}