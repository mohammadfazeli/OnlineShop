using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShop.Web.Controllers
{
    public class SiteController:Controller
    {
        public SiteController()
        {
        }

        protected void GeneratePageTitle(string title)
        {
            ViewData["Title"] = title;
        }
    }
}