using System.Collections.Generic;
using OnlineShop.Entities.Identity;

namespace OnlineShop.ViewModels.Identity
{
    public class TodayBirthDaysViewModel
    {
        public List<User> Users { set; get; }

        public AgeStatViewModel AgeStat { set; get; }
    }
}