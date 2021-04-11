using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base.Coupon;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.Coupon;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class CouponCustomMapping:IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Coupon,CouponDto>()
                .ReverseMap();
        }
    }
}