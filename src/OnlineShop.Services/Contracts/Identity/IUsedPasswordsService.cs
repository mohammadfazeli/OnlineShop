using System;
using System.Threading.Tasks;
using OnlineShop.Entities.Identity;

namespace OnlineShop.Services.Contracts.Admin
{
    public interface IUsedPasswordsService
    {
        Task<bool> IsPreviouslyUsedPasswordAsync(User user, string newPassword);
        Task AddToUsedPasswordsListAsync(User user);
        Task<bool> IsLastUserPasswordTooOldAsync(int userId);
        Task<DateTime?> GetLastUserPasswordChangeDateAsync(int userId);
    }
}