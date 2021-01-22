using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Provider;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProviderService:EntityService<Provider,ProviderDto>, IProviderService
    {
        public ProviderService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<Provider> repository) : base(unitOfWork,mapper,repository)
        {
        }

        public List<ProviderDto> GetList()
        {
            return _mapper.Map(GetAll().OrderByDescending(x => x.CreateOn).ToList(),new List<ProviderDto>());
        }

        public ProviderDto GetInfo(Guid id)
        {
            return _mapper.Map(Get(id),new ProviderDto());
        }
    }
}