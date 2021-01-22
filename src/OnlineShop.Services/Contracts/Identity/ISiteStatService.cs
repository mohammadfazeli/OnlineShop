using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Entities.Identity;
using System.Security.Claims;
using OnlineShop.ViewModels.Admin;

namespace OnlineShop.Services.Contracts.Admin
{
    public interface ISiteStatService
    {
        Task<List<User>> GetOnlineUsersListAsync(int numbersToTake, int minutesToTake);

        Task<List<User>> GetTodayBirthdayListAsync();

        Task UpdateUserLastVisitDateTimeAsync(ClaimsPrincipal claimsPrincipal);

        Task<AgeStatViewModel> GetUsersAverageAge();
    }
}