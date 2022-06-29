using TollStations.Core.SystemUsers.Users.Model;

namespace TollStations.Core.SystemUsers.Users.Service
{
    public interface IAccountService
    {
        Account GetByUsername(string username);
        bool IsExist(string username);
        bool IsUserFound(Account account, string passwordInput);
    }
}