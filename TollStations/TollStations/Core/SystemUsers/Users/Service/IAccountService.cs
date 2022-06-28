using System.Collections.Generic;
using TollStations.Core.SystemUsers.Users.Model;

namespace TollStations.Core.SystemUsers.Users.Service
{
    public interface IAccountService
    {
        List<Account> GetAll();
        Dictionary<int, Account> GetAllById();
        Account GetById(int id);
        void Save();
    }
}