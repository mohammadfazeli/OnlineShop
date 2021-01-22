using System.Threading.Tasks;

namespace OnlineShop.Services.Contracts.Admin
{
    public interface ISmsSender
    {
        #region BaseClass

        Task SendSmsAsync(string number, string message);

        #endregion

        #region CustomMethods

        #endregion
    }
}