using OnlineShop.Entities.Identity;

namespace OnlineShop.ViewModels.Identity.Emails
{
    public class UserProfileUpdateNotificationViewModel : EmailsBase
    {
        public User User { set; get; }
    }
}