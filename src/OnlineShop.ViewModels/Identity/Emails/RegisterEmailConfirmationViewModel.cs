using OnlineShop.Entities.Identity;

namespace OnlineShop.ViewModels.Admin.Emails
{
    public class RegisterEmailConfirmationViewModel : EmailsBase
    {
        public User User { set; get; }
        public string EmailConfirmationToken { set; get; }
    }
}
