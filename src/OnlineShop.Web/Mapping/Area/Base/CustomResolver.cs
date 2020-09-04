using AutoMapper;
using DNTPersianUtils.Core;
using System;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class CustomResolver : IValueResolver<DateTime, object, string>
    {
        string IValueResolver<DateTime, object, string>.Resolve(DateTime source, object destination, string destMember, ResolutionContext context)
        {
            return source.ToShortPersianDateString();
        }
    }
}