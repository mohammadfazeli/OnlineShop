using OnlineShop.Entities.Identity;

namespace OnlineShop.ViewModels.Admin.Emails
{
    public class ChangePasswordNotificationViewModel : EmailsBase
    {
        public User User { set; get; }
    }
}