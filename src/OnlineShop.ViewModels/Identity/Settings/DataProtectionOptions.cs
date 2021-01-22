using System;

namespace OnlineShop.ViewModels.Admin.Settings
{
    public class DataProtectionOptions
    {
        public TimeSpan DataProtectionKeyLifetime { get; set; }
        public string ApplicationName { get; set; }
    }
}