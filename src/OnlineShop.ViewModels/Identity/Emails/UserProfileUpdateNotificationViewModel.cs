using OnlineShop.Entities.Identity;

namespace OnlineShop.ViewModels.Admin.Emails
{
    public class UserProfileUpdateNotificationViewModel : EmailsBase
    {
        public User User { set; get; }
    }
}