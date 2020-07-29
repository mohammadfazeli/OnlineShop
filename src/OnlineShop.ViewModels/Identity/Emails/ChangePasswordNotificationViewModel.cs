using OnlineShop.Entities.Identity;

namespace OnlineShop.ViewModels.Identity.Emails
{
    public class ChangePasswordNotificationViewModel : EmailsBase
    {
        public User User { set; get; }
    }
}