using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Sizes;

namespace OnlineShop.Services.Services.Area.Base
{
    public class SizeService:EntityService<Size,SizeDto>, ISizeService
    {
        public SizeService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<Size> repository) : base(unitOfWork,mapper,repository)
        {
        }
    }
}