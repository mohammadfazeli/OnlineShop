using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base.Coupon;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Coupon;

namespace OnlineShop.Services.Services.Area.Base
{
    public class CouponService:EntityService<Coupon,CouponDto>, ICouponService
    {
        public CouponService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<Coupon> repository) : base(unitOfWork,mapper,repository)
        {
        }
    }
}