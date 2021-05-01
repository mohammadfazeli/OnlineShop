using Microsoft.AspNetCore.Mvc;
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

        public static string ReverseString(this string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static string RemoveControllerName<T>(this T controller) where T : Controller
        {
            return nameof(controller).Replace("controller","");
        }
    }
}