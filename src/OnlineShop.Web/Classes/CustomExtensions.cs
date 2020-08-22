using OnlineShop.ViewModels;
using System;

namespace OnlineShop.Web.Classes
{
    public static class CustomExtensions
    {
        public static T Initialize<T>(this T dto) where T : BaseDto
        {
            dto.Id = Guid.NewGuid();
            dto.CreateOn = DateTime.Now;
            return dto;
        }
    }
}